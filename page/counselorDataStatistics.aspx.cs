using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Windows.Forms;

public partial class page_counselorDataStatistics : System.Web.UI.Page
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


    public void CounsolerData()
    {
        if (Convert.ToString(Session["ID_College"]) == "" || Convert.ToString(Session["ID_College"]) == null || Convert.ToString(Session["ID_College"]).Length == 0)
        {
            Session["ID_College"] = "xy1000";
        }
        //第一步：建立新的数据连接对象
        OleDbConnection conn = Getconnection();
        //第二步：这里写入你需要执行的SQL语句
        string sql = "SELECT * FROM worker_account WHERE [ID_College] = '" + Convert.ToString(Session["ID_College"]) + "' and [_Status]=" + 3;
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
        GridView1.DataKeyNames = new string[] { "ID_Worker" };
        GridView1.DataBind();
        //第八步：销毁reader对象
        reader.Dispose();
        //第九步：Dispose()用于释放SQL执行连接的资源
        cmd.Dispose();
        //第十步：每次执行完数据库连接后使用Close()关闭该数据库连接
        conn.Close();
    }

    public void CounsolerDataChanged(string uid)
    {
        //int status = 0;
        OleDbConnection conn = Getconnection();
        //if (DropDownList1.SelectedValue == "科长")
        //{
        //    status = 2;
        //}
        //else if (DropDownList1.SelectedValue == "辅导员")
        //{
        //    status = 3;
        //}
        string sql = "update worker_account SET [_Name]='" + TextBox1.Text + "', [_PhoneNum]= '" + TextBox3.Text + "', [_Email]= '" + TextBox4.Text + "', [ID_College]= '" + TextBox5.Text + "' WHERE [ID_Worker] = '" + uid + "'"; 
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        conn.Open();
        DialogResult i = MessageBox.Show("您确定要修改该辅导员信息吗？", "审核对话框", MessageBoxButtons.OKCancel);
        if (i == DialogResult.OK)
            cmd.ExecuteNonQuery();
        cmd.Dispose();
        conn.Close();
    }

    public void Page_Load(object sender, EventArgs e)
    {
        CounsolerData();
        //DropDownList1.Items.Add("辅导员");
        //DropDownList1.Items.Add("科长");
    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "XG")
        {
            uid = Convert.ToString(GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
            OleDbConnection conn = Getconnection();
            string sql = "select * from worker_account where ID_Worker='" + uid + "'";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            conn.Open();
            OleDbDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TextBox1.Text = reader.GetString(1);
                TextBox3.Text = reader.GetString(4);
                TextBox5.Text = reader.GetString(6);
                TextBox4.Text = reader.GetString(5);
            }
            reader.Dispose();
            cmd.Dispose();
            conn.Dispose();
            Session["FDYUID"] = uid;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        CounsolerDataChanged(Convert.ToString(Session["FDYUID"]));
    }
}