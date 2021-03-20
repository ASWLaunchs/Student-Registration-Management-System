using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Windows.Forms;

public partial class page_personalPage : System.Web.UI.Page
{
    string ID_Major;
    string ID_College;
    string ID_Class;
    //Getconnection()
    //作用：根据 OleDb 规则指定相应数据库，并返回一个可创建的连接对象
    public OleDbConnection Getconnection()
    {
        string strConnection = System.Configuration.ConfigurationManager.AppSettings["CONN"].ToString() + System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["dbpath"] + ";");
        OleDbConnection conn = new OleDbConnection(strConnection);
        return conn;
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
        //第七步：绑定获取到的数据到GridView表格上
        GridView1.DataSource = reader;
        GridView1.DataBind();
        //第八步：销毁reader对象
        reader.Dispose();
        //第九步：Dispose()用于释放SQL执行连接的资源
        cmd.Dispose();
        //第十步：每次执行完数据库连接后使用Close()关闭该数据库连接
        conn.Close();
    }

    //updateInfo666() 用于更新个人信息 , 该函数已作废
    //传入参数：userId 用户ID , userName 用户姓名 , userAge 用户年龄 ,userSex 用户性别, userNation 用户民族 , userAddress 用户住址 , userPhone 用户手机号 , userEmail 用户邮箱
    protected void updateInfo666(string userId, string userName, int userAge, string userSex, string userNation, string userAddress, string userPhone, string userEmail)
    {
        //第一步：建立新的数据连接对象
        OleDbConnection conn = Getconnection();
        //第二步：这里写入你需要执行的SQL语句
        string sql = "UPDATE student_info  SET _Name='" + userName + "',  _Sex ='" + userSex + "' , _Age=" + userAge + " , _Nation='" + userNation + "' , _Address='" + userAddress + "' , _PhoneNum='" + userPhone + "' , _Email='" + userEmail + "' WHERE ID_Student ='" + userId + "'";
        //第三步：执行数据库命令传送 且 返回一个处理结果对象
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        //第四步：打开conn对象建立数据库连接
        conn.Open();
        //第五步：执行sql语句更新数据
        cmd.ExecuteNonQuery();
        //第六步：Dispose()用于释放SQL执行连接的资源
        cmd.Dispose();
        //第七步：每次执行完数据库连接后使用Close()关闭该数据库连接
        conn.Close();
    }

    protected void updateInfo1(string userId, string userName, int userAge, string userSex, string userNation, string userAddress, string userPhone, string userEmail)
    {
        //第一步：建立新的数据连接对象
        OleDbConnection conn = Getconnection();
        //第二步：这里写入你需要执行的SQL语句
        string sql = "UPDATE student_info  SET _Name='" + userName + "',  _Sex ='" + userSex + "' , _Age=" + userAge + " , _Nation='" + userNation + "' , _Address='" + userAddress + "' , _PhoneNum='" + userPhone + "' , _Email='" + userEmail + "' WHERE ID_Student ='" + userId + "'";
        //第三步：执行数据库命令传送 且 返回一个处理结果对象
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        //第四步：打开conn对象建立数据库连接
        conn.Open();
        //第五步：执行sql语句更新数据
        cmd.ExecuteNonQuery();
        //第六步：Dispose()用于释放SQL执行连接的资源
        cmd.Dispose();
        //第七步：每次执行完数据库连接后使用Close()关闭该数据库连接
        conn.Close();
    }
    protected void updateInfo(string userId, string comment)
    {
        //第一步：建立新的数据连接对象
        OleDbConnection conn = Getconnection();
        //第二步：这里写入你需要执行的SQL语句
        string sql = "UPDATE student_info SET _Comment = '" + comment + "',_SH = 3  WHERE ID_Student ='" + userId + "'";
        //第三步：执行数据库命令传送 且 返回一个处理结果对象
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        //第四步：打开conn对象建立数据库连接
        conn.Open();
        //第五步：执行sql语句更新数据
        cmd.ExecuteNonQuery();
        //第六步：Dispose()用于释放SQL执行连接的资源
        cmd.Dispose();
        //第七步：每次执行完数据库连接后使用Close()关闭该数据库连接
        conn.Close();
    }

    //deleteInfo() 用于删除个人信息
    //传入参数：userId 用户ID
    //根据userId在feedback_info
    protected void deleteInfo(string userId)
    {
        //第一步：建立新的数据连接对象
        OleDbConnection conn = Getconnection();
        //第二步：这里写入你需要执行的SQL语句
        string sql = "Delete from feedback_info WHERE ID_Student ='" + userId + "'";
        //第三步：执行数据库命令传送 且 返回一个处理结果对象
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        //第四步：打开conn对象建立数据库连接
        conn.Open();
        //第五步：执行sql语句更新数据
        cmd.ExecuteNonQuery();
        //第六步：Dispose()用于释放SQL执行连接的资源
        cmd.Dispose();
        //第七步：每次执行完数据库连接后使用Close()关闭该数据库连接
        conn.Close();
    }


    protected Boolean IsModify(string userId)
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
        //第七步：绑定获取到的数据到GridView表格上
        while (reader.Read())
        {
            if (Convert.ToInt32(reader[12].ToString()) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //第八步：销毁reader对象
        reader.Dispose();
        //第九步：Dispose()用于释放SQL执行连接的资源
        cmd.Dispose();
        //第十步：每次执行完数据库连接后使用Close()关闭该数据库连接
        conn.Close();
        return false;
    }

    public void stuNum(string userId)
    {
        //第一步：建立新的数据连接对象
        OleDbConnection conn = Getconnection();
        //第二步：这里写入你需要执行的SQL语句
        string sql = "SELECT * FROM stunum WHERE ID_Student ='" + userId + "'";
        //第三步：执行数据库命令传送 且 返回一个处理结果对象
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        //第四步：打开conn对象建立数据库连接
        conn.Open();
        //第五步：定义一个数据读取对象 reader
        OleDbDataReader reader;
        //第六步：执行sql语句读取数据返回执行结果
        reader = cmd.ExecuteReader();
        //第七步：绑定获取到的数据到GridView表格上
        while (reader.Read())
        {
            //读取到的数据是用数组形式呈现的，如果你读取的数据只有一个参数数据，则写下标[0]，多个则依次累加[1],[2]....即可
            //Label1.Text = reader[0].ToString();//查询到的数据
        }
        //第八步：销毁reader对象
        reader.Dispose();
        //第九步：Dispose()用于释放SQL执行连接的资源
        cmd.Dispose();
        //第十步：每次执行完数据库连接后使用Close()关闭该数据库连接
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
        string sql = "SELECT * FROM student_info WHERE ID_Student ='" + userId + "'";
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
            Label4.Text = "学号信息：" + reader[1].ToString();//打印查询到的数据
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
            //Label1.Text = "所属学院：" + rs;

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



    protected void Page_Load(object sender, EventArgs e)
    {
        //deleteInfo("599601199002037891");
        //从Session里面取出用户UID后转化为字符串格式通过searchInfo（）在数据库进行搜索
        if (Convert.ToString(Session["UID"]) == null || Convert.ToString(Session["UID"]) == "")
        {
            Response.Redirect("../Default.aspx");
        }
        searchInfo(Convert.ToString(Session["UID"]));
        //stuNum(Convert.ToString(Session["UID"]));
        SearchStudentInfo1(Convert.ToString(Session["UID"]));
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!IsModify(Convert.ToString(Session["UID"])))
        {
            Response.Write("<script>alert('您已经修改过一次信息，已经不能再修改，如有问题请点击反馈按钮进行反馈，我们会在工作日内处理您的消息');</script>");
        }
        else
        {
            Response.Redirect("./feedBack.aspx");
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        updateInfo(Convert.ToString(Session["UID"]), TextBox1.Text);

        Response.Write("<script>alert('您的反馈已经发送成功，我们会再工作日内给予回复');</script>");

    }
}