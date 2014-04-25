using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sender
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnSendWithProcess_Click(object sender, RoutedEventArgs e)
        {
            var lstProcess = Process.GetProcessesByName(txtProcess.Text);
            if (lstProcess.Length > 0)
            {
                Process proc = lstProcess[0];
                DataStruct.DataStruct cds;
                cds.dwData = IntPtr.Zero;
                cds.lpData = txtMSG.Text;
                cds.cbData = System.Text.Encoding.Default.GetBytes(txtMSG.Text).Length + 1;

                int fromWindowHandler = 0;

                MessageHelper.MessageHelper.SendMessage(proc.MainWindowHandle, MessageHelper.MessageHelper.WM_COPYDATA, fromWindowHandler, ref cds);
            }

        }

        private void btnSendWithTitle_Click(object sender, RoutedEventArgs e)
        {
            IntPtr hwnd = MessageHelper.MessageHelper.FindWindow(null, txtTitle.Text);

            if (hwnd != IntPtr.Zero)
            {
                DataStruct.DataStruct cds;
                cds.dwData = IntPtr.Zero;
                cds.lpData = txtMSG.Text;
                cds.cbData = System.Text.Encoding.Default.GetBytes(txtMSG.Text).Length + 1;
                // 消息来源窗体
                int fromWindowHandler = 0;
                MessageHelper.MessageHelper.SendMessage(hwnd, MessageHelper.MessageHelper.WM_COPYDATA, fromWindowHandler, ref cds);
            }
        }


    }
}
