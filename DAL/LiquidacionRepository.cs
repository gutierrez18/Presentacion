using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;
namespace BLL
{
    public class LiquidacionRepository
    {
        private string ruta = @"Liquidacion.txt";
        private List<Liquidacion> liquidaciones;

        public LiquidacionRepository()
        {
            liquidaciones = new List<Liquidacion>();
        }

        public void Guardar(Liquidacion liquidacion)
        {
            FileStream archivo = new FileStream(ruta, FileMode.Append);
            StreamWriter escribir = new StreamWriter(archivo);
            escribir.WriteLine(liquidacion.ToString());

            escribir.Close();
            archivo.Close();
        }

        public List<Liquidacion> Consultar()
        {
            liquidaciones.Clear();

            FileStream archivo = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader leer = new StreamReader(archivo);
            string linea = string.Empty;

            while ((linea = leer.ReadLine()) != null)
            {
                Liquidacion l = MapearLiquidacion(linea);
                liquidaciones.Add(l);

            }

            leer.Close();
            archivo.Close();


            return liquidaciones;
        }

        private Liquidacion MapearLiquidacion(string linea)
        {
            Liquidacion liquidacion = null;
            string[] datos = linea.Split(';');
            Contribuyente contribuyente = new Contribuyente(datos[2], int.Parse(datos[1]));


            if (datos[4].Equals("Licores"))
            {
                Licores licores = new Licores();
                liquidacion = licores;
            }
            else
            {
                Vinos vinos = new Vinos();
                liquidacion = vinos;
            }

            liquidacion.Contribuyente = contribuyente;
            liquidacion.BaseGrabable = decimal.Parse(datos[3]);
            liquidacion.Cantidad = int.Parse(datos[5]);
            liquidacion.NumLiquidacion = int.Parse(datos[0]);
            liquidacion.PrecioVenta = decimal.Parse(datos[6]);
            liquidacion.TipoImpuesto = datos[4];
            liquidacion.ValorEspecifico= decimal.Parse(datos[7]);
            liquidacion.ValorAdValorem= decimal.Parse(datos[8]);
            liquidacion.ValorImpuestoConsumo= decimal.Parse(datos[9]);
            liquidacion.TarifaEspecifica = decimal.Parse(datos[10]);
            liquidacion.TarifaAdValorem = decimal.Parse(datos[11]);

            

            return liquidacion;
        }

        public void Modificar(Liquidacion liquidacion)
        {
            liquidaciones.Clear();

            liquidaciones = Consultar();

            FileStream archivo = new FileStream(ruta, FileMode.Create);
            archivo.Close();

            foreach (var item in liquidaciones)
            {
                if (liquidacion.NumLiquidacion == item.NumLiquidacion)
                {
                    Guardar(liquidacion);
                }
                else
                    Guardar(item);
            }
        }
    

        public void Eliminar(int numero)
        {
            liquidaciones.Clear();
            liquidaciones = Consultar();

            FileStream archivo = new FileStream(ruta, FileMode.Create);
            archivo.Close();

            foreach (var item in liquidaciones)
            {
                if (item.NumLiquidacion != numero)
                {
                    Guardar(item);
                }
            }

        }
        public Liquidacion Buscar(int numero)
        {
            liquidaciones.Clear();
            liquidaciones = Consultar();

            foreach (var item in liquidaciones)
            {
                if (numero == item.NumLiquidacion)
                    return item;
            }
            return null;
        }

    }
}
