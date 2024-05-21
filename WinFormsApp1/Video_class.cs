using WinFormsApp;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using AxWMPLib;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using Org.BouncyCastle.Asn1.X509;
using Microsoft.VisualBasic.ApplicationServices;
using System.Reflection;

namespace WinFormsApp1
{
    public class Video_class
    {
        private readonly Sql SqlInstance = new Sql();
        private int id;
        private Form _form;
        string[] movie;
        int movieid;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private Panel panel1;
        private RoundedButton button1;
        private RoundedButton server;
        private RoundedButton local;
        private RoundedButton more;
        private Panel panel3;
        private Panel panel4;
        private RoundedPanel poster_panel;
        private Label label2;
        private PictureBox iconPictureBox;
        private PictureBox iconPictureBox2;
        private PictureBox iconPictureBox3;
        private PictureBox iconPictureBox4;
        private PictureBox iconPictureBox5;
        private PictureBox iconPictureBox69;
        private RoundedPanel roundedPanelTop;
        private System.Windows.Forms.TextBox textBox1;
        private RoundedPanel Comment_panel;
        private Label label1;
        private RoundedPanel trailer_panel;
        private Panel data_panel;
        private RoundedPanel rate_panel;
        private Label Trailer;
        private Label label3;
        private System.Threading.Timer timer;
        private System.Windows.Forms.TextBox newCommentTextBox;
        private ColorDetectorForm _colorDetectorForm;

        public Video_class(Form form, string[] array, int movieid, int id)
        {
            this.id = id;
            _form = form;
            _form.BackColor = Color.Black;
            this.movie = array;
            this.movieid = movieid;

            _colorDetectorForm = new ColorDetectorForm();
            _colorDetectorForm.ColorUpdated += ColorDetectorForm_ColorUpdated;

            iconPictureBox69 = new PictureBox();
            iconPictureBox69.SizeMode = PictureBoxSizeMode.Zoom; // Maintain aspect ratio
            iconPictureBox69.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\opacity.png");
            iconPictureBox69.Name = "wide_panel";
            iconPictureBox69.Dock = DockStyle.Fill;
            iconPictureBox69.TabIndex = 13;
            _form.Controls.Add(iconPictureBox69);

            InitializeComponent();
            PlayVideoFromDatabase();
            PopulateMovieDataPanel();
            _form.BackgroundImage = null;

            int rate = SqlInstance.GetUserRating(movieid, id);
            if (rate > 0)
            {
                for (int i = 1; i <= rate; i++)
                {
                    Control[] stars = rate_panel.Controls.Find("star" + i, true);
                    PictureBox star = (PictureBox)stars[0];
                    star.ImageLocation = @"C:\Users\enkud\Desktop\Cinema\back_image\y_star.png";
                    star.MouseEnter -= Star_MouseEnter;
                    star.MouseClick -= Star_MouseClick;
                }
                for (int i = rate + 1; i <= 5; i++)
                {
                    Control[] stars = rate_panel.Controls.Find("star" + i, true);
                    PictureBox star = (PictureBox)stars[0];
                    star.MouseEnter -= Star_MouseEnter;
                    star.MouseClick -= Star_MouseClick;
                }
            }
        }

        void InitializeComponent()
        {
            axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            panel1 = new Panel();
            button1 = new RoundedButton();
            server = new RoundedButton();
            local = new RoundedButton();
            more = new RoundedButton();
            iconPictureBox = new PictureBox();
            iconPictureBox2 = new PictureBox();
            iconPictureBox4 = new PictureBox();
            iconPictureBox5 = new PictureBox();
            roundedPanelTop = new RoundedPanel();
            textBox1 = new System.Windows.Forms.TextBox();
            panel3 = new Panel();
            label3 = new Label();
            data_panel = new Panel();
            rate_panel = new RoundedPanel();
            label2 = new Label();
            Comment_panel = new RoundedPanel();
            Trailer = new Label();
            label1 = new Label();
            trailer_panel = new RoundedPanel();
            poster_panel = new RoundedPanel();
            panel4 = new Panel();

            // axWindowsMediaPlayer1
            axWindowsMediaPlayer1.Enabled = true;
            axWindowsMediaPlayer1.Location = new Point(436, 78);
            axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            axWindowsMediaPlayer1.Size = new Size(1100, 623);
            axWindowsMediaPlayer1.TabIndex = 1;

            // panel1
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(server);
            panel1.Controls.Add(local);
            panel1.Dock = DockStyle.Top;
            panel1.Name = "panel1";
            panel1.Size = new Size(1920, 64 + 3);

            // Initialize the textBox1 and its properties
            textBox1.BackColor = Color.FromArgb(29, 41, 43);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new System.Drawing.Font("Segoe UI", 15F);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(20, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(420, 32);
            textBox1.TabIndex = 5;
            textBox1.Text = "Search movies...";
            textBox1.ForeColor = Color.Gray;
            textBox1.GotFocus += TextBox1_GotFocus;
            textBox1.KeyDown += TextBox1_KeyDown;

            // Define the GotFocus event handler
            void TextBox1_GotFocus(object sender, EventArgs e)
            {
                roundedPanelTop.EdgeColor = Color.Teal;
                roundedPanelTop.Invalidate();
                roundedPanelTop.Update();

                if (textBox1.Text == "Search movies...")
                {
                    textBox1.Text = "";
                    textBox1.ForeColor = Color.White;
                }
            }

            // Define the KeyDown event handler
            void TextBox1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string searchText = textBox1.Text;
                    PerformSearch(searchText);
                }
            }

            void PerformSearch(string searchText)
            {
                axWindowsMediaPlayer1.close();

                foreach (Control control in _form.Controls)
                {
                    control.Dispose();
                }
                _form.Controls.Clear();

                Home homePage = new Home(_form, id);
                homePage.str = searchText;
                KeyEventArgs keyEventArgs = new KeyEventArgs(Keys.Enter);
                homePage.TextBox1_KeyDown(new System.Windows.Forms.TextBox { Text = searchText }, keyEventArgs);

                _form.WindowState = FormWindowState.Maximized;

                homePage._form.Show();
                homePage._form.Refresh();
            }

            // Initialize the roundedPanelTop and its properties
            roundedPanelTop.BackColor = Color.FromArgb(29, 41, 43);
            roundedPanelTop.Controls.Add(textBox1);
            roundedPanelTop.CornerRadius = 10;
            roundedPanelTop.Location = new Point(740, 10);
            roundedPanelTop.Name = "roundedPanel1";
            roundedPanelTop.Size = new Size(519, 44);
            roundedPanelTop.TabIndex = 13;
            roundedPanelTop.BorderStyle = System.Windows.Forms.BorderStyle.None;
            roundedPanelTop.EdgeColor = Color.FromArgb(29, 41, 43);
            panel1.Controls.Add(roundedPanelTop);

            // button1
            button1.BackColor = Color.Teal;
            button1.FlatAppearance.BorderSize = 0;
            button1.CornerRadius = 10;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new System.Drawing.Font("Segoe UI", 14F);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(1788, 12);
            button1.Name = "button1";
            button1.Size = new Size(118, 39);
            button1.TabIndex = 0;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            
            server.BackColor = Color.FromArgb(24, 24, 24);
            server.FlatAppearance.BorderSize = 0;
            server.CornerRadius = 7;
            server.FlatStyle = FlatStyle.Flat;
            server.Font = new System.Drawing.Font("Segoe UI", 14F);
            server.ForeColor = SystemColors.ButtonHighlight;
            server.Location = new Point(125, 12);
            server.Name = "server 2";
            server.Size = new Size(100, 40);
            server.TabIndex = 0;
            server.Text = "server 2";
            server.UseVisualStyleBackColor = false;
            server.Click += server_Click;
            
            local.BackColor = Color.FromArgb(24, 24, 24);
            local.FlatAppearance.BorderSize = 0;
            local.CornerRadius = 7;
            local.FlatStyle = FlatStyle.Flat;
            local.Font = new System.Drawing.Font("Segoe UI", 14F);
            local.ForeColor = SystemColors.ButtonHighlight;
            local.Location = new Point(15, 12);
            local.Name = "server 1";
            local.Size = new Size(100, 40);
            local.TabIndex = 0;
            local.Text = "server 1";
            local.UseVisualStyleBackColor = false;
            local.Click += local_Click;

            // more button
            more.Visible = false;
            more.BackColor = Color.Teal;
            more.FlatAppearance.BorderSize = 0;
            more.CornerRadius = 8;
            more.FlatStyle = FlatStyle.Flat;
            more.Font = new System.Drawing.Font("Segoe UI", 14F);
            more.ForeColor = SystemColors.ButtonHighlight;
            more.Location = new Point(1721, 24);
            more.Name = "more";
            more.Size = new Size(121, 35);
            more.TabIndex = 0;
            more.Text = "More";
            more.UseVisualStyleBackColor = false;
            more.Click += more_Click;

            // iconPictureBox4
            iconPictureBox4.SizeMode = PictureBoxSizeMode.Zoom; // Maintain aspect ratio
            iconPictureBox4.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\rate.png");
            iconPictureBox4.Location = new(900, 20);
            iconPictureBox4.Name = "wide_panel";
            iconPictureBox4.Size = new Size(217, 35);

            // iconPictureBox5
            iconPictureBox5.SizeMode = PictureBoxSizeMode.Zoom; // Maintain aspect ratio
            iconPictureBox5.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\mp4_bar.png");
            iconPictureBox5.Location = new(436, 653);
            iconPictureBox5.Name = "wide_panel";
            iconPictureBox5.Size = new Size(1100, 48);
            iconPictureBox5.BringToFront();

            // panel3
            panel3.BackColor = Color.FromArgb(24, 24, 24);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(data_panel);
            panel3.Controls.Add(rate_panel);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(iconPictureBox);
            panel3.Controls.Add(iconPictureBox2);
            panel3.Controls.Add(iconPictureBox4);
            panel3.Controls.Add(Comment_panel);
            panel3.Controls.Add(more);
            panel3.Controls.Add(Trailer);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(trailer_panel);
            panel3.Controls.Add(poster_panel);
            panel3.Dock = DockStyle.Bottom;
            panel3.Name = "panel3";
            panel3.Size = new Size(1920, 473);

            // label3
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 14F);
            label3.ForeColor = Color.Gray;
            label3.Location = new Point(328, 381);
            label3.Name = "label3";
            label3.Size = new Size(394, 25);
            label3.Text = "Final movie trailer on youtube //https://grandrs_usk.com/ by jordan and aly...";

            // data_panel
            data_panel.BackColor = Color.FromArgb(24, 24, 24);
            data_panel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            data_panel.Location = new Point(326, 80);
            data_panel.Name = "data_panel";
            data_panel.Size = new Size(827, 250);

            // rate_panelcount
            rate_panel.BackColor = Color.Transparent;
            rate_panel.Location = new Point(900, 60);
            rate_panel.Name = "rate_panel";
            rate_panel.Size = new Size(220, 50);
            rate_panel.TabIndex = 6;
            rate_panel.EdgeColor = Color.Transparent;
            rate_panel.BringToFront();

            for (int i = 1; i <= 5; i++)
            {
                PictureBox star = new PictureBox();
                star.Name = "star" + i;
                star.Size = new Size(40, 40); // Adjust the size of the stars as needed
                star.Location = new Point(10 + (i - 1) * 40, 5); // Adjust the positioning of the stars as needed
                star.ImageLocation = @"C:\Users\enkud\Desktop\Cinema\back_image\e_star.png"; // Path to the empty star image
                star.Tag = i; // Set the tag to keep track of the star index
                star.SizeMode = PictureBoxSizeMode.StretchImage;
                star.MouseEnter += Star_MouseEnter;
                star.MouseClick += Star_MouseClick;

                rate_panel.Controls.Add(star);
            }

            // iconPictureBox
            iconPictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Maintain aspect ratio
            iconPictureBox.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\comments.png");
            iconPictureBox.Location = new Point(1244, 16);
            iconPictureBox.Name = "wide_panel";
            iconPictureBox.Size = new Size(217, 35);

            // Comment_panel
            Comment_panel.BackColor = Color.FromArgb(24, 24, 24);
            Comment_panel.Location = new Point(1244, 75);
            Comment_panel.Name = "Comment_panel";
            Comment_panel.Size = new Size(608, 276);
            Comment_panel.EdgeColor = Color.FromArgb(29, 41, 43);

            int commentY = 10;
            newCommentTextBox = new System.Windows.Forms.TextBox();
            newCommentTextBox.BorderStyle = BorderStyle.None;
            newCommentTextBox.Font = new System.Drawing.Font("Segoe UI", 15F);
            newCommentTextBox.BackColor = Color.FromArgb(24, 24, 24);
            newCommentTextBox.ForeColor = Color.White;
            newCommentTextBox.Location = new Point(20, 7); // Position below existing comments
            newCommentTextBox.Width = 375;

            RoundedButton addCommentButton = new RoundedButton();
            addCommentButton.CornerRadius = 11;
            addCommentButton.BackColor = Color.Gray;
            addCommentButton.UseVisualStyleBackColor = false;
            addCommentButton.FlatAppearance.BorderSize = 0;
            addCommentButton.FlatStyle = FlatStyle.Flat;
            addCommentButton.Text = "Post";
            addCommentButton.Width = 100;
            addCommentButton.Height = 33;
            addCommentButton.Location = new Point(newCommentTextBox.Width + 127, 5);
            addCommentButton.Click += AddCommentButton_Click;

            RoundedPanel roundedPanel1 = new RoundedPanel();
            roundedPanel1.BackColor = Color.Transparent;
            roundedPanel1.Controls.Add(newCommentTextBox);
            roundedPanel1.Controls.Add(addCommentButton);
            roundedPanel1.CornerRadius = 10;
            roundedPanel1.Location = new Point(Comment_panel.Left, Comment_panel.Bottom + 20); // Position relative to Comment_panel
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(610, 44);
            roundedPanel1.EdgeColor = Color.FromArgb(29, 41, 43);
            roundedPanel1.BringToFront();

            panel3.Controls.Add(roundedPanel1);

            // iconPictureBox2
            iconPictureBox2.SizeMode = PictureBoxSizeMode.Zoom; // Maintain aspect ratio
            iconPictureBox2.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\logo.png");
            iconPictureBox2.Location = new Point(326, 349);
            iconPictureBox2.Name = "wide_panel";
            iconPictureBox2.Size = new Size(17, 27);

            // Trailer
            Trailer.AutoSize = true;
            Trailer.Font = new System.Drawing.Font("Segoe UI", 18F);
            Trailer.ForeColor = Color.White;
            Trailer.Location = new Point(346, 346);
            Trailer.Name = "Trailer";
            Trailer.Size = new Size(78, 32);

            // label1
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 36F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(324, 10);
            label1.Name = "label1";
            label1.Size = new Size(118, 65);
            label1.Text = "Title";

            // trailer_panel
            trailer_panel.BackColor = Color.FromArgb(24, 24, 24);
            trailer_panel.Location = new Point(66, 346);
            trailer_panel.Name = "trailer_panel";
            trailer_panel.Size = new Size(241, 105);

            // poster_panel
            poster_panel.BackColor = Color.FromArgb(24, 24, 24);
            poster_panel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            poster_panel.Location = new Point(66, 18);
            poster_panel.Name = "poster_panel";
            poster_panel.Size = new Size(241, 312);

            // panel4
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 64);
            panel4.Name = "panel4";
            panel4.Size = new Size(1920, 650);

            iconPictureBox69.Controls.Add(iconPictureBox5);
            iconPictureBox69.Controls.Add(axWindowsMediaPlayer1);
            iconPictureBox69.Controls.Add(panel3);
            iconPictureBox69.Controls.Add(panel1);

            _form.AutoScaleDimensions = new SizeF(7F, 15F);
            _form.AutoScaleMode = AutoScaleMode.Font;
            _form.ClientSize = new Size(1487, 931);
            _form.Name = "Form1";
            _form.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).EndInit();
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            _form.ResumeLayout(false);
        }

        private void ColorDetectorForm_ColorUpdated(object sender, ColorEventArgs e)
        {
            UpdateFormColors(e.Color);
        }

        private void UpdateFormColors(Color color)
        {
            _form.BackColor = color;
        }


        private void PlayVideoFromDatabase()
        {
            string videoPath = SqlInstance.GetVideoPath(movieid);
            string imagePath = SqlInstance.GetWideImagePath(movieid);
            if (!string.IsNullOrEmpty(videoPath))
            {
                TimeSpan? watchProgress = SqlInstance.GetWatchProgress(id, movieid);

                if (watchProgress.HasValue)
                {
                    using (Form customDialog = new Form())
                    {
                        customDialog.FormBorderStyle = FormBorderStyle.None; // Remove the title bar
                        customDialog.StartPosition = FormStartPosition.CenterParent;
                        customDialog.BackColor = Color.Teal;
                        customDialog.Size = new Size(400, 200);
                        customDialog.MinimizeBox = false;
                        customDialog.MaximizeBox = false;
                        customDialog.ShowIcon = false;
                        customDialog.ShowInTaskbar = false;

                        Label messageLabel = new Label()
                        {
                            Text = "Do you want to resume from where you left off?",
                            ForeColor = Color.White,
                            Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold),
                            AutoSize = true,
                            Location = new Point(10, 50),
                            BackColor = Color.Teal
                        };
                        customDialog.Controls.Add(messageLabel);

                        System.Windows.Forms.Button yesButton = new System.Windows.Forms.Button()
                        {
                            BackColor = Color.White,
                            Text = "Yes",
                            Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold),
                            DialogResult = DialogResult.Yes,
                            Size = new Size(100, 40),
                            Location = new Point(90, 100)
                        };
                        customDialog.Controls.Add(yesButton);

                        System.Windows.Forms.Button noButton = new System.Windows.Forms.Button()
                        {
                            BackColor = Color.White,
                            Text = "No",
                            Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold),
                            DialogResult = DialogResult.No,
                            Size = new Size(100, 40),
                            Location = new Point(210, 100)
                        };
                        customDialog.Controls.Add(noButton);

                        customDialog.AcceptButton = yesButton;
                        customDialog.CancelButton = noButton;

                        DialogResult result = customDialog.ShowDialog();

                        if (result == DialogResult.Yes)
                        {
                             axWindowsMediaPlayer1.URL = videoPath;

                            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = watchProgress.Value.TotalSeconds;
                        }
                        else
                        {
                             axWindowsMediaPlayer1.URL = videoPath;
                        }
                    }
                }
                else
                {
                    axWindowsMediaPlayer1.URL = videoPath;
                }
            }
            else
            {
                MessageBox.Show("Video path not found in the database.");
            }

            if (!string.IsNullOrEmpty(imagePath))
            {
                try
                {
                    panel4.BackgroundImage = System.Drawing.Image.FromFile(imagePath);
                    panel4.BackgroundImageLayout = ImageLayout.Stretch;

                    Panel overlayPanel = new Panel();
                    overlayPanel.BackColor = Color.FromArgb(128, Color.Black);
                    overlayPanel.Dock = DockStyle.Fill;
                    panel4.Controls.Add(overlayPanel);
                    overlayPanel.BringToFront(); // Ensure the overlay panel is on top
                    label1.Text = movie[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Image path not found in the database.");
            }
        }



        private void ShowCommentCount(int count)
        { 
            if (count > 4)
            {
                more.Visible = true;
            }
            else
            {
                more.Visible = false;
            }
        }

        private void more_Click(object sender, EventArgs e)
        {
            if (more.Text == "More")
            {
                panel3.Controls.Remove(more);
                iconPictureBox69.Controls.Add(more);
                more.Location = new Point(1730, 78);

                data_panel.Controls.Remove(Comment_panel);
                data_panel.Controls.Remove(iconPictureBox);

                Comment_panel.Location = new Point(1247, 122);
                Comment_panel.Size = new Size(608, 956);

                iconPictureBox69.Controls.Add(Comment_panel);
                iconPictureBox69.Controls.Add(iconPictureBox);
                Comment_panel.BringToFront();

                axWindowsMediaPlayer1.Location = new Point(68, 78);
                iconPictureBox5.Location = new Point(68, 653);
                iconPictureBox.Location = new Point(1247, 78);

                more.Text = "Less";
            }
            else
            {
                iconPictureBox69.Controls.Remove(more);
                panel3.Controls.Add(more);
                more.Location = new Point(1721, 24);

                iconPictureBox69.Controls.Remove(Comment_panel);
                iconPictureBox69.Controls.Remove(iconPictureBox);

                Comment_panel.Location = new Point(1244, 75);
                Comment_panel.Size = new Size(608, 276);
                iconPictureBox.Location = new Point(1244, 16);

                panel3.Controls.Add(Comment_panel);
                panel3.Controls.Add(iconPictureBox);
                Comment_panel.BringToFront();

                axWindowsMediaPlayer1.Location = new Point(436, 78);
                iconPictureBox5.Location = new Point(436, 653);

                more.Text = "More";
            }
        }


        private void PopulateMovieDataPanel()
        {
            data_panel.Controls.Clear();

            int y = 10;

            Label titleLabel = new Label();
            Label releaseDateLabel = new Label();
            Label descriptionLabel = new Label();
            Label ratingLabel = new Label();

            titleLabel.Text = "Title: " + movie[0];
            releaseDateLabel.Text = "Release Date: " + movie[1];
            descriptionLabel.Text = "Description: " + movie[2];

            double averageRating = SqlInstance.GetAverageRating(movieid);
            ratingLabel.Text = "Average Rating: " + averageRating.ToString("F1");

            titleLabel.ForeColor = Color.White;
            releaseDateLabel.ForeColor = Color.White;
            descriptionLabel.ForeColor = Color.White;
            ratingLabel.ForeColor = Color.White;

            titleLabel.Font = new System.Drawing.Font("Segoe UI", 15, FontStyle.Bold);
            releaseDateLabel.Font = new System.Drawing.Font("Segoe UI", 15);
            ratingLabel.Font = new System.Drawing.Font("Segoe UI", 15);
            titleLabel.Location = new Point(10, y);
            releaseDateLabel.Location = new Point(10, y + 30);
            ratingLabel.Location = new Point(10, y + 60);
            descriptionLabel.AutoSize = false;
            descriptionLabel.Width = data_panel.Width - 20;
            releaseDateLabel.Width = data_panel.Width - 20;
            ratingLabel.Width = data_panel.Width - 20;

            descriptionLabel.Height = 100;
            descriptionLabel.Location = new Point(10, y + 90);
            descriptionLabel.Font = new System.Drawing.Font("Segoe UI", 17);
            descriptionLabel.AutoEllipsis = true;
            descriptionLabel.Text = "Description: " + movie[2];
            descriptionLabel.ForeColor = Color.White;

            data_panel.AutoSize = true;

            data_panel.Controls.Add(titleLabel);
            data_panel.Controls.Add(releaseDateLabel);
            data_panel.Controls.Add(descriptionLabel);
            data_panel.Controls.Add(ratingLabel);

            // Adding Poster Image
            string PosterImagePath = movie[4];

            PictureBox widePictureBox = new PictureBox();
            widePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            widePictureBox.ImageLocation = PosterImagePath;
            widePictureBox.Dock = DockStyle.Fill;

            RoundedPictureBox iconPictureBox_YT = new RoundedPictureBox();
            iconPictureBox_YT.CornerRadius = 10;
            iconPictureBox_YT.SizeMode = PictureBoxSizeMode.StretchImage;
            iconPictureBox_YT.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\YT_logo.png");
            iconPictureBox_YT.Name = "wide_panel";
            iconPictureBox_YT.Size = new Size(58, 33);
            iconPictureBox_YT.Location = new Point(90, 35);
            iconPictureBox_YT.TabIndex = 13;

            trailer_panel.Controls.Add(iconPictureBox_YT);
            poster_panel.Controls.Add(widePictureBox);

            string wideImagePath = movie[5];

            PictureBox widePicture = new PictureBox();
            widePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            widePicture.ImageLocation = wideImagePath;
            widePicture.Dock = DockStyle.Fill;

            widePicture.Paint += (sender, e) =>
            {
                int coloredAreaHeight = (widePicture.Height / 2) + 100;

                // Draw fading teal color
                for (int j = 0; j <= coloredAreaHeight; j++)
                {
                    int alpha = (int)(255 * ((double)j / coloredAreaHeight));
                    Color color = Color.FromArgb(alpha, Color.Teal);
                    Rectangle rect = new Rectangle(0, widePicture.Height - coloredAreaHeight + j, widePicture.Width, 1);
                    using (SolidBrush brush = new SolidBrush(color))
                    {
                        e.Graphics.FillRectangle(brush, rect);
                    }
                }
            };

            trailer_panel.Controls.Add(widePicture);
            widePicture.MouseEnter += PictureBox_MouseEnter;
            widePicture.MouseLeave += PictureBox_MouseLeave;
            widePicture.Click += bars_click;

            void bars_click(object sender, EventArgs e)
            {
                string url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }

            ///////// Comments //////////////////
            int commentY = 10;
            List<(string, string, string, DateTime)> comments = SqlInstance.GetCommentsForMovie(movieid);
            foreach (var comment in comments)
            {
                string username = comment.Item1;
                string profilePicture = comment.Item2;
                string commentText = comment.Item3;
                DateTime commentDate = comment.Item4;

                AddComment(username, profilePicture, commentText, commentDate);
            }

            ShowCommentCount(comments.Count);
        }

        private void AddCommentButton_Click(object sender, EventArgs e)
        {
            string newComment = newCommentTextBox.Text;

            if (!string.IsNullOrWhiteSpace(newComment))
            {
                SqlInstance.PostComment(movieid, newComment, id);

                newCommentTextBox.Clear();

                Comment_panel.Controls.Clear();

                List<(string, string, string, DateTime)> comments = SqlInstance.GetCommentsForMovie(movieid);

                lastCommentBottom = 10;

                foreach (var comment in comments)
                {
                    string username = comment.Item1;
                    string profilePicture = comment.Item2;
                    string commentText = comment.Item3;
                    DateTime commentDate = comment.Item4;

                    AddComment(username, profilePicture, commentText, commentDate);
                }

                ShowCommentCount(comments.Count);
            }
        }

        private int lastCommentBottom = 10;

        private void AddComment(string username, string profilePicture, string commentText, DateTime commentDate)
        {
            int verticalSpacing = 15;
            PictureBox profilePictureBox = new PictureBox();
            profilePictureBox.Size = new Size(50, 50); 
            profilePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            profilePictureBox.Location = new Point(10, lastCommentBottom);

            try
            {
                if (string.IsNullOrEmpty(profilePicture) || !File.Exists(profilePicture))
                {
                     profilePicture = "C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\pfp.png";
                }

                System.Drawing.Image image = System.Drawing.Image.FromFile(profilePicture);
                profilePictureBox.Image = image;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading profile picture: {ex.Message}");
            }

            Comment_panel.Controls.Add(profilePictureBox);

            Label usernameLabel = new Label();
            usernameLabel.AutoSize = true;
            usernameLabel.Font = new System.Drawing.Font("Segoe UI", 13, FontStyle.Bold);
            usernameLabel.Location = new Point(profilePictureBox.Right + 10, profilePictureBox.Top); 
            usernameLabel.Text = username;
            usernameLabel.ForeColor = Color.Teal;
            Comment_panel.Controls.Add(usernameLabel);

            Label dateLabel = new Label();
            dateLabel.AutoSize = true;
            dateLabel.Font = new System.Drawing.Font("Segoe UI", 10);
            dateLabel.ForeColor = Color.Silver;
            dateLabel.Location = new Point(Comment_panel.Width - 150, profilePictureBox.Top);
            dateLabel.Text = commentDate.ToString("yyyy-MM-dd HH:mm"); 
            Comment_panel.Controls.Add(dateLabel);

            Label commentTextLabel = new Label();
            commentTextLabel.AutoSize = true;
            commentTextLabel.Font = new System.Drawing.Font("Segoe UI", 10); 
            commentTextLabel.Location = new Point(profilePictureBox.Right + 10, usernameLabel.Bottom + 5); 
            commentTextLabel.Text = commentText;
            commentTextLabel.ForeColor = Color.White;
            Comment_panel.Controls.Add(commentTextLabel);

            lastCommentBottom = commentTextLabel.Bottom + verticalSpacing;
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.Cursor = Cursors.Default;
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.Cursor = Cursors.Hand;
            pictureBox.Click += WidePictureBox_Click;
        }

        private void WidePictureBox_Click(object sender, EventArgs e)
        {
            string trailerUrl = movie[3];
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            if (axWindowsMediaPlayer1.currentMedia != null)
            { 
                string mediaDuration = axWindowsMediaPlayer1.currentMedia.durationString;
                string mediaInfo =  mediaDuration;
                TimeSpan stoppedAt = TimeSpan.FromSeconds(axWindowsMediaPlayer1.Ctlcontrols.currentPosition);
                SqlInstance.SaveWatchProgress(id, movieid, stoppedAt);
                axWindowsMediaPlayer1.close();
            }
            else
            {
                 MessageBox.Show("No media is currently playing.", "Error");
            }

            Form f = new Form();
            f.StartPosition = FormStartPosition.Manual;
            f.Location = new Point(0, 0);
            f.FormBorderStyle = FormBorderStyle.None;
            f.WindowState = FormWindowState.Maximized;

            Home homePage = new Home(f, id);
            f.Show();

            _form.Hide();

        }

         private void server_Click(object sender, EventArgs e)
         {
             if (IsInternetAvailable())
             {
                 string backupVideoPath = SqlInstance.GetBackupVideoPath(movieid);
                 if (!string.IsNullOrEmpty(backupVideoPath))
                 {
                     axWindowsMediaPlayer1.URL = backupVideoPath;
                 }
                 else
                 {
                     MessageBox.Show("Server currently unavelable!");
                 }
             }
             else
             {
                 MessageBox.Show("No internet connection!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

             }
         }

        private void local_Click(object sender, EventArgs e)
        {
            PlayVideoFromDatabase();
        }

        private bool IsInternetAvailable()
        {
            try
            {
                using (var client = new System.Net.WebClient())
                using (client.OpenRead("http://www.google.com"))
                    return true;
            }
            catch
            {
                return false;
            }
        }

        int currentRating = 0;
        /////////////////////// rate ////////////////////////////
        private void Star_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            int starIndex = int.Parse(pictureBox.Tag.ToString());

            for (int i = 1; i <= starIndex; i++)
            {
                Control[] stars = ((Control)pictureBox.Parent).Controls.Find("star" + i, true);
                PictureBox star = (PictureBox)stars[0];
                star.ImageLocation = @"C:\Users\enkud\Desktop\Cinema\back_image\y_star.png";
            }
        }

        private void Star_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            int starIndex = int.Parse(pictureBox.Tag.ToString());

            currentRating = starIndex;
            MessageBox.Show($"You rated : {currentRating}");

             SqlInstance.UpdateMovieRating(movieid, id, currentRating);

            for (int i = 1; i <= starIndex; i++)
            {
                Control[] stars = ((Control)pictureBox.Parent).Controls.Find("star" + i, true);
                PictureBox star = (PictureBox)stars[0];
                star.ImageLocation = @"C:\Users\enkud\Desktop\Cinema\back_image\y_star.png";
            }

            for (int i = starIndex + 1; i <= 5; i++)
            {
                Control[] stars = ((Control)pictureBox.Parent).Controls.Find("star" + i, true);
                PictureBox star = (PictureBox)stars[0];
                star.ImageLocation = @"C:\Users\enkud\Desktop\Cinema\back_image\e_star.png";
            }
        }
    }
}



