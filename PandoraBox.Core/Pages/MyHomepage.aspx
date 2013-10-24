<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyHomepage.aspx.cs" Inherits="Pages_MyHomepage" %>

<%@ Register Src="~/Pages/Information.ascx" TagPrefix="uc1" TagName="Information" %>
<%@ Register Src="~/Pages/deBlocking.ascx" TagPrefix="uc1" TagName="deBlocking" %>
<%@ Register Src="~/Pages/MyFriends.ascx" TagPrefix="uc1" TagName="MyFriends" %>
<%@ Register Src="~/Pages/MyFans.ascx" TagPrefix="uc1" TagName="MyFans" %>
<%@ Register Src="~/Pages/AssessmentFood.ascx" TagPrefix="uc1" TagName="AssessmentFood" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../CSS/MyHomepage.css" rel="stylesheet" />
    <script src="jquery-1.10.2.js"></script>
    <script src="jquery.ez-bg-resize.js"></script>
    <script>
        $(document).ready(function () {
            //$(".background").ezBgResize();
        });
    </script>
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
                <asp:ImageButton ID="gerenzhuye" runat="server" ImageUrl="~/CSS/HomePage/menu/menu_style_2_2.png" OnClick="gerenzhuye_Click" />
            </div>
            <div id="Module_personalInfomation" class="menuItem">
                <asp:ImageButton ID="gerenxinxi" runat="server" ImageUrl="~/CSS/HomePage/menu/menu_style_1_3.png" OnClick="gerenxinxi_Click" />
            </div>
            <div id="Module_responseInform" class="menuItem">
                <asp:ImageButton ID="huifutixing" runat="server" ImageUrl="~/CSS/HomePage/menu/menu_style_1_4.png" OnClick="huifutixing_Click" />
            </div>
            <div id="Module_responseFriends" class="menuItem">
                <asp:ImageButton ID="haoyouguanli" runat="server" ImageUrl="~/CSS/HomePage/menu/menu_style_1_5.png" OnClick="haoyouguanli_Click" />
            </div>
        </div>
        <div id="mainPart">
            <div id="MyBackGround"></div>
            <div id="myPanel">
                <asp:UpdatePanel ID="myHomePagePanel" runat="server">
                </asp:UpdatePanel>
            </div>
            <div id="MyHomepageStateColumn">
                <asp:UpdatePanel ID="ButtonPanel" runat="server">
                    <ContentTemplate>
                        <div id="myInformation" class="menuItem">
                            <asp:ImageButton ID="MyInformation" runat="server" ImageUrl="~/CSS/HomePage/personalHomepage/button_style1_03.png" OnClick="MyInformation_Click" />
                        </div>
                        <div id="myCollection" class="menuItem">
                            <asp:ImageButton ID="MyCollection" runat="server" ImageUrl="~/CSS/HomePage/personalHomepage/button_style1_04.png" OnClick="MyCollection_Click" />
                        </div>
                        <div id="report" class="menuItem" runat="server">
                            <asp:ImageButton ID="aspReport" runat="server" ImageUrl="~/CSS/HomePage/personalHomepage/button_style1_05.png" OnClick="aspReport_Click" />
                        </div>
                        <div id="confine" class="menuItem" runat="server">
                            <asp:ImageButton ID="aspConfine" runat="server" ImageUrl="~/CSS/HomePage/personalHomepage/button_style1_06.png" OnClick="aspConfine_Click" />
                        </div>
                        <div id="noAuthority" class="menuItem" runat="server">
                            <asp:ImageButton ID="aspNoAuthority" runat="server" ImageUrl="~/CSS/HomePage/personalHomepage/button_style1_07.png" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="add_and_delete">
                <div id="addTag" class="menuItem">
                    <asp:ImageButton ID="AddTag" runat="server" ImageUrl="~/CSS/HomePage/personalHomepage/add.png" OnClick="AddTag_Click" />
                </div>
                <div id="deleteTag" class="menuItem">
                    <asp:ImageButton ID="DeleteTag" runat="server" ImageUrl="~/CSS/HomePage/personalHomepage/delete.png" OnClick="DeleteTag_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
