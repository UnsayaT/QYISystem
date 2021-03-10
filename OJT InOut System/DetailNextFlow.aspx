<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetailNextFlow.aspx.vb" Inherits="OJT_InOut_System.DetailNextFlow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2>&nbsp;Detail Next Flow</h2>
    </div>
    <div class="panel panel-primary">
        <div class="panel-body">
            <div class="form-group">
                <label for="Lot No">Lot No :</label>
                <asp:TextBox ID="txtLotno" runat="server" class="form-control" Enabled="False" ></asp:TextBox>          
            </div>
            <div class="form-group">
                <label for="OP No">OP No :</label>
                <asp:TextBox ID="txtOPNO" runat="server" class="form-control" Enabled="False"  ></asp:TextBox>        
            </div>
            <div class="form-group">
                <label for="Next Process">Next Process :</label>
                <div class="form-control">
                    <label class="radio-inline">
                        <asp:RadioButton ID="RadioButton1" runat="server"  Text="EDS" GroupName="Process" />
                    </label>
                    <label class="radio-inline">
                        <asp:RadioButton ID="RadioButton2" runat="server"  Text="DC" GroupName="Process"/>
                    </label>
                    <label class="radio-inline">
                        <asp:RadioButton ID="RadioButton3" runat="server" Text="DB" GroupName="Process"/>
                    </label>
                    <label class="radio-inline">
                        <asp:RadioButton ID="RadioButton4" runat="server"  Text="WB" GroupName="Process"/>
                    </label>
                    <label class="radio-inline">
                        <asp:RadioButton ID="RadioButton5" runat="server"  Text="MP" GroupName="Process"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RadioButton ID="RadioButton17" runat="server"  Text="Low Yield" GroupName="Process" style="color: #0000FF"/>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RadioButton ID="RadioButton18" runat="server"  Text="IC Burn" GroupName="Process" style="color: #FF6666"/>
                    </label>
                </div>
                <br />
                <div class="form-control">
                    <label class="radio-inline">
                        <asp:RadioButton ID="RadioButton6" runat="server"  Text="TC" GroupName="Process"/>
                    </label>
                    <label class="radio-inline">
                        <asp:RadioButton ID="RadioButton7" runat="server"  Text="PL" GroupName="Process"/>
                    </label>
                    <label class="radio-inline">
                        <asp:RadioButton ID="RadioButton8" runat="server" Text="FL" GroupName="Process"/>
                    </label>
                    <label class="radio-inline">
                        <asp:RadioButton ID="RadioButton9" runat="server"  Text="FT" GroupName="Process"/>
                        <label for="Auto">Auto :</label>
                        <asp:TextBox ID="txtAuto" runat="server" ></asp:TextBox>
                    </label>
                    <label class="radio-inline">
                        <asp:RadioButton ID="RadioButton10" runat="server" Text="TP"  GroupName="Process"/>
                    </label>
                    <label class="radio-inline">
                        <asp:RadioButton ID="RadioButton16" runat="server" Text="100 % Insp"  GroupName="Process"/>
                    </label>
                </div>
                <br />
                <div class="form-control">
                    <label class="radio-inline">
                        <asp:RadioButton ID="RadioButton11" runat="server" Text="MAP" GroupName="Process"/>
                    </label>
                    <label class="radio-inline">
                        <asp:RadioButton ID="RadioButton12" runat="server" Text="X-ray" GroupName="Process"/>
                    </label>
                    <label class="radio-inline">
                        <asp:RadioButton ID="RadioButton13" runat="server" Text="QA"  GroupName="Process"/>
                    </label>
                    <label class="radio-inline">
                        <asp:RadioButton ID="RadioButton15" runat="server" Text="TRAY CHANGE"  GroupName="Process"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RadioButton ID="RadioButton14" runat="server" Text=" Retest FT" GroupName="Process" style="color: #FF0000"/>&nbsp;
                        <label for="Auto">Auto :</label>
                        <asp:TextBox ID="txtRetestAuto" runat="server" Width="50px" style="color: #FF5050"></asp:TextBox>
                    </label>
                </div>
            </div>
            <div class="form-group">
               <label for="Remark1">Remark1 :</label> 
               <asp:Label ID="lblRemark" runat="server" Text="Remark1 :"></asp:Label>
               <asp:TextBox ID="txtRemark" runat="server" class="form-control"></asp:TextBox>        
            </div>
            <div class="form-group">
               <label for="Remark1">Remark1 :</label>
               <asp:TextBox ID="txtRemark1" runat="server" class="form-control"></asp:TextBox>       
            </div>
        </div>
        <div class="panel-footer">
            <asp:Button ID="btnconfirm" runat="server" class="btn btn-primary" Text="Confirm" />
        </div>
    </div>
</asp:Content>
