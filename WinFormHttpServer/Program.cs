using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormHttpServer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process[] ProcArry = Process.GetProcesses();//获取系统所有进程的数组
            Process ProcCur = Process.GetCurrentProcess();//获取现行的进程
            Process ProcOld = ProcArry.FirstOrDefault(p =>
            {
                if (p.ProcessName == ProcCur.ProcessName && p.StartTime != ProcCur.StartTime) return true;
                else return false;
            });

            if (ProcOld != null)
            {
                //如果程序已经运行，则给出提示。并退出本进程。
                MessageBox.Show("本程序已在系统中运行！！！");
                Application.Exit();
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
