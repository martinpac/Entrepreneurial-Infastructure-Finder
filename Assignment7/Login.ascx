<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="Assignment7.Login" %>

<%-- welcome message panel --%>
<asp:Panel runat="server" ID="WelcomeMessage">
    <asp:Label ID="WelcomeLabel" runat="server"></asp:Label>
</asp:Panel>

<%-- login controls panel --%>
<asp:Panel runat="server" ID="LoginPanel">
    <asp:Label ID="LoginLabel" runat="server" Text="Please Login"></asp:Label>
    <br />
    <br />
    <asp:Label ID="UserNameLabel" runat="server" Text="Username:"></asp:Label>
&nbsp;
    <asp:TextBox ID="UserNameTxtBox" runat="server" OnTextChanged="UserNameTxtBox_TextChanged"></asp:TextBox>
    <br />
    <asp:Label ID="PasswordLabel" runat="server" Text="Password:"></asp:Label>
&nbsp;
    <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" OnTextChanged="PasswordTextBox_TextChanged"></asp:TextBox> <br />
    <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" /> <br />
    <asp:Label ID="SuccessMsgLabel" runat="server"></asp:Label>
    <br /> 
</asp:Panel>
