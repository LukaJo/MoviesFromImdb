using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace MoviesFromImdb
{
    public partial class WatchlistForm : Form
    {
        private DataSet dsMovies;

        public WatchlistForm()
        {
            InitializeComponent();
            FillUpGrid();
        }

        public void FillUpGrid()
        {

            dsMovies = DAL.GetAllMovies();
            bsMovies.DataSource = dsMovies.Tables[0];
            gridMovies.DataSource = bsMovies;
        }


        private void cmsOptions_Opening(object sender, CancelEventArgs e)
        {
            if (gridMovies.Rows.Count == 0)
            {
                miMovieDetails.Enabled = false;
                miChangeStatus.Enabled = false;
                miDeleteMovie.Enabled = false;
            }
            else
            {
                miMovieDetails.Enabled = true;
                miDeleteMovie.Enabled = true;
                if (gridMovies["Watched", gridMovies.CurrentCell.RowIndex].Value.ToString() != "N")
                {
                    miChangeStatus.Enabled = false;
                }
                else miChangeStatus.Enabled = true;
            }
        }

        private void miMovieDetails_Click(object sender, EventArgs e)
        {
            MovieDetailsForm frm = new MovieDetailsForm(bsMovies);
            frm.ShowDialog();
        }

        private void gridMovies_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
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

        private void miChangeStatus_Click(object sender, EventArgs e)
        {
            DAL.ChangeMovieStatus(gridMovies["MovieId", gridMovies.CurrentCell.RowIndex].Value.ToString());

            FillUpGrid();

        }

        private void miDeleteMovie_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete movie?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) !=
              DialogResult.Yes)
                return;

            DAL.DeleteMovie(gridMovies["MovieId", gridMovies.CurrentCell.RowIndex].Value.ToString());

            FillUpGrid();
        }

        private void bsMovies_CurrentChanged(object sender, EventArgs e)
        {
            lblFound.Text = (bsMovies.IndexOf(bsMovies.Current) + 1).ToString() + " / " + bsMovies.Count.ToString();
        }

        private void gridMovies_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var watched = gridMovies["Watched", e.RowIndex].Value.ToString();

            if (watched == "N")
            {
                gridMovies.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightPink;
            }
            if (watched == "Y")
            {
                gridMovies.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        private void chbWatched_CheckedChanged(object sender, EventArgs e)
        {
            if (chbWatched.Checked && chbNotWatched.Checked == false)
            {
                bsMovies.Filter = "Watched = 'Y'";
            }
            if (chbWatched.Checked == false && chbNotWatched.Checked)
            {
                bsMovies.Filter = "Watched = 'N'";

            }
            if (chbWatched.Checked == false && chbNotWatched.Checked == false)
            {
                bsMovies.RemoveFilter();
            }

            if (chbWatched.Checked && chbNotWatched.Checked)
            {
                bsMovies.RemoveFilter();
            }
        }

        #region filter by Title
        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            bsMovies.Filter = string.Format("Title LIKE '%{0}%'", tbTitle.Text);
        }

        private void tbTitle_Enter(object sender, EventArgs e)
        {
            if (tbTitle.Text == "Title...")
            {
                tbTitle.ForeColor = Color.Black;
                tbTitle.Text = string.Empty;
            }
        }

        private void tbTitle_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbTitle.Text))
            {
                tbTitle.ForeColor = Color.DarkGray;
                tbTitle.Text = "Title...";
                bsMovies.RemoveFilter();
            }

        }

        #endregion

        #region Excel
        private void copyAlltoClipboardFromGrid()
        {
            gridMovies.SelectAll();
            DataObject dataObj = gridMovies.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "My_Watchlist.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // Copy DataGridView results to clipboard
                copyAlltoClipboardFromGrid();

                object misValue = System.Reflection.Missing.Value;
                Excel.Application xlexcel = new Excel.Application();

                xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
                Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


                // Format column C as text before pasting results, this was required for my data
                Excel.Range rng = xlWorkSheet.get_Range("C:C").Cells;
                rng.NumberFormat = "@";

                // Paste clipboard results to worksheet range
                Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                // Add header text from columns in datagridview to worksheet
                for (int i = 0; i < gridMovies.Columns.Count; i++)
                {
                    xlWorkSheet.Cells[1, i + 1] = gridMovies.Columns[i].HeaderText;
                }

                // Delete blank column K
                Excel.Range delRng = xlWorkSheet.get_Range("K:K").Cells;
                delRng.Delete(Type.Missing);


                // Save the excel file under the captured location from the SaveFileDialog
                xlWorkBook.SaveAs(sfd.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlexcel.DisplayAlerts = true;
                xlWorkBook.Close(true, misValue, misValue);
                xlexcel.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlexcel);

                // Clear Clipboard and DataGridView selection
                Clipboard.Clear();
                gridMovies.ClearSelection();

                // Open the newly saved excel file
                if (File.Exists(sfd.FileName))
                    System.Diagnostics.Process.Start(sfd.FileName);
            }
        }
        #endregion

        private void btnShare_Click(object sender, EventArgs e)
        {
            EmailForm frm = new EmailForm();
            frm.ShowDialog();

        }

        private void btnWa_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Title: ");
            sb.Append(gridMovies["Title", gridMovies.CurrentCell.RowIndex].Value.ToString());
            sb.Append(" ");
            sb.Append("Genre: ");
            sb.Append(gridMovies["Genre", gridMovies.CurrentCell.RowIndex].Value.ToString());
            sb.Append(" ");
            sb.Append("Actors: ");
            sb.Append(gridMovies["Actors", gridMovies.CurrentCell.RowIndex].Value.ToString());
            sb.Append(" ");
            sb.Append("Plot: ");
            sb.Append(gridMovies["Plot", gridMovies.CurrentCell.RowIndex].Value.ToString());
            sb.Append(" ");
            sb.Append("IMDb Rating: ");
            sb.Append(gridMovies["imdbRating", gridMovies.CurrentCell.RowIndex].Value.ToString());
            sb.Append(" ");
            sb.Append("Metascore: ");
            sb.Append(gridMovies["Metascore", gridMovies.CurrentCell.RowIndex].Value.ToString());


            System.Diagnostics.Process.Start("https://api.whatsapp.com/send?phone=yourphonehere&text=" + sb.ToString());
        }

        private void WatchlistForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();

        }
    }
}
