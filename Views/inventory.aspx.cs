using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;
using Model;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.xml;
using System.IO;
using iTextSharp.tool.xml;

namespace oficinas_y_mas.Views
{
    public partial class inventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gvMuebles.DataSource = MuebleController.searchMuebleByCriteria("");
            gvMuebles.DataBind();
        }

        private void BindGrid()
        {
            
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

        protected void btnExport_Click(object sender, EventArgs e)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    gvMuebles.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    pdfDoc.Close();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=Articulos_en_inventario.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        protected void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMuebles.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }
    }
}