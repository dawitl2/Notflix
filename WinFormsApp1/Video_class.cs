﻿using Org.BouncyCastle.Asn1.Crmf;
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
        private RoundedPanel poster_panel;
        private Label label2;
        private PictureBox iconPictureBox;
        private PictureBox iconPictureBox2;
        private Panel Comment_panel;
        private Label label1;
        private RoundedPanel trailer_panel;
        private Panel data_panel;
        private Label Trailer;
        private Label label3;
        private System.Windows.Forms.TextBox newCommentTextBox;

        public Video_class(Form form, string[] array, int movieid)
        {
            _form = form;
            this.movie = array;
            this.movieid = movieid;
            InitializeComponent();

        }

         void InitializeComponent(){
           // pictureBox1 = new PictureBox();
            axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            back_panel = new Panel();
            panel1 = new Panel();
            panel2 = new Panel();
            button1 = new RoundedButton();
            label_N = new Label();
            iconPictureBox = new PictureBox();
            iconPictureBox2 = new PictureBox();
            panel3 = new Panel();
            label3 = new Label();
            data_panel = new Panel();
            label2 = new Label();
            Comment_panel = new Panel();
            Trailer = new Label();
            label1 = new Label();
            trailer_panel = new RoundedPanel();
            poster_panel = new RoundedPanel();
            panel4 = new Panel();
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
            // 
            // panel3
            // 
             panel3.BackColor = Color.FromArgb(24, 24, 24);
            //panel3.BackColor = Color.Transparent;
            panel3.Controls.Add(label3);
            panel3.Controls.Add(data_panel);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(iconPictureBox);
            panel3.Controls.Add(iconPictureBox2);
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
            data_panel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            data_panel.Location = new Point(326, 80);
            data_panel.Name = "data_panel";
            data_panel.Size = new Size(827, 250);
            data_panel.TabIndex = 6;
            // 
            // label2
            // 


            iconPictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Maintain aspect ratio
            iconPictureBox.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\logo.png");
            iconPictureBox.Location = new(1171, 37);
            iconPictureBox.Name = "wide_panel";
            iconPictureBox.Size = new Size(20, 30);
            iconPictureBox.TabIndex = 13;

            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 21F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(1191, 32);
            label2.Name = "label2";
            label2.Size = new Size(118, 30);
            label2.TabIndex = 5;
            label2.Text = "Comments";
            // 
            // Comment_panel
            // 
           // Comment_panel.BackColor = Color.FromArgb(29, 47, 50);
            Comment_panel.BackColor = Color.FromArgb(24, 24, 24);
            Comment_panel.Location = new Point(1171, 75);
            Comment_panel.Name = "Comment_panel";
            Comment_panel.Size = new Size(682, 376);
            Comment_panel.TabIndex = 4;
            // 
            // comment_textbox
            //
           

            int commentY = 10;
            newCommentTextBox = new System.Windows.Forms.TextBox();
            newCommentTextBox.BorderStyle = BorderStyle.None;
            newCommentTextBox.Font = new System.Drawing.Font("Segoe UI", 15F);
            newCommentTextBox.BackColor = Color.FromArgb(29, 41, 43);
            newCommentTextBox.ForeColor = Color.White;
           // newCommentTextBox.BackColor = Color.Red;
            newCommentTextBox.Location = new Point(20, 7); // Position below existing comments
            newCommentTextBox.Width = 375;
           
            RoundedButton addCommentButton = new RoundedButton();
            addCommentButton.CornerRadius = 11;
            addCommentButton.BackColor = Color.Teal;
            addCommentButton.UseVisualStyleBackColor = false;
            addCommentButton.FlatAppearance.BorderSize = 0;
            addCommentButton.FlatStyle = FlatStyle.Flat;
            addCommentButton.Text = "Post";
            addCommentButton.Width = 100;
            addCommentButton.Height = 33;
            addCommentButton.Location = new Point(newCommentTextBox.Width + 35, 5);
            addCommentButton.Click += AddCommentButton_Click;
            

            RoundedPanel roundedPanel1 = new RoundedPanel();
            roundedPanel1.BackColor = Color.FromArgb(29, 41, 43);
            roundedPanel1.Controls.Add(newCommentTextBox);
            roundedPanel1.Controls.Add(addCommentButton);
            roundedPanel1.CornerRadius = 10;
            roundedPanel1.EdgeColor = Color.Black;
            roundedPanel1.Location = new Point(5, Comment_panel.Height - 60);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(519, 44);
            roundedPanel1.TabIndex = 13;
            roundedPanel1.EdgeColor = Color.FromArgb(41, 172, 191);
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

           // back_panel.Anchor

           back_panel.Controls.Add(axWindowsMediaPlayer1);
            // _form.Controls.Add(panel4);
            back_panel.Controls.Add(panel3);
            back_panel.Controls.Add(panel1);
         //  _form.Controls.Add(pictureBox1);

            // 
            // Form1
            // 
            _form.AutoScaleDimensions = new SizeF(7F, 15F);
            _form.AutoScaleMode = AutoScaleMode.Font;
            _form.ClientSize = new Size(1487, 931);
            _form.Controls.Add(back_panel);
            /*     _form.Controls.Add(axWindowsMediaPlayer1);
                // _form.Controls.Add(panel4);
                 _form.Controls.Add(panel3);
                 _form.Controls.Add(panel1);
              //  _form.Controls.Add(pictureBox1);*/
            _form.Name = "Form1";
            _form.Text = "Form1";
           // _form.Load += Form1_Load;
        //  ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
           ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).EndInit();
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            _form.ResumeLayout(false);

           

            PlayVideoFromDatabase();
           

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

                  
                    PopulateMovieDataPanel();
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
            titleLabel.Font = new System.Drawing.Font("Segoe UI", 17, FontStyle.Bold); // Example font size and style
            releaseDateLabel.Font = new System.Drawing.Font("Segoe UI", 17); // Example font size
            ratingLabel.Font = new System.Drawing.Font("Segoe UI", 17); // Example font size

            // Set label positions
            titleLabel.Location = new Point(10, y);
            releaseDateLabel.Location = new Point(10, y + 30); // Adjust vertical spacing as needed
            ratingLabel.Location = new Point(10, y + 60);

            // Set description label width and enable word wrap
            descriptionLabel.AutoSize = false;
            descriptionLabel.Width = data_panel.Width - 20; // Adjust width as needed
            descriptionLabel.Height = 100; // Adjust height as needed
            descriptionLabel.Location = new Point(10, y + 90); // Adjust vertical spacing as needed
            descriptionLabel.Font = new System.Drawing.Font("Segoe UI", 17); // Example font size
            descriptionLabel.AutoEllipsis = true;
            descriptionLabel.Text = "Description: " + movie[2]; // Get description for movie
            descriptionLabel.ForeColor = Color.White;

            // Allow data_panel to adjust its size based on the content
            data_panel.AutoSize = true;

            // Add labels to the data_panel
            data_panel.Controls.Add(titleLabel);
            data_panel.Controls.Add(releaseDateLabel);
            data_panel.Controls.Add(descriptionLabel);
            data_panel.Controls.Add(ratingLabel);

            string PosterImagePath = movie[4];
    
            // Create a PictureBox to display the wide poster image
            PictureBox widePictureBox = new PictureBox();
            widePictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Maintain aspect ratio
            widePictureBox.ImageLocation = PosterImagePath; // Set image location to the retrieved image path
            widePictureBox.Dock = DockStyle.Fill; // Dock the PictureBox to fill the entire panel

            // Add PictureBox to the wide_panel
            poster_panel.Controls.Add(widePictureBox);


             string wideImagePath = movie[5];

             // Create a PictureBox to display the wide poster image
             PictureBox widePicture = new PictureBox();
             widePicture.SizeMode = PictureBoxSizeMode.StretchImage; // Maintain aspect ratio
             widePicture.ImageLocation = wideImagePath; // Set image location to the retrieved image path
             widePicture.Dock = DockStyle.Fill; // Dock the PictureBox to fill the entire panel

             // Add PictureBox to the wide_panel
             trailer_panel.Controls.Add(widePicture);
            widePicture.MouseEnter += PictureBox_MouseEnter; // Attach MouseEnter event handler
            widePicture.MouseLeave += PictureBox_MouseLeave;

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

        private void AddComment(string username, String profilePicture, string commentText)
        {
            PictureBox profilePictureBox = new PictureBox();
            profilePictureBox.Size = new Size(50, 50); // Adjust size as needed
            profilePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            profilePictureBox.Location = new Point(10, 10); // Adjust location as needed

          
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
            usernameLabel.Location = new Point(profilePictureBox.Right + 10, 10); // Adjust location as needed
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
        }


        private void AddCommentButton_Click(object sender, EventArgs e)
        {
            // Handle adding a new comment
            string newComment = newCommentTextBox.Text; // Assuming newCommentTextBox is accessible here
            MessageBox.Show(newComment);
            SqlInstance.PostComment(movieid, newComment, 1);


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
    }
}