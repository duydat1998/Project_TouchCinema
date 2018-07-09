using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
                imageAvatar.ImageUrl = "~/Image/Avatar/default-avatar.jpg";
                txtPicture.Value = "~/Image/Avatar/default-avatar.jpg";

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
                this.txtUsername.ForeColor = System.Drawing.Color.Red;
                this.txtUsername.Focus();
                return;
            }
            string password = txtPass.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string firstname = txtFirstName.Text.Trim();
            string lastname = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string picture = txtPicture.Value;
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
                ImageLink = picture,
                IsActive = true,
                Birthdate = birthday,
            };

            bool result = dao.AddNewMemberAdmin(member);
            if (result)
            {
                string message = "Regiter SUCCESSFULLY.\\nPlease login to continue.";
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
            }
            else
            {
                Response.Redirect("../ErrorPages/ErrorPage.aspx");
            }
        }

        protected void btnUploadPicture_Click(object sender, EventArgs e)
        {
            if (FileUpload.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload.PostedFile.FileName);
                //only save picture when user import new picture
                if (!fileName.Equals("default-avatar.jpg"))
                {
                    string tempFilename = fileName;
                    bool check = System.IO.File.Exists(Server.MapPath(Server.MapPath("~/Image/Avatar/") + fileName));
                    if (check)
                    {
                        int i = 1;
                        do
                        {
                            fileName = tempFilename + "" + i + "";
                            check = System.IO.File.Exists(Server.MapPath(Server.MapPath("~/Image/Avatar/") + fileName));
                            i++;
                        } while (check);
                    }
                    //save avatar into image folder 
                    FileUpload.PostedFile.SaveAs(Server.MapPath("~/Image/Avatar/") + fileName);
                }
                imageAvatar.ImageUrl = "~/Image/Avatar/" + fileName;
                txtPicture.Value = "~/Image/Avatar/" + fileName;
            }
        }
    }
}