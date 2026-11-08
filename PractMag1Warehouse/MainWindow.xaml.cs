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

namespace PractMag1Warehouse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Warehouse_Click(object sender, RoutedEventArgs e)
        {
            //открытие окна со списком оборудования в аренде
            WarehouseWindow WarehouseWindow = new WarehouseWindow();
            this.Close();
            WarehouseWindow.Show();
        }

        private void Employee_Click(object sender, RoutedEventArgs e)
        {
            //открытие окна со списком сотрудников
            
        }

        private void Tool_Click(object sender, RoutedEventArgs e)
        {
            //открытие окна со списком оборуждования не в аренде
            
        }
    }
}