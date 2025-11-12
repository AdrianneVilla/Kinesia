using Kinesia.Assessment;
using Kinesia.Components;
using Kinesia.Offline;
using KinesiaLibrary.DTOs.AuthDTOs;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinesia
{
    public partial class Login : Form
    {
        private LoadingScreen loadingScreen;
        private readonly HttpClient client = ApiClient.Instance;

        private static Login loginInstance;
        public Login()
        {
            InitializeComponent();

        }

        public static Login getLoginInstance()
        {
            if (loginInstance == null)
            {
                loginInstance = new Login();
            }
            return loginInstance;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Login));
            flowLayoutPanel3 = new FlowLayoutPanel();
            pictureBox4 = new PictureBox();
            label1 = new Label();
            usernameLabel = new Label();
            header1 = new Header();
            panelBorder1 = new WindowsFormsApp2.CustomButton.PanelBorder();
            txtPassword = new CustomControls.RJControls.RJTextBox();
            txtUsername = new CustomControls.RJControls.RJTextBox();
            username = new Label();
            btnLogin = new OrganizationProfile.CustomButton();
            passwordLabel = new Label();
            label3 = new Label();
            label2 = new Label();
            backgroundWorker1 = new BackgroundWorker();
            flowLayoutPanel3.SuspendLayout();
            ((ISupportInitialize)pictureBox4).BeginInit();
            panelBorder1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel3.Controls.Add(pictureBox4);
            flowLayoutPanel3.Controls.Add(label1);
            flowLayoutPanel3.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel3.Location = new Point(12, 75);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(386, 512);
            flowLayoutPanel3.TabIndex = 1;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.large_logo;
            pictureBox4.Location = new Point(15, 90);
            pictureBox4.Margin = new Padding(15, 90, 3, 25);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(353, 179);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 0;
            pictureBox4.TabStop = false;
            // 
            // label1
            // 
            label1.Font = new Font("Poppins", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(18, 90, 211);
            label1.Location = new Point(55, 294);
            label1.Margin = new Padding(55, 0, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(270, 69);
            label1.TabIndex = 1;
            label1.Text = "A System for Physical Therapy\r\n for Musculoskeletal Conditions\r\n using Astra Pro Plus Camera";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // usernameLabel
            // 
            usernameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            usernameLabel.AutoSize = true;
            usernameLabel.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            usernameLabel.ForeColor = Color.DimGray;
            usernameLabel.Location = new Point(57, 99);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(91, 26);
            usernameLabel.TabIndex = 4;
            usernameLabel.Text = "Username";
            // 
            // header1
            // 
            header1.BackColor = Color.White;
            header1.BackgroundImage = (Image)resources.GetObject("header1.BackgroundImage");
            header1.BackgroundImageLayout = ImageLayout.Stretch;
            header1.Dock = DockStyle.Top;
            header1.Location = new Point(0, 0);
            header1.Margin = new Padding(4, 3, 4, 3);
            header1.Name = "header1";
            header1.Size = new Size(972, 69);
            header1.TabIndex = 3;
            header1.Load += header1_Load;
            // 
            // panelBorder1
            // 
            panelBorder1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelBorder1.BackColor = Color.White;
            panelBorder1.BackgroundImage = Properties.Resources.login_holder;
            panelBorder1.BackgroundImageLayout = ImageLayout.Stretch;
            panelBorder1.BorderRadius = 30;
            panelBorder1.Color = Color.White;
            panelBorder1.Controls.Add(txtPassword);
            panelBorder1.Controls.Add(txtUsername);
            panelBorder1.Controls.Add(username);
            panelBorder1.Controls.Add(btnLogin);
            panelBorder1.Controls.Add(passwordLabel);
            panelBorder1.Controls.Add(label3);
            panelBorder1.Controls.Add(label2);
            panelBorder1.ForeColor = Color.Black;
            panelBorder1.Location = new Point(529, 97);
            panelBorder1.Name = "panelBorder1";
            panelBorder1.Size = new Size(366, 416);
            panelBorder1.TabIndex = 2;
            panelBorder1.Paint += panelBorder1_Paint;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.BackColor = SystemColors.Window;
            txtPassword.BorderColor = Color.Black;
            txtPassword.BorderFocusColor = Color.FromArgb(18, 90, 211);
            txtPassword.BorderRadius = 5;
            txtPassword.BorderSize = 1;
            txtPassword.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtPassword.ForeColor = Color.FromArgb(64, 64, 64);
            txtPassword.Location = new Point(62, 199);
            txtPassword.Margin = new Padding(4);
            txtPassword.MaxLength = 32767;
            txtPassword.Multiline = false;
            txtPassword.Name = "txtPassword";
            txtPassword.Padding = new Padding(10, 7, 10, 7);
            txtPassword.PasswordChar = true;
            txtPassword.PlaceholderColor = Color.DarkGray;
            txtPassword.PlaceholderText = "";
            txtPassword.SelectionLength = 0;
            txtPassword.SelectionStart = 0;
            txtPassword.Size = new Size(255, 31);
            txtPassword.TabIndex = 2;
            txtPassword.Texts = "";
            txtPassword.UnderlinedStyle = false;
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtUsername.BackColor = SystemColors.Window;
            txtUsername.BorderColor = Color.Black;
            txtUsername.BorderFocusColor = Color.FromArgb(18, 90, 211);
            txtUsername.BorderRadius = 5;
            txtUsername.BorderSize = 1;
            txtUsername.Font = new Font("Microsoft Sans Serif", 9.75F);
            txtUsername.ForeColor = Color.FromArgb(64, 64, 64);
            txtUsername.Location = new Point(62, 129);
            txtUsername.Margin = new Padding(4);
            txtUsername.MaxLength = 32767;
            txtUsername.Multiline = false;
            txtUsername.Name = "txtUsername";
            txtUsername.Padding = new Padding(10, 7, 10, 7);
            txtUsername.PasswordChar = false;
            txtUsername.PlaceholderColor = Color.DarkGray;
            txtUsername.PlaceholderText = "";
            txtUsername.SelectionLength = 0;
            txtUsername.SelectionStart = 0;
            txtUsername.Size = new Size(255, 31);
            txtUsername.TabIndex = 1;
            txtUsername.Texts = "";
            txtUsername.UnderlinedStyle = false;
            // 
            // username
            // 
            username.AutoSize = true;
            username.Font = new Font("Poppins", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            username.ForeColor = Color.DimGray;
            username.Location = new Point(57, 102);
            username.Name = "username";
            username.Size = new Size(80, 23);
            username.TabIndex = 7;
            username.Text = "Username";
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnLogin.BackColor = Color.FromArgb(18, 90, 211);
            btnLogin.BackgroundColor = Color.FromArgb(18, 90, 211);
            btnLogin.BorderColor = Color.Transparent;
            btnLogin.BorderRadius = 10;
            btnLogin.BorderSize = 0;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Poppins", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.Transparent;
            btnLogin.Location = new Point(62, 260);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(255, 40);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.TextColor = Color.Transparent;
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Poppins", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passwordLabel.ForeColor = Color.DimGray;
            passwordLabel.Location = new Point(57, 172);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(75, 23);
            passwordLabel.TabIndex = 5;
            passwordLabel.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(46, 105);
            label3.Name = "label3";
            label3.Size = new Size(67, 16);
            label3.TabIndex = 1;
            label3.Text = "               ";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Poppins", 13.75F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(38, 38, 38);
            label2.Location = new Point(56, 40);
            label2.Name = "label2";
            label2.Size = new Size(204, 34);
            label2.TabIndex = 0;
            label2.Text = "Login Your Account";
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            // 
            // Login
            // 
            BackColor = Color.White;
            ClientSize = new Size(972, 599);
            Controls.Add(header1);
            Controls.Add(panelBorder1);
            Controls.Add(flowLayoutPanel3);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Load += Form1_Load_2;
            flowLayoutPanel3.ResumeLayout(false);
            ((ISupportInitialize)pictureBox4).EndInit();
            panelBorder1.ResumeLayout(false);
            panelBorder1.PerformLayout();
            ResumeLayout(false);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_2(object sender, EventArgs e)
        {

        }

        private void panelBorder1_Paint(object sender, PaintEventArgs e)
        {

        }


        private async void btnLogin_Click(object sender, EventArgs e)
        {
            // will remove white spaces before and after the textboxes input
            txtUsername.Texts.Trim();
            txtPassword.Texts.Trim();

            if (txtUsername.Texts.Equals("") || txtPassword.Texts.Equals(""))
            {
                // will show an error dialog if the login field was incomplete
                CustomDialog.Show("Username or Password field are empty!\n" +
                    "Please fill-out all fields to login.", "Login Alert", CustomDialogButtons.OK, CustomDialogIcons.Error);
            }
            else
            {
                try
                {
                    var loginResult = await LoginAsync(txtUsername.Texts, txtPassword.Texts);

                    if (loginResult.Success)
                    {
                        // will continue to dashboard page if the password and hashed + salted password input is the same
                        PageObjects.dashboard = new Dashboard();
                        PageObjects.dashboard.Show();
                        this.Hide();
                        SessionManager.UserID = loginResult.UserID;
                        SessionManager.UserLastName = loginResult.UserLastName;
                        SessionManager.Role = loginResult.Role;
                        await Queries.LogsQueries.AddLog($"User logged in: {loginResult.Role}", "Login");

                    }
                    else if (loginResult.Message.Trim().Equals("Unable to connect to the server. Please try again."))
                    {
                        // will show an error dialog if the password and hashed + salted password input is different
                        CustomDialog.Show("Unable to connect to the server. Please try again.\n" +
                            "Please try again.", "Login Alert", CustomDialogButtons.OK, CustomDialogIcons.Error);
                    }
                    else
                    {
                        // will show an error dialog if the password and hashed + salted password input is different
                        CustomDialog.Show("Username or Password was incorrect!\n" +
                            "Please try again.", "Login Alert", CustomDialogButtons.OK, CustomDialogIcons.Error);
                    }
                }
                catch (HttpRequestException)
                {
                    // will show an error dialog if it catches a http request error from client-side.
                    CustomDialog.Show("Unable to connect to the server.\nPlease try again.",
                                "Connection Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                }
                catch (Exception)
                {
                    // will show an error dialog if it catches an unexpected error from client-side.
                    CustomDialog.Show("Unexpected error occured.\nPlease try again.",
                                "Unexpected Error", CustomDialogButtons.OK, CustomDialogIcons.Error);
                }
            }

        }

        public async Task<LoginResponse> LoginAsync(string username, string password)
        {
            var request = new LoginRequest
            {
                Username = username,
                Password = password
            };

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:5000/api/auth/login", content);

            if (!response.IsSuccessStatusCode)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = $"Server error {response.StatusCode}"
                };
            }

            var responsContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<LoginResponse>(responsContent);
        }

        private void header1_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private bool IsCameraConnected()
        {
            Astra.StreamSet tempStreamSet = null;
            bool initialized = false; // Keep track if Initialize was called
            try
            {
                // Initialize the SDK context first
                Astra.Context.Initialize(); //
                initialized = true;

                // Now try to open the default device stream set
                tempStreamSet = Astra.StreamSet.Open(); //

                if (tempStreamSet != null && tempStreamSet.IsAvailable) //
                {
                    return true; // Camera found and available
                }
                else
                {
                    return false; // Camera opened but not available
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Camera check failed: {ex.Message}");
                return false; // Exception likely means no device or driver issue
            }
            finally
            {
                // Dispose the stream set if created
                tempStreamSet?.Dispose(); //
                                          // Terminate the SDK context if it was initialized
                if (initialized)
                {
                    Astra.Context.Terminate(); //
                }
            }
        }
    }
}
