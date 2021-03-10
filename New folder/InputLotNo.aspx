  <%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="InputLotNo.aspx.vb" Inherits="OJT_InOut_System.InputLotNo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2>Input Lot No.</h2>
    </div>
    <div class="panel panel-primary">
        <div class="panel-body">
             <div class="form-group">
                 <label for="Lot No">Lot No</label>
                 <asp:TextBox ID="txtLotno" runat="server" class="form-control" ></asp:TextBox>    
             </div>
             <%--<div class="form-group">
                 <label for="Process">Process</label>
                 <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" Height="30px" Width="100%">
                    <asp:ListItem>Select Process</asp:ListItem>
                    <asp:ListItem>FT</asp:ListItem>
                    <asp:ListItem>FL</asp:ListItem>
                    <asp:ListItem>MAP</asp:ListItem>
                </asp:DropDownList>
             </div>--%>
             <div class="form-group">
                 <label for="Process">Mode</label>
                 <div class="form-control">
                     <label class="radio-inline">
                        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Menu" Text="BIN19" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     </label>
                     <label class="radio-inline"> 
                         <asp:RadioButton ID="RadioButton3" runat="server" GroupName="Menu" Text="BIN28" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     </label>
                     <label class="radio-inline">
                         <asp:RadioButton ID="RadioButton4" runat="server" Text="BIN29,BIN30,BIN31" GroupName="Menu" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     </label>
                     <label class="radio-inline">
                         <asp:RadioButton ID="RadioButton5" runat="server" Text="LCL" GroupName="Menu"/>&nbsp;
                     </label>
                </div>
                <br />
                <div class="form-control">
                     <label class="radio-inline">
                         <asp:RadioButton ID="RadioButton6" runat="server" Text="Yield < 80 %" GroupName="Menu"/>&nbsp;
                     </label>
                     <label class="radio-inline">
                         <asp:RadioButton ID="RadioButton9" runat="server" Text="ASI 100% Lot" GroupName="Menu" />&nbsp;
                     </label>
                     <label class="radio-inline">
                         <asp:RadioButton ID="RadioButton7" runat="server" Text="Lot Eva Test Equipment" GroupName="Menu" />&nbsp;
                     </label>
                     <label class="radio-inline">
                            <asp:RadioButton ID="RadioButton8" runat="server" Text="Lot Eva New Device" GroupName="Menu" />&nbsp;
                     </label>
                 </div>
             </div>
             <div class="form-group">
                 <label for="EmpNo">EmpNo</label>
                 <asp:TextBox ID="txtEmpNo" runat="server" class="form-control" ></asp:TextBox>
             </div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblerror" runat="server" ForeColor="Red"></asp:Label>
        </div>
        <div class="panel-footer">
            <asp:Button ID="Button1" runat="server"  class="btn btn-primary" Text="Confirm" Height="35px"/>
        </div>
    </div>

</asp:Content>