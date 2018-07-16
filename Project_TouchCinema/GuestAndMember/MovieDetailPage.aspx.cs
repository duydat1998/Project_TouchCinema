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
    public partial class MovieDetailPage : System.Web.UI.Page
    {
        MovieDAO mDAO = new MovieDAO();
        GenreDAO gDAO = new GenreDAO();
        ScheduleDAO sDAO = new ScheduleDAO();
        RoomDAO rDAO = new RoomDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string movieTitle = Request.QueryString["movieTitle"];
                LoadAllLists();

                List<MovieDTO> movieDetal = mDAO.getMovieDTO((List<MovieDTO>)Session["MovieList"], movieTitle);                
                if(movieDetal.Count == 0 || movieDetal == null)
                {
                    MovieDataEmpty.Visible = true;
                }
                else
                {
                    MovieDataEmpty.Visible = false;
                }
                int movieGenreID = movieDetal[0].Genre;
                string movieGenreName = mDAO.getGenreName(movieDetal, (List<GenreDTO>)Session["GenreList"])[0].GenreName;
                string movieProducer = movieDetal[0].Producer;
                MovieDataForm.DataSource = movieDetal;
                MovieDataForm.DataBind();

                MovieSameGenre.Text = "Movies also have " + movieGenreName + " genre";
                MovieSameGenreList.DataSource = mDAO.getFiveMovieReference(mDAO.getMovieListByGenre((List<MovieDTO>)Session["MovieList"], movieGenreID, movieDetal[0]));
                MovieSameGenreList.DataBind();
                GenreTagLink.NavigateUrl = "MovieListWithTag.aspx?tag=" + movieGenreID + "&type=genre";


                MovieSameProducer.Text = "Movies also have been made from " + movieProducer;                
                MovieSameProducerList.DataSource = mDAO.getFiveMovieReference(mDAO.getMovieListByProducer((List<MovieDTO>)Session["MovieList"], movieProducer, movieDetal[0]));
                MovieSameProducerList.DataBind();
                Session["MovieProducer"] = movieProducer;
                ProducerTagLink.NavigateUrl = "MovieListWithTag.aspx?tag=" + movieProducer + "&type=producer";
            }            
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