using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using Newtonsoft.Json;

namespace UP_MDK_02._01
{
    /// <summary>
    /// Логика взаимодействия для ExportWindow.xaml
    /// </summary>
    public partial class ExportWindow : Window
    {
        public ExportWindow()
        {
            InitializeComponent();
        }

        private void ExcelUpload_Click(object sender, RoutedEventArgs e)
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
                    p.StartInfo = new ProcessStartInfo("Информация о персонале.xlsx")
                    {
                        UseShellExecute = true
                    };
                    p.Start();
                }
                Hide();
            }
        }

        private void JSONUpload_Click(object sender, RoutedEventArgs e)
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
            var Json = JsonConvert.SerializeObject(workerList);
            File.WriteAllText("Информация о персонале.json", Json.ToString());
            if (MessageBox.Show("Файл создан, открыть сейчас?", "Отдел кадров", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var p = new Process();
                p.StartInfo = new ProcessStartInfo("Информация о персонале.json")
                {
                    UseShellExecute = true
                };
                p.Start();
            }
            Hide();
        }
    }
}
