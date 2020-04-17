using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract class Liquidacion
    {
       
        public decimal BaseGrabable { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioVenta { get; set; }
        public int NumLiquidacion { get; set;  }
        public string TipoImpuesto { get; set; }

        public decimal ValorImpuestoConsumo { get; set; }
        public decimal ValorEspecifico { get; set; }
        public decimal ValorAdValorem { get; set; }

        public decimal TarifaAdValorem { get; set; }
        public decimal TarifaEspecifica { get; set; }

        public Liquidacion(Contribuyente contribuyente, decimal baseGrabable, int cantidad, decimal precioVenta, int numLiquidacion, string tipoImpuesto)
        {
            Contribuyente = contribuyente;
            BaseGrabable = baseGrabable;
            Cantidad = cantidad;
            PrecioVenta = precioVenta;
            NumLiquidacion = numLiquidacion;
            TipoImpuesto = tipoImpuesto;
        }
        public Contribuyente Contribuyente { get; set; }

        public abstract decimal CalcularTarifaEspecifica();
        public abstract decimal CalcularTarifaAdValorem();

        public Liquidacion()
        {
                
        }
        public void CalcularValorEspecifico()
        {
            TarifaEspecifica = CalcularTarifaEspecifica();
            ValorEspecifico =  BaseGrabable * TarifaEspecifica * Cantidad;
        }

        public void CalcularValorAdValorem()
        {
            TarifaAdValorem = CalcularTarifaAdValorem();
            ValorAdValorem = PrecioVenta * TarifaAdValorem * Cantidad;
        }

        public void CalcularValorImpuestoConsumo()
        {
            ValorImpuestoConsumo = ValorAdValorem + ValorEspecifico;
             
        }

        public override string ToString()
        {
            return $"{NumLiquidacion};{Contribuyente.NIT};{Contribuyente.RazonSocial};{BaseGrabable};{TipoImpuesto};" +
                $"{Cantidad};{PrecioVenta};{ValorEspecifico};{ValorAdValorem};{ValorImpuestoConsumo};{TarifaEspecifica};" +
                $"{TarifaAdValorem}";

            
        }
    }

    
}
