using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Time_Management_Web_Application
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static string SetValueForUsername = "";
        public static string SetValueForPassword = "";
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            //This code is for when we send usernames to the next window
            SetValueForUsername = txtUsername.Text;
            SetValueForPassword = txtPassword.Text;

        string  error = $"Password or Username is incorrect. Please re-enter the fields.";
            string cs = $"Data Source=LAPTOP-31H3BH8T\\SQLEXPRESS;Initial Catalog=STUDENT_MODULES;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(cs))
            {
                string scmd = $"SELECT COUNT(*) FROM USER_INFO WHERE USERNAME = '{txtUsername.Text}' AND PASSWORD = '{txtPassword.Text}'";
                SqlDataAdapter sda = new SqlDataAdapter(scmd, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if(dt.Rows[0][0].ToString() == "1")
                {
                    Response.Redirect("ModuleInformation.aspx");   
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "my alert", "alert('" + error + "');", true);
                //Use username Thabi1502 and password 170345JUICY to login
            }
        }
    }
}