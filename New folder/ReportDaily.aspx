<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ReportDaily.aspx.vb" Inherits="OJT_InOut_System.ReportDaily" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" media="all" type="text/css" href="Scripts/jquery-ui.css" />
    <link rel="stylesheet" media="all" type="text/css" href="Scripts/jquery-ui-timepicker-addon.css" />

    <script type="text/javascript" src="Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui.min.js"></script>

    <script type="text/javascript" src="Scripts/jquery-ui-timepicker-addon.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui-sliderAccess.js"></script>
    <script type="text/javascript">

        $(function () {
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
        <h1>Web QYI Daily Report</h1>
    </div>
    <div>
        <div class="col-md-10">
             <p class="text-center">
                <table align="center" style="width: 1100px">
                    <tr>
                        <td style="height: 45px; width: 1000px; align-content:center">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <strong>
                            <asp:Label ID="Label3" runat="server" Text="Select Daily : "></asp:Label>
                            &nbsp;
                            </strong>
                            <input id="txtDaily" type="text" name="txtDaily" style="border:2px solid;border-radius:4px;height:25px"/></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="ui-button" />
                        </td>
                    </tr>
                 </table>
            </p>
        </div>
        <div class="col-md-10">
            <h3>RIST Daily Low Yield Report (BELOW 80%)</h3>
            <p>
                <asp:GridView id="myGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1500px" >
	                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
	            <Columns>
	                <asp:TemplateField HeaderText="No">
		                <ItemTemplate>
			                <asp:Label id="lblNo" runat="server" Text=''></asp:Label>
		                </ItemTemplate>


	                </asp:TemplateField>
	                <asp:TemplateField HeaderText="Device Name">
		                <ItemTemplate>
			                 <asp:Label id="lblOldDeviceName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OldDeviceName") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
	                <asp:TemplateField HeaderText="Flow">
		                <ItemTemplate>
			                <asp:Label id="lblFlow" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Process ") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField> 
	                <asp:TemplateField HeaderText="RANK">
		                <ItemTemplate>
			                <asp:Label id="lblRank" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
	                <asp:TemplateField HeaderText="PKG.">
		                <ItemTemplate>
			                <asp:Label id="lblPKG" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OldPackage") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
	                <asp:TemplateField HeaderText="Lot No.">
		                <ItemTemplate>
			                <asp:Label id="lblOldDeviceName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LotNo") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Wafer Lot No.">
		                <ItemTemplate>
			                <asp:Label id="lblOldDeviceName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.WaferLotNo") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Wafer No.">
		                <ItemTemplate>
			                <asp:Label id="lblWaferNo" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Test No.">
		                <ItemTemplate>
			                <asp:Label id="lblTestNo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TestNo") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Yield">
		                <ItemTemplate>
			                <asp:Label id="lblYield" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FTYield") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="FYI IN">
		                <ItemTemplate>
			                <asp:Label id="lblFYIIN" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TimeIn") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Shipment Date">
		                <ItemTemplate>
			                <asp:Label id="lblShipmentDate" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="RIST Incharge">
		                <ItemTemplate>
			                <asp:Label id="lblRISTIncharge" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Issu. No.">
		                <ItemTemplate>
			               <asp:Label id="lblIssue" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IssueNo") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Data sent to R/K ATP (Date)">
		                <ItemTemplate>
			                <asp:Label id="lblRKDate" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sample Sent Date">
		                <ItemTemplate>
			                <asp:Label id="lblSample" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sample Sent Designer">
		                <ItemTemplate>
			                <asp:Label id="SampleDesigner" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Invoice No.">
		                <ItemTemplate>
			                <asp:Label id="lblInv" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Shipmentdelayed">
		                <ItemTemplate>
			                 <asp:Label id="lblShipment" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="FYI delayed">
		                <ItemTemplate>
			                <asp:Label id="lblFYI" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Plan Answer">
		                <ItemTemplate>
			                <asp:Label id="lblplanAnswer" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Revise Shipment Date">
		                <ItemTemplate>
			                <asp:Label id="lblRevise" runat="server"></asp:Label>    
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="FYI OUT">
		                <ItemTemplate>
			                <asp:Label id="lblFYIOUT" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Next Process">
		                <ItemTemplate>
			                <asp:Label id="lblNextProcess" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NextProcess") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="RIST Remark">
		                <ItemTemplate>
			                <asp:Label id="lblRISTRemark" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RISTRemark") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remark">
		                <ItemTemplate>
                            <asp:Label ID="lblRemark" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
	            </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            </p>
        </div>
        <div class="col-md-10">
            <h3>RIST Daily Low Yield Report (BELOW LCL &amp; ABOVE 80%)</h3>
            <p>
               <asp:GridView id="GridView1" runat="server" AutoGenerateColumns="False">
	            <Columns>
	                <asp:TemplateField HeaderText="No">
		                <ItemTemplate>
			                <asp:Label id="lblCustomerID" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
	                <asp:TemplateField HeaderText="Device Name">
		                <ItemTemplate>
			                <asp:Label id="lblName" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
	                <asp:TemplateField HeaderText="Flow">
		                <ItemTemplate>
			                <asp:Label id="lblEmail" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
	                <asp:TemplateField HeaderText="RANK">
		                <ItemTemplate>
			                <asp:Label id="lblCountryCode" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
	                <asp:TemplateField HeaderText="PKG.">
		                <ItemTemplate>
			                <asp:Label id="lblBudget" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
	                <asp:TemplateField HeaderText="Lot No.">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Wafer Lot No.">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Wafer No.">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Test No.">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Yield">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="FYI IN">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Shipment Date">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="RIST Incharge">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Issu. No.">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Data sent to R/K ATP (Date)">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sample Sent Date">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sample Sent Designer">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Invoice No.">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Shipmentdelayed">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="FYI delayed">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Plan Answer">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Revise Shipment Date">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="FYI OUT">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Next Process">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="RIST Remark">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remark">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
	            </Columns>
            </asp:GridView> 
            </p>
        </div>
        <div class="col-md-10">
            <h3>RIST Daily Low Yield Report (issued QAR,wait QC answer)</h3>
            <p>
                <asp:GridView id="GridView2" runat="server" AutoGenerateColumns="False">
	            <Columns>
	                <asp:TemplateField HeaderText="No">
		                <ItemTemplate>
			                <asp:Label id="lblCustomerID" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
	                <asp:TemplateField HeaderText="Device Name">
		                <ItemTemplate>
			                <asp:Label id="lblName" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
	                <asp:TemplateField HeaderText="Flow">
		                <ItemTemplate>
			                <asp:Label id="lblEmail" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
	                <asp:TemplateField HeaderText="RANK">
		                <ItemTemplate>
			                <asp:Label id="lblCountryCode" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
	                <asp:TemplateField HeaderText="PKG.">
		                <ItemTemplate>
			                <asp:Label id="lblBudget" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
	                <asp:TemplateField HeaderText="Lot No.">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Wafer Lot No.">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Wafer No.">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Test No.">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Yield">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="FYI IN">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Shipment Date">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="RIST Incharge">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Issu. No.">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Data sent to R/K ATP (Date)">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sample Sent Date">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sample Sent Designer">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Invoice No.">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Shipmentdelayed">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="FYI delayed">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Plan Answer">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Revise Shipment Date">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="FYI OUT">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Next Process">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="RIST Remark">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remark">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
	            </Columns>
            </asp:GridView>
            </p>
        </div>
        <div class="col-md-10">
            <h3 style="color: #FF0000">RIST Daily IC Burn Report.</h3>
            <p>
                <asp:GridView id="GridView3" runat="server" AutoGenerateColumns="False">
	            <Columns>
	                <asp:TemplateField HeaderText="No">
		                <ItemTemplate>
			                <asp:Label id="lblCustomerID" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
	                <asp:TemplateField HeaderText="Device Name">
		                <ItemTemplate>
			                <asp:Label id="lblName" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
	                <asp:TemplateField HeaderText="Flow">
		                <ItemTemplate>
			                <asp:Label id="lblEmail" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
	                <asp:TemplateField HeaderText="RANK">
		                <ItemTemplate>
			                <asp:Label id="lblCountryCode" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
	                <asp:TemplateField HeaderText="PKG.">
		                <ItemTemplate>
			                <asp:Label id="lblBudget" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
	                <asp:TemplateField HeaderText="Lot No.">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Wafer Lot No.">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Wafer No.">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Test No.">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Yield">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="FYI IN">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Shipment Date">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="RIST Incharge">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Issu. No.">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Data sent to R/K ATP (Date)">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sample Sent Date">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sample Sent Designer">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Invoice No.">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Shipmentdelayed">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="FYI delayed">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Plan Answer">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Revise Shipment Date">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="FYI OUT">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Next Process">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="RIST Remark">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remark">
		                <ItemTemplate>
			                <asp:Label id="lblUsed" runat="server"></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
	            </Columns>
            </asp:GridView>
            &nbsp;</p>
        </div>
    </div>
</asp:Content>

