using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MovieLibrary;
using GenreLibrary;
using RoomLibrary;
using ScheduleLibrary;

namespace Project_TouchCinema
{
    public partial class MemberWorkspace : System.Web.UI.Page
    {
        MovieDAO mDAO = new MovieDAO();
        GenreDAO gDAO = new GenreDAO();
        ScheduleDAO sDAO = new ScheduleDAO();
        RoomDAO rDAO = new RoomDAO();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LastestMovieList.DataSource = mDAO.getTopFiveLastestMovie();               
                LastestMovieList.DataBind();
                MostRatingMovieList.DataSource = mDAO.getTopFiveRatingMovie();
                MostRatingMovieList.DataBind();
                LoadAllLists();
                Session["CurrentPage"] = "TouchCinema.aspx";
            }            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {            
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Session["SearchValue"] = "";
            Response.Redirect("MemberRegister.aspx");
        }

        protected void btnSeacrh_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearchValue.Text;
            List<MovieDTO> resultList = mDAO.searchByName((List<MovieDTO>)Session["MovieList"], searchValue);
            Session["SearchResult"] = resultList;
            Session["SearchValue"] = searchValue;
            Response.Redirect("SearchResultPage.aspx");
        }

        private void LoadAllLists()
        {
            Session["MovieList"] = mDAO.GetMovieList();
            Session["ScheduleList"] = sDAO.GetScheduleFromNowOn();
            Session["RoomList"] = rDAO.GetRoomList();
            Session["GenreList"] = gDAO.GetGenreList();
        }
    }
}