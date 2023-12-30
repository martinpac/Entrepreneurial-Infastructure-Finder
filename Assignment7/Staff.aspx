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
            <p>
            <b>Description:</b> This is the Staff Page where only the TA username can add staff personal to the Staff.xml. You cannot see the xml <br />
            (for security reasons here) but you can see it in the http://webstrar35.fulton.asu.edu/page4/ page that was provided in assignment 6. <br />
            You cannot add the same staff with the same password in twice or you will be dsiplayed an error message. 
        </p>
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

