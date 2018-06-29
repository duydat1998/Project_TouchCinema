using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StaffLibrary;
using OrderLibary;
namespace Project_TouchCinema
{
    public partial class StaffWorkspace : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["STAFF_USER"] == null)
            {
                Response.Redirect("StaffLogin.aspx");
            }
            this.orderDetail.Visible = false;
            this.invalidCode.Visible = false;
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            string orderID = txtBookingCode.Text.Trim();
            if (orderID.Equals("") || orderID.Length != 10)
            {
                this.invalidCode.Visible = true;
            }
            else
            {
                this.invalidCode.Visible = false;
            }
        }

        protected void txtBookingCode_TextChanged(object sender, EventArgs e)
        {
            this.invalidCode.Visible = false;
        }
    }
}