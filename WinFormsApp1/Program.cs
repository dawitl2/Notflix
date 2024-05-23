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
        private Button loginShowPasswordButton;
        private Button signUpShowPasswordButton;
        private readonly Sql SqlInstance = new Sql();

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
            AddLoginControls(panel);
            panel_genre.Visible = false;
            panel_movie.EdgeColor = Color.Teal;
            panel_genre.EdgeColor = Color.Teal;
            panel_movie.Visible = false;
            this.Controls.Add(panel);
            this.Controls.Add(panel_movie);
            this.Controls.Add(panel_genre);
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
                if (IsInternetAvailable())
                {
                    string username = Microsoft.VisualBasic.Interaction.InputBox("Please enter your username:", "Forgot Password", "");
                    if (!string.IsNullOrEmpty(username))
                    {
                        Sql sql = new Sql();
                        var (userExists, email) = sql.CheckUserExists(username);

                        if (userExists)
                        {
                            Email mail = new Email(email, username);
                            int num = mail.code;
                            MessageBox.Show($"Verification code is sent to Email: {email}", "User Found", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            int code = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Enter Code: ", "Verification Code"));
                            while (code != num)
                            {
                                DialogResult result = MessageBox.Show("Incorrect code. Try again?", "Verification Failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                                if (result == DialogResult.Cancel)
                                {
                                    return;
                                }
                                code = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Enter Code: ", "Verification Code"));
                            }

                            string newPassword = Microsoft.VisualBasic.Interaction.InputBox("Enter new password:", "New Password");
                            bool passwordChanged = sql.ChangePassword(username, newPassword);

                            if (passwordChanged)
                            {
                                MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Error changing password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Username not found in the database.", "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No username entered.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No internet connection!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


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
            loginAsAdminLabel.LinkClicked += (sender, e) =>
            {
                panel.Visible = false;
                panel_genre.Visible = true;
                panel_movie.Visible = true;
            };

            ExitLink.LinkClicked += (sender, e) =>
            {
                Application.Exit();
            };
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

        /* private void SignUpButton_Click(object sender, EventArgs e)
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

             string pfp = "";

             bool isCreated = SqlInstance.CreateUser(username, password, email, pfp);

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
 */


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
