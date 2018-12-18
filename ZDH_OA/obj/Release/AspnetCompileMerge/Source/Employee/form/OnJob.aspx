<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnJob.aspx.cs" Inherits="ZDH_OA.Employee.form.OnJob" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../../Scripts/bootstrap.min.js"></script>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../www/form.css" rel="stylesheet" />
</head>
<body style="background-color:#ededed">
    <div class="jumbotron jumbotron-fluid" style="background-color:#ededed">
        <div class="container">
            <form id="program" runat="server">
                <!--修改索引-->
                <h5>借调状态更改</h5>
                <h6 style="color: red; font-weight: bold">文本框请填写相应借调部门</h6>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="index">借调至</span>
                    </div>
                    <asp:TextBox runat="server" ID="add_index" class="form-control" placeholder="Index" aria-describedby="basic-addon1" />
                    <dx:ASPxButton ID="add" runat="server" Theme="Material" style="margin-left:9px" Text="确认" width="58px" height="40px" margin="3px" OnClick="add_Click"/>
                </div>
            </form>
        </div>
    </div>
</body>
</html>
