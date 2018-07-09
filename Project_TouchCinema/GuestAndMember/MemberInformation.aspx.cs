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
            if (Session["MEMBER_USER"] == null)
            {
                MemberDTO member = (MemberDTO)Session["MEMBER_USER"];
                this.txtUsername.Text = member.Username;
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
    }
}