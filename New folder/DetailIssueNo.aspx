<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetailIssueNo.aspx.vb" Inherits="OJT_InOut_System.DetailIssueNo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2>Detail Issue No For Low Yield</h2>
    </div>
    <div class="panel panel-primary">
        <div class="panel-body">
                <table align="center" style="width: 1000px">
                    <tr>
                        <td><asp:Button ID="Button1" runat="server" BackColor="White" ForeColor="Red" Text="New Issue" /></td>
                        <td><asp:Label ID="Label1" runat="server" Text="Label" Font-Size="Large" Font-Bold="True"></asp:Label></td>
                        <td><asp:Button ID="Button2" runat="server" BackColor="White" ForeColor="#0066FF" Text="Edit Issue" /></td>
                        <td><asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox></td>
                    </tr>
                </table>
                <br />
                <div class="text-center">
                <asp:Table ID="Table1" runat="server" Height="16px" Width="1000px"  HorizontalAlign="Center" Font-Size="Medium">
				                <asp:TableRow runat="server">
                                    <asp:TableCell runat="server">
                                        <asp:Label ID="Label5" runat="server" Text="Lot No" Font-Size="Medium" BackColor="#ffcccc"></asp:Label><br/><br/>
                                        <asp:TextBox ID="Lottxt1" runat="server" Width="100px" Enabled="false"></asp:TextBox>&nbsp;&nbsp;
                                        <asp:TextBox ID="Lottxt2" runat="server" Width="100px" ></asp:TextBox>&nbsp;&nbsp;
                                        <asp:TextBox ID="Lottxt3" runat="server" Width="100px" ></asp:TextBox>&nbsp;&nbsp;
                                        <asp:TextBox ID="Lottxt4" runat="server" Width="100px" ></asp:TextBox>&nbsp;&nbsp;
                                        <asp:TextBox ID="Lottxt5" runat="server" Width="100px" ></asp:TextBox>&nbsp;&nbsp; 
                                        <asp:TextBox ID="Lottxt6" runat="server" Width="100px" ></asp:TextBox>&nbsp;&nbsp;
                                        <asp:TextBox ID="Lottxt7" runat="server" Width="100px" ></asp:TextBox>&nbsp;&nbsp;
                                        <asp:TextBox ID="Lottxt8" runat="server" Width="100px" ></asp:TextBox>&nbsp;&nbsp;
                                    </asp:TableCell>
                                </asp:TableRow>
                                
                                <asp:TableRow runat="server">
                                    <asp:TableCell runat="server">
                                        <br />
                                        <asp:TextBox ID="Lottxt9" runat="server" Width="100px" ></asp:TextBox>&nbsp;&nbsp;
                                        <asp:TextBox ID="Lottxt10" runat="server" Width="100px" ></asp:TextBox>&nbsp;&nbsp;
                                        <asp:TextBox ID="Lottxt11" runat="server" Width="100px" ></asp:TextBox>&nbsp;&nbsp;
                                        <asp:TextBox ID="Lottxt12" runat="server" Width="100px" ></asp:TextBox>&nbsp;&nbsp;
                                        <asp:TextBox ID="Lottxt13" runat="server" Width="100px" ></asp:TextBox>&nbsp;&nbsp;
                                        <asp:TextBox ID="Lottxt14" runat="server" Width="100px" ></asp:TextBox>&nbsp;&nbsp;
                                        <asp:TextBox ID="Lottxt15" runat="server" Width="100px" ></asp:TextBox>&nbsp;&nbsp;
                                        <asp:TextBox ID="Lottxt16" runat="server" Width="100px" ></asp:TextBox>&nbsp;&nbsp;
                                    </asp:TableCell>
                                </asp:TableRow>
                  </asp:Table>
                  </div>
                  <br />
                  <table align="center" style="width: 1000px">
                      <tr>
                          <td class="text-center">
                              <asp:Label ID="ModeL" runat="server" Text="Mode :"></asp:Label>
                              <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="128px">
                                    <asp:ListItem>Same Mode</asp:ListItem>
                                    <asp:ListItem>New Mode</asp:ListItem>
                              </asp:DropDownList>
                         
                               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         
                               <asp:Label ID="ModeL1" runat="server" Text="Same Mode IssueNo:"></asp:Label>
                               <asp:TextBox ID="txtModel1" runat="server" ></asp:TextBox>

                               <asp:Label ID="ModeL2" runat="server" Text="Ex.  RIST-2019-0001" style="font-size: small; color: #FF0000"></asp:Label>
                              <br />
                          </td>
                      </tr>
                  </table>
                  <br />

                  <div class="text-center">

                  <asp:Table ID="Table2" runat="server" Height="16px" Width="1000px"  HorizontalAlign="Center" Font-Size="Medium">
				    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">
                            <asp:Label ID="Label2" runat="server" Text="NG Test No." Font-Size="Medium" BackColor="#ffcccc"></asp:Label><br/><br/>
                            <asp:TextBox ID="NgtNoT" runat="server" Width="100px" ></asp:TextBox>&nbsp;&nbsp;
                            <asp:TextBox ID="txtNGTestNo2" runat="server" Width="100px" ></asp:TextBox>&nbsp;&nbsp;
                            <asp:TextBox ID="txtNGTestNo3" runat="server" Width="100px" ></asp:TextBox>&nbsp;&nbsp;
                            <asp:TextBox ID="txtNGTestNo4" runat="server" Width="100px" ></asp:TextBox>&nbsp;&nbsp;
                            <asp:TextBox ID="txtNGTestNo5" runat="server" Width="100px" ></asp:TextBox>&nbsp;&nbsp; 
                            <asp:TextBox ID="txtNGTestNo6" runat="server" Width="100px" ></asp:TextBox>&nbsp;&nbsp;
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">
                            <br />
                            <asp:Label ID="Label3" runat="server" Text="NG Data." Font-Size="Medium" BackColor="#ffcccc"></asp:Label><br/><br/>
                            <asp:TextBox ID="NgtDateT" runat="server" Width="100px" ></asp:TextBox>&nbsp;&nbsp;
                            <asp:TextBox ID="txtNGData2" runat="server" Width="100px" ></asp:TextBox>&nbsp;&nbsp;
                            <asp:TextBox ID="txtNGData3" runat="server" Width="100px" ></asp:TextBox>&nbsp;&nbsp;
                            <asp:TextBox ID="txtNGData4" runat="server" Width="100px" ></asp:TextBox>&nbsp;&nbsp;
                            <asp:TextBox ID="txtNGData5" runat="server" Width="100px" ></asp:TextBox>&nbsp;&nbsp; 
                            <asp:TextBox ID="txtNGData6" runat="server" Width="100px" ></asp:TextBox>&nbsp;&nbsp;
                        </asp:TableCell>
                    </asp:TableRow>
                  </asp:Table>
                  <table align="center" style="width: 1000px">
                      <tr>
                          <td class="text-center">
                                <br />
                                <asp:Button ID="InputButton" runat="server" Text="Next" Height="35px" Width="135px" class="HeadButton "/>
                          </td>
                      </tr>
                  </table>
                </div>
        </div>
    </div>
</asp:Content>
