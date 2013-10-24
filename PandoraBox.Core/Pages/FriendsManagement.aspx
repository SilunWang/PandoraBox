<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FriendsManagement.aspx.cs" Inherits="Pages_FriendsManagement" %>

<%@ Register Src="~/Pages/MyFriends.ascx" TagPrefix="uc1" TagName="MyFriends" %>
<%@ Register Src="~/Pages/MyFans.ascx" TagPrefix="uc1" TagName="MyFans" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../CSS/FriendsManagement.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="background">
            <img src="../CSS/HomePage/HomePageBack/myBackground.jpg" />
        </div>
        <div id="stateColumn">
            <div id="Module_newThings" class="menuItem">
                <asp:ImageButton ID="xinxianshi" runat="server" ImageUrl="~/CSS/HomePage/menu/menu_style_1_1.png" OnClick="xinxianshi_Click" />
            </div>
            <div id="Module_personalThings" class="menuItem">
                <asp:ImageButton ID="gerenzhuye" runat="server" ImageUrl="~/CSS/HomePage/menu/menu_style_1_2.png" OnClick="gerenzhuye_Click" />
            </div>
            <div id="Module_personalInfomation" class="menuItem">
                <asp:ImageButton ID="gerenxinxi" runat="server" ImageUrl="~/CSS/HomePage/menu/menu_style_1_3.png" OnClick="gerenxinxi_Click" />
            </div>
            <div id="Module_responseInform" class="menuItem">
                <asp:ImageButton ID="huifutixing" runat="server" ImageUrl="~/CSS/HomePage/menu/menu_style_1_4.png" OnClick="huifutixing_Click" />
            </div>
            <div id="Module_responseFriends" class="menuItem">
                <asp:ImageButton ID="haoyouguanli" runat="server" ImageUrl="~/CSS/HomePage/menu/menu_style_2_5.png" OnClick="haoyouguanli_Click" />
            </div>
        </div>
        <div id="mainPart">
            <div id="MyBackGround"></div>
            <div id="myPanel">
                <asp:UpdatePanel ID="UpdatePanel" runat="server">
                </asp:UpdatePanel>
            </div>
        </div>
        <div id="MyHomepageStateColumn">
            <asp:UpdatePanel ID="buttonPanel" runat="server">
                <ContentTemplate>
                    <div id="numOfFriends" class="menuItem">
                        <div id="numText">
                            <asp:Label ID="NumText" runat="server" Text="200粉丝 ღ 100关注" Font-Names="幼圆" Font-Size="12pt" ForeColor="#CCCCCC" Font-Bold="True"></asp:Label>
                        </div>
                        <asp:Image ID="NumOfFriends" runat="server" ImageUrl="~/CSS/HomePage/Friends/column_02.png" />
                    </div>
                    <div id="getInformation" class="menuItem">
                        <asp:ImageButton ID="GetInformation" runat="server" ImageUrl="~/CSS/HomePage/Friends/column_04.png" OnClick="GetInformation_Click" />
                    </div>
                    <div id="concern" class="menuItem">
                        <asp:ImageButton ID="Concern" runat="server" ImageUrl="~/CSS/HomePage/Friends/column_05.png" OnClick="Concern_Click" />
                    </div>
                    <div id="fans" class="menuItem">
                        <asp:ImageButton ID="Fans" runat="server" ImageUrl="~/CSS/HomePage/Friends/column_06.png" OnClick="Fans_Click" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
