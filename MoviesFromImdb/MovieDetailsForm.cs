using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace MoviesFromImdb
{
    public partial class MovieDetailsForm : Form
    {
        private BindingSource _bsMovies;

        public MovieDetailsForm()
        {
            InitializeComponent();
        }

        public MovieDetailsForm(ImdbEntity obj)
        {
            InitializeComponent();
            tbTitle.Text = obj.Title;
            tbYear.Text = obj.Year;
            tbRated.Text = obj.imdbRating;
            tbReleased.Text = obj.Released;
            tbGenre.Text = obj.Genre;
            tbActors.Text = obj.Actors;
            tbPlot.Text = obj.Plot;
            tbMetascore.Text = obj.Metascore;
            pbPoster.ImageLocation = obj.Poster;
            btnLeft.Hide();
            btnRight.Hide();

        }

        public MovieDetailsForm(BindingSource bsMovies)
        {
            InitializeComponent();
            btnAddToWatchlist.Hide();
            _bsMovies = bsMovies;
            FillUpFields(_bsMovies);
        }

        private void FillUpFields(BindingSource bsMovies)
        {
            DataRowView drv = bsMovies.Current as DataRowView;

            if (drv != null)
            {
                tbTitle.Text = drv["Title"].ToString();
                tbYear.Text = drv["Year"].ToString();
                tbReleased.Text = drv["Released"].ToString();
                tbRated.Text = drv["imdbRating"].ToString();
                tbGenre.Text = drv["Genre"].ToString();
                tbActors.Text = drv["Actors"].ToString();
                tbPlot.Text = drv["Plot"].ToString();
                tbMetascore.Text = drv["Metascore"].ToString();
                pbPoster.ImageLocation = drv["Poster"].ToString();

                btnLeft.Enabled = _bsMovies.IndexOf(drv) != 0;
                btnRight.Enabled = _bsMovies.IndexOf(drv) != _bsMovies.Count - 1;
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            _bsMovies.MovePrevious();
            FillUpFields(_bsMovies);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            _bsMovies.MoveNext();
            FillUpFields(_bsMovies);
        }

        private void MovieDetailsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();

            if (e.KeyCode == Keys.Right) btnRight.PerformClick();

            if (e.KeyCode == Keys.Left) btnLeft.PerformClick();
        }

        private void btnAddToWatchlist_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbTitle.Text) && string.IsNullOrEmpty(tbYear.Text) && string.IsNullOrEmpty(tbRated.Text) && string.IsNullOrEmpty(tbReleased.Text) && string.IsNullOrEmpty(tbGenre.Text) && string.IsNullOrEmpty(tbActors.Text) && string.IsNullOrEmpty(tbPlot.Text) && string.IsNullOrEmpty(tbMetascore.Text) && string.IsNullOrEmpty(pbPoster.ImageLocation))
            {
                MessageBox.Show("Fields cannot be empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Image img = pbPoster.Image;
            byte[] arr;
            ImageConverter converter = new ImageConverter();
            arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

            ImdbEntity obj = new ImdbEntity()
            {
                Title = tbTitle.Text,
                Year = tbYear.Text,
                Rated = tbRated.Text,
                Released = tbReleased.Text,
                Genre = tbGenre.Text,
                Actors = tbActors.Text,
                Plot = tbPlot.Text,
                Metascore = tbMetascore.Text,
                Poster = pbPoster.ImageLocation,
                Picture = arr
            };

            DAL.AddMovie(obj);
        }
    }
}
