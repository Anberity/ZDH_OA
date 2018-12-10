using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDH_OA.App_Code;

namespace ZDH_OA.Root.function
{
    public partial class offJob : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void submit_Click(object sender, EventArgs e)
        {
            string username = off_username.Text.Trim();//用户名
            string jobStatus = Request.Form["jobstatus"].ToString().Trim();//工作状态

            //查找是否有此用户
            string[] pwd = new string[1];
            string[] list01 = { "password" };
            sqlTable st = new sqlTable();
            st.select_login(username, pwd, "Login", list01);

            //更新状态
            string[] list = { "on_job" };
            string[] source = { jobStatus };
            string[] selectList = { "username" };
            string[] selectSource = { username };

            if (pwd[0] == "NULL" || pwd[0] == "null")
            {
                Response.Write("<script>alert('输入用户名有误，请重新输入')</script>");
            }
            else
            {
                int res = st.table_update("Login", list, source, selectList, selectSource);

                if (res == 1)
                {
                    Response.Write("<script>alert('修改成功')</script>");
                }
                else
                {
                    Response.Write("<script>alert('语法错误')</script>");
                }
            }
        }
    }
}