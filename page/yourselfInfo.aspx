<%@ Page Language="C#" AutoEventWireup="true" CodeFile="yourselfInfo.aspx.cs" Inherits="page_yourselfInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../css/bootstrap.min.css">
    <style>
        body {
            background-color: rgba(0,0,0,0.1);
        }

        #form1 {
            display: block;
            color: #fff;
            width: 50%;
            margin: 30vh auto;
        }

            #form1 table th, #form1 table td {
                color: #fff;
                padding: 4px 8px;
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
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="_Name"
                        ReadOnly="true"
                        HeaderText="姓名" />
                    <asp:BoundField DataField="ID_Worker"
                        ReadOnly="true"
                        HeaderText="工号" />
                    <asp:BoundField DataField="_Position"
                        ConvertEmptyStringToNull="true"
                        HeaderText="职位" />
                    <asp:BoundField DataField="_PhoneNum"
                        ConvertEmptyStringToNull="true"
                        HeaderText="手机号" />
                    <asp:BoundField DataField="_Email"
                        ConvertEmptyStringToNull="true"
                        HeaderText="邮箱地址" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
