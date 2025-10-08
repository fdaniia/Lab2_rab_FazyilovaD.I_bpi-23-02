using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_rab_FazyilovaD.I_bpi_23_02
{
    public class Function5 : Base
    {
        public Function5() { ImagePath = "5.png"; }
        public override double Calculate(Parameters parameters)
        {
            double sum = 0;
            for (int i = 1; i <= parameters.N; i++)
            {
                for (int j = 1; j <= parameters.K; j++)
                {
                    sum += (Math.Cos(Math.Pow(parameters.Y, i)) + j * parameters.X) / (i * j);
                }
            }
            return sum;
        }
    }
}
