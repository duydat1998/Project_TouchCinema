using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_TouchCinema
{
    public partial class MemberRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dlDay.Items.Insert(0, new ListItem("Day", ""));
            for(int i=1; i<=31; i++)
            {
                ListItem day = new ListItem(i+"",i+"");
                this.dlDay.Items.Insert(i, day);
            }

            dlMonth.Items.Insert(0, new ListItem("Month", ""));
            for (int i = 1; i <= 12; i++)
            {
                ListItem month = new ListItem(i + "", i + "");
                this.dlMonth.Items.Insert(i, month);
            }

            dlYear.Items.Insert(0, new ListItem("Year", ""));
            for (int i = (DateTime.Today.Year-10); i >= 1950; i--)
            {
                ListItem year = new ListItem(i + "", i + "");
                this.dlYear.Items.Add(year);
            }

        }

    }
}