<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="IssueNo.aspx.vb" Inherits="OJT_InOut_System.IssueNo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2>IssueNo</h2>
    </div>
    <div class="row">
        <div class="col-md-13">
            <br />
            <br />
            <br />
            <p class="text-center">
                <asp:Label ID="Label3" runat="server" Text="Process :"></asp:Label>
                &nbsp;
                <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="128px">
                    <asp:ListItem>Select Process</asp:ListItem>
                    <asp:ListItem>FT</asp:ListItem>
                    <asp:ListItem>FL</asp:ListItem>
                    <asp:ListItem>MAP</asp:ListItem>
                </asp:DropDownList>
                &nbsp;
            </p>
            <br />
            <p class="text-center"> 
                &nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:Label ID="Label1" runat="server" Text="Lot No :"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtLotno1" runat="server"></asp:TextBox>   
                &nbsp;
                &nbsp;
                &nbsp;
                </p>
            <br />
            <p class="text-center">
                <asp:Button ID="btnNext" runat="server" Text="Next"/>
            </p>
        </div>
    </div>
</asp:Content>
