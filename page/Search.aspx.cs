using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Windows.Forms;

public partial class page_Search : System.Web.UI.Page
{
    string ID_Class;
    string ID_College;
    string ID_Major;
    //Getconnection()
    //作用：根据 OleDb 规则指定相应数据库，并返回一个可创建的连接对象
    public OleDbConnection Getconnection()
    {
        string strConnection = System.Configuration.ConfigurationManager.AppSettings["CONN"].ToString() + System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["dbpath"] + ";");
        OleDbConnection conn = new OleDbConnection(strConnection);
        return conn;
    }
    //SearchStudentInfo()
    //作用：用于从student_info的数据表中查询信息查询学生基本信息
    //传入参数：userId 用户ID
    protected void SearchStudentInfo(string userId)
    {
        //第一步：建立新的数据连接对象
        OleDbConnection conn = Getconnection();
        //第二步：这里写入你需要执行的SQL语句
        string sql = "SELECT * FROM student_info  WHERE ID_Student ='" + userId + "'";
        //第三步：执行数据库命令传送 且 返回一个处理结果对象
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        //第四步：打开conn对象建立数据库连接
        conn.Open();
        //第五步：定义一个数据读取对象 reader
        OleDbDataReader reader;
        //第六步：执行sql语句读取数据返回执行结果
        reader = cmd.ExecuteReader();
        //第七步：读取到信息后将数据绑定在GridView组件上
        GridView1.DataSource = reader;
        GridView1.DataBind();
        //第八步：销毁reader对象
        reader.Dispose();
        //第九步：销毁reader对象
        reader.Dispose();
        //第十步：Dispose()用于释放SQL执行连接的资源
        cmd.Dispose();
        //第十一步：每次执行完数据库连接后使用Close()关闭该数据库连接
        conn.Close();
    }

    //SearchStudentInfo1()
    //作用：用于从student_info的数据表中查询信息查询学生班级，学院，专业所属情况
    //传入参数：userId 用户ID
    public void SearchStudentInfo1(string userId)
    {
        //第一步：建立新的数据连接对象
        OleDbConnection conn = Getconnection();
        //第二步：这里写入你需要执行的SQL语句
        string sql = "SELECT ID_Class , ID_College , ID_Major FROM student_info WHERE student_info.ID_Student ='" + userId + "'";
        //第三步：执行数据库命令传送 且 返回一个处理结果对象
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        //第四步：打开conn对象建立数据库连接
        conn.Open();
        //第五步：定义一个数据读取对象 reader
        OleDbDataReader reader;
        //第六步：执行sql语句读取数据返回执行结果
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            //读取到的数据是用数组形式呈现的，如果你读取的数据只有一个参数数据，则写下标[0]，多个则依次累加[1],[2]....即可
            ID_Class = reader[0].ToString();//打印查询到的数据
            ID_Major = reader[2].ToString();//打印查询到的数据
            ID_College = reader[1].ToString();//打印查询到的数据
        }

        //第七步：读取到信息后将数据绑定在GridView组件上
        reader.Dispose();
        //第八步：Dispose()用于释放SQL执行连接的资源
        cmd.Dispose();
        // cmd1.Dispose();
        //第九步：每次执行完数据库连接后使用Close()关闭该数据库连接
        conn.Close();
        SearchStudentInfo2(userId);
        SearchStudentInfo3();
        SearchStudentInfo4();
        SearchStudentInfo5();
    }

    public void SearchStudentInfo2(string userId)
    {
        //第一步：建立新的数据连接对象
        OleDbConnection conn = Getconnection();
        //第二步：这里写入你需要执行的SQL语句
        string sql = "SELECT [_StuNum] FROM student_info WHERE ID_Student ='" + userId + "'";
        //第三步：执行数据库命令传送 且 返回一个处理结果对象
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        //第四步：打开conn对象建立数据库连接
        conn.Open();
        //第五步：定义一个数据读取对象 reader
        OleDbDataReader reader;
        //第六步：执行sql语句读取数据返回执行结果
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            //读取到的数据是用数组形式呈现的，如果你读取的数据只有一个参数数据，则写下标[0]，多个则依次累加[1],[2]....即可
            Label4.Text = "学号信息：" +reader[0].ToString();//打印查询到的数据
        }

        //第七步：读取到信息后将数据绑定在GridView组件上
        reader.Dispose();
        //第八步：Dispose()用于释放SQL执行连接的资源
        cmd.Dispose();
        // cmd1.Dispose();
        //第九步：每次执行完数据库连接后使用Close()关闭该数据库连接
        conn.Close();
    }


    public void SearchStudentInfo3()
    {
        //第一步：建立新的数据连接对象
        OleDbConnection conn = Getconnection();
        //第二步：这里写入你需要执行的SQL语句
        //string sql = "SELECT *  FROM student_info, class_info,college_info,major_info WHERE student_info.ID_Class = class_info.ID_Class and student.ID_College = college_info.ID_College and Major.ID_Major = student_info.ID_Major  and student_info.ID_Student ='" + userId + "'";
        string sql = "SELECT * FROM college_info WHERE [ID_College] ='" + Convert.ToString(ID_College) + "'";
        //第三步：执行数据库命令传送 且 返回一个处理结果对象
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        //第四步：打开conn对象建立数据库连接
        conn.Open();
        //第五步：定义一个数据读取对象 reader
        OleDbDataReader reader;
        //第六步：执行sql语句读取数据返回执行结果
        reader = cmd.ExecuteReader();
        //第七步：读取到信息后将数据绑定在GridView组件上
        while (reader.Read())
        {

            //读取到的数据是用数组形式呈现的，如果你读取的数据只有一个参数数据，则写下标[0]，多个则依次累加[1],[2]....即可
            string rs = reader[1].ToString();//打印查询到的数据
            Label1.Text = "所属学院：" + rs;

        }
        reader.Dispose();
        //第八步：Dispose()用于释放SQL执行连接的资源
        cmd.Dispose();
        // cmd1.Dispose();
        //第九步：每次执行完数据库连接后使用Close()关闭该数据库连接
        conn.Close();
    }


    public void SearchStudentInfo4()
    {
        //第一步：建立新的数据连接对象
        OleDbConnection conn = Getconnection();
        //第二步：这里写入你需要执行的SQL语句
        string sql = "SELECT * FROM major_info WHERE [ID_Major] ='" + Convert.ToString(ID_Major) + "'";
        //第三步：执行数据库命令传送 且 返回一个处理结果对象
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        //第四步：打开conn对象建立数据库连接
        conn.Open();
        //第五步：定义一个数据读取对象 reader
        OleDbDataReader reader;
        //第六步：执行sql语句读取数据返回执行结果
        reader = cmd.ExecuteReader();
        //第七步：读取到信息后将数据绑定在GridView组件上
        while (reader.Read())
        {
            //读取到的数据是用数组形式呈现的，如果你读取的数据只有一个参数数据，则写下标[0]，多个则依次累加[1],[2]....即可
            string rs = reader[1].ToString();//打印查询到的数据
            if (rs != "")
            {
                Label2.Text = "所属专业：" + rs;
            }
        }
        reader.Dispose();
        //第八步：Dispose()用于释放SQL执行连接的资源
        cmd.Dispose();
        // cmd1.Dispose();
        //第九步：每次执行完数据库连接后使用Close()关闭该数据库连接
        conn.Close();
    }


    public void SearchStudentInfo5()
    {
        Label3.Text = "";
        //第一步：建立新的数据连接对象
        OleDbConnection conn = Getconnection();
        //第二步：这里写入你需要执行的SQL语句
        string sql = "SELECT * FROM Class_info WHERE ID_Class ='" + Convert.ToString(ID_Class) + "'";
        //第三步：执行数据库命令传送 且 返回一个处理结果对象
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        //第四步：打开conn对象建立数据库连接
        conn.Open();
        //第五步：定义一个数据读取对象 reader
        OleDbDataReader reader;
        //第六步：执行sql语句读取数据返回执行结果
        reader = cmd.ExecuteReader();
        //第七步：读取到信息后将数据绑定在GridView组件上
        while (reader.Read())
        {
            //读取到的数据是用数组形式呈现的，如果你读取的数据只有一个参数数据，则写下标[0]，多个则依次累加[1],[2]....即可
            string rs = reader[1].ToString();//打印查询到的数据
            Label3.Text = "所属班级：" + rs;
        }
        reader.Dispose();
        //第八步：Dispose()用于释放SQL执行连接的资源
        cmd.Dispose();
        // cmd1.Dispose();
        //第九步：每次执行完数据库连接后使用Close()关闭该数据库连接
        conn.Close();
    }

    //查询学号
    public void SearchStudentInfo6()
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }



    //Permission_Choose()
    //作用：用于在用户按下本页面的搜索按钮后，从下拉框中选出选择的值，然后在C#代码中进行权限比较
    //不同权限的身份将在后台页面看见不同的内容，身份在系统中起到的决策作用越小，看到的内容也会越少
    //本search.aspx页面被权限锁定的主要内容是： DropDownList1 下拉框
    protected void Permission_Choose()
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string userId; //定义需要搜素的文本
        string identity; //定义所选择的信息类型
        userId = TextBox1.Text; //将搜索框获取到的身份信息存在userId中，该变量userId被用于下面的switch代码进行信息查询

        //从session获取身份标识 ， 可能获取到的值 counselor 辅导员 | sectionManager 科长 | finance 财务
        identity = (string)Session["identity"];
        identity = "finance";
        //selectedType = DropDownList1.SelectedValue;

        //进行搜索内容的判断，针对不同对象进入执行不不同的函数进入不同的数据库进行搜索
        switch (identity)
        {
            //选择辅导员
            case "counselor":
                SearchStudentInfo(userId); //学生信息搜索
                SearchStudentInfo1(userId); //学生学院 专业 班级 信息
                break;

            //选择科长
            case "sectionManager":

                break;
            //选择财务
            case "finance":
                SearchStudentInfo(userId); //学生信息搜索
                SearchStudentInfo1(userId);//学生学院 专业 班级 信息
                break;
            //默认情况
            default:
                //因为没有得到identity的选择项，向页面发出警告
                Response.Write("<script>alert(\" 您的身份有误，无法使用查询系统 \");</script>");
                break;
        }
    }


    protected void Button2_Click(object sender, EventArgs e)
    {

    }
}