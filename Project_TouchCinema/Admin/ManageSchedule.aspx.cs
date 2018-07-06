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
                for (int i = 9; i <= 12; i++)
                {
                    dlHour.Items.Add(i.ToString());
                }
            }
            else if(dlState.SelectedValue.Equals("PM"))
            {
                dlHour.Items.Clear();
                for (int i = 1; i <= 12; i++)
                {
                    dlHour.Items.Add(i.ToString());
                }
            }
            
            for (int i = 0; i <= 59; i++)
            {
                dlMinute.Items.Add(i.ToString());
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            List<ScheduleDTO> list = (List<ScheduleDTO>)Session["AdminScheduleList"];
            gvStaffList.DataSource = list;
            gvStaffList.DataBind();
            lblMessage.Text = "";
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {

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

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void lnkView_Click(object sender, EventArgs e)
        {

        }

        protected void dlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimeDropdownListAdd();
        }
    }
}