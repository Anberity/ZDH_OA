<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePass.aspx.cs" Inherits="ZDH_OA.ChangePass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>修改密码</title>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="www/form.css" rel="stylesheet" />
    <style>
        #add_user .input-group-text{
            text-align:center;
            width:90px;
        }
        .input-group-text{
            display:block;
        }
        h2{
            text-align:center;
            margin-bottom:24px; 
        }
        #add_user #confirm{
            width:100px;
        }
    </style>
</head>
<body>
    <div class="jumbotron jumbotron-fluid" style="background-color:#e9ecef">
        <h2>修改密码</h2>
        <div class="container">
            <form id="add_user" runat="server">
                <!--用户名-->
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="username">用户名</span>
                    </div>
                    <asp:TextBox runat="server" ID="add_username" class="form-control" placeholder="Username" aria-describedby="basic-addon1"/>
                </div>
                <!--旧密码-->
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="password">旧密码</span>
                    </div>
                    <asp:TextBox runat="server" ID="add_userpass" class="form-control" placeholder="Password" aria-describedby="basic-addon1"/>
                </div>
                <!--新密码-->
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="newpassword">新密码</span>
                    </div>
                    <asp:TextBox runat="server" ID="add_newPass" class="form-control" placeholder="NewPass" aria-describedby="basic-addon1"/>
                </div>
                <!--确认新密码-->
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="confirm">确认新密码</span>
                    </div>
                    <asp:TextBox runat="server" ID="add_confirm" class="form-control" placeholder="ConfirmPass" aria-describedby="basic-addon1"/>
                </div>
                <!--提交-->
                <div class="submit" style="position:absolute;right:700px">
                    <dx:ASPxbutton runat="server" Text="确认修改" Height="40px" ID="submit" OnClick="submit_Click"></dx:ASPxbutton>
                </div>
            </form>
        </div>
    </div>
</body>
</html>
