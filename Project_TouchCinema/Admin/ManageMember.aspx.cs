using MemberLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Project_TouchCinema
{
    public partial class ManageMember : System.Web.UI.Page
    {
        List<MemberDTO> AdminMemberList = new List<MemberDTO>();
        MemberDAO dao = new MemberDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                AdminMemberList = dao.GetMemberList();
                Session.Add("AdminMemberList", AdminMemberList);
                gvStaffList.DataSource = AdminMemberList;
                gvStaffList.DataBind();

            }
        }

        protected void btnUpdateActive_Click(object sender, EventArgs e)
        {
            List<MemberDTO> list = (List<MemberDTO>)Session["AdminMemberList"];
            foreach (GridViewRow row in gvStaffList.Rows)
            {
                CheckBox status = (row.Cells[6].FindControl("isActive") as CheckBox);
                string username = row.Cells[0].Text;
                if (status.Checked)
                {
                    if (dao.UpdateMemberStatus(username, 1))
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
                    if (dao.UpdateMemberStatus(username, 0))
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "";
            txtFirstname.Text = "";
            txtLastname.Text = "";
            txtPhone.Text = "";
            txtUsername.Text = "";
            txtBirth.Text = "";
            btnNew.Enabled = true;
            txtUsername.Enabled = true;
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
            DateTime birth = new DateTime();
            try
            {
                birth =Convert.ToDateTime(txtBirth.Text.Trim());
            }
            catch
            {
                lblMessage.Text = "Wrong format for Date of Birth, must be MM/dd/yyyy";
                return;
            }
            bool isActive = true;

            MemberDTO dto = new MemberDTO(username, password, firstname, lastname, phone, email, birth, "", isActive);
            //{
            //    Username = username,
            //    Password = password,
            //    FirstName = firstname,
            //    LastName = lastname,
            //    PhoneNum = phone,
            //    Email = email,
            //    Birthdate = birth,
            //    IsActive = isActive
            //};
            try
            {
                if (dao.AddNewMemberAdmin(dto))
                {
                    List<MemberDTO> list = (List<MemberDTO>)Session["AdminMemberList"];
                    list.Add(dto);
                    gvStaffList.DataSource = list;
                    gvStaffList.DataBind();
                    Session.Add("AdminMemberList", list);
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

        protected void lnkView_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            txtPassword.Text = "";
            string username = (sender as LinkButton).CommandArgument;
            List<MemberDTO> list = (List<MemberDTO>)Session["AdminMemberList"];
            for (int i = 0; i <= list.Count - 1; i++)
            {
                if (list[i].Username == username)
                {
                    txtUsername.Text = list[i].Username;
                    txtFirstname.Text = list[i].FirstName;
                    txtLastname.Text = list[i].LastName;
                    txtPhone.Text = list[i].PhoneNum;
                    txtEmail.Text = list[i].Email;
                    txtBirth.Text = list[i].Birthdate.ToShortDateString();
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
                List<MemberDTO> list = (List<MemberDTO>)Session["AdminMemberList"];
                List<MemberDTO> searchResult = SearchInListByUsername(list,searchValue);
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

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            gvStaffList.Visible = true;
            List<MemberDTO> list = (List<MemberDTO>)Session["AdminMemberList"];
            gvStaffList.DataSource = list;
            gvStaffList.DataBind();
        }

        public List<MemberDTO> SearchInListByUsername(List<MemberDTO> list, string username)
        {
            List<MemberDTO> result = new List<MemberDTO>();
            foreach (MemberDTO item in list)
            {
                if (item.Username.IndexOf(username) >= 0)
                {
                    result.Add(item);
                }

            }

            return result;
        }
    }
}