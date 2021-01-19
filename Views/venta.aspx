<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeFile="~/Views/venta.aspx.cs" Inherits="oficinas_y_mas.Views.venta" %>
<%@ Import Namespace="Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-8">
            <div class="white-box">
                <h3 class="box-title">venta</h3>
                <div class="app-search  m-r-10 m-b-40">
                    <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control border border-primary search-bar-x" />
                    <asp:Button Text="Agregar" ID="btnSearch" OnClick="btnSearch_Click" CssClass="btn btn-primary right " runat="server" />
                </div>
                
                <div class="table-responsive">

                    <asp:GridView runat="server" ID="gvMuebles" AutoGenerateColumns="false" CssClass="table table-bordered dataTable">
                        <Columns>
                            <asp:BoundField DataField="idMueble" HeaderText="Clave" InsertVisible="False" ReadOnly="true" />
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" InsertVisible="False" ReadOnly="true" />
                            <asp:BoundField DataField="color" HeaderText="Color" InsertVisible="False" ReadOnly="true" />
                            <asp:BoundField DataField="precio" DataFormatString="${0}" HeaderText="Precio" InsertVisible="False" ReadOnly="true" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox runat="server" ID="txtCantidad" type="number" CssClass="form-control"  min="1" 
                                        max="<%# ((Mueble)(Container.DataItem)).cantidad_stock %>" value="1" Text="1" 
                                        OnTextChanged="txtCantidad_TextChanged" AutoPostBack="true"/>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Cantidad
                                </HeaderTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="col-sm-4">
            <div class="white-box">
                <h3 class="box-title" runat="server" id="lblTotalTitle">TOTAL:</h3>
                <h1 runat="server" id="lblTotal" class="right">$00.0</h1>
                <asp:Button Text="Completar" ID="btnSell" OnClick="btnSell_Click" CssClass="btn btn-default float-right" runat="server" />
            </div>
        </div>
    </div>
    <div class="modal" id="myModal" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="box-title">MONTO INGRESADO</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="">
                    <asp:TextBox runat="server" ID="txtMonto" CssClass="form-control" />
                </div>
                <div class="modal-footer">
                    <asp:Button Text="Confirmar" runat="server" CssClass="btn btn-primary" ID="btnConfirm" OnClick="btnConfirm_Click"/>
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal" id="my_modal" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="box-title">CAMBIO</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="">
                    <h3 id="lblCambio" runat="server"></h3>
                </div>
                <div class="modal-footer">
                    <asp:Button Text="Finalizar" runat="server" CssClass="btn btn-primary" ID="btnFinalizarVenta" OnClick="btnFinalizarVenta_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
