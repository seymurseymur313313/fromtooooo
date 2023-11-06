using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfApp2
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
        Thread thread1 = new Thread(() => { });
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string a=txtfrom.Text;
            bar.Maximum = a.Length; 
            
            thread1 = new Thread(() =>

            {
            for (int i = 0; i < a.Length; i++)
            {

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        txtto.Text += a[i];
                        bar.Value += 1;
                        

                    });
                    Thread.Sleep(1000); 
                    
            } 
                
                
            });
            thread1.Start();
            


        }

   

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            thread1.Suspend();
        }

        private void resum_Click(object sender, RoutedEventArgs e)
        {
            thread1.Resume();
        }
    }
}
