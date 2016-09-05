using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;


namespace AtjWinForms
{
    public partial class Atencjometer : Form
    {
        public Atencjometer()
        {
            InitializeComponent();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {

            var nick1 = txtbNick1.Text;
            var nick2 = txtBNick2.Text;
            
            rtxtBTagi1.Text = ConnectToMirko.WypiszTagi(txtbNick1.Text);
            rtxtBTagi2.Text = ConnectToMirko.WypiszTagi(txtBNick2.Text);
            avMirek1.Image = ConnectToMirko.UstawAvek(txtbNick1.Text);
            avMirek2.Image = ConnectToMirko.UstawAvek(txtBNick2.Text);
            lblCommonTags.Text = ConnectToMirko.CommonTags(nick1, nick2).ToString();
           
        }

       
    }
}
