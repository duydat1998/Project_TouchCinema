﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_TouchCinema.GuestAndMember
{
    public partial class TermAndCondition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["CurrentPage"] = "TermAndCondition.aspx";
            }            
        }
    }
}