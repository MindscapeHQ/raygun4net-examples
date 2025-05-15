using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Raygun4Net.NetCore.Example.WinUI
{
    /// <summary>  
    /// An empty window that can be used on its own or navigated to within a Frame.  
    /// </summary>  
    public sealed partial class MainWindow : Window
    {
        // Change to the path of the DLL you build with Raygun4Net.DLL.Example
        [DllImport("PATH TO DLL\\Raygun4Net.DLL.Example.dll")]
        public static extern int division(int a, int b); 

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // This will work and return 2
                var result = division(4, 2);
                Console.WriteLine("Result: " + result);

                // This will throw a divide by zero exception
                var crash = division(1, 0);
            }
            catch (DllNotFoundException ex)
            {
                Console.WriteLine("Dll Not Found: " + ex.Message);
            }
        }
    }
}
