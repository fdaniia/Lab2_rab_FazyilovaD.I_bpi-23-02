using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_rab_FazyilovaD.I_bpi_23_02
{
    public class Function1 : Base
    {
        public Function1() { ImagePath = "1.png"; }
        public override double Calculate(Parameters parameters)
        {
            return Math.Sin(parameters.F * parameters.A);
        }      
    }
}
