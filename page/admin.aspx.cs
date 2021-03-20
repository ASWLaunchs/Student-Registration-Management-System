using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Windows.Forms;

public partial class page_admin : System.Web.UI.Page
{
    string identityText;
    //Getconnection()
    //作用：根据 OleDb 规则指定相应数据库，并返回一个可创建的连接对象
    public OleDbConnection Getconnection()
    {
        string strConnection = System.Configuration.ConfigurationManager.AppSettings["CONN"].ToString() + System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["dbpath"] + ";");
        OleDbConnection conn = new OleDbConnection(strConnection);
        return conn;
    }


    public void counsoler()
    {
        //第一步：建立新的数据连接对象
        OleDbConnection conn = Getconnection();
        //第二步：这里写入你需要执行的SQL语句
        string sql = "SELECT * FROM student_info WHERE ID_Student";
        //第三步：执行数据库命令传送 且 返回一个处理结果对象
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        //第四步：打开conn对象建立数据库连接
        conn.Open();
        //第五步：定义一个数据读取对象 reader
        OleDbDataReader reader;
        //第六步：执行sql语句读取数据返回执行结果
        reader = cmd.ExecuteReader();
        //第七步：一直读取执行信息，如果读取成功，则打印；反之，如果读取不到信息，表示没有数据记录
        GridView1.DataSource = reader;
        GridView1.DataBind();
        //第八步：销毁reader对象
        reader.Dispose();
        //第九步：Dispose()用于释放SQL执行连接的资源
        cmd.Dispose();
        //第十步：每次执行完数据库连接后使用Close()关闭该数据库连接
        conn.Close();
    }

    //searchInfo()
    //作用：用于从student_info的数据表中查询信息查询学生信息
    //传入参数：userId 用户ID
    protected void searchInfo(string userId)
    {
        //第一步：建立新的数据连接对象
        OleDbConnection conn = Getconnection();
        //第二步：这里写入你需要执行的SQL语句
        string sql = "SELECT * FROM student_info WHERE ID_Student ='" + userId + "'";
        //第三步：执行数据库命令传送 且 返回一个处理结果对象
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        //第四步：打开conn对象建立数据库连接
        conn.Open();
        //第五步：定义一个数据读取对象 reader
        OleDbDataReader reader;
        //第六步：执行sql语句读取数据返回执行结果
        reader = cmd.ExecuteReader();
        //第七步：一直读取执行信息，如果读取成功，则打印；反之，如果读取不到信息，表示没有数据记录
        while (reader.Read())
        {
            //读取到的数据是用数组形式呈现的，如果你读取的数据只有一个参数数据，则写下标[0]，多个则依次累加[1],[2]....即可
            MessageBox.Show(reader[1].ToString());//打印查询到的数据
        }
        //第八步：销毁reader对象
        reader.Dispose();
        //第九步：Dispose()用于释放SQL执行连接的资源
        cmd.Dispose();
        //第十步：每次执行完数据库连接后使用Close()关闭该数据库连接
        conn.Close();
    }


    public void Page_Load(object sender, EventArgs e)
    {
        string identity;//定义操作者的身份

        identity = (string)Session["identity"];  //从session获取身份标识 ， 可能获取到的值 counselor 辅导员 | sectionManager 科长 | finance 财务
        //进行搜索内容的判断，针对不同对象进入执行不不同的函数进入不同的数据库进行搜索
        switch (identity)
        {
            //选择辅导员
            case "counselor":
                counsoler();
                identityText = "辅导员";
                break;

            //选择科长
            case "sectionManager":

                identityText = "科长";
                break;
            //选择财务
            case "finance":

                identityText = "财务";
                break;
            //默认情况
            default:
                //因为没有得到identity的选择项，向页面发出警告
                Response.Write("<script>alert(\" 您的身份有误，无法使用查询系统 \");window.location.href=\"./adminLogin.aspx\"</script>");
                Response.Redirect("./adminLogin.aspx");
                break;
        }

        if ((string)Session["ID_Worker"] == null || (string)Session["ID_Worker"] == "")
        {
            Response.Write("<script>alert(\" 您的身份有误，无法使用查询系统 \");window.location.href=\"./adminLogin.aspx\"</script>");
            Response.Redirect("./adminLogin.aspx");
        }
        //如果获取到的用户名程度小于2，或者用户的ID是空的，则返回登录界面
        else if (((string)Session["userName"]).Length < 2 || (string)Session["ID_Worker"] == null || (string)Session["ID_Worker"] == "")
        {
            Response.Redirect("./adminLogin.aspx");
        }
        else
        {
            Label1.Text = "<p class=\"text - white mt - 5 mb - 5\">欢迎回来, <b>" + identityText + " | " + (string)Session["userName"] + "</b></p>";
        }
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        //string searchText;
        // searchText = TextBox1.Text;
    }

    //注销
    protected void Button1_Click(object sender, EventArgs e)
    {
        //让Session的身份为空，用户ID为空，然后返回管理员登录界面
        Session["identity"] = null;
        HttpContext.Current.Session["ID_Worker"] = null;
        Response.Write("<script>'window.location.href=\"./adminLogin.aspx\"';</script>");
        Response.Redirect("./adminLogin.aspx");
    }
}