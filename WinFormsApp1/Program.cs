using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WMPLib;
using System.Diagnostics;
using WinFormsApp;
using WinFormsApp1;

namespace FullScreenApp
{

    public class FullScreenForm : Form
    {
        public event EventHandler LoginButtonClicked;
        private RoundedPanel panel;
        private RoundedPanel signUpPanel;
        private RoundedPanel loginRedPanel1;
        private RoundedPanel loginRedPanel2;
        private RoundedPanel signUpRedPanel1;
        private RoundedPanel signUpRedPanel2;
        private RoundedPanel signUpRedPanel3;
        private RoundedPanel signUpRedPanel4;
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
            string imagePath = @"C:\Users\enkud\Desktop\Cinema\back_image\login_img.png"; // Provide your own file path here

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
            panel = CreateRoundedPanel(new Point(1172, 276), new Size(522, 526));
            AddLoginControls(panel);
            this.Controls.Add(panel);
        }

        private RoundedPanel CreateRoundedPanel(Point location, Size size)
        {
            RoundedPanel roundedPanel = new RoundedPanel
            {
                BackColor = Color.FromArgb(24, 24, 24),
                Location = location,
                Size = size,
                CornerRadius = 20,
                EdgeColor = Color.FromArgb(41, 172, 191)
            };
            return roundedPanel;
        }

        private RoundedPanel CreateRedPanel(Point location, Size size)
        {
            RoundedPanel redPanel = new RoundedPanel
            {
                BackColor = Color.FromArgb(41, 41, 41),
                Location = location,
                Size = size,
                CornerRadius = 10,
                EdgeColor = Color.Teal
            };
            return redPanel;
        }

        private void AddLoginControls(RoundedPanel panel)
        {
            Label welcomeLabel = CreateLabel("Welcome back!", new Point(33, 27), 27, FontStyle.Bold);
            panel.Controls.Add(welcomeLabel);

            Label accountLabel = CreateLabel("Account", new Point(39, 92), 12);
            panel.Controls.Add(accountLabel);

            Label passwordLabel = CreateLabel("Password", new Point(39, 220), 12);
            panel.Controls.Add(passwordLabel);

            loginRedPanel1 = CreateRedPanel(new Point(39, 124), new Size(452, 61));
            panel.Controls.Add(loginRedPanel1);

            loginUserTextBox = CreateTextBox(new Point(10, 10), new Size(412, 41));
            loginRedPanel1.Controls.Add(loginUserTextBox);

            loginRedPanel2 = CreateRedPanel(new Point(39, 253), new Size(452, 61));
            panel.Controls.Add(loginRedPanel2);

            loginPasswordTextBox = CreatePasswordTextBox(new Point(10, 10), new Size(372, 41));
            loginRedPanel2.Controls.Add(loginPasswordTextBox);

            loginShowPasswordButton = CreateShowPasswordButton(new Point(394, 10));
            loginRedPanel2.Controls.Add(loginShowPasswordButton);
            loginShowPasswordButton.Click += (sender, e) => TogglePasswordVisibility(loginPasswordTextBox, ref isLoginPasswordVisible, loginShowPasswordButton);

            loginButton = CreateLoginButton(new Point(39, 364), new Size(452, 61));
            panel.Controls.Add(loginButton);

            AddLinks(panel, loginButton.Bottom + 10);

            loginButton.Click += LoginButton_Click;
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
                Font = new Font(FontFamily.GenericSansSerif, 23)
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
                BackColor = Color.FromArgb(41, 172, 191),
                FlatStyle = FlatStyle.Flat,
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
            Label forgotPasswordLabel = CreateLinkLabel("Forgot password.", new Point(39, buttonBottom));
            panel.Controls.Add(forgotPasswordLabel);

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
                MessageBox.Show("Coming Soon..");
            };

            ExitLink.LinkClicked += (sender, e) =>
            {
                Application.Exit();
            };
        }

        private void InitializeSignUpPanel()
        {
            signUpPanel = CreateRoundedPanel(new Point(1172, 276), new Size(522, 700));
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

            signUpRedPanel1 = CreateRedPanel(new Point(39, 124), new Size(452, 61));
            panel.Controls.Add(signUpRedPanel1);

            signUpNameTextBox = CreateTextBox(new Point(10, 10), new Size(412, 41));
            signUpRedPanel1.Controls.Add(signUpNameTextBox);

            signUpRedPanel2 = CreateRedPanel(new Point(39, 249), new Size(452, 61));
            panel.Controls.Add(signUpRedPanel2);

            signUpEmailTextBox = CreateTextBox(new Point(10, 10), new Size(412, 41));
            signUpRedPanel2.Controls.Add(signUpEmailTextBox);

            signUpRedPanel3 = CreateRedPanel(new Point(39, 356), new Size(452, 61));
            panel.Controls.Add(signUpRedPanel3);

            signUpPasswordTextBox = CreatePasswordTextBox(new Point(10, 10), new Size(372, 41));
            signUpRedPanel3.Controls.Add(signUpPasswordTextBox);

            signUpShowPasswordButton = CreateShowPasswordButton(new Point(394, 10));
            signUpRedPanel3.Controls.Add(signUpShowPasswordButton);
            signUpShowPasswordButton.Click += (sender, e) => TogglePasswordVisibility(signUpPasswordTextBox, ref isSignUpPasswordVisible, signUpShowPasswordButton);

            signUpRedPanel4 = CreateRedPanel(new Point(39, 471), new Size(452, 61));
            panel.Controls.Add(signUpRedPanel4);

            signUpUserTextBox = CreateTextBox(new Point(10, 10), new Size(412, 41));
            signUpRedPanel4.Controls.Add(signUpUserTextBox);

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

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = loginUserTextBox.Text.Trim();
            string password = loginPasswordTextBox.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool isAuthenticated = Authenticate(username, password);

            if (isAuthenticated)
            {
                panel.Visible = false;
                OnLoginButtonClicked(EventArgs.Empty);
                Home home = new Home(this);
                //home.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearLoginFields();
            }
        }

        private bool Authenticate(string username, string password)
        {
            bool isAuthenticated = SqlInstance.AuthenticateUser(username, password);
            return isAuthenticated;
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