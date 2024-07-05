using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using L.Business.Abstract;
using L.Business.Concrete;
using L.DataAccess.Concrete.EntityFramework;
using L.Entities.Concrete;

namespace L.WebFormsUI
{
    public partial class Login : Form
    {
        IUserService _userService;
        public Login()
        {
            InitializeComponent();
            _userService = new UserManager(new EfUserDal());
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                if (UserExists(tBUser.Text,tBPass.Text))
                {
                    MessageBox.Show("Login successful.");
                    Menu menu = new Menu();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username or password incorrect.");
                }

            }
            else
            {
                MessageBox.Show("You cannot leave the blanks empty.");
            }
        }
        
        bool ValidateInputs()
        {
            return !string.IsNullOrEmpty(tBUser.Text) && !string.IsNullOrEmpty(tBPass.Text);
        }

        bool UserExists(string username, string password)
        {
            var _user = _userService.AuthenticateUser(username, password);
            if (_user != null)
            {
                return true;
            }
            return false;
        }
    }
}
