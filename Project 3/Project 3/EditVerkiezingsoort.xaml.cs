using Project_3.Classes;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Project_3
{
    /// <summary>
    /// Interaction logic for EditVerkiezingsoort.xaml
    /// </summary>
    public partial class EditVerkiezingsoort : Window
    {
        public EditVerkiezingsoort(DataRowView verkiezingsoort)
        {
            InitializeComponent();
            fillscreen(verkiezingsoort);
        }
        private void fillscreen(DataRowView verkiezingsoort)
        {
            tbid.Text = verkiezingsoort["verkiezingsoort_id"].ToString();
            tbnaam.Text = verkiezingsoort["verkiezingsoort"].ToString();
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Verkiezingdb verkiezingdb = new Verkiezingdb();
            if (verkiezingdb.UpdateVerkiezingsoort(int.Parse(tbid.Text), tbnaam.Text))
            {
                MessageBox.Show($"Thema {tbid.Text} aangepast");
            }
            else
            {
                MessageBox.Show($"Aanpassen van {tbid.Text} mislukt");
            }
            this.Close();
        }
    }
}
