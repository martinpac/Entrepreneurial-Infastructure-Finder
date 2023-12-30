using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using EncryptionLibrary;

namespace Assignment7
{
    public partial class Staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SuccessLabel.Text = "";

            //check the cookies everytime the session is started
            HttpCookie staffCookies = Request.Cookies["staffCookieID"];

            //if there are no cookies saved then it should display the login window
            if ((staffCookies == null) || (staffCookies["Username"] == ""))
            {
                DisplayStaffControls();
            }

            //if there are cookies saved then it will not show the login window
            else
            {
                WelcomeLabel.Text = "Welcome " + staffCookies["Username"] + "!";
                HideStaffControls();
            }
        }

        //display login, hide add staff feature
        protected void DisplayStaffControls()
        {
            StaffLogin.Visible = true;
            AddStaff.Visible = false;
        }

        //hide login, display add staff feature
        protected void HideStaffControls()
        {
            StaffLogin.Visible = false;
            AddStaff.Visible = true;
        }

        //checks if a staff already exists in the xml document
        protected Boolean checkExist(string username, string password)
        {
            Boolean exists = false;

            //calls dll encryption library class
            Cryption encrypt = new Cryption();
            string pwdEncrypted = encrypt.Encrypt(password);

            //opens xml document
            XmlDocument myDoc = new XmlDocument();

            myDoc.Load(HttpRuntime.AppDomainAppPath + @"\App_Data\Staff.xml");

            string xpathQuery = $"//Staff[@username='{username}']";
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

        protected void AddStaffButton_Click(object sender, EventArgs e)
        {
            //if username/password text boxes are empty
            if (UsernameBox.Text == "" || PasswordBox.Text == "")
            {
                SuccessLabel.ForeColor = Color.Red;
                SuccessLabel.Text = "Please fill out both boxes.";
                UsernameBox.Text = "";
                PasswordBox.Text = "";
            }

            //username/password text boxes not empty
            else
            {
                //checks if member is in xml document
                Boolean exists = checkExist(UsernameBox.Text, PasswordBox.Text);

                if (exists == true)
                {
                    SuccessLabel.Text = "Staff member already exists!";
                    SuccessLabel.ForeColor = Color.Red;
                }
                //member does not exist in xml document
                else
                {
                    try
                    {
                        //collect username and password
                        string username = UsernameBox.Text;
                        string password = PasswordBox.Text;

                        //call DLL library class to encrypt password
                        Cryption encrypt = new Cryption();
                        string encryptedPassword = encrypt.Encrypt(password);

                        //load local Staff.xml file
                        string path = Server.MapPath("~/App_Data/Staff.xml");
                        XmlDocument xml = new XmlDocument();
                        xml.Load(path);

                        //create new staff element
                        XmlElement newStaff = xml.CreateElement("Staff");

                        //new username attribute and append to new staff
                        XmlAttribute newUsername = xml.CreateAttribute("username");
                        newUsername.Value = username;
                        newStaff.Attributes.Append(newUsername);

                        //new password and append to new staff
                        XmlElement newPassword = xml.CreateElement("password");
                        newPassword.InnerText = encryptedPassword;
                        newStaff.AppendChild(newPassword);
                        xml.DocumentElement.AppendChild(newStaff);

                        //save the xml file with new staff
                        xml.Save(path);

                        UsernameBox.Text = "";
                        PasswordBox.Text = "";

                        SuccessLabel.Text = "Staff Was Added Succesfully!";
                        SuccessLabel.ForeColor = Color.Green;

                        //to prevent the same entry when refreshing page
                        //Response.Redirect(Request.RawUrl);
                    }
                    catch (Exception ex)
                    {
                        SuccessLabel.Text = ("Error adding staff: " + ex.Message);
                    }
                }
            }
        }
    }
}