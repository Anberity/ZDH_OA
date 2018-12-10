using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDH_OA.App_Code;

namespace ZDH_OA.Root
{
    public partial class Root : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            sqlTable st = new sqlTable();
            string[] value = new string[5];
            string[] list = { "power", "username", "password", "name", "team" };
            st.select_login("root", value, "Login", list);

            try
            {
                if (HttpContext.Current.Session["username"].ToString() != "root" || HttpContext.Current.Session["userpwd"].ToString() != value[2])
                {
                    Response.Write(" <script> alert( '您无权访问此页面');window.location.href= 'Default.aspx ' </script> ");
                }
            }
            catch (Exception)
            {
                Response.Write(" <script> alert( '您无权访问此页面');window.location.href= '../Default.aspx' </script> ");
            }

            string name = null;
            try
            {
                name = HttpContext.Current.Session["name"].ToString();
            }
            catch (Exception)
            {
                Response.Write(" <script> alert( '登录超时，请重新登录');window.location.href= '../Default.aspx' </script> ");
            }
            Response.Write(" <script>window.onload=function(){ var name=document.getElementById('name'); name.innerHTML='欢迎你，" + name + "'} </script> ");
        }

        //注销
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