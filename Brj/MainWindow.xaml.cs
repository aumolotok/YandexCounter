using Brj.Elements;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Brj
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainPage mainPage;

        private bool doesSale = false;

        private Thread saleThread;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChromeDriver browser = new ChromeDriver();
            browser.Navigate().GoToUrl("https://abcc.com/markets/eosbtc");
            mainPage = new MainPage(browser).Init();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            saleThread = new Thread(new ThreadStart(delegate () { TryThread(mainPage, label); }));
            while (doesSale)
            {
                Thread.Sleep(1000);
                label.Content = mainPage.glassObject.GetValue();
                Label a = label;
            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            doesSale = false;
        }

        private static void TryThread(MainPage page, Label label) => label.Content = page.glassObject.GetValue();
    }
}
