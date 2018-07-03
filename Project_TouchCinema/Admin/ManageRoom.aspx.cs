using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RoomLibrary;
using System.Drawing;

namespace Project_TouchCinema
{
    public partial class ManageRoom : System.Web.UI.Page
    {
        List<RoomDTO> AdminRoomList = new List<RoomDTO>();
        RoomDAO dao = new RoomDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                AdminRoomList = dao.GetRoomList();
                Session.Add("AdminRoomList", AdminRoomList);
                gvStaffList.DataSource = AdminRoomList;
                gvStaffList.DataBind();

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<RoomDTO> list = (List<RoomDTO>)Session["AdminRoomList"];
            int searchValue = 0;
            try
            {
                searchValue = Convert.ToInt32(txtSearch.Text);
            }
            catch
            {
                lblMessage.Text = "Room ID must be a number! Please type again!";
                lblMessage.ForeColor = Color.Red;
                return;
            }
            if (!searchValue.Equals(""))
            {
                RoomDTO searchResult = SearchInListByID(list, searchValue);
                if (searchResult!=null)
                {
                    List<RoomDTO> roomSearchList = new List<RoomDTO>();
                    roomSearchList.Add(searchResult);
                    lblMessage.Text = "";
                    gvStaffList.Visible = true;
                    gvStaffList.DataSource = null;
                    gvStaffList.DataSource = roomSearchList;
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
            List<RoomDTO> list = (List<RoomDTO>)Session["AdminRoomList"];
            gvStaffList.DataSource = list;
            gvStaffList.DataBind();
        }

        protected void btnUpdateActive_Click(object sender, EventArgs e)
        {
            List<RoomDTO> list = (List<RoomDTO>)Session["AdminRoomList"];
            foreach (GridViewRow row in gvStaffList.Rows)
            {
                CheckBox status = (row.Cells[2].FindControl("isActive") as CheckBox);
                int id = Convert.ToInt32(row.Cells[0].Text);
                if (status.Checked)
                {
                    if (dao.UpdateRoomStatus(id, 1))
                    {
                        for (int i = 0; i <= list.Count - 1; i++)
                        {
                            if (list[i].RoomID == id)
                            {
                                list[i].IsActive = true;
                            }
                        }
                    }
                }
                else
                {
                    if (dao.UpdateRoomStatus(id, 0))
                    {
                        for (int i = 0; i <= list.Count - 1; i++)
                        {
                            if (list[i].RoomID == id)
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

        public RoomDTO SearchInListByID(List<RoomDTO> list, int id)
        {
            RoomDTO result = new RoomDTO();
            foreach (RoomDTO item in list)
            {
                if (item.RoomID == id)
                {
                    result = new RoomDTO
                    {
                        RoomID = item.RoomID,
                        NumberOfSeat = item.NumberOfSeat,
                        IsActive = item.IsActive
                    };
                }

            }

            return result;
        }
    }
}