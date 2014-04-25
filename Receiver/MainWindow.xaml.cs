using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Receiver
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Window_Loaded);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            (PresentationSource.FromVisual(this) as HwndSource).AddHook(new HwndSourceHook(this.WndProc));
        }

        IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {

            if (msg == MessageHelper.MessageHelper.WM_COPYDATA)
            {

                DataStruct.DataStruct cds = (DataStruct.DataStruct)System.Runtime.InteropServices.Marshal.PtrToStructure(lParam, typeof(DataStruct.DataStruct));

                txtShow.Text = cds.lpData;

            }

            return hwnd;

        }
    }
}
