using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;

namespace Projeto
{
    public partial class LoginForm : Form
    {
        bool mouseDown;
        private Point offset;
        MySqlConnection myConnection = new MySqlConnection("Server=127.0.0.1;Port=3306;Database=usersts;Uid=root;Pwd=;");

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
                if (!Regex.IsMatch(username, @"^[a-zA-Z0-9]+$")) { throw new Exception("Insira apenas letras e números no campo do username!"); }

                username = username.Trim();

                /*myConnection.Open();

                //Declara uma query que vai procurar o user com o username da textbox e executa
                MySqlCommand cmd = new MySqlCommand($"SELECT username, password FROM users where username LIKE '{username}'", myConnection);
                MySqlDataReader reader = cmd.ExecuteReader();            

                //Verifica se o SELECT retorna algum dado
                if(reader.Read())
                {                
                    //Converte a password da textbox para um hash e compara à password na base de dados 
                    string hashedPassword = HashPassword(password);

                    if (hashedPassword == reader["password"].ToString())
                    {*/
                        //Abre a sala de chat
                        ChatForm chat = new ChatForm(username);
                        chat.Show();
                        this.Close(); /*                   
                    }
                    else
                    {
                        throw new Exception("Username ou Password incorretos!");
                    }
                }
                else
                {
                    throw new Exception("Username ou Password incorretos!");
                }*/
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Erro");
            }
            finally
            {
                //myConnection.Close();
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
                if (!Regex.IsMatch(username, @"^[a-zA-Z0-9]+$")) { throw new Exception("Insira apenas letras e números no campo do username!"); }
                
                username = username.Trim();

                /*myConnection.Open();

                //Declara uma query que vai procurar o user com o username da textbox e executa
                MySqlCommand cmd = new MySqlCommand($"SELECT username FROM users where username LIKE '{username}'", myConnection);
                MySqlDataReader reader = cmd.ExecuteReader();

                //Verifica se o SELECT retorna algum dado
                if(reader.Read())
                {
                    throw new Exception("Username já existente!");
                }
                else
                {
                    cmd = new MySqlCommand($"INSERT INTO users (username, password) VALUES( '{username}', '{HashPassword(password)}');", myConnection);
                */
                    ChatForm chat = new ChatForm(username);
                    chat.Show();
                    this.Close();
                //}
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Erro");
            }
            finally
            {
                myConnection.Close();
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
    }
}
