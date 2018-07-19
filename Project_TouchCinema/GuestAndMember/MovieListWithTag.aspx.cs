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

namespace Project_TouchCinema.GuestAndMember
{
    public partial class MovieListWithTag : System.Web.UI.Page
    {
        MovieDAO mDAO = new MovieDAO();
        GenreDAO gDAO = new GenreDAO();
        ScheduleDAO sDAO = new ScheduleDAO();
        RoomDAO rDAO = new RoomDAO();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllLists();
                string tagValue = Request.QueryString["tag"];
                string tagType = Request.QueryString["type"];
                MoviesTag.Text = MakeTagHeader(tagType, tagValue);
                if (tagType.Equals("genre"))
                {
                    int genreID = int.Parse(tagValue);
                    TaggedMovieList.DataSource = mDAO.getMovieListByGenre((List<MovieDTO>)Session["MovieList"], genreID, null);
                }
                else if (tagType.Equals("producer"))
                {
                    TaggedMovieList.DataSource = mDAO.getMovieListByProducer((List<MovieDTO>)Session["MovieList"], tagValue, null);
                }
                else
                {
                    TaggedMovieList.DataSource = new List<MovieDTO>();
                }
                TaggedMovieList.DataBind();
                Session["CurrentPage"] = "MovieListWithTag.aspx";
            }
        }
        
        private string MakeTagHeader(string tagType, string tagValue)
        {
            if (tagType.Equals("genre"))
            {
                return "Movies also have " + getGenreName(tagValue,(List<GenreDTO>)Session["GenreList"]) + " genre";
            }
            else if (tagType.Equals("producer"))
            {
                return "Movies also have been made from " + tagValue;
            }
            else
            {
                return "";
            }
        }

        private string getGenreName(string tagValue, List<GenreDTO> genreList)
        {
            string result = "";
            int genreID = int.Parse(tagValue);
            foreach (var genre in genreList)
            {                
                if(genre.GenreID == genreID)
                {
                    result = genre.GenreName;
                    break;
                }
            }
            return result;
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