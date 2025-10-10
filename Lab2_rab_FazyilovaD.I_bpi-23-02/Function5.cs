using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_rab_FazyilovaD.I_bpi_23_02
{
    public class Function5 : Base
    {
        public int N { get; set; }
        public int K { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public Function5() { ImagePath = "5.png"; }
        public override double Calculate()
        {
            double sum = 0;
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= K; j++)
                {
                    sum += (Math.Cos(Math.Pow(Y, i)) + j * X) / (i * j);
                }
            }
            return sum;
        }
    }
}
