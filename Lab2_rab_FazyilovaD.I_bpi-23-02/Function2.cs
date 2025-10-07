using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_rab_FazyilovaD.I_bpi_23_02
{
    public class Function2 : Base
    {
        public double A { get; set; }
        public double B { get; set; }
        public double F { get; set; }
        public Function2() { ImagePath = "2.png"; }
        public override double Calculate()
        {
            return Math.Cos(F * A) + Math.Sin(F * B);
        }
    }
}
