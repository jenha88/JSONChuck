using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace Chuck
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            cmbBox.Items.Add("all");
            cmbBox.SelectedIndex = 0;

            using (var client = new HttpClient())
            {
                string jsonData = client.GetStringAsync("https://api.chucknorris.io/jokes/categories").Result;

                List<string>Category = JsonConvert.DeserializeObject<List<string>>(jsonData);
                foreach (var item in Category)
                {
                 
                    cmbBox.Items.Add(item);
                }
            }
        }

        private void btb_Click(object sender, RoutedEventArgs e)
        {
            string s = cmbBox.SelectedItem.ToString();
            if (s=="all")
            {
                using (var client = new HttpClient())
                {
                    string jsonData = client.GetStringAsync("https://api.chucknorris.io/jokes/random?").Result;
                    Category api = JsonConvert.DeserializeObject<Category>(jsonData);

                    txtBox.Text = api.value;

                }
            }
            else
            {
                using (var client = new HttpClient())
                {
                    string jsonData = client.GetStringAsync("https://api.chucknorris.io/jokes/random?category=" + s).Result;
                    Category api = JsonConvert.DeserializeObject<Category>(jsonData);

                    txtBox.Text = api.value;

                }
            }
            
        }
        
     
    }
}
