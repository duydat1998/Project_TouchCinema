using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StaffLibrary;
namespace Project_TouchCinema
{
    public partial class StaffLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.invalidLogin.CssClass = "error_message";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            StaffDTO staff = null;
            StaffDAO dao = new StaffDAO();
            bool result = dao.CheckLogin(username, password, ref staff);
            if (result)
            {
                Session["STAFF_USER"] = staff;
                Response.Redirect("StaffWorkspace.aspx");
            }
            else
            {
                this.invalidLogin.CssClass = "error_message_show";
                this.txtPassword.Text = "";
            }
        }

    }
}