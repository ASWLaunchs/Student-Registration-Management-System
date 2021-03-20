using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Windows.Forms;
using System.Collections;

public partial class page_admin2 : System.Web.UI.Page
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


    public void Finance()
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
        string sql = "SELECT * FROM student_info Where  [_SH] = 0 and ID_College ='" + Session["ID_College"] + "'";
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

    public void SelectClass(string id)
    {
        //第一步：建立新的数据连接对象
        OleDbConnection conn = Getconnection();
        //第二步：这里写入你需要执行的SQL语句
        string sql = "SELECT * FROM student_info WHERE [ID_Class]='" + id + "'";
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


    public void Page_Load(object sender, EventArgs e)
    {
        string identity;//定义操作者的身份

        if (!IsPostBack)
        {
            ArrayList arr = new ArrayList();
            arr.Add("信息技术学院");
            arr.Add("物理工程学院");
            DropDownList1.DataSource = arr;
            DropDownList1.DataBind();
            DropDownList2.Items.Add("请选择");
            DropDownList2.Items.Add("物联网工程");
            DropDownList2.Items.Add("计算机科学与技术");
            DropDownList2.Items.Add("网络工程");
            DropDownList3.Items.Add("请选择");
            DropDownList3.Items.Add("物联网工程");
            DropDownList3.Items.Add("计算机科学与技术");
            DropDownList3.Items.Add("网络工程");
        }

        identity = (string)Session["identity"];  //从session获取身份标识 ， 可能获取到的值 counselor 辅导员 | sectionManager 科长 | finance 财务
        //进行搜索内容的判断，针对不同对象进入执行不不同的函数进入不同的数据库进行搜索
        switch (identity)
        {
            //选择辅导员
            case "counselor":
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
            Label1.Text = "<p class=\"text - white mt - 5 mb - 5\">欢迎回来, <b>财务 | " + (string)Session["userName"] + "</b></p>";
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
        if (e.CommandName == "JF")
        {
            if (TextBox1.Text == "" || TextBox1.Text == null || TextBox1.Text.Length < 2)
            {
                MessageBox.Show("请输入金额");
            }
            else
            {

                long money = 0;
                string id = Convert.ToString(GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
                OleDbConnection conn = Getconnection();
                string sql = "update student_info SET _Pay = True , _Money = " + Convert.ToInt32(TextBox1.Text) + " , _Date ='" + System.DateTime.Now + "' where ID_Student = '" + id + "'"; //更新数据库的审核功能，设置为1表示审核，设置为0表示为未审核
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.Open();
                DialogResult i = MessageBox.Show("您确定要给该学生缴费吗？", "缴费对话框", MessageBoxButtons.OKCancel);
                if (i == DialogResult.OK)
                    cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
            }
        }
        Response.Redirect("./admin2.aspx");
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList2.Items.Clear();
        if (DropDownList1.SelectedValue == "信息技术学院")
        {
            DropDownList2.Items.Add("物联网工程");
            DropDownList2.Items.Add("计算机科学与技术");
            DropDownList2.Items.Add("网络工程");
        }
        else if (DropDownList1.SelectedValue == "物理工程学院")
        {
            DropDownList2.Items.Add("物理教育");
            DropDownList2.Items.Add("工程物理");
        }
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList3.Items.Clear();
        if (DropDownList2.SelectedValue == "物联网工程")
        {
            DropDownList3.Items.Add("18级物联");
            DropDownList3.Items.Add("19级物联");
        }
        else if (DropDownList2.SelectedValue == "计算机科学与技术")
        {
            DropDownList3.Items.Add("18级计本");
            DropDownList3.Items.Add("19级计本");
            DropDownList3.Items.Add("20级计本");
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (DropDownList3.SelectedValue == "18级计本")
        {
            SelectClass("bj1000");
        }
        else if (DropDownList3.SelectedValue == "19级计本")
        {
            SelectClass("bj2000");
        }
    }
}