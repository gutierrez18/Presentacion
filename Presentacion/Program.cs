using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Entity;
namespace Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {
            LiquidacionService liquidacionService = new LiquidacionService();

            int opcion;
            do
            {
                Console.Clear();
                opcion = Menu();
                switch (opcion)
                {
                    case 1:
                        {
                            RegistrarLiquidacion(liquidacionService); break;
                        }
                    case 2:
                        {
                            MostrarLiquidaciones(liquidacionService); break;

                        }
                   
                    case 3:
                        {
                            Console.WriteLine("Fin de la aplicacion"); break;
                        }

                }

                Console.Write("Oprima ENTER para continuar....");
                Console.ReadKey();

            } while (opcion != 3);


        }



        public static void RegistrarLiquidacion(LiquidacionService liquidacionService)
        {
            Liquidacion liquidacion;
            decimal baseGrabable,precioVenta;
            string tipoImpuesto, razonSocial;
            int cantidad, numLiquidacion, nit;
            

            Console.WriteLine("--\tREGISTRAR CONTRIBUYENTE---\n");


           
            Console.Write("Digite Nombre la razon Social del contribuyente: ");
            razonSocial = Console.ReadLine();

            Console.Write("Digite el Nit del contribuyente: ");
            nit = int.Parse(Console.ReadLine());
            Console.Write("\nA. LICORES APERITIVOS Y SIMILARES \nB. VINOS Y APERITIVOS VINICOS \n\n=>: ");
            ConsoleKeyInfo opcion = Console.ReadKey();
            Console.Clear();
            Console.Write("Digite el precio del producto: ");
            precioVenta = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Digite el Numero de liquidacion: ");
            numLiquidacion = int.Parse(Console.ReadLine());
            Console.Write("Digite la base gravable del preducto(grados de alcohol): ");
            baseGrabable = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Digite la cantidad de productos: ");
            cantidad = int.Parse(Console.ReadLine());
            Contribuyente contribuyente = new Contribuyente(razonSocial, nit);

            if (opcion.KeyChar == 'A' || opcion.KeyChar == 'a')
            {

                Licores licores = new Licores(contribuyente,baseGrabable, cantidad, precioVenta, numLiquidacion);
                liquidacion = licores;

            }
            else
            {
                Vinos vinos = new Vinos(contribuyente, baseGrabable, cantidad, precioVenta, numLiquidacion);
                liquidacion = vinos;
            }
            liquidacion.CalcularValorEspecifico();
            liquidacion.CalcularValorAdValorem();
            liquidacion.CalcularValorImpuestoConsumo();

            
            Console.WriteLine("\n" + liquidacionService.Guardar(liquidacion));


        }

        public static void MostrarLiquidaciones(LiquidacionService liquidacionService)
        {
            try
            {
                if (liquidacionService.Consulatar().Count() != 0)
                {
                    Console.WriteLine("\n\t---Lista de liquidaciones---\n");

                    foreach (var item in liquidacionService.Consulatar())
                    {
                        MostrarLiquidacion(item);

                    }
                }
                else Console.WriteLine("No se encontraron registros!");


            }
            catch (Exception e)
            {

                Console.WriteLine("Error!. Archivo no encontrado y/o no existe!" + e.Message);
            }
        }

        public static void MostrarLiquidacion(Liquidacion liquidacion)
        {
            Console.WriteLine($"Razon Social: {liquidacion.Contribuyente.RazonSocial}");
            Console.WriteLine($"NIT: {liquidacion.Contribuyente.NIT}");
            Console.WriteLine($"Cantidad: {liquidacion.Cantidad}");
            Console.WriteLine($"Precio: {liquidacion.PrecioVenta}");
            Console.WriteLine($"Numero de liquidacion: {liquidacion.NumLiquidacion}");
            Console.WriteLine($"Tipo Impuesto: {liquidacion.TipoImpuesto}");
            Console.WriteLine($"Base gravable: {liquidacion.BaseGrabable}");
            Console.WriteLine($"Tarifa espesifica: {liquidacion.TarifaEspecifica}");
            Console.WriteLine($"Valor componente especifico : {liquidacion.ValorEspecifico}");
            Console.WriteLine($"Tarifa Valorem : {liquidacion.TarifaAdValorem}");
            Console.WriteLine($"Valor componente Ad Valorem : {liquidacion.ValorAdValorem}");
            Console.WriteLine($"Valor impuesto consumo : {liquidacion.ValorImpuestoConsumo}");


            Console.WriteLine();
        }

       

        public static int Menu()
        {
            int opcion;
            string[] opciones =
            {
                "\n\t\t *** LICORES Y VINOS ***\n",
                "\t1. Registrar",
                "\t2. Consultar",
                "\t3. Salir\n",

            };

            foreach (var item in opciones)
            {
                Console.WriteLine(item);
            }
            try
            {
                do
                {
                    Console.Write("=>: ");
                    opcion = Convert.ToInt32(Console.ReadLine());
                } while (opcion < 1 || opcion > 3);
                return opcion;

            }
            catch (Exception e)
            {

                Console.WriteLine("Se debe digitar solo numeros! " + e.Message);
            }


            return 0;
        }

    }
}
