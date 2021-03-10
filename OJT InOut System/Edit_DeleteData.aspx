   <%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Edit_DeleteData.aspx.vb" Inherits="OJT_InOut_System.Edit_DeleteData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Edit & Delete Data</h1>
    </div>
    <div class="panel panel-primary">
        <div class="panel-body">
            <table align="center" style="width: 500px">
                <tr>
                    <td><asp:Label ID="Label3" runat="server" Text="AB No :"></asp:Label></td>
                    <td><asp:TextBox ID="txtABNo" runat="server" Width="150px"></asp:TextBox>  </td>
                    <td><asp:Label ID="Label1" runat="server" Text="Issue No :"></asp:Label></td>
                    <td><asp:TextBox ID="txtIssueNo" runat="server" Width="150px"></asp:TextBox>   </td>
                    <td><asp:Button ID="Button1" runat="server" Text="Search"/></td>
                </tr>
            </table>
            <br />
            <br />
            <table style="width: 100%;" align="center">
                    <tr>
                        <td><strong>IssuNo /AB No :</strong></td>
                        <td>
                            <asp:Label ID="lblIssuNo" runat="server" Text=""></asp:Label>
                            <br />
                            <asp:TextBox ID="txtIssuNo" runat="server" Width="180px"></asp:TextBox>
                        </td>
                        <td><strong>Lot no :</strong></td>
                        <td>
                            <asp:Label ID="lblLotNo" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><strong>Device Name :</strong></td>
                        <td>
                            <asp:Label ID="lblDevice" runat="server" Text=""></asp:Label>
                        </td>
                        <td><strong>Package :</strong></td>
                        <td>
                            <asp:Label ID="lblPackage" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><strong>Process :</strong></td>
                        <td>
                            <asp:Label ID="lblProcess" runat="server" Text=""></asp:Label>
                        </td>
                        <td><strong>Flow :</strong></td>
                        <td>
                            <asp:Label ID="lblFlow" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="background-color: #0099FF"><strong>Data Low Yield </strong></td>
                    </tr>
                    <tr>
                        <td><strong>Mode :</strong></td>
                        <td>
                            <asp:DropDownList ID="Mode" runat="server"  Height="50px" Width="117px" AutoPostBack="True">
                                <asp:ListItem>New Mode</asp:ListItem>
                                <asp:ListItem>Same Mode</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td><strong>NG.T.No. :</strong></td>
                        <td>
                            <asp:TextBox ID="txtNG" runat="server" Height="70px" Width="300px" TextMode="MultiLine" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td><strong>NG Data :</strong></td>
                        <td>
                            <asp:TextBox ID="txtDataNG" runat="server" Height="70px" Width="300px" TextMode="MultiLine" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="background-color: #3399FF"><strong>Data IC Burn</strong></td>
                    </tr>
                    <tr>
                        <td colspan="4"></td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <strong>O/S Check : </strong>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox ID="OSCheckValue" runat="server" Width="180px"></asp:TextBox>
                        </td>
                        <td>
                            <br />
                            <strong>OSCheckValue : </strong>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox ID="LotstatusValue" runat="server" Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4"></td>
                    </tr>
                    <tr>
                        <td colspan="4"></td>
                    </tr>
                    <tr>
                        <td colspan="2" class="text-center">
                            <br />
                            <asp:Button ID="btnEdit" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="Red" Height="42px" Text="Confirn Edit" Width="122px" />
                        </td>
                        <td colspan="2" class="text-center">
                            <br />
                            <asp:Button ID="btnDelete" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="Red" Height="42px" Text="Confirn Delete" Width="122px" />
                        </td>
                    </tr>
                </table>
        </div>
    </div>
    </asp:Content>
