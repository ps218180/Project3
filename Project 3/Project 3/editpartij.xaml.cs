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
using System.Data;
using Project_3.Classes;

namespace Project_3
{
    /// <summary>
    /// Interaction logic for editpartij.xaml
    /// </summary>
    public partial class editpartij : Window
    {
        public editpartij(DataRowView partij)
        {
            InitializeComponent();
            fillscreen(partij);
        }
        private void fillscreen(DataRowView partij)
        {
            tbid.Text = partij["partij_id"].ToString();
            tbnaam.Text = partij["naam"].ToString();
            tbadres.Text = partij["adres"].ToString();
            tbpostcode.Text = partij["postcode"].ToString();
            tbgemeente.Text = partij["gemeente"].ToString();
            tbemail.Text = partij["emailadres"].ToString();
            tbtelefoonnummer.Text = partij["telefoonnummer"].ToString();
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Verkiezingdb verkiezingdb = new Verkiezingdb();
            if (verkiezingdb.Updatepartij(int.Parse(tbid.Text), tbnaam.Text, tbadres.Text, tbpostcode.Text, tbgemeente.Text, tbemail.Text, tbtelefoonnummer.Text))
            {
                MessageBox.Show($"Partij {tbid.Text} aangepast");
            }
            else
            {
                MessageBox.Show($"Aanpassen van {tbid.Text} mislukt");
            }
            this.Close();
        }
    }
}
