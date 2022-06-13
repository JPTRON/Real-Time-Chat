using EI.SI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Projeto
{
    public partial class LoginForm : Form
    {
        bool mouseDown;
        private Point offset;

        private const int PORT = 10000;
        NetworkStream networkstream;
        ProtocolSI protocolSI = new ProtocolSI();
        TcpClient tcpClient;
        Thread trd = null;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void topBar_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void topBar_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouseDown == true)
            {
                Point currentPos = PointToScreen(e.Location);
                Location = new Point(currentPos.X - offset.X, currentPos.Y - offset.Y);
            }
        }

        private void topBar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Pretende sair do programa?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Close(); //This block is responsable for the dialog box when closing
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; //Minimizes the 1st form
        }

        private void lblSignIn_Click(object sender, EventArgs e)
        {
            signUpPanel.Visible = false;
            signInPanel.Visible = true;
        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {
            signUpPanel.Visible = true;
            signInPanel.Visible = false;
        }

        private void signinBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string username = usernameSigninTxt.Text;
                string password = passwordSigninTtx.Text;

                //Verifica se os campos das textbox estão preenchidos
                if (username.Trim() == "" || password.Trim() == "") { throw new Exception("Preencha todos os campos!"); }
                if (username.Any(Char.IsWhiteSpace)) { throw new Exception("Preencha o username sem espaços!"); }
                if (!Regex.IsMatch(username, @"^[a-zA-Z0-9]+$")) { throw new Exception("Insira apenas letras e números no campo do username!"); }
                
                username = username.Trim();

                Credenciais credenciaisObj = new Credenciais();
                credenciaisObj.username = username;
                credenciaisObj.passwordHash = HashPassword(password);

                string credenciais = System.Text.Json.JsonSerializer.Serialize(credenciaisObj);

                IPEndPoint endpoint = new IPEndPoint(IPAddress.Loopback, PORT);
                tcpClient = new TcpClient();
                tcpClient.Connect(endpoint);
                networkstream = tcpClient.GetStream();
                byte[] dataBytes;

                byte[] packet = protocolSI.Make(ProtocolSICmdType.USER_OPTION_4, credenciais);
                networkstream.Write(packet, 0, packet.Length);

                while (protocolSI.GetCmdType() != ProtocolSICmdType.DATA)
                {
                    networkstream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                }

                dataBytes = protocolSI.GetData();
                string message = ASCIIEncoding.ASCII.GetString(dataBytes);

                while (protocolSI.GetCmdType() != ProtocolSICmdType.ACK)
                {
                    networkstream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                }

                networkstream.Close();
                tcpClient.Close();

                if (message == "true")
                {
                    ChatForm chat = new ChatForm(username);
                    chat.Show();
                    this.Close();
                }
                else
                {
                    throw new Exception(message);
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Erro");
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUnameSignUp.Text;
                string password = txtPwdSignUp.Text;

                //Verifica se os campos das textbox estão preenchidos
                if (username.Trim() == "" || password.Trim() == "") { throw new Exception("Preencha todos os campos!"); }
                if (username.Any(Char.IsWhiteSpace)) { throw new Exception("Preencha o username sem espaços!"); }
                if (!Regex.IsMatch(username, @"^[a-zA-Z0-9]+$")) { throw new Exception("Insira apenas letras e números no campo do username!"); }
                
                username = username.Trim();

                Credenciais credenciaisObj = new Credenciais();
                credenciaisObj.username = username;
                credenciaisObj.passwordHash = HashPassword(password);

                string credenciais = System.Text.Json.JsonSerializer.Serialize(credenciaisObj);

                IPEndPoint endpoint = new IPEndPoint(IPAddress.Loopback, PORT);
                tcpClient = new TcpClient();
                tcpClient.Connect(endpoint);
                networkstream = tcpClient.GetStream();
                byte[] dataBytes;

                byte[] packet = protocolSI.Make(ProtocolSICmdType.USER_OPTION_5, credenciais);
                networkstream.Write(packet, 0, packet.Length);

                while (protocolSI.GetCmdType() != ProtocolSICmdType.DATA)
                {
                    networkstream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                }

                dataBytes = protocolSI.GetData();
                string message = ASCIIEncoding.ASCII.GetString(dataBytes);

                while (protocolSI.GetCmdType() != ProtocolSICmdType.ACK)
                {
                    networkstream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                }

                networkstream.Close();
                tcpClient.Close();

                if (message == "true")
                {
                    ChatForm chat = new ChatForm(username);
                    chat.Show();
                    this.Close();
                }
                else
                {
                    throw new Exception(message);
                }                     
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Erro");
            }
        }

        private string HashPassword(string password)
        {
            //Cria um SHA256
            SHA256 sha256 = SHA256.Create();
            //Retorna uma array de bytes a partir da password
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            //Converte a array numa string
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }

        class Credenciais
        {
            public string username { get; set; }
            public string passwordHash { get; set; }
        }

        private void passwordSigninTtx_IconRightClick(object sender, EventArgs e)
        {
            passwordSigninTtx.UseSystemPasswordChar = !passwordSigninTtx.UseSystemPasswordChar;
        }

        private void txtPwdSignUp_IconRightClick(object sender, EventArgs e)
        {
            txtPwdSignUp.UseSystemPasswordChar = !txtPwdSignUp.UseSystemPasswordChar;
        }
    }
}