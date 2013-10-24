<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Pages_Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>潘多拉注册</title>
    <link href="../CSS/Register.css" rel="stylesheet" />
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
            <img src="../CSS/backgrounds/background1.jpg" />
        </div>
        <div id="mainpart">

            <div id="dialog">
                <div id="inform_text">
                    <asp:Label ID="infoLabel" CssClass="css_inform" runat="server" Text="" Font-Names="方正卡通简体" Font-Size="13pt" ForeColor="White" Font-Bold="True"></asp:Label>
                </div>
            </div>

            <div id="row1">
                <div class="left">
                    <asp:Label ID="Label1" runat="server" Text="您的邮箱："></asp:Label>
                </div>
                <div class="right">
                    <asp:TextBox ID="TextBox1" Style="background-color: transparent; outline: none" Font-Size="12pt" Height="18px" ForeColor="White" Width="160px" Font-Names="Times New Roman" runat="server" BorderColor="White" BorderStyle="Groove" BorderWidth="2px"></asp:TextBox>
                </div>
            </div>

            <div id="row2">
                <div class="left">
                    <asp:Label ID="Label2" runat="server" Text="输入密码："></asp:Label>
                </div>
                <div class="right">
                    <asp:TextBox ID="TextBox2" Style="background-color: transparent; outline: none" Font-Size="12pt" Height="18px" ForeColor="White" Width="160px" Font-Names="Times New Roman" runat="server" BorderColor="White" BorderStyle="Groove" BorderWidth="2px" TextMode="Password"></asp:TextBox>
                </div>
            </div>

            <div id="row3">
                <div class="left">
                    <asp:Label ID="Label3" runat="server" Text="确认密码："></asp:Label>
                </div>
                <div class="right">
                    <asp:TextBox ID="TextBox3" Style="background-color: transparent; outline: none" Font-Size="12pt" Height="18px" ForeColor="White" Width="160px" Font-Names="Times New Roman" runat="server" BorderColor="White" BorderStyle="Groove" BorderWidth="2px" TextMode="Password"></asp:TextBox>
                </div>
            </div>

            <div id="row4">
                <div class="left">
                    <asp:Label ID="Label4" runat="server" Text="密保问题："></asp:Label>
                </div>
                <div class="right">
                    <asp:TextBox ID="TextBox4" Style="background-color: transparent; outline: none" Font-Size="12pt" Height="18px" ForeColor="White" Width="160px" Font-Names="Times New Roman" runat="server" BorderColor="White" BorderStyle="Groove" BorderWidth="2px"></asp:TextBox>
                </div>
            </div>

            <div id="row5">
                <div class="left">
                    <asp:Label ID="Label5" runat="server" Text="问题答案："></asp:Label>
                </div>
                <div class="right">
                    <asp:TextBox ID="TextBox5" Style="background-color: transparent; outline: none" Font-Size="12pt" Height="18px" ForeColor="White" Width="160px" Font-Names="Times New Roman" runat="server" BorderColor="White" BorderStyle="Groove" BorderWidth="2px"></asp:TextBox>
                </div>
            </div>

            <div id="row6" class="auto-style1">
                <div class="left">
                    <asp:Label ID="Label6" runat="server" Text="验证码：" ForeColor="White"></asp:Label>
                </div>
                <div id="rightInput">
                    <asp:TextBox ID="TextBox6" Style="background-color: transparent; outline: none" Font-Size="12pt" Height="18px" ForeColor="White" Width="80px" Font-Names="Times New Roman" runat="server" BorderColor="White" BorderStyle="Groove" BorderWidth="2px"></asp:TextBox>
                </div>
                <div id="verificationCode">
                    <img src="VerifyCode.aspx" />
                </div>
            </div>

            <div id="row7">
                <div id="submit">
                    <asp:ImageButton ID="SubmitButton" runat="server" ImageUrl="~/Resource/Register/querenzhuce.png" OnClick="SubmitButton_Click" />
                </div>
            </div>
        </div>

    </form>
</body>
</html>
