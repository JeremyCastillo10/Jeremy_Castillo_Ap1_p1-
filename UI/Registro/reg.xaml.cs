using System.Windows;
using Jeremy_Castillo_Ap1_p1_.Entidades;
using Jeremy_Castillo_Ap1_p1_.BLL;

namespace Jeremy_Castillo_Ap1_p1_.UI.Registros
{
    public partial class reg : Window
    {
        private Productos productos = new Productos();

        public reg()
        {
            InitializeComponent();
            this.DataContext = productos;

        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = this.productos;
        }

        private void Limpiar()
        {
            this.productos = new Productos();
            this.DataContext = productos;
        }

        private bool Validar()
        {
            bool valido = true;

            if(string.IsNullOrWhiteSpace(productos.Descripcion))
            {
                valido = false;
                DescripcionTextBox.Focus();
                MessageBox.Show("Indique el nombre del producto", "Validacion", MessageBoxButton.OK,MessageBoxImage.Error);
            }
            return valido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontrado = ProductosBLL.Buscar(this.productos.ProductoId);
            if(encontrado != null)
            {
                this.productos = encontrado;
                Cargar();
            }
            else 
            {
                Limpiar();
                MessageBox.Show("No se pudo encontar el producto", "Falido",MessageBoxButton.OK,MessageBoxImage.Error);
            }

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();


        }


        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if(ProductosBLL.BuscarDescripcion(DescripcionTextBox.Text) || DescripcionTextBox.Text == " ")
            {
                MessageBox.Show("Ya existe este Nombre", "fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if(ProductosBLL.BuscarDescripcion(DescripcionTextBox.Text))
            {
                MessageBox.Show("Solo puede haber un producto con este Nombre", "fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else{
                bool pasa = false;
                if(!Validar())
                return;

                pasa = ProductosBLL.Guardar(productos);

            if(pasa)
                 MessageBox.Show("Producto guardado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
               MessageBox.Show("No se pudo Guardar el Producto", "fallo", MessageBoxButton.OK, MessageBoxImage.Information);

            };
          

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if(ProductosBLL.Eliminar(productos.ProductoId))
            {
                Limpiar();
                MessageBox.Show("producto eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No se pudo Eliminar el producto", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
              
           
        }
}
}