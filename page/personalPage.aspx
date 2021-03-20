<%@ Page Language="C#" AutoEventWireup="true" CodeFile="personalPage.aspx.cs" Inherits="page_personalPage" %>

<!DOCTYPE HTML>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link href="../css/bootstrap.css" rel='stylesheet' type='text/css' />
    <style>
        body {
            background-color: #4e657a !important;
        }

        th {
            text-align: center;
            padding: 8px 10px;
        }

        td {
            text-align: center;
            padding: 8px 10px;
        }

        .paid {
            color: cornflowerblue;
            font-weight: bold;
            /* transform: rotate(-45deg); */
            width: 300px;
            z-index: 9999;
        }
    </style>
</head>
<body style="background-color: #4e657a; min-height: 100vh">
    <form id="form1" runat="server">
        <div class="container" style="background-color: #fff">
            <h3 style="background-color: cornflowerblue; color: #ff6a00; padding: 8px;">您的个人页面</h3>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="_Name"
                        ReadOnly="true"
                        HeaderText="姓名" />
                    <asp:BoundField DataField="ID_Student"
                        ReadOnly="true"
                        HeaderText="身份证信息" />
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
                    <asp:BoundField DataField="_Money"
                        ReadOnly="true"
                        HeaderText="缴费金额" />
                    <asp:BoundField DataField="_Date"
                        ConvertEmptyStringToNull="true"
                        HeaderText="缴费时间" />
                    <asp:BoundField DataField="_Pay"
                        ConvertEmptyStringToNull="true"
                        HeaderText="是否缴费" />
                </Columns>
            </asp:GridView>
            <br />
            <ul class="list-group list-group-flush">
                <li class="list-group-item " style="background-color: #ccc;height:40px">
                    <asp:Label ID="Label2" runat="server" Text="" Style="text-align: left; float: left;"></asp:Label></li>
                <li class="list-group-item " style="background-color: #ccc;height:40px">
                    <asp:Label ID="Label3" runat="server" Text="" Style="text-align: left; float: left;"></asp:Label></li>
                <li class="list-group-item " style="background-color: #ccc;height:40px">
                    <asp:Label ID="Label4" runat="server" Text="" Style="text-align: left; float: left;"></asp:Label></li>
                <%-- <h2 class="paid">你已缴费！</h2>--%>
                <hr/>
                <ul class="list-group list-group-flush">
                    <li class="list-group-item active" style="background-color: cornflowerblue">可操作项</li>
                    <li class="list-group-item">
                        <asp:Button ID="Button1" runat="server" Text="修改个人信息" OnClick="Button1_Click" />
                        (注意：您只有一次修改个人信息的机会)</li>
                    <li class="list-group-item">
                        <asp:Button ID="Button2" runat="server" Text="信息反馈" OnClick="Button2_Click" />
                        <asp:TextBox ID="TextBox1" runat="server" Height="60px" Width="300px" Style="margin-left: 10px;"></asp:TextBox>
                    </li>
                </ul>
        </div>
        <script>
            postData('http://example.com/answer', { answer: 42 })
                .then(data => console.log(data)) // JSON from `response.json()` call
                .catch(error => console.error(error))

            function postData(url, data) {
                // Default options are marked with *
                return fetch(url, {
                    body: JSON.stringify(data), // must match 'Content-Type' header
                    cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
                    credentials: 'same-origin', // include, same-origin, *omit
                    headers: {
                        'user-agent': 'Mozilla/4.0 MDN Example',
                        'content-type': 'application/json'
                    },
                    method: 'POST', // *GET, POST, PUT, DELETE, etc.
                    mode: 'cors', // no-cors, cors, *same-origin
                    redirect: 'follow', // manual, *follow, error
                    referrer: 'no-referrer', // *client, no-referrer
                })
                    .then(response => response.json()) // parses response to JSON
            }
        </script>
    </form>
</body>
</html>


