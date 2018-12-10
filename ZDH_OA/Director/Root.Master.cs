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
    public partial class Root : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (HttpContext.Current.Session["username"].ToString() != "zdhqxc" || HttpContext.Current.Session["userpwd"].ToString() == "null")
                {
                    HttpContext.Current.Response.Write(" <script> alert( '您还未登陆，请先登录！！！');window.location.href= '../Default.aspx ' </script> ");
                }
                string name = HttpContext.Current.Session["name"].ToString();
                Response.Write(" <script>window.onload=function(){ var name=document.getElementById('name'); name.innerHTML='欢迎您，" + name + "主任'} </script> ");
            }
            catch (Exception)
            {
                HttpContext.Current.Response.Write(" <script> alert( '您还未登陆，请先登录！！！');window.location.href= '../Default.aspx ' </script> ");
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["power"] = "null";//权限
            HttpContext.Current.Session["username"] = "null";//获取用户名
            HttpContext.Current.Session["userpwd"] = "null";//获取密码
            HttpContext.Current.Session["name"] = "null";//获取用户名字
            HttpContext.Current.Session["team"] = "null";//获取用户小组
            HttpContext.Current.Session["transfer"] = "null";//获取用户借调状态
            HttpContext.Current.Session["yearh"] = DateTime.Now.Year.ToString();//历史年份
            HttpContext.Current.Session["monh"] = DateTime.Now.Month.ToString();//历史月份
            HttpContext.Current.Session["months"] = DateTime.Now.Month.ToString();//汇总查看月份
            HttpContext.Current.Session["years"] = DateTime.Now.Month.ToString();//汇总查看年份
            HttpContext.Current.Session["yearuser"] = DateTime.Now.Month.ToString();//按年查看员工汇总
            HttpContext.Current.Session["numberMonth"] = "0";//月份汇总
            HttpContext.Current.Session["numberYear"] = "0";//年份汇总
            HttpContext.Current.Session["userYear"] = "0";//员工年份汇总
            HttpContext.Current.Response.Write(" <script>window.location.href= '../Default.aspx' </script> ");
        }
    }
}