using MovieLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_TouchCinema.GuestAndMember
{
    public partial class SearchResultPage : System.Web.UI.Page
    {
        MovieDAO mDAO = new MovieDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string SearchValue = (string)Session["SearchValue"];
                if (Session["MovieList"] == null)
                {
                    Session["MovieList"] = mDAO.GetMovieList();
                }
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
            List<MovieDTO> resultList = searchByName((List<MovieDTO>)Session["MovieList"], searchValue);
            Session["SearchResult"] = resultList;
            Session["SearchValue"] = searchValue;            
            Response.Redirect("SearchResultPage.aspx");
        }

        private List<MovieDTO> searchByName(List<MovieDTO> listMovie, string searchValue)
        {
            List<MovieDTO> resultList = new List<MovieDTO>();
            foreach (MovieDTO item in listMovie)
            {
                if (item.MovieTitle.ToUpper().Contains(searchValue.ToUpper()))
                {
                    resultList.Add(item);
                }

            }
            return resultList;
        }
    }
}