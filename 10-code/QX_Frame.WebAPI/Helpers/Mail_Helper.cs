using QX_Frame.Helper_DG_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace QX_Frame.WebAPI.Helpers
{
    public class Mail_Helper
    {
        public static bool SendMail(string sendToAddress,string _link)
        {
            string account = "13097677577@163.com";
            string password = "880226";
            string[] toMailAddress = { sendToAddress };
            string[] ccMailAddress = { };
            string fromMailAddress = "13097677577@163.com";
            string fromMailName = "Ant Help";

            string mailSubject="Ant Help Account Register Mail";

            StringBuilder builer = new StringBuilder();
            builer.Append("<!DOCTYPE html PUBLIC \" -//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
            builer.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
            builer.Append("<head>");
            builer.Append("<meta charset=\"UTF-8\">");
            builer.Append("<title>安全验证</title>");
            builer.Append("</head>");
            builer.Append("<body>");
            builer.Append("<div>");
            builer.Append("<p>请点击下面链接跳转完成注册(10分钟内有效)</p>");
            builer.Append($"<p><a href='{_link}' target='_blank'>{_link}</a></P>");
            builer.Append("</div>");
            builer.Append("</body>");
            builer.Append("</html>");

            string mailBody=builer.ToString();
            bool isHtmlBody=true;

            return Mail_Helper_DG.SendBySMTP(account,password,toMailAddress,ccMailAddress,fromMailAddress,fromMailName, mailSubject, mailBody, isHtmlBody);
        }
    }
}