using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public MovieDetailsForm(BindingSource bsMovies)
        {
            InitializeComponent();
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
    }
}
