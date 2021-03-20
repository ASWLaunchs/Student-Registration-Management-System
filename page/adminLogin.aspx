<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminLogin.aspx.cs" Inherits="page_adminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/banner.css" rel="stylesheet" />
    <title>学生教务管理系统</title>
    <style>
        #form1 {
            margin-top: 80px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="banner">
            <hr />
            <div class="banner1">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                <br/>
                <br/>
                <asp:Label ID="Label4" runat="server" Text="用户名" Style="margin-right: 8px"></asp:Label>&nbsp;&nbsp;<asp:TextBox ID="TextBox1" style="height:30px" runat="server"></asp:TextBox>
            </div>
            <br />
            <br />
            <div class="banner2">
                <asp:Label ID="Label2" runat="server" Text="" style="margin-left:-px;"></asp:Label>
                <br/>
                <br/>
                <asp:Label ID="Label5" runat="server" Text="密码" Style="margin-right: 20px"></asp:Label>&nbsp;&nbsp;<asp:TextBox ID="TextBox2" style="height:30px"  runat="server"></asp:TextBox>
            </div>
            <br />
            <br />
            <div class="banner3">
                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                <asp:Button ID="Button1" runat="server" Text="提交" Style="margin-left: 20px" OnClick="Button1_Click" />
                <br/>
                <br/>
                <hr />

            </div>
    </form>
</body>
</html>
