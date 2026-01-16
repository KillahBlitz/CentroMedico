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
using Microsoft.EntityFrameworkCore;

namespace CentroMedico.viewers
{

    public partial class principalViewer : UserControl
    {
     
        private List<patientModel> _todosLosPacientes;

        public principalViewer()
        {
            InitializeComponent();

            ConsultorioContext.PrepararBaseDeDatos();

            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                using (var db = new ConsultorioContext())
                {
     
                    _todosLosPacientes = db.Patients.ToList();
                }

                listaPacientes.ItemsSource = _todosLosPacientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}");
            }
        }

        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
  
            if (_todosLosPacientes == null) return;


            string textoBusqueda = txtBuscar.Text.ToLower();


            if (string.IsNullOrEmpty(textoBusqueda))
            {
                listaPacientes.ItemsSource = _todosLosPacientes;
                return;
            }

            var listaFiltrada = _todosLosPacientes
                                .Where(paciente => paciente.name != null &&
                                                   paciente.name.ToLower().Contains(textoBusqueda))
                                .ToList();

            listaPacientes.ItemsSource = listaFiltrada;
        }

    }
}