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
    public partial class addPeople : System.Web.UI.Page
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
            String NewUserName = add_username.Text.ToString().Trim();//用户名
            String NewUserPass = add_userpass.Text.ToString().Trim();//密码
            String RealName = add_realname.Text.ToString().Trim();//真实姓名
            String Job = Request.Form["job"].ToString().Trim();//power
            String Master = Request.Form["master"].ToString().Trim();//副主任
            string peonumber = PeopleNumber.Text.ToString().Trim();//员工编号
            int power = 0;
            switch (Job)
            {
                case "职员":
                    power = 18;
                    break;
                case "2":
                    switch (Master)
                    {
                        case "项目管理副主任":
                            power = 2;
                            break;
                        case "设计管理副主任":
                            power = 3;
                            break;
                        case "编程管理副主任":
                            power = 4;
                            break;
                        case "软件管理副主任":
                            power = 5;
                            break;
                        case "仪表管理副主任":
                            power = 6;
                            break;
                    }
                    break;
                default:
                    power = 1;
                    break;
            }
            String Group = Request.Form["group"].ToString().Trim();//小组
            if (Group == "自动化")
            {
                Group = "1";
            }
            else if (Group == "软件")

            {
                Group = "2";
            }
            else if (Group == "营销")
            {
                Group = "3";
            }
            else if (Group == "管理层")
            {
                Group = "0";
            }
            //列名以及数据源
            string[] list = { "power", "username", "password", "name", "team", "transfer", "peoplenumber", "on_job" };
            string[] source = { power.ToString(), NewUserName, NewUserPass, RealName, Group, "0", peonumber, "1" };

            //插入
            if (NewUserName == "" || NewUserPass == "" || RealName == "")
            {
                Response.Write("<script>alert('请输入完整信息')</script>");
            }
            else
            {
                sqlTable st = new sqlTable();
                int res = st.table_insert("Login", list, source);
                if (res == 1)
                {
                    Response.Write("<script>alert('成功')</script>");
                }
                else
                {
                    Response.Write("<script>alert('输入有误，请重新输入')</script>");
                }
            }
        }
    }
}