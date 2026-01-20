using System.Text;
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


namespace CentroMedico
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            initDataBase();
        }

        public static void initDataBase()
        {
            try
            {
                using (var db = new ConsultorioContext())
                {
                    db.Database.EnsureCreated();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error al inicializar la base de datos: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

    }
}