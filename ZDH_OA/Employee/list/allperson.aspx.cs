using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Reflection;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDH_OA.App_Code;

namespace ZDH_OA.Employee.list
{
    public partial class allperson : System.Web.UI.Page
    {
        DataTable designDt;
        DataTable programCmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (HttpContext.Current.Session["username"].ToString() == "null" || HttpContext.Current.Session["userpwd"].ToString() == "null")
                {
                    HttpContext.Current.Response.Write(" <script> alert( '您还未登陆，请先登录！！！');window.parent.location.href= '../../Default.aspx' </script> ");
                }
            }
            catch (Exception)
            {
                HttpContext.Current.Response.Write(" <script> alert( '您还未登陆，请先登录！！！');window.parent.location.href= '../../Default.aspx' </script> ");
            }

            sqlTable st = new sqlTable();
            #region 设计工作量
            string designTableName1 = "Design";//表名1
            string designTableName2 = "Login";//表名2
            string[] designSourceList = { "Design.number", "Login.name", "Design.project_number", "Design.project_name", "Design.drawing_number", "Design.A1_number", "Design.zhehe_working_day", "Design.month_day", "Design.program_day", "Design.basic_design_day", "Design.leader", "Design.remark" };//查看列名
            string[] designSelectList = { "year", "month", "Design.username" };//限定列名
            string[] designSelectValue = { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), "Login.username" };//限定列值

            //连接数据查看并显示在网页
            designDt = st.selectAll(designTableName1, designTableName2, designSourceList, designSelectList, designSelectValue);
            if (designDt != null)
            {
                Design_Repeater.DataSource = designDt;
                Design_Repeater.DataBind();
            }
            #endregion

            #region 编程/画面工作量
            string programTableName1 = "Programing_Picture";//表名1
            string programTableName2 = "Login";//表名2
            string[] programSourceList = { "Programing_Picture.number", "Login.name", "Programing_Picture.project_name", "Programing_Picture.digital_number", "Programing_Picture.analog_number", "Programing_Picture.programing_picture", "Programing_Picture.programing_day", "Programing_Picture.month_day", "Programing_Picture.remark" };//查看列名
            string[] programSelectList = { "year", "month", "Programing_Picture.username" };//限定列名
            string[] programSelectValue = { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), "Login.username" };//限定列值

            //连接数据查看并显示在网页
            programCmd = st.selectAll(programTableName1, programTableName2, programSourceList, programSelectList, programSelectValue);
            if (programCmd != null)
            {
                Programming_Picture_Repeater.DataSource = programCmd;
                Programming_Picture_Repeater.DataBind();
            }
            #endregion

            #region 调试/工程管理工作量
            string debugTableName1 = "Debug";//表名1
            string debugTableName2 = "Login";//表名2
            string[] debugSourceList = { "Debug.number", "Login.name", "Debug.projectname", "Debug.site", "Debug.manageday", "Debug.debugday", "Debug.remark" };//查看列名
            string[] debugSelectList = { "year", "month", "Debug.username" };//限定列名
            string[] debugSelectValue = { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), "Login.username" };//限定列值

            //连接数据查看并显示在网页
            System.Data.DataTable debugCmd = st.selectAll(debugTableName1, debugTableName2, debugSourceList, debugSelectList, debugSelectValue);
            if (debugCmd != null)
            {
                Debug_Repeater.DataSource = debugCmd;
                Debug_Repeater.DataBind();
            }
            #endregion

            #region 经营工作量
            string manageWorkingTableName1 = "Manage_Working";//表名1
            string manageWorkingTableName2 = "Login";//表名2
            string[] manageWorkingSourceList = { "Manage_Working.number", "Login.name", "Manage_Working.project_name", "Manage_Working.xunjia_baojia", "Manage_Working.tender", "Manage_Working.sign", "Manage_Working.toubiao", "Manage_Working.equip", "Manage_Working.test", "Manage_Working.cuikuan", "Manage_Working.contract", "Manage_Working.other", "Manage_Working.PM_day", "Manage_Working.remark" };//查看列名
            string[] manageWorkingSelectList = { "year", "month", "Manage_Working.username" };//限定列名
            string[] manageWorkingSelectValue = { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), "Login.username" };//限定列值

            //连接数据查看并显示在网页
            System.Data.DataTable manageWorkingCmd = st.selectAll(manageWorkingTableName1, manageWorkingTableName2, manageWorkingSourceList, manageWorkingSelectList, manageWorkingSelectValue);
            if (manageWorkingCmd != null)
            {
                Manage_Working_Repeater.DataSource = manageWorkingCmd;
                Manage_Working_Repeater.DataBind();
            }
            #endregion

            #region 日常管理工作量
            string DailyManageTableName1 = "Daily_Manage";//表名1
            string DailyManageTableName2 = "Login";//表名2

            string[] DailyManageSourceList = { "Daily_Manage.number", "Login.name", "Daily_Manage.management", "Daily_Manage.affair_gonghui", "Daily_Manage.affair_dangzu", "Daily_Manage.affair_tuanzu", "Daily_Manage.examine", "Daily_Manage.kaoqin", "Daily_Manage.other", "Daily_Manage.month_day", "Daily_Manage.remark" };//查看列名
            string[] DailyManageSelectList = { "year", "month", "Daily_Manage.username" };//限定列名
            string[] DailyManageSelectValue = { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), "Login.username" };//限定列值

            //连接数据查看并显示在网页
            System.Data.DataTable DailyManageCmd = st.selectAll(DailyManageTableName1, DailyManageTableName2, DailyManageSourceList, DailyManageSelectList, DailyManageSelectValue);
            if (DailyManageCmd != null)
            {
                Daily_Manage_Repeater.DataSource = DailyManageCmd;
                Daily_Manage_Repeater.DataBind();
            }
            #endregion

            #region 零星工日
            string lingXingTableName1 = "LingXing";//表名1
            string lingXingTableName2 = "Login";//表名2

            string[] lingXingSourceList = { "LingXing.number", "Login.name", "LingXing.chuchai_day", "LingXing.jiaoliu_day", "LingXing.other_day", "LingXing.remark" };//查看列名
            string[] lingXingSelectList = { "year", "month", "LingXing.username" };//限定列名
            string[] lingXingSelectValue = { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), "Login.username" };//限定列值

            //连接数据查看并显示在网页
            System.Data.DataTable lingXingCmd = st.selectAll(lingXingTableName1, lingXingTableName2, lingXingSourceList, lingXingSelectList, lingXingSelectValue);
            if (lingXingCmd != null)
            {
                LingXing_Repeater.DataSource = lingXingCmd;
                LingXing_Repeater.DataBind();
            }
            #endregion

            #region 本月工日之和
            string summaryTableName1 = "Summary";//表名
            string summaryTableName2 = "Login";//表名2
            string summaryTableName3 = "Jiediao";//表名3
            string summaryTableName4 = "Summary_Month";//表名4

            string[] summarySourceList = { "Login.name", "Summary.work_day" };//查看列名
            string[] summarySourceList2 = { "Login.name", "Jiediao.transfer" };//查看列名2

            string[] summarySelectList = { "year", "month", "Summary.username" };//限定列名
            string[] summarySelectList2 = { "year", "month", "Jiediao.username" };//限定列名2

            string[] summarySelectValue = { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), "Login.username" };//限定列值
            string[] summarySelectValue2 = { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), "Login.username" };//限定列值2


            //连接数据查看并显示在网页
            DataTable summaryCmd = st.selectAll6(summaryTableName2, summaryTableName1, summaryTableName3, summaryTableName4, summarySourceList, summarySelectList, summarySelectValue, summarySourceList2, summarySelectList2, summarySelectValue2);
            if (summaryCmd != null)
            {
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
            st.select_delete(tableName, mysqlm, listm, sourcem, columnsm);
            HttpContext.Current.Session["numberMonth"] = mysqlm[0];
            #endregion
        }
    }
}