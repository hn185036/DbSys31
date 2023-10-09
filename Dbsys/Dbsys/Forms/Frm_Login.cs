using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dbsys.AppData;
using Dbsys.Forms;

namespace Dbsys
{
    
    public partial class Frm_Login : Form
    {
        UserRepository userRepo;
        public Frm_Login()
        {
            InitializeComponent();
            //
            userRepo = new UserRepository();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUsername.Text))
            {
                errorProviderCustom.SetError(txtUsername, "Empty Field!");
                return;
            }
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                errorProviderCustom.SetError(txtPassword, "Empty Field!");
                return;
            }

            var userLogged = userRepo.GetUserByUsername(txtUsername.Text);

            if (userLogged != null)
            {
                if (userLogged.userPassword.Equals(txtPassword.Text))
                {
                    if (userLogged.roleId == 1)
                    {
                        new Frm_Student_Dashboard().Show();
                        this.Hide();
                    }
                    if (userLogged.roleId == 2)
                    {
                        new Frm_Teacher_DashBoard().Show();
                        this.Hide();
                    }
                    if (userLogged.roleId == 3)
                    {
                        new Frm_Teacher_DashBoard().Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Password");
                }
            }
            else
            {
                MessageBox.Show("Username not found");
            }

        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {

        }

        private void linkLabelRigester_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var frm = new Frm_Register())
            {
                frm.ShowDialog();
                txtUsername.Text = frm.username;
            }
        }
    }
}
