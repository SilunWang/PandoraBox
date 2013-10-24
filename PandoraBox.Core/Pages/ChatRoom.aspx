<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChatRoom.aspx.cs" Inherits="Pages_ChatRoom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../CSS/chatroom.css" rel="stylesheet" />
    <script src="../JS/jquery-1.10.2.js" type="text/javascript"></script>
    <!--窗口自适应显示 ezBgResize.js-->
    <script src="../JS/jquery.ez-bg-resize.js"></script>
    <!--图片的自适应显示-->
    <script>
        //function scrollWindow() {
            //var t = document.getElementById('PublicTextBox');
            //t.scrollTop = t.scrollHeight;
            //var act = document.activeElement;
            //if (act != t) {
                //setTimeout('scrollWindow()', 1000);
            //}
        //}
        var flag = false;
        function DrawImage(ImgD, iwidth, iheight) {
            //参数(图片,允许的宽度,允许的高度)
            var image = new Image();
            image.src = ImgD.src;
            if (image.width > 0 && image.height > 0) {
                flag = true;
                if (image.width / image.height >= iwidth / iheight) {
                    if (image.width > iwidth) {
                        ImgD.width = iwidth;
                        ImgD.height = (image.height * iwidth) / image.width;
                    } else {
                        ImgD.width = image.width;
                        ImgD.height = image.height;
                    }
                }
                else {
                    if (image.height > iheight) {
                        ImgD.height = iheight;
                        ImgD.width = (image.width * iheight) / image.height;
                    } else {
                        ImgD.width = image.width;
                        ImgD.height = image.height;
                    }
                }
            }
        }
        //遍历窗口中每一个img
        function Init() {
            var obj = document.getElementsByTagName("img");
            for (var j = 0; j < obj.length; j++) {
                DrawImage(obj[j], 500, 500);
            }
        }
        window.onload = function () { Init(); scrollWindow(); }
        $(document).ready(function () {
            $(".mainbg").ezBgResize();
        });
        function SubmitKeyClick(button) {
            if (event.keyCode == 13) {
                event.keyCode = 9; event.returnValue = false;
                document.all[button].click();
            }
        }
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <div class="mainbg">
                <img src="../CSS/backgrounds/chatroombg.png" />
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
                <Scripts>
                    <asp:ScriptReference Path="~/jquery-1.8.0.js" />
                </Scripts>
            </asp:ScriptManager>
        </div>
        <div id="mainpart">
            <div class="main1">
                <img src="../CSS/backgrounds/tb1.png" />
            </div>
            <div class="main2" id="bg2">
                <img src="../CSS/backgrounds/tb2.png" />
            </div>
            <div class="main3" id="bg3">
                <img src="../CSS/backgrounds/tb3.png" />
            </div>
            <div class="left">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick"></asp:Timer>
                        <div class="public">
                            <asp:TextBox ID="PublicTextBox" Style="background-color: transparent;" CssClass="PublicTextBox" runat="server" BorderColor="White" BorderStyle="None" ReadOnly="True" TextMode="MultiLine" BackColor="White" Font-Names="微软雅黑" Font-Size="Medium" ForeColor="White"></asp:TextBox>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Button2" />
                    </Triggers>
                </asp:UpdatePanel>
                <div class="ResponsePanel">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        <div class="ResponseTC">
                            <asp:TextBox ID="ResponseTB" CssClass="ResTB" runat="server" Width="370px" Height="70px" Style="background-color: transparent;" BorderColor="White" BorderStyle="None" TextMode="MultiLine" Font-Names="微软雅黑" Font-Size="Medium" ForeColor="White"></asp:TextBox>
                            <asp:ImageButton ID="Button2" CssClass="Button2" runat="server" OnClick="Button2_Click" ImageUrl="~/Resource/Image/responsebt.png" />
                        </div>
                            </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="right">
                <asp:ListBox ID="ListBox1" CssClass="FriendList" Style="background-color: transparent;" runat="server" Font-Names="微软雅黑" Font-Size="Large"></asp:ListBox>
            </div>
        </div>
    </form>
</body>
</html>
