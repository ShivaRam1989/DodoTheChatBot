<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl_confirmation" runat="server"></asp:Label>
            <br />
            <br />
        </div>
        <div id="app" runat="server">
            <asp:Button ID="btn_launch" runat="server" Text="Start" OnClick="btn_launch_Click" />
        </div>
    </form>
</body>
</html>