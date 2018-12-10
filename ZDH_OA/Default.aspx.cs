using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDH_OA.App_Code;

namespace ZDH_OA
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
        }

        //登录
        protected void login_Click(object sender, EventArgs e)
        {
            sqlTable st = new sqlTable();
            string[] value = new string[7];
            string[] list = { "power", "username", "password", "name", "team", "transfer", "on_job" };

            string username = UserName.Text.Trim();
            string password = Password.Text.Trim();
            if (username == "")
            {
                Response.Write(@"<script>alert('用户名不能为空！');</script>");
            }
            else if (password == "")
            {
                Response.Write(@"<script>alert('密码不能为空！');</script>");
            }
            else
            {

                st.select_login(username, value, "Login", list);


                // root 跳转
                if (int.Parse(value[6]) == 1)
                {

                    if (username == value[1])
                    {
                        if (password == value[2])
                        {
                            if (int.Parse(value[0]) == 0)
                            {
                                //session存储用户信息
                                HttpContext.Current.Session["power"] = value[0];//权限
                                HttpContext.Current.Session["username"] = value[1];//获取用户名
                                HttpContext.Current.Session["userpwd"] = value[2];//获取密码
                                HttpContext.Current.Session["name"] = value[3];//获取用户名字
                                HttpContext.Current.Session["team"] = value[4];//获取用户小组
                                HttpContext.Current.Session["transfer"] = value[5];//获取用户借调状态
                                Response.Redirect("Root/Root.aspx");
                            }
                            else if (int.Parse(value[0]) == 1)
                            {
                                //session存储用户信息
                                HttpContext.Current.Session["power"] = value[0];//权限
                                HttpContext.Current.Session["username"] = value[1];//获取用户名
                                HttpContext.Current.Session["userpwd"] = value[2];//获取密码
                                HttpContext.Current.Session["name"] = value[3];//获取用户名字
                                HttpContext.Current.Session["team"] = value[4];//获取用户小组
                                HttpContext.Current.Session["transfer"] = value[5];//获取用户借调状态
                                Response.Redirect("Director/Director.aspx");
                            }
                            else
                            {
                                //session存储用户信息
                                HttpContext.Current.Session["power"] = value[0];//权限
                                HttpContext.Current.Session["username"] = value[1];//获取用户名
                                HttpContext.Current.Session["userpwd"] = value[2];//获取密码
                                HttpContext.Current.Session["name"] = value[3];//获取用户名字
                                HttpContext.Current.Session["team"] = value[4];//获取用户小组
                                HttpContext.Current.Session["transfer"] = value[5];//获取用户借调状态
                                if (value[1] == "zdhzls01")
                                {
                                    Response.Redirect("DeputyDirector/DeputyDirector.aspx");
                                }
                                if (value[5] == "1")
                                {
                                    Response.Redirect("Jiediao/Work.aspx");
                                }
                                else
                                {
                                    Response.Redirect("Work.aspx");
                                }
                            }
                        }
                        else
                        {
                            Response.Write(@"<script>alert('密码输入有误！');</script>");
                        }


                    }
                    else
                    {
                        Response.Write(@"<script>alert('用户名输入有误！');</script>");
                    }
                }
                else
                {
                    Response.Write(@"<script>alert('您已离职，无登录权限！');</script>");
                }
            }
        }

        //修改密码
        protected void changePass_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePass.aspx");
        }
    }
}