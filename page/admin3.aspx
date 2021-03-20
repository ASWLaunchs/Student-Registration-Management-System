<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin3.aspx.cs" Inherits="page_admin3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../css/bootstrap.min.css">
    <link rel="stylesheet" href="../css/search.css">
    <style>
        body {
            color:#fff;
            background-color: rgba(0,0,0,1);
        }

        .list-group {
            color: #fff;
        }

        .list-group-item {
            background-color: rgba(0,0,0,0.1);
        }

            .list-group-item:first-child {
                margin-top: 20px;
            }

            .list-group-item:not(:first-child) {
                text-align: center;
                color: #fff;
            }

                .list-group-item:not(:first-child) table th, .list-group-item:not(:first-child) table td {
                    color: #fff;
                    padding: 4px 8px;
                }

        hr {
            color: #808080;
            background-color: #808080;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2 style="padding:8px">管理员界面 | 科长信息添加</h2>
        <table class="table table-dark" style="text-align: center;">
            <thead>
                <tr>
                    <th scope="col">属性</th>
                    <th scope="col">输入框</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="工号"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="名字"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="密码"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="职位"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="手机号"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="邮箱"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="所属单位"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button1" class="btn btn-warning" runat="server" Text="添加" OnClick="Button1_Click" />
                        <asp:Button ID="Button2" class="btn btn-warning" runat="server" Text="修改" OnClick="Button2_Click" />
                        <asp:Button ID="Button3" class="btn btn-warning" runat="server" Text="删除" OnClick="Button3_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
    </form>
</body>
</html>
