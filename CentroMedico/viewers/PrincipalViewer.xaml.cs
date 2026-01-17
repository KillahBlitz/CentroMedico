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
using CentroMedico.Database;
using CentroMedico.models;
using Microsoft.EntityFrameworkCore;

namespace CentroMedico.viewers
{

    public partial class principalViewer : UserControl
    {
     
        private List<patientModel> _allPatients;

        public principalViewer()
        {
            InitializeComponent();
            ConsultorioContext.PrepareDatBase();
            ChargeData();
        }

        private void ChargeData()
        {
            try
            {
                using (var db = new ConsultorioContext())
                {
                    _allPatients = db.Patients.ToList();
                }
                _allPatients = OrderByName(_allPatients);
                foreach (var patient in _allPatients)
                {
                    patient.ultimateDate = SelectUltimateConsulation(patient.id);
                }
                PatientsList.ItemsSource = _allPatients;
                UpdateYearsOld();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}");
            }
        }

        private void searchUser(object sender, TextChangedEventArgs e)
        {
            if (_allPatients == null) return;
            
            string searchText = txtBuscar.Text.ToLower();
            
            if (string.IsNullOrEmpty(searchText))
            {
                PatientsList.ItemsSource = _allPatients;
                return;
            }
            
            var filteredPatients = _allPatients
                .Where(p => p.name.ToLower().Contains(searchText) || p.id.ToString().Contains(searchText))
                .ToList();
            PatientsList.ItemsSource = filteredPatients;
        }

        public static List<patientModel> OrderByName(List<patientModel> patients)
        {
            patients.Sort((x, y) => string.Compare(x.name, y.name));
            return patients;
        }

        private void UpdateYearsOld()
        {
            int currentYear = DateTime.Now.Year;
            foreach (var patient in _allPatients)
            {
                int birthYear = patient.birthdate.Year;
                int age = currentYear - birthYear;
                patient.age = age;
                int birthMonth = patient.birthdate.Month;
                int currentMonth = DateTime.Now.Month;
                int monthsOld = birthMonth - currentMonth;
                patient.age_mounth = monthsOld;
                using (var db = new ConsultorioContext())
                {
                    var patientToUpdate = db.Patients.Find(patient.id);
                    if (patientToUpdate != null)
                    {
                        patientToUpdate.age = patient.age;
                        patientToUpdate.age_mounth = patient.age_mounth;
                        db.SaveChanges();
                    }
                }
            }
        }

        private DateOnly SelectUltimateConsulation(int patientId)
        {
            using (var db = new ConsultorioContext())
            {
                var ultimateConsulation = db.Consulations
                                            .Where(c => c.patient_id == patientId)
                                            .OrderByDescending(c => c.date)
                                            .FirstOrDefault();
                return ultimateConsulation != null ? DateOnly.FromDateTime(ultimateConsulation.date) : DateOnly.FromDateTime(DateTime.Now);
            }
        }
        private void openRegisterModal(object sender, RoutedEventArgs e)
        {
            CreatePatientViewer modal = new CreatePatientViewer();
            modal.ShowDialog();
        }
    }
}

