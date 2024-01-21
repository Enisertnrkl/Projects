using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Stockmanagement
{
 
    public partial class Login : Form
    {

		public Login()
        {

            InitializeComponent();
        }
        //Textboxların boş olup olmadığını kontrol eder
        private bool CheckInputs()
        {
           return !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text);
        }
        
        //username ve password ün veritabanında bir satırı olup olmadığına bakarak bool döndürür
        private bool ValidateUser(string username,string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Database.DatabaseString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT Username,Password FROM UserList WHERE Username = @username AND Password = @password",conn))
                    {
                        cmd.Parameters.AddWithValue("username", username);
                        cmd.Parameters.AddWithValue("password", password);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            return reader.HasRows;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası",ex.Message);
                return false;
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

			//kullanıcı adı ve şifre boş değil ise
			if (CheckInputs())
            {
                //kullanıcı adı ve şifrenin veritabanında satırı var ise
                if (ValidateUser(textBox1.Text, textBox2.Text))
                {

                    UserCredentials.UserManager.GetCurrentUserInfo(textBox1.Text);
					MessageBox.Show($"Hoşgeldiniz,  {UserCredentials.Name} {UserCredentials.LastName}");
					Menu menu = new Menu();
                    menu.Show();
                    this.Hide();
                }
                //kullanıcı adı ve şifrenin veritabanında satırı yok ise
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre yanlış");
                }
            }
			//kullanıcı adı ve şifre boş ise
			else
				MessageBox.Show("Kullanıcı adı veya şifre boş olamaz!");
        }
    }


}
