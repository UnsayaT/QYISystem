<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="UploadFileIssueNo.aspx.vb" Inherits="OJT_InOut_System.UploadFileIssueNo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="jumbotron">
        <h2>Upload File</h2>
    </div>
    <div class="row">
        <div class="col-md-13">
            <br />
            <br />
            <br />
            <p class="text-center">
                <asp:Label ID="Label1" runat="server" Text="Label" Font-Size="Medium" Font-Bold="True"></asp:Label>
            </p> 
            <br />
            <p class="text-center"> 
                <asp:FileUpload ID="FileUpload1" runat="server" Width="250px" />   
                <br />
                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="UploadFile" Height="22px" Width="88px" />
            </p>
            <p class="text-center"> 
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" Width="619px" EmptyDataText="EmptyData">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField DataField="Text" HeaderText="File Name" >
                            <ItemStyle Width="40%" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDownload" Text = "Download" CommandArgument = '<%# Eval("Value") %>' runat="server" OnClick = "DownloadFile"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID = "lnkDelete" Text = "Delete" CommandArgument = '<%# Eval("Value") %>' runat = "server" OnClick = "DeleteFile" />
                                    </ItemTemplate>
                                 </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
            </p>
            <br />
            <p class="text-center">
                <asp:Button ID="Button1" runat="server" Text="Complete" Height="35px" Width="135px" class="HeadButton"/>
            </p>
        </div> 
    </div>
</asp:Content>
