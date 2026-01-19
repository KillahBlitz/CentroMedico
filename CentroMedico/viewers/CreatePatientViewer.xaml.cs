using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CentroMedico.Database;
using CentroMedico.models;

namespace CentroMedico.viewers
{
    public partial class CreatePatientViewer : Window
    {
        public event EventHandler PatientCreated;

        public CreatePatientViewer()
        {
            InitializeComponent();
            dobInput.DisplayDateEnd = DateTime.Now;
        }

        private void OnlyNumbers_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            if (regex.IsMatch(e.Text))
            {
                e.Handled = true;
                return;
            }

            if (e.Text == "." && ((TextBox)sender).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void closeModal(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveData(object sender, RoutedEventArgs e)
        {
            string patientName = fullNameInput.Text;
            string typePatient = patientTypeInput.Text;
            string weight = weightInput.Text;
            string height = heightInput.Text;
            string history = historyInput.Text;
            string typeHistory = typeHistoryInput.Text;
            string apgar_left = apgar1Input.Text;
            string apgar_right = apgar5Input.Text;
            string BloodType = bloodTypeInput.Text;

            DateTime? birthdate = dobInput.SelectedDate.HasValue ? dobInput.SelectedDate.Value : (DateTime?)null;
            typePatient = string.IsNullOrEmpty(typePatient) ? "General" : typePatient;
            typeHistory = string.IsNullOrEmpty(typeHistory) ? "Indefinido" : typeHistory;

            bool validation = ChampsValidation(patientName, weight, height, birthdate);

            if (validation)
            {
                using (var db = new ConsultorioContext())
                {
                    var newPatient = new patientModel
                    {
                        name = patientName,
                        type_patient = typePatient,
                        weight = float.Parse(weight),
                        height = float.Parse(height),
                        blood_type = BloodType,
                        birthdate = birthdate.Value,
                        apgar = $"{apgar_left} de {apgar_right}",
                    };
                    db.Patients.Add(newPatient);
                    db.SaveChanges();

                    if (!string.IsNullOrEmpty(history))
                    {
                        var newHistory = new historyModel
                        {
                            patient_id = newPatient.id,
                            history = history,
                            name = newPatient.name,
                            type_history = typeHistory
                        };
                        db.Histories.Add(newHistory);
                        db.SaveChanges();
                    }
                }
                MessageBox.Show("Paciente creado exitosamente.");
                PatientCreated?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            else
            {
                return;
            }
        }

        public static bool ChampsValidation(string name, string weight, string height, DateTime? birthDate)
        {
            bool validation = false;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("El campo de nombre es obligatorio.");
            }
            else if (string.IsNullOrEmpty(weight))
            {
                MessageBox.Show("El campo de peso es obligatorio.");
            }
            else if (string.IsNullOrEmpty(height))
            {
                MessageBox.Show("El campo de altura es obligatorio.");
            } 
            else if (birthDate == null)
            {
                MessageBox.Show("El campo de fecha de nacimiento es obligatorio.");
            }
            else
            {
                validation = true;
            }
            return validation;
        }
        private void fullNameInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            fullNameInput.Text = fullNameInput.Text.ToUpper();
            fullNameInput.SelectionStart = fullNameInput.Text.Length;
        }

    }
}