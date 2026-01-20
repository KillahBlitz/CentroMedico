using System;
using System.Windows;
using System.Windows.Controls;
using CentroMedico.Database;
using CentroMedico.models;

namespace CentroMedico.viewers
{
    public partial class CreateHistoryViewer : Window
    {
        private int _patientId;
        public event EventHandler HistorySaved;

        public CreateHistoryViewer(int patientId)
        {
            InitializeComponent();
            _patientId = patientId;
        }

        private void CloseModal(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveHistory(object sender, RoutedEventArgs e)
        {
            string description = historyInput.Text;
            string type = typeInput.Text;

            if (string.IsNullOrEmpty(type))
            {
                MessageBox.Show("Por favor escribe el tipo de antecedente.");
                return;
            }

            if (string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Por favor escribe la descripción del antecedente.");
                return;
            }

            try
            {
                using (var db = new ConsultorioContext())
                {
                    var newHistory = new historyModel
                    {
                        patient_id = _patientId,
                        type_history = type,
                        history = description
                    };

                    db.Histories.Add(newHistory);
                    db.SaveChanges();
                }

                MessageBox.Show("Antecedente agregado correctamente.");
                HistorySaved?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}");
            }
        }
    }
}