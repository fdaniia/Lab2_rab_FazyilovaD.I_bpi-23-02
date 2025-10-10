using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_rab_FazyilovaD.I_bpi_23_02
{
    public abstract class Base
    {
        public string ImagePath { get; set; }
        public abstract double Calculate ();
    }
}
