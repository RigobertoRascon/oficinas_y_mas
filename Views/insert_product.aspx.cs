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
    public partial class insert_product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("inventory.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Mueble mueble = new Mueble();

            mueble.nombre = txtName.Text;
            mueble.color = txtColor.Text;
            mueble.categoria = txtCategoria.Text;
            mueble.precio = Convert.ToInt32(txtPrecio.Text);
            mueble.cantidad_stock = Convert.ToInt32(txtCantidad.Text);
            mueble.idAlmacen = 1;
            MuebleController.insertMueble(mueble);

            var savePath = @"D:\Programming\shcool\web\oficinas_y_mas\assets\images\muebles\";
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
                Response.Redirect("inventory.aspx");
            }
        }
    }
}