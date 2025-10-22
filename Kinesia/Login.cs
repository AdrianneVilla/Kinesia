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
using Kinesia.Components;
using KinesiaLibrary.DTOs.AuthDTOs;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace Kinesia
{
    public partial class Login : Form
    {
        private LoadingScreen loadingScreen;
       

        private static Login loginInstance;
        public Login()
        {
            InitializeComponent();
       
        }

        public static Login getLoginInstance()
        {
            if(loginInstance == null)
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
            customButton1 = new OrganizationProfile.CustomButton();
            label4 = new Label();
            txtPassword = new CustomControls.RJControls.RJTextBox();
            txtUsername = new CustomControls.RJControls.RJTextBox();
            username = new Label();
            btnLogin = new OrganizationProfile.CustomButton();
            passwordLabel = new Label();
            label3 = new Label();
            label2 = new Label();
            backgroundWorker1 = new BackgroundWorker();
            label5 = new Label();
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
            panelBorder1.Controls.Add(customButton1);
            panelBorder1.Controls.Add(label4);
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
            // customButton1
            // 
            customButton1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            customButton1.BackColor = Color.FromArgb(207, 249, 238);
            customButton1.BackgroundColor = Color.FromArgb(207, 249, 238);
            customButton1.BorderColor = Color.FromArgb(21, 134, 105);
            customButton1.BorderRadius = 10;
            customButton1.BorderSize = 1;
            customButton1.FlatAppearance.BorderSize = 0;
            customButton1.FlatStyle = FlatStyle.Flat;
            customButton1.Font = new Font("Poppins", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            customButton1.ForeColor = Color.FromArgb(21, 134, 105);
            customButton1.Location = new Point(62, 345);
            customButton1.Name = "customButton1";
            customButton1.Padding = new Padding(0, 1, 0, 0);
            customButton1.Size = new Size(255, 33);
            customButton1.TabIndex = 9;
            customButton1.Text = "Use Camera (Offline Mode)";
            customButton1.TextColor = Color.FromArgb(21, 134, 105);
            customButton1.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(141, 319);
            label4.Name = "label4";
            label4.Size = new Size(94, 23);
            label4.TabIndex = 8;
            label4.Text = "for offline use";
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
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("Poppins", 10F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(18, 90, 211);
            label5.Location = new Point(640, 545);
            label5.Name = "label5";
            label5.Size = new Size(150, 25);
            label5.TabIndex = 4;
            label5.Text = "View system guide";
            // 
            // Login
            // 
            BackColor = Color.White;
            ClientSize = new Size(972, 599);
            Controls.Add(label5);
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
            PerformLayout();

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

            if(txtUsername.Texts.Equals("") || txtPassword.Texts.Equals(""))
            {
                // will show an error dialog if the login field was incomplete
                CustomDialog.Show("Username or Password field are empty!\n" +
                    "Please fill-out all fields to login.", "Login Alert", CustomDialogButtons.OK, CustomDialogIcons.Error);
            } 
            else
            {
                loadingScreen = new LoadingScreen();
                loadingScreen.Show();

                var loginResult = await LoginAsync(txtUsername.Texts, txtPassword.Texts);

                if (loginResult.Success)
                {
                    // will close the loading screen after the loginResult was success
                    loadingScreen.Close();

                    // will continue to dashboard page if the password and hashed + salted password input is the same
                    PageObjects.dashboard = new Dashboard();
                    PageObjects.dashboard.Show();
                    this.Hide();
                    SessionManager.UserID = loginResult.UserID;
                    SessionManager.UserLastName = loginResult.UserLastName;
                    await Queries.LogsQueries.AddLog("Has Logged In", "Sessions");
          
                }
                else if(loginResult.Message.Trim().Equals("Unable to connect to the server. Please try again."))
                {
                    loadingScreen.Close();
                    // will show an error dialog if the password and hashed + salted password input is different
                    CustomDialog.Show("Unable to connect to the server. Please try again.\n" +
                        "Please try again.", "Login Alert", CustomDialogButtons.OK, CustomDialogIcons.Error);
                }
                else
                {
                    loadingScreen.Close();
                    // will show an error dialog if the password and hashed + salted password input is different
                    CustomDialog.Show("Username or Password was incorrect!\n" +
                        "Please try again.", "Login Alert", CustomDialogButtons.OK, CustomDialogIcons.Error);
                }
            }

        }

        public async Task<LoginResponse> LoginAsync(string username, string password)
        {
            try
            {
                using (var client = new HttpClient { BaseAddress = new Uri("http://localhost:5000/") })
                {
                    var request = new LoginRequest
                    {
                        Username = username,
                        Password = password
                    };

                    var json = JsonConvert.SerializeObject(request);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("api/auth/login", content);

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
            }
            catch (HttpRequestException ex)
            {
                return new LoginResponse { Success = false, Message = "Unable to connect to the server. Please try again." };
            }
        }

        private void header1_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
