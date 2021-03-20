<%@ Page Language="C#" AutoEventWireup="true" CodeFile="feedBack.aspx.cs" Inherits="page_feedBack" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>个人信息修改</title>
    <link href="../css/feedback.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="feedback1">
                <asp:Label ID="Label10" runat="server" Text="个人信息修改界面"></asp:Label>
            </div>
            <br />
            <div class="feedback2">
                <asp:Label ID="Label11" runat="server" Text=""></asp:Label>
                <br/>
                <br/>
                <asp:Label ID="Label3" runat="server" Text="姓名："></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server"  Height="18px" ></asp:TextBox>
                <br/>
                <br/>
                <asp:Label ID="Label4" runat="server" Text="年龄：" ></asp:Label><asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox>
                <br/>
                <br/>
                <asp:Label ID="Label5" runat="server" Text="性别："></asp:Label><asp:Label ID="Label1" runat="server" ></asp:Label><asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                <br/>
                <br/>
                <asp:Label ID="Label6" runat="server" Text="民族："></asp:Label><asp:TextBox ID="TextBox4" runat="server"  ></asp:TextBox>
                <br/>
                <br/>
                <asp:Label ID="Label7" runat="server" Text="地址："></asp:Label><asp:TextBox ID="TextBox5" runat="server"  ></asp:TextBox>
                <br/>
                <br/>
                <asp:Label ID="Label8" runat="server" Text="手机号：" ></asp:Label><asp:TextBox ID="TextBox6" runat="server" ></asp:TextBox>
                <br/>
                <br/>
                <asp:Label ID="Label9" runat="server" Text="电子邮箱："></asp:Label><asp:TextBox ID="TextBox7" runat="server"  ></asp:TextBox>
                <br/>
            </div>
            <br/>
            <hr />
            <br/>
            <div class="buttun">
                <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />
            </div>
            
        </div>
    </form>
</body>
</html>
