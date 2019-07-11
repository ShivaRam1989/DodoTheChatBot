<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication1.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/Site.css" rel="stylesheet" />
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
            <asp:Button ID="btn_video_play" runat="server" Text="Click To Play" OnClick="btn_video_play_Click" />
            <asp:Button ID="btn_pause" runat="server" Text="Pause" OnClick="btn_pause_Click" />
            <asp:Button ID="btn_stop" runat="server" Text="Stop" OnClick="btn_stop_Click" />
        </div>

        <br />
        <div>
            <asp:Button ID="btn_1_EntryVideo" runat="server" Text="1_EntryVideo" OnClick="btn_1_EntryVideo_Click" />
            <asp:Button ID="btn_2_AzadPratikaEntry" runat="server" Text="2_AzadPratikaEntry" OnClick="btn_2_AzadPratikaEntry_Click" />
            <asp:Button ID="btn_3_gaurdxstart" runat="server" Text="3_gaurdxstart" OnClick="btn_3_gaurdxstart_Click" />
        </div>
        <br />
        <div>
            <asp:Button ID="btn_4_gaurdxvideo" runat="server" Text="4_gaurdxvideo" OnClick="btn_4_gaurdxvideo_Click" />
            <asp:Button ID="btn_5_marketdata" runat="server" Text="5_marketdata" OnClick="btn_5_marketdata_Click" />
            <asp:Button ID="btn_6_techvideo" runat="server" Text="6_techvideo" OnClick="btn_6_techvideo_Click" />
        </div>
        <br />
        <div>
            <asp:Button ID="btn_7_MD1" runat="server" Text="7_MD1" OnClick="btn_7_MD1_Click" />
            <asp:Button ID="btn_8_MD2" runat="server" Text="8_MD2" OnClick="btn_8_MD2_Click" />
            <asp:Button ID="btn_9_MD3" runat="server" Text="9_MD3" OnClick="btn_9_MD3_Click" />
        </div>
        <br />
        <div>
            <asp:Button ID="btn_10_anyquestions" runat="server" Text="10_anyquestions" OnClick="btn_10_anyquestions_Click" />
            <asp:Button ID="btn_11_thankyou" runat="server" Text="11_thankyou" OnClick="btn_11_thankyou_Click" />
            <asp:Button ID="btn_12_RPAVideo" runat="server" Text="12_RPAVideo" OnClick="btn_12_RPAVideo_Click" />
        </div>
        <br />
        <%--        <div>
            <b>
                <asp:Label ID="lbl_timeJump" runat="server" Text="Jump to Time"></asp:Label></b>
            <asp:TextBox ID="txt_timeJump" runat="server" placeholder="Jump to Time"></asp:TextBox>
            <asp:Button ID="btn_timeJump" runat="server" Text="Click To Jump Time" OnClick="btn_timeJump_Click" />
        </div>--%>
        <br />
        <div>
            <asp:Button ID="btn_1_AzadPpt" runat="server" Text="1_AzadPpt" OnClick="btn_1_AzadPpt_Click" />
            <asp:Button ID="btn_2_RPAPpt" runat="server" Text="2_RPAPpt" OnClick="btn_2_RPAPpt_Click" />
            <asp:Button ID="btn_3_GaurdxPpt" runat="server" Text="3_GaurdxPpt" OnClick="btn_3_GaurdxPpt_Click" />
        </div>
        <br />
        <div>
            <asp:Button ID="btn_4_MarketDataPpt" runat="server" Text="4_MarketData" OnClick="btn_4_MarketDataPpt_Click" />
            <asp:Button ID="btn_5_DummyPpt" runat="server" Text="5_Dummy" OnClick="btn_5_DummyPpt_Click" />
        </div>
        <br />
        <div>
            <asp:Button ID="StartListening" runat="server" OnClick="Listen_Click" Text="Listen" />
            <asp:Button ID="StopListen" runat="server" OnClick="StopListen_Click" Text="StopListen" />
        </div>
    </form>
</body>
</html>
