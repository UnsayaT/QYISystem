<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetailInputBin19.aspx.vb" Inherits="OJT_InOut_System.DetailInputBin19" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2>Detail Input Data Bin19</h2>
     </div>
    <div class="row">
        <div class="col-md-3">

            <table align="center" style="width: 500px">
                <tr>
                    <td>
                        <h4 class="text-center">LotNo</h4>
                        <p class="text-center"> <asp:Label ID="LotNo" runat="server" ForeColor="Blue"></asp:Label> </p>
                    </td>
                    <td>
                        <h4 class="text-center">Process</h4>
                        <p class="text-center"> <asp:Label ID="Process" runat="server" ForeColor="Blue"></asp:Label> </p>
                    </td>
                    <td style="width: 113px">
                        <h4 class="text-center">Package</h4>
                        <p class="text-center"> <asp:Label ID="Package" runat="server" ForeColor="Blue"></asp:Label> </p>
                    </td>
                    <td>
                        <h4 class="text-center">Device</h4>
                        <p class="text-center"> <asp:Label ID="Device" runat="server" ForeColor="Blue"></asp:Label> </p>
                    </td> 
                </tr>
                <tr>
                    <td style="width: 113px">
                        <h4 class="text-center">Input 1</h4>
                    </td>
                    <td style="width: 113px">
                        <h4 class="text-center">BIN19</h4>
                        <p class="text-center"> <asp:TextBox ID="txtBIN19_1" runat="server" BackColor="#99CCFF" Width="50px"></asp:TextBox> </p>
                    </td>
                    <td>
                        <h4 class="text-center">Tester</h4>
                        <p class="text-center"> <asp:TextBox ID="txtTester1" runat="server" BackColor="#99CCFF" Width="50px"></asp:TextBox></p>
                    </td>
                    <td style="width: 113px">
                        <h4 class="text-center">Input By</h4>
                        <p class="text-center"> <asp:Label ID="Input1" runat="server" ForeColor="Blue"></asp:Label> </p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h4 class="text-center">Input 2</h4>
                    </td>
                    <td style="width: 113px">
                        <h4 class="text-center">BIN19</h4>
                        <p class="text-center"> <asp:TextBox ID="txtBIN19_2" runat="server" BackColor="#99CCFF" Width="50px"></asp:TextBox> </p>
                    </td>
                    <td>
                        <h4 class="text-center">Tester</h4>
                        <p class="text-center"> <asp:TextBox ID="txtTester2" runat="server" BackColor="#99CCFF" Width="50px"></asp:TextBox> </p>
                    </td>
                    <td>
                        <h4 class="text-center">Input By</h4>
                        <p class="text-center"> <asp:Label ID="Input2" runat="server" ForeColor="Blue"></asp:Label> </p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h4 class="text-center">Input 3</h4>
                    </td>
                    <td>
                        <h4 class="text-center">BIN19</h4>
                        <p class="text-center"> <asp:TextBox ID="txtBIN19_3" runat="server" BackColor="#99CCFF" Width="50px"></asp:TextBox> </p>
                    </td>
                    <td style="width: 113px">
                        <h4 class="text-center">Tester</h4>
                        <p class="text-center"> <asp:TextBox ID="txtTester3" runat="server" BackColor="#99CCFF" Width="50px"></asp:TextBox> </p>
                    </td> 
                    <td>
                        <h4 class="text-center">Input By</h4>
                        <p class="text-center"> <asp:Label ID="Input3" runat="server" ForeColor="Blue"></asp:Label> </p>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <p class="text-center">
                            <strong>
                            <asp:Label ID="lblerror" runat="server" ForeColor="Red"></asp:Label>
                            </strong>
                        </p>
                        <p class="text-center">
                            <asp:Button ID="Button1" runat="server" Text="Confirm" style="width: 71px"/>
                        </p>
                    </td>
                </tr>
            </table>
            
        </div>
        <br />
        <br />
    </div>
</asp:Content>
