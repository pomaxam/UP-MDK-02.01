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

namespace UP_MDK_02._01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Мужики-работяги");
                worksheet.Cells["A1"].Value = "ID"; ;
                worksheet.Cells["B1"].Value = "Идентификатор";
                worksheet.Cells["C1"].Value = "Имя";
                worksheet.Cells["D1"].Value = "Фамилия";
                worksheet.Cells["E1"].Value = "Отчество";
                worksheet.Cells["F1"].Value = "Должность";
                worksheet.Cells["G1"].Value = "Номер телефона";
                worksheet.Cells["H1"].Value = "Email";
                List<Worker> workerList = new List<Worker>();
                using (var db = new ApplicationContext())
                {
                    var query = from b in db.workers select b;
                    foreach (var item in query)
                    {
                        workerList.Add(item);
                    }
                }
                worksheet.Cells["A2"].LoadFromCollection(workerList);
                string filePath = "Информация о персонале.xlsx";
                FileInfo fi = new FileInfo(filePath);
                excelPackage.SaveAs(fi);

                if (MessageBox.Show("Файл создан, открыть сейчас?", "Отдел кадров", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    var p = new Process();
                    p.StartInfo = new ProcessStartInfo(@"Информация о персонале.xlsx")
                    {
                        UseShellExecute = true
                    };
                    p.Start();
                }
            }
        }
    }
}
