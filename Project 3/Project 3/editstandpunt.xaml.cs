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
    /// Interaction logic for editstandpunt.xaml
    /// </summary>
    public partial class editstandpunt : Window
    {
        public editstandpunt(DataRowView standpunt)
        {
            InitializeComponent();
            fillscreen(standpunt);
        }
        private void fillscreen(DataRowView standpunt)
        {
            tbstandpuntid.Text = standpunt["standpunt_id"].ToString();
            tbthemaid.Text = standpunt["thema_id"].ToString();
            tbstandpunt.Text = standpunt["standpunt"].ToString();
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Verkiezingdb verkiezingdb = new Verkiezingdb();
            if (verkiezingdb.Updatestandpunt(int.Parse(tbstandpuntid.Text), int.Parse(tbthemaid.Text), tbstandpunt.Text))
            {
                MessageBox.Show($"standpunt {tbstandpuntid.Text} aangepast");
            }
            else
            {
                MessageBox.Show($"Aanpassen van {tbstandpuntid.Text} mislukt");
            }
            this.Close();
        }
    }
}
