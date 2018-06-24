using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_TouchCinema
{
    public partial class AdminLayout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER"] == null)
            {
                this.lblUser.Visible = false;
                this.btnLogout.Visible = false;
                this.menuAdmin.Visible = false;

            }
            else
            {
                this.lblUser.Visible = true;
                this.btnLogout.Visible = true;
                this.menuAdmin.Visible = true;
            }

           
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            Response.Redirect("AdminLogin.aspx");
        }
    }
}