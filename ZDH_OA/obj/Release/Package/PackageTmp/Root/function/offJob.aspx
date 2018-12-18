<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="offJob.aspx.cs" Inherits="ZDH_OA.Root.function.offJob" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>管理员界面</title>
    <script src="../../Scripts/bootstrap.min.js"></script>
    <script src="../../Scripts/jquery-3.0.0.min.js"></script>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../www/form.css" rel="stylesheet" />
    <style>
        #add_user .input-group-text {
            text-align: center;
            width: 90px;
        }

        .input-group-text {
            display: block;
        }

        h2 {
            text-align: center;
            margin-bottom: 24px;
        }

        #master {
            display: none;
        }

        .table {
            margin-top: 20px;
            width: 402px;
        }

        td {
            width: 200px;
        }

        .month {
            position: absolute;
            top: 20px;
            left: 500px;
            width: 500px;
            margin: 30px auto;
        }

        .welcome {
            position: absolute;
            right: 50px;
            top: 10px;
            text-align: center;
            margin: 0 auto;
        }

        #logout {
            position: absolute;
            right: 0;
        }

        .biankuang {
            padding: 5px 5px 5px 5px;
            box-shadow: 0px 1px 3px rgba(34, 25, 25, 0.2);
            background-color: #ededed;
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
<body>
    <div>
        <div class="container">
            <form id="add_user" runat="server">
                <!--员工离职-->
                <h2 style="position: absolute; top: 70px; left: 180px" class="biankuang">员工离职</h2>
                <div style="position: absolute; top: 120px; left: 100px; height: 157px" class="biankuang">
                    <!--用户名-->
                    <div class="input-group mb-3">
                        <div class="input-group-append">
                            <span class="input-group-text" id="offusername">用户名</span>
                        </div>
                        <asp:TextBox runat="server" ID="off_username" Class="form-control" placeholder="Username" aria-describedby="basic-addon1" />
                    </div>
                    <!--在职状态-->
                    <div class="form-group">
                        <label for="jobsta">工作状态</label>
                        <select class="form-control" id="jobstatus" name="jobstatus">
                            <option value="1">在职</option>
                            <option value="0">离职</option>
                        </select>
                    </div>
                    <!--提交-->
                    <div class="submit" style="position: absolute; left: 110px;">
                        <dx:ASPxButton ID="submit" runat="server" Text="添加" Width="58px" Height="40px" OnClick="submit_Click" />
                    </div>
                </div>

                <!--列表展示-->
            <div class="month">
                <asp:Repeater ID="Username_Repeater" runat="server">
                    <HeaderTemplate>
                        <table class="table table-hover table-bordered">
                            <thead>
                                <tr>
                                    <td style="text-align:center;max-width:20px">用户名</td>
                                    <td style="text-align:center">密码</td>
                                    <td style="min-width: 150px;">员工姓名</td>
                                    <td style="min-width: 150px">
                                        <div style="text-align:center">在职状态</div>
                                        <div style="text-align:center">1:在职</div>
                                        <div style="text-align:center">0:离职</div>
                                    </td>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <td><%#Eval("username") %></td>
                                <td><%#Eval("password") %></td>
                                <td style="width: 90px"><%#Eval("name") %></td>
                                <td><%#Eval("on_job") %></td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            </form>
        </div>
    </div>
</body>
</html>