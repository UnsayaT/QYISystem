 <%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="OutputFQI.aspx.vb" Inherits="OJT_InOut_System.OutputFQI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2>Output FQI.</h2>
     </div>
    <div class="row">
         <div class="col-md-13">
            <br />
            <br />
            <br />
            <p class="text-center"> 
                <asp:Label ID="Label1" runat="server" Text="Lot No :"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtLotno" runat="server"></asp:TextBox>      
            </p>
            <br />
            <p class="text-center">
                <asp:Label ID="Label2" runat="server" Text="Emp No :"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtEmpNo" runat="server"></asp:TextBox>
            </p>
            <br />
            <p class="text-center">
                <asp:Button ID="Button1" runat="server" Text="Confirm" />
            </p>
            <br />
            <br />
            <br />
        </div>
     </div>
</asp:Content>
