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
using System.Windows.Shapes;

namespace UP_MDK_02._01
{
    /// <summary>
    /// Логика взаимодействия для addWindow.xaml
    /// </summary>
    public partial class addWindow : Window
    {
        ApplicationContext db;

        public addWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();

        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string ident = textBoxIdent.Text.Trim();
            string first_name = textBoxFirstName.Text.Trim();
            string last_name = textBoxLastName.Text.Trim();
            string patronymic = textBoxPatronymic.Text.Trim();
            string datebirth = textBoxDatebirth.Text.Trim();
            string phone_number = textBoxPhoneNumber.Text.Trim();
            string department = textBoxDepartment.Text.Trim();

            textBoxDepartment.ToolTip = "";
            textBoxDepartment.Background = Brushes.Transparent;

            Worker worker = new Worker(ident, first_name, last_name, patronymic, datebirth, phone_number, department);

            db.workers.Add(worker);
            db.SaveChanges();
            Hide();
            
        }
    }
}
