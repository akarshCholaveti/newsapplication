<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetNews.aspx.cs" Inherits="NewsWebApplication.GetNews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 987px">
    
        <asp:Label ID="Label1" runat="server" Text="Enter the topic:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="GetNews" />
        <asp:BulletedList ID="BulletedList1" runat="server" BulletStyle="Numbered">
        </asp:BulletedList>
        <br /><p>
        <asp:Label ID="Label2" runat="server" Text="Enter the Link numbers to be saved (separated by commas Eg:1,2):"></asp:Label></p>
        <p>
        <asp:TextBox ID="TextBox2" runat="server" Width="460px"></asp:TextBox>
        </p>
        <p>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="SaveWebPages" />
        </p>
        <p>
            <asp:BulletedList ID="BulletedList2" runat="server" BulletStyle="NotSet">
        </asp:BulletedList>
        </p>

    </div>
    </form>
</body>
</html>
