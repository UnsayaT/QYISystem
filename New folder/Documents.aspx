<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Documents.aspx.vb" Inherits="OJT_InOut_System.Documents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2>Documents Low Yield.</h2>
    </div>
    <div class="row">
         <div class="col-md-13">
            <br />
            <br />
            <br />
            <p class="text-center">
                <asp:Label ID="Label1" runat="server" Text="Issue No :"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtIssueNo" runat="server"></asp:TextBox>   
                &nbsp;&nbsp;
                <asp:Button ID="btnIssueNo" runat="server" Text="Search" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" Text="Device Name :"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtDevice" runat="server"></asp:TextBox>   
                &nbsp;&nbsp;
                <asp:Button ID="btnDevice" runat="server" Text="Search" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" Text="Year :"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtYear" runat="server"  placeholder="Enter Year"></asp:TextBox>
                &nbsp;
                <asp:Button ID="btnYear" runat="server" Text="Search" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnReset" runat="server" Text="Reset" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton1" runat="server" class="auto-style21" ImageUrl="Pictures/folder_document.png" style="width: 30px; height: 30px"/>
                
            </p>
              <br />
            <p class="text-center">
                <asp:Table ID="Table2" runat="server" BackColor="White" HorizontalAlign="Center" Width="779px" Height="50px">
                                    <asp:TableRow runat="server">
                                        <asp:TableCell colspan="2" runat="server">
                                            <asp:Label ID="Label6" runat="server" Text="Selected Process"></asp:Label>&nbsp;&nbsp;&nbsp;
                                        </asp:TableCell>
                                        <asp:TableCell colspan="2" runat="server">
                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" CssClass="auto-style16" Height="44px" RepeatDirection="Horizontal" Width="236px">
                                                <asp:ListItem Selected="True">All</asp:ListItem>
                                                <asp:ListItem>FT</asp:ListItem>
                                                <asp:ListItem>FL</asp:ListItem>
                                                <asp:ListItem>Map</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </asp:TableCell>
                                        <asp:TableCell colspan="2" runat="server">
                                            <asp:Label ID="Label7" runat="server" Text="Selected Package"></asp:Label>&nbsp;&nbsp;&nbsp;
                                        </asp:TableCell>
                                        <asp:TableCell colspan="2" runat="server">                  
                                            <asp:DropDownList ID="DropDownList1" runat="server" Height="36px" Width="177px" AutoPostBack="True">
                                            </asp:DropDownList>    
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>          
            </p>
            <br />
            <p class="text-center">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ForeColor="Black" HorizontalAlign="Center" Width="1000px" CellSpacing="2" ShowHeaderWhenEmpty="True" EmptyDataText="No entries found." CssClass="auto-style18" OnPageIndexChanging="OnPageIndexChanging" Font-Size="Medium" PageSize="25">
                    <columns>
                        <asp:HyperLinkField HeaderText="Issue No." DataTextField="IssueNo" DataNavigateUrlFormatString="DetailFile.aspx?IssueNo={0}" DataNavigateUrlFields="IssueNo">
                            <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" ForeColor="Black" Font-Size="X-Small" Width="150px" />
                            <ItemStyle ForeColor="Black" Width="150px" HorizontalAlign="Center" BackColor="#CCCCFF" Font-Size="Smaller" />
                        </asp:HyperLinkField>
                        <asp:BoundField HeaderText="Device" DataField="Device">
                            <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" ForeColor="Black" Font-Size="X-Small" Width="150px" />
                            <ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="150px" BackColor="#CCCCFF" Font-Size="Smaller" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LotNo" HeaderText="Lot No.">
                            <HeaderStyle Font-Size="X-Small" HorizontalAlign="Center"  Width="11px" />
                            <ItemStyle Font-Size="Small" HorizontalAlign="Center" Width="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LotNo1" HeaderText="AllLotNo.">
                            <HeaderStyle ForeColor="Black" Font-Size="X-Small" HorizontalAlign="Center" />
                            <ItemStyle Width="11px" Font-Size="Smaller" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Package" DataField="Package" >
                            <HeaderStyle BackColor="White" HorizontalAlign="Center" ForeColor="Black" Font-Size="X-Small" />
                            <ItemStyle ForeColor="Black" Width="90px" HorizontalAlign="Center" Font-Size="Smaller" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Process" DataField="Process" >
                            <HeaderStyle BackColor="White" HorizontalAlign="Center" ForeColor="Black" Font-Size="X-Small" />
                            <ItemStyle ForeColor="Black" Width="5px" HorizontalAlign="Center" Font-Size="Smaller" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Flow" DataField="TestFlow">
                            <HeaderStyle Font-Size="X-Small" HorizontalAlign="Center"/>
                            <ItemStyle Font-Size="Smaller" HorizontalAlign="Center" Width="5px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="NG. T. No." DataField="NGTestNo" >
                            <HeaderStyle BackColor="#FF9999" HorizontalAlign="Center" ForeColor="Black" Font-Size="X-Small" Width="10px"/>
                            <ItemStyle ForeColor="Black" BackColor="#FF9999" Width="10px" HorizontalAlign="Center" Font-Size="Smaller" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Mode" DataField="Mode" >
                            <HeaderStyle BackColor="#FFFF99" ForeColor="Black" Font-Size="X-Small" HorizontalAlign="Center" />
                            <ItemStyle BackColor="#FFFF99" Width="60px" Font-Size="Smaller" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Yield" DataField="FTYield">
                            <HeaderStyle BackColor="#66FF66" ForeColor="Black" Font-Size="X-Small" HorizontalAlign="Center" />
                            <ItemStyle BackColor="#66FF66" Width="10px" Font-Size="Smaller" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Good Product Ship" DataField="GoodProductShip">
                            <HeaderStyle HorizontalAlign="Center" BackColor="White" ForeColor="Black" Font-Size="X-Small" Width="50px"/>
                            <ItemStyle ForeColor="#0000CC" HorizontalAlign="Center" Font-Size="Smaller" Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Good Product Scrap" DataField="GoodProductScrap">
                            <HeaderStyle  HorizontalAlign="Center" BackColor="White" ForeColor="Black" Font-Size="X-Small" Width="50px"  />
                            <ItemStyle ForeColor="Red" HorizontalAlign="Center" Font-Size="Smaller" Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="NG Product BBank" DataField="NGProductBBank">
                            <HeaderStyle HorizontalAlign="Center" BackColor="White" ForeColor="Black"  Font-Size="X-Small" Width="50px" />
                            <ItemStyle ForeColor="#0000CC" HorizontalAlign="Center"  Font-Size="Smaller" Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="NG Product Scrap" DataField="NGProductScrap">
                            <HeaderStyle HorizontalAlign="Center" BackColor="White" ForeColor="Black"  Font-Size="X-Small" Width="50px" />
                            <ItemStyle ForeColor="Red" HorizontalAlign="Center"  Font-Size="Smaller" Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="One Time ReTest Scrap" DataField="OneTimeReTestScrap">
                            <HeaderStyle HorizontalAlign="Center" BackColor="White" ForeColor="Black" Font-Size="X-Small" Width="50px" />
                            <ItemStyle ForeColor="Black" HorizontalAlign="Center"  Font-Size="Smaller" Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Device Good" DataField="AnswerDeviceGood">
                            <HeaderStyle HorizontalAlign="Center" BackColor="White" ForeColor="Black" Font-Size="X-Small"   Width="50px"/>
                            <ItemStyle ForeColor="#0000CC" HorizontalAlign="Center"  Font-Size="Smaller"  Width="50px"/>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Device NG" DataField="AnswerDeviceNG">
                            <HeaderStyle HorizontalAlign="Center" BackColor="White" ForeColor="Black" Font-Size="X-Small"   Width="50px"/>
                            <ItemStyle ForeColor="Red" HorizontalAlign="Center"  Font-Size="Smaller"  Width="50px"/>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Cause" DataField="Cause">
                            <HeaderStyle BackColor="White" ForeColor="Black" Font-Size="X-Small" HorizontalAlign="Center" Width="50px"/>
                            <ItemStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" Font-Size="Smaller" Width="50px"/>
                        </asp:BoundField>
                            <asp:BoundField HeaderText="FNDate" DataField="NewFNDate">
                            <HeaderStyle BackColor="#FFCC66" ForeColor="Black" Font-Size="X-Small" Width="50px" HorizontalAlign="Center"/>
                            <ItemStyle BackColor="#FFCC66" HorizontalAlign="Center"  Font-Size="Smaller" Width="50px"/>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Program" DataField="Program">
                            <HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="50px"/>
                            <ItemStyle Font-Size="Smaller" Width="30px" HorizontalAlign="Center"/>
                        </asp:BoundField>
                  
                        <asp:BoundField DataField="Remark" HeaderText="Remark">
                             <HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="50px"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="UserIDIn" HeaderText="User Input" >
                            <HeaderStyle Font-Size="X-Small" HorizontalAlign="Justify" Width="10px" />
                            <ItemStyle Font-Size="Smaller" HorizontalAlign="Center"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="UserIDOut" HeaderText="User Update" >
                            <HeaderStyle Font-Size="X-Small" HorizontalAlign="Justify" Width="10px" />
                            <ItemStyle Font-Size="Smaller" Width="10px" HorizontalAlign="Center"/>
                        </asp:BoundField>
                    </columns>
                </asp:GridView>
            </p>
          </div>
    </div>
</asp:Content>
