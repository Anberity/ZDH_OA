using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDH_OA.App_Code;

namespace ZDH_OA.Jiediao
{
    public partial class Jiediao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (HttpContext.Current.Session["username"].ToString() == "null" || HttpContext.Current.Session["userpwd"].ToString() == "null")
                {
                    HttpContext.Current.Response.Write(" <script> alert( '您还未登陆，请先登录！！！');window.parent.location.href= '../Default.aspx' </script> ");
                }
                string name = HttpContext.Current.Session["name"].ToString();
                string[] selist = { "year", "month", "username" };
                string[] solist = { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), HttpContext.Current.Session["username"].ToString() };
                string[] res = new string[1];
                string[] sellist = { "transfer" };
                sqlTable st = new sqlTable();
                st.select_easy(selist, solist, res, "Jiediao", sellist);
                string tran = res[0];
                Response.Write(" <script>window.onload=function(){  var tran=document.getElementById('tran'); tran.innerHTML='您已被" + tran + ",借调结束请点击下面按钮'} </script> ");
            }
            catch (Exception)
            {
                HttpContext.Current.Response.Write(" <script> alert( '您还未登陆，请先登录！！！');window.parent.location.href= '../Default.aspx' </script> ");
            }
        }

        //借调结束
        protected void OnJob_Click(object sender, EventArgs e)
        {
            string username = HttpContext.Current.Session["username"].ToString();

            //查找借调状态
            string[] onJob = new string[1];
            string[] seList = { "transfer" };
            sqlTable st = new sqlTable();
            st.select_login(username, onJob, "Login", seList);

            if (onJob[0] == "0")
            {
                Response.Write("<script>alert('您未被调至其他部门')</script>");
            }
            else if (onJob[0] == "1")
            {
                string[] soList = { "0" };
                string[] usese = { "username", "password" };
                string[] useso = { HttpContext.Current.Session["username"].ToString(), HttpContext.Current.Session["userpwd"].ToString() };
                int res2 = st.table_update("Login", seList, soList, usese, useso);

                //删除本月借调
                string tableName = "Jiediao";
                string[] delist = { "year", "month", "username" };
                string[] deValue = { DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), HttpContext.Current.Session["username"].ToString() };
                int res3 = st.table_delete(tableName, delist, deValue);
            }

            Response.Write("<script>alert('借调结束');;window.parent.location.href= '../Work.aspx' </script>");
        }
    }
}