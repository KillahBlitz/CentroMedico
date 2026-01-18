using CentroMedico.models;
using CentroMedico.Database;
using System;
using System.Collections.Generic;
using System.Windows;

namespace CentroMedico.viewers
{
    public partial class DetailsViewer : Window
    {
        private patientModel Patient;

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
            txtAntecedentes.Text = "Aquí aparecerá la historia clínica del paciente cuando se conecte la base de datos.";

            List<consulationModel> consulationList = ConsulationListObtains(Patient.id);
            List<string> Details = new List<string>();
            foreach (var consulation in consulationList)
            {
                string textData = $"Observaciones: {consulation.observations} \n";
                Details.Add(textData);
            }
            listHistorial.ItemsSource = Details;
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Botón de Editar presionado (Diseño OK).");
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Botón de Eliminar presionado (Diseño OK).");
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
                        db.SaveChanges();
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
    }
}