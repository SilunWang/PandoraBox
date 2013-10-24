using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using PandoraBox.AppCode;
using System.IO;

public partial class Pages_PersonalInformation : System.Web.UI.Page
{
    string image_name;
    protected void Page_Load(object sender, EventArgs e)
    {
        //检查是否是回调
        if (IsPostBack)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "warning22",
                "<script>$(document).ready(function(){$(\"#MyHeadImg\").attr(\"src\", \"" + image_name + "\");});</script>");
            return;
        }
        //检查登录状态
        if (Session["isLogin"] == null || (bool)Session["isLogin"] != true)
            Response.Redirect("~/Pages/login.aspx");
        //获得当前用户信息
        string userID = Session["userID"] as string;
        AppUser user = AppUserManage.getUser(userID);
        MyName.Text = user.Name;
        MySchool.Text = user.School;
        MyDepartment.Text = user.Department;
        image_name = user.UserImagePath;
        this.MyHeadImage.ImageUrl = user.UserImagePath;
        if (user.Gender == AppUserGender.male)
        {
            manButton.ImageUrl = "~/CSS/HomePage/personalInformation/sex_05.png";
            womanButton.ImageUrl = "~/CSS/HomePage/personalInformation/sex2_03.png";
        }
        else if (user.Gender == AppUserGender.female)
        {
            this.womanButton.ImageUrl = "~/CSS/HomePage/personalInformation/sex_03.png";
            this.manButton.ImageUrl = "~/CSS/HomePage/personalInformation/sex2_05.png";
        }
        else
        {
            this.womanButton.ImageUrl = "~/CSS/HomePage/personalInformation/sex2_03.png";
            this.manButton.ImageUrl = "~/CSS/HomePage/personalInformation/sex2_05.png";
        }
    }
    protected void SaveButton_Click(object sender, ImageClickEventArgs e)
    {
        FileStream filest = new FileStream(@"D:\imagename.txt", FileMode.Open, FileAccess.ReadWrite);
        StreamReader sr = new StreamReader(filest);
        image_name = "../" + sr.ReadLine();
        sr.Close();
        if (File.Exists(@"D:\imagename.txt"))
        {
            //如果存在则删除
            File.Delete(@"D:\imagename.txt");
        }
        FileStream fs = new FileStream("D://imagename.txt", FileMode.CreateNew);
        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine("../CSS/backgrounds/pandora.png");
        sw.Close();//写入
        string userID = Session["userID"] as string;
        AppUserGender gender;
        if (this.manButton.ImageUrl == "~/CSS/HomePage/personalInformation/sex_05.png")
            gender = AppUserGender.male;
        else
            gender = AppUserGender.female;
        bool succeed = AppUserManage.userInfoUpdate(userID, MyName.Text, gender, MySchool.Text, MyDepartment.Text, image_name);
        if (succeed)
        {
            infoLabel.Text = "修改成功！1秒后跳转";
            ClientScript.RegisterStartupScript(this.GetType(), "warning",
                "<script>$(document).ready(function(){$(\"#warnningDialog\").show();});</script>"
            + "<script>var the_timeout; the_timeout = setTimeout(\"Refresh();\",1000); function Refresh(){window.location.href=\"HomePage.aspx\";}</script>");

        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "warning3",
                "<script>alert(\"修改失败\");</script>");
            return;
        }
    }
    protected void ChangePasswordButton_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ChangePW.aspx");
    }
    protected void manButton_Click(object sender, ImageClickEventArgs e)
    {
        this.manButton.ImageUrl = "~/CSS/HomePage/personalInformation/sex_05.png";
        this.womanButton.ImageUrl = "~/CSS/HomePage/personalInformation/sex2_03.png";
    }
    protected void womanButton_Click(object sender, ImageClickEventArgs e)
    {
        this.womanButton.ImageUrl = "~/CSS/HomePage/personalInformation/sex_03.png";
        this.manButton.ImageUrl = "~/CSS/HomePage/personalInformation/sex2_05.png";
    }
    protected void ImageBorder_Click(object sender, ImageClickEventArgs e)
    {

    }

    [WebMethod]
    public static void setImage()
    {
        
    }
    protected void gerenzhuye_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("MyHomepage.aspx");
    }
    protected void gerenxinxi_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("PersonalInformation.aspx");
    }
    protected void huifutixing_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ResponseInform.aspx");
    }
    protected void xinxianshi_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("HomePage.aspx");
    }
    protected void haoyouguanli_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Pages/FriendsManagement.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
}