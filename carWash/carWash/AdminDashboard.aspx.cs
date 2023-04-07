using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace carWash
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        public static int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            tableLoad();
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            try
            {
                con.Open();
            }
            catch
            {

            }
            SqlCommand cmd = new SqlCommand("Insert into carwash values (@Name, @Address, @City)", con);
            cmd.Parameters.AddWithValue("@Name", Nametxt.Value.ToString());
            cmd.Parameters.AddWithValue("@Address", Addresstxt.Value.ToString());
            cmd.Parameters.AddWithValue("@City", citytxt.Value.ToString());
            cmd.ExecuteNonQuery();
            Response.Redirect("AdminDashboard.aspx");
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            try
            {
                con.Open();
            }
            catch
            {

            }
           try
           {
                SqlCommand cmd = new SqlCommand("Delete from carwash where id=@id", con);
                cmd.Parameters.AddWithValue("@id",id);
                cmd.ExecuteNonQuery();
                Response.Redirect("AdminDashboard.aspx");
           }
           catch
           {
             Response.Redirect("AdminDashboard.aspx");
           }

        }
        protected void Gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "CellClick")
            {
                // Get the index of the row where the cell was clicked
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                TableCell cell = Gridview1.Rows[rowIndex].Cells[1];
                id = Convert.ToInt32(cell.Text);
                TableCell cell1 = Gridview1.Rows[rowIndex].Cells[2];
                string Name = cell1.Text;
                TableCell cell2 = Gridview1.Rows[rowIndex].Cells[3];
                string Address = cell2.Text;
                TableCell cell3 = Gridview1.Rows[rowIndex].Cells[4];
                string city = cell3.Text;
                Nametxt.Attributes["value"] = Name;
                Addresstxt.Attributes["value"] = Address;
                citytxt.Attributes["value"] = city;
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            try
            {
                con.Open();
            }
            catch
            {

            }
            try
            {
                SqlCommand cmd = new SqlCommand("Update carwash SET Point_Name=@name,Point_Address=@address,Point_City=@city where id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", Nametxt.Value.ToString());
                cmd.Parameters.AddWithValue("@address", Addresstxt.Value.ToString());
                cmd.Parameters.AddWithValue("@city", citytxt.Value.ToString());
                cmd.ExecuteNonQuery();
                Response.Redirect("AdminDashboard.aspx");
            }
            catch
            {
                Response.Redirect("AdminDashboard.aspx");
            }


        }
        protected void check()
        {
            Response.Redirect("SignUp.aspx");
        }

        protected void GotoCarServices_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminCarServices.aspx");
        }

        protected void tableLoad()
        {
            SqlConnection con = Configuration.getInstance().getConnection();
            try
            {
                con.Open();
            }
            catch
            {

            }

            // Retrieve data from the SQL Server table using a SQL query
            SqlCommand cmd = new SqlCommand("Select * from carwash", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Bind the data to the HTML table in the web form
            Gridview1.DataSource = dt;
            Gridview1.DataBind();

            // Close the database connection
            con.Close();
        }
    }
}