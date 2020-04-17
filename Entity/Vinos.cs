using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Vinos : Liquidacion
    {
        public Vinos(Contribuyente contribuyente, decimal baseGrabable, int cantidad, decimal precioVenta, int numLiquidacion) : base(contribuyente,
            baseGrabable, cantidad, precioVenta, numLiquidacion, "Vinos")
        {

        }

        public Vinos()
        {

        }
        public override decimal CalcularTarifaAdValorem()
        {
           return 0.2M;
        }

        public override decimal CalcularTarifaEspecifica()
        {
            return 150;
        }
    }
}
