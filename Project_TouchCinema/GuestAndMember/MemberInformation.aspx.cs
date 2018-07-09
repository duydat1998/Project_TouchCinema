using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MemberLibrary;
namespace Project_TouchCinema.GuestAndMember
{
    public partial class MemberInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MEMBER_USER"] != null)
            {
                if (!IsPostBack)
                {
                    MemberDTO member = (MemberDTO)Session["MEMBER_USER"];
                    this.txtUsername.Text = member.Username;
                    this.txtFirstName.Text = member.FirstName;
                    this.txtLastName.Text = member.LastName;
                    this.txtPhone.Text = member.PhoneNum;
                    this.txtEmail.Text = member.Email;
                    this.dlDay.Text = member.Birthdate.Day + "";
                    this.dlMonth.Text = member.Birthdate.Month + "";
                    this.dlYear.Text = member.Birthdate.Year + "";

                    imageAvatar.ImageUrl = member.ImageLink;
                    txtPicture.Value = member.ImageLink;

                    for (int i = 1; i <= 31; i++)
                    {
                        ListItem day = new ListItem(i + "", i + "");
                        this.dlDay.Items.Add(day);
                    }

                    for (int i = 1; i <= 12; i++)
                    {
                        ListItem month = new ListItem(i + "", i + "");
                        this.dlMonth.Items.Add(month);
                    }

                    for (int i = (DateTime.Today.Year - 10); i >= 1950; i--)
                    {
                        ListItem year = new ListItem(i + "", i + "");
                        this.dlYear.Items.Add(year);
                    }
                }
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
                    bool check = System.IO.File.Exists(Server.MapPath("~/Image/Avatar/") + fileName);
                    if (check)
                    {
                        int i = 1;
                        do
                        {
                            int index = tempFilename.IndexOf(".");
                            fileName = tempFilename.Insert(index, i + "");
                            check = System.IO.File.Exists(Server.MapPath("~/Image/Avatar/") + fileName);
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void btnChangePass_Click(object sender, EventArgs e)
        {

        }
    }
}