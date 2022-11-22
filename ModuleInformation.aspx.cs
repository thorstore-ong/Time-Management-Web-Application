using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Time_Management_Web_Application;
using TimeManagementCalculations;
using System.Threading;

namespace Time_Management_Web_Application
{
    public partial class ModuleInformation : System.Web.UI.Page
    {
        Users use = new Users();

        //instantiating multi-threading
        Thread t = new Thread(ClickButton);
        Thread t1 = new Thread(ClickButton);


        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        
        protected void BtnView_Click(object sender, EventArgs e)
        {
           // creating threading for better responsiveness
            btnView.Enabled = false;
            t1.Start();

            btnView.Enabled = true;


            //loading the Module database by binding it to the gridview in our window
            string cs = "Data Source=LAPTOP-31H3BH8T\\SQLEXPRESS;Initial Catalog=STUDENT_MODULES;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
                    string scomd = $"SELECT * FROM MODULES WHERE USER_ID = '{use.GetUserID()}' ";
                    SqlCommand cmd = new SqlCommand(scomd, con);
                    con.Open();
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    con.Close(); 

            }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            #region Calculation Of Self Study Hours
            //this is where we calculate the self-study-hours
            int selfStudy;
            //declaring the dll class
            Calculations cal = new Calculations();
                selfStudy = cal.SelfStudyHoursCalculation(Convert.ToInt32(txtMCred.Text), Convert.ToInt32(txtNumOfWeeks.Text), Convert.ToInt32(txtClassHours.Text));
            string selfStudyString = $"For the Module {txtMName} there are about {selfStudy} of Self study hours";
            ClientScript.RegisterStartupScript(this.GetType(), "my alert", "alert('" + selfStudyString + "');", true);
            #endregion

            #region Adding the Modules
            string cs = $"Data Source=LAPTOP-31H3BH8T\\SQLEXPRESS;Initial Catalog=STUDENT_MODULES;Integrated Security=True";
            //The using function automatically closes the sql connection object so there is no need to worry about it
            using (SqlConnection con = new SqlConnection(cs))
            {
                string ModuleAdd = $"INSERT INTO MODULES VALUES(@MODULE_CODE, @MODULE_NAME, @CREDITS, @CLASS_HOURS, @START_DATE, @SEMESTER_TYPE, @NUM_OF_WEEKS, @SELF_STUDY_HOURS, @USER_ID)";

                SqlCommand cmd = new SqlCommand(ModuleAdd, con);
                con.Open();
                cmd.Parameters.AddWithValue("@MODULE_CODE", txtMCode.Text.Trim());
                cmd.Parameters.AddWithValue("@MODULE_NAME", txtMName.Text.Trim());
                cmd.Parameters.AddWithValue("@CREDITS", Convert.ToInt32(txtMCred.Text.Trim()));
                cmd.Parameters.AddWithValue("@CLASS_HOURS", Convert.ToInt32(txtClassHours.Text.Trim()));
                cmd.Parameters.AddWithValue("@START_DATE", txtStartDate.Text.Trim());
                cmd.Parameters.AddWithValue("@SEMESTER_TYPE", ddSemester.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@NUM_OF_WEEKS", Convert.ToInt32(txtNumOfWeeks.Text.Trim()));
                cmd.Parameters.AddWithValue("@SELF_STUDY_HOURS", selfStudy);
                cmd.Parameters.AddWithValue("@USER_ID", use.GetUserID());
                cmd.ExecuteNonQuery();
            }
            #endregion

        }
        //this is the main thread
        public static void ClickButton()
        {
            Thread.Sleep(5000);
        }
        protected void BtnHoursRem_Click(object sender, EventArgs e)
        {
            //using multi-threading
            btnHoursRem.Enabled = false;
            t.Start();

            btnHoursRem.Enabled = true;

            Response.Redirect("RemainderOfHours.aspx");
            
        }
    }
    }
//Reference list 
//    Fiqri Ismail (2018). .NET STANDARD 2.0 COOKBOOK : dive deep into .net standard 2.0. Packt.IAmTimCorey (2017a). C# Essentials: Linq for Lists - Sorting, Filtering, and Aggregating Lists Easily. YouTube. Available at: https://www.youtube.com/watch?v=yClSNQdVD7g&list=WL&index=4&t=1474s&ab_channel=IAmTimCorey [Accessed 20 Sep. 2021].
//    IAmTimCorey (2017). Intro to WPF: Learn the basics and best practices of WPF for C#. YouTube. Available at: https://www.youtube.com/watch?v=gSfMNjWNoX0&list=PLLWMQd6PeGY3QEHCmCWaUKNhmFFdIDxE8&ab_channel=IAmTimCorey [Accessed 20 Sep. 2021].
//    Paldia, S. (2021). Creating Class Library in Visual C#. [online] C-sharpcorner.com. Available at: https://www.c-sharpcorner.com/UploadFile/61b832/creating-class-library-in-visual-C-Sharp/ [Accessed 20 Sep. 2021].
//    sluiter (2020). Class Library Project example in C# with Visual Studio Solution tutorial. YouTube. Available at: https://www.youtube.com/watch?v=HOpCbl9Ky_g&list=WL&index=1&ab_channel=shadsluiter [Accessed 20 Sep. 2021].
//    Toshi (2017). Use Linq Select to display data. [online] Stack Overflow.
//    C-sharpcorner.com. (2021). Chart Control in ASP.NET. [online] Available at: https://www.c-sharpcorner.com/UploadFile/63f5c2/chart-control-in-Asp-Net/ [Accessed 17 Nov. 2021].
//    
