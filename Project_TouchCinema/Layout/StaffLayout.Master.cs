using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StaffLibrary;
namespace WebApplicationDemo
{
    public partial class StaffLayout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["STAFF_USER"] == null)
            {
                this.lblUser.Visible = false;
                this.btnLogout.Visible = false;
                this.menuStaff.Visible = false;
            }
            else
            {
                StaffDTO staff =(StaffDTO) Session["STAFF_USER"];
                this.lblUser.Text = staff.FirstName + " " + staff.LastName;
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