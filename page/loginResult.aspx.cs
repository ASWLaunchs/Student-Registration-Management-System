using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using Microsoft.VisualBasic;
using System.Windows.Forms;

public partial class page_Default : System.Web.UI.Page
{

    //全局变量
    string userId = "";//用户ID
    string passwd = "";//用户密码


    //Getconnection()
    //作用：根据 OleDb 规则指定相应数据库，并返回一个可创建的连接对象
    public OleDbConnection Getconnection()
    {
        string strConnection = System.Configuration.ConfigurationManager.AppSettings["CONN"].ToString() + System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["dbpath"] + ";");
        OleDbConnection conn = new OleDbConnection(strConnection);
        return conn;
    }

    //LoginVerify() 
    //作用： 通过将 学生登录页面通过POST方式传来的数据 和 数据库相应数据进行对比验证用户是否存在
    //如果用户存在则返回用户密码，否则返回空密码
    protected string LoginVerify(string userId)
    {
        //第一步：建立新的数据连接对象
        OleDbConnection conn = Getconnection();
        //第二步：这里写入你需要执行的SQL语句
        string sql = "select * from student_info where ID_Student= '" + userId + "'";
        //第三步：执行数据库命令传送 且 返回一个处理结果对象
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        //第四步：打开conn对象建立数据库连接
        conn.Open();
        //第五步：定义一个数据读取对象 reader
        OleDbDataReader reader = cmd.ExecuteReader();
        //第六步：一直读取执行信息，如果读取成功，则打印；反之，如果读取不到信息，表示没有数据记录
        while (reader.Read())
        {
            //读取到的数据是用数组形式呈现的，如果你读取的数据只有一个参数数据，则写下标[0]，多个则依次累加[1],[2]....即可
            passwd = reader[18].ToString();
        }
        //第七步：Dispose()用于释放SQL执行连接的资源
        reader.Dispose();
        cmd.Dispose();
        //第八步：每次执行完数据库连接后使用Close()关闭该数据库连接
        conn.Close();
        return passwd;
    }

    //Page_Load() 
    //作用：该函数为C#自带函数，用于在页面加载时成功响应服务端通讯，可在函数体内写相应代码处理Web业务
    protected void Page_Load(object sender, EventArgs e)
    {
        //安全验证，如果登录者不是从登录界面通过POST提交信息，将视为非法登录
        if (Request.RequestType != "POST")
        {
            Response.Write("非法登录，参数错误");
        }
        else
        {
            //根据userid在数据库查找后返回相应的密码值
            passwd = LoginVerify(Request.Form["userid"]);
            //本页面接收到来自Default.aspx的信息，userid和passwd信息分别为用户提交的身份证号和密码
            //此处判断前端表单传来的用户密码是否和LoginVerify()函数获取到的后端数据库密码一致
            //成功则跳转至用户界面
            //否则，宣告登录失败
            if (passwd == Request.Form["passwd"])
            {
                //将用户UID存入Session缓存方便后面personalPage页面查询信息
                Session["UID"]= Request.Form["userid"];
                Response.Redirect("./personalPage.aspx", false);
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('未匹配到用户名或密码，请重新输入')</script>");
                Response.Redirect("./loginResult.aspx", false);
            }
        }
    }
}