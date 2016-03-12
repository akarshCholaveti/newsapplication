<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SavePage.aspx.cs" Inherits="NewsWebApplication.SavePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 526px">
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:BulletedList ID="BulletedList1" runat="server" Height="478px" BulletStyle="Numbered">
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
    </form>
</body>
</html>
