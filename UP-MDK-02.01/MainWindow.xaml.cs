using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
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
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.ComponentModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace UP_MDK_02._01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Worker> workerList = new List<Worker>();
        public MainWindow()
        {
            InitializeComponent();
            List<Worker> workerList = new List<Worker>();
            using (var db = new ApplicationContext())
            {
                var query = from b in db.workers select b;
                foreach (var item in query)
                {
                    workerList.Add(item);
                }
            }
            WorkersGrid.ItemsSource = workerList;
        }

        private void Button_Window_add_Click(object sender, RoutedEventArgs e)
        {
            addWindow addWindow = new addWindow();
            addWindow.Show();
        }

        public void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            List<Worker> workerList = new List<Worker>();
            using (var db = new ApplicationContext())
            {
                var query = from b in db.workers select b;
                foreach (var item in query)
                {
                    workerList.Add(item);
                }
            }
            WorkersGrid.ItemsSource = workerList;
        }

        private void downloadTableButton_Click(object sender, RoutedEventArgs e)
        {
            ExportWindow exportWindow = new ExportWindow();
            exportWindow.Show();
        }

        List<Worker> filterModeList = new List<Worker>();
        private void textBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            filterModeList.Clear();

            if (textBoxSearch.Text.Equals(""))
            {
                List<Worker> workerList = new List<Worker>();
                using (var db = new ApplicationContext())
                {
                    var query = from b in db.workers select b;
                    foreach (var item in query)
                    {
                        workerList.Add(item);
                    }
                }
                WorkersGrid.ItemsSource = workerList;
            }
            else
            {
                List<Worker> workerList = new List<Worker>();
                using (var db = new ApplicationContext())
                {
                    var query = from b in db.workers select b;
                    foreach (var item in query)
                    {
                        if (item.ident.Contains(textBoxSearch.Text) || item.first_name.Contains(textBoxSearch.Text) || item.last_name.Contains(textBoxSearch.Text)
                            || item.patronymic.Contains(textBoxSearch.Text) || item.datebirth.Contains(textBoxSearch.Text) || item.phone_number.Contains(textBoxSearch.Text)
                            || item.department.Contains(textBoxSearch.Text))
                        {
                            workerList.Add(item);
                        }
                    }
                }
                WorkersGrid.ItemsSource = workerList;
            }

        }
    }
}
