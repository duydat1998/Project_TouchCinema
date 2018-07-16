using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PromotionLibrary;
using System.Drawing;

namespace Project_TouchCinema
{
    public partial class ManagePromotion : System.Web.UI.Page
    {
        PromotionDAO dao = new PromotionDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtName.Enabled = false;
            btnAdd.Enabled = false;

        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {

            txtName.Text = "";
            lblCode.Text = "";
            lblCode.Text = GenerateCode();
            lblMessage.Text = "";
            btnAdd.Enabled = true;
            txtName.Enabled = true;

        }

        public string GenerateCode()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if(!lblCode.Text.Equals("Promotion code will appear here!"))
            {
                PromotionDTO dto = new PromotionDTO
                {
                    Code = lblCode.Text,
                    Name = txtName.Text.Trim(),
                    Active = true
                };
                if (dao.AddPromotion(dto))
                {
                    SetMessageTextAndColor("Successfully Added", Color.Green);
                }
                else
                {
                    SetMessageTextAndColor("Failed to add", Color.Red);
                }
            }
        }

        public void SetMessageTextAndColor(string text, Color color)
        {
            lblMessage.Text = text;
            lblMessage.ForeColor = color;
        }

        protected void btnUpdateActive_Click(object sender, EventArgs e)
        {
            List<PromotionDTO> list = (List<PromotionDTO>)Session["AdminPromotionSearch"];
            foreach (GridViewRow row in gvStaffList.Rows)
            {
                CheckBox status = (row.Cells[2].FindControl("isActive") as CheckBox);
                string code = row.Cells[0].Text;
                if (status.Checked)
                {
                    if (dao.UpdateActivePromotion(code, 1))
                    {
                        for (int i = 0; i <= list.Count - 1; i++)
                        {
                            if (list[i].Code.Equals(code))
                            {
                                list[i].Active = true;
                            }
                        }
                    }
                }
                else
                {
                    if (dao.UpdateActivePromotion(code, 0))
                    {
                        for (int i = 0; i <= list.Count - 1; i++)
                        {
                            if (list[i].Code.Equals(code))
                            {
                                list[i].Active = false;
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text;
            if (!searchValue.Equals(""))
            {
                List<PromotionDTO> result = new List<PromotionDTO>();
                result = dao.SearchPromotionByName(searchValue);
                
                if(result.Count > 0)
                {
                    lblMessage.Text = "";
                    gvStaffList.DataSource = result;
                    gvStaffList.DataBind();
                    Session.Add("AdminPromotionSearch", result);
                }
                else
                {
                    gvStaffList.DataSource = result;
                    gvStaffList.DataBind();
                    SetMessageTextAndColor("No record found", Color.Red);
                }
            }
        }
    }
}