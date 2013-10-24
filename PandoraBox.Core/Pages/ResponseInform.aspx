<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResponseInform.aspx.cs" Inherits="Pages_ResponseInform" %>

<%@ Register Src="~/Pages/Information.ascx" TagPrefix="uc1" TagName="Information" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>回复提醒</title>
    <link href="../CSS/ResponseInform.css" rel="stylesheet" />
    <script src="jquery-1.10.2.js"></script>
    <script src="jquery.ez-bg-resize.js"></script>
    <script>
        $(document).ready(function () {
            $(".background").ezBgResize();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
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
                    <asp:ImageButton ID="huifutixing" runat="server" ImageUrl="~/CSS/HomePage/menu/menu_style_2_4.png" OnClick="huifutixing_Click" />
                </div>
                <div id="Module_responseFriends" class="menuItem">
                    <asp:ImageButton ID="haoyouguanli" runat="server" ImageUrl="~/CSS/HomePage/menu/menu_style_1_5.png" OnClick="haoyouguanli_Click" />
                </div>
            </div>
            <div id="mainPart">
                <div id="MyBackGround"></div>
                <div id="ResponseColumn">
                    <asp:UpdatePanel ID="UpdatePanel" runat="server"></asp:UpdatePanel>
                </div>
                <div id="ResponseStateColumn">

                    <asp:UpdatePanel ID="buttonPanel" runat="server">
                        <ContentTemplate>

                    <div id="stateBubble" class="menuItem">
                        <asp:Image ID="Bubble" runat="server" ImageUrl="~/CSS/HomePage/ResponseInform/column_02.png" />
                        <div id="numResponse">
                            <asp:Label ID="Renum" CssClass="NumResponse" runat="server" Text="3个未读回复" Font-Names="黑体" Font-Size="13pt" ForeColor="White" Font-Bold="False"></asp:Label>
                        </div>
                    </div>
                    <div id="yourNewResponse" class="menuItem">
                        <asp:ImageButton ID="NewResponse" runat="server" ImageUrl="~/CSS/HomePage/ResponseInform/column_04.png" OnClick="NewResponse_Click" />
                    </div>
                    <div id="haveChecked" class="menuItem">
                        <asp:ImageButton ID="HaveChecked" runat="server" ImageUrl="~/CSS/HomePage/ResponseInform/column_05.png" OnClick="HaveChecked_Click" />
                    </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </div>
        </div>
    </form>
</body>
</html>
