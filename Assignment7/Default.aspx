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
            <h3><b>Business Relocation/Startup Location Application</b></h3>
            <h4>Created by: Ricardo Jardinez and Martin Pacheco</h4>
            <p>
            <b>Description:</b> This application is intended to be used for business looking to relocate to a different location in the U.S <br />
            or for start up businesses to find a location/city to build their businesses. They will be able to enter a State Abbreviation and Zip Code <br />
            of the area and various reports will apear for them to decide weather it will be a good fit to relocate or start at that location. <br />
            The various reports that will be displayed are, Weather, Taxes, Crime, Health, Poverty, and Population Reports <br />
            (only avaliable once you have signned up). 
            </p>
            <p>
            <b>Service Directory Link:</b> 
            </p>
            <p>
             <b>Signing Up:</b> Users can sign up to use our services by clicking on the "Members Page" button at the bottom of this page. <br />
                There you will be asked to enter your username and password, then verify you are a human with Google reCAPTCHA. <br />
                Once you have successfully signed up for our application, only then will you be immediately shown our services and can begin using them. 
            </p>
            <p>
            <b>Testing:</b> In order to test our application, please go to the Members Page (with the button) and sign up for our services. Then <br />
            you will be able to use and see our services we provide. You can then come back to this Default Page and there will no longer be a login <br />
            display since we have saved your cookies. You can also go to the Staff Page (with the button) and try to sign in, only the TA username has<br /> 
            access to edit/add staff members to the Staff.xml. You can go ahead and clear your cookies in your settings and see that our application<br />
            will sign you out of eveything and you will have to relogin. 
        </p>
        <p>
            <b>Notes:</b>Login display will only be shown if there are no cookies/record of you logined in before. So you can go ahead and close the browser <br />
            and reopen it and you will see you are still logged in (only if you clear cookies in your browser settings you will be propted to login in <br />
            or if the cookies expire). <br />
            If you have been logged in for over an hour and want to clear your cookies, then you might have to select the option to clear cookie over the <br />
            last 24 hours. 
        </p>
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
