<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Assessment.ascx.cs" Inherits="Pages_Assessment" %>
<link href="../CSS/Assessment.css" rel="stylesheet" />
<div id="assessment">
    <div id="introduction">
        <div id="one">
            <div id="Name">
                <asp:Label CssClass="IntroductionText" ID="Course" runat="server" Text="课 程 名：微积分，Caculus" Font-Size="14pt" Font-Names="微软雅黑" ForeColor="White"></asp:Label>
            </div>
        </div>
        <br />
        <div id="two">
            <div id="Teacher">
                <asp:Label ID="CourseTeacher" CssClass="IntroductionText" runat="server" Text="课程教师：姚家燕" Font-Size="14pt" Font-Names="微软雅黑" ForeColor="White"></asp:Label>
            </div>
            <div id="isExamal">
                <asp:Label ID="CourseIsExam" CssClass="IntroductionText" runat="server" Text="考察方式：" Font-Size="14pt" Font-Names="微软雅黑" ForeColor="White"></asp:Label>
            </div>
        </div>
    </div>
    <br />
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div id="grades">
                <div class="Text">
                    <asp:Label ID="Grades" runat="server" Text="评分：" Font-Size="14pt" Font-Names="微软雅黑" ForeColor="White"></asp:Label>
                </div>
                <span class="star">
                    <asp:Image ID="grade_star_1" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" />
                </span>
                <span class="star">
                    <asp:Image ID="grade_star_2" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" />
                </span>
                <span class="star">
                    <asp:Image ID="grade_star_3" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" />
                </span>
                <span class="star">
                    <asp:Image ID="grade_star_4" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" />
                </span>
                <span class="star">
                    <asp:Image ID="grade_star_5" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" />
                </span>
                <span class="Text2">
                    <asp:Label ID="YourGrades" runat="server" Text="您的评分：" Font-Size="14pt" Font-Names="微软雅黑" ForeColor="White"></asp:Label>
                </span>
                <span class="star2">
                    <asp:ImageButton ID="your_grade_star_1" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" OnClick="your_grade_star_1_Click" />
                </span>
                <span class="star2">
                    <asp:ImageButton ID="your_grade_star_2" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" OnClick="your_grade_star_2_Click"  />
                </span>
                <span class="star2">
                    <asp:ImageButton ID="your_grade_star_3" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" OnClick="your_grade_star_3_Click" />
                </span>
                <span class="star2">
                    <asp:ImageButton ID="your_grade_star_4" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" OnClick="your_grade_star_4_Click" />
                </span>
                <span class="star2">
                    <asp:ImageButton ID="your_grade_star_5" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" OnClick="your_grade_star_5_Click" />
                </span>
            </div>
            <br />
            <div id="difficulty">
                <span class="Text">
                    <asp:Label ID="Difficulty" runat="server" Text="难度：" Font-Size="14pt" Font-Names="微软雅黑" ForeColor="White"></asp:Label>
                </span>
                <span class="star">
                    <asp:Image ID="difficulty_star_1" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" />
                </span>
                <span class="star">
                    <asp:Image ID="difficulty_star_2" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" />
                </span>
                <span class="star">
                    <asp:Image ID="difficulty_star_3" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" />
                </span>
                <span class="star">
                    <asp:Image ID="difficulty_star_4" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" />
                </span>
                <span class="star">
                    <asp:Image ID="difficulty_star_5" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" />
                </span>
                <span class="Text2">
                    <asp:Label ID="YourDifficulty" runat="server" Text="您的评价：" Font-Size="14pt" Font-Names="微软雅黑" ForeColor="White"></asp:Label>
                </span>
                <span class="star2">
                    <asp:ImageButton ID="your_difficulty_star_1" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" OnClick="your_difficulty_star_1_Click" />
                </span>
                <span class="star2" id="Span2">
                    <asp:ImageButton ID="your_difficulty_star_2" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" OnClick="your_difficulty_star_2_Click" />
                </span>
                <span class="star2">
                    <asp:ImageButton ID="your_difficulty_star_3" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" OnClick="your_difficulty_star_3_Click" />
                </span>
                <span class="star2">
                    <asp:ImageButton ID="your_difficulty_star_4" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" OnClick="your_difficulty_star_4_Click" />
                </span>
                <span class="star2">
                    <asp:ImageButton ID="your_difficulty_star_5" runat="server" ImageUrl="~/CSS/HomePage/Assessment/big_star_1.png" OnClick="your_difficulty_star_5_Click"  />
                </span>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
