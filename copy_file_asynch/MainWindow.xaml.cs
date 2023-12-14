using System;
using System.Collections.Generic;
using System.IO;
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

namespace copy_file_asynch
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // скопировать файл с помощью блочного чтени и записи
            CopyFile();

        }

        private async void CopyFile()
        {
            using Stream from = File.OpenRead(@"micro-cap.zip");
            using Stream to = File.OpenWrite(@"micro-cap2.zip");

            byte[] buffer = new byte[7_000_000];

            int read = await from.ReadAsync(buffer, 0, buffer.Length);
            await to.WriteAsync(buffer, 0, read);
            progressBar.Value = 33.33;

            read = await from.ReadAsync(buffer, 0, buffer.Length);
            await to.WriteAsync(buffer, 0, read);
            progressBar.Value = 66.67;

            read = await from.ReadAsync(buffer, 0, buffer.Length);
            await to.WriteAsync(buffer, 0, read);
            progressBar.Value = 100;
        }
    }
}
