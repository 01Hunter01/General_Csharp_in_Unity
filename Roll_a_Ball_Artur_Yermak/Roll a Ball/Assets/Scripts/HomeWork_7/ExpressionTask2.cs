using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7
{
    public static class ExpressionTask2
    {
        public static int CharCount(this string word)
        {

            int counter = 0;
            for (int i = 0; i < word.Length; i++)
            {
                counter++;
            }

            return counter;
        }

    }
}
