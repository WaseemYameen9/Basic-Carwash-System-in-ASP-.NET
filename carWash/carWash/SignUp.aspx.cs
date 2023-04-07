using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace carWash
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            try
            {
                con.Open();
            }
            catch
            {

            }
            SqlCommand cmd = new SqlCommand("Insert into Users values (@Email, @Password, @Role)", con);
            cmd.Parameters.AddWithValue("@Email", emailTxt.Value.ToString());
            cmd.Parameters.AddWithValue("@Password", passwordtxt.Value.ToString());
            cmd.Parameters.AddWithValue("@Role", roleCB.Value.ToString());
            cmd.ExecuteNonQuery();
            Response.Redirect("Loginaspx.aspx");
        }
    }
}