<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkDayUpdate.aspx.cs" Inherits="ZDH_OA.Director.WorkDayUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>当月工作量审核</title>
    <link rel='stylesheet prefetch' href='../www/css/reset.css' />
    <link rel="stylesheet" type="text/css" href="../www/css/default.css" />
    <link rel='stylesheet prefetch' href='https://fonts.googleapis.com/css?family=Roboto:100,300,400,500,700,900|Material+Icons' />
    <link rel="stylesheet" type="text/css" href="../www/css/styles.css" />

    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../www/table.css" rel="stylesheet" />
    <style>
        .timebox {
            margin: 20px auto;
            width: 600px;
        }

        .btn-success, .btn-danger {
            font-size: 14px;
            padding-top: 3px;
            padding-bottom: 3px;
        }

        .btn-warning {
            padding-bottom: 3px;
            padding-top: 3px;
            font-size: 14px;
        }

        .tabs {
            margin-top: 20px;
            font-size: 14px;
        }

        #tabs_content .remarks {
            min-width: 100px;
        }

        #tabs_content input {
            max-width: 100px;
        }

        #close {
            position: absolute;
            right: 0px;
            top: 120px;
        }

        #export {
            position: absolute;
            right: 0px;
            top: 160px;
        }

        .welcome {
            position: absolute;
            right: 0px;
        }

        #logout {
            position: absolute;
            right: 0px;
            top: 80px;
        }
    </style>
</head>
<body>
    <form id="form" runat="server">
        <article class="htmleaf-container">
            <div class="tabs">
                <div style="background-color: #72ccf5;position: relative; top: 0px; height: 50px">
                    <ul>
                        <a style="margin: 0 5px; white-space: nowrap; font-size: 28px; position: relative; left: 550px; top: 5px">当月工作量审核</a>
                        <a style="margin: 0 5px; white-space: nowrap; font-size: 22px; position: relative; left: 750px; top: -155px">
                            <dx:ASPxButton ID="export" runat="server" Text="导出" Theme="Material" Width="40px" OnClick="export_Click" />
                        </a>
                    </ul>
                </div>
                <div class="tabs-header">
                    <div class="border"></div>
                    <ul>
                        <li class="active"><a href="#tab-1" tab-id="1" ripple="ripple" ripple-color="#FFF">设计工作量</a></li>
                        <li><a href="#tab-2" tab-id="2" ripple="ripple" ripple-color="#FFF">编程画面工作量</a></li>
                        <li><a href="#tab-3" tab-id="3" ripple="ripple" ripple-color="#FFF">调试工程管理工作量</a></li>
                        <li><a href="#tab-4" tab-id="4" ripple="ripple" ripple-color="#FFF">经营工作量</a></li>
                        <li><a href="#tab-5" tab-id="5" ripple="ripple" ripple-color="#FFF">日常管理工作量</a></li>
                        <li><a href="#tab-6" tab-id="6" ripple="ripple" ripple-color="#FFF">零星工日</a></li>
                        <li><a href="#tab-7" tab-id="7" ripple="ripple" ripple-color="#FFF">本月工日之和</a></li>
                    </ul>
                    <nav class="tabs-nav"><i id="prev" ripple="ripple" ripple-color="#FFF" class="material-icons">&#xE314;</i><i id="next" ripple="ripple" ripple-color="#FFF" class="material-icons">&#xE315;</i></nav>
                </div>
                <div class="tabs-content" id="tabs_content">
                    <div tab-id="1" class="tab active form">
                        <asp:Repeater ID="Design_Repeater" runat="server" OnItemCommand="Design_Repeater_ItemCommand">
                            <HeaderTemplate>
                                <table class="table table-hover table-bordered table-responsive">
                                    <tr>
                                        <td>序号</td>
                                        <td class="realname">姓名</td>
                                        <td>工程号</td>
                                        <td class="projectname">工程名称</td>
                                        <td>
                                            <div>施工图</div>
                                            <div>图纸张数</div>
                                        </td>
                                        <td>
                                            <div>施工图</div>
                                            <div>折合A1</div>

                                        </td>
                                        <td>
                                            <div>施工图折</div>
                                            <div>合总工日</div>
                                        </td>
                                        <td>
                                            <div>本月完成</div>
                                            <div>(工日)</div>
                                        </td>
                                        <td>
                                            <div>技术方案</div>
                                            <div>（工日）</div>
                                        </td>
                                        <td>
                                            <div>基本设计</div>
                                            <div>（工日）</div>
                                        </td>
                                        <td>
                                            <div>专业负责人</div>
                                            <div>（工日）</div>
                                        </td>
                                        <td class="remarks">备注</td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="dr_number" Width="35px" runat="server" Text='<%#Eval("number")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="dr_name" Width="60px" runat="server" Text='<%#Eval("name")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="dr_project_number" Width="90px" runat="server" Text='<%#Eval("project_number")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="dr_project_name" Width="240px" ToolTip='<%#Eval("project_name")%>' runat="server" Text='<%#Eval("project_name")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="dr_drawing_number" Width="60px" runat="server" Text='<%#Eval("drawing_number")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="dr_A1_number" Width="60px" runat="server" Text='<%#Eval("A1_number")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="dr_zhehe_working_day" Width="60px" runat="server" Text='<%#Eval("zhehe_working_day")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="dr_month_day" runat="server" Width="60px" Text='<%#Eval("month_day")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="dr_program_day" runat="server" Width="60px" Text='<%#Eval("program_day")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="dr_basic_design_day" runat="server" Width="60px" Text='<%#Eval("basic_design_day")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="dr_leader" runat="server" Width="60px" Text='<%#Eval("leader")%>' />
                                    </td>
                                    <td style="width: 100px">
                                        <%#Eval("remark") %>
                                    </td>
                                    <td min-width="150px">
                                        <button type="button" class="btn btn-warning change">修改</button>
                                        
                                        <%--修改按钮比较复杂，除了在CommandName传递一个update给后台，标识自己是修改，还要同时传递两个参数一个打印的id，与该行的行数用于发现TextBox--%>
                                        <span class="submit">
                                            <asp:Button runat="server" class="btn btn-success" CommandName="confirm" CommandArgument='<%#(Container as RepeaterItem).ItemIndex%>' Text="确认"
                                                OnClientClick='return confirm("确定此操作吗？")' />
                                            <%--<dx:ASPxButton runat="server" CommandName="confirm" CommandArgument='<%#(Container as RepeaterItem).ItemIndex%>' Text="确认"
                                                OnClientClick='return confirm("确定此操作吗？")' />--%>
                                        </span>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <div tab-id="2" class="tab form tab2">
                        <asp:Repeater ID="Programming_Picture_Repeater" runat="server" OnItemCommand="Programming_Picture_Repeater_ItemCommand">
                            <HeaderTemplate>
                                <table class="table table-hover table-bordered table-responsive">
                                    <tr>
                                        <td>序号</td>
                                        <td>姓名</td>
                                        <td>项目名称</td>
                                        <td>总开关量点数</td>
                                        <td>总模拟量点数</td>
                                        <td>编程/画面</td>
                                        <td>总工日</td>
                                        <td>本月完成工日</td>
                                        <td class="remarks">备注</td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="ppr_number" Width="35px" runat="server" Text='<%#Eval("number")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="ppr_name" Width="70px" runat="server" Text='<%#Eval("name")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="ppr_project_name" Width="340px" ToolTip='<%#Eval("project_name")%>' runat="server" Text='<%#Eval("project_name")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="ppr_digital_number" Width="70px" runat="server" Text='<%#Eval("digital_number")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="ppr_analog_number" Width="70px" runat="server" Text='<%#Eval("analog_number")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="ppr_programing_picture" Width="70px" runat="server" Text='<%#Eval("programing_picture")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="ppr_programing_day" Width="70px" runat="server" Text='<%#Eval("programing_day")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="ppr_month_day" Width="70px" runat="server" Text='<%#Eval("month_day")%>' />
                                    </td>
                                    <td class="remarks">
                                        <%#Eval("remark") %>
                                       
                                    </td>
                                    <td>
                                        <button type="button" class="btn btn-warning change">修改</button>
                                        <%--修改按钮比较复杂，除了在CommandName传递一个update给后台，标识自己是修改，还要同时传递两个参数一个打印的id，与该行的行数用于发现TextBox--%>
                                        <span class="submit">
                                            <asp:Button runat="server" class="btn btn-success" CommandName="confirm" CommandArgument='<%#(Container as RepeaterItem).ItemIndex%>' Text="确认"
                                                OnClientClick='return confirm("确定此操作吗？")' />

                                        </span>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <div tab-id="3" class="tab form">
                        <asp:Repeater ID="Debug_Repeater" runat="server" OnItemCommand="Debug_Repeater_ItemCommand">
                            <HeaderTemplate>
                                <table class="table table-hover table-bordered table-responsive">
                                    <tr>
                                        <td>序号</td>
                                        <td>姓名</td>
                                        <td>项目名称</td>
                                        <td>项目地点</td>
                                        <td>
                                            <div>工程管理</div>
                                            <div>（工日）</div>

                                        </td>
                                        <td>
                                            <div>调试</div>
                                            <div>（工日）</div>

                                        </td>
                                        <td class="remarks">备注</td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="der_number" Width="35px" runat="server" Text='<%#Eval("number")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="der_name" Width="70px" runat="server" Text='<%#Eval("name")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="der_projectname" ToolTip='<%#Eval("projectname")%>' runat="server" Text='<%#Eval("projectname")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="der_site" Width="120px" runat="server" Text='<%#Eval("site")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="der_manageday" Width="70px" runat="server" Text='<%#Eval("manageday")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="der_debugday" Width="70px" runat="server" Text='<%#Eval("debugday")%>' />
                                    </td>
                                    <td class="remarks">
                                        <%#Eval("remark") %>
                                        
                                    </td>
                                    <td>
                                        <button type="button" class="btn btn-warning change">修改</button>
                                        <%--修改按钮比较复杂，除了在CommandName传递一个update给后台，标识自己是修改，还要同时传递两个参数一个打印的id，与该行的行数用于发现TextBox--%>
                                        <span class="submit">
                                            <asp:Button runat="server" class="btn btn-success" CommandName="confirm" CommandArgument='<%#(Container as RepeaterItem).ItemIndex%>' Text="确认"
                                                OnClientClick='return confirm("确定此操作吗？")' />

                                        </span>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <div tab-id="4" class="tab form tab4">
                        <asp:Repeater ID="Manage_Working_Repeater" runat="server" OnItemCommand="Manage_Working_Repeater_ItemCommand">
                            <HeaderTemplate>
                                <table class="table table-hover table-bordered table-responsive">
                                    <tr>
                                        <td>序号</td>
                                        <td>姓名</td>
                                        <td>项目名称</td>
                                        <td>
                                            <div>商务询价</div>
                                            <div>报价</div>
                                        </td>
                                        <td>标书制作</td>
                                        <td>
                                            <div>合同制作</div>
                                            <div>与签署</div>
                                        </td>
                                        <td>投标</td>
                                        <td>
                                            <div>设备招标</div>
                                            <div>采购</div>
                                        </td>
                                        <td>
                                            <div>设备出厂</div>
                                            <div>检测</div>
                                        </td>
                                        <td>催款</td>
                                        <td>合同管理</td>
                                        <td>其他</td>
                                        <td>
                                            <div>项目经理</div>
                                            <div>（工日）</div>
                                        </td>
                                        <td class="remarks">备注</td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="MW_number" Width="30px" runat="server" Text='<%#Eval("number")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="MW_name" Width="60px" runat="server" Text='<%#Eval("name")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="MW_project_name" Width="200px" ToolTip='<%#Eval("project_name")%>' runat="server" Text='<%#Eval("project_name")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="MW_xunjia_baojia" Width="60px" runat="server" Text='<%#Eval("xunjia_baojia")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="MW_tender" Width="60px" runat="server" Text='<%#Eval("tender")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="MW_sign" Width="60px" runat="server" Text='<%#Eval("sign")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="MW_toubiao" Width="60px" runat="server" Text='<%#Eval("toubiao")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="MW_equip" Width="60px" runat="server" Text='<%#Eval("equip")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="MW_test" Width="60px" runat="server" Text='<%#Eval("test")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="MW_cuikuan" Width="60px" runat="server" Text='<%#Eval("cuikuan")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="MW_contract" Width="60px" runat="server" Text='<%#Eval("contract")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="MW_other" Width="60px" runat="server" Text='<%#Eval("other")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="MW_PM_day" Width="60px" runat="server" Text='<%#Eval("PM_day")%>' />
                                    </td>
                                    <td class="remarks">
                                        <%#Eval("remark") %>
                                    </td>
                                    <td>
                                        <button type="button" class="btn btn-warning change">修改</button>
                                        <%--修改按钮比较复杂，除了在CommandName传递一个update给后台，标识自己是修改，还要同时传递两个参数一个打印的id，与该行的行数用于发现TextBox--%>
                                        <span class="submit">
                                            <asp:Button runat="server" class="btn btn-success" CommandName="confirm" CommandArgument='<%#(Container as RepeaterItem).ItemIndex%>' Text="确认"
                                                OnClientClick='return confirm("确定此操作吗？")' />

                                        </span>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <div tab-id="5" class="tab form tab5">
                        <asp:Repeater ID="Daily_Manage_Repeater" runat="server" OnItemCommand="Daily_Manage_Repeater_ItemCommand">
                            <HeaderTemplate>
                                <table class="table table-hover table-bordered table-responsive">
                                    <tr>
                                        <td>序号</td>
                                        <td>姓名</td>
                                        <td>内部管理</td>
                                        <td>工会事务</td>
                                        <td>党组事务</td>
                                        <td>团组事务</td>
                                        <td>体系内审/外审</td>
                                        <td>考勤</td>
                                        <td>其他</td>
                                        <td class="remarks">备注</td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="DM_number" Width="35px" runat="server" Text='<%#Eval("number")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="DM_name" Width="70px" runat="server" Text='<%#Eval("name")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="DM_management" Width="70px" runat="server" Text='<%#Eval("management")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="DM_affair_gonghui" Width="70px" runat="server" Text='<%#Eval("affair_gonghui")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="DM_affair_dangzu" Width="70px" runat="server" Text='<%#Eval("affair_dangzu")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="DM_affair_tuanzu" Width="70px" runat="server" Text='<%#Eval("affair_tuanzu")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="DM_examine" Width="70px" runat="server" Text='<%#Eval("examine")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="DM_kaoqin" Width="70px" runat="server" Text='<%#Eval("kaoqin")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="DM_other" Width="70px" runat="server" Text='<%#Eval("other")%>' />
                                    </td>
                                    <td class="remarks"><%#Eval("remark") %></td>
                                    <td>
                                        <button type="button" class="btn btn-warning change">修改</button>
                                        <%--修改按钮比较复杂，除了在CommandName传递一个update给后台，标识自己是修改，还要同时传递两个参数一个打印的id，与该行的行数用于发现TextBox--%>
                                        <span class="submit">
                                            <asp:Button runat="server" class="btn btn-success" CommandName="confirm" CommandArgument='<%#(Container as RepeaterItem).ItemIndex%>' Text="确认"
                                                OnClientClick='return confirm("确定此操作吗？")' />

                                        </span>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <div tab-id="6" class="tab form tab6">
                        <asp:Repeater ID="LingXing_Repeater" runat="server" OnItemCommand="LingXing_Repeater_ItemCommand">
                            <HeaderTemplate>
                                <table class="table table-hover table-bordered table-responsive">
                                    <tr>
                                        <td>序号</td>
                                        <td>姓名</td>
                                        <td>出差天数</td>
                                        <td>技术交流天数</td>
                                        <td>其他</td>
                                        <td class="remarks">备注</td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="LX_number" Width="35px" runat="server" Text='<%#Eval("number")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="LX_name" Width="70px" runat="server" Text='<%#Eval("name")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="LX_chuchai_day" Width="70px" runat="server" Text='<%#Eval("chuchai_day")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="LX_jiaoliu_day" Width="70px" runat="server" Text='<%#Eval("jiaoliu_day")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="LX_other_day" Width="70px" runat="server" Text='<%#Eval("other_day")%>' />
                                    </td>
                                    <td class="remarks"><%#Eval("remark") %></td>
                                    <td>
                                        <button type="button" class="btn btn-warning change">修改</button>
                                        <%--修改按钮比较复杂，除了在CommandName传递一个update给后台，标识自己是修改，还要同时传递两个参数一个打印的id，与该行的行数用于发现TextBox--%>
                                        <span class="submit">
                                            <asp:Button runat="server" class="btn btn-success" CommandName="confirm" CommandArgument='<%#(Container as RepeaterItem).ItemIndex%>' Text="确认"
                                                OnClientClick='return confirm("确定此操作吗？")' />

                                        </span>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <div tab-id="7" class="tab form">
                        <asp:Repeater ID="Summary_Repeater" runat="server">
                            <HeaderTemplate>
                                <table class="table table-hover table-bordered table-responsive">
                                    <tr>
                                        <td>人员编号</td>
                                        <td>姓名</td>
                                        <td>总工日</td>
                                        <td>比例%</td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("peoplenumber") %></td>
                                    <td><%#Eval("name") %></td>
                                    <td><%#Eval("work_day") %></td>
                                    <td><%#Eval("ratio") %></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </article>
    </form>

</body>
<script src="../Scripts/bootstrap.min.js"></script>
<script src="http://www.jq22.com/jquery/2.1.1/jquery.min.js"></script>
<script>window.jQuery || document.write('<script src="../Sccript/jquery-3.0.0.min.js"><\/script>')</script>
<script src="../Scripts/jeDate.js"></script>
<script>

    $(document).ready(function () {

        var useragent = navigator.userAgent;
        //var isIE = useragent.indexOf("MSIE") || useragent.indexOf("Trident") || 
        if (useragent.indexOf("Edge") > -1) {
            $(".tabs-content").css("overflow-x", "scroll");
        } else {
            console.log(1)
        }

        var activePos = $('.tabs-header .active').position();
        function changePos() {
            activePos = $('.tabs-header .active').position();
            $('.border').stop().css({
                left: activePos.left,
                width: $('.tabs-header .active').width()
            });
        }
        changePos();
        var tabHeight = $('.tab.active').height();
        function animateTabHeight() {
            tabHeight = $('.tab.active').height();
            $('.tabs-content').stop().css({ height: tabHeight + 'px' });
        }
        animateTabHeight();
        function changeTab() {
            var getTabId = $('.tabs-header .active a').attr('tab-id');
            $('.tab').stop().fadeOut(300, function () {
                $(this).removeClass('active');
            }).hide();
            $('.tab[tab-id=' + getTabId + ']').stop().fadeIn(300, function () {
                $(this).addClass('active');
                animateTabHeight();
            });
        }
        $('.tabs-header a').on('click', function (e) {
            e.preventDefault();
            var tabId = $(this).attr('tab-id');
            $('.tabs-header a').stop().parent().removeClass('active');
            $(this).stop().parent().addClass('active');
            changePos();
            tabCurrentItem = tabItems.filter('.active');
            $('.tab').stop().fadeOut(300, function () {
                $(this).removeClass('active');
            }).hide();
            $('.tab[tab-id="' + tabId + '"]').stop().fadeIn(300, function () {
                $(this).addClass('active');
                animateTabHeight();
            });
        });
        var tabItems = $('.tabs-header ul li');
        var tabCurrentItem = tabItems.filter('.active');
        $('#next').on('click', function (e) {
            e.preventDefault();
            var nextItem = tabCurrentItem.next();
            tabCurrentItem.removeClass('active');
            if (nextItem.length) {
                tabCurrentItem = nextItem.addClass('active');
            } else {
                tabCurrentItem = tabItems.first().addClass('active');
            }
            changePos();
            changeTab();
        });
        $('#prev').on('click', function (e) {
            e.preventDefault();
            var prevItem = tabCurrentItem.prev();
            tabCurrentItem.removeClass('active');
            if (prevItem.length) {
                tabCurrentItem = prevItem.addClass('active');
            } else {
                tabCurrentItem = tabItems.last().addClass('active');
            }
            changePos();
            changeTab();
        });
        $('[ripple]').on('click', function (e) {
            var rippleDiv = $('<div class="ripple" />'), rippleOffset = $(this).offset(), rippleY = e.pageY - rippleOffset.top, rippleX = e.pageX - rippleOffset.left, ripple = $('.ripple');
            rippleDiv.css({
                top: rippleY - ripple.height() / 2,
                left: rippleX - ripple.width() / 2,
                background: $(this).attr('ripple-color')
            }).appendTo($(this));
            window.setTimeout(function () {
                rippleDiv.remove();
            }, 1500);
        });
        $("input[type='text']").each(function () {
            $(this).attr("disabled", true);
        })
        $("button.change").click(function () {
            $("input[type='text']").each(function () {
                console.log($(this).attr("disabled"));
                if ($(this).attr("disabled") === "disabled") {
                    $(this).attr("disabled", false);
                }
                else {
                    $(this).attr("disabled", true);
                }

            })
        })

    });
</script>
</html>
