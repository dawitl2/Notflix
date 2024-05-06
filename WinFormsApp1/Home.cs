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
using System.Drawing.Drawing2D;
using FullScreenApp;



namespace WinFormsApp1
{
    public class Home
    {
        private readonly Sql SqlInstance = new Sql();
        public Form _form;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
      
        private System.Windows.Forms.Label label1;
        private RoundedButton button1;
        private RoundedButton button2;
        private RoundedButton right;
        private RoundedButton left;
        private TextBox textBox1;
        private Panel panel3;
     
        PictureBox widePictureBox;
        PictureBox iconPictureBox;
        PictureBox iconPictureBox2;
        PictureBox iconPictureBox3;
        PictureBox iconPictureBox4;
        private Label discription_label;
        private Label title_label;
        private Panel panel4;
     
        private Label label3;
        private Label label7;
        private Label label6;

        private FlowLayoutPanel flowLayoutPanel1;
        private RoundedPanel roundedPanel1;
        private Label label5;
        private Label label4;
        private Panel panel8;
        private Panel panel7;
        private Label label2;
        private Panel redPanel;
        private FlowLayoutPanel sidepanel;
        private List<(string, string)> movieDataList;

        public Home(Form form)
        {
            _form = form;
       
            InitializeComponent();
            PopulatewideMovies();
            PopulateMostRatedMovies();
            PopulateMovies();

        }

        private void InitializeComponent()
        {
     //
            panel1 = new Panel();
            roundedPanel1 = new RoundedPanel();
            textBox1 = new TextBox();
            button1 = new RoundedButton();
            button2 = new RoundedButton();
            redPanel = new Panel();
            sidepanel = new FlowLayoutPanel();

            widePictureBox = new PictureBox();
            iconPictureBox = new PictureBox();
            iconPictureBox2 = new PictureBox();
            iconPictureBox4 = new PictureBox();
            iconPictureBox3 = new PictureBox();
            right = new RoundedButton();
            left = new RoundedButton();
            panel3 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            // wide_panel = new Panel();
            // panel5 = new Panel();
            title_label = new Label();
            discription_label = new Label();
            panel4 = new Panel();
          
            label5 = new Label();
            label4 = new Label();
            panel8 = new Panel();
            panel7 = new Panel();
            label2 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label3 = new Label();
            label7= new Label();
            label6 = new Label();

            panel1.SuspendLayout();
            roundedPanel1.SuspendLayout();
            panel2.SuspendLayout();
            widePictureBox.SuspendLayout();
        
            panel4.SuspendLayout();
          
            panel7.SuspendLayout();
            _form.SuspendLayout();

            sidepanel.BackColor = Color.FromArgb(24, 24, 24);
            //sidepanel.BackColor = Color.Red;
            sidepanel.Size = new Size(1900, 225); 
            sidepanel.Location = new Point(0, 780);
            sidepanel.AutoScroll = true;
            //
            //
            redPanel.BackColor = Color.FromArgb(24, 24, 24);
           // redPanel.BackColor = Color.Red;
            redPanel.Size = new Size(400, 550); // Adjust size as needed
            //redPanel.Location = new Point(1390, 830); // Adjust position as needed
            List<string> genres = new List<string>
{
    "Comedy",
    "Action",
    "Drama",
    "Science Fiction",
    "Thriller",
    "Romance",
    "Horror",
    "Fantasy",
    "Mystery"

};  
            int yPos = 14; // Starting Y position

            foreach (string genre in genres)
            {
                // Genre Label
                Label genreLabel = new Label();
                genreLabel.Text = "  " + genre;
                genreLabel.ForeColor = Color.Gray;
                genreLabel.AutoSize = true;
                genreLabel.Font = new System.Drawing.Font("Segoe UI", 20);
                genreLabel.Location = new Point(10, yPos + 10); // Adjust spacing as needed
                redPanel.Controls.Add(genreLabel);

                if (!genre.StartsWith("  "))
                {
                    // Logo PictureBox
                    PictureBox logoPictureBox = new PictureBox();
                    logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Maintain aspect ratio
                    logoPictureBox.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\play.png");
                    logoPictureBox.Location = new Point(10, yPos + 10); // Adjust positioning as needed
                    logoPictureBox.Size = new Size(25, 25);
                    redPanel.Controls.Add(logoPictureBox);

                    genreLabel.Location = new Point(34, yPos); // Adjust spacing as needed
                    genreLabel.MouseEnter += GenreLabel_MouseEnter;
                    genreLabel.MouseLeave += GenreLabel_MouseLeave;

                    genreLabel.MouseClick += (sender, e) => GenreLabel_Click(sender, e, genreLabel);
                }

                yPos += 40; // Increase Y position for the next pair
            }



            panel4.Controls.Add(redPanel);
            panel4.Controls.Add(sidepanel);
           
            //
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(24, 24, 24);
            //panel1.BackColor = Color.Red;
            panel1.Controls.Add(roundedPanel1);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            //panel1.Controls.Add(panel5);
            panel1.Controls.Add(iconPictureBox3);
            panel1.Controls.Add(button2);
            panel1.Font = new System.Drawing.Font("Segoe UI", 11F);
            panel1.Location = new Point(2, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1858, 87);
            panel1.TabIndex = 1;
            // 
            // roundedPanel1
            // 
            roundedPanel1.BackColor = Color.FromArgb(29, 41, 43);
            roundedPanel1.Controls.Add(textBox1);
            roundedPanel1.Controls.Add(button1);
            roundedPanel1.CornerRadius = 10;
            roundedPanel1.EdgeColor = Color.Black;
            roundedPanel1.Location = new Point(700, 21);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(519, 44);
            roundedPanel1.TabIndex = 13;
            roundedPanel1.EdgeColor = Color.FromArgb(29, 41, 43);
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(29, 41, 43);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new System.Drawing.Font("Segoe UI", 15F);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(78, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(420, 32);
            textBox1.TabIndex = 5;
            textBox1.Text = "Search movies...";
            textBox1.ForeColor = Color.Gray;

            textBox1.GotFocus += TextBox1_GotFocus;
            textBox1.KeyDown += TextBox1_KeyDown;
            //
            // button1
            // 
            button1.BackColor = Color.FromArgb(32, 42, 38);
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.CornerRadius = 11;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new System.Drawing.Font("Segoe UI", 11F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(9, 7);
            button1.Name = "button1";
            button1.Size = new Size(54, 31);
            button1.TabIndex = 6;
            button1.Text = "filter";
            button1.UseVisualStyleBackColor = false;
            // button 2 //
            button2.BackColor = Color.Teal;
            button2.CornerRadius = 7;
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new System.Drawing.Font("Segoe UI", 11F);
            button2.ForeColor = Color.Black;
            button2.Name = "button1";
            button2.Size = new Size(90, 45);
            button2.TabIndex = 6;
            button2.Text = "Exit";
            button2.UseVisualStyleBackColor = false;
            button2.Location = new Point(panel1.Width - 94, 21);
            button2.MouseEnter += (sender, e) =>
            {
                AnimateButtonColor(button2, Color.Red);
            };
            button2.MouseLeave += (sender, e) =>
            {
                AnimateButtonColor(button2, Color.Teal);
            };
            button2.MouseClick += (sender, e) => exit_Click(sender, e);

            // right //
            right.BackColor = Color.Teal;
            right.BackgroundImageLayout = ImageLayout.None;
            right.CornerRadius = 26;
            right.Cursor = Cursors.Hand;
            right.FlatAppearance.BorderSize = 0;
            right.FlatStyle = FlatStyle.Flat;
            right.Font = new System.Drawing.Font("Segoe UI", 11F);
            right.ForeColor = Color.Black;
            right.Location = new Point(1730, 20);
            right.Name = "right_B";
            right.Size = new Size(50, 50);
            right.TabIndex = 6;
            right.Text = ">";
            right.UseVisualStyleBackColor = false;

            // Assuming you have created the left and right buttons
            left.Click += left_Click;
            right.Click += right_Click;

            // left //
            left.BackColor = Color.Teal;
            left.BackgroundImageLayout = ImageLayout.None;
            left.CornerRadius = 26;
            left.Cursor = Cursors.Hand;
            left.FlatAppearance.BorderSize = 0;
            left.FlatStyle = FlatStyle.Flat;
            left.Font = new System.Drawing.Font("Segoe UI", 11F);
            left.ForeColor = Color.Black;
            left.Location = new Point(1660, 20);
            left.Name = "Left_B";
            left.Size = new Size(50, 50);
            left.TabIndex = 6;
            left.Text = "<";
            left.UseVisualStyleBackColor = false;
            //
            // panel3
            // 
            panel3.Location = new Point(3, 93);
            panel3.Name = "panel3";
            panel3.Size = new Size(1472, 305);
            panel3.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Teal;
            panel2.Controls.Add(label1);
            panel2.Enabled = false;
            panel2.Location = new Point(100, 21);
            panel2.Name = "panel2";
            panel2.Size = new Size(174, 50);
            panel2.TabIndex = 2;
            // panel 5 // 


            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Impact", 26.25F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(21, 3);
            label1.Name = "label1";
            label1.Size = new Size(130, 43);
            label1.TabIndex = 2;
            label1.Text = "NOTFLIX";
            // 
            // wide_panel
            // 
            //

            //widePictureBox.Controls.Add(panel5);
            widePictureBox.Controls.Add(right);
            widePictureBox.Controls.Add(left);
            widePictureBox.Location = new Point(39, 88);
            widePictureBox.Name = "wide_panel";
            widePictureBox.Size = new(1820, 675);
            widePictureBox.TabIndex = 13;

            iconPictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Maintain aspect ratio
            iconPictureBox.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\logo.png");
            //iconPictureBox.Location = new Point(90, 765);
            iconPictureBox.Name = "wide_panel";
            iconPictureBox.Size = new Size(20, 30);
            iconPictureBox.TabIndex = 13;

            iconPictureBox2.SizeMode = PictureBoxSizeMode.Zoom; // Maintain aspect ratio
            iconPictureBox2.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\logo.png");
            //iconPictureBox2.Location = new(1395, 780);
            iconPictureBox2.Name = "wide_panel";
            iconPictureBox2.Size = new(20, 30);
            iconPictureBox2.TabIndex = 13;
            
            iconPictureBox4.SizeMode = PictureBoxSizeMode.Zoom; // Maintain aspect ratio
            iconPictureBox4.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\logo.png");
          //iconPictureBox4.Location = new(1395, 780);
            iconPictureBox4.Name = "wide_panel";
            iconPictureBox4.Size = new(20, 30);
            iconPictureBox4.TabIndex = 13;

            iconPictureBox3.SizeMode = PictureBoxSizeMode.Zoom; // Maintain aspect ratio
            iconPictureBox3.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\bars.png");
            iconPictureBox3.Location = new Point(37, 21);
            iconPictureBox3.Name = "wide_panel";
            iconPictureBox3.Size = new Size(50, 50);
            iconPictureBox3.TabIndex = 13;
            iconPictureBox3.MouseEnter += bars_MouseEnter; // Attach MouseEnter event handler
            iconPictureBox3.MouseLeave += bars_MouseLeave;
            // wide_panel.Paint += wide_panel_Paint                                                                                                                                     
            // 
            // panel5
            // 
            //   panel5.BackColor = Color.Transparent;
            widePictureBox.Controls.Add(title_label);
            widePictureBox.Controls.Add(discription_label);
            // 
            // title_label
            // 
             // 
            // panel4
            // 
            panel4.AutoScroll = true;
            panel4.AutoSize = true;
            panel4.BackColor = Color.FromArgb(24, 24, 24);
            panel4.Controls.Add(widePictureBox);
            panel4.Controls.Add(iconPictureBox);
            panel4.Controls.Add(iconPictureBox2);
            panel4.Controls.Add(iconPictureBox4);
            panel4.Controls.Add(flowLayoutPanel1);
            panel4.Controls.Add(label3);
           
            panel4.Controls.Add(label6);
            panel4.Controls.Add(panel1);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1487, 931);
            panel4.TabIndex = 15;
            panel4.Controls.Add(label7);

            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.FromArgb(0, 192, 192);
            label5.Location = new Point(531, 144);
            label5.Name = "label5";
            label5.Size = new Size(301, 15);
            label5.TabIndex = 6;
            label5.Text = "Follow us on social medias https//:/Adress/webflix.com";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(41, 122);
            label4.Name = "label4";
            label4.Size = new Size(1342, 15);
            label4.TabIndex = 5;
            //label4.Text = resources.GetString("label4.Text");
            // 
            // panel8
            // 
            panel8.BackColor = Color.Teal;
            panel8.Enabled = false;
            panel8.Location = new Point(26, 110);
            panel8.Name = "panel8";
            panel8.Size = new Size(1810, 2);
            panel8.TabIndex = 4;
            // 
            // panel7
            // 
            panel7.BackColor = Color.Teal;
            panel7.Controls.Add(label2);
            panel7.Enabled = false;
            panel7.Location = new Point(602, 47);
            panel7.Name = "panel7";
            panel7.Size = new Size(174, 50);
            panel7.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            //label2.Location = new Point(20, 3);
            label2.Name = "label2";
            label2.Size = new Size(130, 43);
            label2.TabIndex = 2;
            label2.Text = "WebFlix";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.FromArgb(24, 24, 24);
            flowLayoutPanel1.Location = new Point(97, 820);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1354, 967);
            flowLayoutPanel1.TabIndex = 2;
            flowLayoutPanel1.Margin = new Padding(0, 350, 0, 0);

            // Adjust the position of the red panel
            panel4.Margin = new Padding(0, 350, 0, 0);


            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 19F);
            label3.ForeColor = Color.White;
            //label3.Location = new Point(115, 760);
            label3.Name = "label3";
            label3.Size = new Size(283, 36);
            label3.TabIndex = 0;
            label3.Text = "Recommended Movies!";
            //////////
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 19F);
            label7.ForeColor = Color.White;
            //label7.Location = new Point(115, 760);
            label7.Name = "label3";
            label7.Size = new Size(283, 36);
            label7.TabIndex = 0;
            label7.Text = "Latest updates.";
            // lable 6
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 19F);
            label6.ForeColor = Color.White;
            //label6.Location = new Point(1420, 775);
            label6.Name = "label3";
            label6.Size = new Size(283, 36);
            label6.TabIndex = 0;
            label6.Text = "Recommended Genres!";
            // 
            // Form1
            // 
            _form.AutoScaleDimensions = new SizeF(7F, 15F);
            _form.AutoScaleMode = AutoScaleMode.Font;
            //_form.ClientSize = new Size(1487, 931);
            _form.Controls.Add(panel4);
            //_form.FormBorderStyle = FormBorderStyle.FixedSingle;
            //_form.MaximizeBox = false;
            _form.Name = "Form1";
            _form.Text = "Form1";
            _form.TopMost = true;
            panel1.ResumeLayout(false);
            roundedPanel1.ResumeLayout(false);
            roundedPanel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            widePictureBox.ResumeLayout(false);
            // panel5.ResumeLayout(false);
            // panel5.PerformLayout();
            panel4.ResumeLayout(false);
  
            panel4.PerformLayout();
          
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            _form.ResumeLayout(false);
            _form.PerformLayout();


            // Adjust the position of the FlowLayoutPanel
            flowLayoutPanel1.Location = new Point(97, 1100);

            // Adjust the position of the red panel
            panel4.Location = new Point(0, 1170);

            // Adjust the position of the red panel
            redPanel.Location = new Point(1410, 1095);

            // Adjust the position of the label "Recommended Movies"
            label3.Location = new Point(115, 1035);
            label7.BringToFront();
            iconPictureBox4.BringToFront();

            label7.Location = new Point(115, 735);

            // Adjust the position of the icon beside "Recommended Movies"
            iconPictureBox.Location = new Point(90, 1040);

            // Adjust the position of the label "Recommended Genres"
            label6.Location = new Point(1420, 1040);

            // Adjust the position of the icon beside "Recommended Genres"
            iconPictureBox2.Location = new Point(label6.Left - 20, 1045);
            iconPictureBox4.Location = new Point(label7.Left - 30, 740);

        }


        private void PopulatewideMovies()
        {
            List<(string name, string posterPath, string man)> movies = SqlInstance.wideMoviePosters();

            int pictureBoxWidth = 435; // Width of the PictureBox
            int pictureBoxHeight = 180; // Height of the PictureBox
            int horizontalSpacing = 30; // Horizontal spacing between PictureBoxes
            int verticalSpacing = 20; // Vertical spacing between PictureBoxes

            int x = horizontalSpacing; // Initial X coordinate for the first PictureBox
            int y = verticalSpacing; // Initial Y coordinate for the PictureBox

            int maxImagesToShow = 4; // Set the maximum number of images to display

            for (int i = 0; i < Math.Min(maxImagesToShow, movies.Count); i++)
            {
                (string name, string posterPath, string man) = movies[i]; // Get movie details from the list

                // Create PictureBox
                RoundedPictureBox pictureBox = new RoundedPictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Maintain aspect ratio
                pictureBox.Image = System.Drawing.Image.FromFile(posterPath);
                pictureBox.Size = new Size(pictureBoxWidth, pictureBoxHeight); // Set size
                pictureBox.Location = new Point(x, y); // Set position
                pictureBox.Margin = new Padding(horizontalSpacing, verticalSpacing, 0, 0); // Add spacing between PictureBoxes

                // Add PictureBox to the side panel
                sidepanel.Controls.Add(pictureBox);

                // Subscribe to the MouseEnter and MouseLeave events
                pictureBox.MouseEnter += (sender, e) =>
                {
                    // Refresh to trigger repaint with updated title appearance
                    pictureBox.Refresh();
                };

                pictureBox.MouseLeave += (sender, e) =>
                {
                    // Refresh to trigger repaint with updated title appearance
                    pictureBox.Refresh();
                };

                // Subscribe to the Paint event for drawing the fading effect and title
                pictureBox.Paint += (sender, e) =>
                {
                    int coloredAreaHeight = (pictureBox.Height / 2) + 100;

                    // Draw fading teal color
                    for (int j = 0; j <= coloredAreaHeight; j++)
                    {
                        int alpha = (int)(255 * ((double)j / coloredAreaHeight));
                        Color color = Color.FromArgb(alpha, Color.Teal);
                        Rectangle rect = new Rectangle(0, pictureBox.Height - coloredAreaHeight + j, pictureBox.Width, 1);
                        using (SolidBrush brush = new SolidBrush(color))
                        {
                            e.Graphics.FillRectangle(brush, rect);
                        }
                    }

                    // Determine title font and color based on mouse hover state
                    System.Drawing.Font font = new System.Drawing.Font("Arial", pictureBox.ClientRectangle.Contains(pictureBox.PointToClient(Control.MousePosition)) ? 35 : 23, FontStyle.Bold);
                    Color textColor = pictureBox.ClientRectangle.Contains(pictureBox.PointToClient(Control.MousePosition)) ? Color.White : Color.Black;

                    // Draw title text
                    using (Brush brush = new SolidBrush(textColor))
                    {
                        SizeF textSize = e.Graphics.MeasureString(name, font);
                        float titleX, titleY;

                        // Adjust title position based on mouse hover
                        if (pictureBox.ClientRectangle.Contains(pictureBox.PointToClient(Control.MousePosition)))
                        {
                            titleX = (pictureBox.Width - textSize.Width) / 2;
                            titleY = (pictureBox.Height - textSize.Height) / 2;
                        }
                        else
                        {
                            titleX = (pictureBox.Width - textSize.Width) / 2;
                            titleY = pictureBox.Height - 20 - textSize.Height;
                        }

                        PointF titleLocation = new PointF(titleX, titleY);

                        // Draw the title text
                        e.Graphics.DrawString(name, font, brush, titleLocation);
                    }
                };

                pictureBox.Cursor = Cursors.Hand; // Change cursor to hand pointer

                // Update X coordinate for the next PictureBox
                x += pictureBoxWidth + horizontalSpacing;
            }
        }






        private void PopulateMovies()
        {
            List<(string, string, string)> movies = SqlInstance.GetMoviePosters();

            int pictureBoxWidth = 200; // Width of the PictureBox
            int pictureBoxHeight = 250; // Height of the PictureBox
            int labelHeight = 20; // Height of the Label
            int durationLabelHeight = 15; // Height of the duration Label
            int verticalSpacing = 10; // Vertical spacing between PictureBox and Labels

            foreach ((string name, string posterPath, string duration) in movies)
            {
                // Create PictureBox
                RoundedPictureBox pictureBox = new RoundedPictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Maintain aspect ratio
                pictureBox.Image = System.Drawing.Image.FromFile(posterPath);
                pictureBox.Size = new Size(pictureBoxWidth, pictureBoxHeight); // Set size
                pictureBox.MouseEnter += PictureBox_MouseEnter; // Attach MouseEnter event handler
                pictureBox.MouseLeave += PictureBox_MouseLeave; // Attach MouseLeave event handler
                pictureBox.Click += (sender, e) => PictureBox_Click(sender, e, name, duration, posterPath); // Attach Click event handler

                // Create Label for movie title
                Label titleLabel = new Label();
                titleLabel.Text = name;
                titleLabel.TextAlign = ContentAlignment.MiddleLeft;
                titleLabel.AutoSize = false;
                titleLabel.Size = new Size(pictureBoxWidth, labelHeight); // Set size

                // Create Label for movie duration
                Label durationLabel = new Label();
                durationLabel.Text = duration + " min        HD";
                durationLabel.TextAlign = ContentAlignment.MiddleLeft;
                durationLabel.AutoSize = false;
                durationLabel.Size = new Size(pictureBoxWidth, durationLabelHeight); // Set size

                // Assuming you have a Label named "titleLabel" declared somewhere in your code
                titleLabel.Font = new System.Drawing.Font("Arial", 14, FontStyle.Bold); // Change font size and style
                titleLabel.ForeColor = Color.White; // Change font color
                durationLabel.Font = new System.Drawing.Font("Arial", 11, FontStyle.Bold); // Change font size and style
                durationLabel.ForeColor = Color.Teal; // Change font color

                // Create container panel to hold PictureBox and Labels
                FlowLayoutPanel moviePanel = new FlowLayoutPanel();
                moviePanel.FlowDirection = FlowDirection.TopDown;
                moviePanel.Size = new Size(pictureBoxWidth, pictureBoxHeight + labelHeight + durationLabelHeight + verticalSpacing * 2); // Set size
                moviePanel.Controls.Add(pictureBox);
                moviePanel.Controls.Add(titleLabel);
                moviePanel.Controls.Add(durationLabel);

                // Add container panel to the FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(moviePanel);
            }


        }
        private void PopulateMovie(string type)
        {
            // Clear existing movie panels
            flowLayoutPanel1.Controls.Clear();


            // Retrieve movies for the specified genre
            List<(string, string, string)> movies = SqlInstance.GetMoviePostersByGenre(type);

            // Set dimensions and spacing for movie controls
            int pictureBoxWidth = 200; // Width of the PictureBox
            int pictureBoxHeight = 250; // Height of the PictureBox
            int labelHeight = 20; // Height of the Label
            int durationLabelHeight = 15; // Height of the duration Label
            int verticalSpacing = 10; // Vertical spacing between PictureBox and Labels

            // Iterate over retrieved movies and populate the FlowLayoutPanel
            foreach ((string name, string posterPath, string duration) in movies)
            {
                // Create PictureBox
                RoundedPictureBox pictureBox = new RoundedPictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Maintain aspect ratio
                pictureBox.Image = System.Drawing.Image.FromFile(posterPath);
                pictureBox.Size = new Size(pictureBoxWidth, pictureBoxHeight); // Set size#
                pictureBox.MouseEnter += PictureBox_MouseEnter; // Attach MouseEnter event handler
                pictureBox.MouseLeave += PictureBox_MouseLeave; // Attach MouseLeave event handler
                pictureBox.Click += (sender, e) => PictureBox_Click(sender, e, name, duration, posterPath); // Attach Click event handler

                // Create Label for movie title
                Label titleLabel = new Label();
                titleLabel.Text = name;
                titleLabel.TextAlign = ContentAlignment.MiddleLeft;
                titleLabel.AutoSize = false;
                titleLabel.Size = new Size(pictureBoxWidth, labelHeight); // Set size
                titleLabel.Font = new System.Drawing.Font("Arial", 14, FontStyle.Bold); // Change font size and style
                titleLabel.ForeColor = Color.White; // Change font color

                // Create Label for movie duration
                Label durationLabel = new Label();
                durationLabel.Text = duration + "'";
                durationLabel.TextAlign = ContentAlignment.MiddleLeft;
                durationLabel.AutoSize = false;
                durationLabel.Size = new Size(pictureBoxWidth, durationLabelHeight); // Set size
                durationLabel.Font = new System.Drawing.Font("Arial", 11, FontStyle.Bold); // Change font size and style
                durationLabel.ForeColor = Color.Teal; // Change font color

                // Create container panel to hold PictureBox and Labels
                FlowLayoutPanel moviePanel = new FlowLayoutPanel();
                moviePanel.FlowDirection = FlowDirection.TopDown;
                moviePanel.Size = new Size(pictureBoxWidth, pictureBoxHeight + labelHeight + durationLabelHeight + verticalSpacing * 2); // Set size
                moviePanel.Controls.Add(pictureBox);
                moviePanel.Controls.Add(titleLabel);
                moviePanel.Controls.Add(durationLabel);

                // Add container panel to the FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(moviePanel);
            }
        }
        
        private void PopulateMovie(string movie, int n)
        {
            // Clear existing movie panels
            flowLayoutPanel1.Controls.Clear();


            // Retrieve movies for the specified genre
            List<(string, string, string)> movies = SqlInstance.GetMoviePostersname(movie);

            // Set dimensions and spacing for movie controls
            int pictureBoxWidth = 200; // Width of the PictureBox
            int pictureBoxHeight = 250; // Height of the PictureBox
            int labelHeight = 20; // Height of the Label
            int durationLabelHeight = 15; // Height of the duration Label
            int verticalSpacing = 10; // Vertical spacing between PictureBox and Labels

            // Iterate over retrieved movies and populate the FlowLayoutPanel
            foreach ((string name, string posterPath, string duration) in movies)
            {
                // Create PictureBox
                RoundedPictureBox pictureBox = new RoundedPictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Maintain aspect ratio
                pictureBox.Image = System.Drawing.Image.FromFile(posterPath);
                pictureBox.Size = new Size(pictureBoxWidth, pictureBoxHeight); // Set size#
                pictureBox.MouseEnter += PictureBox_MouseEnter; // Attach MouseEnter event handler
                pictureBox.MouseLeave += PictureBox_MouseLeave; // Attach MouseLeave event handler
                pictureBox.Click += (sender, e) => PictureBox_Click(sender, e, name, duration, posterPath); // Attach Click event handler

                // Create Label for movie title
                Label titleLabel = new Label();
                titleLabel.Text = name;
                titleLabel.TextAlign = ContentAlignment.MiddleLeft;
                titleLabel.AutoSize = false;
                titleLabel.Size = new Size(pictureBoxWidth, labelHeight); // Set size
                titleLabel.Font = new System.Drawing.Font("Arial", 14, FontStyle.Bold); // Change font size and style
                titleLabel.ForeColor = Color.White; // Change font color

                // Create Label for movie duration
                Label durationLabel = new Label();
                durationLabel.Text = duration + "'";
                durationLabel.TextAlign = ContentAlignment.MiddleLeft;
                durationLabel.AutoSize = false;
                durationLabel.Size = new Size(pictureBoxWidth, durationLabelHeight); // Set size
                durationLabel.Font = new System.Drawing.Font("Arial", 11, FontStyle.Bold); // Change font size and style
                durationLabel.ForeColor = Color.Teal; // Change font color

                // Create container panel to hold PictureBox and Labels
                FlowLayoutPanel moviePanel = new FlowLayoutPanel();
                moviePanel.FlowDirection = FlowDirection.TopDown;
                moviePanel.Size = new Size(pictureBoxWidth, pictureBoxHeight + labelHeight + durationLabelHeight + verticalSpacing * 2); // Set size
                moviePanel.Controls.Add(pictureBox);
                moviePanel.Controls.Add(titleLabel);
                moviePanel.Controls.Add(durationLabel);

                // Add container panel to the FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(moviePanel);
            }
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.Cursor = Cursors.Hand; // Change cursor to hand pointer

            // Define the height of the colored area (half of the picture box height)
            int coloredAreaHeight = (pictureBox.Height / 2) + 100;

            // Create a semi-transparent overlay with fading effect
            using (Graphics g = pictureBox.CreateGraphics())
            {
                for (int i = 0; i <= coloredAreaHeight; i++)
                {
                    // Calculate the alpha value based on the current height position
                    int alpha = (int)(255 * ((double)i / coloredAreaHeight));

                    // Define the color with the calculated alpha value
                    Color color = Color.FromArgb(alpha, Color.Teal);

                    // Define the rectangle to paint (from top to current height position)
                    Rectangle rect = new Rectangle(0, pictureBox.Height - coloredAreaHeight + i, pictureBox.Width, 1);

                    // Fill the rectangle with the semi-transparent color
                    using (SolidBrush brush = new SolidBrush(color))
                    {
                        g.FillRectangle(brush, rect);
                    }
                }
            }

            // Add play button icon in the middle
            int playButtonSize = 50; // Adjust size as needed
            int playButtonX = (pictureBox.Width - playButtonSize) / 2;
            int playButtonY = (pictureBox.Height - playButtonSize) / 2;

            // Draw the play button icon
            using (Graphics g = pictureBox.CreateGraphics())
            using (System.Drawing.Font font = new System.Drawing.Font("Arial", 32))
            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                g.DrawString("▶", font, brush, playButtonX, playButtonY);
            }
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.Cursor = Cursors.Default; // Revert cursor to default

            // Clear the overlay by redrawing the PictureBox
            pictureBox.Invalidate();
        }




        private void bars_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.Cursor = Cursors.Hand; // Change cursor to hand pointer
        }

        // Inside the MouseLeave event handler:
        private void bars_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.Cursor = Cursors.Default; // Revert cursor to default
        }

        private void PictureBox_Click(object sender, EventArgs e, string movieName, string movieDuration, string posterPath)
        {
            // Retrieve movie ID using the posterPath
            string movieId = SqlInstance.GetMovieIdFromImagePath(posterPath);

            // Retrieve movie data using the movie ID
            string[] movieData = SqlInstance.GetMovieDataById(int.Parse(movieId));

            // Display movie title in a message box
            //  MessageBox.Show($"The ID of the clicked movie is: {movieData[0]}");

            /*  panel1.Visible = false;
              widePictureBox.Visible = false;
              flowLayoutPanel1.Visible = false;
              label3.Visible = false;
              panel4.Visible = false;
              label6.Visible = false;
             // genreLabel.Visible = false;
              iconPictureBox.Visible = false;
              iconPictureBox2.Visible = false;
              iconPictureBox3.Visible = false;*/

            panel4.Visible = false;


            Video_class Vid = new Video_class(_form, movieData, int.Parse(movieId));

        }

        private List<string[]> topRatedMoviesData; // Store data of top rated movies
        private int currentMovieIndex; // Index of the currently displayed movie in the topRatedMoviesData list

        // Modify PopulateMostRatedMovie method to display top 3 rated movies
        private void PopulateMostRatedMovies()
        {
            topRatedMoviesData = SqlInstance.GetTopRatedMoviesData(); // Get data of top rated movies

            // Display the first movie initially
            DisplayMovieAtIndex(0);
        }

        // Helper method to display movie at a specific index in the topRatedMoviesData list
        // Helper method to display movie at a specific index in the topRatedMoviesData list
        private void DisplayMovieAtIndex(int index)
        {
            // Clear previous movie data
            widePictureBox.Controls.Clear();

            // Retrieve data of the movie at the specified index
            string[] movieData = topRatedMoviesData[index];

            // Populate UI elements with movie data

            // Create a panel to hold the text displaying panel and buttons
            Panel contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Bottom;
            contentPanel.BackColor = Color.Transparent;
            contentPanel.Height = 350; // Adjust the height as needed
            contentPanel.Paint += (sender, e) =>
            {
                // Define the rectangle to paint
                Rectangle rect = new Rectangle(0, 0, contentPanel.Width, contentPanel.Height);

                // Define the linear gradient brush
                LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Transparent, Color.FromArgb(24, 24, 24), LinearGradientMode.Vertical);

                // Define the gradient stops
                ColorBlend blend = new ColorBlend();
                blend.Positions = new[] { 0.0f, 0.3f, 0.7f, 1.0f }; // Adjust positions for gradient transition
                blend.Colors = new[] { Color.Transparent, Color.Transparent, Color.FromArgb(24, 24, 24), Color.FromArgb(24, 24, 24) }; // Start from solid color at the bottom to transparent at the top

                // Set the gradient stops
                brush.InterpolationColors = blend;

                // Fill the rectangle with the gradient brush
                e.Graphics.FillRectangle(brush, rect);
            };

            // Create PictureBox for the image
            PictureBox pictureBox = new PictureBox();
            pictureBox.Location = new Point(10, 85); // Adjust the location as needed
            pictureBox.Size = new Size(236, 82); // Adjust the size as needed
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Adjust the size mode as needed
            pictureBox.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\stars.png"); 
            contentPanel.Controls.Add(pictureBox);


            // Retrieve data of the movie at the specified index
            string[] movieData1 = topRatedMoviesData[index];

            widePictureBox.Controls.Add(left);
            widePictureBox.Controls.Add(right);

            // Create and set properties for title_label


            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Segoe UI", 55F);
            this.title_label.ForeColor = Color.White;
            this.title_label.Location = new Point(10, 139);
            this.title_label.Name = "title_label";
            this.title_label.Size = new Size(5, 5);
            this.title_label.TabIndex = 0;
           
            // 
            // discription_label
            // 
            discription_label.AutoSize = true;
            discription_label.Font = new System.Drawing.Font("Segoe UI", 18F);
            discription_label.ForeColor = Color.White;
            discription_label.Location = new Point(30, 240);
            discription_label.Name = "discription_label";
            discription_label.Size = new Size(538, 30);
            discription_label.TabIndex = 1;

            this.title_label.Text = movieData[0];


            discription_label.Text = movieData[2];

            // Create a new RoundedButton for the "Watch" button
            RoundedButton watchButton = new RoundedButton();
            watchButton.BackColor = Color.Teal;
            watchButton.BackgroundImageLayout = ImageLayout.None;
            watchButton.CornerRadius = 7;
            watchButton.Cursor = Cursors.Hand;
            watchButton.FlatAppearance.BorderSize = 0;
            watchButton.FlatStyle = FlatStyle.Flat;
            watchButton.Font = new System.Drawing.Font("Impact", 21F);
            watchButton.ForeColor = Color.Black;
            watchButton.Location = new Point(right.Left - 100, 220); // Adjust position as needed
            watchButton.Size = new Size(160, 50); // Adjust size as needed
            watchButton.TabIndex = 7;
            watchButton.Text = "Watch";
            watchButton.UseVisualStyleBackColor = false;
            watchButton.MouseEnter += (sender, e) =>
            {
                AnimateButtonColor(watchButton, Color.Green);
            };
            watchButton.MouseLeave += (sender, e) =>
            {
                AnimateButtonColor(watchButton, Color.Teal);
            };
            
            RoundedButton trailerButton = new RoundedButton();
            trailerButton.BackColor = Color.Teal;
            trailerButton.BackgroundImageLayout = ImageLayout.None;
            trailerButton.CornerRadius = 7;
            trailerButton.Cursor = Cursors.Hand;
            trailerButton.FlatAppearance.BorderSize = 0;
            trailerButton.FlatStyle = FlatStyle.Flat;
            trailerButton.Font = new System.Drawing.Font("Impact", 21F);
            trailerButton.ForeColor = Color.Black;
            trailerButton.Location = new Point(watchButton.Left - 170, 220); // Adjust position as needed
            trailerButton.Size = new Size(160, 50); // Adjust size as needed
            trailerButton.TabIndex = 7;
            trailerButton.Text = "Trailer";
            trailerButton.UseVisualStyleBackColor = false;
            trailerButton.MouseEnter += (sender, e) =>
            {
                AnimateButtonColor(trailerButton, Color.Red);
            };
            trailerButton.MouseLeave += (sender, e) =>
            {
                AnimateButtonColor(trailerButton, Color.Teal);
            };


            // Add the "Watch" button to the contentPanel
            contentPanel.Controls.Add(watchButton);
            contentPanel.Controls.Add(trailerButton);
            // Assuming index 2 holds the movie description


            // Add labels to contentPanel
            contentPanel.Controls.Add(this.title_label);
            contentPanel.Controls.Add(discription_label);

            // Add contentPanel to the wide_panel
            widePictureBox.Controls.Add(contentPanel);

            // Create PictureBox
            string widePosterImagePath = movieData[5];
            System.Drawing.Image widePosterImage = System.Drawing.Image.FromFile(widePosterImagePath);


            widePictureBox.Image = widePosterImage;
            widePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            widePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
         
            currentMovieIndex = index;
        }

      

        private async void AnimateButtonColor(RoundedButton button, Color targetColor)
        {
            // Adjust the steps and duration as needed for the desired effect
            int steps = 20;
            int duration = 400; // in milliseconds

            Color initialColor = button.BackColor;
            for (int i = 1; i <= steps; i++)
            {
                float ratio = (float)i / steps;
                int R = (int)(initialColor.R + ratio * (targetColor.R - initialColor.R));
                int G = (int)(initialColor.G + ratio * (targetColor.G - initialColor.G));
                int B = (int)(initialColor.B + ratio * (targetColor.B - initialColor.B));

                button.BackColor = Color.FromArgb(R, G, B);

                await Task.Delay(duration / steps);
            }

            button.BackColor = targetColor;
        }
        
        private void left_Click(object sender, EventArgs e)
        {
            if (currentMovieIndex > 0)
            {
                DisplayMovieAtIndex(currentMovieIndex - 1);
            }
        }

        private void right_Click(object sender, EventArgs e)
        {
            if (currentMovieIndex < topRatedMoviesData.Count - 1)
            {
                DisplayMovieAtIndex(currentMovieIndex + 1);
            }
        }



        private void GenreLabel_MouseEnter(object sender, EventArgs e)
        {
            Label hoveredLabel = sender as Label;
            hoveredLabel.Left += 30; // Shift the hovered label a little to the right
            hoveredLabel.Font = new System.Drawing.Font("Segoe UI", 25); // Increase font size
            hoveredLabel.ForeColor = Color.Teal; // Change font color
        }

        private void GenreLabel_MouseLeave(object sender, EventArgs e)
        {
            Label hoveredLabel = sender as Label;
            hoveredLabel.Left -= 30; // Reset the position of the hovered label when the mouse leaves
            hoveredLabel.Font = new System.Drawing.Font("Segoe UI", 20); // Reset font size
            hoveredLabel.ForeColor = Color.Gray; // Reset font color
        }

        private void GenreLabel_Click(object sender, EventArgs e, Label label)
        {
              
                PopulateMovie(label.Text.ToLower());
           
            
        }
        private void exit_Click(object sender, EventArgs e)
        {
            // Clear the controls of the current form
             _form.Controls.Clear();

            // Create a new instance of FullScreenForm
            FullScreenForm form = new FullScreenForm();

            // Show the new form
            form.Show();
           //_form.Close();
        }

        //////////////////////////////////////////////////////////////////////
        //////////////////////////////// search ///////////////////////////////
        //////////////////////////////////////////////////////////////////////

        private void TextBox1_GotFocus(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search movies...")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.White;
            }
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
              if (e.KeyCode == Keys.Enter)
            {
                
                string searchText = textBox1.Text;
                PerformSearch(searchText);
            }
        }

         private void PerformSearch(string searchText)
          {
            PopulateMovie(searchText, 1); 
          }
    }
}