<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgetPW.aspx.cs" Inherits="Pages_ForgetPW" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>潘多拉--找回密码</title>
    <link href="../CSS/ForgetPW.css" rel="stylesheet" />
    <script src="jquery-1.10.2.js"></script>
    <script src="jquery.ez-bg-resize.js"></script>
    <script>
        $(document).ready(function () {
            $(".mainbg").ezBgResize();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainbg">
            <img src="../CSS/backgrounds/login4.jpg" />
        </div>

        <div id="loginPart">
            <div id="dialog">
                <div id="inform_text">
                    <asp:Label ID="infoLabel" CssClass="css_inform" runat="server" Text="您输入的答案有误" Font-Names="方正卡通简体" Font-Size="10pt" ForeColor="White" Font-Bold="False"></asp:Label>
                </div>
            </div>
            <div id="frame">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/CSS/backgrounds/getPWbg.png" BorderStyle="None" />
            </div>
            <div id="UserName">
                <asp:TextBox ID="TextBox1" runat="server" Style="background-color: transparent; border-width: 0px; outline: none" Font-Size="14pt" Height="18px" ForeColor="White" Width="180px" Font-Names="Times New Roman"></asp:TextBox>
            </div>
            <div id="Password">
                <asp:TextBox ID="TextBox2" runat="server" Style="background-color: transparent; border-width: 0px; outline: none" Font-Size="14pt" Height="18px" ForeColor="White" Width="180px" Font-Names="Times New Roman"></asp:TextBox>
            </div>
            <div id="forgetPassword">
                <asp:ImageButton ID="ForgetPassword" runat="server" ImageUrl="~/CSS/backgrounds/getPWbutton.png" Width="167px" BorderStyle="None" OnClick="ForgetPassword_Click1"  />
            </div>
        </div>

    </form>
</body>
</html>
