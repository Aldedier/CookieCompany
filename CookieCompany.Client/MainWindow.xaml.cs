using CookieCompany.Model.Services.FaultExcepcion;
using System;
using System.Linq;
using System.ServiceModel;
using System.Windows;

namespace CookieCompany.Client
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var proxy = new Proxy.ProductsServiceClient())
            {
                var products = await proxy.GetProductsAsync();
                lstResults.ItemsSource = products;
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var proxy = new Proxy.ProductsServiceClient())
            {
                int.TryParse(txtId.Text, out int _idProduct);
                var products = await proxy.GetProductsByIdAsync(_idProduct);
                MessageBox.Show(products);
            }
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (var proxy = new Proxy.ProductsServiceClient())
            {
                var products = await proxy.ProductosAsync();
                lstResults.ItemsSource = products.Select(x => x.Name);
            }
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            using (var proxy = new Proxy.ProductsServiceClient())
            {
                string nombre = txt_nombre.Text;
                string imagen = txt_imagen.Text;

                try
                {
                    await proxy.AddProductAsync( new Model.Services.Data.ProductoDTO { Name = nombre, Image = imagen });
                    MessageBox.Show("El producto se agregó correctamente");
                }
                catch (FaultException<ProductoFault> inventFault)
                {
                    MessageBox.Show(inventFault.Detail.Mensaje);
                }
            }
        }
    }
}
