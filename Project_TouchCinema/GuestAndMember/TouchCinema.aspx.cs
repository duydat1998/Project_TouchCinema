using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MovieLibrary;

namespace Project_TouchCinema
{
    public partial class MemberWorkspace : System.Web.UI.Page
    {
        MovieDAO mDAO = new MovieDAO();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MovieList.DataSource = mDAO.getTopFiveMovie();               
                MovieList.DataBind();                                
            }
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {            
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

        }

        protected void btnSeacrh_Click(object sender, EventArgs e)
        {

        }
    }
}