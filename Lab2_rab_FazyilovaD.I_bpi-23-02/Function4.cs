using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_rab_FazyilovaD.I_bpi_23_02
{
    public class Function4 : Base
    {
        public Function4() { ImagePath = "4.png"; }
        public override double Calculate(Parameters parameters)
        {
            double res = 1;
            for (int i =0; i<parameters.D; i++)
            {
                res = res * (parameters.C + parameters.A) + 1;
            }
            return res;
        }
    }
}
