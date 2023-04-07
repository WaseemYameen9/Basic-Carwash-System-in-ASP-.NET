<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerDashboard.aspx.cs" Inherits="carWash.CustomerDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
    <style type="text/css">

header {
  background-color: black;
  padding: 10px;
}

h1 {
  color: white;
  font-size: 36px;
  margin: 0;
  text-align: center;
}
/* Set font and background color for the entire table */
#Gridview1 {
  font-family: Arial, sans-serif;
  border-collapse: collapse;
  background-color: #f8f8f8;
  width: 100%; /* Set table width to 100% */
}

/* Set font and background color for the table header */
#Gridview1 th {
  background-color: #006699;
  color: #fff;
  font-weight: bold;
  padding: 10px;
  text-align: left;
  border-bottom: 2px solid #ddd;
}

/* Set font and background color for the table cells */
#Gridview1 td {
  padding: 8px;
  border-bottom: 1px solid #ddd;
}

/* Set background color for alternate rows */
#Gridview1 tr:nth-child(even) {
  background-color: #e6e6e6;
}

/* Set background color for table rows on mouse hover */
#Gridview1 tr:hover {
  background-color: #ddd;
}

/* Remove fixed widths on the columns */
#Gridview1 td, #Gridview1 th {
  width: auto !important;
  max-width: none !important;
}

</style>
</head>
<body>
    <header>
        <h1>Car Wash System</h1>
     </header>

    <form id="form1" runat="server">
        <asp:GridView ID="Gridview1" runat="server"></asp:GridView>
    </form>
    

</body>
</html>
