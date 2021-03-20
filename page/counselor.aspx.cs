using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

public partial class page_counselor : System.Web.UI.Page
{
    string rs1, rs2, rs3, rs4, rs5, rs6, rs7;
    string originalUser;
    //searchInfo()
    //作用：用于从student_info的数据表中查询信息查询学生信息
    //传入参数：userId 用户ID

    //Getconnection()
    //作用：根据 OleDb 规则指定相应数据库，并返回一个可创建的连接对象
    public OleDbConnection Getconnection()
    {
        string strConnection = System.Configuration.ConfigurationManager.AppSettings["CONN"].ToString() + System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["dbpath"] + ";");
        OleDbConnection conn = new OleDbConnection(strConnection);
        return conn; //返回数据库连接池的句柄，然后其他页面不用再配置连接，直接拿conn即可操作，详情见下面的增删改查操作
    }

    //效验个人信息是否已经存在
    protected string checkedForm(string userId)
    {
        //第一步：建立新的数据连接对象
        OleDbConnection conn = Getconnection();
        //第二步：这里写入你需要执行的SQL语句
        string sql = "SELECT * FROM worker_account WHERE ID_Worker ='" + userId + "'";
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
            originalUser = reader[0].ToString();//打印查询到的数据
        }
        //第八步：销毁reader对象
        reader.Dispose();
        //第九步：Dispose()用于释放SQL执行连接的资源
        cmd.Dispose();
        //第十步：每次执行完数据库连接后使用Close()关闭该数据库连接
        conn.Close();
        return originalUser;
    }


    //deleteInfo() 用于删除个人信息
    //传入参数：userId 用户ID
    protected void deleteInfo(string userId)
    {
        //第一步：建立新的数据连接对象
        OleDbConnection conn = Getconnection();
        //第二步：这里写入你需要执行的SQL语句
        string sql = "Delete from worker_account WHERE ID_Worker ='" + userId + "'";
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

    protected void Page_Load(object sender, EventArgs e)
    {
        //deleteInfo("599601199002037891");
        //从Session里面取出用户UID后转化为字符串格式通过searchInfo（）在数据库进行搜索
        //searchInfo(Convert.ToString(Session["UID"]));
        //updateInfo("61160120000102000X", "X9day重度用户",18,"女","小仙女族","地球上亚洲大陆","+190902345","1000@x9day.com");
    }

    //submitForm()
    //作用：用于将提交表单的数据存到数据库的feedback_info表
    //该表单所提交的信息是当学生发现自己个人信息和实际情况不符时才提交的反馈修改信息
    //传入参数：userId 用户ID , userName 用户姓名 ,userPasswd 密码, userPosition职位 userPhone 用户手机号 , userEmail 用户邮箱 , BelongTo所属
    protected void submitForm(string userId, string userName, string userPasswd, string userPosition, string userPhone, string userEmail, string BelongTo)
    {
        //第一步：建立新的数据连接对象
        OleDbConnection conn = Getconnection();
        //第二步：这里写入你需要执行的SQL语句 
        string sql = "INSERT INTO worker_account(ID_worker,_Name,_Passwd,_Position,_PhoneNum,_Email,ID_College,_Status) VALUES('" + userId + "','" + userName + "','" + userPasswd + "','" + userPosition + "','" + userPhone + "','" + userEmail + "','" + BelongTo + "' ," + 3 +")" ;
        //第三步：执行数据库命令传送 且 返回一个处理结果对象
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        //第四步：打开conn对象建立数据库连接
        conn.Open();
        //第五步：定义一个数据读取对象 reader
        cmd.ExecuteNonQuery();
        //第六步：Dispose()用于释放SQL执行连接的资源
        cmd.Dispose();
        //第七步：每次执行完数据库连接后使用Close()关闭该数据库连接
        conn.Close();
    }


    //updateInfo() 用于更新个人信息
    //传入参数：userId工号，userName用户姓名,userPasswd用户密码,userPosition用户职位,userPhone用户手机号,userEmail用户邮箱,BelongTo 所属单位
    protected void updateInfo(string userId, string userName, string userPasswd, string userPosition, string userPhone, string userEmail, string BelongTo)
    {
        //第一步：建立新的数据连接对象
        OleDbConnection conn = Getconnection();
        //第二步：这里写入你需要执行的SQL语句
        string sql = "UPDATE worker_account  SET [_Name]='" + userName + "',  [_Passwd] ='" + userPasswd + "' , [_Position]='" + userPosition + "' , [_PhoneNum]='" + userPhone + "' , [_Email]='" + userEmail + "',[ID_College] ='" + BelongTo + "'  WHERE [ID_Worker] ='" + userId + "'";
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



    //添加辅导员信息操作
    protected void Button1_Click(object sender, EventArgs e)
    {
        if ((string)Session["ID_Class"] == null || (string)Session["ID_Class"] == "")
        {
            Response.Write("<script>alert('您提交失败，登录参数有误，请从正确的登录页面登录系统');</script>");
        }
        else
        {
            if (TextBox1.Text == null || TextBox1.Text == "" || TextBox2.Text == null || TextBox2.Text == "" || TextBox3.Text == null || TextBox3.Text == "" || TextBox4.Text == null || TextBox4.Text == "" || TextBox5.Text == null || TextBox5.Text == "" || TextBox1.Text == null)
            {
                Response.Write("<script>alert('请将表单填写完成！');</script>");
            }
            else if (checkedForm(TextBox1.Text) == originalUser && originalUser != null && originalUser != "")
            {
                Response.Write("<script>alert('该辅导员已经存在，请检查输入的辅导员ID是否重复');</script>");
            }
            else
            {
                Response.Write("<script>alert('插入成功！');</script>");
                //传入参数：userId 用户ID , userName 用户姓名 ,userPasswd 密码,userPosition职位 userPhone 用户手机号 , userEmail 用户邮箱 , _BelongTo所属
                submitForm(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text);
            }

        }
    }

    //修改辅导员信息操作
    protected void Button2_Click(object sender, EventArgs e)
    {
        if ((string)Session["ID_Class"] == null || (string)Session["ID_Class"] == "")
        {
            Response.Write("<script>alert('您提交失败，登录参数有误，请从正确的登录页面登录系统');</script>");
        }
        else
        {
            if (TextBox1.Text == null || TextBox1.Text == "" || TextBox2.Text == null || TextBox2.Text == "" || TextBox3.Text == null || TextBox3.Text == "" || TextBox4.Text == null || TextBox4.Text == "" || TextBox5.Text == null || TextBox5.Text == "" || TextBox6.Text == null || TextBox6.Text == "" || TextBox7.Text == null || TextBox7.Text == "" || TextBox3.Text.Length < 6 || TextBox1.Text == null)
            {
                Response.Write("<script>alert('请将表单填写完成！');</script>");
            }
            else if (checkedForm(TextBox1.Text) == originalUser && originalUser != null && originalUser != "")
            {
                Response.Write("<script>alert('修改成功！');</script>");
                //更新个人信息
                //userId工号，userName用户姓名,userPasswd用户密码,userPosition用户职位,userPhone用户手机号,userEmail用户邮箱,BelongTo 所属单位
                updateInfo(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text);
            }
            else
            {
                Response.Write("<script>alert('信息有误，请重新填写！');</script>");

            }
        }
    }

    //删除辅导员信息操作
    protected void Button3_Click(object sender, EventArgs e)
    {
        if ((string)Session["ID_Class"] == null || (string)Session["ID_Class"] == "")
        {
            Response.Write("<script>alert('您提交失败，登录参数有误，请从正确的登录页面登录系统');</script>");
        }
        else
        {
            if (TextBox1.Text == null || TextBox1.Text == "")
            {
                Response.Write("<script>alert('请将表单填写完成！');</script>");
            }
            else if (checkedForm(TextBox1.Text) == originalUser && originalUser != null && originalUser != "")
            {
                Response.Write("<script>alert('删除成功！');</script>");
                deleteInfo(TextBox1.Text);
            }
        }
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        Response.Write("<script>alert('所需要删除的辅导员不存在！');</script>");
        if (checkedForm(TextBox1.Text) == originalUser && originalUser != null && originalUser != "")
        {
        }
        else
        {
            Response.Write("<script>alert('所需要删除的辅导员不存在！');</script>");
        }
    }


    //测试脚本
    //    TextBox1.value ="fdy1002"
    //TextBox2.value = "元辅导"
    //TextBox3.value = "123456"
    //TextBox4.value = "辅导员"
    //TextBox5.value = "176930004000"
    //TextBox6.value = "1000@x9day.com"
    //TextBox7.value = "jb1000"
}