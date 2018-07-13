using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MemberLibrary;
namespace Project_TouchCinema.GuestAndMember
{
    public partial class MemberChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MEMBER_USER"] == null)
            {
                Response.Redirect("TouchCinema.aspx");
            }
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            MemberDTO member =(MemberDTO) Session["MEMBER_USER"];
            string username = member.Username;
            string oldPass = txtOldPass.Text;
            MemberDAO dao = new MemberDAO();
            if (!dao.CheckPassword(username, oldPass)){

                string message = "Password is not correct.";
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                this.txtOldPass.Focus();
                return;
            }
            string newPass = txtNewPass.Text;
            if (dao.ChangePass(username, newPass))
            {
                string message = "Password changed SUCCESSFULLY.";
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
            }
            else
            {
                Response.Redirect("../ErrorPages/ErrorPage.aspx");

            }

        }
    }
}