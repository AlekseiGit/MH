using MH.DataModels;
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

            RegistrationImg.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/imgs/registration.png"));
            IllAnamnesisImg.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/imgs/illanamnesis.png"));
            LifeAnamnesisImg.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/imgs/lifeanamnesis.png"));
            VisitsImg.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/imgs/visits.png"));
            TherapyImg.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/imgs/therapy.png"));
            SurveysImg.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/imgs/surveys.png"));
            DiagnosisImg.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/imgs/diagnosis.png"));
            DocumentsImg.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/imgs/documents.png"));

            LoadPatients();
        }

        ///<summary>
        /// Заполнение таблицы пациентов
        ///</summary>
        private void LoadPatients()
        {
            var patients = Core.GetAllPatients();
            PatientsGrid.ItemsSource = patients;
            PatientsCountBox.Content = "Пациентов в базе данных: " + patients.Count;
        }

        ///<summary>
        /// Формирование таблицы с пациентами
        ///</summary>
        public void PatientsGridColumnsGenerated(object sender, EventArgs e)
        {
            PatientsGrid.Columns[0].Visibility = Visibility.Collapsed;

            PatientsGrid.Columns[1].Header = "Амбулаторная карта";
            PatientsGrid.Columns[2].Header = "Фамилия";
            PatientsGrid.Columns[3].Header = "Имя";
            PatientsGrid.Columns[4].Header = "Отчество";

            PatientsGrid.Columns[1].Width = 120;
            PatientsGrid.Columns[2].Width = 120;
            PatientsGrid.Columns[3].Width = 120;
            PatientsGrid.Columns[4].Width = 120;
        }

        ///<summary>
        /// Событие выбора основного раздела программы
        ///</summary>
        private void SectionSelect(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var section = btn.Content.ToString();

            if (section == "Регистрация")
            {
                RegistrationTab.IsSelected = true;
            }
            else if (section == "Анамнез болезни")
            {
                IllAnamnesisTab.IsSelected = true;
            }
            else if (section == "Анамнез жизни")
            {
                LifeAnamnesisTab.IsSelected = true;
            }
            else if (section == "Осмотры")
            {
                VisitsTab.IsSelected = true;
            }
            else if (section == "Лечение")
            {
                TherapyTab.IsSelected = true;
            }
            else if (section == "Обследования")
            {
                SurveysTab.IsSelected = true;
            }
            else if (section == "Диагноз и рекомендации")
            {
                DiagnosisTab.IsSelected = true;
            }
            else if (section == "Документы")
            {
                DocumentsTab.IsSelected = true;
            }
        }

        private void PatientsByLetter(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var letter = btn.Content.ToString();

            var patients = Core.GetAllPatientsByLetter(letter);
            PatientsGrid.ItemsSource = patients;
            PatientsCountBox.Content = "Пациентов в базе данных: " + patients.Count;
        }

        private void AllPatients(object sender, RoutedEventArgs e)
        {
            LoadPatients();
        }

        ///<summary>
        /// Событие выбора пациента в таблице пациентов
        ///</summary>
        private void PatientsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MedicalCardNumberBox.Text = "";
            SNameBox.Text = "";
            FNameBox.Text = "";
            MNameBox.Text = "";

            RegionBox.SelectedIndex = 0;
            CityBox.Text = "";
            AddressBox.Text = "";
            PhoneBox.Text = "";

            OrganizationBox.Text = "";
            ProfessionBox.SelectedIndex = 0;
            PositionBox.Text = "";

            RegistrationDateBox.Text = "";
            BirthDateBox.Text = "";
            AgeCategoryBox.SelectedIndex = 0;
            SexBox.SelectedIndex = 0;
            WeightBox.Text = "";

            if (PatientsGrid.SelectedItems.Count == 1)
            {
                var patient = PatientsGrid.SelectedItems[0] as Patient;

                MedicalCardNumberBox.Text = patient.MedicalCardNumber;
                SNameBox.Text = patient.SName;
                FNameBox.Text = patient.FName;
                MNameBox.Text = patient.MName;

                RegionBox.Text = patient.Region;
                CityBox.Text = patient.City;
                AddressBox.Text = patient.Address;
                PhoneBox.Text = patient.Phone;

                OrganizationBox.Text = patient.Organization;
                ProfessionBox.Text = patient.Profession;
                PositionBox.Text = patient.Position;

                RegistrationDateBox.SelectedDate = patient.RegistrationDate;
                BirthDateBox.SelectedDate = patient.BirthDate;
                AgeCategoryBox.SelectedIndex = 0;
                if (patient.Sex == 1)
                {
                    SexBox.SelectedIndex = 1;
                }
                else if (patient.Sex == 2)
                {
                    SexBox.SelectedIndex = 2;
                }
                else
                {
                    SexBox.SelectedIndex = 0;
                }                
                WeightBox.Text = patient.Weight.ToString();
            }
        }

        ///<summary>
        /// Событие обновления таблицы пациентов
        ///</summary>
        private void PatientsGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
        }
    }
}