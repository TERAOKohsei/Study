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

namespace AsyncAwait {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }


        private async void button1_Click(object sender, RoutedEventArgs e) {
            System.Diagnostics.Debug.WriteLine("Enter button1_Click");
            await Task.Run(() => System.Threading.Thread.Sleep(10000));
            System.Diagnostics.Debug.WriteLine("Leave button1_Click");
        }

        private async void button2_Click(object sender, RoutedEventArgs e) {
            System.Diagnostics.Debug.WriteLine("Enter button2_Click");
            await Task.Run(() => System.Threading.Thread.Sleep(5000));
            System.Diagnostics.Debug.WriteLine("Leave button2_Click");
        }
    }
}
