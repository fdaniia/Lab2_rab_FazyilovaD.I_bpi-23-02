using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_rab_FazyilovaD.I_bpi_23_02
{
    public class Function1 : Base
    {
        public double F { get; set; }
        public double A { get; set; }
        public Function1() { ImagePath = "1.png"; }
        public override double Calculate()
        {
            return Math.Sin(F * A);
        }      
    }
}
