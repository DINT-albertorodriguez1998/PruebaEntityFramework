using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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

namespace PruebaEntityFramework
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Tema_6Entities contexto;
        CLIENTE c;
        CollectionViewSource vista;

        public MainWindow()
        {
            InitializeComponent();

            c = new CLIENTE
            {
                id = 0,
                nombre = "",
                apellido = ""
            };

            contexto = new Tema_6Entities();
            contexto.CLIENTES.Load();

            vista = new CollectionViewSource();
            vista.Source = contexto.CLIENTES.Local;

            this.DataContext = contexto.CLIENTES.Local;
            InsertarStackPanel.DataContext = c;
            ClientesDataGrid.DataContext = vista;
            ClientesVistaDataGrid.DataContext = vista;
            vista.Filter += Vista_Filter;
        }

        private void Vista_Filter(object sender, FilterEventArgs e)
        {
            CLIENTE c = (CLIENTE)e.Item;


        }

        private void InsertarButton_Click(object sender, RoutedEventArgs e)
        {
            contexto.CLIENTES.Add(c);
            contexto.SaveChanges();

            c = new CLIENTE();
            InsertarStackPanel.DataContext = c;
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            contexto.CLIENTES.Remove((CLIENTE)EliminarComboBox.SelectedValue);
            contexto.SaveChanges();
        }

        private void ModificarButton_Click(object sender, RoutedEventArgs e)
        {
            contexto.SaveChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            contexto.SaveChanges();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            vista.View.Refresh();
        }
    }
}
