namespace MoviesFromImdb
{
    partial class WatchlistForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WatchlistForm));
            this.gridMovies = new System.Windows.Forms.DataGridView();
            this.cmsOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miMovieDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.miChangeStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.miDeleteMovie = new System.Windows.Forms.ToolStripMenuItem();
            this.bsMovies = new System.Windows.Forms.BindingSource(this.components);
            this.lblFound = new System.Windows.Forms.Label();
            this.chbWatched = new System.Windows.Forms.CheckBox();
            this.chbNotWatched = new System.Windows.Forms.CheckBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imdbRating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Released = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Genre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Actors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Metascore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Poster = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Watched = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MovieId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnShare = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridMovies)).BeginInit();
            this.cmsOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMovies)).BeginInit();
            this.SuspendLayout();
            // 
            // gridMovies
            // 
            this.gridMovies.AllowUserToAddRows = false;
            this.gridMovies.AllowUserToDeleteRows = false;
            this.gridMovies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridMovies.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMovies.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridMovies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMovies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.Year,
            this.imdbRating,
            this.Released,
            this.Genre,
            this.Actors,
            this.Plot,
            this.Metascore,
            this.Poster,
            this.Watched,
            this.MovieId});
            this.gridMovies.ContextMenuStrip = this.cmsOptions;
            this.gridMovies.DataSource = this.bsMovies;
            this.gridMovies.Location = new System.Drawing.Point(12, 30);
            this.gridMovies.Name = "gridMovies";
            this.gridMovies.ReadOnly = true;
            this.gridMovies.RowHeadersVisible = false;
            this.gridMovies.Size = new System.Drawing.Size(776, 324);
            this.gridMovies.TabIndex = 0;
            this.gridMovies.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridMovies_CellFormatting);
            this.gridMovies.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridMovies_CellMouseDown);
            // 
            // cmsOptions
            // 
            this.cmsOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miMovieDetails,
            this.miChangeStatus,
            this.miDeleteMovie});
            this.cmsOptions.Name = "cmsOptions";
            this.cmsOptions.Size = new System.Drawing.Size(191, 70);
            this.cmsOptions.Opening += new System.ComponentModel.CancelEventHandler(this.cmsOptions_Opening);
            // 
            // miMovieDetails
            // 
            this.miMovieDetails.Name = "miMovieDetails";
            this.miMovieDetails.Size = new System.Drawing.Size(190, 22);
            this.miMovieDetails.Text = "Show Movie Details";
            this.miMovieDetails.Click += new System.EventHandler(this.miMovieDetails_Click);
            // 
            // miChangeStatus
            // 
            this.miChangeStatus.Name = "miChangeStatus";
            this.miChangeStatus.Size = new System.Drawing.Size(190, 22);
            this.miChangeStatus.Text = "Change to watched";
            this.miChangeStatus.Click += new System.EventHandler(this.miChangeStatus_Click);
            // 
            // miDeleteMovie
            // 
            this.miDeleteMovie.Name = "miDeleteMovie";
            this.miDeleteMovie.Size = new System.Drawing.Size(190, 22);
            this.miDeleteMovie.Text = "Delete movie from list";
            this.miDeleteMovie.Click += new System.EventHandler(this.miDeleteMovie_Click);
            // 
            // bsMovies
            // 
            this.bsMovies.CurrentChanged += new System.EventHandler(this.bsMovies_CurrentChanged);
            // 
            // lblFound
            // 
            this.lblFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFound.AutoSize = true;
            this.lblFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFound.Location = new System.Drawing.Point(588, 10);
            this.lblFound.MinimumSize = new System.Drawing.Size(200, 13);
            this.lblFound.Name = "lblFound";
            this.lblFound.Size = new System.Drawing.Size(200, 13);
            this.lblFound.TabIndex = 68;
            this.lblFound.Text = "0 / 0";
            this.lblFound.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chbWatched
            // 
            this.chbWatched.AutoSize = true;
            this.chbWatched.BackColor = System.Drawing.Color.LightGreen;
            this.chbWatched.Location = new System.Drawing.Point(12, 6);
            this.chbWatched.Name = "chbWatched";
            this.chbWatched.Size = new System.Drawing.Size(70, 17);
            this.chbWatched.TabIndex = 69;
            this.chbWatched.Text = "Watched";
            this.chbWatched.UseVisualStyleBackColor = false;
            this.chbWatched.CheckedChanged += new System.EventHandler(this.chbWatched_CheckedChanged);
            // 
            // chbNotWatched
            // 
            this.chbNotWatched.AutoSize = true;
            this.chbNotWatched.BackColor = System.Drawing.Color.LightPink;
            this.chbNotWatched.Location = new System.Drawing.Point(88, 6);
            this.chbNotWatched.Name = "chbNotWatched";
            this.chbNotWatched.Size = new System.Drawing.Size(87, 17);
            this.chbNotWatched.TabIndex = 70;
            this.chbNotWatched.Text = "Not watched";
            this.chbNotWatched.UseVisualStyleBackColor = false;
            this.chbNotWatched.CheckedChanged += new System.EventHandler(this.chbWatched_CheckedChanged);
            // 
            // tbTitle
            // 
            this.tbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbTitle.BackColor = System.Drawing.Color.LemonChiffon;
            this.tbTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.tbTitle.Location = new System.Drawing.Point(12, 359);
            this.tbTitle.MinimumSize = new System.Drawing.Size(139, 20);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(139, 20);
            this.tbTitle.TabIndex = 71;
            this.tbTitle.Text = "Title...";
            this.tbTitle.TextChanged += new System.EventHandler(this.tbTitle_TextChanged);
            this.tbTitle.Enter += new System.EventHandler(this.tbTitle_Enter);
            this.tbTitle.Leave += new System.EventHandler(this.tbTitle_Leave);
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(329, 390);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(140, 23);
            this.btnExcel.TabIndex = 72;
            this.btnExcel.Text = "Make Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // Year
            // 
            this.Year.DataPropertyName = "Year";
            this.Year.HeaderText = "Year";
            this.Year.Name = "Year";
            this.Year.ReadOnly = true;
            // 
            // imdbRating
            // 
            this.imdbRating.DataPropertyName = "imdbRating";
            this.imdbRating.HeaderText = "IMDb Rating";
            this.imdbRating.Name = "imdbRating";
            this.imdbRating.ReadOnly = true;
            // 
            // Released
            // 
            this.Released.DataPropertyName = "Released";
            this.Released.HeaderText = "Released";
            this.Released.Name = "Released";
            this.Released.ReadOnly = true;
            // 
            // Genre
            // 
            this.Genre.DataPropertyName = "Genre";
            this.Genre.HeaderText = "Genre";
            this.Genre.Name = "Genre";
            this.Genre.ReadOnly = true;
            // 
            // Actors
            // 
            this.Actors.DataPropertyName = "Actors";
            this.Actors.HeaderText = "Actors";
            this.Actors.Name = "Actors";
            this.Actors.ReadOnly = true;
            // 
            // Plot
            // 
            this.Plot.DataPropertyName = "Plot";
            this.Plot.HeaderText = "Plot";
            this.Plot.Name = "Plot";
            this.Plot.ReadOnly = true;
            // 
            // Metascore
            // 
            this.Metascore.DataPropertyName = "Metascore";
            this.Metascore.HeaderText = "Metascore";
            this.Metascore.Name = "Metascore";
            this.Metascore.ReadOnly = true;
            // 
            // Poster
            // 
            this.Poster.DataPropertyName = "Poster";
            this.Poster.HeaderText = "Poster";
            this.Poster.Name = "Poster";
            this.Poster.ReadOnly = true;
            this.Poster.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Poster.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Watched
            // 
            this.Watched.DataPropertyName = "Watched";
            this.Watched.HeaderText = "Watched";
            this.Watched.Name = "Watched";
            this.Watched.ReadOnly = true;
            // 
            // MovieId
            // 
            this.MovieId.DataPropertyName = "MovieId";
            this.MovieId.HeaderText = "MovieId";
            this.MovieId.Name = "MovieId";
            this.MovieId.ReadOnly = true;
            this.MovieId.Visible = false;
            // 
            // btnShare
            // 
            this.btnShare.Location = new System.Drawing.Point(528, 389);
            this.btnShare.Name = "btnShare";
            this.btnShare.Size = new System.Drawing.Size(153, 23);
            this.btnShare.TabIndex = 73;
            this.btnShare.Text = "Share watchlist to friend";
            this.btnShare.UseVisualStyleBackColor = true;
            this.btnShare.Click += new System.EventHandler(this.btnShare_Click);
            // 
            // WatchlistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 460);
            this.Controls.Add(this.btnShare);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.chbNotWatched);
            this.Controls.Add(this.chbWatched);
            this.Controls.Add(this.lblFound);
            this.Controls.Add(this.gridMovies);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WatchlistForm";
            this.Text = "Watchlist";
            ((System.ComponentModel.ISupportInitialize)(this.gridMovies)).EndInit();
            this.cmsOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsMovies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridMovies;
        private System.Windows.Forms.BindingSource bsMovies;
        private System.Windows.Forms.ContextMenuStrip cmsOptions;
        private System.Windows.Forms.ToolStripMenuItem miMovieDetails;
        private System.Windows.Forms.ToolStripMenuItem miChangeStatus;
        private System.Windows.Forms.ToolStripMenuItem miDeleteMovie;
        private System.Windows.Forms.Label lblFound;
        private System.Windows.Forms.CheckBox chbWatched;
        private System.Windows.Forms.CheckBox chbNotWatched;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn imdbRating;
        private System.Windows.Forms.DataGridViewTextBoxColumn Released;
        private System.Windows.Forms.DataGridViewTextBoxColumn Genre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Actors;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plot;
        private System.Windows.Forms.DataGridViewTextBoxColumn Metascore;
        private System.Windows.Forms.DataGridViewTextBoxColumn Poster;
        private System.Windows.Forms.DataGridViewTextBoxColumn Watched;
        private System.Windows.Forms.DataGridViewTextBoxColumn MovieId;
        private System.Windows.Forms.Button btnShare;
    }
}