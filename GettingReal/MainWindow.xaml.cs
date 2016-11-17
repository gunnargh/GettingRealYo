using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
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

namespace GettingReal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EJL72_DBDataSet data = new EJL72_DBDataSet();
        List<Jewlery> jewlery = new List<Jewlery>();
        int i = 0;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Image logoImage = new System.Windows.Controls.Image();
            i++;
            connection(i);
            labelName.Content = "Name: " + jewlery[i-1].JName;
            LabelPrice.Content = "Price : " + jewlery[i-1].JPrice;
            LabelDescription.Content = "Description: " + jewlery[i-1].JDescription;
            logoImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/Images/" + jewlery[i-1].ID + ".jpg"));
            GridImage.Children.Add(logoImage);
        }
        private void BtnBack_click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Image logoImage = new System.Windows.Controls.Image();
            i--;
            connection(i);
            labelName.Content = "Name: " + jewlery[i - 1].JName;
            LabelPrice.Content = "Price : " + jewlery[i - 1].JPrice;
            LabelDescription.Content = "Description: " + jewlery[i - 1].JDescription;
            logoImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/Images/" + jewlery[i - 1].ID + ".jpg"));
            GridImage.Children.Add(logoImage);
        }

        public void connection(int i)
        {
            
            using (SqlConnection con = new SqlConnection(GettingReal.Properties.Settings.Default.EJL72_DBConnectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("select * from JewleryInfo where JID = " + i, con))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            int price = reader.GetInt32(2);
                            int quanity = reader.GetInt32(3);
                            string desc = reader.GetString(4);
                            string type = reader.GetString(5);
                            jewlery.Add(new Jewlery(id, name,price,quanity,desc,type));

                        }
                    }

                }
                catch (SqlException ex)
                {

                    Console.WriteLine(ex);
                }
                con.Close();
            }
            
        }

        
    }
}
