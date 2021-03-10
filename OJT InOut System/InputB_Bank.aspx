<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="InputB_Bank.aspx.vb" Inherits="OJT_InOut_System.InputB_Bank" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2>Input NG To B-Bank</h2>
    </div>
    <div class="panel panel-primary">
        <div class="panel-body">
                <label for="Lot No">Lot No</label>
                <asp:TextBox ID="txtLotno" runat="server" class="form-control" ></asp:TextBox>  
                <br />
                <asp:Button ID="Button1" runat="server"  class="btn btn-primary" Text="View" Height="35px"/>
        </div>
        <div class="panel-body">
                <label for="Package">Package</label>
                <asp:TextBox ID="txtPackage" runat="server" class="form-control" ></asp:TextBox>  
        </div>
    </div>
</asp:Content>
