using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using WinFormsApp;
using WinFormsApp1;
using WMPLib;

namespace FullScreenApp
{
    public class FullScreenForm : Form
    {
        public event EventHandler LoginButtonClicked;
        private RoundedPanel panel;
        private RoundedPanel panel_movie;
        private RoundedPanel panel_genre;
        private RoundedPanel textboxPanel;
        private RoundedPanel signUpPanel;
        private RoundedPanel loginPanel1;
        private RoundedPanel loginPanel2;
        private RoundedPanel signUpPanel1;
        private RoundedPanel signUpPanel2;
        private RoundedPanel signUpPanel3;
        private RoundedPanel signUpPanel4;
        private TextBox loginUserTextBox;
        private TextBox loginPasswordTextBox;
        private TextBox signUpNameTextBox;
        private TextBox signUpUserTextBox;
        private TextBox signUpEmailTextBox;
        private TextBox signUpPasswordTextBox;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private RoundedButton loginButton;
        private RoundedButton signUpButton;
        private RoundedButton delete;
        private RoundedButton EXIT;
        private RoundedButton aMovie;
        private RoundedButton aGenre;
        private Button loginShowPasswordButton;
        private Button signUpShowPasswordButton;
        private readonly Sql SqlInstance = new Sql();
        TextBox TextBox1 = new TextBox();

        private bool isLoginPasswordVisible = false;
        private bool isSignUpPasswordVisible = false;

        public FullScreenForm()
        {
            InitializeForm();
            InitializeLoginPanel();
        }

        private void InitializeForm()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            string imagePath = @"C:\Users\enkud\Desktop\Cinema\back_image\login_img.png";

            if (File.Exists(imagePath))
            {
                this.BackgroundImage = Image.FromFile(imagePath);
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                MessageBox.Show("Image not found at the specified path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeLoginPanel()
        {
            panel = CreateRoundedPanel1(new Point(1172, 276), new Size(522, 526));
            panel_movie = CreateRoundedPanel(new Point(51, 214), new Size(542, 734));
            panel_genre = CreateRoundedPanel(new Point(632, 214), new Size(403, 734));
            textboxPanel = CreateRoundedPanel(new Point(1134, 346), new Size(464, 57));
            AddLoginControls(panel);
            panel_genre.Visible = false;
            textboxPanel.Visible = false;
            delete = new RoundedButton();
            delete.Visible = false;
            EXIT = new RoundedButton();
            EXIT.Visible = false;
            aMovie = new RoundedButton();
            aMovie.Visible = false;
            aGenre = new RoundedButton();
            aGenre.Visible = false;
            panel_movie.EdgeColor = Color.Teal;
            panel_genre.EdgeColor = Color.Teal;
            textboxPanel.EdgeColor = Color.Teal;
            panel_movie.Visible = false;
            this.Controls.Add(panel);
            this.Controls.Add(panel_movie);
            this.Controls.Add(panel_genre);
            this.Controls.Add(textboxPanel);
            this.Controls.Add(delete);
            this.Controls.Add(EXIT);
            this.Controls.Add(aGenre);
            this.Controls.Add(aMovie);
        }

        private RoundedPanel CreateRoundedPanel(Point location, Size size)
        {
            RoundedPanel roundedPanel = new RoundedPanel
            {
                BackColor = Color.FromArgb(24, 24, 24),
                Location = location,
                Size = size,
                CornerRadius = 20,
                EdgeColor = Color.FromArgb(41, 41, 41)
            };
            return roundedPanel;
        }

        private RoundedPanel CreateRoundedPanel1(Point location, Size size)
        {
            RoundedPanel roundedPanel = new RoundedPanel
            {
                BackColor = Color.FromArgb(24, 24, 24),
                Location = location,
                Size = size,
                CornerRadius = 20,
                EdgeColor = Color.Teal
            };
            return roundedPanel;
        }

        private RoundedPanel CreatePanel(Point location, Size size)
        {
            RoundedPanel Panel = new RoundedPanel
            {
                BackColor = Color.FromArgb(41, 41, 41),
                Location = location,
                Size = size,
                CornerRadius = 10,
                EdgeColor = Color.FromArgb(41, 41, 41)
            };
            return Panel;
        }

        private void AddLoginControls(RoundedPanel panel)
        {
            Label welcomeLabel = CreateLabel("Welcome back!", new Point(33, 27), 27, FontStyle.Bold);
            panel.Controls.Add(welcomeLabel);

            Label accountLabel = CreateLabel("Account", new Point(39, 92), 12);
            panel.Controls.Add(accountLabel);

            Label passwordLabel = CreateLabel("Password", new Point(39, 220), 12);
            panel.Controls.Add(passwordLabel);

            loginPanel1 = CreatePanel(new Point(39, 124), new Size(452, 61));
            panel.Controls.Add(loginPanel1);

            loginUserTextBox = CreateTextBox(new Point(10, 10), new Size(412, 41));
            loginPanel1.Controls.Add(loginUserTextBox);
            loginUserTextBox.GotFocus += (sender, e) => ChangePanelEdgeColor(loginPanel1, true);
            loginUserTextBox.LostFocus += (sender, e) => ChangePanelEdgeColor(loginPanel1, false);
            loginUserTextBox.KeyDown += LoginUserTextBox_KeyDown;

            loginPanel2 = CreatePanel(new Point(39, 253), new Size(452, 61));
            panel.Controls.Add(loginPanel2);

            loginPasswordTextBox = CreatePasswordTextBox(new Point(10, 10), new Size(372, 41));
            loginPanel2.Controls.Add(loginPasswordTextBox);
            loginPasswordTextBox.GotFocus += (sender, e) => ChangePanelEdgeColor(loginPanel2, true);
            loginPasswordTextBox.LostFocus += (sender, e) => ChangePanelEdgeColor(loginPanel2, false);
            loginPasswordTextBox.KeyDown += LoginPasswordTextBox_KeyDown;

            loginShowPasswordButton = CreateShowPasswordButton(new Point(394, 10));
            loginPanel2.Controls.Add(loginShowPasswordButton);
            loginShowPasswordButton.Click += (sender, e) => TogglePasswordVisibility(loginPasswordTextBox, ref isLoginPasswordVisible, loginShowPasswordButton);

            loginButton = CreateLoginButton(new Point(39, 364), new Size(452, 61));
            panel.Controls.Add(loginButton);

            AddLinks(panel, loginButton.Bottom + 10);

            loginButton.Click += LoginButton_Click;
        }

        private void ChangePanelEdgeColor(RoundedPanel panel, bool isFocused)
        {
            panel.EdgeColor = isFocused ? Color.Teal : Color.FromArgb(41, 41, 41);
            panel.Invalidate();
        }

        private void SetPanelEdgeColor(RoundedPanel panel, Color color)
        {
            panel.EdgeColor = color;
            panel.Invalidate();
        }

        private Label CreateLabel(string text, Point location, int fontSize, FontStyle fontStyle = FontStyle.Regular)
        {
            Label label = new Label
            {
                Text = text,
                ForeColor = Color.White,
                Font = new Font(FontFamily.GenericSansSerif, fontSize, fontStyle),
                AutoSize = true,
                Location = location
            };
            return label;
        }

        private TextBox CreateTextBox(Point location, Size size)
        {
            TextBox textBox = new TextBox
            {
                Location = location,
                Size = size,
                BackColor = Color.FromArgb(41, 41, 41),
                BorderStyle = BorderStyle.None,
                ForeColor = Color.White,
                Font = new Font(FontFamily.GenericSansSerif, 21)
            };
            return textBox;
        }

        private TextBox CreatePasswordTextBox(Point location, Size size)
        {
            TextBox textBox = CreateTextBox(location, size);
            textBox.PasswordChar = '*';
            return textBox;
        }

        private Button CreateShowPasswordButton(Point location)
        {
            Button button = new Button
            {
                Size = new Size(40, 40),
                Location = location,
                FlatStyle = FlatStyle.Flat,
                BackgroundImageLayout = ImageLayout.Stretch,
                BackgroundImage = Image.FromFile(@"C:\Users\enkud\Desktop\Cinema\back_image\see_pass.png"), // Provide the path to the initial image
                BackColor = Color.FromArgb(41, 41, 41),
                FlatAppearance = { BorderSize = 0 }
            };
            return button;
        }

        private void TogglePasswordVisibility(TextBox passwordTextBox, ref bool isPasswordVisible, Button button)
        {
            if (isPasswordVisible)
            {
                passwordTextBox.PasswordChar = '*';
                button.BackgroundImage = Image.FromFile(@"C:\Users\enkud\Desktop\Cinema\back_image\see_pass.png"); // Provide the path to the "show" image
            }
            else
            {
                passwordTextBox.PasswordChar = '\0';
                button.BackgroundImage = Image.FromFile(@"C:\Users\enkud\Desktop\Cinema\back_image\see_h.png"); // Provide the path to the "hide" image
            }
            isPasswordVisible = !isPasswordVisible;
        }

        private RoundedButton CreateLoginButton(Point location, Size size)
        {
            RoundedButton button = new RoundedButton
            {
                Text = "Sign in",
                Font = new Font(FontFamily.GenericSansSerif, 17),
                Location = location,
                Size = size,
                BackColor = Color.FromArgb(41, 172, 191),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Black
            };
            return button;
        }

        private RoundedButton CreateSignUpButton(Point location, Size size)
        {
            RoundedButton button = new RoundedButton
            {
                Text = "Sign up",
                Font = new Font(FontFamily.GenericSansSerif, 17),
                Location = location,
                Size = size,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(41, 172, 191),
                ForeColor = Color.Black
            };
            return button;
        }

        private LinkLabel CreateLinkLabel(string text, Point location)
        {
            LinkLabel linkLabel = new LinkLabel
            {
                Text = text,
                LinkColor = Color.FromArgb(41, 172, 191),
                Font = new Font(FontFamily.GenericSansSerif, 10),
                AutoSize = true,
                Location = location
            };
            return linkLabel;
        }

        private void AddLinks(RoundedPanel panel, int buttonBottom)
        {
            LinkLabel forgotPasswordLabel = CreateLinkLabel("Forgot password.", new Point(39, buttonBottom));
            panel.Controls.Add(forgotPasswordLabel);

            forgotPasswordLabel.LinkClicked += (sender, e) =>
            {
                ForgotPassword();
            };

            LinkLabel signUpLinkLabel = CreateLinkLabel("Sign up for a new account.", new Point(39, buttonBottom + forgotPasswordLabel.Height + 5));
            panel.Controls.Add(signUpLinkLabel);
            signUpLinkLabel.LinkClicked += (sender, e) =>
            {
                ClearLoginFields();
                panel.Visible = false;
                InitializeSignUpPanel();
            };

            LinkLabel loginAsAdminLabel = CreateLinkLabel("Login as an Admin", new Point(370, buttonBottom));
            LinkLabel ExitLink = CreateLinkLabel("Exit", new Point(370, loginAsAdminLabel.Bottom + 5));
            panel.Controls.Add(loginAsAdminLabel);
            panel.Controls.Add(ExitLink);

            void ForgotPassword()
            {
                string username = Microsoft.VisualBasic.Interaction.InputBox("Enter your username:", "Forgot Password", "");
                if (string.IsNullOrEmpty(username))
                {
                    MessageBox.Show("Please enter your username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var (exists, email) = SqlInstance.CheckUserExists(username);
                if (!exists)
                {
                    MessageBox.Show("Username not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Email emailSender = new Email(email, username);
                int code = emailSender.Code;

                string enteredCode = Microsoft.VisualBasic.Interaction.InputBox("Enter the verification code sent to your email:", "Verification Code", "");
                if (enteredCode != code.ToString())
                {
                    MessageBox.Show("Invalid verification code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string newPassword = Microsoft.VisualBasic.Interaction.InputBox("Enter your new password:", "Reset Password", "");
                if (string.IsNullOrEmpty(newPassword))
                {
                    MessageBox.Show("Please enter a new password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool passwordChanged = SqlInstance.ChangePassword(username, newPassword);
                if (passwordChanged)
                {
                    MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to change password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            loginAsAdminLabel.LinkClicked += (sender, e) =>
            {
                panel.Visible = false;
                panel_genre.Visible = true;
                panel_movie.Visible = true;
                textboxPanel.Visible = true;

                Label m = CreateLabel("All movies", new Point(65, 166), 30, FontStyle.Bold);
                Label g = CreateLabel("All Genres", new Point(645, 166), 30, FontStyle.Bold);
                Label u = CreateLabel("Utility", new Point(1134, 286), 30, FontStyle.Bold);
                m.BackColor = Color.Transparent;
                g.BackColor = Color.Transparent;
                u.BackColor = Color.Transparent;
                this.Controls.Add(m);
                this.Controls.Add(g);
                this.Controls.Add(u);


                delete.Location = new Point(1615, 346);
                delete.Size = new Size(195, 57);
                delete.Text = "Delete Movie";
                delete.BackColor = Color.Teal;
                delete.ForeColor = Color.White;
                delete.Visible = true;
                delete.FlatStyle = FlatStyle.Flat;
                delete.Font = new Font(delete.Font.FontFamily, delete.Font.Size + 7); // Increase font size
                delete.FlatAppearance.BorderColor = Color.Teal; // Set border color to match background
                delete.FlatAppearance.BorderSize = 0; // Remove border
                delete.Click += Delete_Click;

                TextBox1.Size = new Size(448, 41); // Corrected size
                TextBox1.Location = new Point(7, 7);
                TextBox1.BackColor = Color.FromArgb(24, 24, 24);
                TextBox1.BorderStyle = BorderStyle.None;
                TextBox1.ForeColor = Color.White;
                TextBox1.Font = new Font(FontFamily.GenericSansSerif, 21);
                textboxPanel.Controls.Add(TextBox1);

                aMovie.Location = new Point(1134, 431);
                aMovie.Size = new Size(339, 56);
                aMovie.Text = "Add Movie";
                aMovie.BackColor = Color.Teal;
                aMovie.ForeColor = Color.White;
                aMovie.Visible = true;
                aMovie.FlatStyle = FlatStyle.Flat;
                aMovie.Font = new Font(aMovie.Font.FontFamily, aMovie.Font.Size + 7); // Increase font size
                aMovie.FlatAppearance.BorderColor = Color.Teal; // Set border color to match background
                aMovie.FlatAppearance.BorderSize = 0; // Remove border
                aMovie.Click += AddMovie_Click;

                aGenre.Location = new Point(1488, 431);
                aGenre.Size = new Size(339, 56);
                aGenre.Text = "Add Genre";
                aGenre.BackColor = Color.Teal;
                aGenre.ForeColor = Color.White;
                aGenre.Visible = true;
                aGenre.FlatStyle = FlatStyle.Flat;
                aGenre.Font = new Font(aGenre.Font.FontFamily, aGenre.Font.Size + 7); // Increase font size
                aGenre.FlatAppearance.BorderColor = Color.Teal; // Set border color to match background
                aGenre.FlatAppearance.BorderSize = 0; // Remove border
                aGenre.Click += AddGenre_Click;

                EXIT.Location = new Point(1134, 515);
                EXIT.Size = new Size(676, 56);
                EXIT.Text = "EXIT";
                EXIT.BackColor = Color.Teal;
                EXIT.ForeColor = Color.White;
                EXIT.Visible = true;
                EXIT.FlatStyle = FlatStyle.Flat;
                EXIT.Font = new Font(EXIT.Font.FontFamily, EXIT.Font.Size + 7); // Increase font size
                EXIT.FlatAppearance.BorderColor = Color.Teal; // Set border color to match background
                EXIT.FlatAppearance.BorderSize = 0; // Remove border
                EXIT.Click += Exit_Click;

                DisplayMoviesInPanel();
                DisplayGenresInPanel();
            };



            ExitLink.LinkClicked += (sender, e) =>
            {
                Application.Exit();
            };
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string movieTitle = TextBox1.Text.Trim();
            if (!string.IsNullOrEmpty(movieTitle))
            {
                bool deleted = SqlInstance.DeleteMovie(movieTitle);
                if (deleted)
                {
                    MessageBox.Show("Movie deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayMoviesInPanel(); // Refresh the movie display panel
                }
                else
                {
                    MessageBox.Show("Failed to delete movie. Make sure the movie title is correct.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a movie title.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AddMovie_Click(object sender, EventArgs e)
        {
            string movieTitle = Microsoft.VisualBasic.Interaction.InputBox("Enter movie title:", "Add Movie", "");
            if (!string.IsNullOrEmpty(movieTitle))
            {
                // Collect other movie details
                string releaseDateInput = Microsoft.VisualBasic.Interaction.InputBox("Enter release date (yyyy-mm-dd):", "Add Movie", "");
                DateTime releaseDate;
                if (!DateTime.TryParse(releaseDateInput, out releaseDate))
                {
                    MessageBox.Show("Invalid release date format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string durationInput = Microsoft.VisualBasic.Interaction.InputBox("Enter duration (in minutes):", "Add Movie", "");
                int duration;
                if (!int.TryParse(durationInput, out duration))
                {
                    MessageBox.Show("Invalid duration format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string description = Microsoft.VisualBasic.Interaction.InputBox("Enter description:", "Add Movie", "");
                string trailerURL = Microsoft.VisualBasic.Interaction.InputBox("Enter trailer URL:", "Add Movie", "");
                string posterImage = Microsoft.VisualBasic.Interaction.InputBox("Enter poster image path:", "Add Movie", "");
                string widePosterImage = Microsoft.VisualBasic.Interaction.InputBox("Enter wide poster image path:", "Add Movie", "");
                string averageRatingInput = Microsoft.VisualBasic.Interaction.InputBox("Enter average rating (0-10):", "Add Movie", "");
                int averageRating;
                if (!int.TryParse(averageRatingInput, out averageRating))
                {
                    MessageBox.Show("Invalid average rating format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string video = Microsoft.VisualBasic.Interaction.InputBox("Enter video path:", "Add Movie", "");

                // Call AddMovie method
                bool added = SqlInstance.AddMovie(movieTitle, releaseDate, duration, description, trailerURL, posterImage, widePosterImage, averageRating, video);
                if (added)
                {
                    MessageBox.Show("Movie added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayMoviesInPanel();
                }
                else
                {
                    MessageBox.Show("Failed to add movie. Make sure all details are correct.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void AddGenre_Click(object sender, EventArgs e)
        {
            string genreName = Microsoft.VisualBasic.Interaction.InputBox("Enter genre name:", "Add Genre", "");
            if (!string.IsNullOrEmpty(genreName))
            {
                bool added = SqlInstance.AddGenre(genreName);
                if (added)
                {
                    MessageBox.Show("Genre added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayGenresInPanel();
                }
                else
                {
                    MessageBox.Show("Failed to add genre. Make sure the genre name is correct.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DisplayMoviesInPanel()
        {
            List<string> movieNames = SqlInstance.GetAllMovieNames();
            DataGridView movieGridView = new DataGridView
            {
                DataSource = new BindingSource { DataSource = movieNames.Select(m => new { Movie = m }).ToList() },
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.FromArgb(24, 24, 24),
                ForeColor = Color.White,
                GridColor = Color.FromArgb(41, 41, 41),
                ColumnHeadersVisible = false, // Hide column headers
                RowHeadersVisible = false, // Hide row headers (index column)
                RowTemplate = { Height = 50 }, // Set row height
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(24, 24, 24),
                    ForeColor = Color.White,
                    SelectionBackColor = Color.Gray,
                    SelectionForeColor = Color.White,
                    Font = new Font("Segoe UI", 18) // Increase font size
                },
                CellBorderStyle = DataGridViewCellBorderStyle.Single
            };
            movieGridView.EnableHeadersVisualStyles = false;
            panel_movie.Controls.Clear();
            panel_movie.Controls.Add(movieGridView);
        }

        private void DisplayGenresInPanel()
        {
            List<string> genres = SqlInstance.GetAllGenres();
            DataGridView genreGridView = new DataGridView
            {
                DataSource = new BindingSource { DataSource = genres.Select(g => new { Genre = g }).ToList() },
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.FromArgb(24, 24, 24),
                ForeColor = Color.White,
                GridColor = Color.FromArgb(41, 41, 41),
                ColumnHeadersVisible = false, // Hide column headers
                RowHeadersVisible = false, // Hide row headers (index column)
                RowTemplate = { Height = 50 }, // Set row height
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(24, 24, 24),
                    ForeColor = Color.White,
                    SelectionBackColor = Color.Gray,
                    SelectionForeColor = Color.White,
                    Font = new Font("Segoe UI", 18) // Increase font size
                },
                CellBorderStyle = DataGridViewCellBorderStyle.Single
            };
            genreGridView.EnableHeadersVisualStyles = false;
            panel_genre.Controls.Clear();
            panel_genre.Controls.Add(genreGridView);
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



        private void InitializeSignUpPanel()
        {
            signUpPanel = CreateRoundedPanel1(new Point(1172, 276), new Size(522, 700));
            AddSignUpControls(signUpPanel);
            this.Controls.Add(signUpPanel);

            LinkLabel signInLabel = CreateLinkLabel("Sign in", new Point(39, 637));
            signUpPanel.Controls.Add(signInLabel);
            signInLabel.LinkClicked += (sender, e) =>
            {
                ClearSignUpFields();
                signUpPanel.Visible = false;
                panel.Visible = true;
            };
        }

        private void AddSignUpControls(RoundedPanel panel)
        {
            Label signUpLabel = CreateLabel("Account Sign Up", new Point(33, 27), 27, FontStyle.Bold);
            panel.Controls.Add(signUpLabel);

            Label nameLabel = CreateLabel("Full Name", new Point(39, 92), 12);
            panel.Controls.Add(nameLabel);

            Label emailLabel = CreateLabel("Email", new Point(39, 220), 12);
            panel.Controls.Add(emailLabel);

            Label passwordLabel = CreateLabel("Password", new Point(39, 327), 12);
            panel.Controls.Add(passwordLabel);

            Label userLabel = CreateLabel("Username", new Point(39, 442), 12);
            panel.Controls.Add(userLabel);

            signUpPanel1 = CreatePanel(new Point(39, 124), new Size(452, 61));
            panel.Controls.Add(signUpPanel1);

            signUpNameTextBox = CreateTextBox(new Point(10, 10), new Size(412, 41));
            signUpPanel1.Controls.Add(signUpNameTextBox);
            signUpNameTextBox.GotFocus += (sender, e) => ChangePanelEdgeColor(signUpPanel1, true);
            signUpNameTextBox.LostFocus += (sender, e) => ChangePanelEdgeColor(signUpPanel1, false);
            signUpNameTextBox.KeyDown += SignUpNameTextBox_KeyDown;

            signUpPanel2 = CreatePanel(new Point(39, 249), new Size(452, 61));
            panel.Controls.Add(signUpPanel2);

            signUpEmailTextBox = CreateTextBox(new Point(10, 10), new Size(412, 41));
            signUpPanel2.Controls.Add(signUpEmailTextBox);
            signUpEmailTextBox.GotFocus += (sender, e) => ChangePanelEdgeColor(signUpPanel2, true);
            signUpEmailTextBox.LostFocus += (sender, e) => ChangePanelEdgeColor(signUpPanel2, false);
            signUpEmailTextBox.KeyDown += SignUpEmailTextBox_KeyDown;

            signUpPanel3 = CreatePanel(new Point(39, 356), new Size(452, 61));
            panel.Controls.Add(signUpPanel3);

            signUpPasswordTextBox = CreatePasswordTextBox(new Point(10, 10), new Size(372, 41));
            signUpPanel3.Controls.Add(signUpPasswordTextBox);
            signUpPasswordTextBox.GotFocus += (sender, e) => ChangePanelEdgeColor(signUpPanel3, true);
            signUpPasswordTextBox.LostFocus += (sender, e) => ChangePanelEdgeColor(signUpPanel3, false);
            signUpPasswordTextBox.KeyDown += SignUpPasswordTextBox_KeyDown;

            signUpShowPasswordButton = CreateShowPasswordButton(new Point(394, 10));
            signUpPanel3.Controls.Add(signUpShowPasswordButton);
            signUpShowPasswordButton.Click += (sender, e) => TogglePasswordVisibility(signUpPasswordTextBox, ref isSignUpPasswordVisible, signUpShowPasswordButton);

            signUpPanel4 = CreatePanel(new Point(39, 471), new Size(452, 61));
            panel.Controls.Add(signUpPanel4);

            signUpUserTextBox = CreateTextBox(new Point(10, 10), new Size(412, 41));
            signUpPanel4.Controls.Add(signUpUserTextBox);
            signUpUserTextBox.GotFocus += (sender, e) => ChangePanelEdgeColor(signUpPanel4, true);
            signUpUserTextBox.LostFocus += (sender, e) => ChangePanelEdgeColor(signUpPanel4, false);
            signUpUserTextBox.KeyDown += SignUpUserTextBox_KeyDown;

            signUpButton = CreateSignUpButton(new Point(39, 570), new Size(452, 61));
            panel.Controls.Add(signUpButton);
            signUpButton.Click += SignUpButton_Click;
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            string username = signUpUserTextBox.Text.Trim();
            string password = signUpPasswordTextBox.Text.Trim();
            string email = signUpEmailTextBox.Text.Trim();
            string fullName = signUpNameTextBox.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(fullName))
            {
                SetPanelEdgeColor(signUpPanel1, Color.Red);
                SetPanelEdgeColor(signUpPanel2, Color.Red);
                SetPanelEdgeColor(signUpPanel3, Color.Red);
                SetPanelEdgeColor(signUpPanel4, Color.Red);
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string hashedPassword = PasswordHelper.HashPassword(password);
            string pfp = "";

            bool isCreated = SqlInstance.CreateUser(username, hashedPassword, email, pfp);

            if (isCreated)
            {
                MessageBox.Show("Account created successfully. Please sign in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearSignUpFields();
            }
            else
            {
                MessageBox.Show("Failed to create account. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = loginUserTextBox.Text.Trim();
            string password = loginPasswordTextBox.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                SetPanelEdgeColor(loginPanel1, Color.Red);
                SetPanelEdgeColor(loginPanel2, Color.Red);
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int userId = Authenticate(username, password);


            if (userId > 0)
            {
                panel.Visible = false;
                OnLoginButtonClicked(EventArgs.Empty);
                Home home = new Home(this, userId);
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearLoginFields();
                SetPanelEdgeColor(loginPanel1, Color.Red);
                SetPanelEdgeColor(loginPanel2, Color.Red);
            }
        }

        private int Authenticate(string username, string password)
        {
            string hashedPassword = PasswordHelper.HashPassword(password);
            int userId = SqlInstance.AuthenticateUser(username, hashedPassword);
            return userId;
        }


        private void ClearLoginFields()
        {
            loginUserTextBox.Text = "";
            loginPasswordTextBox.Text = "";
        }

        private void ClearSignUpFields()
        {
            signUpNameTextBox.Text = "";
            signUpUserTextBox.Text = "";
            signUpEmailTextBox.Text = "";
            signUpPasswordTextBox.Text = "";
        }

        private void LoginUserTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginPasswordTextBox.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void LoginPasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void SignUpNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                signUpEmailTextBox.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void SignUpEmailTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                signUpPasswordTextBox.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void SignUpPasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                signUpUserTextBox.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void SignUpUserTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                signUpButton.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        protected virtual void OnLoginButtonClicked(EventArgs e)
        {
            LoginButtonClicked?.Invoke(this, e);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FullScreenForm form = new FullScreenForm();
            Application.Run(form);
        }
    }
}