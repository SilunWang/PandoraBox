<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Information.ascx.cs" Inherits="Pages_Information" %>
<%@ Register Src="Response.ascx" TagName="Response" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Pages/Response.ascx" TagPrefix="uc2" TagName="Response" %>
<%@ Register Src="~/Pages/Enclosure.ascx" TagPrefix="uc1" TagName="Enclosure" %>


<link href="../CSS/Information.css" rel="stylesheet" />
<script type="text/javascript"
        src="../JS/jquery.uploadify/jquery-1.3.2.min.js"></script>
<script>
    $(document).ready(function () {
        $('#Myattachment').click(function () {
            
        });
    });
    </script>
<div id="contents">
    <div id="mainBody">
        <div id="MyheadImage">
            <asp:Image ID="Image1" CssClass ="MyPicture" runat="server" ImageUrl="~/CSS/HomePage/Information/InformationHead.png" />
        </div>
                <div id="addConcern">
            <asp:UpdatePanel ID="concernPanel" runat="server">
                <ContentTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/CSS/HomePage/Information/addConcern.png" OnClick="ImageButton1_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="other">
            <div id="informationPart">
                <div id="delete">
                    <asp:ImageButton ID="DeleteButton" runat="server" ImageUrl="~/CSS/HomePage/Information/deleteButton_03.png" OnClick="DeleteButton_Click" />
                </div>
                <div id ="approve">
                    <asp:ImageButton ID="ApproveButton" runat="server" ImageUrl="~/CSS/HomePage/Information/approveButton.png" OnClick="ApproveButton_Click" />
                </div>
                <div id="InnerPart">
                    <div id="text">
                        <asp:Label ID="TextContent" CssClass ="Information_text" runat="server" Font-Names="微软雅黑" Font-Size="13pt" ForeColor="#AFAFAF" Text="洪大神喜欢哈哈" Font-Bold="False"></asp:Label>
                    </div>
                    <div id="picture" >
                        <asp:Image ID="Picture" CssClass="MyPicture" runat="server" />
                    </div>
                    <div id="MyAttachment">
                            <asp:Panel ID="Myattachment" runat="server">

                            </asp:Panel>
                    </div>
                    <div id="secondOther">
                        <asp:UpdatePanel ID="upAndDownPanel" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div id="time">
                                    <asp:Label ID="InformationTime" runat="server" Font-Names="微软雅黑" Font-Size="10pt" ForeColor="#AFAFAF" Text="2013/7/10 5:15"></asp:Label>
                                </div>
                                <div class="small_item">
                                    <asp:ImageButton ID="ToCollect" runat="server" ImageUrl="~/CSS/HomePage/Information/button_style2_11.png" OnClick="ToCollect_Click" />
                                </div>
                                <div class="number">
                                    <asp:Label ID="NumOfDown" runat="server" Font-Names="微软雅黑" Font-Size="10pt" ForeColor="#AFAFAF" Text="6"></asp:Label>
                                </div>
                                <div class="small_item">
                                    <asp:ImageButton ID="ToDown" runat="server" ImageUrl="~/CSS/HomePage/Information/button_style2_09.png" OnClick="ToDown_Click" />
                                </div>

                                <div class="number">
                                    <asp:Label ID="NumOfUp" runat="server" Font-Names="微软雅黑" Font-Size="10pt" ForeColor="#AFAFAF" Text="10"></asp:Label>
                                </div>
                                <div class="small_item">
                                    <asp:ImageButton ID="ToUp" runat="server" ImageUrl="~/CSS/HomePage/Information/button_style2_07.png" OnClick="ToUp_Click" />
                                </div>

                                <div class="small_item">
                                    <asp:ImageButton ID="ToReport" runat="server" ImageUrl="~/CSS/HomePage/Information/button_style2_05.png" OnClick="ToReport_Click" />
                                </div>
                                <div class="small_item">
                                    <asp:ImageButton ID="ToConfine" runat="server" ImageUrl="~/CSS/HomePage/Information/button_style2_03.png" OnClick="ToConfine_Click" />
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <div id="expand">
                <div class="align">
                    <asp:ImageButton ID="Expand" runat="server" ImageUrl="~/CSS/HomePage/Information/expand.png" OnClick="Expand_Click" />
                </div>
            </div>
            <div id="responsesPart">
                <asp:UpdatePanel ID="responsePanel" runat="server" UpdateMode="Conditional">
                </asp:UpdatePanel>
            </div>
            <div id="tempInput">
                <asp:ImageButton ID="TempInput" runat="server" ImageUrl="~/CSS/HomePage/Information/comment.png" OnClick="TempInput_Click" />
            </div>
            <div>
                <div id="a" runat="server">
                    <div id="newResponse">
                        <div id="yourImage">
                            <asp:Image ID="YourImage" CssClass="MyPicture" runat="server" ImageUrl="~/CSS/HomePage/Response/RespondImage.png" />
                        </div>
                        <div id="responseInput">
                            <div id="TextInput">
                                <asp:TextBox ID="InputBox" CssClass="inputBox" runat="server" Style="background-color: transparent; border-width: 0px; outline: none" Font-Size="13pt" ForeColor="White" Font-Names="微软雅黑" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div id="inputBoxother">
                                <div id="responseButton">
                                    <asp:UpdatePanel ID="responseButtonPanel" runat="server">
                                        <ContentTemplate>
                                    <asp:ImageButton ID="PublishResponse" runat="server" ImageUrl="~/CSS/HomePage/Information/button_style2_27.png" OnClick="PublishResponse_Click" />
                                       </ContentTemplate>
                                             </asp:UpdatePanel>
                                </div>
                                <div id="numOfText">
                                    <asp:Label ID="Label3" runat="server" Text="0/140个字" Font-Size="10pt" Font-Names="黑体" ForeColor="White"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<br />
