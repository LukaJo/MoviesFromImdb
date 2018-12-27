using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace MoviesFromImdb
{
    public partial class Top100IMDbForm : Form
    {
        public Top100IMDbForm()
        {
            InitializeComponent();
            top100Movies();
        }

        private void top100Movies()
        {
            if (!File.Exists(@"C:\Users\your\Documents\TestApp\MoviesFromImdb\top100.json"))
            {
                MessageBox.Show("File top100.json not exist!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string json = File.ReadAllText(@"C:\Users\your\Documents\TestApp\MoviesFromImdb\top100.json");
            var result = JsonConvert.DeserializeObject<List<Top100IMDb>>(json);
            gridTop100.AutoGenerateColumns = true;           
            gridTop100.DataSource = result;

            this.gridTop100.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.gridTop100.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.gridTop100.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }


        private void miMovieDetails_Click(object sender, EventArgs e)
        {
            string url = "http://www.omdbapi.com/?i=" + gridTop100[2, gridTop100.CurrentCell.RowIndex].Value.ToString().Trim() + "&apikey=e17f08db";

            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(url);
                var result = JsonConvert.DeserializeObject<ImdbEntity>(json);

                if (result.Response == "True")
                {
                    MovieDetailsForm frm = new MovieDetailsForm(result);
                    frm.Show();

                }
                else
                {
                    MessageBox.Show("Movie not found!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void gridTop100_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right)
            {
                DataGridViewCell c = (sender as DataGridView)[e.ColumnIndex, e.RowIndex];
                if (!c.Selected)
                {
                    c.DataGridView.ClearSelection();
                    c.DataGridView.CurrentCell = c;
                    c.Selected = true;
                }
            }
        }

        private void Top100IMDbForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }
    }
}
