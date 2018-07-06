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

namespace MH
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Core Core;

        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            Core = new Core();

            LoadPatients();
        }

        ///<summary>
        /// Заполнение таблицы пациентов
        ///</summary>
        private void LoadPatients()
        {
            var patients = Core.GetAllPatients();
            PatientsGrid.ItemsSource = patients;
        }


        ///<summary>
        /// Событие выбора основного раздела программы
        ///</summary>
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        ///<summary>
        /// Событие выбора пациента в таблице пациентов
        ///</summary>
        private void PatientsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        ///<summary>
        /// Событие обновления таблицы пациентов
        ///</summary>
        private void PatientsGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
        }
    }
}