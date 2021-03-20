<%@ Page Language="C#" AutoEventWireup="true" CodeFile="feedbackdatacheck.aspx.cs" Inherits="page_feedbackdatacheck" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../css/bootstrap.min.css">
    <style>
        body {
            background-color: rgba(0,0,0,0.1);
        }

        #GridView1{
            margin:40px auto;
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

                table th, table td {
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
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"  OnRowCommand="GridView1_RowCommand">
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
                    <asp:BoundField DataField="_Comment"
                        ReadOnly="true"
                        HeaderText="反馈信息" />
                    <asp:ButtonField HeaderText="确认复核" ButtonType="Button" Text="确认复核" CommandName="FH" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
