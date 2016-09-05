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

            tagim1.Selection.Text = Wypok.ConnectToMirko.WypiszTagi(mirek1.Text);
            tagim2.Selection.Text = Wypok.ConnectToMirko.WypiszTagi(mirek2.Text);

            string link1 = "http://bezpiecznykot.pl/wp-content/uploads/2015/12/kot-150x150.jpg";
        
            avm1.Source = new ImageSourceConverter().ConvertFromString(link1) as ImageSource;
          
            //string link = Wypok.ConnectToMirko.PobierzAvatar(mirek1.Text);
            //avm1.Source = new BitmapImage(new Uri(link));
            // avm2.Source = new BitmapImage(new Uri(Wypok.ConnectToMirko.PobierzAvatar(mirek2.Text)));
            lbl_wspolne.Content = Wypok.ConnectToMirko.CommonTags(mirek1.Text, mirek2.Text);









        }
    }
}
