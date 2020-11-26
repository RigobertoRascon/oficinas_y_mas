using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Controller;

namespace oficinas_y_mas.Views
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
                var loginId = Session["loginId"];
                if (Session["loginId"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    Personal user = PersonalController.searchUserById(Convert.ToInt32(loginId));
                    if (user.rol != 0)
                    {
                        linkUsers.Visible = false;
                        //Response.Redirect("inventory.aspx");
                    }
                    lblUser.InnerText = user.nombre + " " + user.apellido;
                    titleDate.InnerText = DateTime.Now.ToString();
                }
            }
			catch (Exception ex)
			{

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true); ;
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["loginId"] = null;
            Response.Redirect("login.aspx");
        }

        protected void linkUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("users.aspx");
        }

        protected void linkInventory_Click(object sender, EventArgs e)
        {
            Response.Redirect("inventory.aspx");
        }
    }
}