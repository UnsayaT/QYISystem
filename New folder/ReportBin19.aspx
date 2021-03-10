<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ReportBin19.aspx.vb" Inherits="OJT_InOut_System.ReportBin19" %>

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
        <h2>Report Special flow Alarm BIN19 </h2>
    </div>
    <div>
        <div class="col-md-13" style="text-align: center">
            <p class="text-center">
                <table align="center" style="width: 1100px">
                    <tr>
                        <td style="height: 20px; width: 1000px; align-content:center">
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
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="ui-button" />
                            <strong>
                            &nbsp;<br />
                            <asp:Label id="lblText" runat="server" style="color: #FF0000"></asp:Label>
                            </strong>
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
            <table align="center" style="width: 1100px" class="table">
            <asp:Repeater id="myRepeater" runat="server">
	        <HeaderTemplate>		
			        <tr>
				        <td style="background-color:darkgrey;font-size:small"><b>Date In</b></td>
                        <td style="background-color:darkgrey;font-size:small"><b>Date Out</b></td>
				        <td style="background-color:darkgrey;font-size:small"><b>Package</b></td>
				        <td style="background-color:darkgrey;font-size:small"><b>DeviceName</b></td>
				        <td style="background-color:darkgrey;font-size:small"><b>LotNo</b></td>
                        <td style="background-color:darkgrey;font-size:small"><b>NG Bin19 Q'ty</b></td>
				        <td style="background-color:darkgrey;font-size:small"><b>1st Bin19 </b></td>
                        <td style="background-color:darkgrey;font-size:small"><b>1st Bin19 Jugdement</b></td>
                        <td style="background-color:darkgrey;font-size:small"><b>After Retesr A3 NG Bin19 Q'ty</b></td>
				        <td style="background-color:darkgrey;font-size:small"><b>After Retest A3</b></td>
                        <td style="background-color:darkgrey;font-size:small"><b>After Retesr A3 Judgement</b></td>
                        <td style="background-color:darkgrey;font-size:small"><b>QC Judement</b></td>
			        </tr>
	        </HeaderTemplate>
	        <ItemTemplate>
		        <tr>		
			        <td align="center"><asp:Label id="lblDateIn" runat="server" Text='<%#Container.DataItem("DateIn") %>'></asp:Label></td>
                    <td align="center"><asp:Label id="lblDateOut" runat="server" Text='<%#Container.DataItem("DateOut") %>'></asp:Label></td>
			        <td><asp:Label id="lblPackage" runat="server" Text='<%#Container.DataItem("OldPackage") %>'></asp:Label></td>
			        <td><asp:Label id="lblDeviceName" runat="server" Text='<%#Container.DataItem("OldDeviceName") %>'></asp:Label></td>
			        <td align="center"><asp:Label id="lblLotNo" runat="server" Text='<%#Container.DataItem("LotNo") %>'></asp:Label></td>
                    <td align="center"><asp:Label id="lblBeforeOSNG1" runat="server" Text='<%#Container.DataItem("BeforeOSNG1") %>'></asp:Label></td>
			        <td align="center"><asp:Label id="lblNG1" runat="server" Text='<%#Container.DataItem("NG1") %>'></asp:Label></td>
                    <td align="center"><asp:Label id="lbl1stJug" runat="server" Text='<%#Container.DataItem("GotoProcess") %>'></asp:Label></td>
                    <td align="center"><asp:Label id="lblBeforeOSNG2" runat="server" Text='<%#Container.DataItem("BeforeOSNG2") %>'></asp:Label></td>
			        <td align="center"><asp:Label id="lblNG2" runat="server" Text='<%#Container.DataItem("NG2") %>'></asp:Label></td>
                    <td align="center"><asp:Label id="lblAfterJug" runat="server" Text='<%#Container.DataItem("GotoProcess2") %>'></asp:Label></td>
                    <td align="center"><asp:Label id="lblQCJug" runat="server" Text='<%#Container.DataItem("QCJugdement") %>'></asp:Label></td>
		        </tr>		
	        </ItemTemplate>
            <AlternatingItemTemplate>
                <tr bgcolor="#E0FFFF">		
			        <td align="center"><asp:Label id="lblDateIn" runat="server" Text='<%#Container.DataItem("DateIn") %>'></asp:Label></td>
                    <td align="center"><asp:Label id="lblDateOut" runat="server" Text='<%#Container.DataItem("DateOut") %>'></asp:Label></td>
			        <td><asp:Label id="lblPackage" runat="server" Text='<%#Container.DataItem("OldPackage") %>'></asp:Label></td>
			        <td><asp:Label id="lblDeviceName" runat="server" Text='<%#Container.DataItem("OldDeviceName") %>'></asp:Label></td>
			        <td align="center"><asp:Label id="lblLotNo" runat="server" Text='<%#Container.DataItem("LotNo") %>'></asp:Label></td>
                    <td align="center"><asp:Label id="lblBeforeOSNG1" runat="server" Text='<%#Container.DataItem("BeforeOSNG1") %>'></asp:Label></td>
			        <td align="center"><asp:Label id="lblNG1" runat="server" Text='<%#Container.DataItem("NG1") %>'></asp:Label></td>
                    <td align="center"><asp:Label id="lbl1stJug" runat="server" Text='<%#Container.DataItem("GotoProcess") %>'></asp:Label></td>
                    <td align="center"><asp:Label id="lblBeforeOSNG2" runat="server" Text='<%#Container.DataItem("BeforeOSNG2") %>'></asp:Label></td>
			        <td align="center"><asp:Label id="lblNG2" runat="server" Text='<%#Container.DataItem("NG2") %>'></asp:Label></td>
                    <td align="center"><asp:Label id="lblAfterJug" runat="server" Text='<%#Container.DataItem("GotoProcess2") %>'></asp:Label></td>
                    <td align="center"><asp:Label id="lblQCJug" runat="server" Text='<%#Container.DataItem("QCJugdement") %>'></asp:Label></td>
		        </tr>	
            </AlternatingItemTemplate>
	        </asp:Repeater>

	        </table>		
        </div>
    </div>
</asp:Content>
