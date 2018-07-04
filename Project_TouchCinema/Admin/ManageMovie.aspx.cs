using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GenreLibrary;
using MovieLibrary;
using System.Drawing;

namespace Project_TouchCinema
{
    public partial class ManageMovie : System.Web.UI.Page
    {
        GenreDAO GenreDao = new GenreDAO();
        List<GenreDTO> listGenre = new List<GenreDTO>();
        MovieDAO MovieDao = new MovieDAO();
        List<MovieDTO> listMovie = new List<MovieDTO>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listGenre = GenreDao.GetGenreList();
                Session.Add("AdminGenreList", listGenre);
                
                    listMovie = MovieDao.GetMovieList();
                
                Session.Add("AdminMovieList", listMovie);
                gvStaffList.DataSource = listMovie;
                gvStaffList.DataBind();
                DropdownListAdd(listGenre);
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }
        }

        public void DropdownListAdd(List<GenreDTO> list)
        {
            foreach(GenreDTO item in list)
            {
                dlGenre.Items.Add(item.GenreName);
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {

        }

        public void Clear()
        {
            txtMovieID.Text = "";
            txtMovieTitle.Text = "";
            txtLength.Text = "";
            txtPoster.Text = "";
            txtProducer.Text = "";
            txtRating.Text = "";
            txtStartDate.Text = "";
            txtYear.Text = "";
            txtTrailer.Text = "";
            lblMessage.Text = "";
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnNew.Enabled = true;
            txtMovieID.Enabled = true;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void lnkView_Click(object sender, EventArgs e)
        {
            txtMovieID.Enabled = false;
            btnNew.Enabled = false;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string movieID = txtMovieID.Text;
            MovieDAO dao = new MovieDAO();


            Clear();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        public List<MovieDTO> SearchInListByUsername(List<MovieDTO> list, string searchValue)
        {
            List<MovieDTO> result = new List<MovieDTO>();
            foreach (MovieDTO item in list)
            {
                if (item.MovieTitle.IndexOf(searchValue) >= 0)
                {
                    result.Add(item);
                }

            }
            return result;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {

        }
    }
}