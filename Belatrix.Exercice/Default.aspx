<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Belatrix.Exercice.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox runat="server" ID="txtMessage" />
        <asp:Button runat="server" ID="btnToDatabse" Text="To Database" OnClick="btnToDatabse_Click" />
        <asp:Button runat="server" ID="btnToTextfile" Text="To Textfile" OnClick="btnToTextfile_Click" />
        <asp:Button runat="server" ID="btnToConsole" Text="To Console" OnClick="btnToConsole_Click" />
    </div>
    </form>
</body>
</html>
