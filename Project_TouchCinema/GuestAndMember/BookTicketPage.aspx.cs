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
                roomTitle.Text = "Room --";
                DisableSelect();
                Session["CurrentPage"] = "BookTicketPage.aspx";
                lblPriceTicket.Visible = false;

                if (scheduleID.Length != 0 && roomID.Length != 0)
                {
                    LoadDataFromQueryRequest(scheduleID, int.Parse(roomID));
                }
                UpdateTicketMessage();
                if (Session["MEMBER_USER"] == null)
                {
                    lblNotLoggedIn.Visible = true;
                    btnCheckOut.Enabled = false;
                }
                else
                {
                    ReturnSessionAfterLogged();
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
            EnableSelect();
            roomTitle.Text = "Room "+ roomID;

            dlMovieList.SelectedValue = movieTitle;

            dlScheduleID.Items.Clear();
            dlScheduleList.Items.Clear();

            dlScheduleList.Items.Add("--Select a schedule--");
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
            Session["SelectionAvailable"] = 1;
            Session["CurrentPage"] = "BookTicketPage.aspx";            
            Session["CurrentSelectdlMovie"] = dlMovieList.SelectedValue;
            Session["CurrentSelectdlSchedule"] = dlScheduleList.SelectedValue;
            UpdateTicketMessage();

            List<Button> seaList = loadSeatList();
            MarkBookedSeats(bookedSeatList, seaList);
        }

        protected void dlMovieList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pos = dlMovieList.SelectedIndex;
            string selectedStr = dlMovieList.Items[pos].Text;
            List<Button> seatList = loadSeatList();

            dlScheduleList.Items.Clear();
            dlScheduleID.Items.Clear();
            dlTicketNum.Items.Clear();
            ResetStatusSeats(seatList);
            Session["SelectionAvailable"] = null;
            Session["SelectedSeats"] = new List<string>();
            Session["CurrentSelectdlMovie"] = selectedStr;
            Session["CurrentSelectdlSchedule"] = null;
            UpdateTicketMessage();
            DisableSelect();
            roomTitle.Text = "Room --";
            dlTicketNum.Items.Add("--");
            dlTicketNum.Enabled = false;
            lblTicketNoti.Visible = false;                        
            lblPriceTicket.Visible = false;

            if (selectedStr.Equals("--Select a movie--"))
            {                
                dlScheduleList.Items.Add("--Select a movie first--");
                dlScheduleList.Enabled = false;                
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
                Session["CurrentSelectdlSchedule"] = dlScheduleList.SelectedValue;
            }
        }

        protected void dlScheduleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pos = dlScheduleList.SelectedIndex;
            string selectedStr = dlScheduleList.Items[pos].Text;
            List<Button> seatList = loadSeatList();

            dlTicketNum.Items.Clear();
            ResetStatusSeats(seatList);
            Session["SelectedSeats"] = new List<string>();            

            if (selectedStr.Equals("--Select a schedule--"))
            {                
                dlTicketNum.Items.Clear();
                dlTicketNum.Items.Add("--");
                dlTicketNum.Enabled = false;
                lblTicketNoti.Visible = false;
                lblPriceTicket.Visible = false;
                roomTitle.Text = "Room --";
                DisableSelect();
                Session["SelectionAvailable"] = null;
                Session["CurrentSelectdlSchedule"] = selectedStr;
            }
            else
            {
                int roomID = int.Parse(selectedStr.Substring(selectedStr.IndexOf(".")+1));
                string scheduleID = dlScheduleID.Items[pos-1].Text;
                ScheduleDTO sDTO = sDAO.GetScheduleDTO((List<ScheduleDTO>)Session["ScheduleList"], scheduleID);
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

                lblPriceTicket.Text = "Per Ticket costs " + sDTO.PriceOfTicket + " $";
                lblPriceTicket.Visible = true;

                roomTitle.Text = "Room " + roomID;
                EnableSelect();
                //Mặc định là 1
                Session["SelectionAvailable"] = 1;
                Session["SelectedSeats"] = new List<string>();
                Session["CurrentSelectdlSchedule"] = scheduleID;

                MarkBookedSeats(bookedSeatList, seatList);
            }            
            UpdateTicketMessage();
        }

        protected void dlTicketNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pos = dlTicketNum.SelectedIndex;
            int amount = int.Parse(dlTicketNum.Items[pos].Text);
            Session["SelectionAvailable"] = amount;
            UpdateTicketMessage();
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
                            seat.Enabled = false;
                            break;
                        }
                        else
                        {
                            seat.CssClass = "seat_avail";
                            seat.Enabled = true;
                        }
                    }
                }
            }
            return currentSeatList;
        }

        private List<Button> MarkSelectedSeats(List<string> bookedSeatList, List<Button> seatList)
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
                            seat.CssClass = "seat_select";
                            seat.Enabled = true;
                            break;
                        }
                        else
                        {
                            if (!seat.CssClass.Equals("seat_booked"))
                            {
                                seat.CssClass = "seat_avail";
                                seat.Enabled = true;
                                break;
                            }                            
                        }
                    }
                }
            }
            return currentSeatList;
        }

        private List<Button> ResetStatusSeats(List<Button> seatList)
        {
            List<Button> currentSeatList = seatList;
            foreach (var seat in currentSeatList)
            {
                seat.CssClass = "seat_avail";
                seat.Enabled = true;
            }
            return currentSeatList;
        }

        private void UpdateTicketMessage()
        {
            if (Session["SelectionAvailable"] == null)
            {
                TicketAmount.Visible = false;
            }
            else
            {
                List<string> currentSeats = (List<string>)Session["SelectedSeats"];
                int remainingSelect = int.Parse(Session["SelectionAvailable"].ToString()) - currentSeats.Count;
                if (remainingSelect > 0)
                {
                    TicketAmount.Text = "Remaining selectable seats: " + remainingSelect + ".";
                    TicketAmount.CssClass = "ticket_mess";
                }
                else if(remainingSelect == 0)
                {
                    TicketAmount.Text = "You have reached the limit of your seat selection";
                    TicketAmount.CssClass = "ticket_mess_error";
                }
                else
                {
                    TicketAmount.Text = "You are limiting the seat selection.Please uncheck your selected seats\n" +
                                        "Overlimited seats: " + (-remainingSelect)+".";
                    TicketAmount.CssClass = "ticket_mess_error";
                }
                TicketAmount.Visible = true;
                ReachLimitSelect(remainingSelect);
            }
        }

        private void ReachLimitSelect(int AmountDifference)
        {
            List<Button> seatList = loadSeatList();
            bool enable = true;
            if (AmountDifference <= 0)
            {
                enable = false;    
            }
            foreach (var seat in seatList)
            {
                if (!seat.CssClass.Equals("seat_select"))
                {
                    seat.Enabled = enable;
                }                
            }
        }

        private void EnableSelect()
        {
            List<Button> seatList = loadSeatList();
            foreach (var seat in seatList)
            {
                seat.Enabled = true;
            }
        }

        private void DisableSelect()
        {
            List<Button> seatList = loadSeatList();
            foreach (var seat in seatList)
            {
                seat.Enabled = false;
            }
        }

        private void ReturnSessionAfterLogged()
        {
            if (Session["CurrentSelectdlMovie"]!= null)
            {
                string dlMovieListSelected = Session["CurrentSelectdlMovie"].ToString();
                dlMovieList.SelectedValue = dlMovieListSelected;
                MovieDTO mDTO = mDAO.getMovieDTO((List<MovieDTO>)Session["MovieList"], dlMovieListSelected)[0];

                if(Session["CurrentSelectdlSchedule"] != null)
                {                    
                    dlScheduleList.Items.Clear();
                    List<ScheduleDTO> scheduleList = sDAO.getSpecificMovieSchedule((List<ScheduleDTO>)Session["ScheduleList"], mDTO.MovieID);
                    if (scheduleList.Count != 0)
                    {
                        dlScheduleList.Items.Add("--Select a schedule--");
                    }
                    else
                    {
                        dlScheduleList.Items.Add("--Currently There is no schedule for this movie--");
                    }
                    LoadScheduleToDropDownList(scheduleList);
                    dlScheduleList.Enabled = true;
                    string dlScheduleSelected = Session["CurrentSelectdlSchedule"].ToString();
                    if (dlScheduleSelected.Equals("--Select a schedule--") || dlScheduleSelected.Equals("--Currently There is no schedule for this movie--"))
                    {
                        dlScheduleList.SelectedValue = dlScheduleSelected;
                    }
                    else
                    {
                        ScheduleDTO sDTO = sDAO.GetScheduleDTO((List<ScheduleDTO>)Session["ScheduleList"], dlScheduleSelected);
                        dlScheduleList.SelectedValue = sDTO.ScheduleDate + " at Room No. " + sDTO.RoomID;

                        dlTicketNum.Items.Clear();
                        List<string> bookedSeatList = odDAO.GetAllSeats(sDTO.ScheduleID);
                        int bookedSeat;
                        if (bookedSeatList == null)
                        {
                            bookedSeat = 0;
                        }
                        else
                        {
                            bookedSeat = bookedSeatList.Count;
                        }
                        int remainingSeat = rDAO.getRoom((List<RoomDTO>)Session["RoomList"], sDTO.RoomID).NumberOfSeat - bookedSeat;
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
                        lblPriceTicket.Text = "Per Ticket costs " + sDTO.PriceOfTicket + " $";
                        lblPriceTicket.Visible = true;
                        roomTitle.Text = "Room " + sDTO.RoomID;

                        EnableSelect();
                        MarkBookedSeats(bookedSeatList, loadSeatList());

                        if (Session["SelectionAvailable"] != null)
                        {
                            dlTicketNum.SelectedValue = Session["SelectionAvailable"].ToString();
                            if (Session["SelectedSeats"] != null)
                            {
                                List<string> selectedSeatsList = (List<string>)Session["SelectedSeats"];
                                MarkSelectedSeats(selectedSeatsList, loadSeatList());
                                if (selectedSeatsList.Count == 0)
                                {
                                    lblNoBookSession.Visible = true;
                                }
                                else
                                {
                                    lblNoBookSession.Visible = false;
                                }
                            }
                        }
                    }                                        
                }
            }
            UpdateTicketMessage();
        }

        protected void btnSeat_Click(object sender, EventArgs e)
        {
            Button thisSeat = (Button)sender;                        
            List<string> currentSelectedList = (List<string>)Session["SelectedSeats"];
            if (thisSeat.CssClass.Equals("seat_avail"))
            {
                thisSeat.CssClass = "seat_select";
                currentSelectedList.Add(thisSeat.Text);                
            }
            else
            {
                thisSeat.CssClass = "seat_avail";
                currentSelectedList.Remove(thisSeat.Text);                
            }            
            Session["SelectedSeats"] = currentSelectedList;            
            if (currentSelectedList.Count == 0)
            {
                lblNoBookSession.Visible = true;
            }
            else
            {
                lblNoBookSession.Visible = false;
            }
            UpdateTicketMessage();
        }
    }
}