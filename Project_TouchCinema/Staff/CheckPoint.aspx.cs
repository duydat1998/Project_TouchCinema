using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MemberLibrary;
namespace Project_TouchCinema.Staff
{
    public partial class CheckPoint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["STAFF_USER"] == null)
            {
                Response.Redirect("StaffLogin.aspx");
            }
            this.invalidMember.CssClass = "error_message";
            this.memberInfo.Visible = false;
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();
            MemberDAO dao = new MemberDAO();
            MemberDTO member = dao.SearchMember(search);
            if(member != null)
            {
                int point = dao.CheckPointMember(member.Username);
                this.memberInfo.Visible = true;
                this.lbMemberName.Text = member.FirstName + " " + member.LastName;
                this.lbPhone.Text = member.PhoneNum;
                this.lbEmail.Text = member.Email;
                this.lbPoint.Text = point + "";
            }
            else
            {
                this.invalidMember.CssClass = "error_message_show";
            }
        }
    }
}