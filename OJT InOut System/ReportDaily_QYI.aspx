<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportDaily_QYI.aspx.vb" EnableEventValidation="false"  Inherits="OJT_InOut_System.ReportDaily_QYI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: right;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="background-color: #CCCCCC">Web QYI Daily Report</h1>
        </div>
        <div class="col-md-10">
            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style1">
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="60px" ImageUrl="~/Pictures/History.jpg" Width="60px" OnClientClick="window.open('ReportDaily_QYI_History.aspx')"/>
                    </td>
                </tr>
            </table>
        </div>
        <div class="col-md-10">
            <h3 style="background-color: #FFCCCC">RIST Daily Low Yield Report (BELOW 80%)</h3>
            <p>
            <asp:GridView id="myGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="1900px" style="text-align: center" ShowFooter="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                    DataKeyNames="No"
	                OnRowEditing="modEditCommand"
	                OnRowCancelingEdit="modCancelCommand"
	                OnRowDeleting="modDeleteCommand"
	                OnRowUpdating="modUpdateCommand"
	                OnRowCommand="myGridView_RowCommand"> 
                
	            <Columns>
	                <asp:TemplateField HeaderText="No">
		                <ItemTemplate>
			               <%# Container.DataItemIndex + 1 %>
		                </ItemTemplate>
	                </asp:TemplateField>

	                <asp:TemplateField HeaderText="Device Name">
		                <ItemTemplate>
			                 <asp:Label id="lblOldDeviceName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OldDeviceName") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
			                <asp:TextBox id="txtEditDevice" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OldDeviceName") %>' BackColor="#CCCCCC" size="5" ></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

	                <asp:TemplateField HeaderText="Flow">
		                <ItemTemplate>
			                <asp:Label id="lblFlow" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Process ") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    
	                <asp:TemplateField HeaderText="RANK">
		                <ItemTemplate>
			                <asp:Label id="lblRank" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Rank") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
			                <asp:TextBox id="txtEditRank" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Rank") %>' BackColor="#CCCCCC" size="5" ></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

	                <asp:TemplateField HeaderText="PKG.">
		                <ItemTemplate>
			                <asp:Label id="lblPKG" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OldPackage") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
			                <asp:TextBox id="txtEditPKG" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OldPackage") %>' BackColor="#CCCCCC" size="5" ></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

	                <asp:TemplateField HeaderText="Lot No.">
		                <ItemTemplate>
			                <asp:Label id="lblLotno" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LotNo1") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Wafer Lot No.">
		                <ItemTemplate>
			                <asp:Label id="lblWaferLotNo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.WaferLotNo") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
			                <asp:TextBox id="txtEditWaferLotNo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.WaferLotNo") %>' BackColor="#CCCCCC" size="5" ></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Wafer No.">
		                <ItemTemplate>
			                <asp:Label id="lblWaferNo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.WaferNo") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
			                <asp:TextBox id="txtEditWaferNo"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.WaferNo") %>' BackColor="#CCCCCC" size="5"></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Test No.">
		                <ItemTemplate>
			                <asp:Label id="lblTestNo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TestNo") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
			                <asp:TextBox id="txtEditTestNo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TestNo") %>' BackColor="#CCCCCC" size="5" ></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Yield">
		                <ItemTemplate>
			                <asp:Label id="lblYield" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FTYield") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
			                <asp:TextBox id="txtEditYield" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FTYield") %>' BackColor="#CCCCCC" size="5" ></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="FYI IN">
		                <ItemTemplate>
			                <asp:Label id="lblFYIIN" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FYIIN") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Shipment Date">
		                <ItemTemplate>
			                <asp:Label id="lblShipmentDate" runat="server"  Text='<%# DataBinder.Eval(Container, "DataItem.ShipDate") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
                            <input id="txtEditShipmentDate" type="text" name="txtEditShipmentDate"   value='<%# DataBinder.Eval(Container, "DataItem.ShipmentDate") %>'  size="5" style="background-color: #CCCCCC"/>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="RIST Incharge">
		                <ItemTemplate>
			                <asp:Label id="lblRISTIncharge" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FirstName") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Issu. No.">
		                <ItemTemplate>
			               <asp:Label id="lblIssue" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IssueNo") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Data sent to R/K ">
		                <ItemTemplate>
			                <asp:Label id="lblRKDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RKDate1") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
                            <input id="txtEditRKDate" type="text" name="txtEditRKDate"   value='<%# DataBinder.Eval(Container, "DataItem.RKDate") %>'  size="5" style="background-color: #CCCCCC"/>
		                </EditItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sample Sent Date">
		                <ItemTemplate>
			                <asp:Label id="lblSample" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SampleDate1") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
                            <input id="txtEditSample" type="text" name="txtEditSample"   value='<%# DataBinder.Eval(Container, "DataItem.SampleDate") %>' size="5" style="background-color: #CCCCCC"/>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Sample Sent Designer">
		                <ItemTemplate>
			                <asp:Label id="SampleDesigner" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SampleDesigner") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
                             <asp:TextBox id="txtEditSampleDesigner" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SampleDesigner") %>' BackColor="#CCCCCC" size="5"></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Invoice No.">
		                <ItemTemplate>
			                <asp:Label id="lblInv" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.InvoiceNo") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
                             <asp:TextBox id="txtEditInv" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.InvoiceNo") %>' BackColor="#CCCCCC" size="5"></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Shipment Delayed">
		                <ItemTemplate>
			                 <asp:Label id="lblShipment" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ShipmentDela") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="FYI delayed">
		                <ItemTemplate>
			                <asp:Label id="lblFYI" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FYLDela") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Plan Answer">
		                <ItemTemplate>
			                <asp:Label id="lblplanAnswer" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PlanAnswer1") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
                            <input id="txtEditplanAnswer" type="text" name="txtEditplanAnswer"   value='<%# DataBinder.Eval(Container, "DataItem.PlanAnswer") %>'  size="5" style="background-color: #CCCCCC"/>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Revise Shipment Date">
		                <ItemTemplate>
			                <asp:Label id="lblRevise" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PlanAnswer1") %>'></asp:Label>    
		                </ItemTemplate>
                        <EditItemTemplate>
                            <input id="txtEditRevise" type="text" name="txtEditRevise"   value='<%# DataBinder.Eval(Container, "DataItem.ReviseShipmentDate") %>' size="5" style="background-color: #CCCCCC" />
		                </EditItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="FYI OUT">
		                <ItemTemplate>
			                <asp:Label id="lblFYIOUT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FYIOUT") %>'></asp:Label>
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
                            <asp:Label ID="lblRemark" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Remark") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
                             <asp:TextBox id="txtEditRemark" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Remark") %>' BackColor="#CCCCCC" size="5"></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="Modify"  />
	            </Columns>

                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
            </p>
        </div>
         <div class="col-md-10">
            <h3 style="background-color: #FFCC99">RIST Daily Low Yield Report (BELOW LCL &amp; ABOVE 80%)</h3>
            <p>
            <asp:GridView id="MyGridView1" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4"
                    Width="1900px"
                    style="text-align: center"
                ShowFooter="True" 
    DataKeyNames="No"
	OnRowEditing="modEditCommand1"
	OnRowCancelingEdit="modCancelCommand1"
	OnRowUpdating="modUpdateCommand1"
	OnRowCommand="myGridView1_RowCommand" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                    >
	            <Columns>
	                <asp:TemplateField HeaderText="No">
		                <ItemTemplate>
			                <%# Container.DataItemIndex + 1 %>
		                </ItemTemplate>
	                </asp:TemplateField>

	                <asp:TemplateField HeaderText="Device Name">
		                <ItemTemplate>
			                 <asp:Label id="lblOldDeviceName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OldDeviceName") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
			                <asp:TextBox id="txtEditDevice1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OldDeviceName") %>' BackColor="#CCCCCC" size="5" ></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

	                <asp:TemplateField HeaderText="Flow">
		                <ItemTemplate>
			                <asp:Label id="lblFlow" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Process ") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    
	                <asp:TemplateField HeaderText="RANK">
		                <ItemTemplate>
			                <asp:Label id="lblRank" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Rank") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
			                <asp:TextBox id="txtEditRank1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Rank") %>' BackColor="#CCCCCC" size="5" ></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

	                <asp:TemplateField HeaderText="PKG.">
		                <ItemTemplate>
			                <asp:Label id="lblPKG" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OldPackage") %>'></asp:Label>
		                </ItemTemplate>
                         <EditItemTemplate>
			                <asp:TextBox id="txtEditPKG1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OldPackage") %>' BackColor="#CCCCCC" size="5" ></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

	                <asp:TemplateField HeaderText="Lot No.">
		                <ItemTemplate>
			                <asp:Label id="lblLotno" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LotNo1") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Wafer Lot No.">
		                <ItemTemplate>
			                <asp:Label id="lblWaferLotNo1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.WaferLotNo") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
			                <asp:TextBox id="txtEditWaferLotNo1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.WaferLotNo") %>' BackColor="#CCCCCC" size="5" ></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Wafer No.">
		                <ItemTemplate>
			                <asp:Label id="lblWaferNo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.WaferNo") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
			                <asp:TextBox id="txtEditWaferNo1"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.WaferNo") %>' BackColor="#CCCCCC" size="5"></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Test No.">
		                <ItemTemplate>
			                <asp:Label id="lblTestNo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TestNo") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
			                <asp:TextBox id="txtEditTestNo1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TestNo") %>' BackColor="#CCCCCC" size="5" ></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Yield">
		                <ItemTemplate>
			                <asp:Label id="lblYield" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FTYield") %>'></asp:Label>
		                </ItemTemplate>
                         <EditItemTemplate>
			                <asp:TextBox id="txtEditYield1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FTYield") %>' BackColor="#CCCCCC" size="5" ></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="FYI IN">
		                <ItemTemplate>
			                <asp:Label id="lblFYIIN" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FYIIN") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Shipment Date">
		                <ItemTemplate>
			                <asp:Label id="lblShipmentDate" runat="server"  Text='<%# DataBinder.Eval(Container, "DataItem.ShipDate") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
                            <input id="txtEditShipmentDate1" type="text" name="txtEditShipmentDate1"   value='<%# DataBinder.Eval(Container, "DataItem.ShipmentDate") %>'  size="5" style="background-color: #CCCCCC"/>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="RIST Incharge">
		                <ItemTemplate>
			                <asp:Label id="lblRISTIncharge" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FirstName") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Issu. No.">
		                <ItemTemplate>
			               <asp:Label id="lblIssue" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IssueNo") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Data sent to R/K ">
		                <ItemTemplate>
			                <asp:Label id="lblRKDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RKDate1") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
                            <input id="txtEditRKDate1" type="text" name="txtEditRKDate1"   value='<%# DataBinder.Eval(Container, "DataItem.RKDate") %>'  size="5" style="background-color: #CCCCCC"/>
		                </EditItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sample Sent Date">
		                <ItemTemplate>
			                <asp:Label id="lblSample" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SampleDate1") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
                            <input id="txtEditSample1" type="text" name="txtEditSample1"   value='<%# DataBinder.Eval(Container, "DataItem.SampleDate") %>' size="5" style="background-color: #CCCCCC"/>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Sample Sent Designer">
		                <ItemTemplate>
			                <asp:Label id="SampleDesigner" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SampleDesigner") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
                             <asp:TextBox id="txtEditSampleDesigner1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SampleDesigner") %>' BackColor="#CCCCCC" size="5"></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Invoice No.">
		                <ItemTemplate>
			                <asp:Label id="lblInv" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.InvoiceNo") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
                             <asp:TextBox id="txtEditInv1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.InvoiceNo") %>' BackColor="#CCCCCC" size="5"></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Shipment Delayed">
		                <ItemTemplate>
			                 <asp:Label id="lblShipment" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ShipmentDela") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="FYI delayed">
		                <ItemTemplate>
			                <asp:Label id="lblFYI" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FYLDela") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Plan Answer">
		                <ItemTemplate>
			                <asp:Label id="lblplanAnswer" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PlanAnswer1") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
                            <input id="txtEditplanAnswer1" type="text" name="txtEditplanAnswer1"   value='<%# DataBinder.Eval(Container, "DataItem.PlanAnswer1") %>'  size="5" style="background-color: #CCCCCC"/>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Revise Shipment Date">
		                <ItemTemplate>
			                <asp:Label id="lblRevise" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PlanAnswer1") %>'></asp:Label>    
		                </ItemTemplate>
                        <EditItemTemplate>
                            <input id="txtEditRevise1" type="text" name="txtEditRevise1"   value='<%# DataBinder.Eval(Container, "DataItem.ReviseShipmentDate1") %>' size="5" style="background-color: #CCCCCC" />
		                </EditItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="FYI OUT">
		                <ItemTemplate>
			                <asp:Label id="lblFYIOUT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FYIOUT") %>'></asp:Label>
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
                            <asp:Label ID="lblRemark" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Remark") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
                             <asp:TextBox id="txtEditRemark1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Remark") %>' BackColor="#CCCCCC" size="5"></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="Modify"  />
	            </Columns>

                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
            </p>
        </div>
        <div class="col-md-10">
            <h3 style="background-color: #FFCCFF">RIST Daily Low Yield Report (issued QAR,wait QC answer)</h3>
            <p>
                <asp:GridView id="GridView2" runat="server" AutoGenerateColumns="False">
	            <Columns>
	                <asp:TemplateField HeaderText="No">
		                <ItemTemplate>
			                
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
            <h3 style="color: #FF0000; background-color: #99CCFF;">RIST Daily IC Burn Report.</h3>
            <p>
            <asp:GridView id="MyGridView3" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4"
                    Width="1900px"
                    style="text-align: center"
                ShowFooter="True" 
    DataKeyNames="No"
	OnRowEditing="modEditCommand3"
	OnRowCancelingEdit="modCancelCommand3"
	OnRowUpdating="modUpdateCommand3"
	OnRowCommand="myGridView3_RowCommand" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                    >
	            <Columns>
	                <asp:TemplateField HeaderText="No">
		                <ItemTemplate>
			                <%# Container.DataItemIndex + 1 %>
		                </ItemTemplate>
	                </asp:TemplateField>

	                <asp:TemplateField HeaderText="Device Name">
		                <ItemTemplate>
			                 <asp:Label id="lblOldDeviceName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OldDeviceName") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
			                <asp:TextBox id="txtEditDevice3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OldDeviceName") %>' BackColor="#CCCCCC" size="5" ></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

	                <asp:TemplateField HeaderText="Flow">
		                <ItemTemplate>
			                <asp:Label id="lblFlow" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Process") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    
	                <asp:TemplateField HeaderText="RANK">
		                <ItemTemplate>
			                <asp:Label id="lblRank" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Rank") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
			                <asp:TextBox id="txtEditRank3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Rank") %>' BackColor="#CCCCCC" size="5" ></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

	                <asp:TemplateField HeaderText="PKG.">
		                <ItemTemplate>
			                <asp:Label id="lblPKG" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OldPackage") %>'></asp:Label>
		                </ItemTemplate>
                         <EditItemTemplate>
			                <asp:TextBox id="txtEditPKG3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OldPackage") %>' BackColor="#CCCCCC" size="5" ></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

	                <asp:TemplateField HeaderText="Lot No.">
		                <ItemTemplate>
			                <asp:Label id="lblLotno" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LotNo") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Wafer Lot No.">
		                <ItemTemplate>
			                <asp:Label id="lblWaferLotNo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.WaferLotNo") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
			                <asp:TextBox id="txtEditWaferLotNo3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.WaferLotNo") %>' BackColor="#CCCCCC" size="5" ></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Wafer No.">
		                <ItemTemplate>
			                <asp:Label id="lblWaferNo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.WaferNo") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
			                <asp:TextBox id="txtEditWaferNo3"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.WaferNo") %>' BackColor="#CCCCCC" size="5"></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="O/S Test No.">
		                <ItemTemplate>
			                <asp:Label id="lblTestNo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OST1") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Yield">
		                <ItemTemplate>
			                <asp:Label id="lblYield" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FTYield") %>'></asp:Label>
		                </ItemTemplate>
                         <EditItemTemplate>
			                <asp:TextBox id="txtEditYield3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FTYield") %>' BackColor="#CCCCCC" size="5" ></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="FQI IN">
		                <ItemTemplate>
			                <asp:Label id="lblFYIIN" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FQIIN") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Shipment Date">
		                <ItemTemplate>
			                <asp:Label id="lblShipmentDate" runat="server"  Text='<%# DataBinder.Eval(Container, "DataItem.ShipDate") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
                            <input id="txtEditShipmentDate3" type="text" name="txtEditShipmentDate3"   value='<%# DataBinder.Eval(Container, "DataItem.ShipmentDate") %>'  size="5" style="background-color: #CCCCCC"/>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="RIST Incharge">
		                <ItemTemplate>
			                <asp:Label id="lblRISTIncharge" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FirstName") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Abnormal No.">
		                <ItemTemplate>
			               <asp:Label id="lblIssue" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AbNo") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Data sent to R/K ">
		                <ItemTemplate>
			                <asp:Label id="lblRKDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RKDate1") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
                            <input id="txtEditRKDate3" type="text" name="txtEditRKDate3"   value='<%# DataBinder.Eval(Container, "DataItem.RKDate") %>'  size="5" style="background-color: #CCCCCC"/>
		                </EditItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sample Sent Date">
		                <ItemTemplate>
			                <asp:Label id="lblSample" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SampleDate1") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
                            <input id="txtEditSample3" type="text" name="txtEditSample3"   value='<%# DataBinder.Eval(Container, "DataItem.SampleDate") %>' size="5" style="background-color: #CCCCCC"/>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Sample Sent Designer">
		                <ItemTemplate>
			                <asp:Label id="SampleDesigner" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SampleDesigner") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
                             <asp:TextBox id="txtEditSampleDesigner3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SampleDesigner") %>' BackColor="#CCCCCC" size="5"></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Invoice No.">
		                <ItemTemplate>
			                <asp:Label id="lblInv" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.InvoiceNo") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
                             <asp:TextBox id="txtEditInv3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.InvoiceNo") %>' BackColor="#CCCCCC" size="5"></asp:TextBox>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Shipment Delayed">
		                <ItemTemplate>
			                 <asp:Label id="lblShipment" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ShipmentDela") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="FQI delayed">
		                <ItemTemplate>
			                <asp:Label id="lblFYI" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FQLDela") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Plan Answer">
		                <ItemTemplate>
			                <asp:Label id="lblplanAnswer" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PlanAnswer1") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
                            <input id="txtEditplanAnswer3" type="text" name="txtEditplanAnswer3"   value='<%# DataBinder.Eval(Container, "DataItem.PlanAnswer") %>'  size="5" style="background-color: #CCCCCC"/>
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Revise Shipment Date">
		                <ItemTemplate>
			                <asp:Label id="lblRevise" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PlanAnswer1") %>'></asp:Label>    
		                </ItemTemplate>
                        <EditItemTemplate>
                            <input id="txtEditRevise3" type="text" name="txtEditRevise3"   value='<%# DataBinder.Eval(Container, "DataItem.ReviseShipmentDate") %>' size="5" style="background-color: #CCCCCC" />
		                </EditItemTemplate>
	                </asp:TemplateField>
                    <asp:TemplateField HeaderText="FQI OUT">
		                <ItemTemplate>
			                <asp:Label id="lblFYIOUT" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FQIOUT") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Next Process">
		                <ItemTemplate>
			                <asp:Label id="lblNextProcess3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NextProcess") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="AQI sent to QC Approve (Date)">
		                <ItemTemplate>
			                <asp:Label id="lblAQItoQC" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AQIToQC1") %>'></asp:Label>
		                </ItemTemplate>
                        <EditItemTemplate>
                            <input id="txtEditAQIToQC3" type="text" name="txtEditAQIToQC3"   value='<%# DataBinder.Eval(Container, "DataItem.AQIToQC") %>' size="5" style="background-color: #CCCCCC" />
		                </EditItemTemplate>
	                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Remark">
		                <ItemTemplate>
                            <asp:Label ID="lblRemark" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Remark") %>'></asp:Label>
		                </ItemTemplate>
	                </asp:TemplateField>

                    <asp:CommandField ShowEditButton="True" CancelText="Cancel" DeleteText="Delete" EditText="Edit" UpdateText="Update" HeaderText="Modify"  />
	            </Columns>

                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
            </p>
        </div>
        <div class="col-md-10">
        </div>
    </form>
</body>
</html>
