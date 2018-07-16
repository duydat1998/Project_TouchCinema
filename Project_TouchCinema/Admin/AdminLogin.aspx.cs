using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdminLibrary;

namespace Project_TouchCinema
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.invalidLogin.CssClass = "error_message";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            AdminDTO admin = null;
            AdminDAO dao = new AdminDAO();
            admin = dao.CheckLogin(username, password);
            if (admin != null)
            {
                Session["ADMIN_USER"] = admin;
                Response.Redirect("ManageMovie.aspx");
            }
            else
            {
                this.invalidLogin.CssClass = "error_message_show";
                this.txtPassword.Text = "";
            }

        }
    }
}