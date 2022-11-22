using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using TimeManagementCalculations;


namespace Time_Management_Web_Application
{
    public partial class RemainderOfHours : System.Web.UI.Page
    {

        //Setting value for Module Name so that it can be used in other windows
        public static string SetValueForModuleName = "";
        

        //declaring users class
        Users use = new Users();

        
        protected void Page_Load(object sender, EventArgs e)
        {   
            
        }

        protected void BtnSubmitHours_Click(object sender, EventArgs e)
        {
            //continuation of sending code to users class
            SetValueForModuleName = txtmodName.Text;

            #region Calculation Of Self Study Hours
            //this is where we calculate the self-study-hours
            int hoursRemaining;
            //declaring the dll class
            Calculations cal = new Calculations();

            hoursRemaining = cal.SelfStudyHoursRemainder(Convert.ToInt32(txtHoursDone.Text));
            string hoursRemString = $"The Hours remaining for Module: {txtmodName.Text} is {hoursRemaining} on {txtDateUpdated.Text}";
            ClientScript.RegisterStartupScript(this.GetType(), "my alert", "alert('" + hoursRemString + "');", true);
            #endregion

            #region Adding to Hours_Remainder table
            string cs = $"Data Source=LAPTOP-31H3BH8T\\SQLEXPRESS;Initial Catalog=STUDENT_MODULES;Integrated Security=True";
            //The using function automatically closes the sql connection object so there is no need to worry about it
            using (SqlConnection con = new SqlConnection(cs))
            {
                string ModuleAdd = $"INSERT INTO HOURS_REMAINDER VALUES(@MODULE_CODE, @USER_ID, @HOURS_DONE, @DATE_UPDATED, @HOURS_REMAINING)";

                SqlCommand cmd = new SqlCommand(ModuleAdd, con);
                con.Open();
                cmd.Parameters.AddWithValue("@MODULE_CODE", use.GetModuleCode());
                cmd.Parameters.AddWithValue("@USER_ID", use.GetUserID());
                cmd.Parameters.AddWithValue("@HOURS_DONE", Convert.ToInt32(txtHoursDone.Text.Trim()));
                cmd.Parameters.AddWithValue("@DATE_UPDATED", txtDateUpdated.Text.Trim());
                cmd.Parameters.AddWithValue("@HOURS_REMAINING", hoursRemaining);
                cmd.ExecuteNonQuery();
            }
            #endregion
        }

        protected void BtnViewGraph_Click(object sender, EventArgs e)
        {
            //(C-sharpcorner.com, 2021)
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-31H3BH8T\\SQLEXPRESS;Initial Catalog=STUDENT_MODULES;Integrated Security=True");
            DataSet ds = new DataSet();
            string ssda = $"SELECT * FROM HOURS_REMAINDER WHERE USER_ID = '{use.GetUserID()}' AND MODULE_CODE = '{use.GetModuleCode()}'";
            SqlDataAdapter da = new SqlDataAdapter(ssda, con);
            con.Open();
            da.Fill(ds);
            hoursRemChart.DataSource = ds;
            con.Close();
        }
    }
}