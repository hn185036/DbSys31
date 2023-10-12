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
                    // Assigned to a singleton
                    UserLogged.GetInstance().UserAccount = userLogged;

                    switch ((Role)userLogged.roleId)
                    {
                        case Role.Student:
                            // Load student Dashboard
                            new Frm_Student_Dashboard().Show();
                            this.Hide();
                            break;
                        case Role.Teacher:
                            // Load Teacher Dashboard
                            new Frm_Teacher_DashBoard().Show();
                            this.Hide();
                            break;
                        case Role.Admin:
                            // Load Admin Dashboard
                            new Frm_Admin_Dashboard().Show();
                            this.Hide();
                            break;
                        default:
                            MessageBox.Show("User has no role!");
                            break;
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
            // Instantiate new object of class Frm_Register
            Frm_Register frm = new Frm_Register();
            frm.ShowDialog();

            txtUsername.Text = frm.username;

            //using (var frm = new Frm_Register())
            //{
            //    frm.ShowDialog();
            //    txtUsername.Text = frm.username;
            //}
        }
    }
}
