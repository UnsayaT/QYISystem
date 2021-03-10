<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetailIssueNoICBrun.aspx.vb" Inherits="OJT_InOut_System.DetailIssueNoICBrun" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2>Detail Issue No For IC Burn</h2>
    </div>
    <div class="row">
        <div class="col-md-13">
            <br />
            <p class="text-center">
                <asp:Label ID="Label1" runat="server" Text="Label" Font-Size="Medium" Font-Bold="True"></asp:Label>
            </p>
            <br />
            <p class="text-center">
                <asp:Label ID="DeviceTypeText" runat="server" Text="Device Type"></asp:Label>
                &nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True">
                                <asp:ListItem>Bin31</asp:ListItem>                                
                                <asp:ListItem>Bin29</asp:ListItem>                               
                                <asp:ListItem>QA</asp:ListItem>                                
                                <asp:ListItem>LCL</asp:ListItem>                                
                                <asp:ListItem>Eva</asp:ListItem>                                
                                <asp:ListItem>Other</asp:ListItem>                               
               </asp:DropDownList>
                &nbsp;&nbsp;
                <asp:TextBox ID="OtherValue" runat="server" Width="180px" Visible="False"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" Text="Wafer"></asp:Label>
                &nbsp;&nbsp;
                <asp:TextBox ID="txtWafer" runat="server" Width="180px"></asp:TextBox>
            </p> 
            <br />
            <p class="text-center">
                <asp:Label ID="OSCheckText" runat="server" Text="O/S Check"></asp:Label>
                &nbsp;&nbsp;
                <asp:TextBox ID="OSCheckValue" runat="server" Width="180px"></asp:TextBox> 
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="LotstatusText" runat="server" Text="Lot Status"></asp:Label>
                &nbsp;&nbsp;
                <asp:TextBox ID="LotstatusValue" runat="server" Width="180px"></asp:TextBox>
            </p> 
            <p class="text-center">
                &nbsp;
                <asp:Label ID="TesterNoText" runat="server" Text="Tester No."></asp:Label>
                &nbsp;
                <asp:TextBox ID="TesterNoValue" runat="server" Width="180px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="BoxNoText" runat="server" Text="Box No."></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="BoxNoValue" runat="server" Width="180px"></asp:TextBox>
            </p> 
            <br />
            <p class="text-center">
                <asp:Label ID="OSTesterAnalysisText" runat="server" Text="O/S Tester Analysis "></asp:Label>
                &nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True">
                                    <asp:ListItem>1 Row</asp:ListItem>
                                    <asp:ListItem>2 Row</asp:ListItem>
                                    <asp:ListItem>3 Row</asp:ListItem>
                                    <asp:ListItem>4 Row</asp:ListItem>
                                    <asp:ListItem>5 Row</asp:ListItem>
                                    <asp:ListItem>6 Row</asp:ListItem>
                </asp:DropDownList>
            </p>
            <br />
            <p class="text-center">
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="OSTText" runat="server" Text="O/S T."></asp:Label>
                &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                <asp:Label ID="LV1PINText" runat="server" Text="LV1. PIN"></asp:Label>
                &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                <asp:Label ID="ME1PINTText" runat="server" Text="ME1. PIN"></asp:Label>
            </p> 
            <p class="text-center">
                <asp:Label ID="round1" runat="server" Text="Round 1"></asp:Label>
                <asp:TextBox ID="OSTTValue" runat="server" Width="157px"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:TextBox ID="LV1PINTValue" runat="server" Width="157px"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:TextBox ID="ME1PINTValue" runat="server" Width="157px"></asp:TextBox>
            </p>
            <br />
            <p class="text-center">
                <asp:Label ID="round2" runat="server" Text="Round 2"></asp:Label>
                <asp:TextBox ID="OSTTValue0" runat="server" Width="157px"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:TextBox ID="LV1PINTValue0" runat="server" Width="157px"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:TextBox ID="ME1PINTValue0" runat="server" Width="157px"></asp:TextBox>
            </p>
            <br />
            <p class="text-center">
                <asp:Label ID="round3" runat="server" Text="Round 3"></asp:Label>
                <asp:TextBox ID="OSTTValue1" runat="server" Width="157px"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:TextBox ID="LV1PINTValue1" runat="server" Width="157px"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:TextBox ID="ME1PINTValue1" runat="server" Width="157px"></asp:TextBox>
            </p>
            <br />
            <p class="text-center">
                <asp:Label ID="round4" runat="server" Text="Round 4"></asp:Label>
                <asp:TextBox ID="OSTTValue2" runat="server" Width="157px"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:TextBox ID="LV1PINTValue2" runat="server" Width="157px"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:TextBox ID="ME1PINTValue2" runat="server" Width="157px"></asp:TextBox>
            </p>
            <br />
            <p class="text-center">
                <asp:Label ID="round5" runat="server" Text="Round 5"></asp:Label>
                <asp:TextBox ID="OSTTValue3" runat="server" Width="157px"></asp:TextBox>
                 &nbsp;&nbsp;
                <asp:TextBox ID="LV1PINTValue3" runat="server" Width="157px"></asp:TextBox>
                 &nbsp;&nbsp;
                <asp:TextBox ID="ME1PINTValue3" runat="server" Width="157px"></asp:TextBox>
            </p>
            <br />
            <p class="text-center">
                <asp:Label ID="round6" runat="server" Text="Round 6"></asp:Label>
                <asp:TextBox ID="OSTTValue4" runat="server" Width="157px"></asp:TextBox>
                 &nbsp;&nbsp;
                <asp:TextBox ID="LV1PINTValue4" runat="server" Width="157px"></asp:TextBox>
                 &nbsp;&nbsp;
                <asp:TextBox ID="ME1PINTValue4" runat="server" Width="157px"></asp:TextBox>
            </p>
            <br />
            <p class="text-center">
                <asp:Button ID="InputButton" runat="server" Text="Next" Width="135px" class="HeadButton" Height="35px"/>
            </p>
        </div>
    </div>
</asp:Content>
