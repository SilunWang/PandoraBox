<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePW.aspx.cs" Inherits="Pages_ChangePW" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../CSS/ChangePW.css" rel="stylesheet" />
    <script src="../JS/jquery-1.10.2.js"></script>
    <script src="../JS/jquery.ez-bg-resize.js"></script>
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
                    <asp:Label ID="infoLabel" CssClass="css_inform" runat="server" Text="" Font-Names="方正卡通简体" Font-Size="17pt" ForeColor="White"></asp:Label>
                </div>
            </div>
            <div class="row1">
                <div class="left">
                    <asp:Label ID="Label1" runat="server" Text="输入原密码：" ForeColor="#D8D0FF"></asp:Label>
                </div>
                <div class="right">
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="Password" Style="background-color: transparent; outline: none" Font-Size="13pt" Height="19px" ForeColor="White" Width="140px" Font-Names="Times New Roman" BorderColor="White" BorderStyle="Outset" BorderWidth="2px"></asp:TextBox>
                </div>
            </div>
            <div class="row2">
                <div class="left">
                    <asp:Label ID="Label2" runat="server" Text="输入新密码：" ForeColor="#D8D0FF"></asp:Label>
                </div>
                <div class="right">
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Style="background-color: transparent; outline: none" Font-Size="13pt" Height="19px" ForeColor="White" Width="140px" Font-Names="Times New Roman" BorderColor="White" BorderStyle="Outset" BorderWidth="2px"></asp:TextBox>
                </div>
            </div>
            <div class="row3">
                <div class="left">
                    <asp:Label ID="confirm" runat="server" Text="新密码确认：" ForeColor="#D8D0FF"></asp:Label>
                </div>
                <div class="right">
                    <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" Style="background-color: transparent; outline: none" Font-Size="13pt" Height="19px" ForeColor="White" Width="140px" Font-Names="Times New Roman" BorderColor="White" BorderStyle="Outset" BorderWidth="2px"></asp:TextBox>
                </div>
            </div>
            <div class="row4">
                <div class="left">
                    <asp:Label ID="Label4" runat="server" Text=" 密保问题：" ForeColor="#D8D0FF"></asp:Label>
                </div>
                <div class="right">
                    <asp:TextBox ID="TextBox4" runat="server" Style="background-color: transparent; outline: none" Font-Size="13pt" Height="19px" ForeColor="White" Width="140px" Font-Names="Times New Roman" BorderColor="White" BorderStyle="Outset" BorderWidth="2px"></asp:TextBox>
                </div>
            </div>
            <div class="row5">
                <div class="left">
                    <asp:Label ID="Label5" runat="server" Text="问题答案：" ForeColor="#D8D0FF"></asp:Label>
                </div>
                <div class="right">
                    <asp:TextBox ID="TextBox5" runat="server" Style="background-color: transparent; outline: none" Font-Size="13pt" Height="19px" ForeColor="White" Width="140px" Font-Names="Times New Roman" BorderColor="White" BorderStyle="Outset" BorderWidth="2px"></asp:TextBox>
                </div>
            </div>
            <div class="row6">
                <div id="submit">
                    <asp:ImageButton ID="SubmitButton" runat="server" ImageUrl="~/CSS/backgrounds/changePWbutton.png" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
