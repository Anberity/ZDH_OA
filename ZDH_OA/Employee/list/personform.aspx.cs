﻿using System;
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
    public partial class personform : System.Web.UI.Page
    {
        DataTable designDt;
        DataTable programCmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = "";
            try
            {
                if (HttpContext.Current.Session["username"].ToString() == "null" || HttpContext.Current.Session["userpwd"].ToString() == "null")
                {
                    HttpContext.Current.Response.Write(" <script> alert( '您还未登陆，请先登录！！！');window.parent.location.href= '../../Default.aspx' </script> ");
                }
                username = HttpContext.Current.Session["username"].ToString();
            }
            catch (Exception)
            {
                HttpContext.Current.Response.Write(" <script> alert( '您还未登陆，请先登录！！！');window.parent.location.href= '../../Default.aspx' </script> ");
            }

            sqlTable st = new sqlTable();

            #region 设计工作量
            string designTableName = "Design";//表名
            string[] designSourceList = { "number", "project_number", "project_name", "drawing_number", "A1_number", "zhehe_working_day", "month_day", "program_day", "basic_design_day", "leader", "remark" };//查看列名
            string[] designSelectList = { "year", "month", "username" };//限定列名
            string[] designSelectValue = { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), username };//限定列值

            //连接数据查看并显示在网页
            DataTable designCmd = st.selectLoop(designTableName, designSourceList, designSelectList, designSelectValue);
            if (designCmd != null)
            {
                Design_Repeater.DataSource = designCmd;
                Design_Repeater.DataBind();
            }
            #endregion

            #region 编程/画面工作量
            string programTableName = "Programing_Picture";//表名
            string[] programSourceList = { "number", "project_name", "digital_number", "analog_number", "programing_picture", "programing_day", "month_day", "remark" };//查看列名
            string[] programSelectList = { "year", "month", "username" };//限定列名
            string[] programSelectValue = { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), username };//限定列值

            //连接数据查看并显示在网页
            DataTable programCmd = st.selectLoop(programTableName, programSourceList, programSelectList, programSelectValue);
            if (programCmd != null)
            {
                Programming_Picture_Repeater.DataSource = programCmd;
                Programming_Picture_Repeater.DataBind();
            }
            #endregion

            #region 调试/工程管理工作量
            string debugTableName = "Debug";//表名
            string[] debugSourceList = { "number", "projectname", "site", "manageday", "debugday", "remark" };//查看列名
            string[] debugSelectList = { "year", "month", "username" };//限定列名
            string[] debugSelectValue = { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), username };//限定列值

            //连接数据查看并显示在网页
            DataTable debugCmd = st.selectLoop(debugTableName, debugSourceList, debugSelectList, debugSelectValue);
            if (debugCmd != null)
            {
                Debug_Repeater.DataSource = debugCmd;
                Debug_Repeater.DataBind();
            }
            #endregion

            #region 经营工作量
            string manageWorkingTableName = " Manage_Working";//表名
            string[] manageWorkingSourceList = { "number", "project_name", "xunjia_baojia", "tender", "sign", "toubiao", "equip", "test", "cuikuan", "contract", "other", "PM_day", "remark" };//查看列名
            string[] manageWorkingSelectList = { "year", "month", "username" };//限定列名
            string[] manageWorkingSelectValue = { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), username };//限定列值

            //连接数据查看并显示在网页
            DataTable manageWorkingCmd = st.selectLoop(manageWorkingTableName, manageWorkingSourceList, manageWorkingSelectList, manageWorkingSelectValue);
            if (manageWorkingCmd != null)
            {
                Manage_Working_Repeater.DataSource = manageWorkingCmd;
                Manage_Working_Repeater.DataBind();
            }
            #endregion

            #region 日常管理工作量
            string DailyManageTableName = " Daily_Manage";//表名
            string[] DailyManageSourceList = { "number", "management", "affair_gonghui", "affair_dangzu", "affair_tuanzu", "examine", "kaoqin", "other", "month_day", "remark" };//查看列名
            string[] DailyManageSelectList = { "year", "month", "username" };//限定列名
            string[] DailyManageSelectValue = { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), username };//限定列值

            //连接数据查看并显示在网页
            DataTable DailyManageCmd = st.selectLoop(DailyManageTableName, DailyManageSourceList, DailyManageSelectList, DailyManageSelectValue);
            if (DailyManageCmd != null)
            {
                Daily_Manage_Repeater.DataSource = DailyManageCmd;
                Daily_Manage_Repeater.DataBind();
            }
            #endregion

            #region 零星工日
            string lingXingTableName = " LingXing";//表名
            string[] lingXingSourceList = { "number", "chuchai_day", "jiaoliu_day", "other_day", "remark" };//查看列名
            string[] lingXingSelectList = { "year", "month", "username" };//限定列名
            string[] lingXingSelectValue = { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), username };//限定列值

            //连接数据查看并显示在网页
            DataTable lingXingCmd = st.selectLoop(lingXingTableName, lingXingSourceList, lingXingSelectList, lingXingSelectValue);
            if (lingXingCmd != null)
            {
                LingXing_Repeater.DataSource = lingXingCmd;
                LingXing_Repeater.DataBind();
            }
            #endregion

            #region 本月工日之和
            string summaryTableName = "Summary";//表名
            string[] summarySourceList = { "work_day" };//查看列名
            string[] summarySelectList = { "year", "month", "username" };//限定列名
            string[] summarySelectValue = { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), username };//限定列值

            //连接数据查看并显示在网页
            DataTable summaryCmd = st.selectLoop(summaryTableName, summarySourceList, summarySelectList, summarySelectValue);
            if (summaryCmd != null)
            {
                Summary_Repeater.DataSource = summaryCmd;
                Summary_Repeater.DataBind();
            }
            #endregion
        }
    }
}