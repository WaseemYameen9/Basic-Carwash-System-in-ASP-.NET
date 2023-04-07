using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace carWash
{
    public partial class Loginaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void loginBtn_Click(object sender, EventArgs e)
        {
            Response.Write("Invalid User");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();

            try
            {
                con.Open(); // Open the SqlConnection object
            }
            catch
            {

            }
            SqlCommand cmd = new SqlCommand("Select Role from Users where Email=@email and Password=@password", con);
            cmd.Parameters.AddWithValue("@email", emailTxt.Value);
            cmd.Parameters.AddWithValue("@password", passwordTxt.Value);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read(); // Advance to the first row
                string role = reader.GetString(0);
                if (role == "admin")
                {
                    reader.Close();
                    con.Close();
                    Response.Redirect("AdminDashboard.aspx");
                }
                else
                {
                    reader.Close();
                    con.Close();
                    Response.Redirect("CustomerDashboard.aspx");
                }
            }
            else
            {
                reader.Close();
                con.Close();
                Response.Write("Invalid User");
            }

        }

        protected void SignUpBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }
    }
}