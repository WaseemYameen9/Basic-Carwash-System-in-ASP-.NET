using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace carWash
{
    public partial class AdminCarServices : System.Web.UI.Page
    {
        public static int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            cBLoad();
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
            SqlCommand cmd = new SqlCommand("Insert into Services values (@carwashid, @servicename, @price)", con);
            int Cid = getCarWashId(carwashName.Value.ToString());
            cmd.Parameters.AddWithValue("@carwashid", Cid);
            cmd.Parameters.AddWithValue("@servicename", ServiceTxt.Value.ToString());
            cmd.Parameters.AddWithValue("@price",Convert.ToInt32(PriceTxt.Value.ToString()));
            cmd.ExecuteNonQuery();
            Response.Redirect("AdminCarServices.aspx");
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
                SqlCommand cmd = new SqlCommand("Delete from Services where id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                Response.Redirect("AdminCarServices.aspx");
            }
            catch
            {
                Response.Redirect("AdminCarServices.aspx");
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
                string carWashName = cell1.Text;
                TableCell cell2 = Gridview1.Rows[rowIndex].Cells[5];
                string Service = cell2.Text;
                TableCell cell3 = Gridview1.Rows[rowIndex].Cells[6];
                string Price = cell3.Text;
                
                // Get a reference to the HtmlSelect control
                HtmlSelect mySelect = (HtmlSelect)FindControl("carwashName");
                // Set the selected value of the control
                mySelect.Value = carWashName;
                ServiceTxt.Attributes["value"] = Service;
                PriceTxt.Attributes["value"] = Price;
                
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
                SqlCommand cmd = new SqlCommand("Update Services SET CarWashId=@carwashid,Service_Name=@service,Price=@price where id=@id", con);
                int CiD = getCarWashId(carwashName.Value.ToString());
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@carwashid", CiD);
                cmd.Parameters.AddWithValue("@service", ServiceTxt.Value.ToString());
                cmd.Parameters.AddWithValue("@price", PriceTxt.Value.ToString());
                cmd.ExecuteNonQuery();
                Response.Redirect("AdminCarServices.aspx");
            }
            catch
            {
                Response.Redirect("AdminCarServices.aspx");
            }


        }

        protected void GotoCarServices_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDashboard.aspx");
        }

        protected int getCarWashId(string carwashName)
        {
            var con = Configuration.getInstance().getConnection();
            try
            {
                con.Open();
            }
            catch
            {

            }
            SqlCommand cmd = new SqlCommand("Select id from carwash where Point_Name=@name", con);
            cmd.Parameters.AddWithValue("@name",carwashName);
            object result = cmd.ExecuteScalar();
            int value = (int)result;
            return value;

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
            SqlCommand cmd = new SqlCommand("Select Services.id as [ServiceID],carwash.Point_Name as [CarWash Name],carwash.Point_Address as Address,carwash.Point_City as City,Services.Service_Name as ServiceName,Services.Price from carwash inner join Services on carwash.id = Services.CarWashId", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Bind the data to the HTML table in the web form
            Gridview1.DataSource = dt;
            Gridview1.DataBind();

            // Close the database connection
            con.Close();

        }

        protected void cBLoad()
        {
            SqlConnection connection = Configuration.getInstance().getConnection();

            string query = "SELECT Point_Name FROM carwash";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
            }
            catch
            {

            }
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string name = reader.GetString(0);
                ListItem item = new ListItem(name);
                carwashName.Items.Add(item);
            }

            reader.Close();
            connection.Close();
        }
    }
}