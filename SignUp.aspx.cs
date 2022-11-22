using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace Time_Management_Web_Application
{
    public partial class SignUp : System.Web.UI.Page
    {
        //Method to encrypt password so that we do not see the users password in the database and their privacy is safe
        //using MD5CryptoServiceProvider because we will not need to decrypt users password.
        static string EncryptPassword(string value)
        {
            using (MD5CryptoServiceProvider mD5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = mD5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "" || txtUsername.Text == "" && txtPassword.Text != txtconPass.Text)
            {
                string message = $"Please enter the required fields and check that password and confirmed password match!";
                ClientScript.RegisterStartupScript(this.GetType(), "my alert", "alert('" + message + "');", true);
            }
            else
            {
                //creating a string for the SqlConnection object parameter
                string cs = $"Data Source=LAPTOP-31H3BH8T\\SQLEXPRESS;Initial Catalog=STUDENT_MODULES;Integrated Security=True";
                //Declaring sqlConnection object sCon
                SqlConnection sCon = new SqlConnection(cs);
                //opening the database from data source called in the cs string
                sCon.Open();
                string UserAdd = $"INSERT INTO USER_INFO VALUES(@USERNAME, @PASSWORD)";
                //Declaring sqlCommand object sCmd so that we can manipulate the data from the program instead of directly in the database
                SqlCommand sCmd = new SqlCommand(UserAdd, sCon);
                sCmd.Parameters.AddWithValue("@USERNAME", txtUsername.Text);
                sCmd.Parameters.AddWithValue("@PASSWORD", EncryptPassword(txtPassword.Text));
                sCmd.ExecuteNonQuery();
                sCon.Close();

                string confirm = $"User is now successfully registered";
                ClientScript.RegisterStartupScript(this.GetType(), "my alert", "alert('" + confirm + "');", true);

            }
            Response.Redirect("ModuleInformation.aspx");
        }
    }
}
