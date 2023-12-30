<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="Assignment7.Staff" %>
<%@ Register TagPrefix="user" TagName="Login" Src="Login.ascx" runat="server" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:panel id="AddStaff" runat="server">
            <div style="text-align: center;">
                <h1>Staff Page</h1>
            </div>
        <div>
            <asp:Label ID="WelcomeLabel" runat="server"></asp:Label>
        </div>
        <div>
            <br />
            <br />
            Username:
            <asp:TextBox ID="UsernameBox" runat="server"></asp:TextBox>
            <br />
            Password:
            <asp:TextBox ID="PasswordBox" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="AddStaffButton" runat="server" Text="Add Staff" OnClick="AddStaffButton_Click" />
            <br />
            <br />
            <asp:Label ID="SuccessLabel" runat="server"></asp:Label>
        </div>
        </asp:panel>
            <div style="height: 154px">
            <user:Login ID="StaffLogin" runat="server" />
            <asp:Button ID="Button1" runat="server" Text="Default Page" Width="115px" PostBackUrl="Default.aspx" /> &nbsp
            </div>
    </form>
</body>
</html>

