<%@ Page Language="C#" AutoEventWireup="true" CodeFile="counselorDataStatistics.aspx.cs" Inherits="page_counselorDataStatistics" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/search.css" />
    <style>
        body {
            color: #fff;
        }

        table th, table td {
            color: #fff;
            padding: 8px 12px;
        }

        button {
            background: #fff;
            color: #000
        }

        #form1 {
            width: 90%;
            margin: 30px auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:BoundField DataField="ID_Worker"
                        ReadOnly="true"
                        HeaderText="工号" />
                    <asp:BoundField DataField="_Name"
                        ReadOnly="true"
                        HeaderText="姓名" />
                    <asp:BoundField DataField="_Position"
                        ConvertEmptyStringToNull="true"
                        HeaderText="职位" />
                    <asp:BoundField DataField="_PhoneNum"
                        ConvertEmptyStringToNull="true"
                        HeaderText="手机号" />
                    <asp:BoundField DataField="_Email"
                        ConvertEmptyStringToNull="true"
                        HeaderText="邮箱" />
                    <asp:BoundField DataField="ID_College"
                        ConvertEmptyStringToNull="true"
                        HeaderText="学院代码" />
                    <asp:ButtonField HeaderText="修改" ButtonType="Button" Text="修改" CommandName="XG" />
                </Columns>
            </asp:GridView>
        </div>
        <hr/>
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
                        <asp:Label ID="Label1" runat="server" Text="姓名"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                </tr>
<%--                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="职位"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList></td>
                </tr>--%>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="手机号"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="邮箱"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="学院代码"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button1" class="btn btn-warning" runat="server" Text="确认修改" OnClick="Button1_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
    </form>

    <script src="../js/search.js"></script>
</body>
</html>
