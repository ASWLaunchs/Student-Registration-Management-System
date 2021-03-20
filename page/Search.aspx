<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="page_Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../css/bootstrap.min.css">
    <style>
        body {
            background-color: rgba(0,0,0,0.1);
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
    <form id="from" runat="server">
        <div>
            <ul class="list-group list-group-flush" style="background-color: rgba(0,0,0,0.1)">
                <li class="list-group-item">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="查询" OnClick="Button1_Click" />
                </li>
                <li class="list-group-item">
                    <h4>信息查询</h4>
                    <br/>
                     <asp:Label ID="Label4" runat="server" Text="" Style="text-align: left; float: left;">请在输入框中输入需要查询的信息</asp:Label>
                    <br />
                    <br />
                    <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" Style="background-color: rgba(0,0,0,0.4);">
                        <Columns>
                            <asp:BoundField DataField="_Name"
                                ReadOnly="true"
                                HeaderText="姓名" />
                            <asp:BoundField DataField="_Sex"
                                ConvertEmptyStringToNull="true"
                                HeaderText="性别" />
                            <asp:BoundField DataField="_Age"
                                ConvertEmptyStringToNull="true"
                                HeaderText="年龄" />
                            <asp:BoundField DataField="_Nation"
                                ConvertEmptyStringToNull="true"
                                HeaderText="民族" />
                            <asp:BoundField DataField="_Address"
                                ConvertEmptyStringToNull="true"
                                HeaderText="地址" />
                            <asp:BoundField DataField="_PhoneNum"
                                ConvertEmptyStringToNull="true"
                                HeaderText="手机号" />
                            <asp:BoundField DataField="_Email"
                                ConvertEmptyStringToNull="true"
                                HeaderText="邮箱" />
                        </Columns>
                    </asp:GridView>
                </li>
                <li class="list-group-item">
                    <asp:Label ID="Label1" runat="server" Text="" Style="text-align: left; float: left;"></asp:Label>
                    <br/>
                    <asp:Label ID="Label2" runat="server" Text="" Style="text-align: left; float: left;"></asp:Label>
                    <br/>
                    <asp:Label ID="Label3" runat="server" Text="" Style="text-align: left; float: left;"></asp:Label>
                </li>
            </ul>
        </div>
    </form>
</body>
</html>
