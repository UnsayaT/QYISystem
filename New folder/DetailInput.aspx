<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetailInput.aspx.vb" Inherits="OJT_InOut_System.DetailInput" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2>Detail Input Data </h2>
    </div>
    <div class="panel panel-primary">
         <div class="panel-body">
             <div class="form-group">
                 <table style="width: 100%;">
                     <tr>
                         <td><label for="LotNo1">LotNo1</label><asp:Label ID="LotNo" runat="server" Text="Label" ForeColor="Blue" class="form-control"></asp:Label></td>
                         <td><label for="LotNo2">LotNo2</label><asp:TextBox ID="txtLotNo2" runat="server" class="form-control"></asp:TextBox></td>
                         <td><label for="LotNo3">LotNo3</label><asp:TextBox ID="txtLotNo3" runat="server" class="form-control"></asp:TextBox></td>
                         <td><label for="LotNo4">LotNo4</label><asp:TextBox ID="txtLotNo4" runat="server" class="form-control"></asp:TextBox></td>
                     </tr>
                     <tr>
                         <td><label for="LotNo5">LotNo5</label><asp:TextBox ID="txtLotNo5" runat="server" class="form-control"></asp:TextBox></td>
                         <td><label for="LotNo6">LotNo6</label><asp:TextBox ID="txtLotNo6" runat="server" class="form-control"></asp:TextBox></td>
                         <td><label for="LotNo7">LotNo7</label><asp:TextBox ID="txtLotNo7" runat="server" class="form-control"></asp:TextBox> </td>
                         <td><label for="LotNo8">LotNo8</label><asp:TextBox ID="txtLotNo8" runat="server" class="form-control"></asp:TextBox></td>
                     </tr>
                     <tr>
                         <td><label for="LotNo9">LotNo9</label><asp:TextBox ID="txtLotNo9" runat="server" class="form-control"></asp:TextBox> </td>
                         <td><label for="LotNo10">LotNo10</label><asp:TextBox ID="txtLotNo10" runat="server" class="form-control"></asp:TextBox></td>
                         <td><label for="LotNo11">LotNo11</label><asp:TextBox ID="txtLotNo11" runat="server" class="form-control"></asp:TextBox> </td>
                         <td><label for="LotNo12">LotNo12</label><asp:TextBox ID="txtLotNo12" runat="server" class="form-control"></asp:TextBox></td>
                     </tr>
                     <tr>
                         <td><label for="LotNo13">LotNo13</label><asp:TextBox ID="txtLotNo13" runat="server" class="form-control"></asp:TextBox></td>
                         <td><label for="LotNo14">LotNo14</label><asp:TextBox ID="txtLotNo14" runat="server" class="form-control"></asp:TextBox></td>
                         <td><label for="LotNo15">LotNo15</label><asp:TextBox ID="txtLotNo15" runat="server" class="form-control"></asp:TextBox></td>
                         <td><label for="LotNo16">LotNo16</label><asp:TextBox ID="txtLotNo16" runat="server" class="form-control"></asp:TextBox></td>
                     </tr>
                     <tr>
                         <td>
                             <label for="Package">Package</label> 
                             <asp:TextBox ID="txtPackage" runat="server" class="form-control"></asp:TextBox>
                         </td>&nbsp;&nbsp;
                         <td>
                             <label for="Devic">Devic</label>
                             <asp:TextBox ID="txtDevice" runat="server" class="form-control"></asp:TextBox>
                         </td>&nbsp;&nbsp;
                         <td>
                             <label for="Machine No ">Machine No </label>
                             <asp:Label ID="Machine" runat="server" Text="Label" ForeColor="Blue" class="form-control"></asp:Label>
                         </td>&nbsp;&nbsp;
                         <td>
                             <label for="Process">Process</label>
                             <asp:Label ID="Process" runat="server" Text="Label" ForeColor="Blue" class="form-control"></asp:Label> 
                         </td>
                     </tr>
                     <tr>
                         <td>
                             <label for="Program">Program</label>
                             <asp:Label ID="Program" runat="server" Text="Label" ForeColor="Blue" class="form-control"></asp:Label>
                         </td>
                         <td>
                             <label for="LotStartTime">LotStartTime</label>
                             <asp:Label ID="LotStartTime" runat="server" Text="Label" ForeColor="Blue" class="form-control"></asp:Label>
                         </td>
                         <td>
                             <label for="WaferLotNo">WaferLotNo</label>
                             <asp:Label ID="WaferLotNo" runat="server" Text="Label" ForeColor="Blue" class="form-control"></asp:Label>
                         </td>
                         <td>
                             <label for="MarkNo">MarkNo</label>
                             <asp:Label ID="MarkNo" runat="server" Text="Label" ForeColor="Blue" class="form-control"></asp:Label>
                         </td>
                     </tr>
                     <tr>
                         <td>
                             <label for="TestFlow">TestFlow</label>
                             <asp:Label ID="TestFlow" runat="server" Text="Label" ForeColor="Blue" class="form-control"></asp:Label>
                         </td>
                         <td>
                             <label for="TesterName">TesterName</label>
                             <asp:Label ID="TesterName" runat="server" Text="Label" ForeColor="Blue" class="form-control"></asp:Label>
                         </td>
                         <td>
                             <label for="TestBoxName">TestBoxName</label>
                             <asp:Label ID="TestBoxName" runat="server" Text="Label" ForeColor="Blue" class="form-control"></asp:Label>
                         </td>
                         <td>
                             <label for="FinalYield">FinalYield</label>
                             <asp:Label ID="FinalYield" runat="server" Text="Label" ForeColor="Blue" class="form-control"></asp:Label>
                         </td>
                     </tr>
                     <tr> 
                         <td>
                             <label for="Wafer No">Wafer No</label>
                             <asp:Label ID="WaferNo" runat="server" Text="Label" ForeColor="Blue" class="form-control"></asp:Label>
                         </td>
                         <td>
                             <label for="ShipmentDate">ShipmentFate</label>
                             <asp:Label ID="ShipmentDate" runat="server" Text="Label" ForeColor="Blue" class="form-control"></asp:Label>
                         </td>
                         <td>
                             <label for="Mode">Mode</label>
                             <asp:Label ID="Mode" runat="server" Text="Label" ForeColor="Blue" class="form-control"></asp:Label>
                         </td>
                         <td>
                             <label for="Input By">Input By</label>
                             <asp:Label ID="Input" runat="server" Text="Label" ForeColor="Blue" class="form-control"></asp:Label>
                         </td>
                        
                     </tr>
                 </table>
             </div>
             <div class="form-group">
                <label for="FlowFYI">Flow FYI</label>
                <div class="form-control">
                     <label class="radio-inline"> 
                         <asp:RadioButton ID="RadioButton10"  runat="server" GroupName="MenuFlowFYI" Text="FYI" />
                     </label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <span style="color: #FF3300">
                        <label for="Comment">*** งาน Lot นี้จะเข้า FYI ต่อ</label>
                     </span>
                </div>
                <br />
                <div class="form-control">
                     <label class="radio-inline">
                         <asp:RadioButton ID="RadioButton11" runat="server" GroupName="MenuFlowFYI" Text="Finish" />
                     </label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <span style="color: #FF3300">
                        <label for="Comment" >*** งาน Lot นี้จะไม่เข้า FYI</label>
                     </span>
                </div>
             </div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Label ID="lblerror" runat="server" ForeColor="Red"></asp:Label>
             <div class="panel-footer">
                <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Confirm" style="width: 71px"/>
             </div>
         </div>
    </div>
</asp:Content>
