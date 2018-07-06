using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MovieLibrary;

namespace Project_TouchCinema.GuestAndMember
{
    public partial class MovieDetailPage : System.Web.UI.Page
    {
        MovieDAO mDAO = new MovieDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string movieTitle = Request.QueryString["movieTitle"];
                List<MovieDTO> movieDetal = getMovieDTO((List<MovieDTO>)Session["MovieList"], movieTitle);
                MovieDataForm.DataSource = movieDetal;
                MovieDataForm.DataBind();
            }            
        }

        private List<MovieDTO> getMovieDTO(List<MovieDTO> listMovie, string movieTitle)
        {
            List<MovieDTO> dto = new List<MovieDTO>();
            foreach(var item in listMovie)
            {
                if (item.MovieTitle.ToUpper().Equals(movieTitle.ToUpper()))
                {
                    dto.Add(item);
                }
            }
            return dto;
        }

        protected void btnSeacrh_Click(object sender, EventArgs e)
        {

        }
    }
}