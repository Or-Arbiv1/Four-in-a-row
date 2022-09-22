using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class Chip
    {
        private readonly char r_Symbol;

        public Chip(char i_Symbol)
        {
            r_Symbol = i_Symbol;
        }

        public char Symbol
        {
            get
            {
                return r_Symbol;
            }
        }

        public override string ToString()
        {
            return "  " + r_Symbol + "  ";
        }
    }
}
