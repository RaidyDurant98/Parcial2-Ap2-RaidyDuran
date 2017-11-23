<%@ Page Title="Registro de presupuestos" Language="C#" MasterPageFile="~/UI/Base.Master" AutoEventWireup="true" CodeBehind="PresupuestosRegistro.aspx.cs" Inherits="Parcial2_Ap2_RaidyDuran.UI.PresupuestosRegistro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container-fluid">
        <div class="col-12">
            <h1>Registro de Presupuestos</h1>
            <br />
        </div>
        <!--Formulario-->
        <div class="col-12 col-sm-8 col-md-6 col-lg-5">
            <div class="float-right">
                <asp:Button CssClass="btn btn-dark" ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
            </div>
            <br />
            <!--Presupuesto Id-->
            <div class="form-group">
                <asp:Label ID="PresupuestoIdLabel" runat="server" Text="Presupuesto Id:"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="PresupuestoIdTextBox" runat="server" AutoComplete="off"></asp:TextBox>
            </div>
            <!--Fecha-->
            <div class="form-group">
                <asp:Label ID="FechaLabel" runat="server" Text="Fecha:"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="FechaTextBox" runat="server" TextMode="date" AutoComplete="off"></asp:TextBox>
            </div>
            <!--Descripcion-->
            <div class="form-group">
                <asp:Label ID="DescripcionLabel" runat="server" Text="Descripcion:"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="DescripcionTextBox" runat="server" AutoComplete="off" TextMode="MultiLine"></asp:TextBox>
            </div>
            <!--Monto-->
            <div class="form-group">
                <asp:Label ID="MontoLabel" runat="server" Text="Monto:"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="MontoTextBox" runat="server" AutoComplete="off"></asp:TextBox>
            </div>
            <!--Meta-->
            <div class="form-group">
                <asp:Label ID="MetaLabel" runat="server" Text="Meta:"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="MetaTextBox" runat="server" AutoComplete="off"></asp:TextBox>
            </div>
            <!--Logrado-->
            <div class="form-group">
                <asp:Label ID="LogradoLabel" runat="server" Text="Logrado:"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="LogradoTextBox" runat="server" AutoComplete="off"></asp:TextBox>
            </div>
            <div class="text-right">
                <asp:Button CssClass="btn btn-dark" ID="AgregarButton" runat="server" Text="Agregar" OnClick="AgregarButton_Click" />
            </div>
            <br />
            <!--Grid Detalle-->
            <div class="form-group">
                <asp:GridView CssClass="table table-responsive table-hover" BorderStyle="None"
                    ID="DetalleGridView" runat="server" GridLines="Horizontal" ShowFooter="true">
                    <HeaderStyle CssClass="bg-dark text-white" />
                    <FooterStyle CssClass="bg-dark" />
                </asp:GridView>
            </div>
            <!--Botones-->
            <div class="text-center">
                <asp:Button CssClass="btn btn-dafault" ID="NuevoButton" runat="server" Text="Nuevo" OnClick="NuevoButton_Click" />
                <asp:Button CssClass="btn btn-primary" ID="GuardarButton" runat="server" Text="Guardar" OnClick="GuardarButton_Click" />
                <asp:Button CssClass="btn btn-danger" ID="EnviarAlModalEliminarButton" runat="server" Text="Eliminar" OnClick="EnviarAlModalEliminarButton_Click" />
            </div>
        </div>
        <!--Modal de confirmacion de eliminar-->
        <div class="modal" id="ModalEliminar">
            <div class="modal-dialog" role="document">
                <div class="modal-content ">
                    <div class="modal-header bg-dark">
                        <h5 class="modal-title">¡Atencion!</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <p>Esta seguro de eliminar este usuario?</p>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="EliminarButton" runat="server" CssClass="btn btn-secondary" Text="Si" OnClick="EliminarButton_Click" />
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">No</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
