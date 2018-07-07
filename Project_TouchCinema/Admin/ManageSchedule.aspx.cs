using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using MovieLibrary;
using RoomLibrary;
using ScheduleLibrary;

namespace Project_TouchCinema
{
    public partial class ManageSchedule : System.Web.UI.Page
    {
        MovieDTO MovieDtos = new MovieDTO();
        MovieDAO MovieDaos = new MovieDAO();
        RoomDTO RoomDtos = new RoomDTO();
        RoomDAO RoomDaos = new RoomDAO();
        ScheduleDTO ScheduleDtos = new ScheduleDTO();
        ScheduleDAO ScheduleDaos = new ScheduleDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<MovieDTO> ListMovie = new List<MovieDTO>();
                List<RoomDTO> ListRoom = new List<RoomDTO>();
                List<ScheduleDTO> ListSchedule = new List<ScheduleDTO>();
                ListMovie = MovieDaos.GetMovieList();
                Session.Add("AdminMovieList", ListMovie);
                ListRoom = RoomDaos.GetRoomList();
                Session.Add("AdminRoomList", ListRoom);
                ListSchedule = ScheduleDaos.GetScheduleList();
                Session.Add("AdminScheduleList", ListSchedule);
                gvStaffList.DataSource = ListSchedule;
                gvStaffList.DataBind();
                MovieIDDropdownListAdd(ListMovie);
                RoomIDDropdownListAdd(ListRoom);
                TimeDropdownListAdd();
                Clear();
            }
        }

        public void MovieIDDropdownListAdd(List<MovieDTO> list)
        {
            foreach (MovieDTO item in list)
            {
                dlMovieID.Items.Add(item.MovieID);
            }
        }
        public void RoomIDDropdownListAdd(List<RoomDTO> list)
        {
            foreach (RoomDTO item in list)
            {
                dlRoomID.Items.Add(item.RoomID.ToString());
            }
        }
        public void TimeDropdownListAdd()
        {

            if (dlState.SelectedValue.Equals("AM"))
            {
                dlHour.Items.Clear();
                for (int i = 9; i <= 11; i++)
                {
                    dlHour.Items.Add(i.ToString());
                }
            }
            else if(dlState.SelectedValue.Equals("PM"))
            {
                dlHour.Items.Clear();
                for (int i = 0; i <= 11; i++)
                {
                    dlHour.Items.Add(i.ToString());
                }
            }
            
            for (int i = 0; i <= 59; i++)
            {
                if (i < 10)
                {
                    dlMinute.Items.Add("0" + i.ToString());
                }
                else
                {
                    dlMinute.Items.Add(i.ToString());
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Clear(); 
            string searchValue = txtSearch.Text;
            List<ScheduleDTO> list = (List<ScheduleDTO>)Session["AdminScheduleList"];
            if (!searchValue.Equals(""))
            {
                List<ScheduleDTO> result = SearchInListByMovieName(list, searchValue);
                if (result.Count > 0)
                {
                    lblMessage.Text = "";
                    gvStaffList.Visible = true;
                    gvStaffList.DataSource = null;
                    gvStaffList.DataSource = result;
                    gvStaffList.DataBind();
                }
                else
                {
                    gvStaffList.Visible = false;
                    gvStaffList.DataSource = null;
                    SetMessageTextAndColor("No record found", Color.Red);
                }

            }
        }

        public List<ScheduleDTO> SearchInListByMovieName(List<ScheduleDTO> list, string searchValue)
        {
            List<ScheduleDTO> result = new List<ScheduleDTO>();
            foreach (ScheduleDTO item in list)
            {
                if (item.MovieID.ToUpper().Contains(searchValue.ToUpper()))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            List<ScheduleDTO> list = (List<ScheduleDTO>)Session["AdminScheduleList"];
            gvStaffList.Visible = true;
            gvStaffList.DataSource = list;
            gvStaffList.DataBind();
            lblMessage.Text = "";
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            string id = txtScheduleID.Text;
            string date = txtDate.Text;
            if (!CheckDate(date))
            {
                SetMessageTextAndColor("Date is wrong format , format must be MM/dd/yyyy", Color.Red);
                return;
            }
            string time = ConvertToTime(dlHour.SelectedValue, dlMinute.SelectedValue, dlState.SelectedValue);
            string movieid = dlMovieID.SelectedValue;
            int roomID = Convert.ToInt32(dlRoomID.SelectedValue);

        }

        public bool CheckDate(string date)
        {
            bool check = true;
            try
            {
                DateTime dateConvert = Convert.ToDateTime(date);
            }
            catch
            {
                check = false;
            }

            return check;
        }

        public string ConvertToTime(string hour, string min, string state)
        {
            string result = "";

            result = hour + ":" + min + ":" + ":00" + " " + state;

            return result;
        }
        

        public void Clear()
        {
            btnNew.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            txtDate.Text = "";
            txtScheduleID.Text = "";
            txtPrice.Text = "";
            lblMessage.Text = "";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtScheduleID.Text;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void lnkView_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            btnUpdate.Enabled = true;
            string id = (sender as LinkButton).CommandArgument;
            List<ScheduleDTO> listschedule = (List<ScheduleDTO>)Session["AdminScheduleList"];
            for (int i = 0; i <= listschedule.Count - 1; i++)
            {
                if(listschedule[i].ScheduleID == id)
                {
                    txtScheduleID.Text = listschedule[i].ScheduleID;
                    string datetime = listschedule[i].ScheduleDate.ToString().Trim();
                    Tuple<string, string, string> dateTextAndState = SplitDateTime(datetime);
                    Tuple<string, string> time = SplitTime(dateTextAndState.Item2.Trim());
                    txtDate.Text = dateTextAndState.Item1.Trim();
                    dlState.Text = dateTextAndState.Item3.Trim();
                    dlState_SelectedIndexChanged(sender, e);
                    dlHour.Text = time.Item1.Trim();
                    dlMinute.Text = time.Item2.Trim();
                    txtPrice.Text = listschedule[i].PriceOfTicket.ToString();
                }
                
            }
            txtScheduleID.Enabled = false;
            btnNew.Enabled = false;
        }

        public Tuple<string, string> SplitTime(string input)
        {
            string hour = "";
            string min = "";

            string[] time;

            time = input.Split(':');
            hour = time.ElementAt(0);
            min = time.ElementAt(1);

            return Tuple.Create(hour, min);
        }

        public Tuple<string, string, string> SplitDateTime(string input)
        {
            string date = "";
            string time = "";
            string state = "";

            string[] cache;

            cache = input.Split(' ');
            date = cache.ElementAt(0);
            time = cache.ElementAt(1);
            state = cache.ElementAt(2);

            return Tuple.Create(date, time, state);
        }

        protected void dlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimeDropdownListAdd();
        }


        public void SetMessageTextAndColor(string msg, Color color)
        {
            lblMessage.Text = msg;
            lblMessage.ForeColor = color;
        }
    }
}