using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;
namespace BLL
{
    public class LiquidacionService
    {
        private LiquidacionRepository liquidacionRepository;

        public LiquidacionService()
        {
            liquidacionRepository = new LiquidacionRepository();
        }

        public string Guardar(Liquidacion liquidacion)

        {
            try
            {
                if (liquidacionRepository.Buscar(liquidacion.NumLiquidacion) == null)
                {
                    liquidacionRepository.Guardar(liquidacion);
                    return $"Los Datos han sido registrados satisfactoriamente";
                }
                return $"La Liquidacion con el numero: {liquidacion.NumLiquidacion}, ya se encuentra registrada.";

            }
            catch (Exception e)
            {

                return $"Error en los datos, " + e.Message;
            }


        }

        public List<Liquidacion> Consulatar()
        {
            return liquidacionRepository.Consultar();
        }

        public string Modificar(Liquidacion liquidacion)
        {
            try
            {
                if (liquidacionRepository.Buscar(liquidacion.NumLiquidacion) != null)
                {
                    liquidacionRepository.Modificar(liquidacion);
                    return $"La Liquidacion con numero {liquidacion.NumLiquidacion}, ha sido modificada satisfactoriamente!";

                }

                return $"La Liquidacion con numero {liquidacion.NumLiquidacion} NO se encunetra registrada, favor verificar los datos!";

            }
            catch (Exception e)
            {

                return "Error en los datos " + e.Message;
            }
        }

        public string Eliminar(int numero)
        {
            try
            {
                if (liquidacionRepository.Buscar(numero) != null)
                {
                    liquidacionRepository.Eliminar(numero);
                    return $"La Liquidacion con numero {numero}, ha sido Eliminada correctamente!";

                }

                return $"La Liquidacion con numero {numero} NO se encunetra registrada, favor verificar los datos!";

            }
            catch (Exception e)
            {

                return "Error en los datos " + e.Message;
            }

        }

      

        public Liquidacion Buscar(int numero)
        {
            return liquidacionRepository.Buscar(numero);
        }

    }
}
