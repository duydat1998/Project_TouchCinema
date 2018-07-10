using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MovieLibrary;
using ScheduleLibrary;

namespace Project_TouchCinema.GuestAndMember
{
    public partial class MovieSchedulePage : System.Web.UI.Page
    {
        MovieDAO mDAO = new MovieDAO();
        ScheduleDAO sDAO = new ScheduleDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["MovieList"] == null)
                {
                    Session["MovieList"] = mDAO.GetMovieList();
                }
                MovieList.DataSource = (List<MovieDTO>) Session["MovieList"];
                MovieList.DataBind();                
            }
        }
    }
}