using System;
using System.Data;
using System.Net;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
using System.Configuration;

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

            string url = "http://www.omdbapi.com/?t=" + tbSearch.Text.Trim() + "&apikey=e17f08db";
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(url);
                JavaScriptSerializer oJS = new JavaScriptSerializer();
                ImdbEntity obj = new ImdbEntity();
                obj = oJS.Deserialize<ImdbEntity>(json);

                if (obj.Response == "True")
                {
                    tbTitle.Text = obj.Title;
                    tbYear.Text = obj.Year;
                    tbRated.Text = obj.imdbRating;
                    tbReleased.Text = obj.Released;
                    tbGenre.Text = obj.Genre;
                    tbActors.Text = obj.Actors;
                    tbPlot.Text = obj.Plot;
                    tbMetascore.Text = obj.Metascore;
                    pbPoster.ImageLocation = obj.Poster;
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

            var connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("AddNewMovie", conn))
                {
                    conn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", tbTitle.Text);
                    cmd.Parameters.AddWithValue("@Year", tbYear.Text);
                    cmd.Parameters.AddWithValue("@imdbRating", tbRated.Text);
                    cmd.Parameters.AddWithValue("@Released", tbReleased.Text);
                    cmd.Parameters.AddWithValue("@Genre", tbGenre.Text);
                    cmd.Parameters.AddWithValue("@Actors", tbActors.Text);
                    cmd.Parameters.AddWithValue("@Plot", tbPlot.Text);
                    cmd.Parameters.AddWithValue("@Metascore", tbMetascore.Text);
                    cmd.Parameters.AddWithValue("@Poster", pbPoster.ImageLocation);

                    var i = cmd.ExecuteNonQuery();

                    if (i >= 1)
                    {
                        MessageBox.Show("Movie is added to watch list!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Movie already exist in your watchlist!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
            }
        }

        private void btnWatchList_Click(object sender, EventArgs e)
        {
            WatchlistForm frm = new WatchlistForm();
            frm.ShowDialog();
        }

        private void brnRefresh_Click(object sender, EventArgs e)
        {
            tbActors.Text = tbGenre.Text = tbMetascore.Text = tbPlot.Text = tbRated.Text = tbReleased.Text = tbSearch.Text = tbTitle.Text = tbYear.Text = pbPoster.ImageLocation = string.Empty;
        }
    }
}
