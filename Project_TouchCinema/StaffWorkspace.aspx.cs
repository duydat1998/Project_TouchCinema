using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StaffLibrary;
namespace Project_TouchCinema
{
    public partial class StaffWorkspace : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["STAFF_USER"] == null)
            {
                Response.Redirect("StaffLogin.aspx");
            }
        }
    }
}