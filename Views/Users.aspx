<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="oficinas_y_mas.Views.Users" %>

<%@ Import Namespace="Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12">
            
            <div class="white-box">
                <h3 class="box-title">Personal</h3>
                <asp:Button Text="Agregar" ID="btnInsert" OnClick="btnInsert_Click" CssClass="btn btn-success right" runat="server" />
                <div class="table-responsive">
                    <asp:GridView runat="server" ID="gvUsers" AutoGenerateColumns="false" CssClass="table table-bordered dataTable">
                        <Columns>
                            <asp:BoundField DataField="idPersonal" HeaderText="ID" InsertVisible="False" ReadOnly="true" />
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" InsertVisible="False" ReadOnly="true" />
                            <asp:BoundField DataField="apellido" HeaderText="Apellido" InsertVisible="False" ReadOnly="true" />
                            <asp:BoundField DataField="area" HeaderText="Area" InsertVisible="False" ReadOnly="true" />
                            <asp:BoundField DataField="correo" HeaderText="Correo" InsertVisible="False" ReadOnly="true" />
                            <asp:BoundField DataField="telefono" HeaderText="Telefono" InsertVisible="False" ReadOnly="true" />
                            <asp:TemplateField HeaderText="Rol">
                                <ItemTemplate>
                                    <asp:Label ID="lblRol" runat="server" Text='<%# (Convert.ToDecimal(Eval("rol")) == 0) ? "Admin" : "Usuario"   %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton CssClass="" OnCommand="btnEdit_Command" CommandArgument="<%# ((Personal)(Container.DataItem)).idPersonal%>" runat="server" ID="btnEdit"><i class="fa fa-pencil"></i></asp:LinkButton>
                                    <asp:LinkButton CssClass="" OnCommand="btnDelete_Command" CommandArgument="<%# ((Personal)(Container.DataItem)).idPersonal %>" runat="server" ID="btnDelete"><i class="fa fa-trash ml-3"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
