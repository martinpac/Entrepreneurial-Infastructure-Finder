using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;
using EncryptionLibrary;

namespace Assignment7
{
    public partial class Login : System.Web.UI.UserControl
    {
        //global variables for username and password
        protected string Username;
        protected string Password;

        protected void Page_Load(object sender, EventArgs e)
        {
            string pageTitle = Page.Title;
            
            //check the cookies everytime the session is started
            HttpCookie myCookies = Request.Cookies["myCookieID"];
            HttpCookie staffCookies = Request.Cookies["staffCookieID"];

            //checks if we are on staff page
            if (pageTitle == "Staff Page")
            {
                if ((staffCookies == null) || (staffCookies["Username"] == ""))
                {
                    WelcomeLabel.Text = "Welcome, new user";
                    DisplayLoginControls();
                }

                //if there are cookies saved then it will not show the login window
                else
                {
                    WelcomeLabel.Text = "Welcome, " + staffCookies["Username"];
                    HideLoginControls();
                }
            }
            //not on staff page (default or member page)
            else
            {
                if ((myCookies == null) || (myCookies["Username"] == ""))
                {
                    WelcomeLabel.Text = "Welcome, new user";
                    DisplayLoginControls();
                }

                //if there are cookies saved then it will not show the login window
                else
                {
                    WelcomeLabel.Text = "Welcome, " + myCookies["Username"];
                    HideLoginControls();
                }
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string pageTitle = Page.Title;

            if (UserNameTxtBox.Text == "" || PasswordTextBox.Text == "")
            {
                SuccessMsgLabel.Text = "Please fill out both boxes";
                SuccessMsgLabel.ForeColor = Color.Red;
            }
            else
            {
                //call dll encryption library class
                Cryption encrypt = new Cryption();
                string pwdEncrypted = encrypt.Encrypt(Password);
                XmlDocument myDoc = new XmlDocument();

                //checks if we are on staff page
                if (pageTitle == "Staff Page")
                {
                    //load Staff.xml document
                    myDoc.Load(HttpRuntime.AppDomainAppPath + @"\App_Data\Staff.xml");

                    string xpathQuery = $"//Staff[@username='{Username}']";
                    XmlNode staffNode = myDoc.SelectSingleNode(xpathQuery);

                    //username in xml file
                    if (staffNode != null)
                    {
                        //encrypted password in xml
                        if (staffNode["password"].InnerText == pwdEncrypted)
                        {
                            //Cookie layer only saved if successful login
                            HttpCookie staffCookies = new HttpCookie("staffCookieID");
                            staffCookies["Username"] = Username;
                            staffCookies["Password"] = Password;
                            staffCookies.Expires = DateTime.Now.AddMonths(6);
                            Response.Cookies.Add(staffCookies);

                            //welcome message for user
                            WelcomeLabel.Text = "Welcome, " + staffCookies["Username"];
                            HideLoginControls();
                            Response.Redirect(Request.RawUrl);
                        }
                        else
                        {
                            SuccessMsgLabel.Text = "Username or Password is incorrect";
                        }
                    }
                    else
                    {
                        SuccessMsgLabel.Text = "Username or Password is incorrect";
                    }

                }
                //not on staff page (default or member page)
                else
                {
                    //load Member.xml file
                    myDoc.Load(HttpRuntime.AppDomainAppPath + @"\App_Data\Member.xml");

                    string xpathQuery = $"//Member[@username='{Username}']";
                    XmlNode staffNode = myDoc.SelectSingleNode(xpathQuery);

                    //if username in member document
                    if (staffNode != null)
                    {
                        //if encrypted password in member document
                        if (staffNode["password"].InnerText == pwdEncrypted)
                        {
                            SuccessMsgLabel.Text = "Welcome! Showing services (implemented in assignment 7)";

                            //Cookie layer only saved if successful login
                            HttpCookie myCookies = new HttpCookie("myCookieID");
                            myCookies["Username"] = Username;
                            myCookies["Password"] = Password;
                            myCookies.Expires = DateTime.Now.AddMonths(6);
                            Response.Cookies.Add(myCookies);

                            WelcomeLabel.Text = "Welcome, " + myCookies["Username"];
                            HideLoginControls();
                            Response.Redirect(Request.RawUrl);
                        }
                        //if password does not correspond with username
                        else
                        {
                            SuccessMsgLabel.Text = "Username or Password is incorrect";
                        }
                    }
                    //username not in member document
                    else
                    {
                        SuccessMsgLabel.Text = "Username or Password is incorrect";
                    }
                }
            }

            PasswordTextBox.Text = "";
            UserNameTxtBox.Text = "";
        }
        private void DisplayLoginControls()
        {
            // Show the login textboxes and login button
            LoginPanel.Visible = true;
        }

        private void HideLoginControls()
        {
            // hide the login textboxes and login button
            LoginPanel.Visible = false;
        }

        protected void UserNameTxtBox_TextChanged(object sender, EventArgs e)
        {
            Username = UserNameTxtBox.Text;
        }

        protected void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            Password = PasswordTextBox.Text;
        }
    }
}