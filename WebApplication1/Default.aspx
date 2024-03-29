﻿<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .styleBody {
            background-image: url('/Content/IQ-launch-screen-1024x768-V2.jpg');
            background-repeat: no-repeat;
            background-attachment: fixed;
            background-position: center;
            background-size: contain;
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

        .img {
            height: 200px;
            width: 200px;
            position: absolute;
            top: 45%;
            left: 45%;
        }
    </style>
</head>
<body class="styleBody">
    <form id="form1" runat="server">
        <div>
            <asp:Button class="btn" ID="btn_launch" runat="server" Text="LAUNCH" OnClick="btn_launch_Click" />
        </div>
        <br/>
        <br />
        <asp:ImageButton ID="img_fun" class="img" runat="server" ImageUrl="~/Images/thanks.jpg" OnClick="img_fun_Click" Visible="false"/>
    </form>
</body>
</html>
