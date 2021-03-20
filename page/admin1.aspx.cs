using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Windows.Forms;

public partial class page_admin1 : System.Web.UI.Page
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

    public void Counsoler()
    {
        //第一步：建立新的数据连接对象
        OleDbConnection conn = Getconnection();
        //第二步：这里写入你需要执行的SQL语句
        string sql = "SELECT * FROM student_info";
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
        GridView1.DataKeyNames = new string[] { "ID_Student" };
        GridView1.DataBind();
        //第八步：销毁reader对象
        reader.Dispose();
        //第九步：Dispose()用于释放SQL执行连接的资源
        cmd.Dispose();
        //第十步：每次执行完数据库连接后使用Close()关闭该数据库连接
        conn.Close();
    }

    public void SectionManager()
    {
        //第一步：建立新的数据连接对象
        OleDbConnection conn = Getconnection();
        //第二步：这里写入你需要执行的SQL语句
        string sql = "SELECT * FROM student_info Where  [_SH] = 0 OR [_SH] = 3 and ID_College ='" + Session["ID_College"] + "'";
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
        GridView1.DataKeyNames = new string[] { "ID_Student" };
        GridView1.DataBind();
        //第八步：销毁reader对象
        reader.Dispose();
        //第九步：Dispose()用于释放SQL执行连接的资源
        cmd.Dispose();
        //第十步：每次执行完数据库连接后使用Close()关闭该数据库连接
        conn.Close();
    }
    public void Finance()
    {

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
                Counsoler();
                identityText = "辅导员";
                break;

            //选择科长
            case "sectionManager":
                SectionManager();
                identityText = "科长";
                break;
            //选择财务
            case "finance":
                Finance();
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
        else if (((string)Session["userName"]).Length < 2 || (string)Session["ID_Worker"] == null || (string)Session["ID_Worker"] == "")
        {
            Response.Redirect("./adminLogin.aspx");
        }
        else
        {
            Label1.Text = "<p class=\"text - white mt - 5 mb - 5\">欢迎回来, <b>科长 | " + (string)Session["userName"] + "</b></p>";
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
        Session["identity"] = null;
        HttpContext.Current.Session["ID_Worker"] = null;
        Response.Write("<script>'window.location.href=\"./adminLogin.aspx\"';</script>");
        Response.Redirect("./adminLogin.aspx");
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowEditing(object sender, GridViewUpdatedEventArgs e)
    {
        MessageBox.Show("您已经编辑");
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int sh = 0;
        string id = Convert.ToString(GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
        OleDbConnection conn = Getconnection();
        string sql = "select [_SH] from student_info where ID_Student = '" + id + "'"; //更新数据库的审核功能，设置为1表示审核，设置为0表示为未审核,2表示复核然后传给财务继续复核
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        conn.Open();
        OleDbDataReader reader;
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            sh = Convert.ToInt32(reader[0].ToString());
            //MessageBox.Show(reader[0].ToString());
        }
        reader.Dispose();
        cmd.Dispose();
        conn.Close();

        if (sh == 0)
        {
            OleDbConnection conn1 = Getconnection();
            string sql1 = "update student_info SET _SH = 1 where ID_Student = '" + id + "'"; //更新数据库的审核功能，设置为1表示审核，设置为0表示为未审核,2表示复核然后传给财务继续复核
            OleDbCommand cmd1 = new OleDbCommand(sql1, conn1);
            conn1.Open();
            DialogResult i = MessageBox.Show("您确定要审核该学生吗？", "审核对话框", MessageBoxButtons.OKCancel);
            if (i == DialogResult.OK)
                cmd1.ExecuteNonQuery();
            cmd1.Dispose();
            conn1.Close();
            Response.Redirect("./admin1.aspx");
        }
        else if (sh == 3)
        {
            OleDbConnection conn2 = Getconnection();
            string sql2 = "update student_info SET _SH = 2 where ID_Student = '" + id + "'"; //更新数据库的审核功能，设置为1表示审核，设置为0表示为未审核,2表示复核然后传给财务继续复核
            OleDbCommand cmd2 = new OleDbCommand(sql2, conn2);
            conn2.Open();
            DialogResult i = MessageBox.Show("您确定要复核该学生吗？", "审核对话框", MessageBoxButtons.OKCancel);
            if (i == DialogResult.OK)
                cmd2.ExecuteNonQuery();
            cmd2.Dispose();
            conn2.Close();
            Response.Redirect("./admin1.aspx");
        }

    }
}