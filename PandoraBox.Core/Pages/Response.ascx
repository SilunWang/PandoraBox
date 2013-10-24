<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Response.ascx.cs" Inherits="Pages_Response" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<link href="../CSS/response.css" rel="stylesheet" />
<div id="ResponsePart">
    <div id="ReheadImage">
        <asp:Image ID="Image1" runat="server" CssClass ="MyPicture" ImageUrl="~/CSS/HomePage/Response/Responsehead_03.png" />
    </div>
    <div id="Reother">
        <div id="Retext">
            <asp:Label ID="Label3" runat="server" Font-Names="黑体" Font-Size="11pt" ForeColor="#AFAFAF" Text="  洪大神明明喜欢呵呵"></asp:Label>
        </div>
        <div id="ResecondOther">
            <div id="Retime">
                <asp:Label ID="Label2" runat="server" Font-Names="微软雅黑" Font-Size="9pt" ForeColor="#AFAFAF" Text="2013/7/11 10:25"></asp:Label>
            </div>
            <div id="ReresponseButton">
                <asp:ImageButton ID="asp_responseButton" runat="server" ImageUrl="~/CSS/HomePage/Information/button_style2_23.png" OnClick="asp_responseButton_Click" />
            </div>
        </div>
    </div>
</div>
