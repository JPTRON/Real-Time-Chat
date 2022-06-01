namespace Projeto
{
    partial class ChatForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatForm));
            this.onlineUsersLbl = new System.Windows.Forms.Label();
            this.chat = new System.Windows.Forms.ListBox();
            this.dockPanel = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.textBoxMsg = new Guna.UI2.WinForms.Guna2TextBox();
            this.usernameLbl = new System.Windows.Forms.Label();
            this.RoundChat = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.RoundForm = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.avatarPB = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnSend = new Guna.UI2.WinForms.Guna2CircleButton();
            this.buttonMenu = new System.Windows.Forms.Button();
            this.sendFileBtn = new System.Windows.Forms.Button();
            this.profilePanel = new Guna.UI2.WinForms.Guna2Panel();
            this.btnLogOut = new Guna.UI2.WinForms.Guna2Button();
            this.panelUsrname = new System.Windows.Forms.Label();
            this.txtDesc = new Guna.UI2.WinForms.Guna2TextBox();
            this.panelProfilePic = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.dockPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarPB)).BeginInit();
            this.profilePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // onlineUsersLbl
            // 
            this.onlineUsersLbl.AutoSize = true;
            this.onlineUsersLbl.BackColor = System.Drawing.Color.Transparent;
            this.onlineUsersLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.onlineUsersLbl.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.onlineUsersLbl.Location = new System.Drawing.Point(693, 80);
            this.onlineUsersLbl.Name = "onlineUsersLbl";
            this.onlineUsersLbl.Size = new System.Drawing.Size(21, 22);
            this.onlineUsersLbl.TabIndex = 9;
            this.onlineUsersLbl.Text = "0";
            // 
            // chat
            // 
            this.chat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(104)))), ((int)(((byte)(165)))));
            this.chat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chat.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chat.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chat.FormattingEnabled = true;
            this.chat.HorizontalScrollbar = true;
            this.chat.ItemHeight = 18;
            this.chat.Location = new System.Drawing.Point(82, 118);
            this.chat.Name = "chat";
            this.chat.Size = new System.Drawing.Size(668, 414);
            this.chat.TabIndex = 11;
            this.chat.SelectedIndexChanged += new System.EventHandler(this.chat_SelectedIndexChanged);
            // 
            // dockPanel
            // 
            this.dockPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(104)))), ((int)(((byte)(165)))));
            this.dockPanel.Controls.Add(this.btnClose);
            this.dockPanel.Controls.Add(this.btnMinimize);
            this.dockPanel.Location = new System.Drawing.Point(0, 0);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Size = new System.Drawing.Size(832, 32);
            this.dockPanel.TabIndex = 14;
            this.dockPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dockPanel_MouseDown);
            this.dockPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dockPanel_MouseMove);
            this.dockPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dockPanel_MouseUp);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(801, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 20);
            this.btnClose.TabIndex = 18;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(775, 6);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(20, 20);
            this.btnMinimize.TabIndex = 17;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // textBoxMsg
            // 
            this.textBoxMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.textBoxMsg.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(104)))), ((int)(((byte)(165)))));
            this.textBoxMsg.BorderRadius = 8;
            this.textBoxMsg.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxMsg.DefaultText = "";
            this.textBoxMsg.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBoxMsg.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBoxMsg.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxMsg.DisabledState.Parent = this.textBoxMsg;
            this.textBoxMsg.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxMsg.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(104)))), ((int)(((byte)(165)))));
            this.textBoxMsg.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxMsg.FocusedState.Parent = this.textBoxMsg;
            this.textBoxMsg.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxMsg.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxMsg.HoverState.Parent = this.textBoxMsg;
            this.textBoxMsg.Location = new System.Drawing.Point(123, 560);
            this.textBoxMsg.Name = "textBoxMsg";
            this.textBoxMsg.PasswordChar = '\0';
            this.textBoxMsg.PlaceholderText = "Mensagem...";
            this.textBoxMsg.SelectedText = "";
            this.textBoxMsg.ShadowDecoration.Parent = this.textBoxMsg;
            this.textBoxMsg.Size = new System.Drawing.Size(584, 36);
            this.textBoxMsg.TabIndex = 15;
            this.textBoxMsg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxMsg_KeyDown);
            // 
            // usernameLbl
            // 
            this.usernameLbl.AutoSize = true;
            this.usernameLbl.BackColor = System.Drawing.Color.Transparent;
            this.usernameLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F);
            this.usernameLbl.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.usernameLbl.Location = new System.Drawing.Point(138, 85);
            this.usernameLbl.Name = "usernameLbl";
            this.usernameLbl.Size = new System.Drawing.Size(83, 17);
            this.usernameLbl.TabIndex = 18;
            this.usernameLbl.Text = "Username";
            // 
            // RoundChat
            // 
            this.RoundChat.BorderRadius = 8;
            this.RoundChat.TargetControl = this.chat;
            // 
            // RoundForm
            // 
            this.RoundForm.BorderRadius = 8;
            this.RoundForm.TargetControl = this;
            // 
            // avatarPB
            // 
            this.avatarPB.BackColor = System.Drawing.Color.Transparent;
            this.avatarPB.Image = global::Projeto.Properties.Resources._default;
            this.avatarPB.Location = new System.Drawing.Point(82, 54);
            this.avatarPB.Name = "avatarPB";
            this.avatarPB.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.avatarPB.ShadowDecoration.Parent = this.avatarPB;
            this.avatarPB.Size = new System.Drawing.Size(50, 50);
            this.avatarPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.avatarPB.TabIndex = 17;
            this.avatarPB.TabStop = false;
            this.avatarPB.Click += new System.EventHandler(this.avatarPB_Click);
            // 
            // btnSend
            // 
            this.btnSend.CheckedState.Parent = this.btnSend;
            this.btnSend.CustomImages.Parent = this.btnSend;
            this.btnSend.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(104)))), ((int)(((byte)(165)))));
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.HoverState.Parent = this.btnSend;
            this.btnSend.Image = global::Projeto.Properties.Resources.send_1_smol;
            this.btnSend.ImageOffset = new System.Drawing.Point(1, -1);
            this.btnSend.ImageSize = new System.Drawing.Size(25, 25);
            this.btnSend.Location = new System.Drawing.Point(714, 560);
            this.btnSend.Name = "btnSend";
            this.btnSend.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnSend.ShadowDecoration.Parent = this.btnSend;
            this.btnSend.Size = new System.Drawing.Size(36, 36);
            this.btnSend.TabIndex = 16;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // buttonMenu
            // 
            this.buttonMenu.FlatAppearance.BorderSize = 0;
            this.buttonMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenu.Image = global::Projeto.Properties.Resources.user_smol;
            this.buttonMenu.Location = new System.Drawing.Point(720, 74);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(30, 30);
            this.buttonMenu.TabIndex = 12;
            this.buttonMenu.UseVisualStyleBackColor = true;
            // 
            // sendFileBtn
            // 
            this.sendFileBtn.FlatAppearance.BorderSize = 0;
            this.sendFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendFileBtn.Image = global::Projeto.Properties.Resources.file_even_smol;
            this.sendFileBtn.Location = new System.Drawing.Point(82, 559);
            this.sendFileBtn.Name = "sendFileBtn";
            this.sendFileBtn.Size = new System.Drawing.Size(36, 36);
            this.sendFileBtn.TabIndex = 10;
            this.sendFileBtn.UseVisualStyleBackColor = true;
            this.sendFileBtn.Click += new System.EventHandler(this.sendFileBtn_Click);
            // 
            // profilePanel
            // 
            this.profilePanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(104)))), ((int)(((byte)(165)))));
            this.profilePanel.BorderThickness = 1;
            this.profilePanel.Controls.Add(this.btnLogOut);
            this.profilePanel.Controls.Add(this.panelUsrname);
            this.profilePanel.Controls.Add(this.txtDesc);
            this.profilePanel.Controls.Add(this.panelProfilePic);
            this.profilePanel.Location = new System.Drawing.Point(12, 105);
            this.profilePanel.Name = "profilePanel";
            this.profilePanel.ShadowDecoration.Parent = this.profilePanel;
            this.profilePanel.Size = new System.Drawing.Size(215, 299);
            this.profilePanel.TabIndex = 19;
            this.profilePanel.Visible = false;
            // 
            // btnLogOut
            // 
            this.btnLogOut.BorderRadius = 8;
            this.btnLogOut.CheckedState.Parent = this.btnLogOut;
            this.btnLogOut.CustomImages.Parent = this.btnLogOut;
            this.btnLogOut.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(104)))), ((int)(((byte)(165)))));
            this.btnLogOut.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.HoverState.Parent = this.btnLogOut;
            this.btnLogOut.Location = new System.Drawing.Point(70, 260);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.ShadowDecoration.Parent = this.btnLogOut;
            this.btnLogOut.Size = new System.Drawing.Size(63, 24);
            this.btnLogOut.TabIndex = 21;
            this.btnLogOut.Text = "Log Out";
            // 
            // panelUsrname
            // 
            this.panelUsrname.AutoSize = true;
            this.panelUsrname.BackColor = System.Drawing.Color.Transparent;
            this.panelUsrname.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F);
            this.panelUsrname.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.panelUsrname.Location = new System.Drawing.Point(63, 126);
            this.panelUsrname.Name = "panelUsrname";
            this.panelUsrname.Size = new System.Drawing.Size(83, 17);
            this.panelUsrname.TabIndex = 20;
            this.panelUsrname.Text = "Username";
            // 
            // txtDesc
            // 
            this.txtDesc.BorderRadius = 8;
            this.txtDesc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDesc.DefaultText = "";
            this.txtDesc.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDesc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDesc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDesc.DisabledState.Parent = this.txtDesc;
            this.txtDesc.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDesc.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(104)))), ((int)(((byte)(165)))));
            this.txtDesc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDesc.FocusedState.Parent = this.txtDesc;
            this.txtDesc.ForeColor = System.Drawing.Color.Black;
            this.txtDesc.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDesc.HoverState.Parent = this.txtDesc;
            this.txtDesc.Location = new System.Drawing.Point(38, 165);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.PasswordChar = '\0';
            this.txtDesc.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtDesc.PlaceholderText = "Descrição...";
            this.txtDesc.SelectedText = "";
            this.txtDesc.ShadowDecoration.Parent = this.txtDesc;
            this.txtDesc.Size = new System.Drawing.Size(133, 79);
            this.txtDesc.TabIndex = 1;
            // 
            // panelProfilePic
            // 
            this.panelProfilePic.BackColor = System.Drawing.Color.Transparent;
            this.panelProfilePic.Image = global::Projeto.Properties.Resources._default;
            this.panelProfilePic.Location = new System.Drawing.Point(55, 13);
            this.panelProfilePic.Name = "panelProfilePic";
            this.panelProfilePic.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.panelProfilePic.ShadowDecoration.Parent = this.panelProfilePic;
            this.panelProfilePic.Size = new System.Drawing.Size(100, 100);
            this.panelProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.panelProfilePic.TabIndex = 0;
            this.panelProfilePic.TabStop = false;
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(833, 628);
            this.Controls.Add(this.profilePanel);
            this.Controls.Add(this.usernameLbl);
            this.Controls.Add(this.avatarPB);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.textBoxMsg);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.buttonMenu);
            this.Controls.Add(this.chat);
            this.Controls.Add(this.sendFileBtn);
            this.Controls.Add(this.onlineUsersLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "ChatForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.dockPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.avatarPB)).EndInit();
            this.profilePanel.ResumeLayout(false);
            this.profilePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelProfilePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label onlineUsersLbl;
        private System.Windows.Forms.Button sendFileBtn;
        private System.Windows.Forms.ListBox chat;
        private System.Windows.Forms.Button buttonMenu;
        private System.Windows.Forms.Panel dockPanel;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private Guna.UI2.WinForms.Guna2TextBox textBoxMsg;
        private Guna.UI2.WinForms.Guna2CircleButton btnSend;
        private Guna.UI2.WinForms.Guna2CirclePictureBox avatarPB;
        private System.Windows.Forms.Label usernameLbl;
        private Guna.UI2.WinForms.Guna2Elipse RoundChat;
        private Guna.UI2.WinForms.Guna2Elipse RoundForm;
        private Guna.UI2.WinForms.Guna2Panel profilePanel;
        private Guna.UI2.WinForms.Guna2Button btnLogOut;
        private System.Windows.Forms.Label panelUsrname;
        private Guna.UI2.WinForms.Guna2TextBox txtDesc;
        private Guna.UI2.WinForms.Guna2CirclePictureBox panelProfilePic;
    }
}

