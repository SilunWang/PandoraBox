using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandoraBox.AppCode
{

    /// <summary>
    /// 用户的权限
    /// </summary>
    public enum AppUserAuthority
    {
        administrator,
        normal,
        limited
    }

    /// <summary>
    /// 用户的性别
    /// </summary>
    public enum AppUserGender
    {
        male,
        female
    }

    /// <summary>
    /// 评价的种类
    /// </summary>
    public enum AppEvaluationType
    {
        teacher,
        food,
        none
    }

    /// <summary>
    /// 排序的方法
    /// </summary>
    public enum AppSortType
    {
        timeAscending,
        timeDescending,
        hot,
        relevance
    }

    /// <summary>
    /// 描述用户在个人主页上是处于个人发布态还是个人收藏态
    /// </summary>
    public enum AppPersonalPageStatus
    {
        publish,
        collection
    }
}