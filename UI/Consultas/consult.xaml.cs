   
using System.Windows;
using Jeremy_Castillo_Ap1_p1_.Entidades;
using Jeremy_Castillo_Ap1_p1_.BLL;
using System.Linq;
using System.Collections.Generic;

namespace Jeremy_Castillo_Ap1_p1_.UI.Consultas
{
    public partial class consult : Window
    {

        public consult()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var lista = new List<Productos>();

            if(string.IsNullOrWhiteSpace(CriterioTextBox.Text))
            lista = ProductosBLL.GetList(l => true);
            else{
                switch(FiltroComboBox.SelectedIndex)
                {
                    case 1:
                        lista = ProductosBLL.GetList(l => l.ProductoId.ToString().Contains(CriterioTextBox.Text));
                        break;
                    case 2:
                        lista = ProductosBLL.GetList(l => l.Descripcion.Contains(CriterioTextBox.Text));
                        break;
                    case 3:
                        lista = ProductosBLL.GetList(l => l.Costo.ToString().Contains(CriterioTextBox.Text));
                        break;
                }
            }
            

            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = lista;

        }

    }
}