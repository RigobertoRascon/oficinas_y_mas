using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;
using Model;

namespace oficinas_y_mas.Views
{
    public partial class Insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            
            try
            {
                Personal user = new Personal();
                user.nombre = txtName.Text;
                user.apellido = txtLastname.Text;
                user.telefono = txtPhone.Text;
                user.correo = txtEmail.Text;                
                user.password = txtPassword.Text;
                user.area = userArea.SelectedValue;
                user.rol = Convert.ToInt32(userRole.SelectedValue);
                
                PersonalController.insertUser(user);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Nuevo usuario agregado');", true);
                Response.Redirect("Users.aspx");
                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }
        }
    }
}