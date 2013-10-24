<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uploadFile.ascx.cs" Inherits="Pages_uploadFile" %>

<!--Uploadify-->
<link href="../JS/jquery.uploadify/example/css/default.css" rel="stylesheet" type="text/css" />
<link href="../JS/jquery.uploadify/uploadify.css" rel="stylesheet" type="text/css" />
<link href="../CSS/uploadFile.css" rel="stylesheet" type="text/css" />
<!--注：此处必须使用jquery-1.3.2.min版本才能正常使用-->
<script type="text/javascript"
    src="../JS/jquery.uploadify/jquery-1.3.2.min.js"></script>
<!--Uplodify-->
<script type="text/javascript"
    src="../JS/jquery.uploadify/swfobject.js"></script>
<script type="text/javascript"
    src="../JS/jquery.uploadify/jquery.uploadify.v2.1.0.min.js"></script>
<!--Uplodify 千万不要随意更改路径-->
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

            }
        });
    });
</script>
<!--Uplodify-->
<div id="fileQueue">
    <div>
                <asp:ImageButton runat="server" CssClass="cancelbt" ImageUrl="~/Resource/Image/cancel.png" OnClick="Unnamed1_Click" />
    </div>
                <input type="file" name="uploadify" id="uploadify" />
                <p>
                    <a href="javascript:$('#uploadify').uploadifyUpload()">上传</a>| 
                    <a href="javascript:$('#uploadify').uploadifyClearQueue()">取消上传</a>
                </p>

</div>
