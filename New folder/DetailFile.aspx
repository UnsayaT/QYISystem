<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetailFile.aspx.vb" Inherits="OJT_InOut_System.DetailFile" %>
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
                <asp:Label ID="Label1" runat="server" Text="Label" style="text-align: center" Font-Size="Medium" Font-Bold="True"></asp:Label>
            </p>
            <p class="text-center">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" Width="619px" Font-Size="Small">    
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:BoundField DataField="Text" HeaderText="File Name" >
                            <ItemStyle Width="40%" />
                            </asp:BoundField>
                                <asp:TemplateField HeaderText="File">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDownload" Text = "Download" CommandArgument = '<%# Eval("Value") %>' runat="server" OnClick = "DownloadFile"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>        
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </p>
          </div>
    </div>
</asp:Content>
