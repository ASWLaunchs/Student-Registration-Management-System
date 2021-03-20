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

public partial class page_feedBack : System.Web.UI.Page
{

    //Getconnection()
    //作用：根据 OleDb 规则指定相应数据库，并返回一个可创建的连接对象
    public OleDbConnection Getconnection()
    {
        string strConnection = System.Configuration.ConfigurationManager.AppSettings["CONN"].ToString() + System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["dbpath"] + ";");
        OleDbConnection conn = new OleDbConnection(strConnection);
        return conn;
    }
    //submitForm()
    //作用：用于将提交表单的数据存到数据库的feedback_info表
    //该表单所提交的信息是当学生发现自己个人信息和实际情况不符时才提交的反馈修改信息
    //传入参数：userId 用户ID , userName 用户姓名 , userAge 用户年龄 ,userSex 用户性别, userNation 用户民族 , userAddress 用户住址 , userPhone 用户手机号 , userEmail 用户邮箱
    protected void submitForm(string userId, string userName, int userAge, string userSex, string userNation, string userAddress, string userPhone, string userEmail)
    {
        //第一步：建立新的数据连接对象
        OleDbConnection conn = Getconnection();
        //第二步：这里写入你需要执行的SQL语句
        string sql = "INSERT INTO feedback_info VALUES('" + userId + "','" + userName + "','" + userSex + "'," + userAge + ",'" + userNation + "','" + userAddress + "','" + userPhone + "','" + userEmail + "')";
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
    //传入参数：userId 用户ID , userName 用户姓名 , userSex 用户性别,userAge 用户年龄 , userNation 用户民族 , userAddress 用户住址 , userPhone 用户手机号 , userEmail 用户邮箱
    protected void updateInfo(string userId, string userName, string userSex, int userAge, string userNation, string userAddress, string userPhone, string userEmail)
    {
        Response.Write("<script>alert('成功修改个人信息！')</script>");
        //第一步：建立新的数据连接对象
        OleDbConnection conn = Getconnection();
        //第二步：这里写入你需要执行的SQL语句
        string sql = "UPDATE student_info  SET _Name='" + userName + "',  _Sex ='" + userSex + "' , _Age=" + userAge + " , _Nation='" + userNation + "' , _Address='" + userAddress + "' , _PhoneNum='" + userPhone + "' , _Email='" + userEmail + "', _Modify=0 WHERE ID_Student ='" + Convert.ToString(Session["uid"]) + "'";
        //第三步：执行数据库命令传送 且 返回一个处理结果对象
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        Response.Write("<script>alert('"+sql+"')</script>");
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
        if (!IsPostBack)
        {
            ArrayList arr = new ArrayList();
            arr.Add("女");
            arr.Add("男");
            DropDownList1.DataSource = arr;
            DropDownList1.DataBind();
        }
        if (Convert.ToString(Session["uid"]) == null || Convert.ToString(Session["uid"]) == "")
        {
            Response.Redirect("../Default.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if ( TextBox2.Text == "" || TextBox2.Text == null || TextBox3.Text == "" || TextBox3.Text == null)
        {
            Label11.Text = "<h2 style='color:red'>请按正确格式填写表单信息</h2>";
        }
        else
        {
            Label11.Text = "";
            //userId 用户ID, userName 用户姓名 , uuserSex 用户性别,serAge 用户年龄,  userNation 用户民族, userAddress 用户住址 , userPhone 用户手机号, userEmail 用户邮箱
            updateInfo(Convert.ToString(Session["uid"]) , TextBox2.Text, DropDownList1.SelectedValue, Convert.ToInt32(TextBox3.Text),TextBox4.Text,TextBox5.Text,TextBox6.Text,TextBox7.Text);
            Response.Redirect("./personalPage.aspx");
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}