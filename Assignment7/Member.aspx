<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Assignment7.Member" %>
<%@ Register TagPrefix="user" TagName="Login" Src="Login.ascx" runat="server" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<script src="https://www.google.com/recaptcha/api.js" async defer></script>

    <title>Member Page</title>
    <style type="text/css">
        #WeatherReportTxtArea {
            width: 500px;
            height: 250px;
        }
        #TaxReportTxtArea {
            width: 500px;
            height: 249px;
        }
        #CrimeReportTxtArea {
            width: 500px;
            height: 250px;
        }
        #HealthReportTxtArea {
            width: 500px;
            height: 250px;
        }
        #PovertyReportTxtArea {
            width: 500px;
            height: 250px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center;">
        <h1>Member Page</h1>
    </div>
    <div>
        <asp:Label ID="WelcomeLabel" runat="server"></asp:Label>
        <br />
    </div>
        <div>
        <p>
           <b><u>Functions/Features Descriptions</u></b> <br />
           <b>Population Service Description:</b> With the state abbreviation, it will return the most recent population of that state. <br />
           <b> Weather Service Description: </b>Takes a zipcode and returns a weather report for the next 5 days including temperature,wind speed, description, etc. <br />
           <b>Taxes Service Description:</b>Takes a zipcode and returns a tax report contianing city, county, and state taxes <br />
           <b>Crime Service Description:</b> Takes a state abbreviation and returns the numebr of crimes for burglary, arson, fraud, etc for that state <br />
           <b>Health Service Description:</b> Takes a state abbreviation and returns the number of people insured and uninsured for each county for that state <br />
           <b>Poverty Service Description:</b> Takes a state abbreviation and returns the number and percentage of people living in poverty for that state <br />
        </p>
        </div>
    <asp:panel id="SignUp" runat="server">
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

        <div class="g-recaptcha" data-sitekey="6LdFfRkpAAAAANF6GXRLp3FfQWAKa_BFas_EbyJz">
        </div>
        
        <!-- webstrar host key
        <div class="g-recaptcha" data-sitekey="6LcKkh0pAAAAAOio64QK7YF5hgTzafAtsScf2PGC">
        </div>
            -->
        &nbsp;<br />
        <asp:Button ID="SignUpButton" runat="server" OnClick="SignUpButton_Click" Text="Sign Up" />
        <br />
        <br />
    </div>
    </asp:panel>
    <div>
        <asp:Label ID="SuccessMsgLabel" runat="server"></asp:Label>
    </div>
        <asp:panel runat="server" ID="Services">
            <div>
        <p>
            <asp:Label ID="StateAbbreviationLabel" runat="server" Text="Enter State Abbreviation:"></asp:Label> &nbsp
            <asp:TextBox ID="StateAbbreviationInputTxtBox" runat="server" Width="110px" Height="25px" OnTextChanged="StateAbbreviationInputTxtBox_TextChanged"></asp:TextBox>&nbsp
            <asp:Label ID="ZipCodeLabel" runat="server" Text="Enter Zipcode:"></asp:Label>&nbsp
            <asp:TextBox ID="ZipcodeInputTxtBox" runat="server" Height="25px" Width="100px" OnTextChanged="ZipcodeInputTxtBox_TextChanged"></asp:TextBox>&nbsp
            <asp:Button ID="GetReportsButton" runat="server" Height="30px" Text="Get Reports" Width="218px" OnClick="GetReportsButton_Click" />
            &nbsp;</p>
            <p>
                <asp:Label ID="FailLabel" runat="server"></asp:Label>
                <br />
                <asp:Label ID="PopulationLabel" runat="server" Text="Population:"></asp:Label>
                &nbsp;<asp:Label ID="PopulationDisplayLabel" runat="server"></asp:Label>
                <br />
                <br />
                &nbsp;<asp:Label ID="WeatherReportLabel" runat="server" Text="Weather Report:"></asp:Label>
                <br />
                <textarea id="WeatherReportTxtArea" runat="server" name="S1" style="resize:none"></textarea>&nbsp;
            </p>
        <p>
            <asp:Label ID="TaxReportLabel" runat="server" Text="Taxes Report: "></asp:Label><br />
            <textarea id="TaxReportTxtArea" runat="server" name="S5" style="resize:none"></textarea>&nbsp
        </p>
        <p>

            <asp:Label ID="CrimeReportLabel" runat="server" Text="Crime Report:"></asp:Label><br />
            <textarea id="CrimeReportTxtArea" runat="server" name="S2" style="resize:none"></textarea>&nbsp

        </p>
        <p>
            <asp:Label ID="HealthReportLabel" runat="server" Text="Health Insurance Report:"></asp:Label><br />
            <textarea id="HealthReportTxtArea" runat="server" name="S3" style="resize:none"></textarea>&nbsp
        </p>
        <p>
            <asp:Label ID="PovertyReportLabel" runat="server" Text="Poverty Report:"></asp:Label><br />
            <textarea id="PovertyReportTxtArea" runat="server" name="S4" style="resize:none"></textarea>
        </p>
        </div>
    </asp:panel> 

        <div style="height: 154px">
        <asp:Button ID="Button1" runat="server" Text="Default Page" Width="115px" PostBackUrl="Default.aspx" /> &nbsp
        </div>
</form>
</body>
</html>
