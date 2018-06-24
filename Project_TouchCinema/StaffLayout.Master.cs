using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationDemo
{
    public partial class StaffLayout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER"] == null)
            {
                this.lblUser.Visible = false;
                this.btnLogout.Visible = false;
               
            }
            else
            {

                this.lblUser.Visible = true;
                this.btnLogout.Visible = true;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            Response.Redirect("StaffLogin.aspx");
        }
    }
}