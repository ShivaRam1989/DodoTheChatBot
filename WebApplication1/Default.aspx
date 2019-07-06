<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .styleBody {
            background-image: url('/Content/IQ-launch-screen-1024x768.png');
            background-repeat: no-repeat;
            background-attachment: fixed;
            background-position: center;
            height: 999px;
        }


        .btn {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            -ms-transform: translate(-50%, -50%);
            background-color: #ec2027;
            color: white;
            font-size: 30px;
            padding: 12px 24px;
            border: none;
            cursor: pointer;
            border-radius: 50px;
            height: 100px;
            width: 200px;
        }
    </style>
</head>
<body class="styleBody">
    <div >
      <button class="btn" id="btn_launch" onclick="btn_launch_Click">LAUNCH</button>
       </div>
   <%-- <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl_confirmation" runat="server"></asp:Label>
            <br />
            <br />
        </div>
        <div id="app" runat="server">
            <asp:Button ID="btn_launch" runat="server" Text="Start" OnClick="btn_launch_Click" />
        </div>
    </form>--%>
</body>
</html>