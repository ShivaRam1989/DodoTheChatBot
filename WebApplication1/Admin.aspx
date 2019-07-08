<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication1.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Welcome Camper</h2>

        <div>
            <asp:Button ID="btn_launch" runat="server" Text="Launch" OnClick="btn_launch_Click" />
        </div>

        <br />
        <div>
            <b>
                <asp:Label ID="lbl_video" runat="server" Text="Video ID To Play"></asp:Label></b>
            <asp:TextBox ID="txt_videoId" runat="server" placeholder="Type video Id to play"></asp:TextBox>
            <asp:Button ID="btn_video_play" runat="server" Text="Click To Play" OnClick="btn_video_play_Click" />
            <asp:Button ID="btn_pause" runat="server" Text="Pause" OnClick="btn_pause_Click" />
            <asp:Button ID="btn_stop" runat="server" Text="Stop" OnClick="btn_stop_Click" />
        </div>
        <br />
        <div>
            <b>
                <asp:Label ID="lbl_timeJump" runat="server" Text="Jump to Time"></asp:Label></b>
            <asp:TextBox ID="txt_timeJump" runat="server" placeholder="Jump to Time"></asp:TextBox>
            <asp:Button ID="btn_timeJump" runat="server" Text="Click To Jump Time" OnClick="btn_timeJump_Click" />
        </div>
    </form>
</body>
</html>
