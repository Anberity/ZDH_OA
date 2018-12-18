<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LingXing.aspx.cs" Inherits="ZDH_OA.Employee.form.LingXing" %>

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
                <h5>修改/删除索引</h5>
                <h6 style="color: red; font-weight: bold">序号自动生成，填写工作量时不用填写，仅修改及删除时填写！！！</h6>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="index">序号</span>
                    </div>
                    <asp:TextBox runat="server" ID="add_index" class="form-control" placeholder="Index" aria-describedby="basic-addon1" />
                    <dx:ASPxButton ID="add" runat="server" Theme="Material" Style="margin-left: 9px" Text="确认" Width="58px" Height="40px" margin="3px" OnClick="add_Click" />
                </div>
                <div class="line"></div>
                <h5>填写</h5>
                <!--本月出差天数-->
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="business">本月出差天数</span>
                    </div>
                    <asp:TextBox runat="server" ID="add_business" class="form-control" placeholder="Business" aria-describedby="basic-addon1" />
                </div>
                <!--技术交流天数-->
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="technical">技术交流天数</span>
                    </div>
                    <asp:TextBox runat="server" ID="add_technical" class="form-control" placeholder="Technical" aria-describedby="basic-addon1" />
                </div>
                <!--其他零星工日-->
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="others">其他零星工日</span>
                    </div>
                    <asp:TextBox runat="server" ID="add_others" class="form-control" placeholder="Others" aria-describedby="basic-addon1" />
                </div>

                <!--备注-->
                <h5>备注</h5>
                <div class="input-group mb-3 remarksbox">
                    <asp:TextBox runat="server" TextMode="MultiLine" ID="add_remarks" class="form-control" placeholder="Remarks" aria-describedby="basic-addon1" />
                </div>
                <div class="line"></div>
                <!--本次工作量填写及修改按钮-->
                <div id="box">
                    <!--修改-->
                    <div class="modifybox">
                        <dx:ASPxButton runat="server" ID="modifybtn" Text="修改" Width="78px" Height="40px" BackColor="#ffc107" OnClick="modifybtn_Click" Theme="MaterialCompact"></dx:ASPxButton>
                    </div>
                    <!--删除-->
                    <div class="delete">
                        <dx:ASPxButton runat="server" Text="删除" Theme="MaterialCompact" ID="delete" Width="78px" BackColor="#dc3545" Font-Size="Medium" Height="40px" OnClick="delete_Click"></dx:ASPxButton>
                    </div>
                    <!--增加-->
                    <div class="submit">
                        <dx:ASPxButton runat="server" Text="增加" Theme="MaterialCompact" ID="submit" Width="78px" Height="40px" OnClick="submit_Click"></dx:ASPxButton>
                    </div>
                </div>
            </form>
        </div>
    </div>
</body>
<script src="../../www/regexp.js"></script>
<script>
    const add_indexID = "<%=add_index.ClientID%>";
    const add_businessID = "<%=add_business.ClientID%>";
    const add_technicalID = "<%=add_technical.ClientID%>";
    const add_othersID = "<%=add_others.ClientID%>";

    const add_index = document.getElementById(add_indexID);
    const add_business = document.getElementById(add_businessID);
    const add_technical = document.getElementById(add_technicalID);
    const add_others = document.getElementById(add_othersID);
    const submitBtn = document.getElementsByClassName('submit')[0];

    var arr = [add_business, add_technical, add_others];

    add_index.onblur = function () {
        ifIndex(this);
    };
    submitBtn.onclick = function () {
        var arr2 = [];
        var z = /^[0-9]+.?[0-9]*$| (^\s*)|(\s*$) /;
        let s;
        for (let i = 0; i < arr.length; i++) {
            //console.log(arr[i].value + ":" + typeof (arr[i].value));
            if (arr[i].value != "") {
                s = z.test(arr[i].value);
            } else {
                s = true;
            }
            arr2.push(s);
        }
        //console.log(arr2 + ":" + arr2.length);
        for (let i = 0; i < arr2.length; i++) {
            if (arr2[i] == false || arr2[i] == "false") {
                arr[i].value = "";
                alert("请输入有效数字");
                return false;
            }
        }
    };
</script>
</html>
