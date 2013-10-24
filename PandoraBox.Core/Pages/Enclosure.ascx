<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Enclosure.ascx.cs" Inherits="Pages_Enclosure" %>
<link href="../CSS/Enclosure.css" rel="stylesheet" />
<script type="text/javascript"
        src="../JS/jquery.uploadify/jquery-1.3.2.min.js"></script>
<script>
    $(document).ready(function () {
        
    });
    </script>
<div id="enclosure_icon">
    <asp:Image ID="EnclosureIcon" runat="server" ImageUrl="~/CSS/HomePage/Information/attachment_03.png" />
</div>
<div id="enclosure_text">
    <asp:HyperLink ID="EnclosureText" runat="server" Font-Names="幼圆" Font-Size="12pt" ForeColor="White">HyperLink</asp:HyperLink>
</div>
