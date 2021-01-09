<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="oficinas_y_mas.Views.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row ">
        <div class="col-md-12">
            <div class="white-box">
                <div class="form-horizontal form-material">
                    <div class="form-group">
                        <label class="col-md-12">Nombre</label>
                        <div class="col-md-12">
                            <asp:TextBox runat="server" ID="txtName" CssClass="form-control form-control-line"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-12">Apellido</label>
                        <div class="col-md-12">
                            <asp:TextBox runat="server" ID="txtLastname" CssClass="form-control form-control-line"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="example-email" class="col-md-12">Correo electronico</label>
                        <div class="col-md-12">
                            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control form-control-line"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-12">Contraseña</label>
                        <div class="col-md-12">
                            <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control form-control-line"/>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-12">Telefono</label>
                        <div class="col-md-12">
                            <asp:TextBox runat="server" ID="txtPhone" CssClass="form-control form-control-line"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-12">Area</label>
                        <div class="col-sm-12">
                            <br />
                            <asp:DropDownList ID="userArea" runat="server" CssClass="form-control form-control-line">
                                <asp:ListItem Enabled="true" Text="Selecciona el area del usuario"></asp:ListItem>
                                <asp:ListItem Text="Administracion" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Ventas" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-12">Rol</label>
                        <div class="col-sm-12">
                            <br />
                            <asp:DropDownList ID="userRole" runat="server" CssClass="form-control form-control-line">
                                <asp:ListItem Enabled="true" Text="Selecciona el rol de usuario"></asp:ListItem>
                                <asp:ListItem Text="Administrador" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Usuario" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-12">
                            <asp:Button Text="Editar" ID="btnEdit" OnClick="btnEdit_Click" CssClass="btn btn-success" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
