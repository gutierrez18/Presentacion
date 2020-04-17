using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Licores : Liquidacion
    {  
       
        public Licores(Contribuyente contribuyente, decimal baseGrabable, int cantidad, decimal precioVenta, int numLiquidacion): base(contribuyente,
            baseGrabable, cantidad, precioVenta, numLiquidacion, "Licores")
        {

        }

        public Licores()
        {

        }
        public override decimal CalcularTarifaAdValorem()
        {
            if (BaseGrabable < 31)
            {
                return 0.25M;
            }
            else
                return 0.3M;
        }

        public override decimal CalcularTarifaEspecifica()
        {
            if (BaseGrabable < 31)
            {
                return 220;
            }
            else
                return 250;
        }


    }
}
