using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment7
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StatusLabel.Text = $"{HttpContext.Current.Application["startupMessage"]} (Session Counter: {Application["counter"].ToString()})";
            }
        }

        protected void StaffPageButton_Click(object sender, EventArgs e)
        {
            
        }

        protected void MemberPageButton_Click(object sender, EventArgs e)
        {

        }
    }
}