using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            UserAccount userLogin = userRepo.GetUserByUsername(txtUsername.Text);
            // User exist
            if (userLogin != null)
            {

            }
            else
            {
                MessageBox.Show("User Not Exist");
            }

        }
    }
}
