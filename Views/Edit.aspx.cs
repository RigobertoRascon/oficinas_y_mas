﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;
using Model;

namespace oficinas_y_mas.Views
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var idUserToEdit = Session["idUserToEdit"];
            try
			{
                if (idUserToEdit == null)
                {
                    Response.Redirect("Users.aspx");
                }
                else
                {
                    Personal user = PersonalController.searchUserById(Convert.ToInt32(idUserToEdit));
                    txtName.Attributes.Add("placeholder", user.nombre);
                    txtLastname.Attributes.Add("placeholder", user.apellido);
                    txtPhone.Attributes.Add("placeholder", user.telefono);
                    txtEmail.Attributes.Add("placeholder", user.correo);
                    txtPassword.Attributes.Add("placeholder", user.password);
                    if (!Page.IsPostBack)
                    {
                        userArea.Text = user.area.ToString();
                        userRole.Text = user.rol.ToString();
                    }
                }
            }
			catch (Exception ex)
			{
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true); 
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var idUserToEdit = Session["idUserToEdit"];
            try
            {
                Personal user = PersonalController.searchUserById(Convert.ToInt32(idUserToEdit));
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    user.nombre = txtName.Text;
                }
                if (!string.IsNullOrEmpty(txtLastname.Text))
                {
                    user.apellido = txtLastname.Text;
                }
                if (!string.IsNullOrEmpty(txtPhone.Text))
                {
                    user.telefono = txtPhone.Text;
                }
                if (!string.IsNullOrEmpty(txtEmail.Text))
                {
                    user.correo = txtEmail.Text;
                }
                if (!string.IsNullOrEmpty(txtPassword.Text))
                {
                    user.password = txtPassword.Text;
                }
                user.area = userArea.SelectedValue;
                user.rol = Convert.ToInt32(userRole.SelectedValue);
                PersonalController.editUser(user);
                Response.Redirect("Users.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }
        }
    }
}