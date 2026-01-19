using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using CentroMedico.Database;
using CentroMedico.models;

namespace CentroMedico.viewers
{
    public partial class CreateMedicalNote : Window
    {
        private int _patientId;
        public event EventHandler NoteSaved;

        public CreateMedicalNote(int patientId)
        {
            InitializeComponent();
            _patientId = patientId;

            // Configurar fecha por defecto a Hoy y bloquear fechas futuras
            dateInput.SelectedDate = DateTime.Now;
            dateInput.DisplayDateEnd = DateTime.Now;
        }

        private void CloseModal(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveNote(object sender, RoutedEventArgs e)
        {
            // Validaciones básicas: Que al menos haya nota de evolución y diagnóstico
            if (string.IsNullOrEmpty(evolutionNoteInput.Text) || string.IsNullOrEmpty(diagnosisInput.Text))
            {
                MessageBox.Show("Por favor ingresa al menos la Nota de Evolución y el Diagnóstico.");
                return;
            }

            try
            {
                using (var db = new ConsultorioContext())
                {
                    var newConsultation = new consulationModel
                    {
                        patient_id = _patientId,
                        date = dateInput.SelectedDate.Value,
                        type_consultation = consultationTypeInput.Text,

                        // Signos vitales con validación segura (0 si está vacío)
                        weight = float.Parse(string.IsNullOrEmpty(weightInput.Text) ? "0" : weightInput.Text),
                        height = float.Parse(string.IsNullOrEmpty(heightInput.Text) ? "0" : heightInput.Text),
                        temperature = float.Parse(string.IsNullOrEmpty(tempInput.Text) ? "0" : tempInput.Text),
                        heart_rate = float.Parse(string.IsNullOrEmpty(fcInput.Text) ? "0" : fcInput.Text),
                        respiratory_rate = float.Parse(string.IsNullOrEmpty(frInput.Text) ? "0" : frInput.Text),
                        pc = float.Parse(string.IsNullOrEmpty(pcInput.Text) ? "0" : pcInput.Text),

                        // --- AQUÍ ESTÁ EL CAMBIO IMPORTANTE ---
                        // Guardamos cada dato en su columna correspondiente
                        observations = evolutionNoteInput.Text,       // Nota de evolución -> observations
                        support_studies = studiesInput.Text,          // Estudios -> support_studies
                        diagnosis_treatment = diagnosisInput.Text     // Diagnóstico -> diagnosis_treatment
                    };

                    db.Consulations.Add(newConsultation);
                    db.SaveChanges();
                }

                MessageBox.Show("Nota guardada correctamente.");
                NoteSaved?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}");
            }
        }

        private void OnlyNumbers_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            if (regex.IsMatch(e.Text)) e.Handled = true;
        }
    }
}