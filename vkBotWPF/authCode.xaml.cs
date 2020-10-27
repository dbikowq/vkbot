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
using System.Windows.Shapes;
using static vkBotWPF.MainWindow;

namespace vkBotWPF
{
    /// <summary>
    /// Логика взаимодействия для authCode.xaml
    /// </summary>
    public partial class authCode : Window
    {
        public authCode()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.codeAuth = tbCode.Text;
            this.DialogResult = true;
        }
    }
}
