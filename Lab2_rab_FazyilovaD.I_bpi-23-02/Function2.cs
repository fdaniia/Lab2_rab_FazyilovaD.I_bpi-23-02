using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_rab_FazyilovaD.I_bpi_23_02
{
    public class Function2 : Base
    {
        public Function2() { ImagePath = "2.png"; }
        public override double Calculate(Parameters parameters)
        {
            return Math.Cos(parameters.F * parameters.A) + Math.Sin(parameters.F * parameters.B);
        }
    }
}
