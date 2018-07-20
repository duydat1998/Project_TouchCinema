using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MemberLibrary;
using OrderLibary;
using ScheduleLibrary;

namespace Project_TouchCinema.GuestAndMember
{
    public partial class ConfirmationPaymentPage : System.Web.UI.Page
    {
        ScheduleDAO sDAO = new ScheduleDAO();
        OrderDAO oDAO = new OrderDAO();
        OrderDetailDAO odDAO = new OrderDetailDAO();        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bool nullCheck = Session["CurrentSelectdlMovie"] == null ||
                                Session["CurrentSelectdlSchedule"] == null ||
                                Session["SelectedSeats"] == null;
                if (Session["MEMBER_USER"] == null && nullCheck)
                {
                    Response.Redirect("BookTicketPage.aspx");
                }
                else
                {
                    MemberDTO mDTO = (MemberDTO)Session["MEMBER_USER"];
                    lblUsername.Text = mDTO.FirstName + mDTO.LastName;
                    lblPhone.Text = mDTO.PhoneNum;
                    lblEmail.Text = mDTO.Email;

                    lblMovie.Text = Session["CurrentSelectdlMovie"].ToString();
                    string selectedSchedule = Session["CurrentSelectdlSchedule"].ToString();                    
                    ScheduleDTO sDTO = sDAO.GetScheduleDTO((List<ScheduleDTO>)Session["ScheduleList"], selectedSchedule);
                    lblSchedule.Text = sDTO.ScheduleDate + " at Room No. " + sDTO.RoomID;

                    List<string> bookedSeatList = (List<string>)Session["SelectedSeats"];
                    lblBookedSeat.Text = bookedSeatList.Count+"";
                    lblBookedSeatList.Text = ToStringBookedSeatList(bookedSeatList);

                    lblTicketPrice.Text = sDTO.PriceOfTicket+" $";
                    float total = bookedSeatList.Count * sDTO.PriceOfTicket;
                    lblTotalPrice.Text = total+" $";
                }
            }
        }

        private string ToStringBookedSeatList(List<string> bookedSeatList)
        {
            string stringBookedSeatList = "";
            bookedSeatList.Sort();
            foreach (var item in bookedSeatList)
            {
                if(bookedSeatList.IndexOf(item) == (bookedSeatList.Count - 1))
                {
                    stringBookedSeatList += item + "";
                }
                else
                {
                    stringBookedSeatList += item + ", ";
                }                
            }
            return stringBookedSeatList;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookTicketPage.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            MemberDTO mDTO = (MemberDTO)Session["MEMBER_USER"];
            string selectedSchedule = Session["CurrentSelectdlSchedule"].ToString();
            List<string> bookedSeatList = (List<string>)Session["SelectedSeats"];
            OrderDTO oDTO = new OrderDTO
            {
                Email = mDTO.Email,
                Phone = mDTO.PhoneNum,
                ScheduleID = selectedSchedule,                
                ListOfSeat = bookedSeatList
            };

            string orderID = oDAO.InsertOrder(oDTO,mDTO.Username);

            if(orderID.Length == 0)
            {
                string message = "ORDER FAILED.\\nWe are sorry for this inconvinience";
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
            }
            else
            {
                string message = "ORDER SUCCESSFULLY.\\nPress Ok to return to Book Ticket Page";
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
            }

            Session["CurrentSelectdlMovie"] = null;
            Session["CurrentSelectdlSchedule"] = null;
            Session["SelectionAvailable"] = null;
            Session["SelectedSeats"] = new List<string>();

            Response.Redirect("BookTicketPage.aspx");
        }
    }
}