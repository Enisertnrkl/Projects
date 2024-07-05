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
    public partial class Register : Form
    {
        readonly IUserService _userService;
        public Register()
        {
            _userService = new UserManager(new EfUserDal());
            InitializeComponent();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                var user = CreateUser();
                try
                {
                    _userService.Add(user);
                    MessageBox.Show("You have successfuly registered.");
                    this.Hide();
                    Login login = new Login();
                    login.Show();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show($"There was an error while registering.{ex.Message}");
                    ;
                }
            }
            else
            {
                MessageBox.Show("You cannot leave blanks empty.");
            }

        }

        bool ValidateInputs()
        {
            return !string.IsNullOrEmpty(tBUser.Text) && !string.IsNullOrEmpty(tBEmail.Text) &&
                   !string.IsNullOrEmpty(tBPhone.Text) && !string.IsNullOrEmpty(tBPass.Text);
        }

        private User CreateUser()
        {
            return new User()
            {
                UserName = tBUser.Text,
                UserEmail = tBEmail.Text,
                UserPhone = tBPhone.Text,
                Password = tBPass.Text
            };
        }

        private void btnGologin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }
    }
}
