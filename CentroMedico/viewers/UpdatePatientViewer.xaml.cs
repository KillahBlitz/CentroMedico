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

namespace CentroMedico.viewers
{
    public partial class UpdatePatientViewer : Window
    {
        public event EventHandler PatientUpdated;
        private patientModel currentPatient;

        public UpdatePatientViewer(patientModel patient)
        {
            InitializeComponent();
            currentPatient = patient;
            LoadPatientData();
        }

        private void LoadPatientData()
        {
            fullNameInput.Text = currentPatient.name;
            patientTypeInput.Text = currentPatient.type_patient;
            dateOfBirthInput.SelectedDate = currentPatient.birthdate;
            bloodTypeInput.Text = currentPatient.blood_type;

            if (!string.IsNullOrEmpty(currentPatient.apgar))
            {
                var apgarParts = currentPatient.apgar.Split(new[] { " de " }, StringSplitOptions.None);
                if (apgarParts.Length == 2)
                {
                    apgarOneInput.Text = apgarParts[0];
                    apgarFiveInput.Text = apgarParts[1];
                }
            }
        }

        private void CloseModal(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveData(object sender, RoutedEventArgs e)
        {
            string patientName = fullNameInput.Text;
            string typePatient = patientTypeInput.Text;
            string bloodType = bloodTypeInput.Text;
            string apgarLeft = apgarOneInput.Text;
            string apgarRight = apgarFiveInput.Text;

            DateTime? birthdate = dateOfBirthInput.SelectedDate.HasValue ? dateOfBirthInput.SelectedDate.Value : (DateTime?)null;
            typePatient = string.IsNullOrEmpty(typePatient) ? "General" : typePatient;

            bool validation = ValidateFields(patientName, birthdate);

            if (validation)
            {
                try
                {
                    using (var db = new ConsultorioContext())
                    {
                        var patientToUpdate = db.Patients.Find(currentPatient.id);
                        if (patientToUpdate != null)
                        {
                            patientToUpdate.name = patientName;
                            patientToUpdate.type_patient = typePatient;
                            patientToUpdate.blood_type = bloodType;
                            patientToUpdate.birthdate = birthdate.Value;
                            patientToUpdate.apgar = $"{apgarLeft} de {apgarRight}";

                            db.SaveChanges();
                        }
                    }
                    MessageBox.Show("Paciente actualizado exitosamente.");
                    PatientUpdated?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar paciente: {ex.Message}");
                }
            }
        }

        private bool ValidateFields(string name, DateTime? birthDate)
        {
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("El campo de nombre es obligatorio.");
                return false;
            }
            else if (birthDate == null)
            {
                MessageBox.Show("El campo de fecha de nacimiento es obligatorio.");
                return false;
            }
            return true;
        }

        private void FullNameInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            fullNameInput.Text = fullNameInput.Text.ToUpper();
            fullNameInput.SelectionStart = fullNameInput.Text.Length;
        }
    }
}
