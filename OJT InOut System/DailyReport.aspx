<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DailyReport.aspx.vb" Inherits="OJT_InOut_System.DailyReport" %>
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
        <h1>QYI Daily Report</h1>
    </div>

    <div class="row">
        <div class="col-md-10">
                            <table align="center" style="width: 1100px">
                    <tr>
                        <td style="height: 45px; width: 1000px; align-content:center">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <strong>
                            <asp:Label ID="Label3" runat="server" Text="Select Date :"></asp:Label>
                            </strong>
                            <input id="txtDaily" type="text" name="txtDaily" style="border:2px solid;border-radius:4px;height:25px"/></td>
                    </tr>
                    
                    <tr>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="ui-button" />
                        </td>
                    </tr>
                 </table>
        </div>
        <div class="col-md-10">
            <h3>RIST Daily Low Yield Report (BELOW 80%)</h3>
            <p>
                <asp:GridView id="myGridView" runat="server" AutoGenerateColumns="False" onRowDataBound="myGridView_RowDataBound">
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
            <h3>RIST Daily Low Yield Report (BELOW LCL &amp; ABOVE 80%)</h3>
            <p>
               <asp:GridView id="GridView1" runat="server" AutoGenerateColumns="False" onRowDataBound="myGridView1_RowDataBound">
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
                <asp:GridView id="GridView2" runat="server" AutoGenerateColumns="False" onRowDataBound="myGridView2_RowDataBound">
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
                <asp:GridView id="GridView3" runat="server" AutoGenerateColumns="False" onRowDataBound="myGridView3_RowDataBound">
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
