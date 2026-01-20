using CentroMedico.models;
using CentroMedico.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace CentroMedico.viewers
{
    public partial class DetailsViewer : Window
    {
        private patientModel Patient;
        List<consulationModel> consulationList = new List<consulationModel>();
        List<historyModel> historyList = new List<historyModel>();

        public DetailsViewer(patientModel patient)
        {
            InitializeComponent();
            Patient = patient;
            LoadVisualDesign();
        }

        private void LoadVisualDesign()
        {
            txtNombrePaciente.Text = Patient.name;
            txtDatosBasicos.Text = $"Edad: {Patient.age} años, {Patient.age_mounth} meses   •   F. Nacim: {Patient.birthdate:dd/MM/yyyy}";

            UpdateWeightAndHeight();
            txtUltimosDatos.Text = $"Ultimo Peso: {Patient.weight} kg   •   Ultima Altura: {Patient.height} cm";

            txtTipoPaciente.Text = string.IsNullOrEmpty(Patient.type_patient) ? "General" : Patient.type_patient;
            txtApgar.Text = string.IsNullOrEmpty(Patient.apgar) ? "Indefinido" : Patient.apgar;
            txtTipoSangre.Text = string.IsNullOrEmpty(Patient.blood_type) ? "Por definir" : Patient.blood_type;

            try
            {
                using (var db = new ConsultorioContext())
                {
                    consulationList = db.Consulations
                        .Where(c => c.patient_id == Patient.id)
                        .OrderByDescending(c => c.date)
                        .ToList();
                }

                using (var db = new ConsultorioContext())
                {
                    historyList = db.Histories
                        .Where(h => h.patient_id == Patient.id)
                        .ToList();
                }

                listHistorial.ItemsSource = consulationList;
                listHistories.ItemsSource = historyList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}");
            }
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ReloadPatientData()
        {
            try
            {
                using (var db = new ConsultorioContext())
                {
                    var updatedPatient = db.Patients.Find(Patient.id);
                    if (updatedPatient != null)
                    {
                        Patient.name = updatedPatient.name;
                        Patient.type_patient = updatedPatient.type_patient;
                        Patient.birthdate = updatedPatient.birthdate;
                        Patient.blood_type = updatedPatient.blood_type;
                        Patient.apgar = updatedPatient.apgar;
                        Patient.age = updatedPatient.age;
                        Patient.age_mounth = updatedPatient.age_mounth;
                        Patient.weight = updatedPatient.weight;
                        Patient.height = updatedPatient.height;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al recargar datos del paciente: {ex.Message}");
            }
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            UpdatePatientViewer updateModal = new UpdatePatientViewer(Patient);
            updateModal.PatientUpdated += (s, args) =>
            {
                ReloadPatientData();
                LoadVisualDesign();
            };
            updateModal.ShowDialog();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "¿Seguro que deseas eliminar al paciente? Se eliminarán todas sus consultas y antecedentes.",
                "Confirmar Eliminación",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    using (var db = new ConsultorioContext())
                    {
                        var patientToDelete = db.Patients.Find(Patient.id);

                        var relatedConsultations = db.Consulations.Where(c => c.patient_id == Patient.id);
                        db.Consulations.RemoveRange(relatedConsultations);

                        var relatedHistory = db.Histories.Where(h => h.patient_id == Patient.id);
                        db.Histories.RemoveRange(relatedHistory);

                        db.Patients.Remove(patientToDelete);

                        db.SaveChanges();

                        MessageBox.Show("Paciente eliminado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar datos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void UpdateWeightAndHeight()
        {
            try
            {
                using (var db = new ConsultorioContext())
                {
                    var consultations = db.Consulations
                        .Where(c => c.patient_id == Patient.id)
                        .OrderByDescending(c => c.date)
                        .FirstOrDefault();

                    if (consultations != null)
                    {
                        Patient.weight = consultations.weight;
                        Patient.height = consultations.height;

                        var patientToUpdate = db.Patients.Find(Patient.id);
                        if (patientToUpdate != null)
                        {
                            patientToUpdate.weight = consultations.weight;
                            patientToUpdate.height = consultations.height;
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar peso y altura: {ex.Message}");
            }
        }

        private static List<consulationModel> ConsulationListObtains(int patientId)
        {
            try
            {
                using (var db = new ConsultorioContext())
                {
                    var consultations = db.Consulations
                        .Where(c => c.patient_id == patientId)
                        .OrderByDescending(c => c.date)
                        .ToList();
                    return consultations;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener las consultas: {ex.Message}");
                return new List<consulationModel>();
            }
        }


        private void BtnNuevaNota_Click(object sender, RoutedEventArgs e)
        {

            CreateMedicalNote notaWindow = new CreateMedicalNote(Patient.id);

            notaWindow.NoteSaved += (s, args) =>
            {
                LoadVisualDesign();
                ReloadPatientData();
            };

            notaWindow.ShowDialog();
        }

        private void btnEditConsultation_Click(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.Button button && button.Tag is consulationModel consultation)
            {
                CreateMedicalNote editWindow = new CreateMedicalNote(Patient.id, consultation);

                editWindow.NoteSaved += (s, args) =>
                {
                    LoadVisualDesign();
                    ReloadPatientData();
                };

                editWindow.ShowDialog();
            }
        }

        private void btnDeleteConsultation_Click(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.Button button && button.Tag is consulationModel consultation)
            {
                MessageBoxResult result = MessageBox.Show(
                    $"¿Seguro que deseas eliminar la consulta del {consultation.date:dd/MM/yyyy}?",
                    "Confirmar Eliminación",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        using (var db = new ConsultorioContext())
                        {
                            var consultationToDelete = db.Consulations.Find(consultation.id);
                            if (consultationToDelete != null)
                            {
                                db.Consulations.Remove(consultationToDelete);
                                db.SaveChanges();

                                MessageBox.Show("Consulta eliminada correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                                LoadVisualDesign();
                                ReloadPatientData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar consulta: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}