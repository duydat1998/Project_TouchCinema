using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_TouchCinema.GuestAndMember
{
    public partial class FeedbackPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFeedback_Click(object sender, EventArgs e)
        {
            string message = "Your feedback is sent to Touch Cinema Manager Team\\n " +
                "Thank you for your supporting!";
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
        }
    }
}