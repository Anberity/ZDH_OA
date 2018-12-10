using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDH_OA.App_Code;

namespace ZDH_OA.Director
{
    public partial class WorkDayUpdate : System.Web.UI.Page
    {
        //Look st = new Look();
        sqlTable sqlt = new sqlTable();

        DataTable designCmd;
        DataTable programCmd;
        DataTable debugCmd;
        DataTable manageWorkingCmd;
        DataTable DailyManageCmd;
        DataTable lingXingCmd;
        DataTable summaryCmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 登录判断
            try
            {
                if (HttpContext.Current.Session["username"].ToString() == "null" || HttpContext.Current.Session["userpwd"].ToString() == "null")
                {
                    HttpContext.Current.Response.Write(" <script> alert( '您还未登陆，请先登录！！！');window.parent.location.href= '../Default.aspx ' </script> ");
                }
                string name = HttpContext.Current.Session["name"].ToString();
            }
            catch (Exception)
            {
                HttpContext.Current.Response.Write(" <script> alert( '您还未登陆，请先登录！！！');window.parent.location.href= '../Default.aspx ' </script> ");
            }
            #endregion

            #region 设计工作量
            string designTableName1 = "Design";//表名1
            string designTableName2 = "Login";//表名2
            string[] designSourceList = { "Design.number", "Login.name", "Design.project_number", "Design.project_name", "Design.drawing_number", "Design.A1_number", "Design.zhehe_working_day", "Design.month_day", "Design.program_day", "Design.basic_design_day", "Design.leader", "Design.remark" };//查看列名
            string[] designSelectList = { "year", "month", "Design.username" };//限定列名
            string[] designSelectValue = { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), "Login.username" };//限定列值

            //连接数据查看并显示在网页
            designCmd = sqlt.selectAll(designTableName1, designTableName2, designSourceList, designSelectList, designSelectValue);

            #endregion

            #region 编程/画面工作量
            string programTableName1 = "Programing_Picture";//表名1
            string programTableName2 = "Login";//表名2
            string[] programSourceList = { "Programing_Picture.number", "Login.name", "Programing_Picture.project_name", "Programing_Picture.digital_number", "Programing_Picture.analog_number", "Programing_Picture.programing_picture", "Programing_Picture.programing_day", "Programing_Picture.month_day", "Programing_Picture.remark" };//查看列名
            string[] programSelectList = { "year", "month", "Programing_Picture.username" };//限定列名
            string[] programSelectValue = { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), "Login.username" };//限定列值

            //连接数据查看并显示在网页
            programCmd = sqlt.selectAll(programTableName1, programTableName2, programSourceList, programSelectList, programSelectValue);
            //if (programCmd != null)
            //{
            //    Programming_Picture_Repeater.DataSource = programCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            //    Programming_Picture_Repeater.DataBind();
            //}
            #endregion

            #region 调试/工程管理工作量
            string debugTableName1 = "Debug";//表名1
            string debugTableName2 = "Login";//表名2
            string[] debugSourceList = { "Debug.number", "Login.name", "Debug.projectname", "Debug.site", "Debug.manageday", "Debug.debugday", "Debug.remark" };//查看列名
            string[] debugSelectList = { "year", "month", "Debug.username" };//限定列名
            string[] debugSelectValue = { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), "Login.username" };//限定列值

            //连接数据查看并显示在网页
            debugCmd = sqlt.selectAll(debugTableName1, debugTableName2, debugSourceList, debugSelectList, debugSelectValue);
            //if (debugCmd != null)
            //{
            //    Debug_Repeater.DataSource = debugCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            //    Debug_Repeater.DataBind();
            //}
            #endregion

            #region 经营工作量
            string manageWorkingTableName1 = "Manage_Working";//表名1
            string manageWorkingTableName2 = "Login";//表名2
            string[] manageWorkingSourceList = { "Manage_Working.number", "Login.name", "Manage_Working.project_name", "Manage_Working.xunjia_baojia", "Manage_Working.tender", "Manage_Working.sign", "Manage_Working.toubiao", "Manage_Working.equip", "Manage_Working.test", "Manage_Working.cuikuan", "Manage_Working.contract", "Manage_Working.other", "Manage_Working.PM_day", "Manage_Working.remark" };//查看列名
            string[] manageWorkingSelectList = { "year", "month", "Manage_Working.username" };//限定列名
            string[] manageWorkingSelectValue = { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), "Login.username" };//限定列值

            //连接数据查看并显示在网页
            manageWorkingCmd = sqlt.selectAll(manageWorkingTableName1, manageWorkingTableName2, manageWorkingSourceList, manageWorkingSelectList, manageWorkingSelectValue);
            //if (manageWorkingCmd != null)
            //{
            //    Manage_Working_Repeater.DataSource = manageWorkingCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            //    Manage_Working_Repeater.DataBind();
            //}
            #endregion

            #region 日常管理工作量
            string DailyManageTableName1 = "Daily_Manage";//表名1
            string DailyManageTableName2 = "Login";//表名2

            string[] DailyManageSourceList = { "Daily_Manage.number", "Login.name", "Daily_Manage.management", "Daily_Manage.affair_gonghui", "Daily_Manage.affair_dangzu", "Daily_Manage.affair_tuanzu", "Daily_Manage.examine", "Daily_Manage.kaoqin", "Daily_Manage.other", "Daily_Manage.remark" };//查看列名
            string[] DailyManageSelectList = { "year", "month", "Daily_Manage.username" };//限定列名
            string[] DailyManageSelectValue = { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), "Login.username" };//限定列值

            //连接数据查看并显示在网页
            DailyManageCmd = sqlt.selectAll(DailyManageTableName1, DailyManageTableName2, DailyManageSourceList, DailyManageSelectList, DailyManageSelectValue);
            //if (DailyManageCmd != null)
            //{
            //    Daily_Manage_Repeater.DataSource = DailyManageCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            //    Daily_Manage_Repeater.DataBind();
            //}
            #endregion

            #region 零星工日
            string lingXingTableName1 = "LingXing";//表名1
            string lingXingTableName2 = "Login";//表名2

            string[] lingXingSourceList = { "LingXing.number", "Login.name", "LingXing.chuchai_day", "LingXing.jiaoliu_day", "LingXing.other_day", "LingXing.remark" };//查看列名
            string[] lingXingSelectList = { "year", "month", "LingXing.username" };//限定列名
            string[] lingXingSelectValue = { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), "Login.username" };//限定列值

            //连接数据查看并显示在网页
            lingXingCmd = sqlt.selectAll(lingXingTableName1, lingXingTableName2, lingXingSourceList, lingXingSelectList, lingXingSelectValue);
            //if (lingXingCmd != null)
            //{
            //    LingXing_Repeater.DataSource = lingXingCmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            //    LingXing_Repeater.DataBind();
            //}
            #endregion

            #region 本月工日之和
            string summaryTableName1 = "Summary";//表名
            string summaryTableName2 = "Login";//表名2
            string summaryTableName3 = "Jiediao";//表名3
            string summaryTableName4 = "Summary_Month";//表名4


            string[] summarySourceList = { "Login.peoplenumber", "Login.name", "Summary.work_day", "Summary.ratio" };//查看列名
            string[] summarySourceList2 = { "Login.peoplenumber", "Login.name", "Jiediao.transfer", "Jiediao.ratio" };//查看列名2

            string[] summarySelectList = { "year", "month", "Summary.username" };//限定列名
            string[] summarySelectList2 = { "year", "month", "Jiediao.username" };//限定列名2

            string[] summarySelectValue = { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), "Login.username" };//限定列值
            string[] summarySelectValue2 = { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), "Login.username" };//限定列值2

            //连接数据
            summaryCmd = sqlt.selectAll7(summaryTableName2, summaryTableName1, summaryTableName3, summaryTableName4, summarySourceList, summarySelectList, summarySelectValue, summarySourceList2, summarySelectList2, summarySelectValue2);

            #endregion

            #region 数据绑定
            if (!Page.IsPostBack)//必须有，规定数据不能多次被绑定。
            {
                //设计工作量
                Design_Repeater.DataSource = designCmd;
                Design_Repeater.DataBind();

                //编程/画面工作量
                Programming_Picture_Repeater.DataSource = programCmd;
                Programming_Picture_Repeater.DataBind();

                //调试/工程管理工作量
                Debug_Repeater.DataSource = debugCmd;
                Debug_Repeater.DataBind();

                //经营工作量
                Manage_Working_Repeater.DataSource = manageWorkingCmd;
                Manage_Working_Repeater.DataBind();

                //日常管理工作量
                Daily_Manage_Repeater.DataSource = DailyManageCmd;
                Daily_Manage_Repeater.DataBind();

                //零星工日
                LingXing_Repeater.DataSource = lingXingCmd;
                LingXing_Repeater.DataBind();

                //本月工日之和
                Summary_Repeater.DataSource = summaryCmd;
                Summary_Repeater.DataBind();
            }
            #endregion

            #region 合计
            string tableName = "Summary_Month";
            string[] mysqlm = new string[1];
            string[] listm = { "year", "month" };
            string[] sourcem = { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString() };
            string[] columnsm = { "summary" };
            sqlt.select_delete(tableName, mysqlm, listm, sourcem, columnsm);
            HttpContext.Current.Session["numberMonth"] = mysqlm[0];
            #endregion
        }

        //设计工作量
        protected void Design_Repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "confirm")//如果点击的是被标记为CommandName="del"的按钮，也就是确认按钮
            {
                int itemIndex = int.Parse(e.CommandArgument.ToString());//藏在CommandArgument='<%#Eval("id")+","+(Container as RepeaterItem).ItemIndex%>'逗号后面的参数就是该行行号
                TextBox dr_number = Design_Repeater.Items[itemIndex].FindControl("dr_number") as TextBox;//获得改行的TextBox1
                TextBox dr_name = Design_Repeater.Items[itemIndex].FindControl("dr_name") as TextBox;//获得改行的TextBox2
                TextBox dr_project_number = Design_Repeater.Items[itemIndex].FindControl("dr_project_number") as TextBox;
                TextBox dr_project_name = Design_Repeater.Items[itemIndex].FindControl("dr_project_name") as TextBox;
                TextBox dr_drawing_number = Design_Repeater.Items[itemIndex].FindControl("dr_drawing_number") as TextBox;
                TextBox dr_A1_number = Design_Repeater.Items[itemIndex].FindControl("dr_A1_number") as TextBox;
                TextBox dr_zhehe_working_day = Design_Repeater.Items[itemIndex].FindControl("dr_zhehe_working_day") as TextBox;
                TextBox dr_month_day = Design_Repeater.Items[itemIndex].FindControl("dr_month_day") as TextBox;
                TextBox dr_program_day = Design_Repeater.Items[itemIndex].FindControl("dr_program_day") as TextBox;
                TextBox dr_basic_design_day = Design_Repeater.Items[itemIndex].FindControl("dr_basic_design_day") as TextBox;
                TextBox dr_leader = Design_Repeater.Items[itemIndex].FindControl("dr_leader") as TextBox;

                //获取用户名
                sqlTable st = new sqlTable();
                string[] username = new string[1];
                string tableName = "Login";
                string name = dr_name.Text;
                string[] seleList = { "username" };
                st.select_Name(name, username, tableName, seleList);

                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();

                //更新列名以及数据源
                string[] list = { "project_number", "project_name", "drawing_number", "A1_number", "zhehe_working_day", "month_day", "program_day", "basic_design_day", "leader" };
                string[] source1 = { dr_project_number.Text.ToString(), dr_project_name.Text.ToString(), dr_drawing_number.Text.ToString(), dr_A1_number.Text.ToString(), dr_zhehe_working_day.Text.ToString(), dr_month_day.Text.ToString(), dr_program_day.Text.ToString(), dr_basic_design_day.Text.ToString(), dr_leader.Text.ToString() };

                //查找列名以及数据源
                string[] selectList = { "year", "month", "username", "number" };
                string[] selectSource = { year, month, username[0], dr_number.Text.ToString() };

                //插入
                int res = st.table_update("Design", list, source1, selectList, selectSource);

                if (res == 1)
                {
                    Response.Write("<script>alert('成功')</script>");
                }
                else if (res == 0)
                {
                    Response.Write("<script>alert('输入有误，请重新输入')</script>");
                }
                else if (res == 2)
                {
                    Response.Write("<script>alert('语法错误')</script>");
                }


            }
        }

        //编程/画面工作量
        protected void Programming_Picture_Repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "confirm")//如果点击的是被标记为CommandName="del"的按钮，也就是确认按钮
            {
                int itemIndex = int.Parse(e.CommandArgument.ToString());//藏在CommandArgument='<%#Eval("id")+","+(Container as RepeaterItem).ItemIndex%>'逗号后面的参数就是该行行号
                TextBox ppr_number = Programming_Picture_Repeater.Items[itemIndex].FindControl("ppr_number") as TextBox;
                TextBox ppr_name = Programming_Picture_Repeater.Items[itemIndex].FindControl("ppr_name") as TextBox;
                TextBox ppr_project_name = Programming_Picture_Repeater.Items[itemIndex].FindControl("ppr_project_name") as TextBox;
                TextBox ppr_digital_number = Programming_Picture_Repeater.Items[itemIndex].FindControl("ppr_digital_number") as TextBox;
                TextBox ppr_analog_number = Programming_Picture_Repeater.Items[itemIndex].FindControl("ppr_analog_number") as TextBox;
                TextBox ppr_programing_picture = Programming_Picture_Repeater.Items[itemIndex].FindControl("ppr_programing_picture") as TextBox;
                TextBox ppr_programing_day = Programming_Picture_Repeater.Items[itemIndex].FindControl("ppr_programing_day") as TextBox;
                TextBox ppr_month_day = Programming_Picture_Repeater.Items[itemIndex].FindControl("ppr_month_day") as TextBox;

                //获取用户名
                sqlTable st = new sqlTable();
                string[] username = new string[1];
                string tableName = "Login";
                string name = ppr_name.Text.ToString();
                string[] seleList = { "username" };
                st.select_Name(name, username, tableName, seleList);
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();

                //更新列名以及数据源
                string[] list = { "project_name", "digital_number", "analog_number", "programing_picture", "programing_day", "month_day" };
                string[] source1 = { ppr_project_name.Text.ToString(), ppr_digital_number.Text.ToString(), ppr_analog_number.Text.ToString(), ppr_programing_picture.Text.ToString(), ppr_programing_day.Text.ToString(), ppr_month_day.Text.ToString() };

                //查找列名以及数据源
                string[] selectList = { "year", "month", "username", "number" };
                string[] selectSource = { year, month, username[0], ppr_number.Text.ToString() };

                //插入
                int res = st.table_update("Programing_Picture", list, source1, selectList, selectSource);

                if (res == 1)
                {
                    Response.Write("<script>alert('成功')</script>");
                }
                else if (res == 0)
                {
                    Response.Write("<script>alert('输入有误，请重新输入')</script>");
                }
                else if (res == 2)
                {
                    Response.Write("<script>alert('语法错误')</script>");
                }
            }
        }

        //调试/工程管理工作量
        protected void Debug_Repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "confirm")//如果点击的是被标记为CommandName="del"的按钮，也就是确认按钮
            {
                int itemIndex = int.Parse(e.CommandArgument.ToString());//藏在CommandArgument='<%#Eval("id")+","+(Container as RepeaterItem).ItemIndex%>'逗号后面的参数就是该行行号
                TextBox dernumber = Debug_Repeater.Items[itemIndex].FindControl("der_number") as TextBox;
                TextBox dername = Debug_Repeater.Items[itemIndex].FindControl("der_name") as TextBox;
                TextBox derprojectname = Debug_Repeater.Items[itemIndex].FindControl("der_projectname") as TextBox;
                TextBox dersite = Debug_Repeater.Items[itemIndex].FindControl("der_site") as TextBox;
                TextBox dermanageday = Debug_Repeater.Items[itemIndex].FindControl("der_manageday") as TextBox;
                TextBox derdebugday = Debug_Repeater.Items[itemIndex].FindControl("der_debugday") as TextBox;

                //获取用户名
                sqlTable st = new sqlTable();
                string[] username = new string[1];
                string tableName = "Login";
                string name = dername.Text.ToString();
                string[] seleList = { "username" };
                st.select_Name(name, username, tableName, seleList);

                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();



                //更新列名以及数据源
                string[] list1 = { "projectname", "site", "manageday", "debugday" };
                string[] source1 = { derprojectname.Text.ToString(), dersite.Text.ToString(), dermanageday.Text.ToString(), derdebugday.Text.ToString() };

                //查找列名以及数据源
                string[] selectList = { "year", "month", "username", "number" };
                string[] selectSource = { year, month, username[0], dernumber.Text.ToString() };

                int res = st.table_update("Debug", list1, source1, selectList, selectSource);

                if (res == 1)
                {
                    Response.Write("<script>alert('成功')</script>");
                }
                else if (res == 0)
                {
                    Response.Write("<script>alert('输入有误，请重新输入')</script>");
                }
                else if (res == 2)
                {
                    Response.Write("<script>alert('语法错误')</script>");
                }
            }
        }

        //经营工作量
        protected void Manage_Working_Repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "confirm")//如果点击的是被标记为CommandName="del"的按钮，也就是确认按钮
            {
                int itemIndex = int.Parse(e.CommandArgument.ToString());//藏在CommandArgument='<%#Eval("id")+","+(Container as RepeaterItem).ItemIndex%>'逗号后面的参数就是该行行号
                TextBox number = Manage_Working_Repeater.Items[itemIndex].FindControl("MW_number") as TextBox;
                TextBox name = Manage_Working_Repeater.Items[itemIndex].FindControl("MW_name") as TextBox;
                TextBox project_name = Manage_Working_Repeater.Items[itemIndex].FindControl("MW_project_name") as TextBox;
                TextBox xunjia_baojia = Manage_Working_Repeater.Items[itemIndex].FindControl("MW_xunjia_baojia") as TextBox;
                TextBox tender = Manage_Working_Repeater.Items[itemIndex].FindControl("MW_tender") as TextBox;
                TextBox sign = Manage_Working_Repeater.Items[itemIndex].FindControl("MW_sign") as TextBox;
                TextBox toubiao = Manage_Working_Repeater.Items[itemIndex].FindControl("MW_toubiao") as TextBox;
                TextBox equip = Manage_Working_Repeater.Items[itemIndex].FindControl("MW_equip") as TextBox;
                TextBox test = Manage_Working_Repeater.Items[itemIndex].FindControl("MW_test") as TextBox;
                TextBox cuikuan = Manage_Working_Repeater.Items[itemIndex].FindControl("MW_cuikuan") as TextBox;
                TextBox contract = Manage_Working_Repeater.Items[itemIndex].FindControl("MW_contract") as TextBox;
                TextBox other = Manage_Working_Repeater.Items[itemIndex].FindControl("MW_other") as TextBox;
                TextBox PM_day = Manage_Working_Repeater.Items[itemIndex].FindControl("MW_PM_day") as TextBox;

                //获取用户名
                sqlTable st = new sqlTable();
                string[] username = new string[1];
                string tableName = "Login";
                string trueName = name.Text.ToString();
                string[] seleList = { "username" };
                st.select_Name(trueName, username, tableName, seleList);

                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();

                //更新列名以及数据源
                string[] list = { "project_name", "xunjia_baojia", "tender", "sign", "toubiao", "equip", "test", "cuikuan", "contract", "other", "PM_day" };
                string[] source11 = { project_name.Text.ToString(), xunjia_baojia.Text.ToString(), tender.Text.ToString(), sign.Text.ToString(), toubiao.Text.ToString(), equip.Text.ToString(), test.Text.ToString(), cuikuan.Text.ToString(), contract.Text.ToString(), other.Text.ToString(), PM_day.Text.ToString() };

                //查找列名以及数据源
                string[] selectList = { "year", "month", "username", "number" };
                string[] selectSource = { year, month, username[0], number.Text.ToString() };

                //插入
                int res = st.table_update("Manage_Working", list, source11, selectList, selectSource);

                if (res == 1)
                {
                    Response.Write("<script>alert('成功')</script>");
                }
                else if (res == 0)
                {
                    Response.Write("<script>alert('输入有误，请重新输入')</script>");
                }
                else if (res == 2)
                {
                    Response.Write("<script>alert('语法错误')</script>");
                }
            }
        }

        //日常管理工作量
        protected void Daily_Manage_Repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "confirm")//如果点击的是被标记为CommandName="del"的按钮，也就是确认按钮
            {
                int itemIndex = int.Parse(e.CommandArgument.ToString());//藏在CommandArgument='<%#Eval("id")+","+(Container as RepeaterItem).ItemIndex%>'逗号后面的参数就是该行行号
                TextBox number = Daily_Manage_Repeater.Items[itemIndex].FindControl("DM_number") as TextBox;
                TextBox name = Daily_Manage_Repeater.Items[itemIndex].FindControl("DM_name") as TextBox;
                TextBox management = Daily_Manage_Repeater.Items[itemIndex].FindControl("DM_management") as TextBox;
                TextBox affair_gonghui = Daily_Manage_Repeater.Items[itemIndex].FindControl("DM_affair_gonghui") as TextBox;
                TextBox affair_dangzu = Daily_Manage_Repeater.Items[itemIndex].FindControl("DM_affair_dangzu") as TextBox;
                TextBox affair_tuanzu = Daily_Manage_Repeater.Items[itemIndex].FindControl("DM_affair_tuanzu") as TextBox;
                TextBox examine = Daily_Manage_Repeater.Items[itemIndex].FindControl("DM_examine") as TextBox;
                TextBox kaoqin = Daily_Manage_Repeater.Items[itemIndex].FindControl("DM_kaoqin") as TextBox;
                TextBox other = Daily_Manage_Repeater.Items[itemIndex].FindControl("DM_other") as TextBox;
                TextBox month_day = Daily_Manage_Repeater.Items[itemIndex].FindControl("DM_month_day") as TextBox;

                //获取用户名
                sqlTable st = new sqlTable();
                string[] username = new string[1];
                string tableName = "Login";
                string trueName = name.Text.ToString();
                string[] seleList = { "username" };
                st.select_Name(trueName, username, tableName, seleList);

                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();

                //当月总工日汇总
                float monthSum = 0;//修改汇总

                if (management.Text != "")
                {
                    monthSum += float.Parse(management.Text.ToString());
                }
                if (affair_gonghui.Text != "")
                {
                    monthSum += float.Parse(affair_gonghui.Text.ToString());
                }
                if (affair_dangzu.Text != "")
                {
                    monthSum += float.Parse(affair_dangzu.Text.ToString());
                }
                if (affair_tuanzu.Text != "")
                {
                    monthSum += float.Parse(affair_tuanzu.Text.ToString());
                }
                if (examine.Text != "")
                {
                    monthSum += float.Parse(examine.Text.ToString());
                }
                if (kaoqin.Text != "")
                {
                    monthSum += float.Parse(kaoqin.Text.ToString());
                }
                if (other.Text != "")
                {
                    monthSum += float.Parse(other.Text.ToString());
                }

                //更新列名以及数据源
                string[] list = { "management", "affair_gonghui", "affair_dangzu", "affair_tuanzu", "examine", "kaoqin", "other", "month_day" };
                string[] source11 = { management.Text.ToString(), affair_gonghui.Text.ToString(), affair_dangzu.Text.ToString(), affair_tuanzu.Text.ToString(), examine.Text.ToString(), kaoqin.Text.ToString(), other.Text.ToString(), monthSum.ToString() };

                //查找列名以及数据源
                string[] selectList = { "year", "month", "username", "number" };
                string[] selectSource = { year, month, username[0], number.Text.ToString() };

                //插入
                int res = st.table_update("Daily_Manage", list, source11, selectList, selectSource);


                if (res == 1)
                {
                    Response.Write("<script>alert('成功')</script>");
                }
                else if (res == 0)
                {
                    Response.Write("<script>alert('输入有误，请重新输入')</script>");
                }
                else if (res == 2)
                {
                    Response.Write("<script>alert('语法错误')</script>");
                }
            }
        }

        //零星工日
        protected void LingXing_Repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "confirm")//如果点击的是被标记为CommandName="del"的按钮，也就是确认按钮
            {
                int itemIndex = int.Parse(e.CommandArgument.ToString());//藏在CommandArgument='<%#Eval("id")+","+(Container as RepeaterItem).ItemIndex%>'逗号后面的参数就是该行行号
                TextBox number = LingXing_Repeater.Items[itemIndex].FindControl("LX_number") as TextBox;
                TextBox name = LingXing_Repeater.Items[itemIndex].FindControl("LX_name") as TextBox;
                TextBox chuchai_day = LingXing_Repeater.Items[itemIndex].FindControl("LX_chuchai_day") as TextBox;
                TextBox jiaoliu_day = LingXing_Repeater.Items[itemIndex].FindControl("LX_jiaoliu_day") as TextBox;
                TextBox other_day = LingXing_Repeater.Items[itemIndex].FindControl("LX_other_day") as TextBox;

                //获取用户名
                sqlTable st = new sqlTable();
                string[] username = new string[1];
                string tableName = "Login";
                string trueName = name.Text.ToString();
                string[] seleList = { "username" };
                st.select_Name(trueName, username, tableName, seleList);

                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();

                //更新列名以及数据源
                string[] list = { "chuchai_day", "jiaoliu_day", "other_day" };
                string[] source11 = { chuchai_day.Text.ToString(), jiaoliu_day.Text.ToString(), other_day.Text.ToString() };

                //查找列名以及数据源
                string[] selectList = { "year", "month", "username", "number" };
                string[] selectSource = { year, month, username[0], number.Text.ToString() };

                //插入
                int res = st.table_update("LingXing", list, source11, selectList, selectSource);

                if (res == 1)
                {
                    Response.Write("<script>alert('成功')</script>");
                }
                else if (res == 0)
                {
                    Response.Write("<script>alert('输入有误，请重新输入')</script>");
                }
                else if (res == 2)
                {
                    Response.Write("<script>alert('语法错误')</script>");
                }

            }
        }

        /// <summary>
        ///可导出多个sheet表
        /// </summary>
        /// <param name="Author">作者</param>
        /// <param name="Company">公司</param>
        /// <param name="dt">多个DataTable</param>
        /// <param name="fileName">文件名</param>
        public static void PushExcelToClientEx(string Author, string Company, DataTable[] dt, string fileName)
        {
            if (!fileName.Contains(".xls"))
            {
                fileName += ".xls";
            }

            StringBuilder sbBody = new StringBuilder();
            StringBuilder sbSheet = new StringBuilder();

            sbBody.AppendFormat(
                    "MIME-Version: 1.0\r\n" +
                    "X-Document-Type: Workbook\r\n" +
                    "Content-Type: multipart/related; boundary=\"-=BOUNDARY_EXCEL\"\r\n\r\n" +
                    "---=BOUNDARY_EXCEL\r\n" +
                    "Content-Type: text/html; charset=\"gbk\"\r\n\r\n" +
                    "<html xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n" +
                    "xmlns:x=\"urn:schemas-microsoft-com:office:excel\">\r\n\r\n" +
                    "<head>\r\n" +
                    "<xml>\r\n" +
                    "<o:DocumentProperties>\r\n" +
                    "<o:Author>{0}</o:Author>\r\n" +
                    "<o:LastAuthor>{0}</o:LastAuthor>\r\n" +
                    "<o:Created>{1}</o:Created>\r\n" +
                    "<o:LastSaved>{1}</o:LastSaved>\r\n" +
                    "<o:Company>{2}</o:Company>\r\n" +
                    "<o:Version>11.5606</o:Version>\r\n" +
                    "</o:DocumentProperties>\r\n" +
                    "</xml>\r\n" +
                    "<xml>\r\n" +
                    "<x:ExcelWorkbook>\r\n" +
                    "<x:ExcelWorksheets>\r\n"
                   , Author
                   , DateTime.Now.ToString()
                   , Company);

            foreach (var d in dt)
            {
                string gid = Guid.NewGuid().ToString();
                string fileNames = null;
                #region 判断所属sheet

                if (d == dt[0])
                {
                    fileNames = "设计工作量";
                }
                if (d == dt[1])
                {
                    fileNames = "编程/画面工作量";
                }
                else if (d == dt[2])
                {
                    fileNames = "调试/工程管理工作量";
                }
                else if (d == dt[3])
                {
                    fileNames = "经营工作量";
                }
                else if (d == dt[4])
                {
                    fileNames = "日常管理工作量";
                }
                else if (d == dt[5])
                {
                    fileNames = "零星工日";
                }
                else if (d == dt[6])
                {
                    fileNames = "本月工日之和";
                }
                #endregion
                sbBody.AppendFormat("<x:ExcelWorksheet>\r\n" +
                    "<x:Name>{0}</x:Name>\r\n" +
                    "<x:WorksheetSource HRef=\"cid:{1}\"/>\r\n" +
                    "</x:ExcelWorksheet>\r\n"
                    , fileNames.Replace(":", "").Replace("\\", "").Replace("/", "").Replace("?", "").Replace("*", "").Replace("[", "").Replace("]", "").Trim()
                    , gid);


                sbSheet.AppendFormat(
                 "---=BOUNDARY_EXCEL\r\n" +
                 "Content-ID: {0}\r\n" +
                 "Content-Type: text/html; charset=\"gbk\"\r\n\r\n" +
                 "<html xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n" +
                 "xmlns:x=\"urn:schemas-microsoft-com:office:excel\">\r\n\r\n" +
                 "<head>\r\n" +
                 "<xml>\r\n" +
                 "<x:WorksheetOptions>\r\n" +
                 "<x:ProtectContents>False</x:ProtectContents>\r\n" +
                 "<x:ProtectObjects>False</x:ProtectObjects>\r\n" +
                 "<x:ProtectScenarios>False</x:ProtectScenarios>\r\n" +
                 "</x:WorksheetOptions>\r\n" +
                 "</xml>\r\n" +
                 "</head>\r\n" +
                 "<body>\r\n"
                 , gid);

                sbSheet.Append("<table border='1'>");
                sbSheet.Append("<tr style='background-color: #CCC;'>");
                for (int i = 0; i < d.Columns.Count; i++)
                {
                    sbSheet.AppendFormat("<td style='vnd.ms-excel.numberformat: @;font-weight:bold'>{0}</td>", d.Columns[i].ColumnName);
                }
                sbSheet.Append("</tr>");
                for (int j = 0; j < d.Rows.Count; j++)
                {
                    sbSheet.Append("<tr>");
                    for (int k = 0; k < d.Columns.Count; k++)
                    {
                        sbSheet.AppendFormat("<td style='vnd.ms-excel.numberformat: @;'>{0}</td>", Convert.ToString(d.Rows[j][k]));
                    }
                    sbSheet.Append("</tr>");
                }
                sbSheet.Append("</table>");
                sbSheet.Append("</body>\r\n" +
                    "</html>\r\n\r\n");
            }

            StringBuilder sb = new StringBuilder(sbBody.ToString());

            sb.Append("</x:ExcelWorksheets>\r\n" +
                "</x:ExcelWorkbook>\r\n" +
               "</xml>\r\n" +
                "</head>\r\n" +
                "</html>\r\n\r\n");

            sb.Append(sbSheet.ToString());

            sb.Append("---=BOUNDARY_EXCEL--");

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Buffer = true;

            fileName = System.Web.HttpUtility.UrlEncode(fileName, System.Text.Encoding.GetEncoding("utf-8"));//360浏览器导出时文件名乱码

            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("gbk");
            HttpContext.Current.Response.Write(sb.ToString());
            HttpContext.Current.Response.End();
        }

        //导出
        protected void export_Click(object sender, EventArgs e)
        {
            DataTable[] dt = new DataTable[7];
            dt[0] = designCmd;
            dt[1] = programCmd;
            dt[2] = debugCmd;
            dt[3] = manageWorkingCmd;
            dt[4] = DailyManageCmd;
            dt[5] = lingXingCmd;
            dt[6] = summaryCmd;
            string[] designName = { "序号", "姓名", "工程号", "工程名称", "施工图图纸张数", "施工图折合A1", "施工图折合总工日数", "本月完成工日", "技术方案（工日）", "基本设计（工日）", "专业负责人（工日）", "备注" };
            string[] programName = { "序号", "姓名", "项目名称", "总开关量点数", "总模拟量点数", "编程/画面", "总工日", "本月完成工日", "备注" };
            string[] debugName = { "序号", "姓名", "项目名称", "项目地点", "工程管理（工日）", "调试（工日）", "备注" };
            string[] manageName = { "序号", "姓名", "项目名称", "商务询价报价", "标书制作", "合同制作与签署", "投标", "设备招标采购", "设备出厂检测", "催款", "合同管理", "其他", "项目经理（工日）", "备注" };
            string[] dailyName = { "序号", "姓名", "内部管理", "工会事务", "党组事务", "团组事务", "体系内审/外审", "考勤", "其他", "备注" };
            string[] lingxingName = { "序号", "姓名", "出差天数", "技术交流天数", "其他", "备注" };
            string[] sumName = { "员工编号", "姓名", "总工日", "比例%" };

            string[][] listname = { designName, programName, debugName, manageName, dailyName, lingxingName, sumName };
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < listname[i].Length; j++)
                {
                    dt[i].Columns[j].ColumnName = listname[i][j];
                }
            }
            string fileName = DateTime.Now.Year.ToString() + "年" + (int.Parse(DateTime.Now.Month.ToString()) - 1).ToString() + "月份" + "-" + DateTime.Now.Month.ToString() + "月份" + "部门工作量汇总";
            PushExcelToClientEx("自动化", "SDM", dt, fileName);
        }
    }
}