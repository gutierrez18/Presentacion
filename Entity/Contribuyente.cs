using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Contribuyente
    {
        public string RazonSocial { get; set; }

        public  int  NIT { get; set; }
        public Contribuyente(string razonsocial , int nit )
        {
            RazonSocial = razonsocial;
            NIT = nit;
        }

        public Contribuyente()
        {

        }
    }
}
