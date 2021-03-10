<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetailOutICBurn.aspx.vb" Inherits="OJT_InOut_System.DetailOutICBurn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2>Detail Output IC Burn.</h2>
    </div>
    <div class="row">
         <div class="col-md-13">
             <p class="text-center">
                 &nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Label ID="OSCheckText" runat="server" Text="O/S Check :"></asp:Label>
                 &nbsp;
                 <asp:TextBox ID="OSCheckValue" runat="server" Width="157px"></asp:TextBox>
                 &nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Label ID="TesterNoText" runat="server" Text="Tester No. :"></asp:Label>
                 &nbsp;
                 <asp:TextBox ID="TesterNoValue" runat="server" Width="157px"></asp:TextBox>
                 &nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Label ID="LotstatusText" runat="server" Text="Lot Status :"></asp:Label>
                 &nbsp;
                 <asp:TextBox ID="LotstatusValue" runat="server" Width="157px"></asp:TextBox>
                 &nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Label ID="BoxNoText" runat="server" Text="Box No. :"></asp:Label>
                 &nbsp;
                 <asp:TextBox ID="BoxNoValue" runat="server" Width="157px"></asp:TextBox>
                 <br/>
             </p>
             <p class="text-center">
                 <asp:Label ID="GoodProductText" runat="server" Text="Good Product :"></asp:Label>
                 &nbsp;
                 <asp:CheckBox ID="GoodProductSHIP1" runat="server" Text="SHIP" />
                 &nbsp;
                 <asp:CheckBox ID="GoodProductSCRAP1" runat="server" Text="SCRAP" />

                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="DeviceText" runat="server" Text="Device :"></asp:Label>
                 <asp:CheckBox ID="DeviceGoodcheck1" runat="server" Text="Good" />
                 &nbsp;<asp:TextBox ID="DeviceGoodRadioButtontextbox" runat="server" CssClass="InputData"></asp:TextBox>
                 &nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:CheckBox ID="DeviceNGcheck1" runat="server" Text="NG" />
                 &nbsp;<asp:TextBox ID="DeviceNGRadioButtontextbox" runat="server" CssClass="InputData"></asp:TextBox>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Label ID="Label1" runat="server" Text="Finished :"></asp:Label>
                 &nbsp;<asp:CheckBox ID="FinishedCB" runat="server" Text="OK" />
             </p>
             <p class="text-center">
                 <asp:Label ID="NgProductText" runat="server" Text="NG Product :"></asp:Label>
                 &nbsp;<asp:CheckBox ID="NgProductBBANK1" runat="server" Text="B-BANK" />
                 &nbsp;
                 <asp:CheckBox ID="NgProductSCRAP1" runat="server" Text="SCRAP" />
                 &nbsp;
                 <asp:CheckBox ID="NgProducttime1" runat="server" Text="1Time Retest SCRAP" />
             </p>
             <p class="text-center">
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Label ID="OSTText" runat="server" Text="O/S T."></asp:Label>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Label ID="LV1PINText" runat="server" Text="LV1. PIN"></asp:Label>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Label ID="ME1PINTText" runat="server" Text="ME1. PIN"></asp:Label>
             </p>
             <p class="text-center">
                 <asp:Label ID="Round1text" runat="server" Text="Round 1"></asp:Label>
                 <asp:TextBox ID="OSTTValue1" runat="server" Width="157px"></asp:TextBox>
                 <asp:TextBox ID="LV1PINTValue1" runat="server" Width="157px"></asp:TextBox>
                 <asp:TextBox ID="ME1PINTValue1" runat="server" Width="157px"></asp:TextBox>
             </p>
             <p class="text-center">
                 <asp:Label ID="Round2Text" runat="server" Text="Round 2"></asp:Label>
                 <asp:TextBox ID="OSTTValue2" runat="server" Width="157px"></asp:TextBox>
                 <asp:TextBox ID="LV1PINTValue2" runat="server" Width="157px"></asp:TextBox>
                 <asp:TextBox ID="ME1PINTValue2" runat="server" Width="157px"></asp:TextBox>
             </p>
             <p class="text-center">
                 <asp:Label ID="Round3Text" runat="server" Text="Round 3"></asp:Label>          
                 <asp:TextBox ID="OSTTValue3" runat="server" Width="157px"></asp:TextBox>
                 <asp:TextBox ID="LV1PINTValue3" runat="server" Width="157px"></asp:TextBox>
                 <asp:TextBox ID="ME1PINTValue3" runat="server" Width="157px"></asp:TextBox>
             </p>
             <p class="text-center">
                  <asp:Label ID="Round4Text" runat="server" Text="Round 4"></asp:Label>
                  <asp:TextBox ID="OSTTValue4" runat="server" Width="157px"></asp:TextBox>
                  <asp:TextBox ID="LV1PINTValue4" runat="server" Width="157px"></asp:TextBox>
                  <asp:TextBox ID="ME1PINTValue4" runat="server" Width="157px"></asp:TextBox>
             </p>
             <p class="text-center">
                  <asp:Label ID="Round5Text" runat="server" Text="Round 5"></asp:Label>
                  <asp:TextBox ID="OSTTValue5" runat="server" Width="157px"></asp:TextBox>
                  <asp:TextBox ID="LV1PINTValue5" runat="server" Width="157px"></asp:TextBox>
                  <asp:TextBox ID="ME1PINTValue5" runat="server" Width="157px"></asp:TextBox>
             </p>
             <p class="text-center">
                  <asp:Label ID="Round6Text" runat="server" Text="Round 6"></asp:Label>           
                  <asp:TextBox ID="OSTTValue6" runat="server" Width="157px"></asp:TextBox>
                  <asp:TextBox ID="LV1PINTValue6" runat="server" Width="157px"></asp:TextBox>
                  <asp:TextBox ID="ME1PINTValue6" runat="server" Width="157px"></asp:TextBox>
             </p>
             <p class="text-center">
                 <asp:Button ID="InputButton" runat="server" Text="Next" class="HeadButton" Height="35px" Width="135px"/>
             </p>
         </div>
     </div>
</asp:Content>
