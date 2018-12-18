<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ZDH_OA.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>自动化工程技术公司工作量汇总查询系统</title>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        .input-group {
            width: 350px;
            margin: 20px auto;
        }

        #basic-addon2 {
            padding: 6px 19px;
        }

        .btnbox {
            display: flex;
            width: 350px;
            margin: 0 auto;
        }

        .btn {
            display: block;
            justify-content: space-between;
            margin-left: 70px;
            width: 58px;
            height: 38px;
        }

        .btn-info {
            color: #fff;
            background-color: #5bc0de;
            border-color: #46b8da;
        }

            .btn-info.focus, .btn-info:focus {
                color: #fff;
                background-color: #31b0d5;
                border-color: #1b6d85;
            }

        #changePass {
            width: 90px;
        }

        .h1 {
            text-align: center;
            margin-bottom: 20px;
        }

        .logo {
            width: 273px;
            height: 60px;
            margin-top: 10px;
            margin-left: 10px;
        }

        .jumbotron {
            padding: 160px 0;
            background-color: white;
            width: 880px;
            height: 320px;
            align: center;
            line-height: 500px;
            overflow: hidden;
            margin-top: 230px;
            margin-left: auto;
            margin-right: auto;
            box-shadow: 0px 1px 3px rgba(34, 25, 25, 0.2);
        }
    </style>
</head>
<body style="background-color: #dddddd" draggable="false">
    <div style="position: relative; left: 0px; top: 0px">
        <div class="jumbotron">
            <div style="position: absolute; top: 0px">
                <h3 style="width: 900px; position: absolute; top: -55px; margin-left: auto; margin-right: auto; overflow: hidden;">
                    <img src="www/img/logo.png" draggable="false" />
                    <a style="position: absolute; top: 19px" draggable="false">自动化工程技术公司工作量汇总查询系统</a></h3>
                <h1>
                    <img src="www/img/background.jpg" style="width: 450px; height: 320px" draggable="false"></h1>
                <div style="width: 550px; position: absolute; left: 350px; top: 100px">
                    <div style="font-size: 12px;">- 版权所有 (C)2018 山东省冶金设计院股份有限公司 -</div>
                    <div style="font-size: 12px; position: absolute; left: -60px; top: 20px">Copyright (C) 2018 Shandong Province Metallurgical Engineering Co., Ltd.</div>
                </div>
            </div>

            <h3 style="width: 200px; position: relative; left: 580px; top: -120px">用户登录</h3>
            <form id="form1" runat="server">
                <div class="input-group mb-3" style="position: relative; left: 220px; top: -120px">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="basic-addon1">用户名</span>
                    </div>
                    <asp:TextBox runat="server" ID="UserName" class="form-control" placeholder="Username" aria-describedby="basic-addon1" />
                </div>
                <div class="input-group mb-3" style="position: relative; left: 220px; top: -100px">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="basic-addon2">密码</span>
                    </div>
                    <asp:TextBox runat="server" ID="Password" TextMode="Password"
                        class="form-control" placeholder="Password" aria-describedby="basic-addon1"></asp:TextBox>
                </div>

                <div class="btnbox" style="position: relative; left: 285px; top: -80px">
                    <dx:ASPxButton ID="login" runat="server" Text="登录" Theme="MaterialCompact" Width="58px" Height="40px" OnClick="login_Click" />
                    <dx:ASPxButton ID="changePass" runat="server" Text="修改密码" Theme="MaterialCompact" Style="position: absolute; left: 115px" Width="58px" Height="40px" OnClick="changePass_Click" />
                </div>
        </div>
        </form>
            
    </div>
</body>
</html>
