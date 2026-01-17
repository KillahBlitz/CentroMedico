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
using System.Windows.Shapes;

namespace CentroMedico.viewers
{
    public partial class CreatePatientViewer : Window
    {
        public CreatePatientViewer()
        {
            InitializeComponent();
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
            string BloodType = bloodTypeInput.Text;

            DateOnly? birthdate = dobInput.SelectedDate.HasValue ? DateOnly.FromDateTime(dobInput.SelectedDate.Value) : null;

            ChampsValidation(patientName, weight, height, BloodType, birthdate);
        }

        public static void ChampsValidation(string name, string weight, string height, string bloodType, DateOnly? birthDate)
        {
            MessageBox.Show("Validando campos...");
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
            else if (string.IsNullOrEmpty(bloodType))
            {
                MessageBox.Show("El campo de tipo de sangre es obligatorio.");
            }
            else if (birthDate == null)
            {
                MessageBox.Show("El campo de fecha de nacimiento es obligatorio.");
            }
        }
    }
}