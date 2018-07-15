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
using System.Globalization;

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
                ListMovie = MovieDaos.GetMovieListForSchedule();
                Session.Add("AdminMovieList", ListMovie);

                ListRoom = RoomDaos.GetRoomListForSchedule();
                Session.Add("AdminRoomList", ListRoom);

                ListSchedule = ScheduleDaos.GetScheduleList();
                Session.Add("AdminScheduleList", ListSchedule);
                
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
                dlSearch.Items.Add(item.MovieID);
            }
        }
        public void RoomIDDropdownListAdd(List<RoomDTO> list)
        {
            if (list != null)
            {
                foreach (RoomDTO item in list)
                {
                    dlRoomID.Items.Add(item.RoomID.ToString());
                }
            }
            
        }
        public void TimeDropdownListAdd()
        {

            if (dlState.SelectedValue.Equals("AM"))
            {
                dlHour.Items.Clear();
                for (int i = 9; i <= 11; i++)
                {
                    if (i < 10)
                    {
                        dlHour.Items.Add("0"+i.ToString());
                    }
                    else
                    {
                        dlHour.Items.Add(i.ToString());
                    }
                    
                }
            }
            else if(dlState.SelectedValue.Equals("PM"))
            {
                dlHour.Items.Clear();
                for (int i = 0; i <= 11; i++)
                {
                    if (i < 10)
                    {
                        dlHour.Items.Add("0" + i.ToString());
                    }
                    else
                    {
                        dlHour.Items.Add(i.ToString());
                    }
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
            string searchValue = dlSearch.SelectedValue;
            
            if (!searchValue.Equals(""))
            {

                List<ScheduleDTO> searchResultList = new List<ScheduleDTO>();
                searchResultList = ScheduleDaos.GetScheduleListByMovieID(searchValue);
                Session.Add("AdminSearchList", searchResultList);
                if (searchResultList.Count > 0)
                {
                    lblMessage.Text = "";
                    gvStaffList.Visible = true;
                    gvStaffList.DataSource = null;
                    gvStaffList.DataSource = searchResultList;
                    gvStaffList.DataBind();
                }
                else if(searchResultList==null)
                {
                    gvStaffList.Visible = false;
                    gvStaffList.DataSource = null;
                    SetMessageTextAndColor("No record found", Color.Red);
                }
                else
                {
                    gvStaffList.Visible = false;
                    gvStaffList.DataSource = null;
                    SetMessageTextAndColor("No record found", Color.Red);
                }

            }
        }
        
        protected void btnNew_Click(object sender, EventArgs e)
        {
            string id = txtScheduleID.Text;
            string date = ParseExactDateString(txtDate.Text.Trim());
            string time = ConvertToTime(dlHour.SelectedValue, dlMinute.SelectedValue, dlState.SelectedValue.ToUpper());
            float price = 0;
            try
            {
                price = float.Parse(txtPrice.Text);
            }
            catch
            {
                SetMessageTextAndColor("Price must be a number!", Color.Red);
                return;
            }
            if (!CheckDateTime(date, time))
            {
                SetMessageTextAndColor("Date Format is invalid, format: MM/dd/yyyy.", Color.Red);
                return;
            }
            string datetime = date + " " + time;
            string movieid = dlMovieID.SelectedValue;
            int roomID = Convert.ToInt32(dlRoomID.SelectedValue);
            List<ScheduleDTO> list = (List<ScheduleDTO>)Session["AdminScheduleList"];
            foreach (ScheduleDTO item in list)
            {
                if (movieid.Equals(item.MovieID) && roomID == item.RoomID && datetime.Equals(ConvertScheduleDateInListToCompare(item.ScheduleDate.ToString())))
                {
                    SetMessageTextAndColor("This time: " + datetime + " with Room: " + roomID + " and MovieID: " + movieid + " has already been added, please try again!", Color.Red);
                    return;
                } else if (datetime.Equals(ConvertScheduleDateInListToCompare(item.ScheduleDate.ToString())) && roomID == item.RoomID)
                {
                    SetMessageTextAndColor("This time: " + datetime + ", at Room: " + roomID + " has already been set up. Please try again.", Color.Red);
                    return;
                }
            }
            string format = "MM/dd/yyyy hh:mm:ss tt";
            ScheduleDTO dto = new ScheduleDTO
            {
                ScheduleID = id,
                ScheduleDate = DateTime.ParseExact(datetime, format, CultureInfo.CurrentCulture),
                MovieID = movieid,
                RoomID=roomID,
                PriceOfTicket=price
            };
            try
            {
                if (ScheduleDaos.AddSchedule(dto))
                {
                    SetMessageTextAndColor("Successfully added!", Color.Green);
                }
                else
                {
                    SetMessageTextAndColor("Failed to add!", Color.Red);
                }
            }
            catch
            {
                SetMessageTextAndColor("ScheduleID is duplicated, please choose another one!", Color.Red);
            }
            
        }

        public string ConvertScheduleDateInListToCompare(string date)
        {
            string result = "";
            Tuple<string, string, string> DateTimeState = SplitDateTime(date);
            string dateToCompare = ParseExactDateString(DateTimeState.Item1);
            Tuple<string, string> Time = SplitTime(DateTimeState.Item2);
            string timeToCompare = ConvertToTime(Time.Item1, Time.Item2, DateTimeState.Item3);
            result = dateToCompare + " " + timeToCompare;
            return result;
        }

        public string ParseExactDateString(string date)
        {
            string result = "";

            int month = 0;
            int day = 0;
            string monthText = "";
            string dayText = "";
            string[] parts;

            parts = date.Split('/');
            month = Convert.ToInt32(parts.ElementAt(0));
            day = Convert.ToInt32(parts.ElementAt(1));

            if (month < 10)
            {
                monthText = "0" + month.ToString();
            }
            else
            {
                monthText = month.ToString();
            }

            if (day < 10)
            {
                dayText = "0" + day.ToString();
            }
            else
            {
                dayText = day.ToString();
            }
            result = monthText +"/"+ dayText +"/"+ parts.ElementAt(2);
            return result;
        }

        public bool CheckDateTime(string date,string time)
        {
            bool check=true;
            string format = "MM/dd/yyyy hh:mm:ss tt";
            try
            {
                DateTime dateConvert = DateTime.ParseExact(date+" "+time,format, CultureInfo.CurrentCulture);
            }
            catch
            {
                check = false;
            }

            return check;
        }

        public string ConvertToTime(string hour, string min,string state)
        {
            string result = "";
            
            result =hour + ":" + min + ":" + "00"+" "+state;

            return result;
        }
        
        public void Clear()
        {
            btnNew.Enabled = true;
            btnUpdate.Enabled = false;
<<<<<<< HEAD
=======
            //btnDelete.Enabled = false;
>>>>>>> 57e44a8e1e8e566cac8f73389a457b3485762a67
            txtScheduleID.Enabled = true;
            txtDate.Text = "";
            txtScheduleID.Text = "";
            txtPrice.Text = "";
            lblMessage.Text = "";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        
        //update lai list
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtScheduleID.Text;
            string date = ParseExactDateString(txtDate.Text.Trim());
            string time = ConvertToTime(dlHour.SelectedValue, dlMinute.SelectedValue, dlState.SelectedValue.ToUpper());
            float price = 0;
            try
            {
                price = float.Parse(txtPrice.Text);
            }
            catch
            {
                SetMessageTextAndColor("Price must be a number!", Color.Red);
                return;
            }
            if (!CheckDateTime(date, time))
            {
                SetMessageTextAndColor("Date Format is invalid, format: MM/dd/yyyy.", Color.Red);
                return;
            }
            string datetime = date + " " + time;
            string movieid = dlMovieID.SelectedValue;
            int roomID = Convert.ToInt32(dlRoomID.SelectedValue);
            List<ScheduleDTO> list = (List<ScheduleDTO>)Session["AdminScheduleList"];
            foreach (ScheduleDTO item in list)
            {
                if (movieid.Equals(item.MovieID) && roomID == item.RoomID && datetime.Equals(ConvertScheduleDateInListToCompare(item.ScheduleDate.ToString())))
                {
                    SetMessageTextAndColor("This time: " + datetime + " with Room: " + roomID + " and MovieID: " + movieid + " has already been added, please try again!", Color.Red);
                    return;
                }
                else if (datetime.Equals(ConvertScheduleDateInListToCompare(item.ScheduleDate.ToString())) && roomID == item.RoomID)
                {
                    SetMessageTextAndColor("This time: " + datetime + ", at Room: " + roomID + " has already been set up. Please try again.", Color.Red);
                    return;
                }
            }
            string format = "MM/dd/yyyy hh:mm:ss tt";
            ScheduleDTO dto = new ScheduleDTO
            {
                ScheduleID = id,
                ScheduleDate = DateTime.ParseExact(datetime, format, CultureInfo.CurrentCulture),
                MovieID = movieid,
                RoomID = roomID,
                PriceOfTicket = price
            };
            if (ScheduleDaos.UpdateSchedule(dto))
            {
                List<ScheduleDTO> ListforUpdate = (List<ScheduleDTO>)Session["AdminSearchList"];
                foreach(ScheduleDTO item in ListforUpdate.ToList())
                {
                    if (item.ScheduleID.Equals(id))
                    {
                        item.MovieID = movieid;
                        item.PriceOfTicket = price;
                        item.RoomID = roomID;
                        item.ScheduleDate = DateTime.ParseExact(datetime,format,CultureInfo.CurrentCulture);
                    }
                }
                gvStaffList.DataSource = ListforUpdate;
                gvStaffList.DataBind();
                SetMessageTextAndColor("Successfully updated!", Color.Green);

            }
            else
            {
                SetMessageTextAndColor("Failed to update!", Color.Red);
            }
        }

        protected void lnkView_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            btnUpdate.Enabled = true;
            List<ScheduleDTO> searchResultList = (List<ScheduleDTO>)Session["AdminSearchList"];
            string id = (sender as LinkButton).CommandArgument;
            //lblMessage.Text = id;
            for (int i = 0; i <= searchResultList.Count - 1; i++)
            {
                if(searchResultList[i].ScheduleID.Equals(id))
                {
                    txtScheduleID.Text = searchResultList[i].ScheduleID;
                    string datetime = searchResultList[i].ScheduleDate.ToString().Trim();
                    Tuple<string, string, string> dateTextAndState = SplitDateTime(datetime);
                    Tuple<string, string> time = SplitTime(dateTextAndState.Item2.Trim());
                    txtDate.Text = dateTextAndState.Item1.Trim();
                    dlState.Text = dateTextAndState.Item3.Trim();
                    dlState_SelectedIndexChanged(sender, e);
                    dlHour.Text = time.Item1;
                    dlMinute.Text = time.Item2;
                    txtPrice.Text = searchResultList[i].PriceOfTicket.ToString();
                }
                
            }
            txtScheduleID.Enabled = false;
            btnNew.Enabled = false;
<<<<<<< HEAD
=======
            //btnDelete.Enabled = true;
>>>>>>> 57e44a8e1e8e566cac8f73389a457b3485762a67
        }

        public Tuple<string, string> SplitTime(string input)
        {
            string hour = "";
            string min = "";
            int hourNo = 0;
            int minNo = 0;

            string[] time;

            time = input.Split(':');
            hourNo = Convert.ToInt32(time.ElementAt(0));
            if (hourNo < 10)
            {
                hour = "0" + hourNo.ToString();
            }
            else
            {
                hour = hourNo.ToString();
            }
            minNo = Convert.ToInt32(time.ElementAt(1));
            if (minNo < 10)
            {
                min = "0" + minNo.ToString();
            }
            else
            {
                min = minNo.ToString();
            }

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