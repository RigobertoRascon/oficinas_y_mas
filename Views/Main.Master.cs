﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Controller;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.xml;
using System.IO;
using iTextSharp.tool.xml;

namespace oficinas_y_mas.Views
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
                var loginId = Session["loginId"];
                if (Session["loginId"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    Personal user = PersonalController.searchUserById(Convert.ToInt32(loginId));
                    if (user.rol != 0)
                    {
                        linkUsers.Visible = false;
                        //Response.Redirect("inventory.aspx");
                    }
                    lblUser.InnerText = user.nombre + " " + user.apellido;
                    titleDate.InnerText = DateTime.Now.ToString();
                }
            }
			catch (Exception ex)
			{

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true); ;
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["loginId"] = null;
            Response.Redirect("login.aspx");
        }

        protected void linkUsers_Click(object sender, EventArgs e)
        {
            Session["idList"] = null;
            Response.Redirect("users.aspx");
            
        }

        protected void linkInventory_Click(object sender, EventArgs e)
        {
            Session["idList"] = null;
            Response.Redirect("inventory.aspx");
        }

        protected void linkVenta_Click(object sender, EventArgs e)
        {
            Session["idList"] = null;
            Response.Redirect("venta.aspx");
        }
    }
}