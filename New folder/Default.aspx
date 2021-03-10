<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="OJT_InOut_System._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" media="all" type="text/css" href="Scripts/jquery-ui.css" />
    <script type="text/javascript" src="Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('#example').DataTable();
            $('#myGridView').DataTable();
        });
    </script>

    <div class="jumbotron">
        <h1>QYI In-Out System</h1>
    </div>
    <div class="panel panel-primary">
        <div class="panel-body">
            <table align="center" style="width: 1000px">
                <tr>
                    <td>
                        <h2 class="text-center">Input Lot</h2>
                        <p class="text-center">
                            <asp:ImageButton ID="ImageButton1" runat="server" Height="50px" Width="50px" ImageUrl="~/Pictures/In.png" OnClientClick="window.open('InputLotNo.aspx')"  />
                        </p>
                        <p class="text-center"> Input Lotno </p>
                    </td>
                    <td class="modal-sm" style="width: 281px">
                        <h2 class="text-center">Output Lot</h2>
                        <p class="text-center">
                            <asp:ImageButton ID="ImageButton2" runat="server" Height="50px" Width="50px" ImageUrl="~/Pictures/OutFQI.png" OnClientClick="window.open('OutputFQI.aspx')" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="ImageButton3" runat="server" Height="50px" Width="50px" ImageUrl="~/Pictures/OutFYI.png" OnClientClick="window.open('OutputFYI.aspx')" />
                        &nbsp;&nbsp;
                        </p>
                        <p class="text-center"> 
                            <asp:Label ID="Label1" runat="server" Text="Output Lotno FQI"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label2" runat="server" Text="Output Lotno FYI"></asp:Label>
                        </p>
                    </td>
                    <td style="width: 148px">
                        <h2 class="text-center">Issue No</h2>
                        <p class="text-center">
                            <asp:ImageButton ID="ImageButton8" runat="server" Height="50px" ImageUrl="~/Pictures/IssueNo.png" OnClientClick="window.open('IssueNo.aspx')"/>
                        </p>
                        <p class="text-center"> 
                            <asp:Label ID="Label7" runat="server" Text="Issue No"></asp:Label>
                        </p>
                     </td>
                     <td style="width: 200px">
                         <h2 class="text-center">Delete / Edit </h2>
                        <p class="text-center">
                            <asp:ImageButton ID="ImageButton14" runat="server" Height="50px" ImageUrl="~/Pictures/Delete.png" OnClientClick="window.open('Edit_DeleteData.aspx')"/>
                        </p>
                        <p class="text-center"> 
                            Delete Data or Edit Data</p>
                     </td>
                     <td>
                        <h2 class="text-center">QC </h2>
                        <p class="text-center">
                            <asp:ImageButton ID="ImageButton9" runat="server" Height="50px" ImageUrl="~/Pictures/QC.jpg" OnClientClick="window.open('ProcessQC.aspx')"/>
                        </p>
                        <p class="text-center"> 
                            <asp:Label ID="Label8" runat="server" Text="QC Judement BIN19"></asp:Label>
                        </p>
                     </td>
                </tr>
               <%-- <tr>
                    <td colspan="5">
                         <h2 class="text-center">B-Bank Menu</h2>
                        <br />
                         <p class="text-center">
                            &nbsp;<asp:ImageButton ID="ImageButton15" runat="server" Height="50px" Width="50px" ImageUrl="~/Pictures/Bank.png" OnClientClick="window.open('InputB_Bank.aspx')"/>
                            &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                            <asp:ImageButton ID="ImageButton16" runat="server" Height="50px" Width="50px" ImageUrl="~/Pictures/ReportB_Bank.png" OnClientClick="window.open('B_Bank Record.aspx')"/>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                            <asp:ImageButton ID="ImageButton17" runat="server" Height="50px" Width="50px" ImageUrl="" OnClientClick="window.open('StockB_Bank.aspx')"/>
                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                             <asp:ImageButton ID="ImageButton18" runat="server" Height="50px" Width="50px" ImageUrl="" OnClientClick="window.open('OpenB_Bank.aspx')"/>
                        </p>
                        <br />
                        <p class="text-center">
                            <asp:Label ID="Label11" runat="server" Text="NG To B-Bank"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label13" runat="server" Text="B-Bank Record"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label14" runat="server" Text="Stock B-Bank"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label15" runat="server" Text="Open B-Bank"></asp:Label>
                            &nbsp;&nbsp;
                        </p>
                    </td>
                </tr>--%>
                <tr>
                    <td colspan="5">
                        <h2 class="text-center">Link Menu</h2>
                        <br />
                        <p class="text-center">
                            &nbsp;<asp:ImageButton ID="ImageButton4" runat="server" Height="50px" Width="50px" ImageUrl="~/Pictures/Link2.png" OnClientClick="window.open('http://beerserver/FQI_REC/MainForm.aspx')"/>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="ImageButton5" runat="server" Height="50px" Width="50px" ImageUrl="~/Pictures/Link1.png" OnClientClick="window.open('http://beerserver/LSI/FYI/mainmenu.aspx')"/>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="ImageButton6" runat="server" Height="50px" Width="50px" ImageUrl="~/Pictures/Link3.png" OnClientClick="window.open('http://webserv.thematrix.net/QYISystem/QYI/QYIMaster.aspx')" />
                            &nbsp;&nbsp;&nbsp;</p>
                        <br />
                        <p class="text-center">
                            <asp:Label ID="Label3" runat="server" Text="FQI Menu"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label4" runat="server" Text="FYI Menu"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label5" runat="server" Text="QYI Menu"></asp:Label>
                             &nbsp;&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <br />
                        <h2 class="text-center">Report Menu</h2>
                        <br />
                        <p class="text-center">
                            &nbsp;<asp:ImageButton ID="ImageButton10" runat="server" Height="50px" Width="50px" ImageUrl="~/Pictures/LCL.jpg" OnClientClick="window.open('Documents.aspx')"/>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="ImageButton11" runat="server" Height="50px" Width="50px" ImageUrl="~/Pictures/IC.jpg" OnClientClick="window.open('DocumentsICBurn.aspx')"/>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="ImageButton13" runat="server" Height="50px" Width="50px" ImageUrl="~/Pictures/Report.jpg" OnClientClick="window.open('ReportBin19.aspx')"/>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="ImageButton7" runat="server" Height="50px" Width="50px" ImageUrl="~/Pictures/ReportAll.png" OnClientClick="window.open('QYIReport.aspx')"/>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="ImageButton12" runat="server" Height="50px" Width="50px" ImageUrl="~/Pictures/DailyReport.jpg" OnClientClick="window.open('http://webserv.thematrix.net/QYI/dailyreport')"/>
                        </p>
                        <br />
                        <p class="text-center">
                            Low Yield&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label10" runat="server" Text="IC Burn"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label12" runat="server" Text="Report Bin19"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label6" runat="server" Text="QYI Report"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label9" runat="server" Text="Daily Report"></asp:Label>
                        </p>
                    </td>
                </tr>
            </table>

            <table align="center" style="width: 1000px">
                <tr>
                    <td>
                        <h3 style="background-color: #999999; width: 1000px; color: #FFFFFF;" class="text-center">Data FQI --> FYI</h3>
                    </td>
                </tr>
                <tr>
                    <td class="text-center">
                        <div class="text-center">
                            
                            <asp:GridView ID="MyGridViewFYI" runat="server"  DataKeyNames="No"  AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" Width="1000px" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" >
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="No" HeaderText="No" ItemStyle-Width="190" >
                                        <ItemStyle Width="190px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LotNo" HeaderText="Lot No" ItemStyle-Width="190" >
                                        <ItemStyle Width="190px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OldDeviceName" HeaderText="DeviceName" ItemStyle-Width="190" >
                                        <ItemStyle Width="190px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OldPackage" HeaderText="Package" ItemStyle-Width="190" >
                                       <ItemStyle Width="190px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Process" HeaderText="Process" ItemStyle-Width="190" >
                                        <ItemStyle Width="190px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Mode" HeaderText="Mode" ItemStyle-Width="190" >
                                        <ItemStyle Width="190px"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#808080" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#383838" />
                            </asp:GridView>
                            <br />
                            <asp:Button ID="btnReceive" runat="server" Text="Receive Lot" />
                        </div>
                        <br />
                    </td>
                </tr>
            </table>
            <table align="center" style="width: 1000px">
                <tr>
                    <td>
                        <h3 style="background-color: #5D7B9D; width: 1000px; color: #FFFFFF;" class="text-center">Data Low Yield</h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView id="MyGridViewLCL" runat="server" Width="1000px" PageSize="5" HorizontalAlign="Center" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="stripe">
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3 style="background-color: #1C5E55; width: 1000px; color: #FFFFFF;" class="text-center">Data IC Burn</h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView id="myGridViewBIN" runat="server" Width="1000px" PageSize="5" HorizontalAlign="Center" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="stripe">
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White"></HeaderStyle>
                            <AlternatingRowStyle BackColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3 style="background-color: #4A3C8C; width: 1000px; color: #FFFFFF;" class="text-center">Data BIN19</h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView id="myGridViewBin19" runat="server" Width="1000px" PageSize="5" HorizontalAlign="Center" CellPadding="3" GridLines="Horizontal" CssClass="stripe" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px">
                            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7"></HeaderStyle>
                            <AlternatingRowStyle BackColor="#F7F7F7" />
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <SortedAscendingCellStyle BackColor="#F4F4FD" />
                            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                            <SortedDescendingCellStyle BackColor="#D8D8F0" />
                            <SortedDescendingHeaderStyle BackColor="#3E3277" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3 style="background-color: #507CD1; width: 1000px; color: #FFFFFF;" class="text-center">Data Lot Eva</h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView id="myGridViewLot" runat="server" Width="1000px" PageSize="5" HorizontalAlign="Center" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="stripe">
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>
                            <AlternatingRowStyle BackColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <%--  --%>
</asp:Content>
