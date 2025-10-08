using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_rab_FazyilovaD.I_bpi_23_02
{
    public class Function3 : Base
    {
        public Function3() { ImagePath = "3.png"; }
        public override double Calculate(Parameters parameters)
        {
            return parameters.C * parameters.A * parameters.A + parameters.D *parameters.B * parameters.B;
        }
    }
}
