using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderLibary;
using ScheduleLibrary;
using MovieLibrary;
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
                GetOrderDetail(orderID);
                
            }
        }

        public void GetOrderDetail(string orderID)
        {
            OrderDAO orderDao = new OrderDAO();
            ScheduleDAO scheduleDAO = new ScheduleDAO();
            MovieDAO movieDAO = new MovieDAO();
            OrderDTO order = orderDao.CheckOrder(orderID);
            if (order != null)
            {
                ScheduleDTO schedule = scheduleDAO.GetScheduleByID(order.ScheduleID);
                string movieTitle = movieDAO.GetMovieTitle(schedule.MovieID);
                this.invalidCode.Visible = false;
            }
            else
            {
                this.invalidCode.Visible = true;
            }
        }

        protected void txtBookingCode_TextChanged(object sender, EventArgs e)
        {
            this.invalidCode.Visible = false;
        }
    }
}