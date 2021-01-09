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
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gvUsers.DataSource = PersonalController.searchUserByCriteria("");
            gvUsers.DataBind();
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            Session["idUserToDelete"] = Convert.ToInt32(e.CommandArgument);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
        }

        protected void btnEdit_Command(object sender, CommandEventArgs e)
        {
            Session["idUserToEdit"] = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("Edit.aspx");
        }

        protected void btn_send_modal_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("Insert.aspx");
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            PersonalController.removeUser(Convert.ToInt32(Session["idUserToDelete"]));
            Page_Load(null, null);
        }
    }
}