<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetailOutLowYield.aspx.vb" Inherits="OJT_InOut_System.DetailOutLowYield" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2>Detail Output LowYield.</h2>
    </div>
    <div class="row">
         <div class="col-md-13">
            <br />
            <br />
            <br />
            <p class="text-center">
                <asp:Label ID="lblIssueNo" runat="server" Text="Label" Font-Size="Large" Font-Bold="True" /> 
            </p>
            <p class="text-center"> 
                <asp:FileUpload ID="FileUpload1" runat="server" Width="250px" />   
                <br />
                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="UploadFile" Height="22px" Width="88px" />
            </p>
            <p class="text-center"> 
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" Width="619px" EmptyDataText="EmptyData">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField DataField="Text" HeaderText="File Name" >
                            <ItemStyle Width="40%" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDownload" Text = "Download" CommandArgument = '<%# Eval("Value") %>' runat="server" OnClick = "DownloadFile"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID = "lnkDelete" Text = "Delete" CommandArgument = '<%# Eval("Value") %>' runat = "server" OnClick = "DeleteFile" />
                                    </ItemTemplate>
                                 </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
            </p>
            <p class="text-center">
                <asp:Label ID="GoodProductText" runat="server" Text="Good Product :"></asp:Label>
                &nbsp;
                <asp:CheckBox ID="GoodProductSHIP1" runat="server" Text="SHIP" />
                &nbsp;<asp:CheckBox ID="GoodProductSCRAP1" runat="server" Text="SCRAP" />
            </p>
            <p class="text-center">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="CauseText" runat="server" Text="Cause :"></asp:Label>
                &nbsp;
                <asp:CheckBox ID="Cause1" runat="server" Text="Repair" />
                &nbsp;
                <asp:CheckBox ID="Cause2" runat="server" Text="Assy" />
                &nbsp;
                <asp:CheckBox ID="Cause3" runat="server" Text="Test" />
                &nbsp;
                <asp:CheckBox ID="Cause4" runat="server" Text="Fab" />
            </p> 
            <p class="text-center">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="Cause5" runat="server" Text="Spec" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="Cause6" runat="server" Text="Etc" />
                &nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="Cause7" runat="server" Text="Analysis" />
                &nbsp;&nbsp;
            </p>
            <p class="text-center">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="NgProductText" runat="server" Text="NG Product :"></asp:Label>
                &nbsp;
                <asp:CheckBox ID="NgProductBBANK1" runat="server" Text="B-BANK" />
                &nbsp;
                <asp:CheckBox ID="NgProductSCRAP1" runat="server" Text="SCRAP" />
                &nbsp;
                <asp:CheckBox ID="NgProducttime1" runat="server" Text="1Time Retest SCRAP" />
            </p>
            <p class="text-center">
                <asp:Label ID="FnDateText" runat="server" Text="FN Date :"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="FNDate" runat="server" Text=""></asp:Label>
            </p>
            <p class="text-center">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="DeviceText" runat="server" Text="Device :"></asp:Label>
                &nbsp;
                <asp:CheckBox ID="DeviceGoodcheck1" runat="server" Text="Good" />
                &nbsp;
                <asp:TextBox ID="DeviceGoodRadioButtontextbox" runat="server" CssClass="InputData"></asp:TextBox>
                &nbsp;</p>
            <p class="text-center">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="DeviceNGcheck1" runat="server" Text="NG" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="DeviceNGRadioButtontextbox" runat="server" CssClass="InputData"></asp:TextBox>
            </p>
            <p class="text-center">
                <asp:Label runat="server" Text="Remark"></asp:Label>
            </p>
            <p class="text-center">
                <asp:TextBox ID="TextBox1" runat="server" Width="500px" TextMode="MultiLine" Height="250"></asp:TextBox>
            </p>
            <br />
            
            
            
            <br />
            <p class="text-center">
                <asp:Button ID="InputButton" runat="server" Text="Next" Height="35px" Width="135px" class="HeadButton "/>         
            </p>
         </div>
    </div>
</asp:Content>
