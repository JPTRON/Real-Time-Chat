using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Server
{
    internal class BDHandler
    {
        string server = "127.0.0.1";
        string port = "3306";

        public string CompareCredentials(string username, string password)
        {
            MySqlConnection myConnection = new MySqlConnection($"Server={server};Port={port};Database=usersts;Uid=root;Pwd=;");

            try
            {
                myConnection.Open();

                //Declara uma query que vai procurar o user com o username da textbox e executa
                MySqlCommand cmd = new MySqlCommand($"SELECT username, password FROM users where username LIKE '{username}'", myConnection);
                MySqlDataReader reader = cmd.ExecuteReader();            

                //Verifica se o SELECT retorna algum dado
                if(reader.Read())
                {                

                    if (password == reader["password"].ToString())
                    {
                        return "true";
                    }
                    else
                    {
                        throw new Exception("Username ou Password incorretos!");
                    }
                }
                else
                {
                    throw new Exception("Username ou Password incorretos!");
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                myConnection.Close();
            }
        }
        
        public string RegisterUser(string username, string password)
        {
            MySqlConnection myConnection = new MySqlConnection($"Server={server};Port={port};Database=usersts;Uid=root;Pwd=;");

            try
            {
                myConnection.Open();

                //Declara uma query que vai procurar o user com o username da textbox e executa
                MySqlCommand cmd = new MySqlCommand($"SELECT username FROM users where username LIKE '{username}'", myConnection);
                MySqlDataReader reader = cmd.ExecuteReader();

                //Verifica se o SELECT retorna algum dado
                if (reader.Read())
                {
                    throw new Exception("Username já existente!");
                }
                else
                {
                    reader.Close();
                    cmd = new MySqlCommand($"INSERT INTO users (username, password) VALUES( '{username}', '{password}');", myConnection);
                    cmd.ExecuteNonQuery();
                    return "true";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                myConnection.Close();
            }
        }
    }
}
