using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoviesFromImdb
{

    public class DAL
    {

        public static DataSet GetAllMovies()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllMovies", conn))
                {
                    conn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    return ds;
                }
            }


        }

        public static void AddMovie(ImdbEntity imdbentity)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("AddNewMovie", conn))
                {
                    conn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", imdbentity.Title);
                    cmd.Parameters.AddWithValue("@Year", imdbentity.Year);
                    cmd.Parameters.AddWithValue("@imdbRating", imdbentity.Rated);
                    cmd.Parameters.AddWithValue("@Released", imdbentity.Released);
                    cmd.Parameters.AddWithValue("@Genre", imdbentity.Genre);
                    cmd.Parameters.AddWithValue("@Actors", imdbentity.Actors);
                    cmd.Parameters.AddWithValue("@Plot", imdbentity.Plot);
                    cmd.Parameters.AddWithValue("@Metascore", imdbentity.Metascore);
                    cmd.Parameters.AddWithValue("@Poster", imdbentity.Poster);
                    cmd.Parameters.AddWithValue("@Image", imdbentity.Picture);

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

        public static void ChangeMovieStatus(string movieId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ChangeWatchedStatus", conn))
                {
                    conn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("MovieId", movieId);

                    var i = cmd.ExecuteNonQuery();

                    if (i >= 1)
                    {
                        MessageBox.Show("Movie status changed from not watched to watched!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Movie status cannot change!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }

        }
        public static void DeleteMovie(string movieId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteMovie", conn))
                {
                    conn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("MovieId", movieId);

                    var i = cmd.ExecuteNonQuery();

                    if (i >= 1)
                    {
                        MessageBox.Show("Movie deleted from watchlist!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Movie delete failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }

        }
    }
}
