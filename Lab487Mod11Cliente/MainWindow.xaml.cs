using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
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
using Microsoft.WindowsAzure.ActiveDirectory.Authentication;

namespace Lab487Mod11Cliente
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

        private AuthenticationResult auth;

        private AuthenticationResult Autenticar()
        {
            var ctx = new AuthenticationContext("https://login.windows.net/lab487mod11ad.onmicrosoft.com");

            var res = ctx.AcquireToken("https://lab487mod11ad.onmicrosoft.com/Lab487Mod11", "3ca5457d-207f-464e-ac33-38f4c49538b2", "http://midominio/ok");

            return res;
        }

        private async Task<string> Operar(AuthenticationResult auth, string op, Operacion operacion)
        {
            var res = string.Empty;

            HttpClient cl = new HttpClient();
            cl.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth.AccessToken);

            var response = await cl.PostAsync("https://lab487mod11appservice.azurewebsites.net/api/" + op, new StringContent(operacion.ToJson(), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode) res = await response.Content.ReadAsStringAsync();

            return res;

        }

        private async void suma(object sender, RoutedEventArgs e)
        {
            var op = new Operacion()
            {
                Op1 = Convert.ToInt32(textBox.Text),
                Op2 = Convert.ToInt32(textBox1.Text)
            };
            if(auth == null) auth = Autenticar();
            label.Content = await Operar(auth,"suma",op);
        }

        private async void resta(object sender, RoutedEventArgs e)
        {
            var op = new Operacion()
            {
                Op1 = Convert.ToInt32(textBox.Text),
                Op2 = Convert.ToInt32(textBox1.Text)
            };
            if (auth == null) auth = Autenticar();
            label.Content = await Operar(auth, "resta", op);
        }

        private async void producto(object sender, RoutedEventArgs e)
        {
            var op = new Operacion()
            {
                Op1 = Convert.ToInt32(textBox.Text),
                Op2 = Convert.ToInt32(textBox1.Text)
            };
            if (auth == null) auth = Autenticar();
            label.Content = await Operar(auth, "producto", op);
        }

        private async void division(object sender, RoutedEventArgs e)
        {
            var op = new Operacion()
            {
                Op1 = Convert.ToInt32(textBox.Text),
                Op2 = Convert.ToInt32(textBox1.Text)
            };
            if (auth == null) auth = Autenticar();
            label.Content = await Operar(auth, "division", op);
        }
    }
}
