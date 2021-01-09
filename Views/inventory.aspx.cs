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
    public partial class inventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gvUsers.DataSource = MuebleController.searchMuebleByCriteria("");
            gvUsers.DataBind();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("insert_product.aspx");
        }

        protected void btnEdit_Command(object sender, CommandEventArgs e)
        {
            Session["idMuebleToEdit"] = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("edit_product.aspx");
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            Session["idMuebleToDelete"] = Convert.ToInt32(e.CommandArgument);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            MuebleController.removeMueble(Convert.ToInt32(Session["idMuebleToDelete"]));
            Response.Redirect("inventory.aspx");
        }
    }
}