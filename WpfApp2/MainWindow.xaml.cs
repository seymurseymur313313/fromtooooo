using Microsoft.Win32;
using System;
using System.IO;
using System.Threading;
using System.Windows;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        private Thread thread1 = new Thread(() => { });

        public MainWindow()
        {
            InitializeComponent();
        }

        void TextTransfer()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                string ilkDosyaYolu = txtfrom.Text;
                string ikinciDosyaYolu = txtto.Text;

                using (StreamReader sr = new StreamReader(ilkDosyaYolu))
                {
                    using (StreamWriter sw = new StreamWriter(ikinciDosyaYolu))
                    {
                        string satir;
                        while ((satir = sr.ReadLine()) != null)
                        {
                            foreach (char harf in satir)
                            {
                                sw.Write(harf);

                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    bar.Value += 1;
                                });

                                Thread.Sleep(10); // Gerekirse bu değeri ayarlayabilirsiniz
                            }
                            sw.WriteLine();
                        }
                    }
                }
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!thread1.IsAlive)
            {
                thread1 = new Thread(() =>
                {
                    TextTransfer();
                });
                thread1.Start();
            }
        }

        private void resum_Click_1(object sender, RoutedEventArgs e)
        {
            thread1.Resume();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            thread1.Suspend();
        }

        private void open1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text  (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                string dosyaYolu = openFileDialog.FileName;
                txtfrom.Text = openFileDialog.FileName;
            }
        }

        private void open2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text  (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                txtto.Text = openFileDialog.FileName;
            }
        }
    }
}
