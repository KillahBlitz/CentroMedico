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

            MessageBox.Show($"Saving patient: {patientName}...");

            this.Close();
        }
    }
}