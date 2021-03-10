<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DocumentsICBurn.aspx.vb" Inherits="OJT_InOut_System.DocumentsICBurn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2>Documents IC Burn.</h2>
    </div>
    <div class="row">
         <div class="col-md-13">
            <br />
            <br />
            <br />
             <p class="text-center">
                <asp:Label ID="Label1" runat="server" Text="Ab.No :"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtAbNo" runat="server"></asp:TextBox>   
                &nbsp;&nbsp;
                <asp:Button ID="SearchAbNoButton" runat="server" Text="Search" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" Text="Device Name :"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtDevice" runat="server"></asp:TextBox>   
                &nbsp;&nbsp;
                <asp:Button ID="SearchdeviecnameButton" runat="server" Text="Search" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" Text="Year :"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtYear" runat="server"  placeholder="Enter Year"></asp:TextBox>
                &nbsp;
                <asp:Button ID="btnYear" runat="server" Text="Search" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnReset" runat="server" Text="Reset" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton1" runat="server" class="auto-style21" ImageUrl="Pictures/folder_document.png" style="width: 30px; height: 30px"/>
            </p>
            <p class="text-center">
                <asp:RadioButton ID="RadioButton1" runat="server" Text="All" />
                <asp:RadioButton ID="RadioButton2" runat="server" Text="Wait Flow"/>
            </p>
            <p class="text-center">
                <asp:GridView ID="GridView1" runat="server" EmptyDataText="No entries found." AutoGenerateColumns="False" Font-Size="Medium" Width="1000px" ShowHeaderWhenEmpty="True" OnPageIndexChanging="OnPageIndexChanging" PageSize="25" HorizontalAlign="Center" CssClass="auto-style24">
                    <columns>
                        <asp:HyperLinkField DataNavigateUrlFields="AbNo" DataNavigateUrlFormatString="DetailFile.aspx?IssueNo={0}" DataTextField="AbNo" HeaderText="Ab.No." >
                        <HeaderStyle HorizontalAlign="Center" BackColor="#99CCFF" Font-Size="Smaller" />
                        <ItemStyle BackColor="#99CCFF" Font-Size="Smaller" />
                        </asp:HyperLinkField>
                        <asp:BoundField HeaderText="Device" DataField="Device" >
                        <HeaderStyle HorizontalAlign="Center" BackColor="#FFCC99" Font-Size="Smaller" />
                        <ItemStyle BackColor="#FFCC99" Font-Size="Smaller" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Lot No." DataField="LotNo" >
                        <HeaderStyle HorizontalAlign="Center" Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Wafer" DataField="WaferLotNo">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WN" HeaderText="W.N">
                        <HeaderStyle Font-Size="Small" HorizontalAlign="Center" />
                        <ItemStyle Font-Size="Small" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Process" DataField="Process" >
                        <HeaderStyle HorizontalAlign="Center" BackColor="#FFCCFF" Font-Size="Smaller" />
                        <ItemStyle BackColor="#FFCCFF" Font-Size="Smaller" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Test Flow" DataField="TestFlow" >
                        <HeaderStyle HorizontalAlign="Center" BackColor="#FFCCFF" Font-Size="Smaller" />
                        <ItemStyle BackColor="#FFCCFF" Font-Size="Smaller" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Yield" DataField="FTYield" >
                        <HeaderStyle BackColor="#CCFF99" Font-Size="Smaller" />
                        <ItemStyle BackColor="#CCFF99" Font-Size="Smaller" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="OS Check" DataField="OSCheck">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Date Occur" DataField="Date" >
                        <HeaderStyle HorizontalAlign="Center" BackColor="#99CCFF" Font-Size="Smaller" />
                        <ItemStyle HorizontalAlign="Center" BackColor="#99CCFF" Font-Size="Smaller" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Package" DataField="Package" >
                        <HeaderStyle HorizontalAlign="Center" Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Lot Status" DataField="LotStatus">
                        <HeaderStyle BackColor="#FFCCCC" Font-Size="Smaller" />
                        <ItemStyle BackColor="#FFCCCC" Font-Size="Smaller" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="FT MC" DataField="FTMCNo">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="FL MC" DataField="FLMCNo">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MAPMCNo" HeaderText="MAP MC">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Mark No." DataField="MarkNo">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Tester No." DataField="TestNo">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Box No." DataField="BoxNo">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="OS.T" DataField="OST1">
                        <HeaderStyle BackColor="#FFCCCC" Font-Size="Smaller" />
                        <ItemStyle BackColor="#FFCCCC" Font-Size="Smaller" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="LV.PIN" DataField="LowVoltPIN1">
                        <HeaderStyle BackColor="#FFCCCC" Font-Size="Smaller" />
                        <ItemStyle BackColor="#FFCCCC" Font-Size="Smaller" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="ME.PIN" DataField="MeasurePIN1">
                        <HeaderStyle BackColor="#FFCCCC" Font-Size="Smaller" />
                        <ItemStyle BackColor="#FFCCCC" Font-Size="Smaller" HorizontalAlign="Center" />
                        </asp:BoundField>
                         <asp:BoundField HeaderText="OS.T" DataField="OST2">
                        <HeaderStyle BackColor="#CCFFCC" Font-Size="Smaller" />
                        <ItemStyle BackColor="#CCFFCC" Font-Size="Smaller" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="LV.PIN" DataField="LowVoltPIN2">
                        <HeaderStyle BackColor="#CCFFCC" Font-Size="Smaller" />
                        <ItemStyle BackColor="#CCFFCC" Font-Size="Smaller" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="ME.PIN" DataField="MeasurePIN2">
                        <HeaderStyle BackColor="#CCFFCC" Font-Size="Smaller" />
                        <ItemStyle BackColor="#CCFFCC" Font-Size="Smaller" HorizontalAlign="Center" />
                        </asp:BoundField>
                         <asp:BoundField HeaderText="OS.T" DataField="OST3">
                        <HeaderStyle BackColor="#CCFFFF" Font-Size="Smaller" />
                        <ItemStyle BackColor="#CCFFFF" Font-Size="Smaller" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="LV.PIN" DataField="LowVoltPIN3">
                        <HeaderStyle BackColor="#CCFFFF" Font-Size="Smaller" />
                        <ItemStyle BackColor="#CCFFFF" Font-Size="Smaller" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="ME.PIN" DataField="MeasurePIN3">
                        <HeaderStyle BackColor="#CCFFFF" Font-Size="Smaller" />
                        <ItemStyle BackColor="#CCFFFF" Font-Size="Smaller" HorizontalAlign="Center" />
                        </asp:BoundField>
                         <asp:BoundField HeaderText="OS.T" DataField="OST4">
                        <HeaderStyle BackColor="#FFFFCC" Font-Size="Smaller" />
                        <ItemStyle BackColor="#FFFFCC" Font-Size="Smaller" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="LV.PIN" DataField="LowVoltPIN4">
                        <HeaderStyle BackColor="#FFFFCC" Font-Size="Smaller" />
                        <ItemStyle BackColor="#FFFFCC" Font-Size="Smaller" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="ME.PIN" DataField="MeasurePIN4">
                        <HeaderStyle BackColor="#FFFFCC" Font-Size="Smaller" />
                        <ItemStyle BackColor="#FFFFCC" Font-Size="Smaller" HorizontalAlign="Center" />
                        </asp:BoundField>
                         <asp:BoundField HeaderText="OS.T" DataField="OST5">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="LV.PIN" DataField="LowVoltPIN5">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="ME.PIN" DataField="MeasurePIN5">
                        <HeaderStyle Font-Size="Smaller" />
                        <ItemStyle Font-Size="Smaller" HorizontalAlign="Center" />
                        </asp:BoundField>
                         <asp:BoundField HeaderText="OS.T" DataField="OST6">
                        <HeaderStyle BackColor="#CCCCFF" Font-Size="Smaller" />
                        <ItemStyle BackColor="#CCCCFF" Font-Size="Smaller" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="LV.PIN" DataField="LowVoltPIN6">
                        <HeaderStyle BackColor="#CCCCFF" Font-Size="Smaller" />
                        <ItemStyle BackColor="#CCCCFF" Font-Size="Smaller" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="ME.PIN" DataField="MeasurePIN6">
                        <HeaderStyle BackColor="#CCCCFF" Font-Size="Smaller" />
                        <ItemStyle BackColor="#CCCCFF" Font-Size="Smaller" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Ship Date" DataField="ShipmentDate">
                        <HeaderStyle BackColor="#CCCCFF" Font-Size="Smaller" />
                        <ItemStyle BackColor="#CCCCFF" Font-Size="Smaller" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UserIDIn" HeaderText="User Input" >
                        <HeaderStyle Font-Size="Smaller" Width="50px" />
                        <ItemStyle Font-Size="Smaller" Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UserIDOut" HeaderText="User Update" >
                        <HeaderStyle Font-Size="Smaller" Width="50px" />
                        <ItemStyle Font-Size="Smaller" Width="50px" />
                        </asp:BoundField>
                    </columns>
            </asp:GridView>
            </p>
          </div>
   </div>
</asp:Content>
