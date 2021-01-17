using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Controller;
using System.Collections;

namespace oficinas_y_mas.Views
{
    public partial class venta : System.Web.UI.Page
    {
        List<int> idList = new List<int>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idList"] == null)
            {
                idList = new List<int>();
            }
            else
            {
                idList = Session["idList"] as List<int>;
            }
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            idList.Add(Convert.ToInt32(txtSearch.Text));
            Session["idList"] = idList;
            var muebleVenta = MuebleController.searchMuebleByMultipleId(idList);
            gvMuebles.DataSource = muebleVenta;
            gvMuebles.DataBind();
            var total = 0;
            foreach (var item in muebleVenta)
            {
                total = total + Convert.ToInt32(item.precio);
                Session["totalVenta"] = total;
            }
            lblTotal.InnerText = "$ " + Session["totalVenta"].ToString();

        }

        protected void btnSell_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            txtMonto.Attributes.Add("placeholder", "$");
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            var cambio = Convert.ToInt32(txtMonto.Text) - Convert.ToInt32(Session["totalVenta"]);
            if (cambio > 0)
            {
                lblCambio.InnerText = "$ " + cambio.ToString();
            }
            else
            {

            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#my_modal').modal();", true);

            
        }

        protected void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            var muebleVenta = MuebleController.searchMuebleByMultipleId(idList);
            foreach (var item in muebleVenta)
            {
                item.cantidad_stock = item.cantidad_stock - 1;
                MuebleController.updateMueble(item);
            }
            Response.Redirect("venta.aspx");
        }
    }
}