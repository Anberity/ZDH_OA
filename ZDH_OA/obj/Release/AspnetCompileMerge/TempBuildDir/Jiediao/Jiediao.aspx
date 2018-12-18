<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Jiediao.aspx.cs" Inherits="ZDH_OA.Jiediao.Jiediao" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="https://cdn.bootcss.com/bootstrap/4.1.0/css/bootstrap.min.css" />
    <style>
        body {
            margin: 0;
            overflow: auto;
        }

        #Tab {
            width: 100%;
            height: 100%;
            padding: 0;
            margin: 0;
        }

        #list-tab2, #list-tab3 {
            display: none;
        }

        #mainFrame {
            min-width: 1000px;
            min-height: 600px;
        }

        a {
            color: #000;
        }

        #list-tab {
            display: block;
        }

        .logo {
            width: 273px;
            height: 60px;
            margin-top: 10px;
            margin-left: 10px;
        }

        .clearfix:after {
            display: block;
            content: none;
            clear: both;
        }

        .left {
            float: left;
            width: 280px;
            margin-right: 20px;
        }

        .right {
            float: left;
        }

        .welcome {
            position: absolute;
            left: 1250px;
            top: 50px;
        }

        .onj {
            position: absolute;
            left:300px;
            top:200px;
        }

        #logout {
            position: absolute;
            right: 0;
        }
        .biankuang {
            padding: 5px 5px 5px 5px;
            box-shadow: 0px 1px 3px rgba(34, 25, 25, 0.2);
            background:#ededed;
        }
    </style>
</head>
<body>
    <div id="Tab">
        <form runat="server">
            <div class="biankuang" style="position: absolute;left:300px;top:200px;width:500px">
                <h5 id="tran" style="width: 500px;text-align:center;margin-top:10px;margin-bottom:30px"></h5>
                <div style="text-align:center;margin-bottom:10px">
                    <dx:ASPxButton Text="借调结束" runat="server" ID="OnJob" Theme="MaterialCompact" Width="58px" Height="40px" OnClick="OnJob_Click" />
                </div>
            </div>
        </form>
    </div>
</body>
<script src="https://cdn.bootcss.com/jquery/3.2.1/jquery.min.js"></script>
<script src="https://cdn.bootcss.com/popper.js/1.12.5/umd/popper.min.js"></script>
<script src="https://cdn.bootcss.com/bootstrap/4.1.0/js/bootstrap.min.js"></script>
<script>
    function IFrameReSize(iframename) {
        var pTar = document.getElementById(iframename);
        if (pTar) {  //ff
            if (pTar.contentDocument && pTar.contentDocument.body.offsetHeight) {
                pTar.height = pTar.contentDocument;
            } //ie
            else if (pTar.Document && pTar.Document.body.scrollHeight) {
                pTar.height = pTar.Document;
            }
        }
    }
    $(document).ready(function () {
        $('#tianxie').click(function () {
            $('#tianxie').find('.box').toggle();
        })
        $('#tianxie').find('.first span').click(function (e) {
            $('#tianxie').find('.first span').attr("class", "list-group-item list-group-item-action");
            $('#tianxie').find('.first span').eq($(this).index()).attr("class", "list-group-item list-group-item-action active");
            e.stopPropagation();
        });
        $('#box').find('.lis').click(function () {
            $('#box').find('div.box').css('display', 'none')

        });

        $('span.logout').click(function () {
            if (confirm("您确定退出吗？")) {
                window.location.href = 'Default.aspx';
            }

        })
    });
</script>
</html>