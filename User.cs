using System;
using System.Collections.Generic;
using System.Text;

namespace final
{
    class User
    {
        public String name, last_name, city;
        public int age;
        public String eq1, eq2;

        public int anw_x, anw_y;

        public User(String name, String last_name, String city, int age, String equation1, String equation2)
        {
            this.name = name;
            this.last_name = last_name;
            this.age = age;
            this.city = city;
            eq1 = equation1.Trim();
            eq2 = equation2.Trim();

            anw_x = solve_x();
            anw_y = solve_y();
        }

        public int a(String eq)
        {
            String[] tmp = eq.Split("x");
            return int.Parse(tmp[0]);
        }

        public int b(String eq)
        {
            String[] tmp = eq.Split("+")[1].Split("y");
            return int.Parse(tmp[0]);
        }

        public int c(String eq)
        {
            return int.Parse(eq.Split("=")[1]);
        }

        public int makhrag_kramer()
        {
            return a(eq1) * b(eq2) - b(eq1) * a(eq2);
        }

        public int solve_x()
        {
            anw_x = (c(eq1) * b(eq2) - b(eq1) * c(eq2)) / makhrag_kramer();
            return anw_x;
        }

        public int solve_y()
        {
            anw_y = (a(eq1) * c(eq2) - c(eq1) * a(eq2)) / makhrag_kramer();
            return anw_y;
        }
    }
}
