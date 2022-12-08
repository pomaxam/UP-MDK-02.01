﻿using System;
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
    }
}