<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment7._Default" %>
<%@ Register TagPrefix="user" TagName="Login" Src="Login.ascx" runat="server" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Default Page</title>
</head>
<body style="height: 432px">
    <form id="form1" runat="server">
        <div style="text-align: center;">
            <h1>Default Page</h1>
        </div>
        <asp:Label ID="StatusLabel" runat="server"></asp:Label>
        <div>
            <h3><b>Entrepreneurial Infastructure Finder Website Application</b></h3>
            <h4>Created by: Ricardo Jardinez and Martin Pacheco</h4>
        </div>
        <div style="height: 140px">
            <user:Login runat="server" />
        </div>
        
        <div>
            <asp:Button ID="MemberPageButton" runat="server" Text="Member Page" Width="115px" OnClick="MemberPageButton_Click" PostBackUrl="~/Member.aspx" /> &nbsp
            <asp:Button ID="StaffPageButton" runat="server" Text="Staff Page" PostBackUrl="Staff.aspx" />
        </div>
    </form>
</body>
</html>
