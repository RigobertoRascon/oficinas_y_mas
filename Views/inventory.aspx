<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="inventory.aspx.cs" Inherits="oficinas_y_mas.Views.inventory" %>

<%@ Import Namespace="Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12">
            
            <div class="white-box">
                <h3 class="box-title">Productos</h3>
                <asp:Button Text="Agregar" ID="btnInsert" OnClick="btnInsert_Click" CssClass="btn btn-success right" runat="server" />
                <div class="table-responsive">
                    <asp:GridView runat="server" ID="gvUsers" AutoGenerateColumns="false" CssClass="table table-bordered dataTable">
                        <Columns>
                            <asp:BoundField DataField="idMueble" HeaderText="ID" InsertVisible="False" ReadOnly="true" />
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" InsertVisible="False" ReadOnly="true" />
                            <asp:BoundField DataField="color" HeaderText="Color" InsertVisible="False" ReadOnly="true" />
                            <asp:BoundField DataField="categoria" HeaderText="Categoria" InsertVisible="False" ReadOnly="true" />
                            <asp:BoundField DataField="cantidad_stock" HeaderText="Existencia" InsertVisible="False" ReadOnly="true" />
                            <asp:BoundField DataField="precio" HeaderText="Precio" InsertVisible="False" ReadOnly="true" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton CssClass="" OnCommand="btnEdit_Command" CommandArgument="<%# ((Mueble)(Container.DataItem)).idMueble%>" runat="server" ID="btnEdit"><i class="fa fa-eye"></i></asp:LinkButton>
                                    <asp:LinkButton CssClass="" OnCommand="btnDelete_Command" CommandArgument="<%# ((Mueble)(Container.DataItem)).idMueble %>" runat="server" ID="btnDelete"><i class="fa fa-trash ml-3"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
