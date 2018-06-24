using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_TouchCinema
{
    public partial class MemberLayout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER"] == null)
            {
                this.avatar.Visible = false;
                this.myAccount.Visible = false;
                this.btnLogout.Visible = false;
                this.btnLogin.Visible = true;
                this.btnRegister.Visible = true;
            }
            else
            {
                this.avatar.ImageUrl = "";
                this.myAccount.Text = "";
                this.btnLogin.Visible = false;
                this.btnRegister.Visible = false;
                this.btnLogout.Visible = true;
            }


        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            Response.Redirect("MemberWorkspace.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

        }
    }
}