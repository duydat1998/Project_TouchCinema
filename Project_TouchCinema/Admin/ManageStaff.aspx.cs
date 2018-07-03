using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StaffLibrary;
using System.Drawing;

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
                AdminStaffList = dao.GetStaffList();
                Session.Add("AdminStaffList", AdminStaffList);
                gvStaffList.DataSource = AdminStaffList;
                gvStaffList.DataBind();
                
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
        
        protected void btnNew_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            if (username.Equals(""))
            {
                lblMessage.Text = "Username cannot be null!";
                lblMessage.ForeColor = Color.Red;
                return;
            }
            string password = txtPassword.Text.Trim();
            string firstname = txtFirstname.Text.Trim();
            string lastname = txtLastname.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            bool isActive = true;

            StaffDTO dto = new StaffDTO {
                Username = username,
                Password = password,
                FirstName = firstname,
                LastName = lastname,
                Phone = phone,
                Email = email,
                IsActive = isActive
            };
            try
            {
                if (dao.AddNewStaff(username, password, firstname, lastname, phone, email, isActive))
                {
                    List<StaffDTO> list = (List<StaffDTO>)Session["AdminStaffList"];
                    list.Add(dto);
                    gvStaffList.DataSource = list;
                    gvStaffList.DataBind();
                    Session.Add("AdminStaffList", list);
                    lblMessage.Text = "Successfully added";
                    lblMessage.ForeColor = Color.Green;
                }
                else
                {
                    lblMessage.Text = "Failed to add";
                    lblMessage.ForeColor = Color.Red;
                }
            }catch
            {
                lblMessage.Text = "Username is already existed, please choose another one";
                lblMessage.ForeColor = Color.Red;
            }
            

        }

        protected void btnUpdateActive_Click(object sender, EventArgs e)
        {
            List<StaffDTO> list = (List<StaffDTO>)Session["AdminStaffList"];
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
                                list[i].IsActive=true;
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
            List<StaffDTO> list = (List<StaffDTO>)Session["AdminStaffList"];
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

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            gvStaffList.Visible = true;
            List<StaffDTO> list = (List<StaffDTO>)Session["AdminStaffList"];
            gvStaffList.DataSource = list;
            gvStaffList.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text;
            if (!searchValue.Equals(""))
            {
                List<StaffDTO> searchResult = dao.SearchByStaffUsername(searchValue);
                if (searchResult.Count() > 0)
                {
                    lblMessage.Text = "";
                    gvStaffList.Visible = true;
                    gvStaffList.DataSource = null;
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