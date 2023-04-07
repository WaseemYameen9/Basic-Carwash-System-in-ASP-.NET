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
    public partial class CustomerDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = Configuration.getInstance().getConnection();
            try { 
            con.Open();
            }
            catch
            {

            }

            // Retrieve data from the SQL Server table using a SQL query
            SqlCommand cmd = new SqlCommand("Select carwash.Point_Name as [CarWash Name],carwash.Point_Address as Address,carwash.Point_City as City,Services.Service_Name as ServiceName,Services.Price from carwash inner join Services on carwash.id = Services.CarWashId", con);
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