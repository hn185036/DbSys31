using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dbsys.AppData;

namespace Dbsys
{
    
    public class UserRepository
    {
        DBSYSEntities db;

        private String _connStr;
        public UserRepository()
        {
            //_connStr  = Constant.ConString;
        }

        

        public int NewUser(String a_Username, String a_Pass, ref String outMessage)
        {
            int retValue = Constant.ERROR;
            try
            {
                db = new DBSYSEntities();
                // Create new object of USER_ACCOUNT
                UserAccount newUserAcc = new UserAccount();
                newUserAcc.userName = a_Username;
                newUserAcc.userPassword = a_Pass;
                newUserAcc.userStatus = "Active";
                // Call the add() function to insert object
                db.UserAccount.Add(newUserAcc);
                db.SaveChanges();

                outMessage = "Inserted";
                retValue = Constant.SUCESS;
            }
            catch (Exception ex)
            {
                outMessage = ex.Message;
                MessageBox.Show(ex.Message);
            }
            return retValue;
        }



        public int UpdateUser(int userId, String a_Username, String a_Pass, ref String outMessage)
        {
            int retValue = Constant.ERROR;
            try
            {
                db = new DBSYSEntities();
                // Find the user with id
                UserAccount user = db.UserAccount.Where(m => m.userId == userId).FirstOrDefault();
                // Update the value of the retrieved user
                user.userName = a_Username;
                user.userPassword = a_Pass;

                db.SaveChanges();       // Execute the update

                outMessage = "Updated";
                retValue = Constant.SUCESS;
            }
            catch (Exception ex)
            {
                outMessage = ex.Message;
                retValue = Constant.ERROR;
                MessageBox.Show(ex.Message);
            }
            return retValue;

        }

        public int RemoveUser(int userId, ref String outMessage)
        {
            int retValue = Constant.ERROR;
            try
            {

                db = new DBSYSEntities();

                UserAccount user = db.UserAccount.Where(m => m.userId == userId).FirstOrDefault();
                // Remove the user
                db.UserAccount.Remove(user);
                db.SaveChanges();       // Execute the update

                outMessage = "Deleted";
                retValue = Constant.SUCESS;
            }
            catch (Exception ex)
            {
                outMessage = ex.Message;
                retValue = Constant.ERROR;
                MessageBox.Show(ex.Message);
            }
            return retValue;

        }

        /*
        public List<vw_all_user_account> ListUsers()
        {
            List<vw_all_user_account> userList = new List<vw_all_user_account>();
            try
            {
                db = new ITDBSYS31Entities();

                userList = db.vw_all_user_account.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return userList;
        }
       

        public USER_ACCOUNT GetUserByUsername(String username)
        {
            USER_ACCOUNT ua = null;
            try
            {
                db = new ITDBSYS31Entities();
                // retrieve the user account
                ua = db.USER_ACCOUNT.Where(m => m.userName == username).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return ua;
        } 
         */
    }
}
