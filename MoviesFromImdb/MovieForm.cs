using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MoviesFromImdb
{
    public partial class MovieForm : Form
    {
        public MovieForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(tbSearch.Text))
            {
                MessageBox.Show("Please enter movie name!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string url;
            if (string.IsNullOrEmpty(tbYearParameter.Text))
            {
                url = "http://www.omdbapi.com/?t=" + tbSearch.Text.Trim() + "&apikey=e17f08db";
            }
            else
            {

                int YearParameterNumber;
                if (!int.TryParse(tbYearParameter.Text, out YearParameterNumber))
                {
                    MessageBox.Show("The Year format is bad;Enter only year!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                url = "http://www.omdbapi.com/?t=" + tbSearch.Text.Trim() + "&y=" + tbYearParameter.Text.Trim() + "&apikey=e17f08db";
            }

            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(url);
                var result = JsonConvert.DeserializeObject<ImdbEntity>(json);

                if (result.Response == "True")
                {
                    tbTitle.Text = result.Title;
                    tbYear.Text = result.Year;
                    tbRated.Text = result.imdbRating;
                    tbReleased.Text = result.Released;
                    tbGenre.Text = result.Genre;
                    tbActors.Text = result.Actors;
                    tbPlot.Text = result.Plot;
                    tbMetascore.Text = result.Metascore;
                    pbPoster.ImageLocation = result.Poster;
                }
                else
                {
                    MessageBox.Show("Movie not found!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
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

        private void btnWatchList_Click(object sender, EventArgs e)
        {
            WatchlistForm frm = new WatchlistForm();
            frm.ShowDialog();
        }

        private void brnRefresh_Click(object sender, EventArgs e)
        {
            tbActors.Text = tbGenre.Text = tbMetascore.Text = tbPlot.Text = tbRated.Text = tbReleased.Text = tbSearch.Text = tbTitle.Text = tbYear.Text = tbYearParameter.Text = pbPoster.ImageLocation = string.Empty;
        }

        private void MovieForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();

            if (e.KeyCode == Keys.Enter) btnSearch.PerformClick();
        }

        private void btnTop100_Click(object sender, EventArgs e)
        {
            Top100IMDbForm frm = new Top100IMDbForm();
            frm.ShowDialog();
        }
    }
}
