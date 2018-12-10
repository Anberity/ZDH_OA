<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updateInformation.aspx.cs" Inherits="ZDH_OA.Root.function.updateInformation" %>

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
            top: 260px;
            left: 300px;
            width: 400px;
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
                <!--员工信息修改-->
                <h2 style="position: absolute; top: 70px; left: 490px" class="biankuang">员工信息修改</h2>
                <div style="position: absolute; top: 120px; left: 100px; height: 380px; width: 300px">
                    <div class="biankuang" style="width: 1005px; height: 160px;">
                        <!--用户名-->
                        <div class="input-group mb-3" style="position: absolute;">
                            <div class="input-group-prepend">
                                <span class="input-group-text" id="username1">用户名</span>
                            </div>
                            <asp:TextBox runat="server" ID="Username" class="form-control" placeholder="Username" aria-describedby="basic-addon1" />
                        </div>
                        <!--查询-->
                        <div class="submit" style="position: absolute; top: 5px; left: 380px;">
                            <dx:ASPxButton ID="Select" runat="server" Text="查询" Width="58px" Height="40px" OnClick="Select_Click" />
                        </div>
                        <!--密码-->
                        <div class="input-group mb-3" style="position: absolute; top: 60px;">
                            <div class="input-group-prepend">
                                <span class="input-group-text" id="pwd">密码</span>
                            </div>
                            <asp:TextBox runat="server" ID="Pwd" class="form-control" placeholder="Password" aria-describedby="basic-addon1" />
                        </div>
                        <!--真实姓名-->
                        <div class="input-group mb-3" style="position: absolute; top: 60px; left: 350px;">
                            <div class="input-group-prepend">
                                <span class="input-group-text" id="peopleName">姓名</span>
                            </div>
                            <asp:TextBox runat="server" ID="PeopleName" class="form-control" placeholder="RealName" aria-describedby="basic-addon1" />
                        </div>
                        <!--员工编号-->
                        <div class="input-group mb-3" style="position: absolute; top: 5px; left: 700px;">
                            <div class="input-group-prepend">
                                <span class="input-group-text" id="staffNumber">员工编号</span>
                            </div>
                            <asp:TextBox runat="server" ID="StaffNumber" class="form-control" placeholder="StaffNumber" aria-describedby="basic-addon1" />
                        </div>
                        <!--小组-->
                        <div class="input-group mb-3" style="position: absolute; top: 114px;">
                            <div class="input-group-prepend">
                                <span class="input-group-text" id="Group">小组</span>
                            </div>
                            <select runat="server" class="form-control" id="group2" name="group2">
                                <option value="1">自动化</option>
                                <option value="2">软件</option>
                                <option value="3">营销</option>
                                <option value="0">管理层</option>
                            </select>
                        </div>
                        <!--职位-->
                        <div class="input-group mb-3" style="position: absolute; top: 114px; left: 320px; width: 360px">
                            <div class="input-group-prepend">
                                <lable class="input-group-text" for="Post">职位</lable>
                            </div>
                            <select runat="server" class="form-control" id="Post" name="Post">
                                <option value="1">主任</option>
                                <option value="2">副主任</option>
                                <option value="18">职员</option>
                            </select>
                            <select runat="server" class="form-control" id="fzr" name="fzr" style="width: 80px;">
                                <option value="2">项目管理副主任</option>
                                <option value="3">设计管理副主任</option>
                                <option value="4">编程管理副主任</option>
                                <option value="5">软件管理副主任</option>
                                <option value="6">仪表管理副主任</option>
                            </select>
                        </div>
                    </div>
                    <!--借调状态-->
                    <div class="input-group mb-3" style="position: absolute; top: 60px; left: 700px;">
                        <div class="input-group-prepend">
                            <span class="input-group-text" id="jieDiao">借调状态</span>
                        </div>
                        <asp:TextBox runat="server" ID="JieDiao" class="form-control" placeholder="jieDiao" aria-describedby="basic-addon1" />
                    </div>
                    <!--在职状态-->
                    <div class="input-group mb-3" style="position: absolute; top: 114px; left: 700px;">
                        <div class="input-group-prepend">
                            <span class="input-group-text" id="onJob">在职状态</span>
                        </div>
                        <asp:TextBox runat="server" ID="OnJob" class="form-control" placeholder="OnJob" aria-describedby="basic-addon1" />
                    </div>
                    <!--修改-->
                    <div class="submit" style="position: absolute; top: 5px; left: 550px;">
                        <dx:ASPxButton ID="submit" runat="server" Text="修改" Width="58px" Height="40px" OnClick="submit_Click" />
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
<script>
    $(document).ready(function () {

        $("#job").change(function () {
            //console.log($("#job").val());
            if ($("#job").val() == "2") {
                //console.log("fzr")
                $("#master").fadeIn("slow");
            } else {
                $("#master").hide();
            }
        })

        $("#Post").change(function () {
            if ($("#Post").val() == "2") {
                $("#fzr").fadeIn("slow");
            } else {
                $("#fzr").hide();
            }
        })

        $('span.logout').click(function () {
            if (confirm("您确定退出吗？")) {
                window.location.href = 'Default.aspx';
            }

        })


    })
</script>
</html>
