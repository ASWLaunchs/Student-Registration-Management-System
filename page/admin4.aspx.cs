using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

public partial class page_admin4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    //type方式必须是post，方法必须是静态的，方法声明要加上特性[System.Web.Services.WebMethod()]，传递的参数个数也应该和方法的参数相同。
    [System.Web.Services.WebMethod()]
    public static string AjaxMethod(string param1, string param2)
    {
        return "参数1为：" + param1 + "，参数2为：" + param2;
    }
}