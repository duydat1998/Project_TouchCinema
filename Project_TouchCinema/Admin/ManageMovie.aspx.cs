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

        public void SetMessageTextAndColor(string msg, Color color)
        {
            lblMessage.Text = msg;
            lblMessage.ForeColor = color;
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            string id = txtMovieID.Text.Trim();
            string title = txtMovieTitle.Text.Trim();
            int year = 0, length = 0;
            float rating = 0;
            try
            {
                length = Convert.ToInt32(txtLength.Text);
            }
            catch
            {
                SetMessageTextAndColor("Length must be a number", Color.Red);
            }
            try
            {
                year = Convert.ToInt32(txtYear.Text);
            }catch{
                SetMessageTextAndColor("Year must be a number", Color.Red);
            }
            try
            {
                rating = float.Parse(txtRating.Text);
            }
            catch
            {
                SetMessageTextAndColor("Rating must be a number", Color.Red);
            }
            string producer = txtProducer.Text.Trim();
            string poster = txtPoster.Text.Trim();
            string trailer = txtTrailer.Text.Trim();
            DateTime startDate = new DateTime();
            try
            {
                startDate = DateTime.Parse(txtStartDate.Text);
            }
            catch
            {
                SetMessageTextAndColor("Start Date is wrong format , format must be MM/dd/yyyy", Color.Red);
            }

            MovieDTO dto = new MovieDTO
            {
                MovieID = id,
                MovieTitle = title,
                Length = length,
                Rating = rating,
                StartDate = startDate,
                Poster = poster,
                LinkTrailer = trailer,
                Producer = producer,
                Year = year,
            };
            try
            {
                if (MovieDao.AddNewMovie(dto))
                {
                    List<MovieDTO> list = (List<MovieDTO>)Session["AdminMovieList"];
                    list.Add(dto);
                    gvStaffList.DataSource = list;
                    gvStaffList.DataBind();
                    SetMessageTextAndColor("Successfully added", Color.Green);
                }
                else
                {
                    SetMessageTextAndColor("Failed to add", Color.Red);
                }
            }
            catch
            {
                SetMessageTextAndColor("Movie ID is already existed", Color.Red);
            }

            
            
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