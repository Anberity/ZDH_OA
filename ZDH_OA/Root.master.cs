using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

namespace ZDH_OA {
    public partial class RootMaster : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            try
            {
                if (HttpContext.Current.Session["username"].ToString() == "null" || HttpContext.Current.Session["userpwd"].ToString() == "null")
                {
                    HttpContext.Current.Response.Write(" <script> alert( '����δ��½�����ȵ�¼������');window.location.href= '../Default.aspx ' </script> ");
                }
                string name = HttpContext.Current.Session["name"].ToString();
                Response.Write(" <script>window.onload=function(){ var name=document.getElementById('name'); name.innerHTML='��ӭ�㣬" + name + "'} </script> ");
            }
            catch (Exception)
            {
                HttpContext.Current.Response.Write(" <script> alert( '����δ��½�����ȵ�¼������');window.location.href= '../Default.aspx ' </script> ");
            }

        }


        //ע��
        protected void logout_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["power"] = "null";//Ȩ��
            HttpContext.Current.Session["username"] = "null";//��ȡ�û���
            HttpContext.Current.Session["userpwd"] = "null";//��ȡ����
            HttpContext.Current.Session["name"] = "null";//��ȡ�û�����
            HttpContext.Current.Session["team"] = "null";//��ȡ�û�С��
            HttpContext.Current.Session["transfer"] = "null";//��ȡ�û����״̬
            HttpContext.Current.Session["yearh"] = DateTime.Now.Year.ToString();//��ʷ���
            HttpContext.Current.Session["monh"] = DateTime.Now.Month.ToString();//��ʷ�·�
            HttpContext.Current.Session["months"] = DateTime.Now.Month.ToString();//���ܲ鿴�·�
            HttpContext.Current.Session["years"] = DateTime.Now.Month.ToString();//���ܲ鿴���
            HttpContext.Current.Session["yearuser"] = DateTime.Now.Month.ToString();//����鿴Ա������
            HttpContext.Current.Session["numberMonth"] = "0";//�·ݻ���
            HttpContext.Current.Session["numberYear"] = "0";//��ݻ���
            HttpContext.Current.Session["userYear"] = "0";//Ա����ݻ���
            HttpContext.Current.Response.Write(" <script>window.location.href= '../Default.aspx' </script> ");
        }
    }
}