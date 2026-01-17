using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; // <--- IMPORTANTE: Agregué esto para que funcione el Regex
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CentroMedico.viewers
{
    public partial class CreatePatientViewer : Window
    {
        public CreatePatientViewer()
        {
            InitializeComponent();
        }

        // Función para validar que solo se escriban números y un solo punto decimal
        private void OnlyNumbers_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // 1. Si el caracter NO es un número o un punto, bloquéalo
            Regex regex = new Regex("[^0-9.]+");
            if (regex.IsMatch(e.Text))
            {
                e.Handled = true;
                return;
            }

            // 2. Si es un punto, revisa que no haya otro punto ya escrito
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
            // Nota: Para obtener el texto de los ComboBox (Sangre/Apgar) 
            // necesitarás acceder a su SelectedItem o Text dependiendo de cómo lo quieras guardar.
            // Por ahora mantengo tu lógica original de inputs de texto.

            string patientName = fullNameInput.Text;
            string typePatient = patientTypeInput.Text;
            string weight = weightInput.Text;
            string height = heightInput.Text;
            string history = historyInput.Text;

            // Para el ComboBox de sangre, obtenemos el texto del item seleccionado
            string BloodType = bloodTypeInput.Text;

            DateOnly? birthdate = dobInput.SelectedDate.HasValue ? DateOnly.FromDateTime(dobInput.SelectedDate.Value) : null;

            ChampsValidation(patientName, weight, height, BloodType, birthdate);
        }

        public static void ChampsValidation(string name, string weight, string height, string bloodType, DateOnly? birthDate)
        {
            // MessageBox.Show("Validando campos..."); // Puedes comentar esto si es molesto

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
            
            else if (string.IsNullOrEmpty(bloodType) || bloodType == "Por definir")
            {
                MessageBox.Show("El campo de tipo de sangre es obligatorio o debe ser definido.");
            }
            else if (birthDate == null)
            {
                MessageBox.Show("El campo de fecha de nacimiento es obligatorio.");
            }
            else
            {
             
                MessageBox.Show("¡Validación exitosa! Guardando datos...");
              
            }
        }

        private void fullNameInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}