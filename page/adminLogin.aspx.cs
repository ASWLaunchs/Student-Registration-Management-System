using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Configuration;

public partial class page_adminLogin : System.Web.UI.Page
{
    string Passwd;
    string sf; //身份
    //Getconnection()
    //作用：根据 OleDb 规则指定相应数据库，并返回一个可创建的连接对象
    public OleDbConnection Getconnection()
    {
        string strConnection = System.Configuration.ConfigurationManager.AppSettings["CONN"].ToString() + System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["dbpath"] + ";");
        OleDbConnection conn = new OleDbConnection(strConnection);
        return conn; //返回数据库连接池的句柄，然后其他页面不用再配置连接，直接拿conn即可操作，详情见下面的增删改查操作
    }

    protected bool VerifyInfo(string userId, string passwd)
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
            sf = reader[0].ToString(); //获取到科长的身份
            Session["userName"] = reader[1].ToString();//查询到的数据
            Passwd = reader[2].ToString();
            Session["ID_Class"] = reader[6].ToString();

        }
        if (Passwd == "" || Passwd == null)
        {
            reader.Dispose();
            //第九步：Dispose()用于释放SQL执行连接的资源
            cmd.Dispose();
            //第十步：每次执行完数据库连接后使用Close()关闭该数据库连接
            conn.Close();
            return false;
        }
        else
        {
            reader.Dispose();
            //第九步：Dispose()用于释放SQL执行连接的资源
            cmd.Dispose();
            //第十步：每次执行完数据库连接后使用Close()关闭该数据库连接
            conn.Close();
            return true;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.Items.Add("辅导员");
            DropDownList1.Items.Add("科长");
            DropDownList1.Items.Add("财务");
            DropDownList1.Items.Add("管理员");
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "")
        {
            Label1.Text = "<span style='color:red'>用户名不能为空</span>";
        }

        if (TextBox2.Text == "")
        {
            Label2.Text = "<span style='color:red'>密码不能为空</span>";
        }
        else if (TextBox2.Text.Length < 6)
        {
            Label2.Text = "<span style='color:red'>密码长度不能小于6</span>";
        }
        else
        {
            Label1.Text = "";
            Label2.Text = "";
        }

        if (!VerifyInfo(TextBox1.Text, TextBox2.Text))
        {
            Label1.Text = "<span style='color:red'>用户名或密码错误</span>";
        }
        else
        {
            if (DropDownList1.SelectedValue == "辅导员")
            {
                Session["identity"] = "counselor";
            }
            else if (DropDownList1.SelectedValue == "科长")
            {
                Session["identity"] = "sectionManager";
            }
            else if (DropDownList1.SelectedValue == "财务")
            {
                Session["identity"] = "finance";
            }
            else
            {
                Session["identity"] = "admin";
            }
            Session["ID_Worker"] = TextBox1.Text;

            if (sf.Substring(0, 3) == "fdy") //如果截取的字符串前两个字符是fdy , 表示去辅导员那个页面
            {
                Response.Redirect("./admin.aspx");
            }
            else if (sf.Substring(0, 2) == "kz") //如果截取的字符串前两个字符是kz，表示去科长那个页面
            {
                if (Convert.ToString(TextBox1.Text.Substring(TextBox1.Text.Length - 4, 4)) == "1000")
                {
                    Session["ID_College"] = "xy1000";
                }
                Response.Redirect("./admin1.aspx");
            }
            else if (sf.Substring(0, 2) == "cw") //如果截取的字符串前两个字符是cw , 表示去财务那个页面
            {
                Response.Redirect("./admin2.aspx");
            }
            else //否则，截取的字符串前两个字符是gly, 表示去财务那个页面
            {
                Response.Redirect("./admin3.aspx");
            }
        }
    }
}