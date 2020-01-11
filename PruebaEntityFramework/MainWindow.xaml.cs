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
            ClientesListBox.DataContext = contexto.CLIENTES.Local;
            InsertarStackPanel.DataContext = c;
            EliminarComboBox.DataContext = contexto.CLIENTES.Local;
            ModificarComboBox.DataContext = contexto.CLIENTES.Local;

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
            CLIENTE c = (CLIENTE)ModificarComboBox.SelectedValue;
            c.id = int.Parse(IdentificadorTextBox.Text);
            c.nombre = NombreTextBox.Text;
            c.apellido = ApellidoTextBox.Text;
                

            contexto.SaveChanges();
        }
    }
}
