﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

            var nick1 = mirek1.Text;
            var nick2 = mirek2.Text;
            if (nick1.Length == 0 || nick2.Length == 0)
            {
                System.Windows.MessageBox.Show("Wpisz oba nicki");
                return;
            }
            try
            {
                tagim1.Selection.Text = Wypok.Connect.WypiszTagi(mirek1.Text);
                tagim2.Selection.Text = Wypok.Connect.WypiszTagi(mirek2.Text);
            }
            catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.NotFound)
            {
                System.Windows.MessageBox.Show("Nie istnieje taki mirek");
                return;
            }
            catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.ServiceUnavailable)
            {
                MessageBox.Show("Serwer nie odpowiada");
                return;
            }
            catch (Exception exc)
            {
                System.Windows.MessageBox.Show("Error{0}", exc.ToString());
                throw;
            }
            string link1 = "http://bezpiecznykot.pl/wp-content/uploads/2015/12/kot-150x150.jpg";

            avm1.Source = new ImageSourceConverter().ConvertFromString(link1) as ImageSource;

            //string link = Wypok.ConnectToMirko.PobierzAvatar(mirek1.Text);
            //avm1.Source = new BitmapImage(new Uri(link));
            lbl_wspolne.Content = Wypok.Connect.CommonTags(mirek1.Text, mirek2.Text);
          //  avm1.Source = new BitmapImage(new Uri(Wypok.ConnectToMirko.PobierzAvatar(mirek1.Text)));
           // avm2.Source = new BitmapImage(new Uri(Wypok.ConnectToMirko.PobierzAvatar(mirek2.Text)));
            
            
           









        }
    }
}
