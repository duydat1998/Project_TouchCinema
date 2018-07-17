using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderLibary;
using MovieLibrary;
using ScheduleLibrary;
using RoomLibrary;
using GenreLibrary;

namespace Project_TouchCinema.GuestAndMember
{
    public partial class BookTicketPage : System.Web.UI.Page
    {
        OrderDAO oDAO = new OrderDAO();
        OrderDetailDAO odDAO = new OrderDetailDAO();
        MovieDAO mDAO = new MovieDAO();
        ScheduleDAO sDAO = new ScheduleDAO();
        RoomDAO rDAO = new RoomDAO();
        GenreDAO gDAO = new GenreDAO();        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string scheduleID = "";
                string roomID = "";
                if (Request.QueryString["schedule"] != null)
                {
                    scheduleID = Request.QueryString["schedule"];
                }
                if(Request.QueryString["room"] != null)
                {
                    roomID = Request.QueryString["room"];
                }
                LoadAllLists();

                loadSeatList();

                dlMovieList.Items.Add("--Select a movie--");                
                LoadMovieToDropDownList();
                dlScheduleList.Items.Add("--Select a movie first--");
                dlScheduleList.Enabled = false;
                dlTicketNum.Items.Add("--");
                dlTicketNum.Enabled = false;
                lblTicketNoti.Visible = false;                

                if (scheduleID.Length != 0 && roomID.Length != 0)
                {
                    LoadDataFromQueryRequest(scheduleID, int.Parse(roomID));
                }
                
            }
        }

        private void LoadAllLists()
        {
            Session["MovieList"] = mDAO.GetMovieList();
            Session["ScheduleList"] = sDAO.GetScheduleFromNowOn();
            Session["RoomList"] = rDAO.GetRoomList();
            Session["GenreList"] = gDAO.GetGenreList();
        }

        private void LoadMovieToDropDownList()
        {
            List<MovieDTO> movieList = (List<MovieDTO>)Session["MovieList"];
            foreach (var movie in movieList)
            {
                dlMovieList.Items.Add(movie.MovieTitle);
            }
        }

        private void LoadScheduleToDropDownList(List<ScheduleDTO> scheduleList)
        {            
            foreach (var schedule in scheduleList)
            {
                dlScheduleList.Items.Add(schedule.ScheduleDate + " at Room No. " + schedule.RoomID);
                dlScheduleID.Items.Add(schedule.ScheduleID);
            }
        }
        
        private void LoadAvailableSeat(int remainingSeatList)
        {
            for(int i = 1; i <= remainingSeatList; i++)
            {
                dlTicketNum.Items.Add(i+"");
            }
        }

        private void LoadDataFromQueryRequest(string scheduleID, int roomID)
        {
            ScheduleDTO sDTO = sDAO.GetScheduleDTO((List<ScheduleDTO>)Session["ScheduleList"], scheduleID);
            string movieID = sDTO.MovieID;
            string movieTitle = mDAO.getMovieDTOByMovieID((List<MovieDTO>)Session["MovieList"], movieID).MovieTitle;

            dlMovieList.SelectedValue = movieTitle;

            dlScheduleID.Items.Clear();
            List<ScheduleDTO> scheduleList = sDAO.getSpecificMovieSchedule((List<ScheduleDTO>)Session["ScheduleList"], movieID);
            LoadScheduleToDropDownList(scheduleList);
            dlScheduleList.Enabled = true;
            dlScheduleList.SelectedValue = sDTO.ScheduleDate + " at Room No. " + sDTO.RoomID;


            dlTicketNum.Items.Clear();
            List<string> bookedSeatList = odDAO.GetAllSeats(scheduleID);
            int bookedSeat;
            if (bookedSeatList == null)
            {
                bookedSeat = 0;
            }
            else
            {
                bookedSeat = bookedSeatList.Count;
            }
            int remainingSeat = rDAO.getRoom((List<RoomDTO>)Session["RoomList"], roomID).NumberOfSeat - bookedSeat;
            if (remainingSeat >= 10)
            {
                LoadAvailableSeat(10);
            }
            else
            {
                LoadAvailableSeat(remainingSeat);
            }
            dlTicketNum.Enabled = true;
            lblTicketNoti.Visible = true;

            List<Button> seaList = loadSeatList();
            MarkBookedSeats(bookedSeatList, seaList);
        }

        protected void dlMovieList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pos = dlMovieList.SelectedIndex;
            string selectedStr = dlMovieList.Items[pos].Text;

            dlScheduleList.Items.Clear();
            dlScheduleID.Items.Clear();
            dlTicketNum.Items.Clear();

            if (selectedStr.Equals("--Select a movie--"))
            {                
                dlScheduleList.Items.Add("--Select a movie first--");
                dlScheduleList.Enabled = false;
                dlTicketNum.Items.Add("--");
                dlTicketNum.Enabled = false;
                lblTicketNoti.Visible = false;
            }
            else
            {                                
                string movieID = mDAO.getMovieDTO((List<MovieDTO>)Session["MovieList"], selectedStr)[0].MovieID;
                List<ScheduleDTO> scheduleList=sDAO.getSpecificMovieSchedule((List<ScheduleDTO>)Session["ScheduleList"], movieID);
                if(scheduleList.Count!= 0)
                {
                    dlScheduleList.Items.Add("--Select a schedule--");
                }
                else
                {
                    dlScheduleList.Items.Add("--Currently There is no schedule for this movie--");
                }
                LoadScheduleToDropDownList(scheduleList);
                dlScheduleList.Enabled = true;
                dlTicketNum.Items.Add("--");
                dlTicketNum.Enabled = false;
                lblTicketNoti.Visible = true;
            }
        }

        protected void dlScheduleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pos = dlScheduleList.SelectedIndex;
            string selectedStr = dlScheduleList.Items[pos].Text;

            dlTicketNum.Items.Clear();

            if (selectedStr.Equals("--Select a schedule--"))
            {                
                dlTicketNum.Items.Clear();
                dlTicketNum.Items.Add("--");
                dlTicketNum.Enabled = false;
                lblTicketNoti.Visible = false;
            }
            else
            {
                int roomID = int.Parse(selectedStr.Substring(selectedStr.IndexOf(".")+1));
                string scheduleID = dlScheduleID.Items[pos-1].Text;
                List<string> bookedSeatList = odDAO.GetAllSeats(scheduleID);
                int bookedSeat;
                if (bookedSeatList == null)
                {
                    bookedSeat = 0;
                }
                else
                {
                    bookedSeat = bookedSeatList.Count;
                }
                int remainingSeat = rDAO.getRoom((List<RoomDTO>)Session["RoomList"], roomID).NumberOfSeat - bookedSeat;
                if (remainingSeat >= 10)
                {
                    LoadAvailableSeat(10);
                }
                else
                {
                    LoadAvailableSeat(remainingSeat);
                }
                dlTicketNum.Enabled = true;
                lblTicketNoti.Visible = true;

                List<Button> seatList = loadSeatList();
                MarkBookedSeats(bookedSeatList, seatList);
            }
        }

        protected void dlTicketNum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private List<Button> loadSeatList()
        {
            List<Button> seatList = new List<Button>();

            seatList.Add(btnA1);
            seatList.Add(btnA2);
            seatList.Add(btnA3);
            seatList.Add(btnA4);
            seatList.Add(btnA5);
            seatList.Add(btnA6);
            seatList.Add(btnA7);
            seatList.Add(btnA8);

            seatList.Add(btnB1);
            seatList.Add(btnB2);
            seatList.Add(btnB3);
            seatList.Add(btnB4);
            seatList.Add(btnB5);
            seatList.Add(btnB6);
            seatList.Add(btnB7);
            seatList.Add(btnB8);

            seatList.Add(btnC1);
            seatList.Add(btnC2);
            seatList.Add(btnC3);
            seatList.Add(btnC4);
            seatList.Add(btnC5);
            seatList.Add(btnC6);
            seatList.Add(btnC7);
            seatList.Add(btnC8);

            seatList.Add(btnD1);
            seatList.Add(btnD2);
            seatList.Add(btnD3);
            seatList.Add(btnD4);
            seatList.Add(btnD5);
            seatList.Add(btnD6);
            seatList.Add(btnD7);
            seatList.Add(btnD8);

            seatList.Add(btnE1);
            seatList.Add(btnE2);
            seatList.Add(btnE3);
            seatList.Add(btnE4);
            seatList.Add(btnE5);
            seatList.Add(btnE6);
            seatList.Add(btnE7);
            seatList.Add(btnE8);

            return seatList;
        }

        private List<Button> MarkBookedSeats(List<string> bookedSeatList , List<Button> seatList)
        {
            List<Button> currentSeatList = seatList;
            if (bookedSeatList != null)
            {
                foreach (var seat in currentSeatList)
                {
                    foreach (var bookedseat in bookedSeatList)
                    {
                        if (seat.Text.ToUpper().Equals(bookedseat.ToUpper()))
                        {
                            seat.CssClass = "seat_booked";
                            break;
                        }
                    }
                }
            }
            return currentSeatList;
        }
    }
}