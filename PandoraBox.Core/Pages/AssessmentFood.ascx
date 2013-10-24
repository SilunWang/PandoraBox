<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AssessmentFood.ascx.cs" Inherits="Pages_AssessmentFood" %>
<link href="../CSS/AssessmentFood.css" rel="stylesheet"/>
<div id ="food_assessment">
<div id="food_introduction">
    <div id ="food_one">
    <span id="food_name">
        <asp:Label ID="Food_name" CssClass ="food_Text" runat="server" Text="菜 名：鱼香肉丝" Font-Size="16pt" Font-Names="微软雅黑" ForeColor="White"></asp:Label>
    </span>
    <span id="cantin">
        <asp:Label ID="Cantin" runat="server" CssClass ="food_Text"  Text="紫荆园1楼1号窗口" Font-Size="16pt" Font-Names="微软雅黑" ForeColor="White" ></asp:Label>
    </span>
    </div>
    <br />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

    <div id="food_grades">
        <span class="food_Text">
            <asp:Label ID="food_grade_text" runat="server" Text="大众评分：" Font-Size="15pt" Font-Names="微软雅黑" ForeColor="White"></asp:Label>
        </span>
        <span class="star">
            <asp:Image ID="food_grade_star_1" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" />
        </span>
        <span class="star">
            <asp:Image ID="food_grade_star_2" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" />
        </span>
        <span class="star">
            <asp:Image ID="food_grade_star_3" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" />
        </span>
        <span class="star">
            <asp:Image ID="food_grade_star_4" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" />
        </span>
        <span class="star">
            <asp:Image ID="food_grade_star_5" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_5.png" />
        </span>
    </div>
    <div id="your_food_grades">
        <span class="food_Text">
            <asp:Label ID="your_food_grade_text" runat="server" Text="您的评分：" Font-Size="15pt" Font-Names="微软雅黑" ForeColor="White"></asp:Label>
        </span>
        <span class="star">
            <asp:ImageButton ID="your_food_grade_star_1" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" OnClick="your_food_grade_star_1_Click" />
        </span>
        <span class="star">
            <asp:ImageButton ID="your_food_grade_star_2" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" OnClick="your_food_grade_star_2_Click" />
        </span>
        <span class="star">
            <asp:ImageButton ID="your_food_grade_star_3" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" OnClick="your_food_grade_star_3_Click" />
        </span>
        <span class="star">
            <asp:ImageButton ID="your_food_grade_star_4" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" OnClick="your_food_grade_star_4_Click" />
        </span>
        <span class="star">
            <asp:ImageButton ID="your_food_grade_star_5" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" OnClick="your_food_grade_star_5_Click" />
        </span>
    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</div>
</div>