<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="QYIReport.aspx.vb" Inherits="OJT_InOut_System.QYIReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" media="all" type="text/css" href="Scripts/jquery-ui.css" />
    <link rel="stylesheet" media="all" type="text/css" href="Scripts/jquery-ui-timepicker-addon.css" />

    <script type="text/javascript" src="Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui.min.js"></script>

    <script type="text/javascript" src="Scripts/jquery-ui-timepicker-addon.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui-sliderAccess.js"></script>
    <script type="text/javascript">

        $(function(){
            $("#txtDaily").datepicker({
		        dateFormat: 'yy-mm-dd'
	        });
        });

        $(function () {
            $("#txtStart").datepicker({
                dateFormat: 'yy-mm-dd'
            });
        });

        $(function () {
            $("#txtEnd").datepicker({
                dateFormat: 'yy-mm-dd'
            });
        });

        function disable() {
            document.getElementById("txtDaily").disabled = false;
            document.getElementById("txtStart").disabled = true;
            document.getElementById("txtEnd").disabled = true;
        }
        function disable1() {
            document.getElementById("txtDaily").disabled = true;
            document.getElementById("txtStart").disabled = false;
            document.getElementById("txtEnd").disabled = false;
        }
    </script>

    <div class="jumbotron">
        <h2>QYI Report</h2>
    </div>

    <div>
        <div class="col-md-13" style="text-align: center">
            <p class="text-center">
                <table align="center" style="width: 1100px">
                    <tr>
                        <td style="height: 45px; width: 1000px; align-content:center">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <input id="Radio1" name="select Date" type="radio" checked="checked" onclick="disable()"/>
                            <strong>
                            <asp:Label ID="Label3" runat="server" Text="Select Daily"></asp:Label>
                            </strong>
                            <input id="txtDaily" type="text" name="txtDaily" style="border:2px solid;border-radius:4px;height:25px"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <input id="Radio2" name="select Date" type="radio" onclick="disable1()" value="1"/><strong><asp:Label ID="Label2" runat="server" Text="Select Period"></asp:Label>
                            </strong>
                            <input id="txtStart" type="text" name="txtStart" style="border:2px solid;border-radius:4px;height:25px" disabled="disabled" />
                            &nbsp;&nbsp; <strong>To&nbsp;&nbsp; </strong>
                            <input id="txtEnd" type="text" name="txtEnd" style="border:2px solid;border-radius:4px;height:25px" disabled="disabled" />
                            
                        </td>
                    </tr>
                    
                    <tr>
                        <td style="height: 45px">

                            <strong>
                            <asp:Label ID="Label6" runat="server" Text="LotNo :"></asp:Label>
                            &nbsp;<input id="txtLotNo" type="text" name="txtLotNo" style="border:2px solid;border-radius:4px;height:25px"/>&nbsp;&nbsp;&nbsp;&nbsp;
                            </strong>

                            <asp:RadioButton ID="RadioButton1" runat="server" Text="Low Yield" GroupName="Mode" />
&nbsp;&nbsp;
                            <asp:RadioButton ID="RadioButton2" runat="server" Text="IC Burn" GroupName="Mode" />
&nbsp;&nbsp;
                            <asp:RadioButton ID="RadioButton3" runat="server" Text="Bin19" GroupName="Mode" />
&nbsp;&nbsp;
                            <asp:RadioButton ID="RadioButton4" runat="server" Text="All" GroupName="Mode" Checked="True" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="ui-button" style="left: 218px; top: -44px" />
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                             <br />
                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button2" runat="server" Text="Export" CssClass="ui-button" style="left: 218px; top: -44px"  OnClick = "ExportToExcel" />
                        </td>
                    </tr>
                 </table>
            </p>
        </div>
        <br />
        <div class="col-md-13" style="text-align: center">
            Data Start <asp:Label id="lblStart" runat="server" style="color: #0000FF"></asp:Label> To <asp:Label id="lblEnd" runat="server" style="color: #0000FF"></asp:Label>
        </div>
        <br />
        <div class="col-md-13" style="text-align: center">
            <asp:GridView id="MyGridViewLCL" runat="server" Width="1300px" PageSize="5" HorizontalAlign="Center" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="stripe">
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
        </div>
    </div>
</asp:Content>
