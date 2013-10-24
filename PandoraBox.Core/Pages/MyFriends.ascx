<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MyFriends.ascx.cs" Inherits="Pages_MyFriends" %>
<link href="../CSS/MyFriends.css" rel="stylesheet" />
<div id="fr_contents">
    <div id="fr_main">
        <div id="fr_head">
            <asp:ImageButton ID="friendsImage" CssClass ="imageStyle" runat="server" ImageUrl="~/CSS/HomePage/Information/InformationHead.png" OnClick="friendsImage_Click" />
        </div>
        <div id="fr_middle">
            <div id="fr_userName" class="opacity_style">
                <asp:Label ID="Fr_uerName" runat="server" Text="用户昵称:" Font-Names="黑体" Font-Size="12pt" ForeColor="White"></asp:Label>
            </div>
            <div id="fr_email" class="opacity_style">
                <asp:Label ID="Fr_email" runat="server" Text="用户邮箱:" Font-Names="黑体" Font-Size="12pt" ForeColor="White"></asp:Label>
            </div>
            <br />
            <div id="fr_school" class="opacity_style">
                <asp:Label ID="Fr_school" runat="server" Text="所在学校:" Font-Names="黑体" Font-Size="12pt" ForeColor="White"></asp:Label>
            </div>
            <div id="fr_department" class="opacity_style">
                <asp:Label ID="Fr_department" runat="server" Text="所在院系:" Font-Names="黑体" Font-Size="12pt" ForeColor="White"></asp:Label>
            </div>
        </div>
        <div id="fr_right">
            <asp:ImageButton ID="right_button" runat="server" ImageUrl="~/CSS/HomePage/Friends/deleteFriend.png" OnClick="right_button_Click" />
        </div>
    </div>
</div>
