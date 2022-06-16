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
            private void themagrid()
        {
            DataTable thema = Verkiezingdb.SelectThema();
            if (thema != null)
            {
                dgThema.ItemsSource = thema.DefaultView;
            }
        }
        private void verkiezinggrid()
        {
            DataTable verkiezing = Verkiezingdb.SelectVerkiezing();
            if (verkiezing != null)
            {
                dgVerkiezing.ItemsSource = verkiezing.DefaultView;
            }

        }
        private void verkiezingsoortgrid()
        {
            DataTable verkiezingsoort = Verkiezingdb.SelectVerkiezingsoort();
            if (verkiezingsoort != null)
            {
                dgVerkiezingsoort.ItemsSource = verkiezingsoort.DefaultView;
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
        private void CreateThema_Click(object sender, RoutedEventArgs e)
        {
            Themacreate create = new Themacreate();
            create.Show();
            themagrid();
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
        private void UpdateThema_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = dgThema.SelectedItem as DataRowView;

            EditThema edit = new EditThema(selectedRow);
            edit.ShowDialog();
            themagrid();
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
                dgThema.ItemsSource = null;
                dgVerkiezing.ItemsSource = null;
                dgVerkiezingsoort.ItemsSource = null;
                partijgrid();
                dgpartij.Visibility = Visibility.Visible;
                dgstandpunt.Visibility = Visibility.Hidden;
                dgverkiezingPartij.Visibility = Visibility.Hidden;
                dgThema.Visibility = Visibility.Hidden;
                dgVerkiezing.Visibility = Visibility.Hidden;
                dgVerkiezingsoort.Visibility = Visibility.Hidden;
                standpuntbtn.Visibility = Visibility.Hidden;
                partijbtn.Visibility = Visibility.Visible;
                verkiezingpartijbtn.Visibility = Visibility.Hidden;
                themabtn.Visibility = Visibility.Hidden;
                verkiezingbtn.Visibility = Visibility.Hidden;
                verkiezingsoortbtn.Visibility = Visibility.Hidden;
            }
            else if (cmbtabel.SelectedIndex == 1)
            {
                dgpartij.ItemsSource = null;
                dgstandpunt.ItemsSource = null;
                dgverkiezingPartij.ItemsSource = null;
                dgThema.ItemsSource = null;
                dgVerkiezing.ItemsSource = null;
                dgVerkiezingsoort.ItemsSource = null;
                standpuntgrid();
                dgpartij.Visibility = Visibility.Hidden;
                dgstandpunt.Visibility = Visibility.Visible;
                dgverkiezingPartij.Visibility = Visibility.Hidden;
                dgThema.Visibility = Visibility.Hidden;
                dgVerkiezing.Visibility = Visibility.Hidden;
                dgVerkiezingsoort.Visibility = Visibility.Hidden;
                partijbtn.Visibility = Visibility.Hidden;
                standpuntbtn.Visibility = Visibility.Visible;
                verkiezingpartijbtn.Visibility = Visibility.Hidden;
                themabtn.Visibility = Visibility.Hidden;
                verkiezingbtn.Visibility = Visibility.Hidden;
                verkiezingsoortbtn.Visibility = Visibility.Hidden;
            }
            else if (cmbtabel.SelectedIndex == 2)
            {
                dgpartij.ItemsSource = null;
                dgstandpunt.ItemsSource = null;
                dgverkiezingPartij.ItemsSource = null;
                dgThema.ItemsSource = null;
                dgVerkiezing.ItemsSource = null;
                dgVerkiezingsoort.ItemsSource = null;
                verkiezingpartijgrid();
                dgpartij.Visibility = Visibility.Hidden;
                dgstandpunt.Visibility = Visibility.Hidden;
                dgverkiezingPartij.Visibility = Visibility.Visible;
                dgThema.Visibility = Visibility.Hidden;
                dgVerkiezing.Visibility = Visibility.Hidden;
                dgVerkiezingsoort.Visibility = Visibility.Hidden;
                partijbtn.Visibility = Visibility.Hidden;
                standpuntbtn.Visibility = Visibility.Hidden;
                verkiezingpartijbtn.Visibility = Visibility.Visible;
                themabtn.Visibility = Visibility.Hidden;
                verkiezingbtn.Visibility = Visibility.Hidden;
                verkiezingsoortbtn.Visibility = Visibility.Hidden;
            }
            else if(cmbtabel.SelectedIndex == 3)
            {
                dgpartij.ItemsSource = null;
                dgstandpunt.ItemsSource = null;
                dgverkiezingPartij.ItemsSource = null;
                dgThema.ItemsSource = null;
                dgVerkiezing.ItemsSource = null;
                dgVerkiezingsoort.ItemsSource = null;
                themagrid();
                dgpartij.Visibility = Visibility.Hidden;
                dgstandpunt.Visibility = Visibility.Hidden;
                dgverkiezingPartij.Visibility = Visibility.Hidden;
                dgThema.Visibility = Visibility.Visible;
                dgVerkiezing.Visibility = Visibility.Hidden;
                dgVerkiezingsoort.Visibility = Visibility.Hidden;
                partijbtn.Visibility = Visibility.Hidden;
                standpuntbtn.Visibility = Visibility.Hidden;
                verkiezingpartijbtn.Visibility = Visibility.Hidden;
                themabtn.Visibility = Visibility.Visible;
                verkiezingbtn.Visibility = Visibility.Hidden;
                verkiezingsoortbtn.Visibility = Visibility.Hidden;
            }
            else if(cmbtabel.SelectedIndex == 4)
            {
                dgpartij.ItemsSource = null;
                dgstandpunt.ItemsSource = null;
                dgverkiezingPartij.ItemsSource = null;
                dgThema.ItemsSource = null;
                dgVerkiezing.ItemsSource = null;
                dgVerkiezingsoort.ItemsSource = null;
                verkiezinggrid();
                dgpartij.Visibility = Visibility.Hidden;
                dgstandpunt.Visibility = Visibility.Hidden;
                dgverkiezingPartij.Visibility = Visibility.Hidden;
                dgThema.Visibility = Visibility.Hidden;
                dgVerkiezing.Visibility = Visibility.Visible;
                dgVerkiezingsoort.Visibility = Visibility.Hidden;
                partijbtn.Visibility = Visibility.Hidden;
                standpuntbtn.Visibility = Visibility.Hidden;
                verkiezingpartijbtn.Visibility = Visibility.Hidden;
                themabtn.Visibility = Visibility.Hidden;
                verkiezingbtn.Visibility = Visibility.Visible;
                verkiezingsoortbtn.Visibility = Visibility.Hidden;
            }
            else if(cmbtabel.SelectedIndex == 5)
            {
                dgpartij.ItemsSource = null;
                dgstandpunt.ItemsSource = null;
                dgverkiezingPartij.ItemsSource = null;
                dgThema.ItemsSource = null;
                dgVerkiezing.ItemsSource = null;
                dgVerkiezingsoort.ItemsSource = null;
                verkiezingsoortgrid();
                dgpartij.Visibility = Visibility.Hidden;
                dgstandpunt.Visibility = Visibility.Hidden;
                dgverkiezingPartij.Visibility = Visibility.Hidden;
                dgThema.Visibility = Visibility.Hidden;
                dgVerkiezing.Visibility = Visibility.Hidden;
                dgVerkiezingsoort.Visibility = Visibility.Visible;
                partijbtn.Visibility = Visibility.Hidden;
                standpuntbtn.Visibility = Visibility.Hidden;
                verkiezingpartijbtn.Visibility = Visibility.Hidden;
                themabtn.Visibility = Visibility.Hidden;
                verkiezingbtn.Visibility = Visibility.Hidden;
                verkiezingsoortbtn.Visibility = Visibility.Visible;
            }
        }
        }
    }
