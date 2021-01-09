<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="insert_product.aspx.cs" Inherits="oficinas_y_mas.Views.insert_product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row ">
        <div class="col-md-4 col-xs-12">
            <div class="white-box">
                <div class="user-bg">
                    <img runat="server" class="w-50" alt="" src="">
                    <div class="overlay-box">
                                    <div class="user-content">
                                        <a href="javascript:void(0)"><img id= "imgMueble" alt="Sin imagen" runat="server" src=""
                                                class="thumb-lg"></a>
                                    </div>
                                </div>
                </div>
            </div>
            <div class="form-horizontal form-material">
            <span class="help-block text-danger" id="lblWarning" runat="server"><i id="warningIconPassword" class="fa fa-exclamation-circle fa-fw" runat="server"></i>Mensaje de error</span>
            <div class="form-group">
                <div class="col-md-12">
                    <asp:FileUpload ID="FileUpload"
                        runat="server" CssClass=""></asp:FileUpload>
                </div>
            </div>
        </div>
        <div class="form-group float-right">
            
        </div>
        </div>
        <div class="col-md-8">
            <div class="white-box">
                <div class="form-horizontal form-material">
                    <div class="form-group">
                        <label class="col-md-12">Nombre</label>
                        <div class="col-md-12">
                            <asp:TextBox runat="server" ID="txtName" CssClass="form-control form-control-line" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-12">Color</label>
                        <div class="col-md-12">
                            <asp:TextBox runat="server" ID="txtColor" CssClass="form-control form-control-line" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-12">Categoria</label>
                        <div class="col-md-12">
                            <asp:TextBox runat="server" ID="txtCategoria" CssClass="form-control form-control-line" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-12">Almacen</label>
                        <div class="col-md-12">
                            <asp:TextBox runat="server" ReadOnly="true" ID="txtAlmacen" style="cursor :not-allowed" CssClass="form-control form-control-line" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="example-email" class="col-md-12">Precio</label>
                        <div class="col-md-12">
                            <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control form-control-line" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="example-email" class="col-md-12">Cantidad en stock</label>
                        <div class="col-md-12">
                            <asp:TextBox runat="server" ID="txtCantidad" CssClass="form-control form-control-line" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-12">
                            <asp:Button Text="Cancelar" runat="server" ID="btnCancel" CssClass="btn" OnClick="btnCancel_Click"/>
                            <asp:Button Text="Insertar" ID="btnEdit" OnClick="btnEdit_Click" CssClass="btn btn-success" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
