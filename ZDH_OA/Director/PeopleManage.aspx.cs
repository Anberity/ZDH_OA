using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDH_OA.App_Code;

namespace ZDH_OA.Director
{
    public partial class PeopleManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (HttpContext.Current.Session["username"].ToString() != "zdhqxc" || HttpContext.Current.Session["userpwd"].ToString() == "null")
                {
                    HttpContext.Current.Response.Write(" <script> alert( '您还未登陆，请先登录！！！');window.parent.location.href= '../Default.aspx' </script> ");
                }
                string name = HttpContext.Current.Session["name"].ToString();
                Response.Write(" <script>window.onload=function(){ var name=document.getElementById('name'); name.innerHTML='欢迎你，" + name + "主任'} </script> ");
            }
            catch (Exception)
            {
                HttpContext.Current.Response.Write(" <script> alert( '您还未登陆，请先登录！！！');window.parent.location.href= '../Default.aspx' </script> ");
            }
            sqlTable st = new sqlTable();
            string tableName = "Login";
            string[] list = { "username", "password", "name", "on_job" };
            DataTable loginCmd = st.selectUser(tableName, list);
            if (loginCmd != null)
            {
                Username_Repeater.DataSource = loginCmd;
                Username_Repeater.DataBind();
            }
        }

        protected void JobStatusBtn_Click(object sender, EventArgs e)
        {
            string username = off_username.Text.Trim();//用户名
            string jobStatus = Request.Form["jobstatus"].ToString().Trim();//工作状态

            //查找是否有此用户
            string[] pwd = new string[1];
            string[] list01 = { "password" };
            sqlTable st = new sqlTable();
            st.select_onjob(username, pwd, "Login", list01);



            if (pwd[0] == "NULL" || pwd[0] == "null")
            {
                Response.Write("<script>alert('员工姓名输入有误，请重新输入')</script>");
            }
            else
            {
                //更新状态
                string[] list = { "on_job" };
                string[] source = { jobStatus };
                string[] selectList = { "name" };
                string[] selectSource = { username };
                int res = st.table_update("Login", list, source, selectList, selectSource);

                if (res == 1)
                {
                    Response.Write("<script>alert('修改成功')</script>");
                    Page_Load(sender, e);
                }
                else
                {
                    Response.Write("<script>alert('语法错误')</script>");
                }
            }
        }
    }
}