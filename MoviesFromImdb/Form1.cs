using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace MoviesFromImdb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
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
                    MessageBox.Show("Movie not Found!!!");
                }


            }
        }
    }
}
