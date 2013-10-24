<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="Pages_HomePage" %>

<%@ Register Src="Information.ascx" TagName="Information" TagPrefix="uc1" %>

<%@ Register Src="Response.ascx" TagName="Response" TagPrefix="uc2" %>

<%@ Register Src="Assessment.ascx" TagName="Assessment" TagPrefix="uc3" %>
<%@ Register Src="~/Pages/chatbox.ascx" TagPrefix="uc1" TagName="chatbox" %>
<%@ Register Src="~/Pages/uploadFile.ascx" TagPrefix="uc1" TagName="uploadFile" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>PandoraBox</title>
    <link href="../CSS/Homepage.css" rel="stylesheet" />
    <script type="text/javascript"
        src="../JS/jquery.uploadify/jquery-1.3.2.min.js"></script>
    <script src="jquery.ez-bg-resize.js"></script>
    <script src="../JS/imgFit.js"></script>
    <script>
        $(document).ready(function () {
            $('#UploadPicture').click(function () {
                $('#MyUpload').show();
            });
            $('#ImageCancel').click(function () {
                $('#MyUpload').hide();
                
            });
        });
    </script>
    <script type="text/javascript">
        function BtnClick(obj) {
            if (event.keyCode == 13) {
                if (obj == document.all.SearchInputBox) {
                    document.all.SearchButton.click();
                }
            }
        }
          </script>   
    <script>
        window.onload = function () { Init(); }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        <div class="background">
            <img src="../CSS/HomePage/HomePageBack/myBackground.jpg" />
        </div>
        <div id="stateColumn">
            <div id="Module_newThings" class="menuItem">
                <asp:ImageButton ID="xinxianshi" runat="server" ImageUrl="~/CSS/HomePage/menu/menu_style_2_1.png" OnClick="xinxianshi_Click" />
            </div>
            <div id="Module_personalThings" class="menuItem">
                <asp:ImageButton ID="gerenzhuye" runat="server" ImageUrl="~/CSS/HomePage/menu/menu_style_1_2.png" OnClick="gerenzhuye_Click" />
            </div>
            <div id="Module_personalInfomation" class="menuItem">
                <asp:ImageButton ID="gerenxinxi" runat="server" ImageUrl="~/CSS/HomePage/menu/menu_style_1_3.png" OnClick="gerenxinxi_Click1" />
            </div>
            <div id="Module_responseInform" class="menuItem">
                <asp:ImageButton ID="huifutixing" runat="server" ImageUrl="~/CSS/HomePage/menu/menu_style_1_4.png" OnClick="huifutixing_Click" />
            </div>
            <div id="Module_responseFriends" class="menuItem">
                <asp:ImageButton ID="haoyouguanli" runat="server" ImageUrl="~/CSS/HomePage/menu/menu_style_1_5.png" OnClick="haoyouguanli_Click" />
            </div>
        </div>
        <div id="mainPart">
            <div id="MyBackGround">
            </div>
            <div id="banner">
                <asp:UpdatePanel ID="SearchPanel" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <div id="searchInput">
                            <asp:TextBox ID="SearchInputBox" CssClass="search_text" runat="server" Style="background-color: transparent; border-width: 0px; outline: none" Font-Size="18pt" ForeColor="White" Font-Names="微软雅黑" TextMode="SingleLine"></asp:TextBox>
                        </div>
                        <div id="search">
                            <asp:ImageButton ID="SearchButton" runat="server" ImageUrl="~/CSS/HomePage/banner/search.png" OnClick="SearchButton_Click" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div id="logout">
                    <asp:ImageButton ID="LogOut" runat="server" ImageUrl="~/CSS/HomePage/banner/logOut_03.png" OnClick="LogOut_Click" />
                </div>
                <div id="headImg">
                    <asp:Image ID="HeadImg" CssClass="HHH" runat="server" ImageUrl="~/Resource/Image/headImage.png" Width="135px" />
                </div>
                <div id="headBorder">
                    <asp:Image ID="HeadBorder" runat="server" ImageUrl="~/CSS/HomePage/banner/headImageBorder_03.png" />
                </div>

                <div id="sortStandard">
                    <asp:UpdatePanel ID="sortTypePanel" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <div id="sortStandard_1">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/CSS/HomePage/sort/sort_hot.png" OnClick="ImageButton1_Click" />
                            </div>
                            <div id="sortStandard_2">
                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/CSS/HomePage/sort/sort_time.png" OnClick="ImageButton2_Click" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div id="chatroom">
                        <asp:ImageButton ID="ChatRoom" runat="server" ImageUrl="~/CSS/HomePage/sort/chatroom.png" OnClick="ChatRoom_Click" />
                    </div>
                </div>
            </div>
            <div id="belowBanner">
                <div id="firstModule">
                    <asp:UpdatePanel ID="currentTagPanel" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <div id="tagText">
                                <asp:Label ID="TagText" runat="server" Text="标 签：所 有" ForeColor="#B6B6B6" Font-Size="14pt" Font-Names="微软雅黑"></asp:Label>
                            </div>
                            <div id="nameOfModule">
                                <span id="tag">
                                    <asp:Image ID="Tag" runat="server" ImageUrl="~/CSS/HomePage/publish/Tag.png" />
                                </span>
                                <span id="return">
                                    <asp:ImageButton ID="ReturnButton" runat="server" ImageUrl="~/CSS/HomePage/publish/Return.png" OnClick="ReturnButton_Click" />
                                </span>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div id="publishNews">
                        <asp:UpdatePanel ID="publishPanel" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div id="NewThings">
                                    <div id="TextNews">
                                        <asp:Image ID="BoxImage" runat="server" ImageUrl="~/CSS/HomePage/publish/TextBox.png" />
                                        <div id="publishBox">
                                            <asp:TextBox ID="TextBox1" CssClass="publishText" runat="server" Style="background-color: transparent; border-width: 0px; outline: none" Font-Size="13pt" ForeColor="White" Font-Names="微软雅黑" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="upLoadPicture">
                                        <asp:ImageButton ID="UploadPicture" runat="server" ImageUrl="~/CSS/HomePage/publish/fileButton.png" />
                                    </div>
                                    <div id="publish">
                                        <asp:ImageButton ID="PublishButton" runat="server" ImageUrl="~/CSS/HomePage/publish/publishButton.png" OnClick="PublishButton_Click" />
                                    </div>
                                     <div id ="fileInform">
                                         <asp:Image ID="FileInform" runat="server" ImageUrl="~/CSS/HomePage/publish/fileInform.png" />
                                     </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>


                </div>
                <div id="secondModule">
                    <div id="listOfSubModule">
                        <asp:UpdatePanel ID="directorPanel" runat="server" UpdateMode="Always">
                            <ContentTemplate>
                                <div id="director_background">
                                    <asp:Image ID="director" runat="server" ImageUrl="~/CSS/HomePage/banner/director.png" />
                                </div>
                                <div id="leftButton">
                                    <asp:ImageButton ID="LeftButton" runat="server" ImageUrl="~/CSS/HomePage/category/director_1.png" OnClick="LeftButton_Click" />
                                </div>
                                <div id="directorText_01">
                                    <asp:Label ID="DirectorText1" CssClass="DirectorText" runat="server" Text="微积分" Font-Names="微软雅黑" Font-Size="16pt" ForeColor="#CCCCCC"></asp:Label>
                                </div>
                                <div id="directorText_02">
                                    <asp:Label ID="DirectorText2" CssClass="DirectorText" runat="server" Text="线性代数" Font-Names="微软雅黑" Font-Size="16pt" ForeColor="#CCCCCC"></asp:Label>
                                </div>
                                <div id="directorText_03">
                                    <asp:Label ID="DirectorText3" CssClass="DirectorText" runat="server" Text="离散数学" Font-Names="微软雅黑" Font-Size="16pt" ForeColor="#CCCCCC"></asp:Label>
                                </div>
                                <div id="directorText_04">
                                    <asp:Label ID="DirectorText4" CssClass="DirectorText" runat="server" Text="复变函数" Font-Names="微软雅黑" Font-Size="16pt" ForeColor="#CCCCCC"></asp:Label>
                                </div>
                                <div id="director_01">
                                    <asp:ImageButton ID="Director1" runat="server" ImageUrl="~/CSS/HomePage/category/director_2.png" CssClass="auto-style3" Style="right: 396px" OnClick="Director1_Click" />
                                </div>
                                <div id="director_02">
                                    <asp:ImageButton ID="Director2" runat="server" ImageUrl="~/CSS/HomePage/category/director_2.png" OnClick="Director2_Click" />
                                </div>
                                <div id="director_03">
                                    <asp:ImageButton ID="Director3" runat="server" ImageUrl="~/CSS/HomePage/category/director_2.png" CssClass="auto-style3" OnClick="Director3_Click" />
                                </div>
                                <div id="director_04">
                                    <asp:ImageButton ID="Director4" runat="server" ImageUrl="~/CSS/HomePage/category/director_2.png" CssClass="auto-style4" OnClick="Director4_Click" />
                                </div>
                                <div id="rightButton">
                                    <asp:ImageButton ID="RightButton" runat="server" ImageUrl="~/CSS/HomePage/category/director_1.png" OnClick="RightButton_Click" />
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div id="grade">
                        <asp:UpdatePanel ID="assessment1Panel" runat="server" UpdateMode="Conditional">
                        </asp:UpdatePanel>
                    </div>
                    <div id="events">
                        <asp:UpdatePanel ID="messagePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
                        </asp:UpdatePanel>
                    </div>
                    <asp:UpdatePanel ID="lastAndNext" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <div id="PageChange">
                                <div id="LastPage">
                                    <asp:ImageButton ID="Last" runat="server" ImageUrl="~/CSS/HomePage/Information/begin.png" OnClick="Last_Click" />
                                </div>
                                <div id="NextPage">
                                    <asp:ImageButton ID="Next" runat="server" ImageUrl="~/CSS/HomePage/Information/next.png" OnClick="Next_Click" />
                                </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

        <!--Uploadify-->
        <link href="../JS/jquery.uploadify/example/css/default.css" rel="stylesheet" type="text/css" />
        <link href="../JS/jquery.uploadify/uploadify.css" rel="stylesheet" type="text/css" />
        <link href="../CSS/uploadFile.css" rel="stylesheet" type="text/css" />
        <!--Uplodify-->
        <script type="text/javascript"
            src="../JS/jquery.uploadify/swfobject.js"></script>
        <script type="text/javascript"
            src="../JS/jquery.uploadify/jquery.uploadify.v2.1.0.min.js"></script>
        <script type="text/javascript"
            src="jquery.cookie.js"></script>
        <!--Uplodify 千万不要随意更改路径-->
        <input id="hd" name="hd" type="hidden" runat="server"/>
        <script type="text/javascript">

            $(document).ready(function () {
                $("#uploadify").uploadify({
                    'uploader': '../JS/jquery.uploadify/uploadify.swf',
                    'script': 'UploadHandler.ashx',
                    'cancelImg': '../JS/jquery.uploadify/cancel.png',
                    //存放路径：Pages/UploadFile
                    'folder': 'UploadFile',
                    'queueID': 'fileQueue',
                    'auto': false,
                    'multi': false,
                    'OnUploadStart': function () {
                        $('#uploadify').uploadifyUpload();
                    },
                    'onComplete': function (event, queueID, fileObj, response, data) {
                        //$.ajax({
                        //    type: "post",
                        //    url: "HomePage.aspx/filesubmitClick",
                        //    data: " { 'filePath':'" + fileObj.name + "'}",
                        //    contentType: "application/json; charset=utf-8",
                        //    datatype: "json",
                        //    success: function (message) {
                        //        alert("上传成功！");
                        //        $('#fileInform').show();
                        //        $('#MyUpload').hide();
                                
                        //    }
                        //});
                        $('#fileInform').show();
                        $('#MyUpload').hide();
                        $("#hd").attr("value", fileObj.name);
                    }
                });
            });
        </script>
        <!--Uplodify-->
        <div id="outLoad">
            <div id="MyUpload" runat="server">
                <div id="fileQueue">
                    <div>
                        <asp:Image ID="ImageCancel" runat="server" CssClass="cancelbt" ImageUrl="~/Resource/Image/cancel.png" />
                    </div>
                    <input type="file" name="uploadify" id="uploadify" />
                    <p>
                        <a href="javascript:$('#uploadify').uploadifyUpload()">上传</a>| 
                <a href="javascript:$('#uploadify').uploadifyClearQueue()">取消上传</a>
                    </p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
