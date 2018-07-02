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
                btnDelete.Enabled = false;
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
            btnDelete.Enabled = false;
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {

            Clear();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            
            if (dao.RemoveStaff(username))
            {
                List<StaffDTO> list = (List<StaffDTO>)Session["AdminStaffList"];
                for (int i = 0; i <= list.Count - 1; i++)
                {
                    if (list[i].Username == username)
                    {
                        list.RemoveAt(i);
                    }
                }
                gvStaffList.DataSource = list;
                gvStaffList.DataBind();
                Session.Add("AdminStaffList", list);
                lblMessage.Text = "Successfully deleted";
                lblMessage.ForeColor = Color.Green;
            }
            else
            {
                lblMessage.Text = "Failed to delete";
                lblMessage.ForeColor = Color.Red;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string firstname = txtFirstname.Text.Trim();
            string lastname = txtLastname.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            bool isActive = true;

            StaffDTO dto = new StaffDTO {
                Username = username,
                Password = username,
                FirstName = username,
                LastName = username,
                Phone = username,
                Email = username,
                IsActive = isActive
            };
            if (dao.AddNewStaff(username, password, firstname, lastname, phone, email, isActive))
            {
                List<StaffDTO> list = (List<StaffDTO>) Session["AdminStaffList"];
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

        }

        protected void btnUpdateActive_Click(object sender, EventArgs e)
        {
            
        }

        protected void lnkView_Click(object sender, EventArgs e)
        {
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
            btnDelete.Enabled = true;
            btnNew.Enabled = false;
        }
    }
}