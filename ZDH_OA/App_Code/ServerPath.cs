using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.InteropServices;
using System.Text;

namespace ZDH_OA.App_Code
{
    public class ServerPath
    {
        [DllImport("kernel32")] //引入“shell32.dll”API文件
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// 获取数据库登录信息
        /// </summary>
        /// <param name="iniName">section名</param>
        /// <param name="key">获取项目</param>
        /// <returns>项目内容</returns>
        public string sqlPath(string iniName, string key)
        {
            StringBuilder sb = new StringBuilder(1024);
            GetPrivateProfileString(iniName, key, "", sb, 1024, HttpRuntime.AppDomainAppPath.ToString() + @"\sql_pw.ini");
            return sb.ToString();
        }
    }
}