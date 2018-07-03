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
                this.orderDetail.Visible = true;
                this.lblOrderID.Text = order.OrderID;
                this.invalidCode.Visible = false;
                this.lbMovieName.Text = movieTitle;
                this.lbDate.Text = schedule.ScheduleDate.ToShortDateString();
                this.lbTime.Text = schedule.ScheduleDate.ToShortTimeString();
                this.lbRoom.Text = schedule.RoomID.ToString();
                this.lbPrice.Text = (schedule.PriceOfTicket * (order.ListOfSeat).Count) +"";
                string seat = "";
                foreach(string s in order.ListOfSeat)
                {
                    seat += (s + "  ");
                }
                this.lbSeat.Text = seat;

            }
            else
            {
                this.invalidCode.Visible = true;
                this.orderDetail.Visible = false;
            }
        }


        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            OrderDAO orderDao = new OrderDAO();
            string orderID = txtBookingCode.Text.Trim();
            bool result = orderDao.CheckOutOrder(orderID);
            if (result)
            {
                Response.Redirect("StaffWorkspace.aspx");
            }
            else
            {
                Response.Redirect("../ErrorPages/ErrorPage.aspx");
            }

        }
    }
}