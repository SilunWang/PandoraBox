<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Pages_Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>潘多拉宝盒</title>
    <link href="../CSS/login.css" rel="stylesheet" />
    <script src="jquery-1.10.2.js"></script>
    <script src="jquery.ez-bg-resize.js"></script>
    <script>
        $(document).ready(function () {
            $(".main").ezBgResize();
        });
    </script>
</head>

<body>
    
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="main">
            <img src="../CSS/backgrounds/login4.jpg" />
        </div>
        <div id="loginPart">
        
            <div id="dialog">
                <div id="inform_text">
                    <asp:Label ID="infoLabel" CssClass="css_inform" runat="server" Text="您输入的密码有误" Font-Names="方正卡通简体" Font-Size="14pt" ForeColor="White" Font-Bold="True"></asp:Label>
                </div>
            </div>

            <div id="frame">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Resource/loginImage/window.png" BorderStyle="None" Width="301px" />
            </div>
            <div id="UserName">
                <asp:TextBox ID="TextBox1" runat="server" Style="background-color: transparent; border-width: 0px; outline: none" Font-Size="13pt" Height="20px" ForeColor="White" Width="200px" Font-Names="Times New Roman"></asp:TextBox>
            </div>
            <div id="Password">
                <asp:TextBox ID="TextBox2" runat="server" Style="background-color: transparent; border-width: 0px; outline: none" Font-Size="13pt" Height="20px" ForeColor="White" Width="140px" Font-Names="Times New Roman" TextMode="Password"></asp:TextBox>
            </div>
            <div id="go">
                <asp:ImageButton ID="Go" runat="server" ImageUrl="~/Resource/loginImage/go.png" BorderStyle="None" BorderWidth="0px" OnClick="Go_Click" />
            </div>
            <div id="register">
                <asp:ImageButton ID="RegisterButton" runat="server" ImageUrl="~/Resource/loginImage/register.jpg" OnClick="RegisterButton_Click" />
            </div>

            <div id="forgetPassword">
                <asp:ImageButton ID="ForgetPassword" runat="server" ImageUrl="~/Resource/loginImage/forget.png" Width="167px" BorderStyle="None" OnClick="ForgetPassword_Click" />
            </div>
        </div>

    </form>
</body>
</html>

