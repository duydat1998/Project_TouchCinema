﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MemberLibrary;
namespace Project_TouchCinema
{
    public partial class MemberRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dlDay.Items.Insert(0, new ListItem("Day", "Day"));
                for (int i = 1; i <= 31; i++)
                {
                    ListItem day = new ListItem(i + "", i + "");
                    this.dlDay.Items.Insert(i, day);
                }

                dlMonth.Items.Insert(0, new ListItem("Month", "Month"));
                for (int i = 1; i <= 12; i++)
                {
                    ListItem month = new ListItem(i + "", i + "");
                    this.dlMonth.Items.Insert(i, month);
                }

                dlYear.Items.Insert(0, new ListItem("Year", "Year"));
                for (int i = (DateTime.Today.Year - 10); i >= 1950; i--)
                {
                    ListItem year = new ListItem(i + "", i + "");
                    this.dlYear.Items.Add(year);
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            MemberDAO dao = new MemberDAO();
            string username = txtUsername.Text.Trim();
            if (dao.IsUsernameExist(username))
            {
                string message = "Username already exists.\\nPlease choose a different username.";
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                this.txtUsername.Focus();
                return;
            }
            string password = txtPass.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string firstname = txtFirstName.Text.Trim();
            string lastname = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            int day = int.Parse(dlDay.Text);
            int month = int.Parse(dlMonth.Text);
            int year = int.Parse(dlYear.Text);
            DateTime birthday = new DateTime(year, month, day);
            MemberDTO member = new MemberDTO
            {
                Username = username,
                Password = password,
                PhoneNum = phone,
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                ImageLink = "a",
                IsActive = true,
                Birthdate = birthday,
            };

            bool result = dao.AddNewMemberAdmin(member);
            if (result)
            {
                string message = "Regiter SUCCESSFULLY.\\nPlease login to continue.";
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                Response.Redirect("TouchCinema.aspx");
            }
            else
            {
                Response.Redirect("../ErrorPages/ErrorPage.aspx");
            }
        }

    }
}