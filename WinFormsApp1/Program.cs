using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WinFormsApp;
using System.Drawing;
using WMPLib;
using System;
using WinFormsApp1;

namespace FullScreenApp
{
    public class FullScreenForm : Form
    {
        public event EventHandler LoginButtonClicked;
        private RoundedPanel panel;
        private TextBox nameTextBox;
        private TextBox userTextBox;
        private TextBox emailTextBox;
        private TextBox passwordTextBox;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private Button loginButton;

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
            this.TopMost = true;
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
            RoundedPanel roundedPanel = new RoundedPanel();
            roundedPanel.BackColor = Color.FromArgb(24, 24, 24);
            roundedPanel.Location = location;
            roundedPanel.Size = size;
            roundedPanel.CornerRadius = 20;
            roundedPanel.EdgeColor = Color.FromArgb(41, 172, 191);
            return roundedPanel;
        }

        private void AddLoginControls(RoundedPanel panel)
        {
            Label welcomeLabel = CreateLabel("Welcome back!", new Point(33, 27), 27, FontStyle.Bold);
            panel.Controls.Add(welcomeLabel);

            Label accountLabel = CreateLabel("Account", new Point(39, 92), 12);
            panel.Controls.Add(accountLabel);

            Label passwordLabel = CreateLabel("Password", new Point(39, 220), 12);
            panel.Controls.Add(passwordLabel);

            nameTextBox = CreateTextBox(new Point(39, 124), new Size(452, 61));
            panel.Controls.Add(nameTextBox);

            passwordTextBox = CreatePasswordTextBox(new Point(39, 253), new Size(452, 61));
            panel.Controls.Add(passwordTextBox);

            loginButton = CreateLoginButton(new Point(39, 364), new Size(452, 61));
            panel.Controls.Add(loginButton);

            AddLinks(panel, loginButton.Bottom + 10);

            loginButton.Click += LoginButton_Click;

        }

        private Label CreateLabel(string text, Point location, int fontSize, FontStyle fontStyle = FontStyle.Regular)
        {
            Label label = new Label();
            label.Text = text;
            label.ForeColor = Color.White;
            label.Font = new Font(label.Font.FontFamily, fontSize, fontStyle);
            label.AutoSize = true;
            label.Location = location;
            return label;
        }

        private TextBox CreateTextBox(Point location, Size size)
        {
            TextBox textBox = new TextBox();
            textBox.Location = location;
            textBox.Size = size;
            textBox.BackColor = Color.FromArgb(41, 41, 41);
            textBox.BorderStyle = BorderStyle.None;
            textBox.ForeColor = Color.White;
            textBox.Font = new Font(textBox.Font.FontFamily, 23);
            return textBox;
        }

        private TextBox CreatePasswordTextBox(Point location, Size size)
        {
            TextBox textBox = CreateTextBox(location, size);
            textBox.PasswordChar = '*';
            return textBox;
        }

        private RoundedButton CreateLoginButton(Point location, Size size)
        {
            RoundedButton button = new RoundedButton(); // Use RoundedButton instead of Button
            button.Text = "Sign in";
            button.Font = new Font(button.Font.FontFamily, 17);
            button.Location = location;
            button.Size = size;
            button.BackColor = Color.FromArgb(41, 172, 191);
            button.FlatStyle = FlatStyle.Flat;
            button.ForeColor = Color.Black;
            return button;
        }

        private void AddLinks(RoundedPanel panel, int buttonBottom)
        {
            Label forgotPasswordLabel = CreateLinkLabel("Forgot password.", new Point(39, buttonBottom));
            panel.Controls.Add(forgotPasswordLabel);

            LinkLabel signUpLinkLabel = CreateLinkLabel("Sign up for a new account.", new Point(39, buttonBottom + forgotPasswordLabel.Height + 5));
            panel.Controls.Add(signUpLinkLabel);
            signUpLinkLabel.LinkClicked += (sender, e) =>
            {
                panel.Visible = false;
                InitializeSignUpPanel(panel);
            };

            LinkLabel loginAsAdminLabel = CreateLinkLabel("Login as an Admin", new Point(370, buttonBottom));
            LinkLabel ExitLink = CreateLinkLabel("Exit", new Point(370, loginAsAdminLabel.Bottom + 5));
            panel.Controls.Add(loginAsAdminLabel);
            panel.Controls.Add(ExitLink);
            loginAsAdminLabel.LinkClicked += (sender, e) =>
            {
                MessageBox.Show("Comming Soon..");
            };

            ExitLink.LinkClicked += (sender, e) =>
            {
                Application.Exit();
                
             };
        }

        private LinkLabel CreateLinkLabel(string text, Point location)
        {
            LinkLabel linkLabel = new LinkLabel();
            linkLabel.Text = text;
            linkLabel.LinkColor = Color.FromArgb(41, 172, 191);
            linkLabel.Font = new Font(linkLabel.Font.FontFamily, 10);
            linkLabel.AutoSize = true;
            linkLabel.Location = location;
            return linkLabel;
        }

        private void InitializeSignUpPanel(RoundedPanel previousPanel)
        {
            RoundedPanel panel2 = CreateRoundedPanel(new Point(1172, 276), new Size(522, 700));
            AddSignUpControls(panel2);
            this.Controls.Add(panel2);

            LinkLabel signInLabel = CreateLinkLabel("Sign in", new Point(39, 637));
            panel2.Controls.Add(signInLabel);
            signInLabel.LinkClicked += (sender, e) =>
            {
                panel2.Visible = false;
                previousPanel.Visible = true;
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

            nameTextBox = CreateTextBox(new Point(39, 249), new Size(452, 61));
            panel.Controls.Add(nameTextBox);

            emailTextBox = CreateTextBox(new Point(39, 124), new Size(452, 61));
            panel.Controls.Add(emailTextBox);

            passwordTextBox = CreatePasswordTextBox(new Point(39, 356), new Size(452, 61));
            panel.Controls.Add(passwordTextBox);

            userTextBox = CreateTextBox(new Point(39, 471), new Size(452, 61));
            panel.Controls.Add(userTextBox);

            loginButton = CreateLoginButton(new Point(39, 570), new Size(452, 61));
            panel.Controls.Add(loginButton);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            panel.Visible = false;
            OnLoginButtonClicked(EventArgs.Empty);
            Home home = new Home(this);
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
