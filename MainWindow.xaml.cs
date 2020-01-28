using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        private IEnumerable<User> user_check_Query;
        public static MainWindow AppWindow;
        Clock MyClock = new Clock();
        static List<User> users_list = new List<User>();
        static List<System_2_2> system_list = new List<System_2_2>();
        data data = new data();

        public MainWindow()
        {
            InitializeComponent();
            AppWindow = this;
            Thread ClockThread = new Thread(Update);
            ClockThread.Start();
        }

        private void Update()
        {
            DateTime dateTime;
            Dispatcher.BeginInvoke(new Action(() =>
            {
                MyClock.DrawClock();
                MyClock.FrameShape.Demo();
            }));
            while (true)
            {
                Thread.Sleep(1000);
                dateTime = DateTime.Now;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    MyClock.UpdateClock();
                }));
            }
        }

        private void Add_bttn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String[] get_input_win = input_window.Text.Split("\r\n");
                check_input(get_input_win);
                User user_new = new User(get_input_win[0], get_input_win[1], get_input_win[2], get_input_win[3], get_input_win[4], get_input_win[5]);
                Equation equation1 = new Equation(get_input_win[4]);
                Equation equation2 = new Equation(get_input_win[5]);
                System_2_2 system_2_2 = new System_2_2(equation1, equation2);
                bool is_added_user = check_list_users(user_new, users_list);
                if (is_added_user)
                    throw new Exception("your informations is Available.");
                users_list.Add(user_new);
                bool is_added_system = check_list_systems(system_2_2);
                if (!is_added_system)
                {
                    system_2_2.solve_x();
                    system_2_2.solve_y();
                    system_list.Add(system_2_2);
                }
                user_new.anw_x = system_2_2.anw_x;
                user_new.anw_y = system_2_2.anw_y;
                x_anw_window.AppendText(system_2_2.anw_x.ToString());
                y_anw_window.AppendText(system_2_2.anw_y.ToString());

                data.write_data(user_new);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool check_list_systems(System_2_2 system_2_2)
        {
            foreach (System_2_2 ss in system_list)
            {
                if ((ss.eq1 == system_2_2.eq1 && ss.eq2 == system_2_2.eq2) || (ss.eq1 == system_2_2.eq2 && ss.eq2 == system_2_2.eq1))
                {
                    system_2_2.anw_x = ss.anw_x;
                    system_2_2.anw_y = ss.anw_y;
                    return true;
                }
            }
            return false;
        }

        private bool check_list_users(User user_new, List<User> list)
        {
            foreach (User s in list)
            {
                if (s.name.Equals(user_new.name) && s.last_name.Equals(user_new.last_name) &&
                    s.city.Equals(user_new.city) && s.age.Equals(user_new.age) &&
                    ((s.eq1.Equals(user_new.eq1) && s.eq2.Equals(user_new.eq2)) || (s.eq1.Equals(user_new.eq2) && s.eq2.Equals(user_new.eq1))))
                    return true;

            }
            return false;
        }

        private void check_input(String[] s)
        {
            if (s.Length != 6)
                throw new Exception("!!!not valude.");
        }

        private void Clr_bttn_Click(object sender, RoutedEventArgs e)
        {
            input_window.Clear();
            x_anw_window.Clear();
            y_anw_window.Clear();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            user_check_Query = from user in users_list
                               where user.name.Equals("Ali")
                               select user;
        }

        private void young_18_Checked(object sender, RoutedEventArgs e)
        {
            user_check_Query = from user in users_list
                               where int.Parse(user.age) < 18
                               select user;
        }

        private void name_hossein_check_Checked(object sender, RoutedEventArgs e)
        {
            user_check_Query = from user in users_list
                               where user.name.Equals("Hossein")
                               select user;
        }

        private void fadayi_lastName_check_Checked(object sender, RoutedEventArgs e)
        {
            user_check_Query = from user in users_list
                               where user.last_name.Equals("Fadayi")
                               select user;
        }

        private void yavari_lastName_check_Checked(object sender, RoutedEventArgs e)
        {
            user_check_Query = from user in users_list
                               where user.name.Equals("Yavari")
                               select user;
        }

        private void above_18_Checked(object sender, RoutedEventArgs e)
        {
            user_check_Query = from user in users_list
                               where int.Parse(user.age) > 18
                               select user;
        }

        private void above_50_Checked(object sender, RoutedEventArgs e)
        {
            user_check_Query = from user in users_list
                               where int.Parse(user.age) > 50
                               select user;
        }

        private void Mashhad_check_Checked(object sender, RoutedEventArgs e)
        {
            user_check_Query = from user in users_list
                               where user.city.Equals("Mashhad")
                               select user;
        }

        private void Tehran_check_Checked(object sender, RoutedEventArgs e)
        {
            user_check_Query = from user in users_list
                               where user.city.Equals("Tehran")
                               select user;
        }

        private void anw_15_20_check_Checked(object sender, RoutedEventArgs e)
        {
            user_check_Query = from user in users_list
                               where user.anw_x == 15 && user.anw_y == 20
                               select user;
        }

        private void eq1_check_Checked(object sender, RoutedEventArgs e)
        {
            user_check_Query = from user in users_list
                               where user.eq1.Equals("4x+5y=10") && user.eq2.Equals("4x+5y=10")
                               select user;
        }

        private void eq2_check_Checked(object sender, RoutedEventArgs e)
        {
            user_check_Query = from user in users_list
                               where user.eq1.Equals("15x+36y=80") && user.eq2.Equals("15x+36y=80")
                               select user;
        }

        private void filter_bttn_Click(object sender, RoutedEventArgs e)
        {
            foreach (User u in user_check_Query)
            {
                win_query.AppendText(u.name + "   " + u.last_name + "   " + u.eq1 + "   " + u.eq2 + "\n");
            }
        }

        private void clr_bttn_Click_1(object sender, RoutedEventArgs e)
        {
            win_query.Clear();
        }
    }

    class data
    {
        public void write_data(User u)
        {
            string path = @"../../../data.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("NAME**" + "     LAST_NAME**" + "        CITY**" + "     AGE**" + "   EQUATION_1**" + "  EQUATION_2**" + "\n" +
                                                  ".................................................................................................\n");
                }
            }
            File.AppendAllText("../../../data.txt", String.Format("{0,-10:N0} {1,-18:N0} {2,-10:N0} {3,-7:N0} {4,-13:N0} {5,-12:N0}\n",
                                                                                u.name, u.last_name, u.city, u.age, u.eq1, u.eq2));
        }
    }
}
