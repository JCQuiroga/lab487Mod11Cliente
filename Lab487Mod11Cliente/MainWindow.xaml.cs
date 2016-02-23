using System;
using System.Collections.Generic;
using System.Linq;
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
        
        private AuthenticationResult Autenticar()
        {
            var ctx = new AuthenticationContext("http://login.windows.net/lab487mod11ad.onmicrosoft.com");

            var res = ctx.AcquireToken("https://lab487mod11ad.onmicrosoft.com/Lab487Mod11", "3ca5457d-207f-464e-ac33-38f4c49538b2", "http://midominio/ok");

            return res;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
