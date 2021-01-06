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

        }

        protected void btnEdit_Command(object sender, CommandEventArgs e)
        {
            Session["idMuebleToEdit"] = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("edit_product.aspx");
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            var idMuebleToRemove = Convert.ToInt32(e.CommandArgument);
            PersonalController.removeUser(idMuebleToRemove);
            Page_Load(null, null);
        }
    }
}