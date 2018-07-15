using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderLibary;

namespace Project_TouchCinema.GuestAndMember
{
    public partial class BookTicketPage : System.Web.UI.Page
    {
        OrderDAO oDAO = new OrderDAO();
        OrderDetailDAO odDAO = new OrderDetailDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string scheduleID = null;
                if (Request.QueryString["schedule"] != null)
                {
                    scheduleID = Request.QueryString["schedule"];
                }
                Session["SeatInRoomSameSche"] = odDAO.GetAllSeats(scheduleID);
            }
        }
    }
}