using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDH_OA.App_Code;

namespace ZDH_OA.Employee.form
{
    public partial class LingXing : System.Web.UI.Page
    {
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
        }

        //增加事件
        protected void submit_Click(object sender, EventArgs e)
        {
            sqlTable st = new sqlTable();
            int number = 0;//填写序号

            //获取年月日以及用户名，小组
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string username = HttpContext.Current.Session["username"].ToString();
            string team = HttpContext.Current.Session["team"].ToString();

            //借调判断
            if (HttpContext.Current.Session["transfer"].ToString() == "1")
            {
                string tableNames = "Jiediao";
                string[] result = new string[1];
                string[] col = { "transfer" };
                string[] translist = { "year", "month", "username" };
                string[] transsource = { year, month, username };
                st.select_delete(tableNames, result, translist, transsource, col);
                Response.Write("<script>alert('您已被" + result[0] + "，不可填写')</script>");
                return;
            }


            //网页输入
            string New_add_business = add_business.Text.Trim();//本月出差天数
            string New_add_technical = add_technical.Text.Trim();//技术交流天数
            string New_add_others = add_others.Text.Trim();//其他零星工日
            string New_add_remarks = add_remarks.Text.Trim();//备注

            //全为空不允许填写
            if (New_add_business == "" && New_add_technical == "" && New_add_others == "" && New_add_remarks == "")
            {
                Response.Write("<script>alert('插入工作量为空，请重新填写')</script>");
                return;
            }

            //number在原有基础上加1
            string list1 = "number";
            string[] value = new string[1];
            string[] tableName = { "Daily_Manage", "Debug", "Design", "LingXing", "Manage_Working", "Programing_Picture" };

            st.select_number(list1, value, tableName, year, month, username);
            if (value[0] != "" && value[0] != "NULL" && value[0] != "null")
            {
                number = int.Parse(value[0]) + 1;
            }
            else
            {
                number = 1;
            }
            //列名以及数据源
            string[] list = { "year", "month", "username", "team", "number", "chuchai_day", "jiaoliu_day", "other_day", "remark" };
            string[] source = { year, month, username, team, number.ToString(), New_add_business, New_add_technical, New_add_others, New_add_remarks };

            //插入
            int res = st.table_insert("LingXing", list, source);

            if (res == 1)
            {
                Response.Write("<script>alert('成功')</script>");
            }
            else if (res == 0)
            {
                Response.Write("<script>alert('输入有误，请重新输入')</script>");
            }
            else
            {
                Response.Write("<script>alert('语法错误')</script>");
            }
        }

        //修改事件
        protected void modifybtn_Click(object sender, EventArgs e)
        {
            sqlTable st = new sqlTable();

            //获取年月日以及用户名，小组
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string username = HttpContext.Current.Session["username"].ToString();

            //借调判断
            if (HttpContext.Current.Session["transfer"].ToString() == "1")
            {
                string tableNames = "Jiediao";
                string[] result = new string[1];
                string[] col = { "transfer" };
                string[] translist = { "year", "month", "username" };
                string[] transsource = { year, month, username };
                st.select_delete(tableNames, result, translist, transsource, col);
                Response.Write("<script>alert('您已被" + result[0] + "，不可修改')</script>");
                return;
            }

            //网页输入
            string New_add_index = add_index.Text.Trim(); // 索引
            string New_add_business = add_business.Text.Trim();//本月出差天数
            string New_add_technical = add_technical.Text.Trim();//技术交流天数
            string New_add_others = add_others.Text.Trim();//其他零星工日
            string New_add_remarks = add_remarks.Text.Trim();//备注

            //查找索引是否存在
            string[] listNumber = { "year", "month", "username", "number" };
            string[] sourceNumber = { year, month, username, New_add_index };
            string[] selectNumber = { "number" };
            string tableNameNumber = "LingXing";
            string[] resNumber = new string[1];
            st.select_delete(tableNameNumber, resNumber, listNumber, sourceNumber, selectNumber);
            if (New_add_index != resNumber[0])
            {
                Response.Write("<script>alert('填写序号有误')</script>");
                return;
            }

            //更新列名以及数据源
            string[] list = { "chuchai_day", "jiaoliu_day", "other_day", "remark" };
            string[] source = { New_add_business, New_add_technical, New_add_others, New_add_remarks };

            //查找列名以及数据源
            string[] selectList = { "year", "month", "username", "number" };
            string[] selectSource = { year, month, username, New_add_index };

            //插入
            int res = st.table_update("LingXing", list, source, selectList, selectSource);

            if (res == 1)
            {
                Response.Write("<script>alert('成功')</script>");
            }
            else if (res == 0)
            {
                Response.Write("<script>alert('输入有误，请重新输入')</script>");
            }
            else if (res == 2)
            {
                Response.Write("<script>alert('语法错误')</script>");
            }
        }

        //删除事件
        protected void delete_Click(object sender, EventArgs e)
        {
            sqlTable st = new sqlTable();

            //获取年月日以及用户名，小组
            string year = DateTime.Now.Year.ToString();//获取当前年份
            string month = DateTime.Now.Month.ToString();//获取当前月份
            string username = HttpContext.Current.Session["username"].ToString();//获取当前用户名

            //借调判断
            if (HttpContext.Current.Session["transfer"].ToString() == "1")
            {
                string tableNames = "Jiediao";
                string[] result = new string[1];
                string[] col = { "transfer" };
                string[] translist = { "year", "month", "username" };
                string[] transsource = { year, month, username };
                st.select_delete(tableNames, result, translist, transsource, col);
                Response.Write("<script>alert('您已被" + result[0] + "，无法删除')</script>");
                return;
            }

            //网页输入
            string New_add_index = add_index.Text.Trim(); //添加索引
                                                          //查找索引是否存在
            string[] listNumber = { "year", "month", "username", "number" };
            string[] sourceNumber = { year, month, username, New_add_index };
            string[] selectNumber = { "number" };
            string tableNameNumber = "LingXing";
            string[] resNumber = new string[1];
            st.select_delete(tableNameNumber, resNumber, listNumber, sourceNumber, selectNumber);
            if (New_add_index != resNumber[0])
            {
                Response.Write("<script>alert('填写序号有误')</script>");
                return;
            }

            //查找原来日常工作量当月汇总
            string[] list5 = { "year", "month", "username", "number" };
            string[] source5 = { year, month, username, New_add_index };
            int res = st.table_delete("LingXing", list5, source5);

            #region 修改number值
            string[] tableName = { "Daily_Manage", "Debug", "Design", "LingXing", "Manage_Working", "Programing_Picture" };
            string[] columns = { "number" };
            String[,] temp = new String[30, 1];
            String[,] temp1 = new String[30, 1];
            string[] xianding = { "year", "month", "username" };
            string[] xdValue = { year, month, username };

            for (int k = 0; k < tableName.Length; k++)
            {
                for (int j = 0; j < temp.Length; j++)
                {
                    temp[j, 0] = null;
                }
                //st.page_flash(temp, tableName[k], columns);//tableName[i]
                st.selecet_number(temp, tableName[k], columns, xianding, xdValue);
                for (int i = 0; i < temp.GetLength(0); i++)
                {
                    if (temp[i, 0] == null)
                    {
                        break;
                    }
                    if (int.Parse(temp[i, 0]) > int.Parse(New_add_index))
                    {
                        temp1[i, 0] = temp[i, 0];
                        temp[i, 0] = (int.Parse(temp[i, 0]) - 1).ToString();
                        string[] temp2 = new string[1];
                        temp2[0] = temp[i, 0];
                        string[] upsource = { year, month, username, temp1[i, 0] };
                        st.table_update(tableName[k], columns, temp2, list5, upsource);
                    }
                }
            }
            #endregion

            if (res == 1)
            {
                Response.Write("<script>alert('成功')</script>");
            }
            else if (res == 0)
            {
                Response.Write("<script>alert('输入有误，请重新输入')</script>");
            }
            else if (res == 2)
            {
                Response.Write("<script>alert('语法错误')</script>");
            }
        }

        //修改内容拉取
        protected void add_Click(object sender, EventArgs e)
        {
            sqlTable st = new sqlTable();

            //网页输入
            string New_add_index = add_index.Text.Trim(); // 索引
                                                          //获取年月日以及用户名
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string username = HttpContext.Current.Session["username"].ToString();

            //查找索引是否存在
            string[] listNumber = { "year", "month", "username", "number" };
            string[] sourceNumber = { year, month, username, New_add_index };
            string[] selectNumber = { "number" };
            string tableNameNumber = "LingXing";
            string[] resNumber = new string[1];
            st.select_delete(tableNameNumber, resNumber, listNumber, sourceNumber, selectNumber);
            if (New_add_index != resNumber[0])
            {
                Response.Write("<script>alert('填写序号有误')</script>");
                return;
            }

            //查找原来日常工作量当月汇总
            string[] list = { "year", "month", "username", "number" };
            string[] source = { year, month, username, New_add_index };
            string[] select_List = { "chuchai_day", "jiaoliu_day", "other_day", "remark" };
            string[] data = new string[4];
            st.select_delete("LingXing", data, list, source, select_List);

            //text框赋值
            add_business.Text = data[0];//本月出差天数
            add_technical.Text = data[1];//技术交流天数
            add_others.Text = data[2];//其他零星工日
            add_remarks.Text = data[3];//备注
        }
    }
}