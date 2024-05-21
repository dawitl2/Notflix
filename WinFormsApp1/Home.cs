using WinFormsApp;
using System.Drawing.Drawing2D;
using FullScreenApp;
using System.Diagnostics;

namespace WinFormsApp1
{
    public class Home
    {
        private readonly Sql SqlInstance = new Sql();
        public Form _form;
        private System.Windows.Forms.Panel panel1;
        private RoundedButton button1;
        private RoundedButton button2;
        private RoundedButton right;
        private RoundedButton left;
        private TextBox textBox1;
        private Panel panel3;
        private RoundedPanel panel;
        private RoundedPanel suggestionPanel;

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
        private int id;
       
        public Home(Form form, int id)
        {
            this.id = id;
             _form = form;
            InitializeComponent();
            PopulatewideMovies();
            PopulateMostRatedMovies();
            PopulateMovies();

        }

        private void InitializeComponent()
        {

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
            label7 = new Label();
            label6 = new Label();

            suggestionPanel = new RoundedPanel();
            suggestionPanel.BackColor = Color.FromArgb(29, 41, 43);
            suggestionPanel.CornerRadius = 10;
            suggestionPanel.EdgeColor = Color.FromArgb(29, 41, 43);
            suggestionPanel.Visible = false; // Initially hidden
           

            panel1.SuspendLayout();
            roundedPanel1.SuspendLayout();
            widePictureBox.SuspendLayout();

            panel4.SuspendLayout();

            panel7.SuspendLayout();
            _form.SuspendLayout();

            sidepanel.BackColor = Color.FromArgb(24, 24, 24);
            sidepanel.Size = new Size(1840, 175);
            sidepanel.Location = new Point(60, 780);
            sidepanel.AutoScroll = true;
          
            redPanel.BackColor = Color.FromArgb(24, 24, 24);
            redPanel.Size = new Size(400, 700);
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
    "Mystery",
    "History",
    "Lib Anteltay",
    "Cartoon",
    "Adult",
    "Milf",
    "Step Mom"

};
            int yPos = 14;
            foreach (string genre in genres)
            {
                Label genreLabel = new Label();
                genreLabel.Text = "  " + genre;
                genreLabel.ForeColor = Color.Gray;
                genreLabel.AutoSize = true;
                genreLabel.Font = new System.Drawing.Font("Segoe UI", 20);
                genreLabel.Location = new Point(10, yPos + 10);
                redPanel.Controls.Add(genreLabel);

                if (!genre.StartsWith("  "))
                {
                    // Logo PictureBox
                    PictureBox logoPictureBox = new PictureBox();
                    logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    logoPictureBox.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\play.png");
                    logoPictureBox.Location = new Point(10, yPos + 10);
                    logoPictureBox.Size = new Size(25, 25);
                    redPanel.Controls.Add(logoPictureBox);

                    genreLabel.Location = new Point(34, yPos);
                    genreLabel.MouseEnter += GenreLabel_MouseEnter;
                    genreLabel.MouseLeave += GenreLabel_MouseLeave;

                    genreLabel.MouseClick += (sender, e) => GenreLabel_Click(sender, e, genreLabel);
                }

                yPos += 40; 
            }


            panel4.Controls.Add(redPanel);
            panel4.Controls.Add(sidepanel);
            //
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(24, 24, 24);
            _form.Controls.Add(suggestionPanel);
            suggestionPanel.BringToFront();
            panel1.Controls.Add(roundedPanel1);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(iconPictureBox3);
            panel1.Controls.Add(button2);
            panel1.Font = new System.Drawing.Font("Segoe UI", 11F);
            panel1.Dock = DockStyle.Top;
            //panel1.Location = new Point(2, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1900, 66);
            panel1.TabIndex = 1;
            panel1.BringToFront();
            // 
            // roundedPanel1
            // 
            roundedPanel1.BackColor = Color.FromArgb(29, 41, 43); 
            roundedPanel1.Controls.Add(textBox1);
            roundedPanel1.Controls.Add(button1);
            roundedPanel1.CornerRadius = 10;
            roundedPanel1.Location = new Point(700, 21);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(519, 44);
            roundedPanel1.TabIndex = 13;
            roundedPanel1.BorderStyle = System.Windows.Forms.BorderStyle.None;
           // roundedPanel1.EdgeColor = Color.Teal;
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
            textBox1.TextChanged += TextBox1_TextChanged;
            //
            // button1
            // 
            //button1.BackColor = Color.FromArgb(32, 42, 38);
            button1.BackColor = Color.Teal;
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
            button1.MouseClick += (sender, e) => filter_Click(sender, e);


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
            button2.Location = new Point(panel1.Width - 130, 21);
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
            right.Location = new Point(1810, 70);
            right.Name = "right_B";
            right.Size = new Size(50, 50);
            right.TabIndex = 6;
            right.Text = ">";
            right.UseVisualStyleBackColor = false;
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
            left.Location = new Point(1740, 70);
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
            // wide_panel
            // 
            //
            widePictureBox.Controls.Add(right);
            widePictureBox.Controls.Add(left);
            widePictureBox.Location = new Point(0, 40);
            widePictureBox.Name = "wide_panel";
            widePictureBox.Size = new(1900, 723);
            widePictureBox.TabIndex = 13;

            iconPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            iconPictureBox.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\logo.png");
            iconPictureBox.Name = "wide_panel";
            iconPictureBox.Size = new Size(20, 30);
            iconPictureBox.TabIndex = 13;

            iconPictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            iconPictureBox2.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\logo.png");
            iconPictureBox2.Name = "wide_panel";
            iconPictureBox2.Size = new(20, 30);
            iconPictureBox2.TabIndex = 13;

            iconPictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            iconPictureBox4.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\logo.png");
            iconPictureBox4.Name = "wide_panel";
            iconPictureBox4.Size = new(20, 30);
            iconPictureBox4.TabIndex = 13;

            iconPictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            iconPictureBox3.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\notflix.png");
            iconPictureBox3.Location = new Point(37, 21);
            iconPictureBox3.Name = "wide_panel";
            iconPictureBox3.Size = new Size(160, 45);
            iconPictureBox3.TabIndex = 13;
            iconPictureBox3.MouseEnter += bars_MouseEnter;
            iconPictureBox3.MouseLeave += bars_MouseLeave;
            iconPictureBox3.Click += bars_click;
            // 
            // panel5
            // 
            widePictureBox.Controls.Add(title_label);
            widePictureBox.Controls.Add(discription_label);
            // 
            // panel4
            // 
            panel4.AutoScroll = true;
            panel4.AutoSize = true;
            panel4.BackColor = Color.FromArgb(24, 24, 24);
            panel4.Controls.Add(panel1);
            panel4.Controls.Add(widePictureBox);
            panel4.Controls.Add(iconPictureBox);
            panel4.Controls.Add(iconPictureBox2);
            panel4.Controls.Add(iconPictureBox4);
            panel4.Controls.Add(flowLayoutPanel1);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(label6);
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
            _form.Controls.Add(panel4);
            _form.Name = "Form1";
            _form.Text = "Form1";
            panel1.ResumeLayout(false);
            roundedPanel1.ResumeLayout(false);
            roundedPanel1.PerformLayout();
            widePictureBox.ResumeLayout(false);
            panel4.ResumeLayout(false);

            panel4.PerformLayout();

            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            _form.ResumeLayout(false);
            _form.PerformLayout();

            // location fixing
            flowLayoutPanel1.Location = new Point(97, 1040);
            panel4.Location = new Point(0, 1110);
            redPanel.Location = new Point(1410, 1035);
            label3.Location = new Point(115, 965);
            label7.BringToFront();
            iconPictureBox4.BringToFront();
            label7.Location = new Point(115, 735);
            iconPictureBox.Location = new Point(90, 967);
            label6.Location = new Point(1420, 960);
            iconPictureBox2.Location = new Point(label6.Left - 20, 967); // gunra lable
            iconPictureBox4.Location = new Point(label7.Left - 30, 740);

        }

        private void PopulatewideMovies()
        {
            List<(string name, string posterPath, string duration, List<string> genres, int rating)> movies = SqlInstance.GetMostRecentMovieDetailsWithGenresAndRatings();

            int pictureBoxWidth = 400;
            int pictureBoxHeight = 136;
            int horizontalSpacing = 30;
            int verticalSpacing = 20;
            int x = horizontalSpacing;
            int y = verticalSpacing;
            int maxImagesToShow = 4;
            for (int i = 0; i < Math.Min(maxImagesToShow, movies.Count); i++)
            {
                (string name, string posterPath, string man, List<string> genres, int rating) = movies[i];

                RoundedPictureBox pictureBox = new RoundedPictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Image = System.Drawing.Image.FromFile(posterPath);
                pictureBox.Size = new Size(pictureBoxWidth, pictureBoxHeight);
                pictureBox.Location = new Point(x, y);
                pictureBox.Margin = new Padding(horizontalSpacing, verticalSpacing, 0, 0);
                pictureBox.CornerRadius = 9;

                Size normalSize = pictureBox.Size;
                Size hoverSize = new Size(normalSize.Width + 36, normalSize.Height + 36); // Increase by 10 pixels
                Padding normalMargin = pictureBox.Margin;
                Padding hoverMargin = new Padding(normalMargin.Left + 30, normalMargin.Top - 30, normalMargin.Right, normalMargin.Bottom); // Increase by 5 pixels

                // Event handlers
                pictureBox.MouseEnter += (sender, e) =>
                {
                    pictureBox.Size = hoverSize;
                    pictureBox.Margin = hoverMargin;
                    pictureBox.Refresh();   
                };

                pictureBox.MouseLeave += (sender, e) =>
                {
                    pictureBox.Size = normalSize;
                    pictureBox.Margin = normalMargin;
                    pictureBox.Refresh(); 
                };

                pictureBox.Paint += (sender, e) =>
                {
                    int coloredAreaHeight = (pictureBox.Height / 2) + 70;

                    for (int j = 0; j <= coloredAreaHeight; j++)
                    {
                        int alpha = (int)(200 * ((double)j / coloredAreaHeight));
                        Color color = pictureBox.ClientRectangle.Contains(pictureBox.PointToClient(Control.MousePosition)) ? Color.FromArgb(alpha, Color.Teal) : Color.FromArgb(alpha, Color.Black);
                        Rectangle rect = new Rectangle(0, pictureBox.Height - coloredAreaHeight + j, pictureBox.Width, 1);
                        using (SolidBrush brush = new SolidBrush(color))
                        {
                            e.Graphics.FillRectangle(brush, rect);
                        }
                    }

                    System.Drawing.Font font = new System.Drawing.Font("Arial", pictureBox.ClientRectangle.Contains(pictureBox.PointToClient(Control.MousePosition)) ? 35 : 23, FontStyle.Bold);
                    Color textColor = pictureBox.ClientRectangle.Contains(pictureBox.PointToClient(Control.MousePosition)) ? Color.White : Color.White;

                    using (Brush brush = new SolidBrush(textColor))
                    {
                        SizeF textSize = e.Graphics.MeasureString(name, font);
                        float titleX, titleY;
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
                        e.Graphics.DrawString(name, font, brush, titleLocation);

                        if (pictureBox.ClientRectangle.Contains(pictureBox.PointToClient(Control.MousePosition)))
                        {
                            font = new System.Drawing.Font("Arial", 14, FontStyle.Regular);
                            string details = $"{man} mins | Genres: {string.Join(", ", genres)} | Rating: {rating}";
                            SizeF detailsSize = e.Graphics.MeasureString(details, font);
                            float detailsX = (pictureBox.Width - detailsSize.Width) / 2;
                            float detailsY = titleY + textSize.Height + 10; // Adjust the vertical position
                            PointF detailsLocation = new PointF(detailsX, detailsY);
                            e.Graphics.DrawString(details, font, brush, detailsLocation);
                        }
                    }
                };
            
                pictureBox.Cursor = Cursors.Hand; // Change cursor to hand pointer
                pictureBox.MouseClick += (sender, e) => back_Click(sender, e);

                void back_Click(object sender, EventArgs e)
                {
                    string movieId = SqlInstance.GetMovieIdFromImagePathwide(posterPath);
                    string[] movieData = SqlInstance.GetMovieDataById(int.Parse(movieId));
                    panel4.Visible = false;
                    Video_class Vid = new Video_class(_form, movieData, int.Parse(movieId), id);
                }

                sidepanel.Controls.Add(pictureBox);

                x += pictureBoxWidth + horizontalSpacing;
            }

        }

        



        private void PopulateMovies()
        {
            List<(string, string, string)> movies = SqlInstance.GetMoviePosters();

            int pictureBoxWidth = 200;
            int pictureBoxHeight = 250;
            int labelHeight = 20;
            int durationLabelHeight = 15;
            int verticalSpacing = 10;

            foreach ((string name, string posterPath, string duration) in movies)
            {
                RoundedPictureBox pictureBox = new RoundedPictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Image = System.Drawing.Image.FromFile(posterPath);
                pictureBox.Size = new Size(pictureBoxWidth, pictureBoxHeight);
                pictureBox.CornerRadius = 9;
                pictureBox.MouseEnter += PictureBox_MouseEnter;
                pictureBox.MouseLeave += PictureBox_MouseLeave;
                pictureBox.Click += (sender, e) => PictureBox_Click(sender, e, name, duration, posterPath);

                Label titleLabel = new Label();
                titleLabel.Text = name;
                titleLabel.TextAlign = ContentAlignment.MiddleLeft;
                titleLabel.AutoSize = false;
                titleLabel.Size = new Size(pictureBoxWidth, labelHeight);

                Label durationLabel = new Label();
                durationLabel.Text = duration + " min        HD";
                durationLabel.TextAlign = ContentAlignment.MiddleLeft;
                durationLabel.AutoSize = false;
                durationLabel.Size = new Size(pictureBoxWidth, durationLabelHeight);

                titleLabel.Font = new System.Drawing.Font("Arial", 14, FontStyle.Bold);
                titleLabel.ForeColor = Color.White;
                durationLabel.Font = new System.Drawing.Font("Arial", 11, FontStyle.Bold);
                durationLabel.ForeColor = Color.Teal;

                FlowLayoutPanel moviePanel = new FlowLayoutPanel();
                moviePanel.FlowDirection = FlowDirection.TopDown;
                moviePanel.Size = new Size(pictureBoxWidth, pictureBoxHeight + labelHeight + durationLabelHeight + verticalSpacing * 2); // Set size
                moviePanel.Controls.Add(pictureBox);
                moviePanel.Controls.Add(titleLabel);
                moviePanel.Controls.Add(durationLabel);

                flowLayoutPanel1.Controls.Add(moviePanel);
            }


        }
        private void PopulateMovie(string type)
        {
            flowLayoutPanel1.Controls.Clear();
            List<(string, string, string)> movies = SqlInstance.GetMoviePostersByGenre(type);


            int pictureBoxWidth = 200;
            int pictureBoxHeight = 250;
            int labelHeight = 20;
            int durationLabelHeight = 15;
            int verticalSpacing = 10;

            foreach ((string name, string posterPath, string duration) in movies)
            {
                RoundedPictureBox pictureBox = new RoundedPictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Image = System.Drawing.Image.FromFile(posterPath);
                pictureBox.Size = new Size(pictureBoxWidth, pictureBoxHeight);
                pictureBox.CornerRadius = 9;
                pictureBox.MouseEnter += PictureBox_MouseEnter;
                pictureBox.MouseLeave += PictureBox_MouseLeave;
                pictureBox.Click += (sender, e) => PictureBox_Click(sender, e, name, duration, posterPath);

                Label titleLabel = new Label();
                titleLabel.Text = name;
                titleLabel.TextAlign = ContentAlignment.MiddleLeft;
                titleLabel.AutoSize = false;
                titleLabel.Size = new Size(pictureBoxWidth, labelHeight);
                titleLabel.Font = new System.Drawing.Font("Arial", 14, FontStyle.Bold);
                titleLabel.ForeColor = Color.White;

                Label durationLabel = new Label();
                durationLabel.Text = duration + "'";
                durationLabel.TextAlign = ContentAlignment.MiddleLeft;
                durationLabel.AutoSize = false;
                durationLabel.Size = new Size(pictureBoxWidth, durationLabelHeight);
                durationLabel.Font = new System.Drawing.Font("Arial", 11, FontStyle.Bold);
                durationLabel.ForeColor = Color.Teal;

                FlowLayoutPanel moviePanel = new FlowLayoutPanel();
                moviePanel.FlowDirection = FlowDirection.TopDown;
                moviePanel.Size = new Size(pictureBoxWidth, pictureBoxHeight + labelHeight + durationLabelHeight + verticalSpacing * 2);
                moviePanel.Controls.Add(pictureBox);
                moviePanel.Controls.Add(titleLabel);
                moviePanel.Controls.Add(durationLabel);

                flowLayoutPanel1.Controls.Add(moviePanel);
            }
        }

        private void PopulateMovie(string Genre, string Release_Date, string Duration, string Rating)
        {
            flowLayoutPanel1.Controls.Clear();
            List<(string, string, string, string)> movies = SqlInstance.FilterMovies(Genre, Release_Date, Duration, Rating); // this is super old need updating

            int pictureBoxWidth = 200;
            int pictureBoxHeight = 250;
            int labelHeight = 20;
            int durationLabelHeight = 15;
            int verticalSpacing = 10;

            foreach ((string name, string posterPath, string duration, string videoPath) in movies)
            {
                RoundedPictureBox pictureBox = new RoundedPictureBox();
                pictureBox.CornerRadius = 9;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Image = System.Drawing.Image.FromFile(posterPath);
                pictureBox.Size = new Size(pictureBoxWidth, pictureBoxHeight);
                pictureBox.MouseEnter += PictureBox_MouseEnter;
                pictureBox.MouseLeave += PictureBox_MouseLeave;
                pictureBox.Click += (sender, e) => PictureBox_Click(sender, e, name, duration, posterPath);

                Label titleLabel = new Label();
                titleLabel.Text = name;
                titleLabel.TextAlign = ContentAlignment.MiddleLeft;
                titleLabel.AutoSize = false;
                titleLabel.Size = new Size(pictureBoxWidth, labelHeight);
                titleLabel.Font = new System.Drawing.Font("Arial", 14, FontStyle.Bold);
                titleLabel.ForeColor = Color.White;

                Label durationLabel = new Label();
                durationLabel.Text = duration + "'";
                durationLabel.TextAlign = ContentAlignment.MiddleLeft;
                durationLabel.AutoSize = false;
                durationLabel.Size = new Size(pictureBoxWidth, durationLabelHeight);
                durationLabel.Font = new System.Drawing.Font("Arial", 11, FontStyle.Bold);
                durationLabel.ForeColor = Color.Teal;

                FlowLayoutPanel moviePanel = new FlowLayoutPanel();
                moviePanel.FlowDirection = FlowDirection.TopDown;
                moviePanel.Size = new Size(pictureBoxWidth, pictureBoxHeight + labelHeight + durationLabelHeight + verticalSpacing * 2);
                moviePanel.Controls.Add(pictureBox);
                moviePanel.Controls.Add(titleLabel);
                moviePanel.Controls.Add(durationLabel);

                flowLayoutPanel1.Controls.Add(moviePanel);
            }
        }


        public void PopulateMovie(string movie, int n)
        {
            flowLayoutPanel1.Controls.Clear();
            List<(string, string, string)> movies = SqlInstance.GetMoviePostersname(movie);

            int pictureBoxWidth = 200;
            int pictureBoxHeight = 250;
            int labelHeight = 20;
            int durationLabelHeight = 15;
            int verticalSpacing = 10;

            foreach ((string name, string posterPath, string duration) in movies)
            {
                RoundedPictureBox pictureBox = new RoundedPictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Image = System.Drawing.Image.FromFile(posterPath);
                pictureBox.Size = new Size(pictureBoxWidth, pictureBoxHeight);
                pictureBox.MouseEnter += PictureBox_MouseEnter;
                pictureBox.MouseLeave += PictureBox_MouseLeave;
                pictureBox.Click += (sender, e) => PictureBox_Click(sender, e, name, duration, posterPath);

                Label titleLabel = new Label();
                titleLabel.Text = name;
                titleLabel.TextAlign = ContentAlignment.MiddleLeft;
                titleLabel.AutoSize = false;
                titleLabel.Size = new Size(pictureBoxWidth, labelHeight);
                titleLabel.Font = new System.Drawing.Font("Arial", 14, FontStyle.Bold);
                titleLabel.ForeColor = Color.White;

                Label durationLabel = new Label();
                durationLabel.Text = duration + "'";
                durationLabel.TextAlign = ContentAlignment.MiddleLeft;
                durationLabel.AutoSize = false;
                durationLabel.Size = new Size(pictureBoxWidth, durationLabelHeight);
                durationLabel.Font = new System.Drawing.Font("Arial", 11, FontStyle.Bold);
                durationLabel.ForeColor = Color.Teal;

                FlowLayoutPanel moviePanel = new FlowLayoutPanel();
                moviePanel.FlowDirection = FlowDirection.TopDown;
                moviePanel.Size = new Size(pictureBoxWidth, pictureBoxHeight + labelHeight + durationLabelHeight + verticalSpacing * 2);
                moviePanel.Controls.Add(pictureBox);
                moviePanel.Controls.Add(titleLabel);
                moviePanel.Controls.Add(durationLabel);

                flowLayoutPanel1.Controls.Add(moviePanel);
            }
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.Cursor = Cursors.Hand;
            int coloredAreaHeight = (pictureBox.Height / 2) + 100;

            using (Graphics g = pictureBox.CreateGraphics())
            {
                for (int i = 0; i <= coloredAreaHeight; i++)
                {
                    int alpha = (int)(255 * ((double)i / coloredAreaHeight));

                    Color color = Color.FromArgb(alpha, Color.Teal);
                    Rectangle rect = new Rectangle(0, pictureBox.Height - coloredAreaHeight + i, pictureBox.Width, 1);

                    using (SolidBrush brush = new SolidBrush(color))
                    {
                        g.FillRectangle(brush, rect);
                    }
                }
            }

            int playButtonSize = 50; // Adjust size as needed
            int playButtonX = (pictureBox.Width - playButtonSize) / 2;
            int playButtonY = (pictureBox.Height - playButtonSize) / 2;

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
            pictureBox.Cursor = Cursors.Default;
            pictureBox.Invalidate();
        }

        private void bars_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.Cursor = Cursors.Hand;
        }

        private void bars_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.Cursor = Cursors.Default;
        }

        Button btn1 = new Button();
        Button btn2 = new Button();
        Button btn3 = new Button();
        Button btn4 = new Button();

        private void bars_click(object sender, EventArgs e)
        {
            // Create and configure the panel
            panel = new RoundedPanel();
            panel4.Controls.Add(panel);
            panel.BringToFront();
            panel.Location = new Point(37 + iconPictureBox3.Width - 8, 19);
            panel.Size = new Size(130, 190);
            panel.BackColor = Color.FromArgb(41, 172, 191);
            panel.EdgeColor = Color.FromArgb(41, 172, 191);

            btn1.Size = new Size(panel.Width - 40, 30);
            btn2.Size = new Size(panel.Width - 40, 30);
            btn3.Size = new Size(panel.Width - 40, 30);
            btn4.Size = new Size(panel.Width - 40, 30);

            btn1.Location = new Point(20, 20);
            btn2.Location = new Point(20, 60);
            btn3.Location = new Point(20, 100);
            btn4.Location = new Point(20, 140);

            btn1.BackColor = Color.FromArgb(41, 172, 191);
            btn2.BackColor = Color.FromArgb(41, 172, 191);
            btn3.BackColor = Color.FromArgb(41, 172, 191);
            btn4.BackColor = Color.FromArgb(41, 172, 191);

            btn1.ForeColor = Color.FromArgb(24, 24, 24);
            btn2.ForeColor = Color.FromArgb(24, 24, 24);
            btn3.ForeColor = Color.FromArgb(24, 24, 24);
            btn4.ForeColor = Color.FromArgb(24, 24, 24);

            btn1.FlatAppearance.BorderSize = 0;
            btn2.FlatAppearance.BorderSize = 0;
            btn3.FlatAppearance.BorderSize = 0;
            btn4.FlatAppearance.BorderSize = 0;
            btn1.FlatStyle = FlatStyle.Flat;
            btn2.FlatStyle = FlatStyle.Flat;
            btn3.FlatStyle = FlatStyle.Flat;
            btn4.FlatStyle = FlatStyle.Flat;

            btn1.Font = new System.Drawing.Font(btn1.Font.FontFamily, 15, FontStyle.Regular);
            btn2.Font = new System.Drawing.Font(btn2.Font.FontFamily, 15, FontStyle.Regular);
            btn3.Font = new System.Drawing.Font(btn3.Font.FontFamily, 15, FontStyle.Regular);
            btn4.Font = new System.Drawing.Font(btn3.Font.FontFamily, 15, FontStyle.Regular);
        
            // Set names for the buttons
            btn1.Text = "Profile";
            btn2.Text = "Lang";
            btn3.Text = "About";
            btn4.Text = "Back";

            panel.Controls.Add(btn1);
            panel.Controls.Add(btn2);
            panel.Controls.Add(btn3);
            panel.Controls.Add(btn4);

            // Attach mouse events to the panel
            panel.MouseEnter += Panel_MouseEnter;
            panel.MouseLeave += Panel_MouseLeave;

            btn1.MouseEnter += Button_MouseEnter;
            btn2.MouseEnter += Button_MouseEnter;
            btn3.MouseEnter += Button_MouseEnter;
            btn4.MouseEnter += Button_MouseEnter;

            btn1.MouseLeave += Button_MouseLeave;
            btn2.MouseLeave += Button_MouseLeave;
            btn3.MouseLeave += Button_MouseLeave;
            btn4.MouseLeave += Button_MouseLeave;

            btn4.Click += Button_Click;
    }


        private void Button_Click(object sender, EventArgs e)
        {
            panel.Visible = false;
        }
        
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.FromArgb(24, 24, 24);
            button.ForeColor = Color.White;
            panel.Cursor = Cursors.Hand;
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.FromArgb(41, 172, 191);
            button.ForeColor = Color.Black;
            panel.Cursor = Cursors.Default;
          
        }

        private void Panel_MouseEnter(object sender, EventArgs e)
        {
            panel.Cursor = Cursors.Hand;
        }

        private void Panel_MouseLeave(object sender, EventArgs e)
        {
            panel.Cursor = Cursors.Default;
        }
        private void PictureBox_Click(object sender, EventArgs e, string movieName, string movieDuration, string posterPath)
        {
            string movieId = SqlInstance.GetMovieIdFromImagePath(posterPath);
            string[] movieData = SqlInstance.GetMovieDataById(int.Parse(movieId));
            panel4.Visible = false;
            Video_class Vid = new Video_class(_form, movieData, int.Parse(movieId), id);
        }

        private List<string[]> topRatedMoviesData;
        private int currentMovieIndex;

        private void PopulateMostRatedMovies()
        {
            topRatedMoviesData = SqlInstance.GetTopRatedMoviesData();
            DisplayMovieAtIndex(0);
        }

        private void DisplayMovieAtIndex(int index)
        {
            Color majorityColor;
            widePictureBox.Controls.Clear();
            widePictureBox.Controls.Add(left);
            widePictureBox.Controls.Add(right);

            string[] movieData = topRatedMoviesData[index];
            string path = movieData[4];
            Panel contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Bottom;
            contentPanel.BackColor = Color.Transparent;
            contentPanel.Height = 350;
            contentPanel.Paint += (sender, e) =>
            {
                Rectangle rect = new Rectangle(0, 0, contentPanel.Width, contentPanel.Height);
                LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Transparent, Color.FromArgb(24, 24, 24), LinearGradientMode.Vertical);

                ColorBlend blend = new ColorBlend();
                blend.Positions = new[] { 0.0f, 0.3f, 0.7f, 1.0f };
                blend.Colors = new[] { Color.Transparent, Color.Transparent, Color.FromArgb(24, 24, 24), Color.FromArgb(24, 24, 24) };
                brush.InterpolationColors = blend;
                e.Graphics.FillRectangle(brush, rect);
            };

            PictureBox pictureBox = new PictureBox();
            pictureBox.Location = new Point(10, 85);
            pictureBox.Size = new Size(236, 82);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\stars.png");
            contentPanel.Controls.Add(pictureBox);

            Panel topFadingPanel = new Panel();
            topFadingPanel.Dock = DockStyle.Top;
            topFadingPanel.BackColor = Color.Transparent;
            topFadingPanel.Height = 150;

            widePictureBox.Controls.Add(topFadingPanel);
            string[] movieData1 = topRatedMoviesData[index];

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

            RoundedButton watchButton = new RoundedButton();
            watchButton.BackColor = Color.Teal;
            watchButton.BackgroundImageLayout = ImageLayout.None;
            watchButton.CornerRadius = 7;
            watchButton.Cursor = Cursors.Hand;
            watchButton.FlatAppearance.BorderSize = 0;
            watchButton.FlatStyle = FlatStyle.Flat;
            watchButton.Font = new System.Drawing.Font("Impact", 21F);
            watchButton.ForeColor = Color.Black;
            watchButton.Location = new Point(right.Left - 100, 220);
            watchButton.Size = new Size(160, 50);
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
            watchButton.Enter += (sender, e) =>
            {
                 PictureBox_Click(sender, e, "name", "duration", path);
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
            trailerButton.Location = new Point(watchButton.Left - 170, 220);
            trailerButton.Size = new Size(160, 50);
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
            trailerButton.Enter += (sender, e) =>
            {
                string url = movieData[3];
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                };
                Process.Start(psi);
            };

            contentPanel.Controls.Add(watchButton);
            contentPanel.Controls.Add(trailerButton);
            contentPanel.Controls.Add(this.title_label);
            contentPanel.Controls.Add(discription_label);
            widePictureBox.Controls.Add(contentPanel);

            string widePosterImagePath = movieData[5];
            System.Drawing.Image widePosterImage = System.Drawing.Image.FromFile(widePosterImagePath);

            widePictureBox.Image = widePosterImage;
            widePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            widePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            currentMovieIndex = index;

         

            Bitmap resizedImage = new Bitmap(widePictureBox.Image, new Size(100, 100));

            majorityColor = FindMajorityColor(resizedImage);
            topFadingPanel.Paint += (sender, e) =>
            {

                Rectangle rect = new Rectangle(0, 0, topFadingPanel.Width, topFadingPanel.Height);
                LinearGradientBrush brush = new LinearGradientBrush(rect, Color.FromArgb(24, 24, 24), Color.Transparent, LinearGradientMode.Vertical);
                ColorBlend blend = new ColorBlend();
                blend.Positions = new[] { 0.0f, 0.3f, 0.7f, 1.0f };
                blend.Colors = new[] { majorityColor, majorityColor, Color.Transparent, Color.Transparent };
                brush.InterpolationColors = blend;
                e.Graphics.FillRectangle(brush, rect);
            };

            panel1.BackColor = majorityColor;
        }

        // ///////////////////// //////////////////////////////////////////
        // ///////////////////// //////////////////////////////////////////





        private Color FindMajorityColor(Bitmap image)
        {
              int totalRed = 0, totalGreen = 0, totalBlue = 0;
            int pixelCount = 0;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    totalRed += pixelColor.R;
                    totalGreen += pixelColor.G;
                    totalBlue += pixelColor.B;
                    pixelCount++;
                }
            }

            // Calculate average color
            int avgRed = totalRed / pixelCount;
            int avgGreen = totalGreen / pixelCount;
            int avgBlue = totalBlue / pixelCount;

            return Color.FromArgb(avgRed, avgGreen, avgBlue);
        }






        // ///////////////////// //////////////////////////////////////////
        // ///////////////////// //////////////////////////////////////////






        private async void AnimateButtonColor(RoundedButton button, Color targetColor)
        {
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
            hoveredLabel.Left += 30;
            hoveredLabel.Font = new System.Drawing.Font("Segoe UI", 25);
            hoveredLabel.ForeColor = Color.Teal;
        }

        private void GenreLabel_MouseLeave(object sender, EventArgs e)
        {
            Label hoveredLabel = sender as Label;
            hoveredLabel.Left -= 30;
            hoveredLabel.Font = new System.Drawing.Font("Segoe UI", 20);
            hoveredLabel.ForeColor = Color.Gray;
        }

        private void GenreLabel_Click(object sender, EventArgs e, Label label) { 
        
                PopulateMovie(label.Text.ToLower());
        }
        private void exit_Click(object sender, EventArgs e)
        {
            _form.Controls.Clear();
            FullScreenForm form = new FullScreenForm();
            form.Show();
            _form.Visible = false;
        }

        private void TextBox1_GotFocus(object sender, EventArgs e)
        {
            roundedPanel1.EdgeColor = Color.Teal;
            roundedPanel1.Invalidate();
            roundedPanel1.Update();

            if (textBox1.Text == "Search movies...")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.White;
            }
        }

        public string str = "none";

        public void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            suggestionPanel.Visible = false;
            if (e.KeyCode == Keys.Enter)
            {
                string searchText;

                 if(str == "none")
                  {
                       searchText = textBox1.Text;

                  }
                  else
                  {
                      searchText = str;

                  }

                filter_Click(sender, e);
                PerformSearch(searchText);
            }
        }

         private void PerformSearch(string searchText)
          {
            PopulateMovie(searchText, 1); 
          }


        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 3)
            {
                List<(string title, string posterPath)> suggestions = GetMovieSuggestions(textBox1.Text);
                DisplaySuggestions(suggestions);
            }
            else
            {
                suggestionPanel.Visible = false; 
            }
        }

        private List<(string title, string posterPath)> GetMovieSuggestions(string searchText)
        {
            return SqlInstance.GetMovieTitlesAndImagesByTitle(searchText);
        }

        private void DisplaySuggestions(List<(string title, string posterPath)> suggestions)
        {
            suggestionPanel.Controls.Clear();
            int suggestionCount = suggestions.Count;

            if (suggestionCount > 0)
            {
                int panelWidth = roundedPanel1.Width;
                int panelHeight = Math.Min(200, suggestionCount * 60); 
                suggestionPanel.Size = new Size(panelWidth, panelHeight);
                suggestionPanel.Location = new Point(roundedPanel1.Left, roundedPanel1.Bottom + 5); 
                suggestionPanel.Visible = true;

                for (int i = 0; i < suggestionCount; i++)
                {
                    (string title, string posterPath) = suggestions[i];

                    PictureBox pictureBox = new PictureBox();
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Image = System.Drawing.Image.FromFile(posterPath);
                    pictureBox.Size = new Size(50, 50);
                    pictureBox.Location = new Point(10, i * 50 + 10);

                    Label titleLabel = new Label();
                    titleLabel.Text = title;
                    titleLabel.Font = new System.Drawing.Font("Segoe UI", 18F);
                    titleLabel.ForeColor = Color.White;
                    titleLabel.Location = new Point(60, i * 50 + 13);
                    titleLabel.AutoSize = true;

                    suggestionPanel.Controls.Add(pictureBox);
                    suggestionPanel.Controls.Add(titleLabel);

                    pictureBox.Click += (sender, e) => PerformSearch(title);
                    titleLabel.Click += (sender, e) => PerformSearch(title);
                }
            }
            else
            {
                suggestionPanel.Visible = false;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////filter//////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////

        public void filter_Click(object sender, EventArgs e)
        {
            PictureBox iconPicture2 = new PictureBox();
            panel4.Controls.Add(iconPicture2);

            panel1.BackColor = Color.Black;
            panel1.Height += 20;
            widePictureBox.Visible = false;
            sidepanel.Visible = false;
            label7.Visible = false;
            redPanel.Visible = false;
            iconPictureBox4.Visible = false;
            iconPictureBox2.Visible = false;
            label6.Visible = false;
            flowLayoutPanel1.Location = new Point(97, 400);
            label3.Location = new Point(115, 325);
            iconPictureBox.Location = new Point(90, 327);

            RoundedComboBox genreComboBox = new RoundedComboBox();
            RoundedComboBox releaseDateComboBox = new RoundedComboBox();
            RoundedComboBox durationComboBox = new RoundedComboBox();
            RoundedComboBox ratingComboBox = new RoundedComboBox();
            RadioButton filterButton = new RadioButton();
            RadioButton clearButton = new RadioButton();
            RadioButton backButton = new RadioButton();

            genreComboBox.Width = 150;
            releaseDateComboBox.Width = 150;
            durationComboBox.Width = 150;
            ratingComboBox.Width = 150;
            filterButton.Width = 67;
            clearButton.Width = 100;
            backButton.Width = 100;

            System.Drawing.Font font = new System.Drawing.Font("Segoe UI", 18F);
            genreComboBox.Font = font;
            releaseDateComboBox.Font = font;
            durationComboBox.Font = font;
            ratingComboBox.Font = font;

            genreComboBox.Location = new Point(90, 89);
            releaseDateComboBox.Location = new Point(290, 89);
            durationComboBox.Location = new Point(490, 89);
            ratingComboBox.Location = new Point(690, 89);
            filterButton.Location = new Point(890, 100);
            clearButton.Location = new Point(958, 100);
            backButton.Location = new Point(1240, 100);

            PictureBox iconPicture = new PictureBox();
            iconPicture.SizeMode = PictureBoxSizeMode.Zoom;
            iconPicture.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\filter.png");
            iconPicture.Name = "wide_panel";
            iconPicture.Size = new Size(1900, 189);
            iconPicture.Location = new Point(0, 120);
            iconPicture.TabIndex = 13;

            iconPicture2.SizeMode = PictureBoxSizeMode.Zoom;
            iconPicture2.Image = System.Drawing.Image.FromFile("C:\\Users\\enkud\\Desktop\\Cinema\\back_image\\payment.png");
            iconPicture2.Name = "wide_panel";
            iconPicture2.Size = new Size(480, 854);
            iconPicture2.Location = new Point(1375, 160);
            iconPicture2.TabIndex = 13;
            iconPicture2.BringToFront();

            iconPicture.Controls.Add(genreComboBox);
            iconPicture.Controls.Add(releaseDateComboBox);
            iconPicture.Controls.Add(durationComboBox);
            iconPicture.Controls.Add(ratingComboBox);
            iconPicture.Controls.Add(filterButton);
            iconPicture.Controls.Add(clearButton);
            iconPicture.Controls.Add(backButton);
            panel4.Controls.Add(iconPicture);

            filterButton.BackgroundImageLayout = ImageLayout.None;
            filterButton.Cursor = Cursors.Hand;
            filterButton.FlatAppearance.BorderSize = 0;
            filterButton.FlatStyle = FlatStyle.Flat;
            filterButton.Font = new System.Drawing.Font("Segoe UI", 11F);
            filterButton.ForeColor = Color.White;
            filterButton.Name = "Filter";
            filterButton.TabIndex = 6;
            filterButton.Text = "filter";
            filterButton.UseVisualStyleBackColor = false;
            
            clearButton.BackgroundImageLayout = ImageLayout.None;
            clearButton.Cursor = Cursors.Hand;
            clearButton.FlatAppearance.BorderSize = 0;
            clearButton.FlatStyle = FlatStyle.Flat;
            clearButton.Font = new System.Drawing.Font("Segoe UI", 11F);
            clearButton.ForeColor = Color.White;
            clearButton.Name = "Clear";
            clearButton.TabIndex = 6;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = false;

            backButton.BackgroundImageLayout = ImageLayout.None;
            backButton.Cursor = Cursors.Hand;
            backButton.FlatAppearance.BorderSize = 0;
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.Font = new System.Drawing.Font("Segoe UI", 11F);
            backButton.ForeColor = Color.White;
            backButton.Name = "Back";
            backButton.TabIndex = 6;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = false;

            filterButton.BackColor = Color.Transparent;
            clearButton.BackColor = Color.Transparent;
            backButton.BackColor = Color.Transparent;
            filterButton.MouseClick += (sender, e) => filters_Click(sender, e);
            clearButton.MouseClick += (sender, e) => Clear_Click(sender, e);
            backButton.MouseClick += (sender, e) => back_Click(sender, e);
           
            PopulateGenreComboBox(genreComboBox);
            PopulateReleaseDateComboBox(releaseDateComboBox);
            PopulateDurationComboBox(durationComboBox);
            PopulateRatingComboBox(ratingComboBox);

            void filters_Click(object sender, EventArgs e)
            {
                string selectedGenre = genreComboBox.SelectedItem?.ToString();
                string selectedReleaseDate = releaseDateComboBox.SelectedItem?.ToString();
                string selectedDuration = durationComboBox.SelectedItem?.ToString();
                string selectedRating = ratingComboBox.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(selectedGenre) && string.IsNullOrEmpty(selectedReleaseDate) &&
                    string.IsNullOrEmpty(selectedDuration) && string.IsNullOrEmpty(selectedRating))
                {
                    MessageBox.Show("Please select at least one filter.", "No Filters Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                    PopulateMovie(selectedGenre, selectedReleaseDate, selectedDuration, selectedRating);
            }

            void Clear_Click(object sender, EventArgs e)
            {
                genreComboBox.SelectedItem = null;
                releaseDateComboBox.SelectedItem = null;
                durationComboBox.SelectedItem = null;
                ratingComboBox.SelectedItem = null;
            }

            void back_Click(object sender, EventArgs e)
            {
                panel4.Visible = false;
                Home home = new Home(_form, id);
            }
        }

        private void PopulateGenreComboBox(ComboBox comboBox)
        {
            List<string> genres = SqlInstance.GetGenres(); 
            comboBox.Items.AddRange(genres.ToArray());
        }

          private void PopulateReleaseDateComboBox(ComboBox comboBox)
        {
            List<string> releaseDates = SqlInstance.GetReleaseDates(); 
            comboBox.Items.AddRange(releaseDates.ToArray());
        }

        private void PopulateDurationComboBox(ComboBox comboBox)
        {
            comboBox.Items.Add("90 minutes");
            comboBox.Items.Add("100 minutes");
            comboBox.Items.Add("113 minutes");
            comboBox.Items.Add("125 minutes");
            comboBox.Items.Add("225 minutes");
        }
      
        private void PopulateRatingComboBox(ComboBox comboBox)
        {
            comboBox.Items.Add("5 stars");
            comboBox.Items.Add("4 stars");
            comboBox.Items.Add("3 stars");
            comboBox.Items.Add("2 stars");
            comboBox.Items.Add("1 star");
        }


    }
}
