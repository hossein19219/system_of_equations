using System;
using System.Collections.Generic;
using System.Text;

namespace final
{
    class User
    {
        public String name, last_name, city, age;
        public String eq1, eq2;
        public int anw_x, anw_y;
        public User(String name, String last_name, String city, String age, String equation1, String equation2)
        {
            this.name = name;
            this.last_name = last_name;
            this.age = age;
            this.city = city;
            eq1 = equation1.Trim();
            eq2 = equation2.Trim();
        }
    }
}
