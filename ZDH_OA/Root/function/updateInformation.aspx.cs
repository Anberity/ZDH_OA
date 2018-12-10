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
    public partial class updateInformation : System.Web.UI.Page
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

        //查询
        protected void Select_Click(object sender, EventArgs e)
        {
            string NewUserName = Username.Text.ToString().Trim();//用户名

            string[] value = new string[8];
            string[] list01 = { "power", "username", "password", "name", "team", "transfer", "peoplenumber", "on_job" };
            sqlTable st = new sqlTable();
            st.select_login(NewUserName, value, "Login", list01);

            if (value[0] == "18")
            {
                Post.Value = "18";
            }
            else if (value[0] == "1")
            {
                Post.Value = "1";
            }
            else if (value[0] == "2" || value[0] == "3" || value[0] == "4" || value[0] == "5" || value[0] == "6")
            {
                switch (value[0])
                {
                    case "2":
                        Post.Value = "2";
                        fzr.Value = "2";
                        break;
                    case "3":
                        Post.Value = "2";
                        fzr.Value = "3";
                        break;
                    case "4":
                        Post.Value = "2";
                        fzr.Value = "4";
                        break;
                    case "5":
                        Post.Value = "2";
                        fzr.Value = "5";
                        break;
                    default:
                        Post.Value = "2";
                        fzr.Value = "6";
                        break;
                }
            }
            Username.Text = value[1];
            Pwd.Text = value[2];
            PeopleName.Text = value[3];
            group2.Value = value[4];
            if (value[5] == "1")
            {
                JieDiao.Text = "已借调";
            }
            else
            {
                JieDiao.Text = "未借调";
            }
            StaffNumber.Text = value[6];

            if (value[7] == "1")
            {
                OnJob.Text = "在职";
            }
            else
            {
                OnJob.Text = "已离职";
            }
        }

        //修改
        protected void submit_Click(object sender, EventArgs e)
        {
            string power = Request.Form["Post"].ToString().Trim();//职位
            if (power == "2")
            {
                power = Request.Form["fzr"].ToString().Trim();
            }
            string NewUserName = Username.Text.ToString().Trim();//用户名
            string NewUserPass = Pwd.Text.ToString().Trim();//密码
            string RealName = PeopleName.Text.ToString().Trim();//真实姓名
            string team = group2.Value;//获取小组
            string transfer = JieDiao.Text.ToString().Trim();//借调
            if (transfer == "已借调")
            {
                transfer = "1";
            }
            else
            {
                transfer = "0";
            }
            string peonumber = StaffNumber.Text.ToString().Trim();//员工编号
            string on_job = OnJob.Text.ToString().Trim();
            if (on_job == "在职")
            {
                on_job = "1";
            }
            else
            {
                on_job = "0";
            }

            sqlTable st = new sqlTable();
            string[] list01 = { "power", "password", "name", "team", "transfer", "peoplenumber", "on_job" };
            string[] list02 = { power, NewUserPass, RealName, team, transfer, peonumber, on_job };
            string[] list03 = { "username" };
            string[] list04 = { NewUserName };
            int res = st.table_update("Login", list01, list02, list03, list04);

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