<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonalInformation.aspx.cs" Inherits="Pages_PersonalInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../CSS/PersonalInformation.css" rel="stylesheet" />
    <!--Uploadify-->
    <link href="../JS/jquery.uploadify/example/css/default.css" rel="stylesheet" type="text/css" />
    <link href="../JS/jquery.uploadify/uploadify.css" rel="stylesheet" type="text/css" />
    <!--BitmapCutter-->
    <link rel="Stylesheet" type="text/css" href="../CSS/jquery.bitmapcutter.css" />
    <link href="../CSS/MessageBox.css" rel="stylesheet" />
    <!--注：此处必须使用jquery-1.3.2.min版本才能正常使用-->
    <script type="text/javascript"
        src="../JS/jquery.uploadify/jquery-1.3.2.min.js"></script>
    <!--窗口自适应显示 ezBgResize.js-->
    <script src="../JS/jquery.ez-bg-resize.js"></script>
    <!--弹出框-->
    <script src="../JS/PopUp.js"></script>
    <!--Uploadify-->
    <script type="text/javascript"
        src="../JS/jquery.uploadify/swfobject.js"></script>
    <script type="text/javascript"
        src="../JS/jquery.uploadify/jquery.uploadify.v2.1.0.min.js"></script>
    <!--BitmapCutter-->
    <script type="text/javascript" src="../JS/jquery.bitmapcutter.js"></script>
    <script src="../JS/MessageBox.js"></script>
    <script>
        $(document).ready(function () {
            //$(".mainbg").ezBgResize();
            $('#ImageBorder').click(function () {
                $('.popupbox').fadeIn(100);
                //alert();
            });
            $('#Button1').click(function () {
                $('.popupbox').fadeOut(100);
            })
        });
        $(document).ready(function () {
            $("#uploadify").uploadify({
                'uploader': '../JS/jquery.uploadify/uploadify.swf',
                'script': 'UploadHandler.ashx',
                'cancelImg': '../JS/jquery.uploadify/cancel.png',
                'folder': 'UploadFile',
                'queueID': 'fileQueue',
                'auto': false,
                'multi': false,
                'OnUploadStart': function () {
                    $('#uploadify').uploadifyUpload();
                },
                'onComplete': function (event, queueID, fileObj, response, data) {
                    $.fn.bitmapCutter({
                        src: 'UploadFile/' + fileObj.name,
                        renderTo: '#container',
                        cutterSize: { width: 135, height: 135 },
                        onGenerated: function (src) {
                            $('.popupbox').hide();
                            alert("请点击保存修改，以显示新头像");
                            //var a = "＜%=ss()%＞";
                            //$.ajax({
                            //    type: "POST",
                            //    contentType: "application/json; charset=utf-8",
                            //    url: "PersonalInformation.aspx/setImage",
                            //    data: "{}",
                            //    dataType: 'json',
                            //    success: function (result) {
                            //        alert("请点击保存修改，以显示新头像");
                            //    },
                            //    error: function (err) {
                            //        alert(err);
                            //    }
                            //});
                        },
                        rotateAngle: 90,
                        lang: { clockwise: '顺时针旋转{0}度.' }
                    });
                }
            });
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
                <asp:ImageButton ID="gerenzhuye" runat="server" ImageUrl="~/CSS/HomePage/menu/menu_style_1_2.png" OnClick="gerenzhuye_Click" />
            </div>
            <div id="Module_personalInfomation" class="menuItem">
                <asp:ImageButton ID="gerenxinxi" runat="server" ImageUrl="~/CSS/HomePage/menu/menu_style_2_3.png" OnClick="gerenxinxi_Click" />
            </div>
            <div id="Module_responseInform" class="menuItem">
                <asp:ImageButton ID="huifutixing" runat="server" ImageUrl="~/CSS/HomePage/menu/menu_style_1_4.png" OnClick="huifutixing_Click" />
            </div>
            <div id="Module_responseFriends" class="menuItem">
                <asp:ImageButton ID="haoyouguanli" runat="server" ImageUrl="~/CSS/HomePage/menu/menu_style_1_5.png" OnClick="haoyouguanli_Click" />
            </div>
        </div>
        <div id="mainPart">
            <div id="MyBlackGround"></div>
            <div id="MyInfo">
                <div id="warnningDialog">
                    <div id="inform_text">
                        <asp:Label ID="infoLabel" CssClass="css_inform" runat="server" Font-Names="微软雅黑" Font-Size="14pt" ForeColor="White" Font-Bold="False"></asp:Label>
                    </div>
                </div>
                <asp:UpdatePanel ID="headPanel" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="headImage">
                            <div id="myHead">
                                <asp:ImageButton CssClass ="headImageStyle" ID="MyHeadImage" runat="server" />
                            </div>
                            <div id="myHeadBorder">
                                <asp:ImageButton ID="ImageBorder" runat="server" ImageUrl="~/CSS/HomePage/personalInformation/image.png" OnClick="ImageBorder_Click" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div id="information">
                    <div id="myName">
                        <asp:TextBox ID="MyName" CssClass="myTextBox" runat="server" Style="background-color: transparent; border-width: 0px; outline: none" Font-Size="13pt" ForeColor="White" Font-Names="微软雅黑" TextMode="SingleLine" Width="137px" Height="17pt" MaxLength="8"></asp:TextBox>
                    </div>
                    <asp:UpdatePanel ID="sexPanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div id="man">
                                <asp:ImageButton ID="manButton" runat="server" ImageUrl="~/CSS/HomePage/personalInformation/sex_05.png" OnClick="manButton_Click" />
                            </div>
                            <div id="woman">
                                <asp:ImageButton ID="womanButton" runat="server" ImageUrl="~/CSS/HomePage/personalInformation/sex2_03.png" OnClick="womanButton_Click" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div id="mySchool">
                        <asp:TextBox ID="MySchool" CssClass="myTextBox" runat="server" Style="background-color: transparent; border-width: 0px; outline: none" Font-Size="13pt" ForeColor="White" Font-Names="微软雅黑" TextMode="SingleLine" Width="137px" Height="17pt" MaxLength="8"></asp:TextBox>
                    </div>
                    <div id="myDepartment">
                        <asp:TextBox ID="MyDepartment" CssClass="myTextBox" runat="server" Style="background-color: transparent; border-width: 0px; outline: none" Font-Size="13pt" ForeColor="White" Font-Names="微软雅黑" TextMode="SingleLine" Width="137px" Height="17pt" MaxLength="8"></asp:TextBox>
                    </div>
                </div>
                <div id="save">
                    <asp:ImageButton ID="SaveButton" runat="server" ImageUrl="~/CSS/HomePage/personalInformation/button.png" OnClick="SaveButton_Click" />
                </div>
                <div id="changePassword">
                    <asp:ImageButton ID="ChangePasswordButton" runat="server" ImageUrl="~/CSS/HomePage/personalInformation/button.png" OnClick="ChangePasswordButton_Click" />
                </div>
            </div>
            <div class="popupbox" id="popuprel">
                <div id="intabdiv">
                    <!--BitmapCutter布局-->
                    <style type="text/css">
                        #container
                        {
                            width: 500px;
                            height: 500px;
                            margin: 50px auto;
                            border: solid 1px #7d9edb;
                            padding: 5px;
                        }
                    </style>
                    <div id="fileQueue"></div>
                    <div id="filebutton">
                        <input type="file" name="uploadify" id="uploadify" />
                        <asp:Button ID="Button1" runat="server" Text="退出" OnClick="Button1_Click" />
                        <div>
                            <p>
                                <a href="javascript:$('#uploadify').uploadifyUpload()">上传</a>
                                <a href="javascript:$('#uploadify').uploadifyClearQueue()">取消上传</a>
                            </p>
                        </div>
                    </div>
                    
                    <!--BitmapCutter-->
                    <div id="container"></div>
                   
                </div>
            </div>
        </div>

    </form>
</body>
</html>
