<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddTag.aspx.cs" Inherits="Pages_AddTag" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../CSS/AddTag.css" rel="stylesheet" />
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

            <div id="row1" class="auto-style1">
                <div class="left">
                    <asp:Label ID="NameLabel" runat="server" Text="添加标签：" Font-Names="微软雅黑" Font-Size="14pt"></asp:Label>
                </div>
                <div class="right">
                    <asp:TextBox ID="TagText" runat="server" Style="background-color: transparent; outline: none" Font-Size="13pt" Height="22px" ForeColor="White" Width="140px" Font-Names="Times New Roman" BorderColor="White" BorderStyle="Outset" BorderWidth="2px" MaxLength="7"></asp:TextBox>
                </div>
            </div>
            <div id="row3">
                <div class="left">
                    <asp:Label ID="ParentLabel" runat="server" Text="父标签：" Font-Names="微软雅黑" Font-Size="14pt"></asp:Label>
                </div>
                <div class="right">
                    <asp:TextBox ID="ParentLabelText" runat="server" Style="background-color: transparent; outline: none" Font-Size="13pt" Height="22px" ForeColor="White" Width="140px" Font-Names="Times New Roman" BorderColor="White" BorderStyle="Outset" BorderWidth="2px" MaxLength="7"></asp:TextBox>
                </div>
            </div>

            <div id="row5">
                <div id="submit">
                    <asp:ImageButton ID="SubmitButton" runat="server" ImageUrl="~/CSS/backgrounds/AddTagButton.png" OnClick="SubmitButton_Click" />

                </div>
                <div id="return">
                    <asp:ImageButton ID="ReturnButton" runat="server" ImageUrl="~/CSS/backgrounds/returnButton .png" OnClick="ReturnButton_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
