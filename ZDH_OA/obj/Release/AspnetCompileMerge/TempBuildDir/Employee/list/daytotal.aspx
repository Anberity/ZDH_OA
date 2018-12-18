<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="daytotal.aspx.cs" Inherits="ZDH_OA.Employee.list.daytotal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>工作量统计汇总</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        .col {
            padding-left: 50px;
        }

        .table {
            margin-top: 20px;
            width: 402px;
        }

        td {
            width: 200px;
        }

        .month {
            position: relative;
            width: 400px;
            margin: 30px auto;
        }

        #month {
            width: 80px;
        }

        #year, #person_year {
            width: 120px;
        }

        #submit {
            position: absolute;
            left: 162px;
            top: 74px;
            height: 36px;
        }

        #confirm, #person_submit {
            position: absolute;
            left: 300px;
            top: 75px;
            height: 36px;
            bottom: 147px;
        }

        #close {
            position: absolute;
            right: 50px;
            top: 120px;
            height: 36px;
        }

        .year {
            padding-left: 170px;
        }

        .welcome {
            position: absolute;
            right: 50px;
            top: 20px;
        }

        .logo {
            margin-bottom: 80px;
        }

        #logout {
            position: absolute;
            right: 0;
        }
    </style>
</head>
<body style="background-color: #ededed">
    <form id="form1" runat="server">
        <div style="font-size: 30px; position: relative; left: 550px; top: 10px">工作量统计汇总</div>
        <div class="row">
            <div class="month col">
                <div class="form-group ">
                    <h3>本年员工月工作量汇总</h3>
                    <label for="month">选择月份</label>
                    <select class="form-control" id="month" runat="server">
                        <option>1</option>
                        <option>2</option>
                        <option>3</option>
                        <option>4</option>
                        <option>5</option>
                        <option>6</option>
                        <option>7</option>
                        <option>8</option>
                        <option>9</option>
                        <option>10</option>
                        <option>11</option>
                        <option>12</option>
                    </select>
                </div>
                <dx:ASPxButton ID="submit" runat="server" Theme="Material" Width="40px" Text="确认" OnClick="submit_Click" />
                <asp:Repeater ID="Month_Repeater" runat="server">
                    <HeaderTemplate>
                        <table class="table table-hover table-bordered">
                            <thead>
                                <tr>
                                    <td>员工姓名</td>
                                    <td>工日之和</td>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <td><%#Eval("name") %></td>
                                <td><%#Eval("work_day") %></td>
                            </tr>

                        </tbody>


                    </ItemTemplate>
                    <FooterTemplate>
                        <tfoot>
                            <tr>
                                <td colspan="2">总计:<%= HttpContext.Current.Session["numberMonth"] %></td>
                            </tr>
                        </tfoot>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>

            <div class="month col year">
                <div class="form-group " >
                    <div style="width:280px">
                        <h3>历年员工年工作量汇总</h3>
                    </div>
                    <label for="person_year">选择年份</label>
                    <select class="form-control" id="person_year" runat="server">
                        <option>2018</option>
                        <option>2017</option>
                        <option>2016</option>
                        <option>2015</option>
                        <option>2014</option>
                        <option>2013</option>
                        <option>2012</option>
                        <option>2011</option>
                        <option>2010</option>
                        <option>2009</option>
                        <option>2008</option>
                        <option>2007</option>
                    </select>
                </div>
                <dx:ASPxButton ID="person_submit" runat="server" Text="确认" Theme="Material" Width="40px" OnClick="person_submit_Click" />
                <asp:Repeater ID="Person_Repeater" runat="server">
                    <HeaderTemplate>
                        <table class="table table-hover table-bordered">
                            <thead>
                                <tr>
                                    <td>员工姓名</td>
                                    <td>工日之和</td>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <td><%#Eval("name") %></td>
                                <td><%#Eval("summary_user") %></td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                    <FooterTemplate>
                        <tfoot>
                            <tr>
                                <td colspan="2">总计:<%= HttpContext.Current.Session["userYear"] %></td>
                            </tr>
                        </tfoot>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>

            <div class="month col year">
                <div class="form-group ">
                    <div style="width: 280px">
                        <h3>历年月工作量汇总</h3>
                    </div>
                    <label for="year">选择年份</label>
                    <select class="form-control" id="year" runat="server">
                        <option>2018</option>
                        <option>2017</option>
                        <option>2016</option>
                        <option>2015</option>
                        <option>2014</option>
                        <option>2013</option>
                        <option>2012</option>
                        <option>2011</option>
                        <option>2010</option>
                        <option>2009</option>
                        <option>2008</option>
                        <option>2007</option>
                    </select>
                </div>
                <dx:ASPxButton ID="confirm" runat="server" Text="确认" Theme="Material" Width="40px" OnClick="confirm_Click" />
                <asp:Repeater ID="Year_Repeater" runat="server">
                    <HeaderTemplate>
                        <table class="table table-hover table-bordered">
                            <thead>
                                <tr>
                                    <td>月份</td>
                                    <td>工日之和</td>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <td><%#Eval("month") %></td>
                                <td><%#Eval("summary") %></td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                    <FooterTemplate>
                        <tfoot>
                            <tr>
                                <td colspan="2">总计:<%= HttpContext.Current.Session["numberYear"] %></td>
                            </tr>
                        </tfoot>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</body>
</html>
