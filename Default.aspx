<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/bootstrap-grid.min.css" />
    <link rel="stylesheet" type="text/css" href="css/htmleaf-demo.css" />
    <link rel="stylesheet" type="text/css" href="css/normalize.css" />
    <link rel="stylesheet" type="text/css" href="css/index.css" />
    <link href="http://cdn.bootcss.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" />
</head>
<body>
    <div class="htmleaf-container">
        <div class="demo form-bg">
            <div class="container">
                <div class="row">
                    <div class="col-md-offset-4 col-md-4 col-sm-offset-3 col-sm-6">
                        <form class="form-horizontal" action="/page/loginResult.aspx" method="post">
                            <div class="heading">学生报名系统</div>
                            <div class="form-group">
                                <i class="fa fa-user"></i>
                                <input id="userName" required name="userid" type="text" class="form-control" placeholder="学生身份证号" id="exampleInputEmail1">
                            </div>
                            <div class="form-group">
                                <i class="fa fa-lock"></i>
                                <input id="userPasswd" required name="passwd" type="password" class="form-control" placeholder="密码" />
                            </div>
                            <div class="form-group">
                                <button id="login" type="submit" class="btn btn-default"><i class="fa fa-arrow-right"></i></button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        let login = document.querySelector("#login")
        let userName = document.querySelector("#userName")
        let userPasswd = document.querySelector("#userPasswd")
        login.onclick = () => {

        }
    </script>
</body>
</html>
