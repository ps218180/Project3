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
            }
            private void verkiezingpartijgrid()
            {
                DataTable verkiezingpartij = Verkiezingdb.SelectVerkiezingPartij();
            
            
                    if (verkiezingpartij != null)
                    {
                    dgverkiezingPartij.ItemsSource = verkiezingpartij.DefaultView;
                    }
                
                
            }
            private void partijgrid()
            {
                DataTable partij = Verkiezingdb.SelectPartij();
                if (partij != null)
                {
                    dgpartij.ItemsSource = partij.DefaultView;
                }
            }
            private void standpuntgrid()
            {
                DataTable standpunt = Verkiezingdb.SelectStandpunt();
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
                partijgrid();
            }
            private void CreateStandpunt_Click(object sender, RoutedEventArgs e)
            {
                createstandpunt create = new createstandpunt();
                create.Show();
                standpuntgrid();
            }
            #endregion

            #region update
            private void UpdatePartij_Click(object sender, RoutedEventArgs e)
            {
                DataRowView selectedRow = dgpartij.SelectedItem as DataRowView;

                editpartij edit = new editpartij(selectedRow);
                edit.ShowDialog();
                partijgrid();
            }
            private void UpdateStandpunt_Click(object sender, RoutedEventArgs e)
            {
                DataRowView selectedRow = dgstandpunt.SelectedItem as DataRowView;

                editstandpunt edit = new editstandpunt(selectedRow);
                edit.ShowDialog();
                standpuntgrid();
            }
            #endregion

            #region delete
            private void DeletePartij_Click(object sender, RoutedEventArgs e)
            {
                DataRowView selectedRow = dgpartij.SelectedItem as DataRowView;

                if (Verkiezingdb.DeletePartij(selectedRow["partij_id"].ToString()))
                {
                    MessageBox.Show($"team {selectedRow["partij_id"]} verwijderd");
                }
                else
                {
                    MessageBox.Show($"Verwijderen van {selectedRow["partij_id"]} mislukt");
                }
                partijgrid();
            }
        #endregion

        private void cmbtabel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbtabel.SelectedIndex == 0)
            {
                dgpartij.ItemsSource = null;
                dgstandpunt.ItemsSource = null;
                dgverkiezingPartij.ItemsSource = null;
                partijgrid();
                dgpartij.Visibility = Visibility.Visible;
                dgstandpunt.Visibility = Visibility.Hidden;
                dgverkiezingPartij.Visibility = Visibility.Hidden;
                standpuntbtn.Visibility = Visibility.Hidden;
                partijbtn.Visibility = Visibility.Visible;
            }
            else if (cmbtabel.SelectedIndex == 1)
            {
                dgstandpunt.ItemsSource = null;
                dgpartij.ItemsSource = null;
                dgverkiezingPartij.ItemsSource = null;
                standpuntgrid();
                dgpartij.Visibility = Visibility.Hidden;
                dgstandpunt.Visibility = Visibility.Visible;
                dgverkiezingPartij.Visibility = Visibility.Hidden;
                standpuntbtn.Visibility = Visibility.Visible;
                partijbtn.Visibility = Visibility.Hidden;
            }
            else if (cmbtabel.SelectedIndex == 2)
            {

            }
        }
        }
    }
