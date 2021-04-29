using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdasVetelServer.logger
{
    class ServerLogger
    {
        public static ServerLogger Instance { get; } = new ServerLogger();
        public TextBox output { get; set; }
        public void writeLog(string text) {
            if (output != null) {               
                output.Invoke((MethodInvoker)delegate
                {
                    output.AppendText(text + Environment.NewLine);
                });
            }
            Console.WriteLine(text);
        }
        public void writeLog(bool text)
        {
            if (output != null)
            {
                output.Invoke((MethodInvoker)delegate
                {
                    output.AppendText(text + Environment.NewLine);
                });
            }
            Console.WriteLine(text);
        }
        public void writeLog(int text)
        {
            if (output != null)
            {
                output.Invoke((MethodInvoker)delegate
                {
                    output.AppendText(text + Environment.NewLine);
                });
            }
            Console.WriteLine(text);
        }
        public void writeLog(double text)
        {
            if (output != null)
            {
                output.Invoke((MethodInvoker)delegate
                {
                    output.AppendText(text + Environment.NewLine);
                });
            }
            Console.WriteLine(text);
        }
        public void writeLog()
        {
            if (output != null)
            {
                output.Invoke((MethodInvoker)delegate
                {
                    output.AppendText(Environment.NewLine);
                });
            }
            Console.WriteLine();
        }
    }
}
