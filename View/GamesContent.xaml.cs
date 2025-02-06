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

namespace ADETProjApp.View
{
    /// <summary>
    /// Interaction logic for GamesContent.xaml
    /// </summary>
    public partial class GamesContent : UserControl
    {
        public GamesContent()
        {
            InitializeComponent();
        }

        private void wordBtn_Click(object sender, RoutedEventArgs e)
        {
            Window window = new WordGameWindow();
            window.ShowDialog();
        }

        private void triviaBtn_Click(object sender, RoutedEventArgs e)
        {
            Window window = new TriviaGameWindow();
            window.ShowDialog();
        }
    }
}
