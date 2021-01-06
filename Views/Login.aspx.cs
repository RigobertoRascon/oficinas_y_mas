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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginId"] != null)
            {
                Response.Redirect("views/users.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try



            {
                var login = new Personal()
                {
                    correo = txtEmail.Text,
                    password = txtPassword.Text,
                };
                var user = PersonalController.login(login);
                Session["loginId"] = user.idPersonal;
                Response.Redirect("inventory.aspx");
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true); ;
            }
        }
    }
}