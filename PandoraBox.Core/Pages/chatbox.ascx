<%@ Control Language="C#" AutoEventWireup="true" CodeFile="chatbox.ascx.cs" Inherits="Pages_chatbox" %>

<link href="../CSS/charbox.css" rel="stylesheet" />
<!--jQuery 1.10.2版本-->
<script src="../JS/jquery-1.10.2.js"></script>
<script>
    $(document).ready(function () {
        $('.cancelbt').click(function () {
            $("#DialogRect").fadeOut(1000);
        });
    });
</script>
<div id="DialogRect">
    <div class="bg">
        <img src="../CSS/backgrounds/dialogbg.png" />
    </div>
    <div id="mainpart">
        <asp:Image ID="CancelButton" CssClass="cancelbt" runat="server" ImageUrl="~/Resource/Image/cancel.png" />
        <asp:UpdatePanel ID="UpdatePanel1" CssClass="UPanel" runat="server">
            <ContentTemplate>
                <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick"></asp:Timer>
                <asp:TextBox ID="DialogText" CssClass="DialogText" runat="server" TextMode="MultiLine" BorderColor="White" BorderStyle="None" Font-Bold="True" Font-Names="微软雅黑" Font-Size="Medium" ForeColor="White"></asp:TextBox>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <div id="input">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <asp:TextBox ID="ResponseText" CssClass="ResponseText" runat="server" TextMode="MultiLine" BorderColor="White" BorderStyle="None" Font-Bold="True" Font-Names="微软雅黑" Font-Size="Medium" ForeColor="White"></asp:TextBox>
            <asp:ImageButton ID="Button1" CssClass="EnterBT" runat="server" Text="Button" ImageUrl="~/Resource/Image/responsebt.png" OnClick="Button2_Click"/>
        </ContentTemplate>
                </asp:UpdatePanel>
    </div>
</div>
