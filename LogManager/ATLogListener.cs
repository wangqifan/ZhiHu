using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace LogManager
{
    class ATLogListener : TraceListener
    {
        private string m_logFileName;

        public ATLogListener()
        {
            if (!Directory.Exists(LogConstant.LogFolder))
            {
                Directory.CreateDirectory(LogConstant.LogFolder);
            }

            this.m_logFileName = LogConstant.LogFolder + "/" + string.Format("Log-{0}", DateTime.Now.ToString("yyyyMMdd"));
        }



        public override void Write(string message)
        {
            message = Format(message, "");
            File.AppendAllText(m_logFileName, message);
        }

        public override void WriteLine(string message)
        {
            message = Format(message, "");
            File.AppendAllText(m_logFileName, message);
        }

        public override void WriteLine(object o)
        {
            string message = Format(o, "");
            File.AppendAllText(m_logFileName, message);
        }

        public override void WriteLine(string message, string category)
        {
            message = Format(message, category);
            File.AppendAllText(m_logFileName, message);
        }

        public override void WriteLine(object o, string category)
        {
            string message = Format(o, category);
            File.AppendAllText(m_logFileName, message);
        }

        private string Format(object obj, string category)
        {
            StringBuilder message = new StringBuilder();
            message.AppendFormat("{0} ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            if (!string.IsNullOrEmpty(category))
            {
                message.AppendFormat("[{0}]", category);
            }

            if (obj is Exception)
            {
                var ex = obj as Exception;
                message.Append(ex.Message + "\r\n");
                message.Append(ex.StackTrace + "\r\n");
            }
            else
            {
                message.Append(obj.ToString() + "\r\n");
            }

            return message.ToString();
        }
    }
}
