<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Belatrix.Exercice.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Belatrix exercice</title>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <header>
        <div class="container">
            <h1>Belatrix Job Logger</h1><br />
        </div>
    </header>
    <section>
        <div class="container">
            <form id="form1" runat="server">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtMessage" CssClass="form-control" placeholder="Insert log message here..." />
                </div>
                <div class="form-group">
                    <label class="radio-inline">
                        <asp:RadioButton runat="server" ID="rbLogMessage" Text="Message" Checked="true" GroupName="LogTypeGroup" />
                    </label>
                    <label class="radio-inline">
                        <asp:RadioButton runat="server" ID="rbLogWarning" Text="Warning" GroupName="LogTypeGroup" />
                    </label>
                    <label class="radio-inline">
                        <asp:RadioButton runat="server" ID="rbLogError" Text="Error" GroupName="LogTypeGroup" />
                    </label>
                </div>
                <div class="form-group">
                    <label class="checkbox-inline">
                        <asp:CheckBox runat="server" ID="ckLogToDatabase" Text="Log to Database" />
                    </label>
                    <label class="checkbox-inline">
                        <asp:CheckBox runat="server" ID="ckLogToTextfile" Text="Log to Textfile" />
                    </label>
                    <label class="checkbox-inline">
                        <asp:CheckBox runat="server" ID="ckLogToConsole" Text="Log to Console" />
                    </label>
                </div>
                <div class="form-group">
                    <asp:Button runat="server" ID="btnLog" CssClass="btn btn-primary" Text="Log" OnClick="btnLog_Click" />
                </div>
                <div class="form-group">
                    <asp:Label runat="server" ID="lblMessage" />
                </div>
            </form>
        </div>
    </section>
</body>
</html>
