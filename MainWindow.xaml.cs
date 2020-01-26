using System;
using System.Collections.Generic;
using System.IO;
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

namespace final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<User> users = new List<User>();
        data data = new data();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_bttn_Click(object sender, RoutedEventArgs e)
        {
            String[] inpt = new String[6];
            for (int i = 0; i < 6; i++)
            {
                inpt[i] = input_window.GetLineText(i);
            }
            User user = new User(inpt[0], inpt[1], inpt[2], int.Parse(inpt[3]), inpt[4], inpt[5]);
            users.Add(user);

            x_anw.AppendText(user.anw_x.ToString());
            y_anw.AppendText(user.anw_y.ToString());

            data.write_data(user);
        }

        private void Clr_bttn_Click(object sender, RoutedEventArgs e)
        {
            input_window.Clear();
            x_anw.Clear();
            y_anw.Clear();
        }
    }

    class data
    {
        StreamWriter sw = new StreamWriter("../../../data.txt");
        public void write_data(User u)
        {
            sw.WriteLine(u.name + " " + u.last_name + " " + u.age + " " + u.city + " " + u.eq1 + " " + u.eq2);
            sw.Close();

            
        }
    }
}
