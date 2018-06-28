using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdminLibrary;
namespace Project_TouchCinema
{
    public partial class AdminLayout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ADMIN_USER"] == null)
            {
                this.lblUser.Visible = false;
                this.btnLogout.Visible = false;
                this.menuAdmin.Visible = false;

            }
            else
            {
                this.lblUser.Visible = true;
                AdminDTO admin = (AdminDTO) Session["ADMIN_USER"];
                this.lblUser.Text = admin.Firstname + " " + admin.Lastname;
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