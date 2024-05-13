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
using System.ComponentModel.DataAnnotations;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;

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
        private Panel back_panel;
        private Panel panel1;
        private Panel panel2;
        private RoundedButton button1;
        private Label label_N;
        private Panel panel3;
        private Panel panel4;
        private Panel redpanel;
        private RoundedPanel poster_panel;
        private Label label2;
        private PictureBox iconPictureBox;
        private PictureBox iconPictureBox2;
        private PictureBox iconPictureBox3;
        private PictureBox iconPictureBox4;
        private PictureBox iconPictureBox5;
        private PictureBox iconPictureBox6;
        private RoundedPanel Comment_panel;
        private Label label1;
        private RoundedPanel trailer_panel;
        private Panel data_panel;
        private RoundedPanel rate_panel;
        private Label Trailer;
        private Label label3;
        private System.Threading.Timer timer;
        private System.Windows.Forms.TextBox newCommentTextBox;

        public Video_class(Form form, string[] array, int movieid)
        {
            _form = form;
            this.movie = array;
            this.movieid = movieid;
            InitializeComponent();
            PlayVideoFromDatabase();
            PopulateMovieDataPanel();
        }

        void InitializeComponent()
        {
            // pictureBox1 = new PictureBox();
            axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            back_panel = new Panel();
            panel1 = new Panel();
            panel2 = new Panel();
            button1 = new RoundedButton();
            label_N = new Label();
            iconPictureBox = new PictureBox();
            iconPictureBox2 = new PictureBox();
            iconPictureBox3 = new PictureBox();
            iconPictureBox4 = new PictureBox();
            iconPictureBox5 = new PictureBox();
            iconPictureBox6 = new PictureBox();
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
            redpanel = new Panel();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            _form.SuspendLayout();
            // 
            // pictureBox1
            // 

            // 
            // axWindowsMediaPlayer1
            // 
            axWindowsMediaPlayer1.Enabled = true;
            axWindowsMediaPlayer1.Location = new Point(70, 77);
            axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            // axWindowsMediaPlayer1.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer1.OcxState");
            axWindowsMediaPlayer1.Size = new Size(1100, 623);
            axWindowsMediaPlayer1.TabIndex = 1;
            // 
            // panel1
            // 
            // back_panel.BackColor = Color.FromArgb(24, 24, 24);
            back_panel.BackColor = Color.Transparent;
            back_panel.Dock = DockStyle.Fill;
            back_panel.Location = new Point(0, 0);
            back_panel.Name = "panel1";
            // panel1.Size = new Size(1920, 64);
            back_panel.Size = new Size(1487, 700);
            back_panel.TabIndex = 1;

            panel1.BackColor = SystemColors.ActiveCaptionText;
            //panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(panel2);
            //panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1920, 64);
            panel1.TabIndex = 2;
            // 
            // button1
            // 
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
            // -- 
            panel2.BackColor = Color.Teal;
            panel2.Controls.Add(label1);
            panel2.Enabled = false;
            panel2.Location = new Point(20, 10);
            panel2.Name = "panel2";
            panel2.Size = new Size(174, 50);
            panel2.TabIndex = 2;

            label_N.AutoSize = true;
            label_N.Font = new System.Drawing.Font("Impact", 26.25F);
            label_N.ForeColor = Color.White;
            label_N.Location = new Point(21, 3);
            label_N.Name = "label1";
            label_N.Size = new Size(130, 43);
            label_N.TabIndex = 2;
            label_N.Text = "NOTFLIX";

            panel2.Controls.Add(label_N);
            redpanel.Location = new Point(1200, 77);
            redpanel.BackColor = Color.Transparent;
            //redpanel.BackColor = Color.Red;
            redpanel.Name = "start / director panel";
            redpanel.Size = new Size(700, 623);
            redpanel.TabIndex = 4;

            Label redLabel = new Label();
            redLabel.Font = new System.Drawing.Font("Segoe UI", 21F);
            redLabel.ForeColor = Color.Teal;
            redLabel.Location = new Point(60, 16);
            redLabel.Name = "label2";
            redLabel.Size = new Size(300, 50);
            redLabel.TabIndex = 5;
            redLabel.Text = "Director / Stars";
            redpanel.Controls.Add(redLabel);

            iconPictureBox3.SizeMode = PictureBoxSizeMode.Zoom; // Maintain aspect ratio
            iconPictureBox3.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\logo.png");
            iconPictureBox3.Location = new(20, 20);
            iconPictureBox3.Name = "wide_panel";
            iconPictureBox3.Size = new Size(20, 30);
            iconPictureBox3.TabIndex = 13;
            redpanel.Controls.Add(iconPictureBox3);
            // text
            iconPictureBox4.SizeMode = PictureBoxSizeMode.Zoom; // Maintain aspect ratio
            iconPictureBox4.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\rate.png");
            iconPictureBox4.Location = new(900, 20);
            iconPictureBox4.Name = "wide_panel";
            iconPictureBox4.Size = new Size(217, 35);
            iconPictureBox4.TabIndex = 13;
            // bar
            iconPictureBox5.SizeMode = PictureBoxSizeMode.Zoom; // Maintain aspect ratio
            iconPictureBox5.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\mp4_bar.png");
            iconPictureBox5.Location = new(70, 652);
            iconPictureBox5.Name = "wide_panel";
            iconPictureBox5.Size = new Size(1100, 48);
            iconPictureBox5.TabIndex = 13;
            iconPictureBox5.BringToFront();
            // cast
            iconPictureBox6.SizeMode = PictureBoxSizeMode.Zoom; // Maintain aspect ratio
            iconPictureBox6.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\cast.png");
            //iconPictureBox6.Location = new(70, 652);
            iconPictureBox6.Name = "wide_panel";
            //iconPictureBox6.Size = new Size(1100, 48);
            iconPictureBox6.TabIndex = 13;
            iconPictureBox6.Size = new Size(700, 623);
            iconPictureBox6.Location = new Point(1200, 77);
            // 
            // panel3
            // 
            //panel3.BackColor = Color.Red;
            panel3.BackColor = Color.FromArgb(24, 24, 24);
            //panel3.BackColor = Color.Transparent;
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
            //  panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 720);
            panel3.Name = "panel3";
            panel3.Size = new Size(1920, 473);
            panel3.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 14F);
            label3.ForeColor = Color.Gray;
            label3.Location = new Point(328, 381);
            label3.Name = "label3";
            label3.Size = new Size(394, 25);
            label3.TabIndex = 7;
            label3.Text = "Final movie trailer on youtube //https;//gran...";
            // 
            // data_panel
            // 
            // data_panel.BackColor = Color.FromArgb(29, 47, 50);
            data_panel.BackColor = Color.Transparent;
            //data_panel.BackColor = Color.Red;
            data_panel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            data_panel.Location = new Point(326, 80);
            data_panel.Name = "data_panel";
            data_panel.Size = new Size(827, 250);
            data_panel.TabIndex = 6;
            // star
            rate_panel.BackColor = Color.Transparent;
          //rate_panel.BackColor = Color.Black;
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
            // 
            // label2
            // 

            iconPictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Maintain aspect ratio
            iconPictureBox.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\comments.png");
            iconPictureBox.Location = new(1244, 16);
            //iconPictureBox.Location = new Point(1244, 75);
            iconPictureBox.Name = "wide_panel";
            iconPictureBox.Size = new Size(217, 35);
            iconPictureBox.TabIndex = 13;

            Comment_panel.BackColor = Color.Transparent;
            //Comment_panel.BackColor = Color.Red;
            Comment_panel.Location = new Point(1244, 75);
            Comment_panel.Name = "Comment_panel";
            Comment_panel.Size = new Size(598, 376);
            Comment_panel.TabIndex = 4;
            //Comment_panel.EdgeColor = Color.FromArgb(41, 172, 191);
            Comment_panel.EdgeColor = Color.FromArgb(29, 41, 43);

            int commentY = 10;
            newCommentTextBox = new System.Windows.Forms.TextBox();
            newCommentTextBox.BorderStyle = BorderStyle.None;
            newCommentTextBox.Font = new System.Drawing.Font("Segoe UI", 15F);
            newCommentTextBox.BackColor = Color.FromArgb(24, 24, 24);
            newCommentTextBox.ForeColor = Color.White;
            // newCommentTextBox.BackColor = Color.Red;
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
            addCommentButton.Location = new Point(newCommentTextBox.Width + 99, 5);
            addCommentButton.Click += AddCommentButton_Click;

            RoundedPanel roundedPanel1 = new RoundedPanel();
            //roundedPanel1.BackColor = Color.FromArgb(29, 41, 43);
            roundedPanel1.BackColor = Color.Transparent;
            roundedPanel1.Controls.Add(newCommentTextBox);
            roundedPanel1.Controls.Add(addCommentButton);
            roundedPanel1.CornerRadius = 10;
           // roundedPanel1.EdgeColor = Color.Black;
            roundedPanel1.Location = new Point(10, Comment_panel.Height - 51);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(580, 44);
            roundedPanel1.TabIndex = 13;
            roundedPanel1.EdgeColor = Color.FromArgb(29, 41, 43);
            Comment_panel.Controls.Add(roundedPanel1);
            // 
            // Trailer
            // 
            iconPictureBox2.SizeMode = PictureBoxSizeMode.Zoom; // Maintain aspect ratio
            iconPictureBox2.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\logo.png");
            iconPictureBox2.Location = new(326, 349); 
            iconPictureBox2.Name = "wide_panel";
            iconPictureBox2.Size = new Size(17, 27);
            iconPictureBox2.TabIndex = 13;

            Trailer.AutoSize = true;
            Trailer.Font = new System.Drawing.Font("Segoe UI", 18F);
            Trailer.ForeColor = Color.White;
            Trailer.Location = new Point(346, 346);
            Trailer.Name = "Trailer";
            Trailer.Size = new Size(78, 32);
            Trailer.TabIndex = 3;
            Trailer.Text = "Trailer";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 36F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(324, 10);
            label1.Name = "label1";
            label1.Size = new Size(118, 65);
            label1.TabIndex = 2;
            label1.Text = "Title";
            // 
            // trailer_panel
            // 
            //trailer_panel.BackColor = Color.FromArgb(29, 47, 50);
            trailer_panel.BackColor = Color.FromArgb(24, 24, 24);
            trailer_panel.Location = new Point(66, 346);
            trailer_panel.Name = "trailer_panel";
            trailer_panel.Size = new Size(241, 105);
            trailer_panel.TabIndex = 1;
            // 
            // poster_panel
            // 
            //poster_panel.BackColor = Color.FromArgb(29, 47, 50);
            poster_panel.BackColor = Color.FromArgb(24, 24, 24);
            poster_panel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            poster_panel.Location = new Point(66, 18);
            poster_panel.Name = "poster_panel";
            poster_panel.Size = new Size(241, 312);
            poster_panel.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 64);
            panel4.Name = "panel4";
            panel4.Size = new Size(1920, 650);
            panel4.TabIndex = 4;

            DisplayDirectorsAndStars(movieid);

            // back_panel.Anchor
            //back_panel.Controls.Add(redpanel);
            back_panel.Controls.Add(iconPictureBox6);
            back_panel.Controls.Add(iconPictureBox5);
            back_panel.Controls.Add(axWindowsMediaPlayer1);
           
            // _form.Controls.Add(panel4);
            back_panel.Controls.Add(panel3);
            back_panel.Controls.Add(panel1);
            //  _form.Controls.Add(pictureBox1
            // 
            // Form1
            // 
            _form.AutoScaleDimensions = new SizeF(7F, 15F);
            _form.AutoScaleMode = AutoScaleMode.Font;
            _form.ClientSize = new Size(1487, 931);
            _form.Controls.Add(back_panel);
            _form.Name = "Form1";
            _form.Text = "Form1";
            // _form.Load += Form1_Load;
            //((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).EndInit();
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            _form.ResumeLayout(false);



          

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
                    // Load the image and set it as the background of panel4
                    panel4.BackgroundImage = System.Drawing.Image.FromFile(imagePath);

                    // Set background image layout to stretch
                    panel4.BackgroundImageLayout = ImageLayout.Stretch;

                    // Add a semi-transparent overlay panel
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

            // Clear existing controls from the data_panel
            data_panel.Controls.Clear();

            // Define the y-coordinate for positioning controls
            int y = 10;

            // Create labels for displaying movie data
            Label titleLabel = new Label();
            Label releaseDateLabel = new Label();
            Label descriptionLabel = new Label();
            Label ratingLabel = new Label();

            // Set properties for the labels
            titleLabel.Text = "Title: " + movie[0]; // Assuming movie[0] contains the movie title
            releaseDateLabel.Text = "Release Date: " + movie[1]; // Get release date for movie
            descriptionLabel.Text = "Description: " + movie[2]; // Get description for movie
            ratingLabel.Text = "Average Rating: " + movie[6]; // Get average rating for movie

            // Set font properties
            titleLabel.ForeColor = Color.White;
            releaseDateLabel.ForeColor = Color.White;
            descriptionLabel.ForeColor = Color.White;
            ratingLabel.ForeColor = Color.White;

            // Set font size
            titleLabel.Font = new System.Drawing.Font("Segoe UI", 15, FontStyle.Bold); // Example font size and style
            releaseDateLabel.Font = new System.Drawing.Font("Segoe UI", 15); // Example font size
            ratingLabel.Font = new System.Drawing.Font("Segoe UI", 15); // Example font size

            // Set label positions
            titleLabel.Location = new Point(10, y);
            releaseDateLabel.Location = new Point(10, y + 30); // Adjust vertical spacing as needed
            ratingLabel.Location = new Point(10, y + 60);

             // Set description label width and enable word wrap
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

            // Allow data_panel to adjust its size based on the content
            data_panel.AutoSize = true;

            // Add labels to the data_panel
            data_panel.Controls.Add(releaseDateLabel);
            data_panel.Controls.Add(descriptionLabel);
            data_panel.Controls.Add(ratingLabel);

            string PosterImagePath = movie[4];

            // Create a PictureBox to display the wide poster image
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


            // Add PictureBox to the wide_panel
            trailer_panel.Controls.Add(iconPictureBox_YT);
            poster_panel.Controls.Add(widePictureBox);
            string wideImagePath = movie[5];

            // Create a PictureBox to display the wide poster image
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
            List<(string, string, string)> comments = SqlInstance.GetCommentsForMovie(movieid); // Fetch comments for the movie title
            foreach (var comment in comments)
            {
                string username = comment.Item1;
                string profilePicture = comment.Item2;
                string commentText = comment.Item3;

                // Create a custom control for each comment
                AddComment(username, profilePicture, commentText);
            }



        }

        private int lastCommentBottom = 10; // Initialize with the starting position

        private void AddComment(string username, string profilePicture, string commentText)
        {
            int verticalSpacing = 15; // Adjust the vertical spacing between comments as needed

            PictureBox profilePictureBox = new PictureBox();
            profilePictureBox.Size = new Size(50, 50); // Adjust size as needed
            profilePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            profilePictureBox.Location = new Point(10, lastCommentBottom); // Use the last comment bottom as the top position

            try
            {
                // Load the image from the file path
                System.Drawing.Image image = System.Drawing.Image.FromFile(profilePicture);
                profilePictureBox.Image = image;
            }
            catch (Exception ex)
            {
                // Handle the case where the image cannot be loaded
                // MessageBox.Show($"Error loading profile picture: {ex.Message}");
                // You might want to set a default image or handle this error differently
            }

            Comment_panel.Controls.Add(profilePictureBox);

            Label usernameLabel = new Label();
            usernameLabel.AutoSize = true;
            usernameLabel.Font = new System.Drawing.Font("Segoe UI", 13, FontStyle.Bold); // Adjust font and size as needed
            usernameLabel.Location = new Point(profilePictureBox.Right + 10, profilePictureBox.Top); // Adjust location as needed
            usernameLabel.Text = username;
            usernameLabel.ForeColor = Color.Teal;
            Comment_panel.Controls.Add(usernameLabel);

            Label commentTextLabel = new Label();
            commentTextLabel.AutoSize = true;
            commentTextLabel.Font = new System.Drawing.Font("Segoe UI", 10); // Adjust font and size as needed
            commentTextLabel.Location = new Point(profilePictureBox.Right + 10, usernameLabel.Bottom + 5); // Adjust location as needed
            commentTextLabel.Text = commentText;
            commentTextLabel.ForeColor = Color.White;
            Comment_panel.Controls.Add(commentTextLabel);

            // Update the lastCommentBottom for the next comment
            lastCommentBottom = commentTextLabel.Bottom + verticalSpacing;
        }



        private void DisplayDirectorsAndStars(int movieId)
        {
            // Get directors and stars from the database
            List<(string, string)> directorsAndStars = SqlInstance.GetMovieDirectorsAndStars(movieId);

            // Separate directors and stars
            List<(string, string)> directors = new List<(string, string)>();
            List<(string, string)> stars = new List<(string, string)>();

            foreach ((string name, string image) in directorsAndStars)
            {
                if (name.StartsWith("Director:"))
                {
                    // Remove "Director:" prefix and add to directors list
                    directors.Add((name.Replace("Director:", ""), image));
                }
                else
                {
                    // Add to stars list
                    stars.Add((name, image));
                }
            }

            // Display directors
            int verticalPosition = 50; // Initial vertical position for directors
            foreach ((string directorName, string directorImage) in directors)
            {
                // Create PictureBox and Label controls for each director
                RoundedPictureBox pictureBox = new RoundedPictureBox();
                pictureBox.CornerRadius = 30;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.ImageLocation = directorImage;
                pictureBox.Width = 100;
                pictureBox.Height = 100;
                pictureBox.Location = new Point(10, verticalPosition); // Set location

                Label label = new Label();
                label.Text = directorName;
                label.AutoSize = true; // Automatically adjust label size
                label.MaximumSize = new Size(500, 0); // Limit maximum width to prevent cutting off
                label.Location = new Point(120, verticalPosition + 40); // Set location
                label.Font = new System.Drawing.Font(label.Font.FontFamily, 18, FontStyle.Regular); // Make font bigger and bold
                label.ForeColor = Color.White; // Make text color white

                // Add PictureBox and Label to redpanel
                redpanel.Controls.Add(pictureBox);
                redpanel.Controls.Add(label);

                // Increment vertical position for the next director
                verticalPosition += 140; // Adjust as needed
            }

            // Add a gap between directors and stars
            verticalPosition += 40; // Adjust as needed

            // Display stars
            foreach ((string starName, string starImage) in stars)
            {
                // Create PictureBox and Label controls for each star
                RoundedPictureBox pictureBox = new RoundedPictureBox();
                pictureBox.CornerRadius = 50;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.ImageLocation = starImage;
                pictureBox.Width = 100;
                pictureBox.Height = 100;
                pictureBox.Location = new Point(10, verticalPosition); // Set location

                Label label = new Label();
                label.Text = starName;
                label.AutoSize = true; // Automatically adjust label size
                label.MaximumSize = new Size(500, 0); // Limit maximum width to prevent cutting off
                label.Location = new Point(120, verticalPosition + 40); // Set location
                label.Font = new System.Drawing.Font(label.Font.FontFamily, 18, FontStyle.Regular); // Make font bigger and bold
                label.ForeColor = Color.White; // Make text color white

                // Add PictureBox and Label to redpanel
                redpanel.Controls.Add(pictureBox);
                redpanel.Controls.Add(label);

                // Increment vertical position for the next star
                verticalPosition += 140; // Adjust as needed
            }


        }



        private void AddCommentButton_Click(object sender, EventArgs e)
        {
            // Handle adding a new comment
            string newComment = newCommentTextBox.Text; // Assuming newCommentTextBox is accessible here
            MessageBox.Show(newComment);
            SqlInstance.PostComment(movieid, newComment, 1); // Post the comment to the database

            // Fetch comments again from the database
            List<(string, string, string)> comments = SqlInstance.GetCommentsForMovie(movieid);

            // Clear existing comments from the UI
            Comment_panel.Controls.Clear();

            // Iterate over the new comments and add them to the UI
            foreach (var comment in comments)
            {
                string username = comment.Item1;
                string profilePicture = comment.Item2;
                string commentText = comment.Item3;

                // Add comment to the UI
                AddComment(username, profilePicture, commentText);
            }
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.Cursor = Cursors.Default; // Revert cursor to default

        }

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.Cursor = Cursors.Hand; // Change cursor to hand pointer
            pictureBox.Click += WidePictureBox_Click; // Attach Click event handler
        }

        private void WidePictureBox_Click(object sender, EventArgs e)
        {
            string trailerUrl = movie[3]; // Assuming movie[3] contains the YouTube trailer URL
        }


        private void button1_Click(object sender, EventArgs e)
        {

            //panel1.Visible = false;
            //panel4.Visible = false;
            //panel3.Visible = false;
            //axWindowsMediaPlayer1.Visible = false;
            axWindowsMediaPlayer1.close();
            _form.Controls.Clear();
            //  pictureBox1.Visible = false;
            Home h = new Home(_form);
            h._form.Show();
            h._form.Refresh();

            //  _form.Visible = false;

        }

        int currentRating = 0;
        /////////////////////// rate ////////////////////////////
        private void Star_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            int starIndex = int.Parse(pictureBox.Tag.ToString());

            // Change the color of stars up to the current one
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

            // Change the color of stars up to the clicked one
            for (int i = 1; i <= currentRating; i++)
            {
                Control[] stars = ((Control)pictureBox.Parent).Controls.Find("star" + i, true);
                PictureBox star = (PictureBox)stars[0];
                star.ImageLocation = @"C:\Users\enkud\Desktop\Cinema\back_image\y_star.png";
            }

            // Reset the color of stars after the clicked one
            for (int i = currentRating + 1; i <= 5; i++)
            {
                Control[] stars = ((Control)pictureBox.Parent).Controls.Find("star" + i, true);
                PictureBox star = (PictureBox)stars[0];
                star.ImageLocation = @"C:\Users\enkud\Desktop\Cinema\back_image\e_star.png";
            }

            //MessageBox.Show("You rated " + currentRating + " stars.");
        }

    }
}