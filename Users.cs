using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;

namespace Time_Management_Web_Application
{
    public class Users
    {
        int userId;
        string modCode;
        public int GetUserID()
        {
            string cs = $"Data Source=LAPTOP-31H3BH8T\\SQLEXPRESS;Initial Catalog=STUDENT_MODULES;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(cs))
            {   
                string scmd = $"SELECT * FROM USER_INFO";
                SqlCommand cmd = new SqlCommand(scmd, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    string username = Convert.ToString(sdr["USERNAME"]);
                    int userid = Convert.ToInt32(sdr["USER_ID"]);
                    
                    if(username == Login.SetValueForUsername)
                    {
                       return userId = userid;
                    }
                }
                int id = userId;
                return id;
            }
        }

        public string GetModuleCode()
        {
            string cs = $"Data Source=LAPTOP-31H3BH8T\\SQLEXPRESS;Initial Catalog=STUDENT_MODULES;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(cs))
            {
                string scmd = $"SELECT * FROM MODULES";
                SqlCommand cmd = new SqlCommand(scmd, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    string modName = Convert.ToString(sdr["MODULE_NAME"]);
                    string moduleCode = Convert.ToString(sdr["MODULE_CODE"]);

                    if (modName == RemainderOfHours.SetValueForModuleName)
                    {
                        return modCode = moduleCode;
                    }
                }
                string code = modCode;
                return code;
            }
        }
    }
}
