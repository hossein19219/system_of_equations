using System;
using System.Collections.Generic;
using System.Text;

namespace final
{
    class Equation
    {
        public String equation;
        public int a, b, c;

        public Equation(String eq)
        {
            equation = eq;
            fnd_a(eq);
            fnd_b(eq);
            fnd_c(eq);
        }

        public void fnd_a(String eq)
        {
            String[] tmp = eq.Split("x");
            a = int.Parse(tmp[0]);
        }

        public void fnd_b(String eq)
        {
            String[] tmp = eq.Split("+")[1].Split("y");
            b = int.Parse(tmp[0]);
        }

        public void fnd_c(String eq)
        {
            c = int.Parse(eq.Split("=")[1]);
        }
    }
}
