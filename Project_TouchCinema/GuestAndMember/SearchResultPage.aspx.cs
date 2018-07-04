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
            string SearchValue = (string)Session["SearchValue"];
            txtSearchValue.Text = SearchValue;
            List<MovieDTO> resultList = (List<MovieDTO>)Session["SearchResult"];
            if(resultList == null)
            {
                ResultEmpty.Visible = true;
                ResultFor.Text = "";
                ResultFor.Visible = false;
            }
            else
            {
                ResultEmpty.Visible = false;
                ResultFor.Text = resultList.Count + "matches for " + SearchValue;
                ResultFor.Visible = true;
            }
            ResultDetail.DataSource = resultList;
            ResultDetail.DataBind();
        }

        protected void btnSeacrh_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearchValue.Text;
            List<MovieDTO> resultList = mDAO.SearchListMoiveMemberGuest(searchValue);
            Session["SearchResult"] = resultList;
            Session["SearchValue"] = searchValue;
            Response.Redirect("SearchResultPage.aspx");
        }
    }
}