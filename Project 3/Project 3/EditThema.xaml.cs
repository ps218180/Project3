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
    /// Interaction logic for EditThema.xaml
    /// </summary>
    public partial class EditThema : Window
    {
        public EditThema(DataRowView thema)
        {
            InitializeComponent();
            fillscreen(thema);
        }
        private void fillscreen(DataRowView thema)
        {
            tbid.Text = thema["thema_ID"].ToString();
            tbnaam.Text = thema["thema"].ToString();
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Verkiezingdb verkiezingdb = new Verkiezingdb();
            if (verkiezingdb.UpdateThema(int.Parse(tbid.Text), tbnaam.Text))
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
