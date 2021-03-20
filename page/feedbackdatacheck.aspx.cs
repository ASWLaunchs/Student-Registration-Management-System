using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class page_feedbackdatacheck : System.Web.UI.Page
{
    string uid;
    //Getconnection()
    //作用：根据 OleDb 规则指定相应数据库，并返回一个可创建的连接对象
    public OleDbConnection Getconnection()
    {
        string strConnection = System.Configuration.ConfigurationManager.AppSettings["CONN"].ToString() + System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["dbpath"] + ";");
        OleDbConnection conn = new OleDbConnection(strConnection);
        return conn;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        OleDbConnection conn = Getconnection();
        //第二步：这里写入你需要执行的SQL语句
        string sql = "SELECT * FROM student_info WHERE [_SH] = 2";
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

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "FH")//复核
        {
            uid = Convert.ToString(GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
            OleDbConnection conn = Getconnection();
            string sql = "UPDATE student_info SET _SH=0 , _Modify=1  WHERE ID_Student='" + uid + "'";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Dispose();
            Session["FDYUID"] = uid;
            Response.Redirect("./feedbackdatacheck.aspx");
        }
    }
}