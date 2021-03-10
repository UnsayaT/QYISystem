<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="OSNG_Over.aspx.vb" Inherits="OJT_InOut_System.OSNG_Over" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2>OS NG Over</h2>
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
                <asp:RadioButton ID="RadioButton1" runat="server" GroupName="GOTOProcess" Text="QC" />&nbsp;&nbsp;
                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="GOTOProcess" Text="Next Process" />&nbsp;&nbsp;
                <asp:RadioButton ID="RadioButton3" runat="server" GroupName="GOTOProcess" Text="Retest Auto" />&nbsp;
                <asp:TextBox ID="txtAutoNo" runat="server"  MaxLength="1" Width="20px"></asp:TextBox>
            </p>
             <br />
            <p class="text-center">
                <asp:Label ID="Label2" runat="server" Text="Emp No :"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtEmpNo" runat="server"></asp:TextBox>
            </p>
            <br />
            <p>
                <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
            </p>
            <br />
            <p class="text-center">
                <asp:Button ID="btnConfirm" runat="server" Text="Confirm" />
            </p>
            <br />
            <br />
            <br />
        </div>
     </div>
</asp:Content>
