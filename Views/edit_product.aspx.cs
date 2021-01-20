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
    public partial class edit_product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            lblWarning.Visible = false;
            var idMuebleToEdit = Session["idMuebleToEdit"];
            try
            {
                if (idMuebleToEdit == null)
                {
                    Response.Redirect("inventory.aspx");
                }
                else
                {
                    Mueble mueble = MuebleController.searchMuebleById(Convert.ToInt32(idMuebleToEdit));
                    txtName.Attributes.Add("placeholder", mueble.nombre);
                    txtColor.Attributes.Add("placeholder", mueble.color);
                    txtAlmacen.Attributes.Add("placeholder", "Almacen 1");
                    txtPrecio.Attributes.Add("placeholder", mueble.precio.ToString());
                    txtCantidad.Attributes.Add("placeholder", mueble.cantidad_stock.ToString());
                    imgMueble.Src = "../assets/images/muebles/" + mueble.image;
                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true); ;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var idMuebleToEdit = Session["idMuebleToEdit"];
            try
            {
                Mueble mueble = MuebleController.searchMuebleById(Convert.ToInt32(idMuebleToEdit));
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    mueble.nombre = txtName.Text;
                }
                if (!string.IsNullOrEmpty(txtColor.Text))
                {
                    mueble.color = txtColor.Text;
                }
                if (!string.IsNullOrEmpty(txtCategory.SelectedValue))
                {
                    mueble.categoria = txtCategory.SelectedValue;
                }
                if (!string.IsNullOrEmpty(txtPrecio.Text))
                {
                    mueble.precio = Convert.ToInt32(txtPrecio.Text);
                }
                if (!string.IsNullOrEmpty(txtCantidad.Text))
                {
                    mueble.cantidad_stock = Convert.ToInt32(txtCantidad.Text);
                }
                var savePath = @"D:\Downloads\ITH\7\Desarrollo de Proyectos de Software\oficinas_y_mas\assets\images\muebles\";
                if (FileUpload.HasFile)
                {
                    string extension = System.IO.Path.GetExtension(FileUpload.FileName);

                    if (extension == ".jpg" || extension == ".png")
                    {
                        if (extension == ".jpg")
                        {
                            var fileName = mueble.idMueble + ".jpg";
                            savePath += fileName;
                            FileUpload.SaveAs(savePath);
                            mueble.image = mueble.idMueble + ".jpg";

                        }
                        if (extension == ".png")
                        {
                            var fileName = mueble.idMueble + ".png";
                            savePath += fileName;
                            FileUpload.SaveAs(savePath);
                            mueble.image = mueble.idMueble + ".png";
                        }
                        MuebleController.updateMueble(mueble);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Modificacion realizada');", true);
                        Response.Redirect("inventory.aspx");
                    }
                    else
                    {
                        lblWarning.InnerText = "Archivo no válido. Seleccione archivos con extensión .jpg o .png";
                        lblWarning.Visible = true;
                    }
                }
                else
                {
                    MuebleController.updateMueble(mueble);
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Modificacion realizada');", true);
                    Response.Redirect("inventory.aspx");
                }
                
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("inventory.aspx");
        }
    }
}