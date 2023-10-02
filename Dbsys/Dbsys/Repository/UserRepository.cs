using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dbsys
{
    public class UserRepository
    {
        private String _connStr;
        public UserRepository()
        {
            _connStr  = Constant.ConString;
        }

        public int NewUser(String a_Username, String a_Pass, ref String outMessage)
        {
            int retValue = Constant.ERROR;
            try
            {
                String query = $"INSERT INTO USER_ACCOUNT VALUES('{a_Username}','{a_Pass}','ACTIVE')";
                using (SqlConnection con = new SqlConnection(_connStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    outMessage = "Success!";
                    //
                    retValue = Constant.SUCESS;

                }               
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
                String query = $"UPDATE USER_ACCOUNT SET userName='{a_Username}', userPassword = '{a_Pass}' WHERE userId = {userId}";
                using (SqlConnection con = new SqlConnection(_connStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    outMessage = "Updated!";
                    //
                    retValue = Constant.SUCESS;

                }

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
                String query = $"DELETE FROM USER_ACCOUNT WHERE userId = {userId}";
                using (SqlConnection con = new SqlConnection(_connStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    outMessage = "Deleted!";
                    //
                    retValue = Constant.SUCESS;

                }

            }
            catch (Exception ex)
            {
                outMessage = ex.Message;
                retValue = Constant.ERROR;
                MessageBox.Show(ex.Message);
            }
            return retValue;

        }

        public List<UserAccount> ListUsers()
        {
            List<UserAccount> userList = new List<UserAccount>();
            try
            {
                String query = $"SELECT * FROM USER_ACCOUNT";
                using (SqlConnection con = new SqlConnection(_connStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        UserAccount user = new UserAccount();
                        user.userId = (Int32)reader["userId"];
                        user.userName = reader["userName"] as String;
                        user.userPassword = reader["userPassword"] as String;
                        user.userStatus = reader["userStatus"] as String;

                        userList.Add(user);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return userList;
        }

        public UserAccount GetUserByUsername(String username)
        {
            UserAccount ua = null;
            try
            {
                String query = $"SELECT TOP 1 * FROM USER_ACCOUNT Where username='{username}'";
                using (SqlConnection con = new SqlConnection(_connStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    //
                    while (reader.Read())
                    {
                        ua = new UserAccount();
                        ua.userId = (Int32)reader["userId"];
                        ua.userName = reader["userName"] as String;
                        ua.userPassword = reader["userPassword"] as String;
                        ua.userStatus = reader["userStatus"] as String;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return ua;
        } 
    }
}
