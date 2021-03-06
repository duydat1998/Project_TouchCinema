﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StaffLibrary;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace Project_TouchCinema
{
    public partial class ManageStaff : System.Web.UI.Page
    {
        List<StaffDTO> AdminStaffList = new List<StaffDTO>();
        StaffDAO dao = new StaffDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        public void Clear()
        {
            txtEmail.Text = "";
            txtFirstname.Text = "";
            txtLastname.Text = "";
            txtPhone.Text = "";
            txtUsername.Text = "";
            btnNew.Enabled = true;
            txtUsername.Enabled = true;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

            Clear();
        }

        public bool IsEmailValid(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            if (username.Equals(""))
            {
                lblMessage.Text = "Username cannot be empty!";
                lblMessage.ForeColor = Color.Red;
                return;
            }
            string password = txtPassword.Text.Trim();
            if (password.Equals(""))
            {
                lblMessage.Text = "Password cannot be empty!";
                lblMessage.ForeColor = Color.Red;
                return;
            }
            string firstname = txtFirstname.Text.Trim();
            string lastname = txtLastname.Text.Trim();
            string phone = txtPhone.Text.Trim();
            double phoneNum = 0;
            try
            {
                phoneNum = double.Parse(phone);
            }
            catch
            {
                lblMessage.Text = "Phone number not valid!";
                lblMessage.ForeColor = Color.Red;
            }
            string email = txtEmail.Text.Trim();
            
            if (!IsEmailValid(email))
            {
                lblMessage.Text = "Email is not valid!";
                lblMessage.ForeColor = Color.Red;
                return;
            }
            StaffDTO dto = new StaffDTO
            {
                Username = username,
                Password = password,
                FirstName = firstname,
                LastName = lastname,
                Phone = phone,
                Email = email,
                IsActive = true
            };
            try
            {
                if (dao.AddNewStaff(username, password, firstname, lastname, phone, email, true))
                {
                    lblMessage.Text = "Successfully added";
                    lblMessage.ForeColor = Color.Green;
                }
                else
                {
                    lblMessage.Text = "Failed to add";
                    lblMessage.ForeColor = Color.Red;
                }
            }
            catch
            {
                lblMessage.Text = "Username is already existed, please choose another one";
                lblMessage.ForeColor = Color.Red;
            }


        }

        protected void btnUpdateActive_Click(object sender, EventArgs e)
        {
            List<StaffDTO> list = (List<StaffDTO>)Session["AdminStaffSearch"];
            foreach (GridViewRow row in gvStaffList.Rows)
            {
                CheckBox status = (row.Cells[5].FindControl("isActive") as CheckBox);
                string username = row.Cells[0].Text;
                if (status.Checked)
                {
                    if (dao.UpdateStaffStatus(username, 1))
                    {
                        for (int i = 0; i <= list.Count - 1; i++)
                        {
                            if (list[i].Username == username)
                            {
                                list[i].IsActive = true;
                            }
                        }
                    }
                }
                else
                {
                    if (dao.UpdateStaffStatus(username, 0))
                    {
                        for (int i = 0; i <= list.Count - 1; i++)
                        {
                            if (list[i].Username == username)
                            {
                                list[i].IsActive = false;
                            }
                        }
                    }
                }
            }
            gvStaffList.DataSource = list;
            gvStaffList.DataBind();
            lblMessage.Text = "Successfully updated";
            lblMessage.ForeColor = Color.Green;
        }
        
        protected void lnkView_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            txtPassword.Text = "";
            string username = (sender as LinkButton).CommandArgument;
            List<StaffDTO> list = (List<StaffDTO>)Session["AdminStaffSearch"];
            for (int i = 0; i <= list.Count - 1; i++)
            {
                if (list[i].Username == username)
                {
                    txtUsername.Text = list[i].Username;
                    txtFirstname.Text = list[i].FirstName;
                    txtLastname.Text = list[i].LastName;
                    txtPhone.Text = list[i].Phone;
                    txtEmail.Text = list[i].Email;
                }
            }
            txtUsername.Enabled = false;
            btnNew.Enabled = false;
        }
        
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text;
            if (!searchValue.Equals(""))
            {
                List<StaffDTO> searchResult = new List<StaffDTO>();
                searchResult = dao.AdminSearchStaffByUsername(searchValue);
                Session.Add("AdminStaffSearch", searchResult);
                if (searchResult.Count() > 0)
                {
                    lblMessage.Text = "";
                    gvStaffList.Visible = true;
                    gvStaffList.DataSource = searchResult;
                    gvStaffList.DataBind();
                }
                else
                {
                    gvStaffList.DataSource = null;
                    gvStaffList.Visible = false;
                    lblMessage.Text = "No record found!";
                    lblMessage.ForeColor = Color.Red;
                }
            }
        }
    }
}