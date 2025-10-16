using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_rab_FazyilovaD.I_bpi_23_02
{
    public class Function3 : Base
    {
        public double A { get; set; }
        public int C { get; set; }
        public int D { get; set; }
        public double B { get; set; }
        public Function3() { ImagePath = "3.png"; }
        public override double Calculate()
        {
            return C * A * A + D * B * B;
        }
    }
}
