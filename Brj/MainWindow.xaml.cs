using Brj.Elements;
using OpenQA.Selenium.Chrome;
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

namespace Brj
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainPage mainPage;

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
            Value1.Content = mainPage.glassObject.GetValue();
        }
    }
}
