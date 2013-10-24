<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MyFans.ascx.cs" Inherits="Pages_MyConcern" %>
<link href="../CSS/MyFans.css" rel="stylesheet" />
<div id="co_contents">
    <div id="co_main">
        <div id="co_head">
            <asp:ImageButton ID="friendsImage" CssClass="imageStyle" runat="server" ImageUrl="~/CSS/HomePage/Information/InformationHead.png" OnClick="friendsImage_Click"/>
        </div>
        <div id="co_middle">
            <div id ="co_userName" class ="opacity_style">
                <asp:Label ID="Co_uerName" runat="server" Text="用户昵称:" Font-Names="黑体" Font-Size="12pt" ForeColor="White"></asp:Label>
            </div>
            <div id ="co_email" class ="opacity_style">
                <asp:Label ID="Co_email" runat="server" Text="用户邮箱:"  Font-Names="黑体" Font-Size="12pt" ForeColor="White"></asp:Label>
            </div>
            <br />
            <div id ="co_school" class ="opacity_style">
                <asp:Label ID="Co_school" runat="server" Text="所在学校:"  Font-Names="黑体" Font-Size="12pt" ForeColor="White"></asp:Label>
            </div>
            <div id ="co_department" class ="opacity_style">
                <asp:Label ID="Co_department" runat="server" Text="所在院系:"  Font-Names="黑体" Font-Size="12pt" ForeColor="White"></asp:Label>
            </div>
        </div>
        <div id="co_right">
            <div id ="addConcern">
                <asp:ImageButton ID="AddConcern" runat="server" ImageUrl="~/CSS/HomePage/Friends/care.png" OnClick="AddConcern_Click" />
            </div>
        </div>
    </div>
</div>