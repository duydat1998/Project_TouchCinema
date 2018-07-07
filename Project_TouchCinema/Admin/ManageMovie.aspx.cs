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
                Session.Add("MovieList", listMovie);
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

        public int ReturnGenreID(string genreName)
        {
            int id = 0;
            List<GenreDTO> list = (List<GenreDTO>)Session["AdminGenreList"];
            foreach(GenreDTO item in list)
            {
                if (item.GenreName.Equals(genreName))
                {
                    id = item.GenreID;
                }
            }
            return id;
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
            int genre = ReturnGenreID(dlGenre.SelectedValue);

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
                Genre = genre
            };
            try
            {
                if (MovieDao.AddNewMovie(dto))
                {
                    List<MovieDTO> list = (List<MovieDTO>)Session["MovieList"];
                    list.Add(dto);
                    gvStaffList.DataSource = list;
                    gvStaffList.DataBind();
                    SetMessageTextAndColor("Successfully added", Color.Green);
                    btnDelete.Enabled = true;
                    btnUpdate.Enabled = true;
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
            lblMessage.Text = "";
            btnUpdate.Enabled = true;
            string id = (sender as LinkButton).CommandArgument;
            List<MovieDTO> list = (List<MovieDTO>)Session["MovieList"];
            List<GenreDTO> listgenre = (List<GenreDTO>)Session["AdminGenreList"];
            for (int i = 0; i <= list.Count - 1; i++)
            {
                if (list[i].MovieID == id)
                {
                    txtMovieID.Text = list[i].MovieID;
                    txtMovieTitle.Text = list[i].MovieTitle;
                    txtLength.Text = list[i].Length.ToString();
                    txtRating.Text = list[i].Rating.ToString();
                    txtPoster.Text = list[i].Poster;
                    txtTrailer.Text = list[i].LinkTrailer;
                    txtStartDate.Text = list[i].StartDate.ToShortDateString();
                    txtProducer.Text = list[i].Producer;
                    txtYear.Text = list[i].Year.ToString();
                    foreach(GenreDTO item in listgenre)
                    {
                        if (item.GenreID==list[i].Genre)
                        {
                            dlGenre.Text = item.GenreName;
                        }
                    }
                }
            }
            txtMovieID.Enabled = false;
            btnNew.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string movieID = txtMovieID.Text;
            if (MovieDao.DeleteMovie(movieID))
            {
                List<MovieDTO> list = (List<MovieDTO>)Session["MovieList"];
                foreach(MovieDTO item in list)
                {
                    if (item.MovieID.Equals(movieID))
                    {
                        list.Remove(item);
                    }
                }
                gvStaffList.DataSource = list;
                gvStaffList.DataBind();
                SetMessageTextAndColor("Successfully deleted", Color.Green);
                Clear();
            }
            else
            {
                SetMessageTextAndColor("Failed to delete", Color.Red);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
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
            }
            catch
            {
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
            int genre = ReturnGenreID(dlGenre.SelectedValue);

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
                Genre = genre
            };

            try
            {
                if (MovieDao.UpdateMovie(dto))
                {
                    List<MovieDTO> list = (List<MovieDTO>)Session["MovieList"];
                    foreach(MovieDTO item in list)
                    {
                        if (item.MovieID.Equals(id))
                        {
                            item.MovieTitle = dto.MovieTitle;
                            item.Year = dto.Year;
                            item.Length = dto.Length;
                            item.Rating = dto.Rating;
                            item.Producer = dto.Producer;
                            item.Poster = dto.Poster;
                            item.LinkTrailer = dto.LinkTrailer;
                            item.StartDate = dto.StartDate;
                            item.Genre = dto.Genre;
                        }
                    }
                    gvStaffList.DataSource = list;
                    gvStaffList.DataBind();
                    SetMessageTextAndColor("Successfully updated", Color.Green);
                }
                else
                {
                    SetMessageTextAndColor("Failed to update", Color.Red);
                }
            }
            catch
            {
                SetMessageTextAndColor("Server encounter a fatal error please try again later.", Color.Red);
            }
        }

        public List<MovieDTO> SearchInListByMovieName(List<MovieDTO> list, string searchValue)
        {
            List<MovieDTO> result = new List<MovieDTO>();
            foreach (MovieDTO item in list)
            {
                if (item.MovieTitle.ToUpper().IndexOf(searchValue.ToUpper()) >= 0)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Clear();
            string searchValue = txtSearch.Text;
            List<MovieDTO> list = (List<MovieDTO>)Session["MovieList"];
            if (!searchValue.Equals(""))
            {
                List<MovieDTO> result = SearchInListByMovieName(list, searchValue);
                if (result.Count > 0)
                {
                    lblMessage.Text = "";
                    gvStaffList.Visible = true;
                    gvStaffList.DataSource = null;
                    gvStaffList.DataSource = result;
                    gvStaffList.DataBind();
                }
                else
                {
                    gvStaffList.Visible = false;
                    gvStaffList.DataSource = null;
                    SetMessageTextAndColor("No record found", Color.Red);
                }

            }
            
            
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            Clear();
            List<MovieDTO> list = (List<MovieDTO>)Session["MovieList"];
            gvStaffList.Visible = true;
            gvStaffList.DataSource = list;
            gvStaffList.DataBind();
        }
    }
}