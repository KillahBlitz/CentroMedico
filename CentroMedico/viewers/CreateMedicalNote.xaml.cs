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
        private consulationModel _existingConsultation;
        private bool _isEditMode;
        public event EventHandler NoteSaved;

        public CreateMedicalNote(int patientId)
        {
            InitializeComponent();
            _patientId = patientId;
            _isEditMode = false;

            dateInput.SelectedDate = DateTime.Now;
            dateInput.DisplayDateEnd = DateTime.Now;
        }

        public CreateMedicalNote(int patientId, consulationModel consultation)
        {
            InitializeComponent();
            _patientId = patientId;
            _existingConsultation = consultation;
            _isEditMode = true;

            dateInput.DisplayDateEnd = DateTime.Now;

            LoadConsultationData();
        }

        private void LoadConsultationData()
        {
            if (_existingConsultation != null)
            {
                dateInput.SelectedDate = _existingConsultation.date;
                consultationTypeInput.Text = _existingConsultation.type_consultation;

                weightInput.Text = _existingConsultation.weight.ToString();
                heightInput.Text = _existingConsultation.height.ToString();
                tempInput.Text = _existingConsultation.temperature.ToString();
                fcInput.Text = _existingConsultation.heart_rate.ToString();
                frInput.Text = _existingConsultation.respiratory_rate.ToString();
                pcInput.Text = _existingConsultation.pc.ToString();

                evolutionNoteInput.Text = _existingConsultation.observations;
                studiesInput.Text = _existingConsultation.support_studies;
                diagnosisInput.Text = _existingConsultation.diagnosis_treatment;
            }
        }

        private void CloseModal(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveNote(object sender, RoutedEventArgs e)
        {
            bool validation = FieldsValidation(
                dateInput.SelectedDate,
                consultationTypeInput.Text,
                weightInput.Text,
                heightInput.Text,
                tempInput.Text,
                fcInput.Text,
                frInput.Text,
                pcInput.Text,
                evolutionNoteInput.Text
            );

            if (!validation)
            {
                return;
            }

            try
            {
                using (var db = new ConsultorioContext())
                {
                    consulationModel consultation;

                    if (_isEditMode && _existingConsultation != null)
                    {
                        consultation = db.Consulations.Find(_existingConsultation.id);
                        if (consultation == null)
                        {
                            MessageBox.Show("No se encontró la consulta a editar.");
                            return;
                        }
                    }
                    else
                    {
                        consultation = new consulationModel
                        {
                            patient_id = _patientId
                        };
                    }

                    consultation.date = dateInput.SelectedDate.Value;
                    consultation.type_consultation = string.IsNullOrWhiteSpace(consultationTypeInput.Text) ? "General" : consultationTypeInput.Text;

                    consultation.weight = float.Parse(string.IsNullOrEmpty(weightInput.Text) ? "0" : weightInput.Text);
                    consultation.height = float.Parse(string.IsNullOrEmpty(heightInput.Text) ? "0" : heightInput.Text);
                    consultation.temperature = float.Parse(string.IsNullOrEmpty(tempInput.Text) ? "0" : tempInput.Text);
                    consultation.heart_rate = float.Parse(string.IsNullOrEmpty(fcInput.Text) ? "0" : fcInput.Text);
                    consultation.respiratory_rate = float.Parse(string.IsNullOrEmpty(frInput.Text) ? "0" : frInput.Text);
                    consultation.pc = float.Parse(string.IsNullOrEmpty(pcInput.Text) ? "0" : pcInput.Text);

                    consultation.observations = evolutionNoteInput.Text;
                    consultation.support_studies = string.IsNullOrWhiteSpace(studiesInput.Text) ? "Ninguno" : studiesInput.Text;
                    consultation.diagnosis_treatment = string.IsNullOrWhiteSpace(diagnosisInput.Text) ? "Pendiente" : diagnosisInput.Text;

                    if (!_isEditMode)
                    {
                        db.Consulations.Add(consultation);
                    }

                    db.SaveChanges();
                }

                MessageBox.Show(_isEditMode ? "Consulta actualizada correctamente." : "Nota guardada correctamente.");
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

        public static bool FieldsValidation(DateTime? date, string typeConsultation, string weight, string height, 
                                           string temperature, string heartRate, string respiratoryRate, 
                                           string pc, string observations)
        {
            bool isValid = false;
            if (date == null)
            {
                MessageBox.Show("El campo de fecha es obligatorio.");
            }
            else if (string.IsNullOrWhiteSpace(weight))
            {
                MessageBox.Show("El campo de peso es obligatorio.");
            }
            else if (string.IsNullOrWhiteSpace(height))
            {
                MessageBox.Show("El campo de altura es obligatorio.");
            }
            else if (string.IsNullOrWhiteSpace(temperature))
            {
                MessageBox.Show("El campo de temperatura es obligatorio.");
            }
            else if (string.IsNullOrWhiteSpace(heartRate))
            {
                MessageBox.Show("El campo de frecuencia cardíaca es obligatorio.");
            }
            else if (string.IsNullOrWhiteSpace(respiratoryRate))
            {
                MessageBox.Show("El campo de frecuencia respiratoria es obligatorio.");
            }
            else if (string.IsNullOrWhiteSpace(pc))
            {
                MessageBox.Show("El campo de PC es obligatorio.");
            }
            else if (string.IsNullOrWhiteSpace(observations))
            {
                MessageBox.Show("El campo de nota de evolución es obligatorio.");
            }
            else
            {
                isValid = true;
            }
            return isValid;
        }
    }
}