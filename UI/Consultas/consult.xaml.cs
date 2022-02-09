   
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
             var listado = new List<Productos>();
            if (string.IsNullOrWhiteSpace(CriterioTextBox.Text))
            {
                listado = ProductosBLL.GetList(l => true);
            }
            else
            {
                switch(FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = ProductosBLL.GetList(l => l.ProductoId.ToString() == (CriterioTextBox.Text));
                        break;
                    case 1:
                        listado = ProductosBLL.GetList(l => l.Descripcion == (CriterioTextBox.Text));
                        break;
                }
            }

            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = listado;

        }

    }
}