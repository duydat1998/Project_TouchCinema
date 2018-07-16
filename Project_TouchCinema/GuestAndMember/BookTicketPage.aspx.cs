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
        List<Button> buttonList = new List<Button>();

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
            }
        }

        protected void dlTicketNum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void loadSeatList()
        {
            buttonList.Add(btnA1);
            buttonList.Add(btnA2);
            buttonList.Add(btnA3);
            buttonList.Add(btnA4);
            buttonList.Add(btnA5);
            buttonList.Add(btnA6);
            buttonList.Add(btnA7);
            buttonList.Add(btnA8);

            buttonList.Add(btnB1);
            buttonList.Add(btnB2);
            buttonList.Add(btnB3);
            buttonList.Add(btnB4);
            buttonList.Add(btnB5);
            buttonList.Add(btnB6);
            buttonList.Add(btnB7);
            buttonList.Add(btnB8);

            buttonList.Add(btnC1);
            buttonList.Add(btnC2);
            buttonList.Add(btnC3);
            buttonList.Add(btnC4);
            buttonList.Add(btnC5);
            buttonList.Add(btnC6);
            buttonList.Add(btnC7);
            buttonList.Add(btnC8);

            buttonList.Add(btnD1);
            buttonList.Add(btnD2);
            buttonList.Add(btnD3);
            buttonList.Add(btnD4);
            buttonList.Add(btnD5);
            buttonList.Add(btnD6);
            buttonList.Add(btnD7);
            buttonList.Add(btnD8);

            buttonList.Add(btnE1);
            buttonList.Add(btnE2);
            buttonList.Add(btnE3);
            buttonList.Add(btnE4);
            buttonList.Add(btnE5);
            buttonList.Add(btnE6);
            buttonList.Add(btnE7);
            buttonList.Add(btnE8);
        }
    }
}