using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
//using ScreenColorDetector;

namespace WinFormsApp1
{
    public class Video_class
    {
        private readonly Sql SqlInstance = new Sql();
        private Form _form;
        string[] movie;
        int movieid;
        // private System.Windows.Forms.PictureBox pictureBox1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        //private Panel back_panel;
        private Panel panel1;
        private Panel panel2;
        private RoundedButton button1;
        private Label label_N;
        private Panel panel3;
        private Panel panel4;
        private RoundedPanel poster_panel;
        private Label label2;
        private PictureBox iconPictureBox;
        private PictureBox iconPictureBox2;
        private PictureBox iconPictureBox3;
        private PictureBox iconPictureBox4;
        private PictureBox iconPictureBox5;
        private PictureBox iconPictureBox6;
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

        public Video_class(Form form, string[] array, int movieid)
        {
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
            //_form.BackgroundImage = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\opacity.png");

            InitializeComponent();
            PlayVideoFromDatabase();
            PopulateMovieDataPanel();
            _form.BackgroundImage = null;
          
        }

        void InitializeComponent()
        {
            axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            panel1 = new Panel();
            panel2 = new Panel();
            button1 = new RoundedButton();
            label_N = new Label();
            iconPictureBox = new PictureBox();
            iconPictureBox2 = new PictureBox();
            iconPictureBox4 = new PictureBox();
            iconPictureBox5 = new PictureBox();
            iconPictureBox6 = new PictureBox();
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
            //panel1.BackColor = Color.FromArgb(24, 24, 24);
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(panel2);
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

            // Define the TextChanged event handler to change the EdgeColor of roundedPanelTop
     

            // Define the PerformSearch method
            void PerformSearch(string searchText)
            {
                axWindowsMediaPlayer1.close();

                // Dispose of all controls and clear the form
                foreach (Control control in _form.Controls)
                {
                    control.Dispose();
                }
                _form.Controls.Clear();

                // Create a new instance of the Home class and initialize it
                Home homePage = new Home(_form);
                homePage.PopulateMovie(searchText, 1);

                _form.WindowState = FormWindowState.Maximized;

                // Show and refresh the form
                homePage._form.Show();
                homePage._form.Refresh();
            }

            // Initialize the roundedPanelTop and its properties
            roundedPanelTop.BackColor = Color.FromArgb(29, 41, 43);
            roundedPanelTop.Controls.Add(textBox1);
            roundedPanelTop.CornerRadius = 10;
            roundedPanelTop.Location = new Point(700, 10);
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

            // panel2
            panel2.BackColor = Color.Teal;
            panel2.Controls.Add(label1);
            panel2.Enabled = false;
            panel2.Location = new Point(20, 10);
            panel2.Name = "panel2";
            panel2.Size = new Size(174, 50);

            // label_N
            label_N.AutoSize = true;
            label_N.Font = new System.Drawing.Font("Impact", 26.25F);
            label_N.ForeColor = Color.White;
            label_N.Location = new Point(21, 3);
            label_N.Name = "label1";
            label_N.Size = new Size(130, 43);
            label_N.Text = "NOTFLIX";
            panel2.Controls.Add(label_N);

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

            // iconPictureBox6
            iconPictureBox6.SizeMode = PictureBoxSizeMode.Zoom; // Maintain aspect ratio
            iconPictureBox6.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\cast.png");
            iconPictureBox6.Name = "wide_panel";
            iconPictureBox6.Size = new Size(700, 623);
            iconPictureBox6.Location = new Point(1200, 77);

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
            label3.Text = "Final movie trailer on youtube //https://gran...";

            // data_panel
            data_panel.BackColor = Color.FromArgb(24, 24, 24);
            data_panel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            data_panel.Location = new Point(326, 80);
            data_panel.Name = "data_panel";
            data_panel.Size = new Size(827, 250);

            // rate_panel
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
                axWindowsMediaPlayer1.URL = videoPath;
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


        private void PopulateMovieDataPanel()
        {

            data_panel.Controls.Clear();

            int y = 10;

            Label titleLabel = new Label();
            Label releaseDateLabel = new Label();
            Label descriptionLabel = new Label();
            Label ratingLabel = new Label();

            titleLabel.Text = "Title: " + movie[0]; // Assuming movie[0] contains the movie title
            releaseDateLabel.Text = "Release Date: " + movie[1]; // Get release date for movie
            descriptionLabel.Text = "Description: " + movie[2]; // Get description for movie
            ratingLabel.Text = "Average Rating: " + movie[6]; // Get average rating for movie

            titleLabel.ForeColor = Color.White;
            releaseDateLabel.ForeColor = Color.White;
            descriptionLabel.ForeColor = Color.White;
            ratingLabel.ForeColor = Color.White;

            titleLabel.Font = new System.Drawing.Font("Segoe UI", 15, FontStyle.Bold); // Example font size and style
            releaseDateLabel.Font = new System.Drawing.Font("Segoe UI", 15); // Example font size
            ratingLabel.Font = new System.Drawing.Font("Segoe UI", 15); // Example font size

            titleLabel.Location = new Point(10, y);
            releaseDateLabel.Location = new Point(10, y + 30); // Adjust vertical spacing as needed
            ratingLabel.Location = new Point(10, y + 60);

            descriptionLabel.AutoSize = false;
            descriptionLabel.Width = data_panel.Width - 20; // Adjust width as needed
            releaseDateLabel.Width = data_panel.Width - 20; // Adjust width as needed
            ratingLabel.Width = data_panel.Width - 20; // Adjust width as needed
            descriptionLabel.Height = 100; // Adjust height as needed
            descriptionLabel.Location = new Point(10, y + 90); // Adjust vertical spacing as needed
            descriptionLabel.Font = new System.Drawing.Font("Segoe UI", 17); // Example font size
            descriptionLabel.AutoEllipsis = true;
            descriptionLabel.Text = "Description: " + movie[2]; // Get description for movie
            descriptionLabel.ForeColor = Color.White;

            data_panel.AutoSize = true;

            data_panel.Controls.Add(releaseDateLabel);
            data_panel.Controls.Add(descriptionLabel);
            data_panel.Controls.Add(ratingLabel);

            string PosterImagePath = movie[4];

            PictureBox widePictureBox = new PictureBox();
            widePictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Maintain aspect ratio
            widePictureBox.ImageLocation = PosterImagePath; // Set image location to the retrieved image path
            widePictureBox.Dock = DockStyle.Fill; // Dock the PictureBox to fill the entire panel
            
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
            widePicture.SizeMode = PictureBoxSizeMode.StretchImage; // Maintain aspect ratio
            widePicture.ImageLocation = wideImagePath; // Set image location to the retrieved image path
            widePicture.Dock = DockStyle.Fill; // Dock the PictureBox to fill the entire panel

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

            // Add PictureBox to the wide_panel
            trailer_panel.Controls.Add(widePicture);
            widePicture.MouseEnter += PictureBox_MouseEnter; // Attach MouseEnter event handler
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

            ///////// comments //////////////////
            int commentY = 10; // Initial y-coordinate for positioning comments
            List<(string, string, string, DateTime)> comments = SqlInstance.GetCommentsForMovie(movieid); // Fetch comments for the movie title
            foreach (var comment in comments)
            {
                string username = comment.Item1;
                string profilePicture = comment.Item2;
                string commentText = comment.Item3;
                DateTime commentDate = comment.Item4;

                AddComment(username, profilePicture, commentText, commentDate);
            }




        }

        private int lastCommentBottom = 10; // Initialize with the starting position


        private void AddComment(string username, string profilePicture, string commentText, DateTime commentDate)
        {
            int verticalSpacing = 15; // Adjust the vertical spacing between comments as needed

            PictureBox profilePictureBox = new PictureBox();
            profilePictureBox.Size = new Size(50, 50); // Adjust size as needed
            profilePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            profilePictureBox.Location = new Point(10, lastCommentBottom); // Use the last comment bottom as the top position

            try
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile(profilePicture);
                profilePictureBox.Image = image;
            }
            catch (Exception ex)
            {
            }

            Comment_panel.Controls.Add(profilePictureBox);

            Label usernameLabel = new Label();
            usernameLabel.AutoSize = true;
            usernameLabel.Font = new System.Drawing.Font("Segoe UI", 13, FontStyle.Bold); // Adjust font and size as needed
            usernameLabel.Location = new Point(profilePictureBox.Right + 10, profilePictureBox.Top); // Adjust location as needed
            usernameLabel.Text = username;
            usernameLabel.ForeColor = Color.Teal;
            Comment_panel.Controls.Add(usernameLabel);

            Label dateLabel = new Label();
            dateLabel.AutoSize = true;
            dateLabel.Font = new System.Drawing.Font("Segoe UI", 10); // Adjust font and size as needed
            dateLabel.ForeColor = Color.Silver;
            dateLabel.Location = new Point(Comment_panel.Width - 150, profilePictureBox.Top); // Position to the right side
            dateLabel.Text = commentDate.ToString("yyyy-MM-dd HH:mm"); // Format the date as needed
            Comment_panel.Controls.Add(dateLabel);

            Label commentTextLabel = new Label();
            commentTextLabel.AutoSize = true;
            commentTextLabel.Font = new System.Drawing.Font("Segoe UI", 10); // Adjust font and size as needed
            commentTextLabel.Location = new Point(profilePictureBox.Right + 10, usernameLabel.Bottom + 5); // Adjust location as needed
            commentTextLabel.Text = commentText;
            commentTextLabel.ForeColor = Color.White;
            Comment_panel.Controls.Add(commentTextLabel);

            lastCommentBottom = commentTextLabel.Bottom + verticalSpacing;
        }

        private void AddCommentButton_Click(object sender, EventArgs e)
        {
            string newComment = newCommentTextBox.Text;
            SqlInstance.PostComment(movieid, newComment, 1); 

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
            axWindowsMediaPlayer1.close();
            
            foreach (Control control in _form.Controls)
            {
                control.Dispose();
            }
            _form.Controls.Clear();

             Home homePage = new Home(_form);

            _form.WindowState = FormWindowState.Maximized;

            homePage._form.Show();
            homePage._form.Refresh();
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
            currentRating = int.Parse(pictureBox.Tag.ToString());

            for (int i = 1; i <= currentRating; i++)
            {
                Control[] stars = ((Control)pictureBox.Parent).Controls.Find("star" + i, true);
                PictureBox star = (PictureBox)stars[0];
                star.ImageLocation = @"C:\Users\enkud\Desktop\Cinema\back_image\y_star.png";
            }

            for (int i = currentRating + 1; i <= 5; i++)
            {
                Control[] stars = ((Control)pictureBox.Parent).Controls.Find("star" + i, true);
                PictureBox star = (PictureBox)stars[0];
                star.ImageLocation = @"C:\Users\enkud\Desktop\Cinema\back_image\e_star.png";
            }

        }

    }
}