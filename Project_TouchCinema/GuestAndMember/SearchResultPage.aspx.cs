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
    public partial class SearchResultPage : System.Web.UI.Page
    {
        MovieDAO mDAO = new MovieDAO();
        GenreDAO gDAO = new GenreDAO();
        ScheduleDAO sDAO = new ScheduleDAO();
        RoomDAO rDAO = new RoomDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string SearchValue = (string)Session["SearchValue"];
                LoadAllLists();
                txtSearchValue.Text = SearchValue;
                List<MovieDTO> resultList = (List<MovieDTO>)Session["SearchResult"];
                if (resultList == null || resultList.Count == 0)
                {
                    ResultEmpty.Visible = true;
                    ResultFor.Text = "";
                    ResultFor.Visible = true;
                }
                else
                {
                    ResultEmpty.Visible = false;
                    ResultFor.Text = resultList.Count + " matches for " + SearchValue;
                    ResultFor.Visible = true;
                    ResultDetail.DataSource = resultList;
                    ResultDetail.DataBind();
                }
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