<%@ Control Language="C#" AutoEventWireup="true" CodeFile="deBlocking.ascx.cs" Inherits="Pages_deBlocking" %>
<link href="../CSS/deBlocking.css" rel="stylesheet"/>
<div id ="b_contents">
    <div id ="b_main">
    <div id ="part1">
        <div id ="b_user">
            <asp:Label ID="User" runat="server" Font-Names="黑体" Font-Size="13pt" ForeColor="Silver" Text="被封用户ID:"></asp:Label>
        </div>
        <div id ="b_time">
            <asp:Label ID="Time" runat="server" Font-Names="黑体" Font-Size="13pt" ForeColor="Silver" Text="被封时间:"></asp:Label>
        </div>
    </div>
    <div id = "b_outButton">
        <asp:ImageButton ID="OutButton" runat="server" ImageUrl="~/CSS/HomePage/personalHomePage/deblock.png" OnClick="OutButton_Click" />
    </div>
    </div>
</div>
