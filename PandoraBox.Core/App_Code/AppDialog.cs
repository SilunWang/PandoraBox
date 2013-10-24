using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

/// <summary>
/// AppDialog 的摘要说明
/// </summary>
public class AppDialog
{
    private string user1ID;
    private string user2ID;
    private int dialogID;
    private string contents;
    private DateTime time;
    private static AppDataBase data = new AppDataBase();


    public int DialogID
    {
        get { return dialogID; }
        set { dialogID = value; }
    }

    public string User1ID
    {
        get { return user1ID; }
        set { user1ID = value; }
    }

    public string User2ID
    {
        get { return user2ID; }
        set { user2ID = value; }
    }

    public string Contents
    {
        get { return contents; }
        set { contents = value; }
    }

    public DateTime Time
    {
        get { return time; }
        set { time = value; }
    }

    public bool insertDialog()
    {
        string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
         SqlParameter[] prams = {
                data.MakeInParam("@user1ID", SqlDbType.NVarChar, 50, user1ID),
                data.MakeInParam("@user2ID", SqlDbType.NVarChar, 50, user2ID),
                data.MakeInParam("@contents", SqlDbType.NVarChar, 400, contents),
                data.MakeInParam("@time", SqlDbType.DateTime, 0, time)
                };
        int result = data.RunProc("INSERT INTO dialog (user1ID,user2ID,contents,time) VALUES(@user1ID,@user2ID,@contents,@time)", prams);
        data.Close();
        if (result == 0)
           return true;
        else
            return false;
    }

    public bool deleteDialog(int dialogID)
    {
        string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        SqlParameter[] prams = {
                data.MakeInParam("@dialogID", SqlDbType.Int, 0, dialogID)
            };
        int result = data.RunProc("DELETE FROM dialog WHERE dialogID = @dialogID", prams);
        data.Close();
        if (result == 0)
            return true;
        else
            return false;
    }

	public AppDialog(string user1, string user2, string content)
	{
        this.user1ID = user1;
        this.user2ID = user2;
        this.contents = content;
	}
}