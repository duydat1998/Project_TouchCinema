using MemberLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Net.Mail;

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
            }
        }

        protected void btnUpdateActive_Click(object sender, EventArgs e)
        {
            List<MemberDTO> list = (List<MemberDTO>)Session["AdminMemberSearch"];
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
            //check null username
            if (username.Equals(""))
            {
                lblMessage.Text = "Username cannot be null!";
                lblMessage.ForeColor = Color.Red;
                return;
            }
            string password = txtPassword.Text.Trim();
            //check null password
            if (password.Equals(""))
            {
                lblMessage.Text = "Password cannot be null!";
                lblMessage.ForeColor = Color.Red;
                return;
            }
            string firstname = txtFirstname.Text.Trim();
            string lastname = txtLastname.Text.Trim();
            string phone = txtPhone.Text.Trim();
            double phoneNum = 0;
            //try phone number
            try
            {
                phoneNum = double.Parse(phone);
            }
            catch
            {
                lblMessage.Text = "Phone number must be numbers";
                lblMessage.ForeColor = Color.Red;
                return;
            }
            string email = txtEmail.Text.Trim();
            // check email
            if (!IsEmailValid(email))
            {
                lblMessage.Text = "Email is not valid.";
                lblMessage.ForeColor = Color.Red;
                return;
            }

            DateTime birth = new DateTime();
            // check birthdate
            try
            {
                birth =Convert.ToDateTime(txtBirth.Text.Trim());
            }
            catch
            {
                lblMessage.Text = "Wrong format for Date of Birth, must be MM/dd/yyyy";
                return;
            }
            
            MemberDTO dto = new MemberDTO(username, password, firstname, lastname, phone, email, birth, "", true);
            try
            {
                if (dao.AddNewMemberAdmin(dto))
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

        protected void lnkView_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            txtPassword.Text = "";
            string username = (sender as LinkButton).CommandArgument;
            List<MemberDTO> list = (List<MemberDTO>)Session["AdminMovieSearch"];
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
                List<MemberDTO> searchResult = new List<MemberDTO>();
                searchResult = dao.AdminSearchMemberByUsername(searchValue);
                Session.Add("AdminMemberSearch", searchResult);
                
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