<%@ Page Language="C#" AutoEventWireup="true" CodeFile="demo.aspx.cs" Inherits="page_demo" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>AJAX与C#后端通信实例</title>
    <script src="../js/jquery-3.4.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#btn").click(function () {
                var pv = $("#Param").val(); //获取输入框的值

                $.ajax({
                    url: "demo.aspx/Ajax",//发送到本页面后台AjaxMethod方法
                    type: "POST",
                    dataType: "json",
                    async: true,//async翻译为异步的，false表示同步，会等待执行完成，true为异步
                    contentType: "application/json; charset=utf-8",//不可少
                    data: "{param:'" + pv + "'}",
                    success: function (data) {
                        $("#result").html(data);
                    },
                    error: function () {
                        alert("请求出错处理");
                    }
                });

            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        所提交的信息：<input type="text" id="Param" value="" /><br />
        <input type="button" id="btn" value="提交"/><br />
        后端C#反馈回来的结果：<div id="result"></div>
    </form>
</body>
</html>