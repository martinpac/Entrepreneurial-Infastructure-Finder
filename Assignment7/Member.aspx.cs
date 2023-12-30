using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Web;
using System.Web.Management;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using EncryptionLibrary;
using Newtonsoft.Json;

namespace Assignment7
{

    //Used for captcha
    public class RecaptchaResponse
    {
        public bool Success { get; set; }
        public string ChallengeTs { get; set; }
        public string Hostname { get; set; }
        public List<string> ErrorCodes { get; set; }
    }

    public partial class Member : System.Web.UI.Page
    {
        //global variables
        public static string zipCode;
        public static string stateAbbreviation;

        protected void Page_Load(object sender, EventArgs e)
        {
            //check the cookies everytime the session is started
            HttpCookie myCookies = Request.Cookies["myCookieID"];
            SuccessMsgLabel.Text = "";

            //if there are no cookies saved then it should display the login window
            if ((myCookies == null) || (myCookies["Username"] == ""))
            {
                WelcomeLabel.Text = "Welcome new user";
                DisplaySignUp();
            }

            //if there are cookies saved then it will not show the login window
            else
            {
                WelcomeLabel.Text = "Welcome " + myCookies["Username"] + "!";
                HideSignUp();
            }
        }

        //show sign up window, hides services
        protected void DisplaySignUp()
        {
            SignUp.Visible = true;
            Services.Visible = false;
        }

        //hides sign up window, shows services
        protected void HideSignUp()
        {
            SignUp.Visible = false;
            Services.Visible = true;
        }

        //checks if a member already exists in the xml document
        protected Boolean checkExist(string username, string password)
        {
            Boolean exists = false;

            //calls dll encryption library class
            Cryption encrypt = new Cryption();
            string pwdEncrypted = encrypt.Encrypt(password);

            //opens xml document
            XmlDocument myDoc = new XmlDocument();

            myDoc.Load(HttpRuntime.AppDomainAppPath + @"\App_Data\Member.xml");

            string xpathQuery = $"//Member[@username='{username}']";
            XmlNode memberNode = myDoc.SelectSingleNode(xpathQuery);

            //checks if username is in xml document
            if (memberNode != null)
            {
                //if username has same encrypted password
                if (memberNode["password"].InnerText == pwdEncrypted)
                {
                    exists = true;
                }
                else
                {
                    exists = false;
                }
            }
            //username does not exist
            else
            {
                exists = false;
            }

            return exists;
        }

        protected void SignUpButton_Click(object sender, EventArgs e)
        {
            //checks for empty/null inputs
            if (UsernameBox.Text == "" || PasswordBox.Text == "")
            {
                SuccessMsgLabel.ForeColor = Color.Red;
                SuccessMsgLabel.Text = "Please fill out both boxes.";
                UsernameBox.Text = "";
                PasswordBox.Text = "";
            }
            //both textboxes are filled
            else
            {
                //checks if member is in xml document
                Boolean exists = checkExist(UsernameBox.Text, PasswordBox.Text);

                if (exists == true)
                {
                    SuccessMsgLabel.Text = "User already exists, please sign in the Default Page";
                    SuccessMsgLabel.ForeColor = Color.Red;
                }
                //member does not exist in xml document
                else
                {
                    //if user does not do google captcha
                    if (string.IsNullOrEmpty(Request["g-recaptcha-response"]))
                    {
                        SuccessMsgLabel.ForeColor = Color.Red;
                        SuccessMsgLabel.Text = "Please complete the reCAPTCHA verification.";
                        return;
                    }

                    // Verify reCAPTCHA
                    
                    //local host key
                    string recaptchaSecretKey = "6LdFfRkpAAAAAA0oXuKtRGLaB1ut-w2ZoQcoVKK9";

                    //webstrar host key
                    //string recaptchaSecretKey = "6LcKkh0pAAAAAGaptOq2eIQZRFwSZ0DStpu6LrBd";

                    string recaptchaResponse = Request["g-recaptcha-response"];
                    string verificationUrl = $"https://www.google.com/recaptcha/api/siteverify?secret={recaptchaSecretKey}&response={recaptchaResponse}";

                    string username = UsernameBox.Text;
                    string password = PasswordBox.Text;
                    try
                    {

                        //call DLL library class to encrypt password
                        Cryption encrypt = new Cryption();
                        string encryptedPassword = encrypt.Encrypt(password);

                        //load local Member.xml file
                        string path = Server.MapPath("~/App_Data/Member.xml");
                        XmlDocument xml = new XmlDocument();
                        xml.Load(path);

                        //create new member element
                        XmlElement newStaff = xml.CreateElement("Member");

                        //new username attribute and append to new member
                        XmlAttribute newUsername = xml.CreateAttribute("username");
                        newUsername.Value = username;
                        newStaff.Attributes.Append(newUsername);

                        //new password and append to new member
                        XmlElement newPassword = xml.CreateElement("password");
                        newPassword.InnerText = encryptedPassword;
                        newStaff.AppendChild(newPassword);
                        xml.DocumentElement.AppendChild(newStaff);

                        //save the xml file with new member
                        xml.Save(path);

                        //Cookie layer only saved if successful login
                        HttpCookie myCookies = new HttpCookie("myCookieID");
                        myCookies["Username"] = username;
                        myCookies["Password"] = password;
                        myCookies.Expires = DateTime.Now.AddMonths(6);
                        Response.Cookies.Add(myCookies);

                        WelcomeLabel.Text = "Welcome, " + myCookies["Username"];

                        UsernameBox.Text = "";
                        PasswordBox.Text = "";

                        SuccessMsgLabel.Text = "You are now a member!";

                        HideSignUp();
                    }
                    catch (Exception ex)
                    {
                        SuccessMsgLabel.Text = ("Error signing up: " + ex.Message);
                    }

                }
            }
        }

        protected void StateAbbreviationInputTxtBox_TextChanged(object sender, EventArgs e)
        {
            stateAbbreviation = StateAbbreviationInputTxtBox.Text;
        }

        protected void ZipcodeInputTxtBox_TextChanged(object sender, EventArgs e)
        {
            zipCode = ZipcodeInputTxtBox.Text;
        }

        protected void GetReportsButton_Click(object sender, EventArgs e)
        {
            ReportsServices.Service1Client myServices = new ReportsServices.Service1Client();

            //checks if state abbreviation/zip code boxes are empty/null
            if (StateAbbreviationInputTxtBox.Text == "" || ZipcodeInputTxtBox.Text == "")
            {
                FailLabel.Text = "Please fill out both boxes";
                FailLabel.ForeColor = Color.Red;
                StateAbbreviationInputTxtBox.Text = "";
                ZipcodeInputTxtBox.Text = "";
                WeatherReportTxtArea.InnerText = "";
                TaxReportTxtArea.InnerText = "";
                CrimeReportTxtArea.InnerText = "";
                HealthReportTxtArea.InnerText = "";
                PovertyReportTxtArea.InnerText = "";
                PopulationDisplayLabel.Text = "";
            }
            //state ebbreviation/zip code boxes not empty
            else
            {
                //Texas does not have health/crime/povery reports
                if (stateAbbreviation == "TX")
                {
                    CrimeReportTxtArea.InnerText = "State not available";
                    HealthReportTxtArea.InnerText = "State not available";
                    PovertyReportTxtArea.InnerText = "State not available";

                    string[] WeatherReport = myServices.Weather5Day(zipCode); //call Weather5Day method 
                    WeatherReportTxtArea.InnerText = String.Join(Environment.NewLine, WeatherReport);

                    //does the tax report 
                    string[] TaxReport = myServices.TaxReport(zipCode); //call the TaxReport method 
                    TaxReportTxtArea.InnerText = String.Join(Environment.NewLine, TaxReport);

                    string stateName = abbreviation2Full(stateAbbreviation.ToUpper());
                    PopulationService.Service1Client myService2 = new PopulationService.Service1Client();
                    int population = myService2.GetPopulation(stateName);

                    PopulationDisplayLabel.Text = population.ToString();
                    PopulationLabel.Text = "Population of: " + stateName;
                }
                else
                {
                    FailLabel.Text = "";

                    string[] WeatherReport = myServices.Weather5Day(zipCode); //call Weather5Day method 
                    WeatherReportTxtArea.InnerText = String.Join(Environment.NewLine, WeatherReport);

                    //does the tax report 
                    string[] TaxReport = myServices.TaxReport(zipCode); //call the TaxReport method 
                    TaxReportTxtArea.InnerText = String.Join(Environment.NewLine, TaxReport);

                    //does the crime report 
                    string[] CrimeReport = myServices.CrimeReport(stateAbbreviation); //call the CrimeReport method 
                    CrimeReportTxtArea.InnerText = String.Join(Environment.NewLine, CrimeReport);

                    //does the health report 
                    string[] HealthReport = myServices.HealthReport(stateAbbreviation); //call the HealthReport method
                    HealthReportTxtArea.InnerText = String.Join(Environment.NewLine, HealthReport);

                    //does the poverty report 
                    string[] PovertyReport = myServices.PovertyReport(stateAbbreviation); //call the PovertyReport method
                    PovertyReportTxtArea.InnerText = String.Join(Environment.NewLine, PovertyReport);

                    string stateName = abbreviation2Full(stateAbbreviation.ToUpper());
                    PopulationService.Service1Client myService2 = new PopulationService.Service1Client();
                    int population = myService2.GetPopulation(stateName);

                    //if invalid state
                    if (population == -1)
                    {
                        PopulationDisplayLabel.Text = "";
                        PopulationLabel.Text = "Population of " + stateAbbreviation + " does not exist!";
                    }
                    //state is valid
                    else
                    {
                        PopulationDisplayLabel.Text = population.ToString();
                        PopulationLabel.Text = "Population of: " + stateName;
                    }
                }
            }
        }

        //convert from abbreviation to full state name
        protected string abbreviation2Full(string abbreviation)
        {
            string fullState = "";

            switch (abbreviation)
            {
                case "AL":
                    fullState = "Alabama";
                    break;
                case "AK":
                    fullState = "Alaska";
                    break;
                case "AZ":
                    fullState = "Arizona";
                    break;
                case "AR":
                    fullState = "Arkansas";
                    break;
                case "CA":
                    fullState = "California";
                    break;
                case "CO":
                    fullState = "Colorado";
                    break;
                case "CT":
                    fullState = "Connecticut";
                    break;
                case "DE":
                    fullState = "Delaware";
                    break;
                case "FL":
                    fullState = "Florida";
                    break;
                case "GA":
                    fullState = "Georgia";
                    break;
                case "HI":
                    fullState = "Hawaii";
                    break;
                case "ID":
                    fullState = "Idaho";
                    break;
                case "IL":
                    fullState = "Illinois";
                    break;
                case "IN":
                    fullState = "Indiana";
                    break;
                case "IA":
                    fullState = "Iowa";
                    break;
                case "KS":
                    fullState = "Kansas";
                    break;
                case "KY":
                    fullState = "Kentucky";
                    break;
                case "LA":
                    fullState = "Louisiana";
                    break;
                case "ME":
                    fullState = "Maine";
                    break;
                case "MD":
                    fullState = "Maryland";
                    break;
                case "MA":
                    fullState = "Massachusettes";
                    break;
                case "MI":
                    fullState = "Michigan";
                    break;
                case "MN":
                    fullState = "Minnesota";
                    break;
                case "MS":
                    fullState = "Mississippi";
                    break;
                case "MO":
                    fullState = "Missouri";
                    break;
                case "MT":
                    fullState = "Montana";
                    break;
                case "NE":
                    fullState = "Nebraska";
                    break;
                case "NV":
                    fullState = "Nevada";
                    break;
                case "NH":
                    fullState = "New Hampshire";
                    break;
                case "NJ":
                    fullState = "New Jersey";
                    break;
                case "NM":
                    fullState = "New Mexico";
                    break;
                case "NY":
                    fullState = "New York";
                    break;
                case "NC":
                    fullState = "North Carolina";
                    break;
                case "ND":
                    fullState = "North Dakota";
                    break;
                case "OH":
                    fullState = "Ohio";
                    break;
                case "OK":
                    fullState = "Oklahoma";
                    break;
                case "OR":
                    fullState = "Oregon";
                    break;
                case "PA":
                    fullState = "Pennsylvania";
                    break;
                case "RI":
                    fullState = "Rhode Island";
                    break;
                case "SC":
                    fullState = "South Carolina";
                    break;
                case "SD":
                    fullState = "South Dakota";
                    break;
                case "TN":
                    fullState = "Tennessee";
                    break;
                case "TX":
                    fullState = "Texas";
                    break;
                case "UT":
                    fullState = "Utah";
                    break;
                case "VT":
                    fullState = "Vermont";
                    break;
                case "VA":
                    fullState = "Virginia";
                    break;
                case "WA":
                    fullState = "Washington";
                    break;
                case "WV":
                    fullState = "West Virginia";
                    break;
                case "WI":
                    fullState = "Wisconsin";
                    break;
                case "WY":
                    fullState = "Wyoming";
                    break;

                default:
                    break;
            }

            return fullState;
        }
    }
}