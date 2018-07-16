using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MovieLibrary;
using ScheduleLibrary;
using RoomLibrary;

namespace Project_TouchCinema.GuestAndMember
{
    public partial class MovieSchedulePage : System.Web.UI.Page
    {
        MovieDAO mDAO = new MovieDAO();
        ScheduleDAO sDAO = new ScheduleDAO();
        RoomDAO rDAO = new RoomDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllLists();
                Session["ScheduleList"] = sDAO.GetScheduleFromNowOn();
                MovieList.DataSource = getMovieHaveSchedule((List<MovieDTO>)Session["MovieList"], (List<ScheduleDTO>)Session["ScheduleList"]);
                MovieList.DataBind();                
            }
        }

        protected void MovieSchedule_DataBinding(object sender, EventArgs e)
        {
            Repeater MovieSchedule = (Repeater)sender;            
            string movieID = (string)(Eval("MovieID"));
            MovieSchedule.DataSource = sDAO.getSpecificMovieSchedule((List<ScheduleDTO>) Session["ScheduleList"],movieID);            
        }

        private List<MovieDTO> getMovieHaveSchedule(List<MovieDTO> movieList, List<ScheduleDTO> scheduleList)
        {
            List<MovieDTO> result = new List<MovieDTO>();
            foreach (var movie in movieList)
            {
                foreach (var schedule in scheduleList)
                {
                    if (movie.MovieID.ToUpper().Equals(schedule.MovieID.ToUpper()))
                    {
                        result.Add(movie);
                        break;
                    }
                }
            }
            return result;
        }

        private void LoadAllLists()
        {
            Session["MovieList"] = mDAO.GetMovieList();
            Session["ScheduleList"] = sDAO.GetScheduleFromNowOn();
            Session["RoomList"] = rDAO.GetRoomList();
        }
    }
}