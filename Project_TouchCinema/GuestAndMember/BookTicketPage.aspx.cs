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

namespace Project_TouchCinema.GuestAndMember
{
    public partial class BookTicketPage : System.Web.UI.Page
    {
        OrderDAO oDAO = new OrderDAO();
        OrderDetailDAO odDAO = new OrderDetailDAO();
        MovieDAO mDAO = new MovieDAO();
        ScheduleDAO sDAO = new ScheduleDAO();
        RoomDAO rDAO = new RoomDAO();        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string scheduleID = "";
                if (Request.QueryString["schedule"] != null)
                {
                    scheduleID = Request.QueryString["schedule"];
                }                
                LoadAllLists();

                dlMovieList.Items.Add("--Select a movie--");
                LoadMovieToDropDownList();
                dlScheduleList.Items.Add("--Select a movie first--");
                dlScheduleList.Enabled = false;
                dlTicketNum.Items.Add("--");
                dlTicketNum.Enabled = false;
            }
        }

        private void LoadAllLists()
        {
            Session["MovieList"] = mDAO.GetMovieList();
            Session["ScheduleList"] = sDAO.GetScheduleFromNowOn();
            Session["RoomList"] = rDAO.GetRoomList();
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

        protected void dlMovieList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pos = dlMovieList.SelectedIndex;
            string selectedStr = dlMovieList.Items[pos].Text;

            dlScheduleList.Items.Clear();
            dlScheduleID.Items.Clear();

            if (selectedStr.Equals("--Select a movie--"))
            {                
                dlScheduleList.Items.Add("--Select a movie first--");
                dlScheduleList.Enabled = false;
                dlTicketNum.Items.Clear();
                dlTicketNum.Items.Add("--");
                dlTicketNum.Enabled = false;
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
                LoadAvailableSeat(remainingSeat);
                dlTicketNum.Enabled = true;
            }
        }

        protected void dlTicketNum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}