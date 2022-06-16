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
using Project_3.Classes;

namespace Project_3
{
    /// <summary>
    /// Interaction logic for createpartij.xaml
    /// </summary>
    public partial class Themacreate : Window
    {
        public Themacreate()
        {
            InitializeComponent();
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Verkiezingdb verkiezingdb = new Verkiezingdb();
            if (verkiezingdb.InsertThema(tbthema.Text))
            {
                MessageBox.Show($"Thema aangemaakt");
            }
            else
            {
                MessageBox.Show($"Aanmaken mislukt");
            }
            this.Close();
        }
    }
}
