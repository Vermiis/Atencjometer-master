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



namespace Atencjometr
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

        private void btn_compare_Click(object sender, RoutedEventArgs e)
        {
          
            tagim1.Selection.Text = Wypok.ConnectToMirko.PobierzTagi(mirek1.Text).ToString();
            
            tagim2.Selection.Text = Wypok.ConnectToMirko.PobierzTagi(mirek2.Text).ToString();

           // Uri iconUri1 = new Uri(Wypok.ConnectToMirko.PobierzAvatar(mirek1.Text), UriKind.RelativeOrAbsolute);
           // avm1.Source = BitmapFrame.Create(iconUri1);
            avm2.Source = new BitmapImage(new Uri(Wypok.ConnectToMirko.PobierzAvatar(mirek1.Text), UriKind.Relative));







        }
    }
}
