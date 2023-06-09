﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminCarServices.aspx.cs" Inherits="carWash.AdminCarServices" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

nav {
  background-color: black;
  padding: 10px;
}

ul {
  list-style: none;
  margin: 0;
  padding: 0;
  display: flex;
  justify-content: center;
}

li {
  margin: 0 20px;
}

a {
  text-decoration: none;
  color: white;
  font-weight: bold;
  font-size: 18px;
  transition: all 0.3s ease;
}

a:hover {
  color: #ffcc00;
}

@media (max-width: 768px) {
  li {
    margin: 0 10px;
  }
  a {
    font-size: 14px;
  }
}


.auto-style10 {
	width: 869px;
	right: 0px;
	height: 104px;
}
.auto-style11 {
	width: 949px;
	height: 104px;
	}
.auto-style12 {
	height: 104px;
}
.auto-style13 {
	width: 869px;
	right: 0px;
	height: 81px;
}
.auto-style14 {
	width: 949px;
	height: 81px;
}
.auto-style15 {
	height: 81px;
}
.auto-style16 {
	width: 869px;
	right: 0px;
	height: 82px;
}
.auto-style17 {
	width: 949px;
	height: 82px;
}
.auto-style18 {
	height: 82px;
}
.auto-style20 {
	width: 341px;
	height: 30px;
}

.auto-style21 {
	width: 340px;
	height: 30px;
		
}
.btn{
	margin-top:60px;
	background-color: #007bff;
	border-color: #007bff;
	color: #fff;
	padding: 5px 10px;
	border-radius: 5px;
	font-size: 13px;
}
.btn1-css{
	margin-left:370px;

}
.btn2-css{
	margin-left:80px;

}
.btn3-css{
	margin-left:80px;

}
#Gridview1 {
	font-family: Arial, sans-serif;
	border-collapse: collapse;
	background-color: #f8f8f8;
	width: 100%; /* Set table width to 100% */
	margin-top:100px;
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



.auto-style22 {
	width: 100%;
	height: 350px;
}

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
.btnn
{
	margin-left:1000px;
}


.auto-style23 {
	width: 356px;
	height: 36px;
}


</style>

</head>

<body>
     <header>
		<h1>Car Wash System</h1>
	</header>

    <form id="form1" runat="server">
       <br />
		<asp:Button ID="GotoCarServices" runat="server" Text="Carwash Points" CssClass="btn btnn" OnClick="GotoCarServices_Click" />
    	<br />
		<table class="auto-style22">
			<tr>
				<td class="auto-style16">Select Carwash Name:</td>
				<td class="auto-style17">
					<select id="carwashName" class="auto-style23" name="D1" runat="server">
						<option></option>
					</select></td>
				<td class="auto-style18"></td>
			</tr>
			<tr>
				<td class="auto-style13">Enter Service:</td>
				<td class="auto-style14">
					<input id="ServiceTxt" class="auto-style21" type="text" runat="server" /></td>
				<td class="auto-style15"></td>
			</tr>
			<tr>
				<td class="auto-style10">Enter Service Price:</td>
				<td class="auto-style11">
					<input id="PriceTxt" class="auto-style20" type="text" runat="server"/></td>
				<td class="auto-style12"></td>
			</tr>
			<tr>
				<td class="auto-style10" id="errortxt" runat="server">&nbsp;</td>
				<td class="auto-style11">
					&nbsp;</td>
				<td class="auto-style12">&nbsp;</td>
			</tr>
		</table>
		<asp:Button ID="AddBtn" runat="server" Text="Add" CssClass="btn1-css btn" OnClick="AddBtn_Click"  />
		<asp:Button ID="UpdateBtn" runat="server" Text="Update" CssClass="btn2-css btn" OnClick="UpdateBtn_Click"  />
		<asp:Button ID="DeleteBtn" runat="server" Text="Delete" CssClass="btn3-css btn" OnClick="DeleteBtn_Click"  />
       
		 
        <asp:GridView ID="Gridview1" runat="server"  OnRowCommand="Gridview1_RowCommand" >
		<Columns>
        <asp:ButtonField ButtonType="Button" CommandName="CellClick" Text="Select" />
        </columns>
			</asp:GridView>
    </form>
</body>
</html>
