using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;

namespace ZDH_OA.App_Code
{
    public class sqlTable
    {
        DataLogic dal = new DataLogic();

        /// <summary>
        /// 数据库内容添加
        /// </summary>
        /// <param name="table_name">表名</param>
        /// <param name="columns">列名</param>
        /// <param name="values">插入内容</param>
        /// <returns>是否成功，0--失败，1--成功</returns>
        public int table_insert(string table_name, string[] columns, string[] values)
        {
            string sql = "insert into ";
            try
            {
                if (columns.Length == 0 || columns.Length != values.Length) return 0;

                sql += table_name;
                sql += " (";

                int a = Math.Min(columns.Length, values.Length);
                for (int i = 0; i < a; i++)
                {
                    sql += columns[i] + ",";
                }
                sql = sql.Substring(0, sql.Length - 1);
                sql += ") values ('";
                for (int i = 0; i < a; i++)
                {
                    sql += values[i] + "','";
                }
                sql = sql.Substring(0, sql.Length - 3);
                sql += "')";


                int Exe = dal.ExecDataBySql(sql);
                return 1;
            }
            catch (Exception e)
            {
                throw e;
                //return 0;
            }
        }

        /// <summary>
        /// 数据库内容删除
        /// </summary>
        /// <param name="table_name">表名</param>
        /// <param name="columns">列名</param>
        /// <param name="values">列值</param>
        /// <returns>是否成功，0--失败，1--成功</returns>
        public int table_delete(string table_name, string[] columns, string[] values)
        {
            string sql = "DELETE FROM " + table_name + " WHERE ";
            try
            {
                if (columns.Length == 0 || columns.Length != values.Length) return 0;

                int a = Math.Min(columns.Length, values.Length);
                for (int i = 0; i < a; i++)
                {
                    sql += columns[i] + " = '" + values[i] + "' AND ";
                }
                sql = sql.Substring(0, sql.Length - 5);

                int Exe = dal.ExecDataBySql(sql);
                return 1;
            }
            catch (Exception e)
            {
                return 2;
            }
        }

        /// <summary>
        /// 数据库内容更新
        /// </summary>
        /// <param name="table_name">表名</param>
        /// <param name="columns1">更新列名</param>
        /// <param name="values1">更新值</param>
        /// <param name="columns2">查找列名</param>
        /// <param name="values2">查找值</param>
        /// <returns></returns>
        public int table_update(string table_name, string[] columns1, string[] values1, string[] columns2, string[] values2)
        {
            string sql = "UPDATE " + table_name + " SET ";
            try
            {
                if (columns1.Length == 0 || columns1.Length != values1.Length) return 0;

                int a = Math.Min(columns1.Length, values1.Length);
                for (int i = 0; i < a; i++)
                {
                    sql += columns1[i] + " = '" + values1[i] + "',";
                }
                sql = sql.Substring(0, sql.Length - 1);
                sql += " WHERE ";

                if (columns2.Length == 0 || columns2.Length != values2.Length) return 0;
                a = Math.Min(columns2.Length, values2.Length);
                for (int i = 0; i < a; i++)
                {
                    sql += columns2[i] + " = '" + values2[i] + "' AND ";
                }

                sql = sql.Substring(0, sql.Length - 5);

                int Exe = dal.ExecDataBySql(sql);
                return 1;
            }
            catch (Exception e)
            {
                return 2;
            }
        }

        /// <summary>
        /// 数据库查找
        /// </summary>
        /// <param name="mySql">查询结果</param>
        /// <param name="table">表名</param>
        /// <param name="columns">列名</param>
        public void page_flash(String[,] mySql, string table, string[] columns)
        {
            int err = 0;
            string sql = "select TOP " + mySql.Length + " ";

            foreach (string i in columns)
            {
                sql += i + ",";
            }
            sql = sql.Substring(0, sql.Length - 1);
            sql += " FROM " + table;

            DataSet ds = dal.GetDataSet(sql, table);

            for (int i = 0; i < mySql.GetLength(0); i++)//mySql.Length
            {
                for (int j = 0; j < mySql.GetLength(1); j++)//mySql[i].Length//mySql.GetLength(0)
                {
                    try
                    {
                        string temp13 = "0";
                        if (ds.Tables[0].Rows[i][j].ToString() != null)
                        {
                            temp13 = ds.Tables[0].Rows[i][j].ToString();


                        }
                        mySql[i, j] = temp13;
                    }
                    catch (Exception Error)
                    {

                        err++;
                    }
                }
            }
            if (err != 0)
            {
            }
        }

        /// <summary>
        /// 登录查询
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="mySql">查询结果</param>
        /// <param name="table">表名</param>
        /// <param name="columns">列名</param>
        public void select_login(string username, String[] mySql, string table, string[] columns)
        {
            string sql = "SELECT ";

            foreach (string i in columns)
            {
                sql += i + ",";
            }
            sql = sql.Substring(0, sql.Length - 1);
            sql += " FROM " + table + " WHERE username='" + username + "'";

            DataSet ds = dal.GetDataSet(sql, table);
            try
            {
                for (int j = 0; j < mySql.Length; j++)
                {
                    string temp13 = "0";
                    if (ds.Tables[0].Rows[0][j].ToString() != null)
                    {
                        temp13 = ds.Tables[0].Rows[0][j].ToString();
                    }
                    mySql[j] = temp13;
                }
            }
            catch (Exception Error)
            {

                for (int i = 0; i < mySql.Length; i++)
                {
                    mySql[i] = "NULL";
                }
            }

        }

        /// <summary>
        /// 登录查询
        /// </summary>
        /// <param name="username">用户姓名</param>
        /// <param name="mySql">查询结果</param>
        /// <param name="table">表名</param>
        /// <param name="columns">列名</param>
        public void select_onjob(string username, String[] mySql, string table, string[] columns)
        {
            string sql = "SELECT ";

            foreach (string i in columns)
            {
                sql += i + ",";
            }
            sql = sql.Substring(0, sql.Length - 1);
            sql += " FROM " + table + " WHERE name='" + username + "'";

            DataSet ds = dal.GetDataSet(sql, table);
            try
            {
                for (int j = 0; j < mySql.Length; j++)
                {
                    string temp13 = "0";
                    if (ds.Tables[0].Rows[0][j].ToString() != null)
                    {
                        temp13 = ds.Tables[0].Rows[0][j].ToString();
                    }
                    mySql[j] = temp13;
                }
            }
            catch (Exception Error)
            {

                for (int i = 0; i < mySql.Length; i++)
                {
                    mySql[i] = "NULL";
                }
            }

        }

        /// <summary>
        /// 简单查找
        /// </summary>
        /// <param name="selist">限定列</param>
        /// <param name="solist">限定值</param>
        /// <param name="mySql">查询结果</param>
        /// <param name="table">表名</param>
        /// <param name="columns">查找列</param>
        public void select_easy(string[] selist, string[] solist, String[] mySql, string table, string[] columns)
        {
            string sql = "SELECT ";

            foreach (string i in columns)
            {
                sql += i + ",";
            }
            sql = sql.Substring(0, sql.Length - 1);
            sql += " FROM " + table + " WHERE ";//name='" + username + "'";

            for (int i = 0; i < solist.Length; i++)
            {
                sql += selist[i] + " = '" + solist[i] + "' AND ";
            }
            sql = sql.Substring(0, sql.Length - 5);

            DataSet ds = dal.GetDataSet(sql, table);
            try
            {
                for (int j = 0; j < mySql.Length; j++)
                {
                    string temp13 = "null";
                    if (ds.Tables[0].Rows[0][j].ToString() != null)
                    {
                        temp13 = ds.Tables[0].Rows[0][j].ToString();
                    }
                    mySql[j] = temp13;
                }
            }
            catch (Exception Error)
            {

                for (int i = 0; i < mySql.Length; i++)
                {
                    mySql[i] = "NULL";
                }
            }

        }

        /// <summary>
        /// 多表联合查询单一列最大值
        /// </summary>
        /// <param name="list">列名</param>
        /// <param name="mySql">查询结果</param>
        /// <param name="tableName">表名</param>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <param name="username">用户名</param>
        public void select_number(string list, String[] mySql, string[] tableName, string year, string month, string username)
        {

            //SELECT MAX(CAST(number as int)) from (SELECT number from Daily_Manage WHERE year='2018' AND month='8' union SELECT number from Debug WHERE year='2018' AND month='8' union SELECT number from Design WHERE year='2018' AND month='8' union SELECT number from LingXing WHERE year='2018' AND month='8' union SELECT number from Manage_Working WHERE year='2018' AND month='8' union SELECT number from Programing_Picture WHERE year='2018' AND month='8' union SELECT number from Summary WHERE year='2018' AND month='8') A
            string sql = "SELECT MAX(CAST(" + list + " as int)) from (";

            foreach (string i in tableName)
            {
                sql += "SELECT " + list + " from " + i + " WHERE year = '" + year + "' AND month = '" + month + "' AND username = '" + username + "' union ";
            }
            sql = sql.Substring(0, sql.Length - 7);
            sql += ") A";

            DataTable dt = dal.GetDataTable1(sql);
            try
            {
                for (int j = 0; j < mySql.Length; j++)
                {
                    string temp13 = "0";
                    temp13 = dt.Rows[0][j].ToString();
                    mySql[0] = temp13;
                }
            }
            catch (Exception Error)
            {
                mySql[0] = "NULL";
            }
        }

        /// <summary>
        /// 删除查找
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="mySql">返回值</param>
        /// <param name="list">限定列名</param>
        /// <param name="source">限定值</param>
        /// <param name="columns">查找列名</param>
        public void select_delete(string tableName, string[] mySql, string[] list, string[] source, string[] columns)
        {
            string sql = "SELECT ";

            foreach (string i in columns)
            {
                sql += i + ",";
            }
            sql = sql.Substring(0, sql.Length - 1);
            sql += " FROM " + tableName + " WHERE ";

            for (int i = 0; i < list.Length; i++)
            {
                sql += list[i] + " = '" + source[i] + "' AND ";
            }
            sql = sql.Substring(0, sql.Length - 5);
            DataSet ds = dal.GetDataSet(sql, tableName);
            try
            {
                for (int j = 0; j < mySql.Length; j++)
                {
                    string temp13 = "0";
                    if (ds.Tables[0].Rows[0][j].ToString() != null)
                    {
                        temp13 = ds.Tables[0].Rows[0][j].ToString();
                    }
                    mySql[j] = temp13;
                }
            }
            catch (Exception Error)
            {

                for (int i = 0; i < mySql.Length; i++)
                {
                    mySql[i] = "NULL";
                }
            }

        }

        /// <summary>
        /// 按表修改序号查询
        /// </summary>
        /// <param name="mySql">返回值</param>
        /// <param name="tableName">表名</param>
        /// <param name="columns">查找列名</param>
        /// <param name="list">限定列名</param>
        /// <param name="source">限定列值</param>
        public void select_number_update(String[][] mySql, string tableName, string[] columns, string[] list, string[] source)
        {
            //SELECT * FROM OA.dbo.Debug WHERE year='2018' AND month='8' AND username='zdhhyz' AND CAST(number as int)>2 ORDER BY CAST(number as int) ASC
            int err = 0;
            string sql = "select ";

            foreach (string i in columns)
            {
                sql += i + ",";
            }
            sql = sql.Substring(0, sql.Length - 1);
            sql += " FROM " + tableName + " WHERE ";//+ " order by number DESC";

            for (int i = 0; i < list.Length - 1; i++)
            {
                sql += list[i] + " = '" + source[i] + "' AND ";
            }

            sql += "CAST(" + list[list.Length - 1] + "as int) > " + source[source.Length - 1] + " ORDER BY CAST(" + list[list.Length - 1] + "as int) ASC";

            DataSet ds = dal.GetDataSet(sql, tableName);

            for (int i = 0; i < mySql.Length; i++)
            {
                for (int j = 0; j < mySql[i].Length; j++)
                {
                    try
                    {
                        string temp13 = "0";
                        if (ds.Tables[0].Rows[i][j].ToString() != null)
                        {
                            temp13 = ds.Tables[0].Rows[i][j].ToString();


                        }
                        mySql[i][j] = temp13;
                    }
                    catch (Exception Error)
                    {

                        err++;
                    }
                }
            }
            if (err != 0)
            {
            }
        }

        /// <summary>
        /// 查找员工用户名
        /// </summary>
        /// <param name="name">员工姓名</param>
        /// <param name="mySql">返回数据</param>
        /// <param name="table">表名</param>
        /// <param name="columns">查找列名</param>
        public void select_Name(string name, String[] mySql, string table, string[] columns)
        {
            string sql = "SELECT ";

            foreach (string i in columns)
            {
                sql += i + ",";
            }
            sql = sql.Substring(0, sql.Length - 1);
            sql += " FROM " + table + " WHERE name='" + name + "'";

            DataSet ds = dal.GetDataSet(sql, table);
            try
            {
                for (int j = 0; j < mySql.Length; j++)
                {
                    string temp13 = "0";
                    if (ds.Tables[0].Rows[0][j].ToString() != null)
                    {
                        temp13 = ds.Tables[0].Rows[0][j].ToString();
                    }
                    mySql[j] = temp13;
                }
            }
            catch (Exception Error)
            {

                for (int i = 0; i < mySql.Length; i++)
                {
                    mySql[i] = "NULL";
                }
            }

        }

        /// <summary>
        /// 查找讯序号
        /// </summary>
        /// <param name="mySql">返回值</param>
        /// <param name="table">表名</param>
        /// <param name="columns">查找列</param>
        /// <param name="selectlist">限定列</param>
        /// <param name="selectsource">限定内容</param>
        public void selecet_number(String[,] mySql, string table, string[] columns, string[] selectlist, string[] selectsource)
        {
            int err = 0;
            string sql = "select TOP " + mySql.Length + " ";

            foreach (string i in columns)
            {
                sql += i + ",";
            }
            sql = sql.Substring(0, sql.Length - 1);
            sql += " FROM " + table + " WHERE ";
            for (int i = 0; i < selectlist.Length; i++)
            {
                sql += selectlist[i] + " = '" + selectsource[i] + "' AND ";
            }
            sql = sql.Substring(0, sql.Length - 5);

            DataSet ds = dal.GetDataSet(sql, table);

            for (int i = 0; i < mySql.GetLength(0); i++)//mySql.Length
            {
                for (int j = 0; j < mySql.GetLength(1); j++)//mySql[i].Length//mySql.GetLength(0)
                {
                    try
                    {
                        string temp13 = "0";
                        if (ds.Tables[0].Rows[i][j].ToString() != null)
                        {
                            temp13 = ds.Tables[0].Rows[i][j].ToString();


                        }
                        mySql[i, j] = temp13;
                    }
                    catch (Exception Error)
                    {

                        err++;
                    }
                }
            }
            if (err != 0)
            {
            }
        }

        /// <summary>
        /// 当月所有员工工作量拉取
        /// </summary>
        /// <param name="tableName1">表一</param>
        /// <param name="tableName2">表二</param>
        /// <param name="list">查看列名</param>
        /// <param name="list1">限定列名</param>
        /// <param name="value1">限定列值</param>
        /// <returns>返回数据</returns>
        public DataTable selectAll(string tableName1, string tableName2, string[] list, string[] list1, string[] value1)
        {
            if (list.Length == 0)
            {
                return null;
            }

            //SQL查看语句拼接
            string sql = "SELECT ";
            foreach (string i in list)
            {
                sql += i + ",";
            }
            sql = sql.Substring(0, sql.Length - 1) + " FROM " + tableName1 + "," + tableName2 + " WHERE ";

            if (list1.Length == 0 || list1.Length != value1.Length)
            {
                return null;
            }
            int num = Math.Min(list1.Length, value1.Length);
            for (int i = 0; i < num - 1; i++)
            {
                sql += list1[i] + " = '" + value1[i] + "' AND ";
            }
            sql += list1[list1.Length - 1] + " = " + value1[value1.Length - 1];
            if (tableName1 != "Summary")
            {
                sql += " ORDER BY Login.name ASC,CAST(number as int) ASC";
            }
            DataTable dt = dal.GetDataTable1(sql);

            return dt;
        }

        /// <summary>
        /// 循环查看
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="list">查看列名</param>
        /// <param name="list1">限定列名</param>
        /// <param name="value1">限定列值</param>
        /// <returns>返回查到的数据</returns>
        public DataTable selectLoop(string tableName, string[] list, string[] list1, string[] value1)
        {
            if (list.Length == 0)
            {
                return null;
            }

            //SQL查看语句拼接
            string sql = "SELECT ";
            foreach (string i in list)
            {
                sql += i + ",";
            }
            sql = sql.Substring(0, sql.Length - 1) + " FROM " + tableName + " WHERE ";

            if (list1.Length == 0 || list1.Length != value1.Length)
            {
                return null;
            }
            int num = Math.Min(list1.Length, value1.Length);
            for (int i = 0; i < num; i++)
            {
                sql += list1[i] + " = '" + value1[i] + "' AND ";
            }
            sql = sql.Substring(0, sql.Length - 5);
            if (tableName != "Summary")
            {
                sql += "ORDER BY CAST(number as int) ASC";
            }
            //连接数据库并发送SQL语句
            DataTable dt = dal.GetDataTable1(sql);

            return dt;
        }

        /// <summary>
        /// 月份查看
        /// </summary>
        /// <param name="tableName1">表一</param>
        /// <param name="tableName2">表二</param>
        /// <param name="tableName3">表三</param>
        /// <param name="list">查看列名一</param>
        /// <param name="list1">限定列名一</param>
        /// <param name="value1">限定值一</param>
        /// <param name="list2">查看列名二</param>
        /// <param name="list3">限定列名二</param>
        /// <param name="value2">限定值二</param>
        /// <returns></returns>
        public DataTable selectAll2(string tableName1, string tableName2, string tableName3, string[] list, string[] list1, string[] value1, string[] list2, string[] list3, string[] value2)
        {
            if (list.Length == 0)
            {
                return null;
            }

            //SQL查看语句拼接
            string sql = "SELECT ";
            foreach (string i in list)
            {
                sql += i + ",";
            }
            sql = sql.Substring(0, sql.Length - 1) + " FROM " + tableName1 + "," + tableName2 + " WHERE ";

            if (list1.Length == 0 || list1.Length != value1.Length)
            {
                return null;
            }
            int num = Math.Min(list1.Length, value1.Length);
            for (int i = 0; i < num - 1; i++)
            {
                sql += list1[i] + " = '" + value1[i] + "' AND ";
            }
            sql += list1[list1.Length - 1] + " = " + value1[value1.Length - 1];

            sql += " union select ";
            foreach (string i in list2)
            {
                sql += i + ",";
            }

            sql = sql.Substring(0, sql.Length - 1) + " FROM " + tableName3 + "," + tableName1 + " WHERE ";
            if (list3.Length == 0 || list3.Length != value2.Length)
            {
                return null;
            }
            int num2 = Math.Min(list3.Length, value2.Length);
            for (int i = 0; i < num - 1; i++)
            {
                sql += list3[i] + " = '" + value2[i] + "' AND ";
            }
            sql += list3[list3.Length - 1] + " = " + value2[value2.Length - 1];

            sql += " ORDER BY Login.name ASC";
            //连接数据库并发送SQL语句
            DataTable dt = dal.GetDataTable1(sql);

            return dt;
        }

        /// <summary>
        /// 年份查看
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="list">查看列名</param>
        /// <param name="list1">限定列</param>
        /// <param name="value1">限定列值</param>
        /// <returns>查找数据</returns>
        public DataTable selectAll3(string tableName, string[] list, string[] list1, string[] value1)
        {
            if (list.Length == 0)
            {
                return null;
            }

            //SQL查看语句拼接
            string sql = "SELECT ";
            foreach (string i in list)
            {
                sql += i + ",";
            }
            sql = sql.Substring(0, sql.Length - 1) + " FROM " + tableName + " WHERE ";

            if (list1.Length == 0 || list1.Length != value1.Length)
            {
                return null;
            }
            int num = Math.Min(list1.Length, value1.Length);
            for (int i = 0; i < num - 1; i++)
            {
                sql += list1[i] + " = '" + value1[i] + "' AND ";
            }
            sql += list1[list1.Length - 1] + " = " + value1[value1.Length - 1];
            sql += " ORDER BY CAST(month as int) ASC";
            //连接数据库并发送SQL语句
            DataTable dt = dal.GetDataTable1(sql);

            return dt;
        }

        /// <summary>
        /// 按招年份查看员工工作量
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="list">查找列</param>
        /// <param name="list1">限定列</param>
        /// <param name="value1">限定值</param>
        /// <returns></returns>
        public DataTable selectAll4(string tableName, string[] list, string[] list1, string[] value1)
        {
            if (list.Length == 0)
            {
                return null;
            }

            //SQL查看语句拼接
            string sql = "SELECT ";
            foreach (string i in list)
            {
                sql += i + ",";
            }
            sql = sql.Substring(0, sql.Length - 1) + " FROM " + tableName + " WHERE ";

            if (list1.Length == 0 || list1.Length != value1.Length)
            {
                return null;
            }
            int num = Math.Min(list1.Length, value1.Length);
            for (int i = 0; i < num - 1; i++)
            {
                sql += list1[i] + " = '" + value1[i] + "' AND ";
            }
            sql += list1[list1.Length - 1] + " = " + value1[value1.Length - 1];
            sql += " ORDER BY name ASC";
            //连接数据库并发送SQL语句
            DataTable dt = dal.GetDataTable1(sql);

            return dt;
        }

        /// <summary>
        /// 当月所有员工工作量拉取
        /// </summary>
        /// <param name="tableName1">表一</param>
        /// <param name="tableName2">表二</param>
        /// <param name="tableName3">表三</param>
        /// <param name="list">查看列名一</param>
        /// <param name="list1">限定列名一</param>
        /// <param name="value1">限定值一</param>
        /// <param name="list2">查看列名二</param>
        /// <param name="list3">限定列名二</param>
        /// <param name="value2">限定值二</param>
        /// <returns></returns>
        public DataTable selectAll5(string tableName1, string tableName2, string tableName3, string[] list, string[] list1, string[] value1, string[] list2, string[] list3, string[] value2)
        {
            if (list.Length == 0)
            {
                return null;
            }

            //SQL查看语句拼接
            string sql = "SELECT ";
            foreach (string i in list)
            {
                sql += i + ",";
            }
            sql = sql.Substring(0, sql.Length - 1) + " FROM " + tableName1 + "," + tableName2 + " WHERE ";

            if (list1.Length == 0 || list1.Length != value1.Length)
            {
                return null;
            }
            int num = Math.Min(list1.Length, value1.Length);
            for (int i = 0; i < num - 1; i++)
            {
                sql += list1[i] + " = '" + value1[i] + "' AND ";
            }
            sql += list1[list1.Length - 1] + " = " + value1[value1.Length - 1];

            sql += " union select ";
            foreach (string i in list2)
            {
                sql += i + ",";
            }

            sql = sql.Substring(0, sql.Length - 1) + " FROM " + tableName3 + "," + tableName2 + " WHERE ";
            if (list3.Length == 0 || list3.Length != value2.Length)
            {
                return null;
            }
            int num2 = Math.Min(list3.Length, value2.Length);
            for (int i = 0; i < num - 1; i++)
            {
                sql += list3[i] + " = '" + value2[i] + "' AND ";
            }
            sql += list3[list3.Length - 1] + " = " + value2[value2.Length - 1];




            sql += " ORDER BY Login.name ASC";

            DataTable dt = dal.GetDataTable1(sql);

            return dt;
        }

        /// <summary>
        /// 当月所有员工工作量拉取
        /// </summary>
        /// <param name="tableName1">表一</param>
        /// <param name="tableName2">表二</param>
        /// <param name="tableName3">表三</param>
        /// <param name="tableName4">表四</param>
        /// <param name="list">查看列名一</param>
        /// <param name="list1">限定列名一</param>
        /// <param name="value1">限定值一</param>
        /// <param name="list2">查看列名二</param>
        /// <param name="list3">限定列名二</param>
        /// <param name="value2">限定值二</param>
        /// <returns></returns>
        //union select '总计：',OA.dbo.Summary_Month.summary from Summary_Month where year='2018' and month='9'
        public DataTable selectAll6(string tableName1, string tableName2, string tableName3, string tableName4, string[] list, string[] list1, string[] value1, string[] list2, string[] list3, string[] value2)
        {
            if (list.Length == 0)
            {
                return null;
            }

            //SQL查看语句拼接
            string sql = "SELECT ";
            foreach (string i in list)
            {
                sql += i + ",";
            }
            sql = sql.Substring(0, sql.Length - 1) + " FROM " + tableName1 + "," + tableName2 + " WHERE ";

            if (list1.Length == 0 || list1.Length != value1.Length)
            {
                return null;
            }
            int num = Math.Min(list1.Length, value1.Length);
            for (int i = 0; i < num - 1; i++)
            {
                sql += list1[i] + " = '" + value1[i] + "' AND ";
            }
            sql += list1[list1.Length - 1] + " = " + value1[value1.Length - 1];

            sql += " UNION SELECT ";
            foreach (string i in list2)
            {
                sql += i + ",";
            }

            sql = sql.Substring(0, sql.Length - 1) + " FROM " + tableName1 + "," + tableName3 + " WHERE ";
            if (list3.Length == 0 || list3.Length != value2.Length)
            {
                return null;
            }
            int num2 = Math.Min(list3.Length, value2.Length);
            for (int i = 0; i < num - 1; i++)
            {
                sql += list3[i] + " = '" + value2[i] + "' AND ";
            }
            sql += list3[list3.Length - 1] + " = " + value2[value2.Length - 1];


            if (list[0] == "Login.peoplenumber")
            {
                sql += " UNION SELECT '无', '总计：',summary, '无' FROM " + tableName4 + " WHERE year='" + value1[0] + "' AND month='" + value1[1] + "'";
            }
            else
            {
                sql += " UNION SELECT '总计：',summary FROM " + tableName4 + " WHERE year='" + value1[0] + "' AND month='" + value1[1] + "'";
            }
            DataTable dt = dal.GetDataTable1(sql);

            return dt;
        }

        /// <summary>
        /// 当月所有员工工作量拉取
        /// </summary>
        /// <param name="tableName1">表一</param>
        /// <param name="tableName2">表二</param>
        /// <param name="tableName3">表三</param>
        /// <param name="tableName4">表四</param>
        /// <param name="list">查看列名一</param>
        /// <param name="list1">限定列名一</param>
        /// <param name="value1">限定值一</param>
        /// <param name="list2">查看列名二</param>
        /// <param name="list3">限定列名二</param>
        /// <param name="value2">限定值二</param>
        /// <returns></returns>
        //union select '总计：',OA.dbo.Summary_Month.summary from Summary_Month where year='2018' and month='9'
        public DataTable selectAll7(string tableName1, string tableName2, string tableName3, string tableName4, string[] list, string[] list1, string[] value1, string[] list2, string[] list3, string[] value2)
        {
            if (list.Length == 0)
            {
                return null;
            }

            //SQL查看语句拼接
            string sql = "SELECT ";
            foreach (string i in list)
            {
                sql += i + ",";
            }
            sql = sql.Substring(0, sql.Length - 1) + " FROM " + tableName1 + "," + tableName2 + " WHERE ";

            if (list1.Length == 0 || list1.Length != value1.Length)
            {
                return null;
            }
            int num = Math.Min(list1.Length, value1.Length);
            for (int i = 0; i < num - 1; i++)
            {
                sql += list1[i] + " = '" + value1[i] + "' AND ";
            }
            sql += list1[list1.Length - 1] + " = " + value1[value1.Length - 1];

            sql += " UNION SELECT ";
            foreach (string i in list2)
            {
                sql += i + ",";
            }

            sql = sql.Substring(0, sql.Length - 1) + " FROM " + tableName1 + "," + tableName3 + " WHERE ";
            if (list3.Length == 0 || list3.Length != value2.Length)
            {
                return null;
            }
            int num2 = Math.Min(list3.Length, value2.Length);
            for (int i = 0; i < num - 1; i++)
            {
                sql += list3[i] + " = '" + value2[i] + "' AND ";
            }
            sql += list3[list3.Length - 1] + " = " + value2[value2.Length - 1];


            if (list[0] == "Login.peoplenumber")
            {
                sql += " UNION SELECT '无', '总计：',summary, '无' FROM " + tableName4 + " WHERE year='" + value1[0] + "' AND month='" + value1[1] + "'";
            }
            else
            {
                sql += " UNION SELECT '总计：',summary, '无' FROM " + tableName4 + " WHERE year='" + value1[0] + "' AND month='" + value1[1] + "'";
            }
            DataTable dt = dal.GetDataTable1(sql);

            return dt;
        }

        /// <summary>
        /// 简单查看
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="list">查看列名</param>
        /// <returns>返回数据</returns>
        public DataTable selectUser(string tableName, string[] list)
        {
            if (list.Length == 0)
            {
                return null;
            }

            //SQL查看语句拼接
            string sql = "SELECT ";
            foreach (string i in list)
            {
                sql += i + ",";
            }
            sql = sql.Substring(0, sql.Length - 1) + " FROM " + tableName;

            //连接数据库并发送SQL语句
            DataTable dt = dal.GetDataTable1(sql);

            return dt;
        }

    }
}