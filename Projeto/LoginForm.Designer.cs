namespace Projeto
{
    partial class LoginForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.RoundForm = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.ShadowForm = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.signUpPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSignIn = new Guna.UI.WinForms.GunaLabel();
            this.btnSignUp = new Guna.UI2.WinForms.Guna2Button();
            this.gunaLabel6 = new Guna.UI.WinForms.GunaLabel();
            this.txtPwdSignUp = new Guna.UI2.WinForms.Guna2TextBox();
            this.gunaLabel5 = new Guna.UI.WinForms.GunaLabel();
            this.txtUnameSignUp = new Guna.UI2.WinForms.Guna2TextBox();
            this.gunaLabel4 = new Guna.UI.WinForms.GunaLabel();
            this.signInPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.signupLbl = new Guna.UI.WinForms.GunaLabel();
            this.signinBtn = new Guna.UI2.WinForms.Guna2Button();
            this.gunaLabel3 = new Guna.UI.WinForms.GunaLabel();
            this.passwordSigninTtx = new Guna.UI2.WinForms.Guna2TextBox();
            this.gunaLabel7 = new Guna.UI.WinForms.GunaLabel();
            this.usernameSigninTxt = new Guna.UI2.WinForms.Guna2TextBox();
            this.gunaLabel8 = new Guna.UI.WinForms.GunaLabel();
            this.topBar = new Guna.UI.WinForms.GunaPanel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.signUpPanel.SuspendLayout();
            this.signInPanel.SuspendLayout();
            this.topBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // RoundForm
            // 
            this.RoundForm.TargetControl = this;
            // 
            // signUpPanel
            // 
            this.signUpPanel.BackColor = System.Drawing.Color.Transparent;
            this.signUpPanel.BorderRadius = 15;
            this.signUpPanel.Controls.Add(this.lblSignIn);
            this.signUpPanel.Controls.Add(this.btnSignUp);
            this.signUpPanel.Controls.Add(this.gunaLabel6);
            this.signUpPanel.Controls.Add(this.txtPwdSignUp);
            this.signUpPanel.Controls.Add(this.gunaLabel5);
            this.signUpPanel.Controls.Add(this.txtUnameSignUp);
            this.signUpPanel.Controls.Add(this.gunaLabel4);
            this.signUpPanel.Location = new System.Drawing.Point(36, 35);
            this.signUpPanel.Name = "signUpPanel";
            this.signUpPanel.ShadowDecoration.Parent = this.signUpPanel;
            this.signUpPanel.Size = new System.Drawing.Size(301, 408);
            this.signUpPanel.TabIndex = 0;
            this.signUpPanel.Visible = false;
            // 
            // lblSignIn
            // 
            this.lblSignIn.AutoSize = true;
            this.lblSignIn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSignIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(104)))), ((int)(((byte)(165)))));
            this.lblSignIn.Location = new System.Drawing.Point(129, 349);
            this.lblSignIn.Name = "lblSignIn";
            this.lblSignIn.Size = new System.Drawing.Size(67, 25);
            this.lblSignIn.TabIndex = 14;
            this.lblSignIn.Text = "Sign In";
            this.lblSignIn.Click += new System.EventHandler(this.lblSignIn_Click);
            // 
            // btnSignUp
            // 
            this.btnSignUp.BackColor = System.Drawing.Color.Transparent;
            this.btnSignUp.BorderRadius = 8;
            this.btnSignUp.CheckedState.Parent = this.btnSignUp;
            this.btnSignUp.CustomImages.Parent = this.btnSignUp;
            this.btnSignUp.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(104)))), ((int)(((byte)(165)))));
            this.btnSignUp.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSignUp.ForeColor = System.Drawing.Color.White;
            this.btnSignUp.HoverState.Parent = this.btnSignUp;
            this.btnSignUp.Location = new System.Drawing.Point(34, 289);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.ShadowDecoration.Parent = this.btnSignUp;
            this.btnSignUp.Size = new System.Drawing.Size(238, 35);
            this.btnSignUp.TabIndex = 9;
            this.btnSignUp.Text = "Sign Up";
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // gunaLabel6
            // 
            this.gunaLabel6.AutoSize = true;
            this.gunaLabel6.BackColor = System.Drawing.Color.Transparent;
            this.gunaLabel6.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.gunaLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(104)))), ((int)(((byte)(165)))));
            this.gunaLabel6.Location = new System.Drawing.Point(30, 161);
            this.gunaLabel6.Name = "gunaLabel6";
            this.gunaLabel6.Size = new System.Drawing.Size(103, 30);
            this.gunaLabel6.TabIndex = 7;
            this.gunaLabel6.Text = "Password";
            // 
            // txtPwdSignUp
            // 
            this.txtPwdSignUp.BackColor = System.Drawing.Color.Transparent;
            this.txtPwdSignUp.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(104)))), ((int)(((byte)(165)))));
            this.txtPwdSignUp.BorderRadius = 8;
            this.txtPwdSignUp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPwdSignUp.DefaultText = "";
            this.txtPwdSignUp.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPwdSignUp.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPwdSignUp.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPwdSignUp.DisabledState.Parent = this.txtPwdSignUp;
            this.txtPwdSignUp.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPwdSignUp.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(104)))), ((int)(((byte)(165)))));
            this.txtPwdSignUp.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPwdSignUp.FocusedState.Parent = this.txtPwdSignUp;
            this.txtPwdSignUp.ForeColor = System.Drawing.Color.White;
            this.txtPwdSignUp.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPwdSignUp.HoverState.Parent = this.txtPwdSignUp;
            this.txtPwdSignUp.IconRight = global::Projeto.Properties.Resources.eye_purple;
            this.txtPwdSignUp.Location = new System.Drawing.Point(34, 186);
            this.txtPwdSignUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPwdSignUp.Name = "txtPwdSignUp";
            this.txtPwdSignUp.PasswordChar = '\0';
            this.txtPwdSignUp.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.txtPwdSignUp.PlaceholderText = "password";
            this.txtPwdSignUp.SelectedText = "";
            this.txtPwdSignUp.ShadowDecoration.Parent = this.txtPwdSignUp;
            this.txtPwdSignUp.Size = new System.Drawing.Size(237, 33);
            this.txtPwdSignUp.TabIndex = 8;
            this.txtPwdSignUp.UseSystemPasswordChar = true;
            this.txtPwdSignUp.IconRightClick += new System.EventHandler(this.txtPwdSignUp_IconRightClick);
            // 
            // gunaLabel5
            // 
            this.gunaLabel5.AutoSize = true;
            this.gunaLabel5.BackColor = System.Drawing.Color.Transparent;
            this.gunaLabel5.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.gunaLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(104)))), ((int)(((byte)(165)))));
            this.gunaLabel5.Location = new System.Drawing.Point(32, 98);
            this.gunaLabel5.Name = "gunaLabel5";
            this.gunaLabel5.Size = new System.Drawing.Size(111, 30);
            this.gunaLabel5.TabIndex = 5;
            this.gunaLabel5.Text = "Username";
            // 
            // txtUnameSignUp
            // 
            this.txtUnameSignUp.BackColor = System.Drawing.Color.Transparent;
            this.txtUnameSignUp.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(104)))), ((int)(((byte)(165)))));
            this.txtUnameSignUp.BorderRadius = 8;
            this.txtUnameSignUp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUnameSignUp.DefaultText = "";
            this.txtUnameSignUp.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUnameSignUp.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUnameSignUp.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUnameSignUp.DisabledState.Parent = this.txtUnameSignUp;
            this.txtUnameSignUp.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUnameSignUp.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(104)))), ((int)(((byte)(165)))));
            this.txtUnameSignUp.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUnameSignUp.FocusedState.Parent = this.txtUnameSignUp;
            this.txtUnameSignUp.ForeColor = System.Drawing.Color.White;
            this.txtUnameSignUp.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUnameSignUp.HoverState.Parent = this.txtUnameSignUp;
            this.txtUnameSignUp.Location = new System.Drawing.Point(36, 123);
            this.txtUnameSignUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUnameSignUp.Name = "txtUnameSignUp";
            this.txtUnameSignUp.PasswordChar = '\0';
            this.txtUnameSignUp.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.txtUnameSignUp.PlaceholderText = "username";
            this.txtUnameSignUp.SelectedText = "";
            this.txtUnameSignUp.ShadowDecoration.Parent = this.txtUnameSignUp;
            this.txtUnameSignUp.Size = new System.Drawing.Size(237, 33);
            this.txtUnameSignUp.TabIndex = 6;
            // 
            // gunaLabel4
            // 
            this.gunaLabel4.AutoSize = true;
            this.gunaLabel4.BackColor = System.Drawing.Color.Transparent;
            this.gunaLabel4.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.gunaLabel4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.gunaLabel4.Location = new System.Drawing.Point(108, 57);
            this.gunaLabel4.Name = "gunaLabel4";
            this.gunaLabel4.Size = new System.Drawing.Size(132, 45);
            this.gunaLabel4.TabIndex = 5;
            this.gunaLabel4.Text = "Sign Up";
            // 
            // signInPanel
            // 
            this.signInPanel.BackColor = System.Drawing.Color.Transparent;
            this.signInPanel.BorderRadius = 15;
            this.signInPanel.Controls.Add(this.signupLbl);
            this.signInPanel.Controls.Add(this.signinBtn);
            this.signInPanel.Controls.Add(this.gunaLabel3);
            this.signInPanel.Controls.Add(this.passwordSigninTtx);
            this.signInPanel.Controls.Add(this.gunaLabel7);
            this.signInPanel.Controls.Add(this.usernameSigninTxt);
            this.signInPanel.Controls.Add(this.gunaLabel8);
            this.signInPanel.Location = new System.Drawing.Point(38, 35);
            this.signInPanel.Name = "signInPanel";
            this.signInPanel.ShadowDecoration.Parent = this.signInPanel;
            this.signInPanel.Size = new System.Drawing.Size(301, 408);
            this.signInPanel.TabIndex = 15;
            // 
            // signupLbl
            // 
            this.signupLbl.AutoSize = true;
            this.signupLbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.signupLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(104)))), ((int)(((byte)(165)))));
            this.signupLbl.Location = new System.Drawing.Point(126, 349);
            this.signupLbl.Name = "signupLbl";
            this.signupLbl.Size = new System.Drawing.Size(75, 25);
            this.signupLbl.TabIndex = 14;
            this.signupLbl.Text = "Sign Up";
            this.signupLbl.Click += new System.EventHandler(this.lblSignUp_Click);
            // 
            // signinBtn
            // 
            this.signinBtn.BackColor = System.Drawing.Color.Transparent;
            this.signinBtn.BorderRadius = 8;
            this.signinBtn.CheckedState.Parent = this.signinBtn;
            this.signinBtn.CustomImages.Parent = this.signinBtn;
            this.signinBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(104)))), ((int)(((byte)(165)))));
            this.signinBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.signinBtn.ForeColor = System.Drawing.Color.White;
            this.signinBtn.HoverState.Parent = this.signinBtn;
            this.signinBtn.Location = new System.Drawing.Point(34, 289);
            this.signinBtn.Name = "signinBtn";
            this.signinBtn.ShadowDecoration.Parent = this.signinBtn;
            this.signinBtn.Size = new System.Drawing.Size(238, 35);
            this.signinBtn.TabIndex = 9;
            this.signinBtn.Text = "Sign In";
            this.signinBtn.Click += new System.EventHandler(this.signinBtn_Click);
            // 
            // gunaLabel3
            // 
            this.gunaLabel3.AutoSize = true;
            this.gunaLabel3.BackColor = System.Drawing.Color.Transparent;
            this.gunaLabel3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.gunaLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(104)))), ((int)(((byte)(165)))));
            this.gunaLabel3.Location = new System.Drawing.Point(30, 161);
            this.gunaLabel3.Name = "gunaLabel3";
            this.gunaLabel3.Size = new System.Drawing.Size(103, 30);
            this.gunaLabel3.TabIndex = 7;
            this.gunaLabel3.Text = "Password";
            // 
            // passwordSigninTtx
            // 
            this.passwordSigninTtx.BackColor = System.Drawing.Color.Transparent;
            this.passwordSigninTtx.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(104)))), ((int)(((byte)(165)))));
            this.passwordSigninTtx.BorderRadius = 8;
            this.passwordSigninTtx.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passwordSigninTtx.DefaultText = "";
            this.passwordSigninTtx.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.passwordSigninTtx.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.passwordSigninTtx.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.passwordSigninTtx.DisabledState.Parent = this.passwordSigninTtx;
            this.passwordSigninTtx.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.passwordSigninTtx.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(104)))), ((int)(((byte)(165)))));
            this.passwordSigninTtx.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.passwordSigninTtx.FocusedState.Parent = this.passwordSigninTtx;
            this.passwordSigninTtx.ForeColor = System.Drawing.Color.White;
            this.passwordSigninTtx.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.passwordSigninTtx.HoverState.Parent = this.passwordSigninTtx;
            this.passwordSigninTtx.IconRight = global::Projeto.Properties.Resources.eye_purple;
            this.passwordSigninTtx.Location = new System.Drawing.Point(34, 186);
            this.passwordSigninTtx.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.passwordSigninTtx.Name = "passwordSigninTtx";
            this.passwordSigninTtx.PasswordChar = '\0';
            this.passwordSigninTtx.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.passwordSigninTtx.PlaceholderText = "password";
            this.passwordSigninTtx.SelectedText = "";
            this.passwordSigninTtx.ShadowDecoration.Parent = this.passwordSigninTtx;
            this.passwordSigninTtx.Size = new System.Drawing.Size(237, 33);
            this.passwordSigninTtx.TabIndex = 8;
            this.passwordSigninTtx.UseSystemPasswordChar = true;
            this.passwordSigninTtx.IconRightClick += new System.EventHandler(this.passwordSigninTtx_IconRightClick);
            // 
            // gunaLabel7
            // 
            this.gunaLabel7.AutoSize = true;
            this.gunaLabel7.BackColor = System.Drawing.Color.Transparent;
            this.gunaLabel7.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.gunaLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(104)))), ((int)(((byte)(165)))));
            this.gunaLabel7.Location = new System.Drawing.Point(32, 98);
            this.gunaLabel7.Name = "gunaLabel7";
            this.gunaLabel7.Size = new System.Drawing.Size(111, 30);
            this.gunaLabel7.TabIndex = 5;
            this.gunaLabel7.Text = "Username";
            // 
            // usernameSigninTxt
            // 
            this.usernameSigninTxt.BackColor = System.Drawing.Color.Transparent;
            this.usernameSigninTxt.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(104)))), ((int)(((byte)(165)))));
            this.usernameSigninTxt.BorderRadius = 8;
            this.usernameSigninTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.usernameSigninTxt.DefaultText = "";
            this.usernameSigninTxt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.usernameSigninTxt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.usernameSigninTxt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.usernameSigninTxt.DisabledState.Parent = this.usernameSigninTxt;
            this.usernameSigninTxt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.usernameSigninTxt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(104)))), ((int)(((byte)(165)))));
            this.usernameSigninTxt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.usernameSigninTxt.FocusedState.Parent = this.usernameSigninTxt;
            this.usernameSigninTxt.ForeColor = System.Drawing.Color.White;
            this.usernameSigninTxt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.usernameSigninTxt.HoverState.Parent = this.usernameSigninTxt;
            this.usernameSigninTxt.Location = new System.Drawing.Point(36, 123);
            this.usernameSigninTxt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.usernameSigninTxt.Name = "usernameSigninTxt";
            this.usernameSigninTxt.PasswordChar = '\0';
            this.usernameSigninTxt.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.usernameSigninTxt.PlaceholderText = "username";
            this.usernameSigninTxt.SelectedText = "";
            this.usernameSigninTxt.ShadowDecoration.Parent = this.usernameSigninTxt;
            this.usernameSigninTxt.Size = new System.Drawing.Size(237, 33);
            this.usernameSigninTxt.TabIndex = 6;
            // 
            // gunaLabel8
            // 
            this.gunaLabel8.AutoSize = true;
            this.gunaLabel8.BackColor = System.Drawing.Color.Transparent;
            this.gunaLabel8.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.gunaLabel8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.gunaLabel8.Location = new System.Drawing.Point(108, 57);
            this.gunaLabel8.Name = "gunaLabel8";
            this.gunaLabel8.Size = new System.Drawing.Size(118, 45);
            this.gunaLabel8.TabIndex = 5;
            this.gunaLabel8.Text = "Sign In";
            // 
            // topBar
            // 
            this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(104)))), ((int)(((byte)(165)))));
            this.topBar.Controls.Add(this.btnMinimize);
            this.topBar.Controls.Add(this.btnClose);
            this.topBar.Location = new System.Drawing.Point(-2, 0);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(374, 28);
            this.topBar.TabIndex = 5;
            this.topBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseDown);
            this.topBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseMove);
            this.topBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseUp);
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(317, 3);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(20, 20);
            this.btnMinimize.TabIndex = 20;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(345, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 20);
            this.btnClose.TabIndex = 19;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(372, 478);
            this.Controls.Add(this.signInPanel);
            this.Controls.Add(this.topBar);
            this.Controls.Add(this.signUpPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.Text = "Login/Sign Up";
            this.signUpPanel.ResumeLayout(false);
            this.signUpPanel.PerformLayout();
            this.signInPanel.ResumeLayout(false);
            this.signInPanel.PerformLayout();
            this.topBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse RoundForm;
        private Guna.UI2.WinForms.Guna2ShadowForm ShadowForm;
        private Guna.UI2.WinForms.Guna2Panel signUpPanel;
        private Guna.UI.WinForms.GunaLabel gunaLabel6;
        private Guna.UI2.WinForms.Guna2TextBox txtPwdSignUp;
        private Guna.UI.WinForms.GunaLabel gunaLabel5;
        private Guna.UI2.WinForms.Guna2TextBox txtUnameSignUp;
        private Guna.UI.WinForms.GunaLabel gunaLabel4;
        private Guna.UI.WinForms.GunaPanel topBar;
        private Guna.UI2.WinForms.Guna2Button btnSignUp;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private Guna.UI.WinForms.GunaLabel lblSignIn;
        private Guna.UI2.WinForms.Guna2Panel signInPanel;
        private Guna.UI.WinForms.GunaLabel signupLbl;
        private Guna.UI2.WinForms.Guna2Button signinBtn;
        private Guna.UI.WinForms.GunaLabel gunaLabel3;
        private Guna.UI2.WinForms.Guna2TextBox passwordSigninTtx;
        private Guna.UI.WinForms.GunaLabel gunaLabel7;
        private Guna.UI2.WinForms.Guna2TextBox usernameSigninTxt;
        private Guna.UI.WinForms.GunaLabel gunaLabel8;
    }
}

