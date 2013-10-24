<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInfo.aspx.cs" Inherits="Pages_UserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../CSS/UserInfo.css" rel="stylesheet" />
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
            <img src="../CSS/backgrounds/background2.jpg" />
        </div>

        <div id="mainpart">
            <div id="dialog">
                <div id="inform_text">
                    <asp:Label ID="infoLabel" CssClass="css_inform" runat="server" Text="" Font-Names="方正卡通简体" Font-Size="14pt" ForeColor="White" Font-Bold="True"></asp:Label>
                </div>
            </div>

            <div class="row1">
                <div class="left">
                    <asp:Label ID="NameLabel" runat="server" Text="姓名："></asp:Label>
                </div>
                <div class="right">
                    <asp:TextBox ID="NameText" runat="server" Style="background-color: transparent; outline: none" Font-Size="13pt" Height="19px" ForeColor="White" Width="140px" Font-Names="Times New Roman" BorderColor="White" BorderStyle="Outset" BorderWidth="2px"></asp:TextBox>
                </div>
            </div>

            <div class="row2">
                <div class="left">
                    <asp:Label ID="GenderLabel" runat="server" Text="性别："></asp:Label>
                </div>
                <div class="right">
                    <asp:DropDownList ID="GenderDropBox" runat="server">
                        <asp:ListItem>男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="row3">
                <div class="left">
                    <asp:Label ID="SchoolLabel" runat="server" Text="学校："></asp:Label>
                </div>
                <div class="right">
                    <asp:TextBox ID="SchoolText" runat="server" Style="background-color: transparent; outline: none" Font-Size="13pt" Height="19px" ForeColor="White" Width="140px" Font-Names="Times New Roman" BorderColor="White" BorderStyle="Outset" BorderWidth="2px"></asp:TextBox>
                </div>
            </div>

            <div class="row4">
                <div class="left">
                    <asp:Label ID="DepartLabel" runat="server" Text="院系："></asp:Label>
                </div>
                <div class="right">
                    <asp:TextBox ID="DepartText" runat="server" Style="background-color: transparent; outline: none" Font-Size="13pt" Height="19px" ForeColor="White" Width="140px" Font-Names="Times New Roman" BorderColor="White" BorderStyle="Outset" BorderWidth="2px"></asp:TextBox>
                </div>
            </div>

            <div class="row5">
                <div id="submit">
                    <asp:ImageButton ID="SubmitButton" runat="server" ImageUrl="~/CSS/backgrounds/submit.png" OnClick="SubmitButton_Click" />
                </div>
                <div id="password">
                    <asp:ImageButton ID="PasswordButton" runat="server" ImageUrl="~/CSS/backgrounds/changepw.png" OnClick="PasswordButton_Click" />
                </div>
            </div>
        </div>

    </form>
</body>
</html>
