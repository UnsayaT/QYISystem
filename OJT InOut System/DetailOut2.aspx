<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetailOut2.aspx.vb" Inherits="OJT_InOut_System.DetailOut2" %>
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
                <asp:TextBox ID="txtLotno" runat="server" Enabled="False"></asp:TextBox>      
            </p>
            <br />
            <p class="text-center">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" Text="Manual OS Test 1st :"></asp:Label>
                &nbsp;<asp:RadioButton ID="RadioButton1" runat="server" Text="OS NG" GroupName="OSNG1" />&nbsp;&nbsp; 
                <asp:TextBox ID="txtOSNG1" runat="server" Width="30px" Enabled="False"></asp:TextBox> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:RadioButton ID="RadioButton2" runat="server" Text="OS Pass All" GroupName="OSNG1" />
                <br />
            </p>
            <br />
            <br />
            <p class="text-center">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" Text="Manual OS Test 2nd :"></asp:Label>
                &nbsp;<asp:RadioButton ID="RadioButton3" runat="server" Text="OS NG" GroupName="OSNG2" />&nbsp; 
                <asp:TextBox ID="txtOSNG2" runat="server" Width="30px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:RadioButton ID="RadioButton4" runat="server" Text="OS Pass All" GroupName="OSNG2" />
                <br />
            </p>
            <br />
            <br />
            <p class="text-center">
                <asp:Label ID="Label2" runat="server" Text="Emp No :"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtEmpNo" runat="server" Enabled="False" Height="22px"></asp:TextBox>
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
