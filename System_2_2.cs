using System;
using System.Collections.Generic;
using System.Text;

namespace final
{
    class System_2_2
    {
        public Equation eq1, eq2;
        public int anw_x, anw_y;
        public System_2_2(Equation equation1, Equation equation2)
        {
            eq1 = equation1;
            eq2 = equation2;
            check_aswer();
        }


        public int makhrag_kramer()
        {
            int reslt = eq1.a * eq2.b - eq1.b * eq2.a;
            return reslt;
        }

        public int solve_x()
        {
            anw_x = (eq1.c * eq2.b - eq1.b * eq2.c) / makhrag_kramer();
            return anw_x;
        }

        public int solve_y()
        {
            anw_y = (eq1.a * eq2.c - eq1.c * eq2.a) / makhrag_kramer();
            return anw_y;
        }

        public void check_aswer()
        {
            int A = (eq1.a * 100 / eq2.a);
            int B = (eq1.b * 100 / eq2.b);
            int C = (eq1.c * 100 / eq2.c);

            if (A == B)
            {
                if (A == C)
                    throw new Exception("!!!Infinite answer...");
                else
                    throw new Exception("!!!No answer.");
            }
        }
    }
}
