using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdminLibrary;

namespace Project_TouchCinema
{
    public partial class AdminWorkspace : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminDTO admin = (AdminDTO) Session["ADMIN_USER"];
            if (admin == null)
            {
                Response.Redirect("AdminLogin.aspx");
            }
        }
    }
}