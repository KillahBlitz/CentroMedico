using CentroMedico.models; // Necesario para recibir el modelo
using System;
using System.Collections.Generic; // Para listas
using System.Windows;

namespace CentroMedico.viewers
{
    public partial class DetailsViewer : Window
    {
        private patientModel _currentPatient;

        public DetailsViewer(patientModel patient)
        {
            InitializeComponent();
            _currentPatient = patient;
            LoadVisualDesign(); 
        }

        private void LoadVisualDesign()
        {
            if (_currentPatient == null) return;

            txtNombrePaciente.Text = _currentPatient.name;

            txtDatosBasicos.Text = $"Edad: {_currentPatient.age} años   •   F. Nacim: {_currentPatient.birthdate:dd/MM/yyyy}";


            txtUltimosDatos.Text = "Peso: 00.0 kg   •   Altura: 000 cm (Pendiente BD)";
            txtAntecedentes.Text = "Aquí aparecerá la historia clínica del paciente cuando se conecte la base de datos.";

            List<string> listaPrueba = new List<string>
            {
                "Consulta 1 - (Datos de prueba para diseño)",
                "Consulta 2 - (Datos de prueba para diseño)"
            };
            listHistorial.ItemsSource = listaPrueba;
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
    }
}