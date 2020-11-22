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
                    lblUser.InnerText = user.nombre + " " + user.apellido;
                    titleDate.InnerText = DateTime.Now.ToString();
                }
            }
			catch (Exception ex)
			{

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true); ;
            }
        }
    }
}