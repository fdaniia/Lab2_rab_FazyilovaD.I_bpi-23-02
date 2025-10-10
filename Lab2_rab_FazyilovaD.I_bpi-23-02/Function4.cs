using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_rab_FazyilovaD.I_bpi_23_02
{
    public class Function4 : Base
    {
        public double C { get; set; }
        public double A { get; set; }
        public int D { get; set; }
        public Function4() { ImagePath = "4.png"; }
        public override double Calculate()
        {
            double res = 1;
            for (int i =0; i< D; i++)
            {
                res = res * (C + A) + 1;
            }
            return res;
        }
    }
}
