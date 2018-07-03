using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MemberLibrary;
namespace Project_TouchCinema
{
    public partial class MemberLayout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MEMBER_USER"] == null)
            {
                this.avatar.Visible = false;
                this.myAccount.Visible = false;
                this.btnLogout.Visible = false;
                this.btnLoadLogin.Visible = true;
                this.btnRegister.Visible = true;
                this.invalidLogin.Visible = false;
            }
            else
            {
                MemberDTO member = (MemberDTO)Session["MEMBER_USER"];
                this.avatar.ImageUrl = member.ImageLink;
                this.myAccount.Text = member.FirstName+" "+member.LastName;
                this.btnLoadLogin.Visible = false;
                this.btnRegister.Visible = false;
                this.btnLogout.Visible = true;
            }


        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            Response.Redirect("TouchCinema.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (username.Equals("") || password.Equals(""))
            {
                this.invalidLogin.Visible = true;
                this.txtPassword.Text = "";
            }
            else
            {
                MemberDTO member = null;
                MemberDAO dao = new MemberDAO();
                member = dao.CheckLoginMember(username, password);
                if (member != null)
                {
                    if (member.IsActive)
                    {
                        Session["MEMBER_USER"] = member;
                        Response.Redirect("TouchCinema.aspx");
                    }
                    else
                    {
                        Response.Redirect("ErrorPage.aspx");
                    }
                }
                else
                {
                    this.invalidLogin.Visible = true;
                    this.txtPassword.Text = "";
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberRegister.aspx");
        }
    }
}