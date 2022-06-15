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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Project_3.Classes;

namespace Project_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Verkiezingdb Verkiezingdb = new Verkiezingdb();
        public MainWindow()
        {
            InitializeComponent();
            fillgrid();
        }
        private void fillgrid()
        {
            DataTable verkiezingpartij = Verkiezingdb.SelectVerkiezingPartij();
            DataTable standpunt = Verkiezingdb.SelectStandpunt();
            DataTable partij = Verkiezingdb.SelectPartij();
                if (verkiezingpartij != null)
                {
                    dgverkiezingPartij.ItemsSource = verkiezingpartij.DefaultView;
                }
                if (partij != null)
                {
                    dgpartij.ItemsSource = partij.DefaultView;
                }
                if (standpunt != null)
                {
                    dgstandpunt.ItemsSource = standpunt.DefaultView;
                }
        }
        #region create
        private void CreatePartij_Click(object sender, RoutedEventArgs e)
        {
            createpartij create = new createpartij();
            create.Show();
            fillgrid();
        }
        private void CreateStandpunt_Click(object sender, RoutedEventArgs e)
        {
            createstandpunt create = new createstandpunt();
            create.Show();
            fillgrid();
        }
        #endregion

        #region update
        private void UpdatePartij_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dgpartij.SelectedItem as DataRowView;

            editpartij edit = new editpartij(selectedRow);
            edit.ShowDialog();
            fillgrid();
        }
        private void UpdateStandpunt_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dgstandpunt.SelectedItem as DataRowView;

            editstandpunt edit = new editstandpunt(selectedRow);
            edit.ShowDialog();
            fillgrid();
        }
        #endregion

        #region delete

        #endregion
    }
}
