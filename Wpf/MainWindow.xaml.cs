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
using Wpf.CRUDForModels;

namespace Wpf
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

        private void OpenClassWindow(object sender, RoutedEventArgs e)
        {
           MyClCRUD category = new MyClCRUD();
           category.ShowDialog();
        }

        private void OpenProfessorWindow(object sender, RoutedEventArgs e)
        {
            ProfessorCRUD product = new ProfessorCRUD();
            product.ShowDialog();
        }
    }
}
