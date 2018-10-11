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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace WpfExe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hwc, IntPtr hwp);
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process p = Process.Start("C:\\Program File\\PotPlayer\\PotPlayerMini64.exe");
            IntPtr handle = new System.Windows.Interop.WindowInteropHelper(this).Handle;  //this refers to the window!
            Thread.Sleep(100);
            SetParent(p.MainWindowHandle, handle);
            //p.WaitForInputIdle();
            if (p != null)
            {
                p.WaitForExit();
                //or any other statements for that matter
            }

        }


        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            var prc = Process.Start("notepad.exe");
            prc.WaitForInputIdle();
            bool ok = MoveWindow(prc.MainWindowHandle, 500, 500, 300, 200, false);
            if (!ok) throw new System.ComponentModel.Win32Exception();
        }


    
        

        
    }
}
