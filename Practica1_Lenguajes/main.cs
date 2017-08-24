using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_Lenguajes
{
    class main
    {
        static void Main(string[] args)
        {
            String ruta = "";
            Practica1 p1 = null;
            Console.WriteLine("                                   Practica #1 - Lenguajes");
            do
            {
                Console.WriteLine("");
                Console.WriteLine("                 1. Leer Script");
                Console.WriteLine("                 2. Crear Archivos De Salida");
                Console.WriteLine("                 3. Salir");
                Console.WriteLine("");
                Console.Write(" Seleccione una opcion: ");
                String entrada = Console.ReadLine().ToString();
                switch (entrada)
                {
                    case "1":
                        Console.WriteLine(" Ingrese ruta de script");
                        ruta = Console.ReadLine();
                        if (ruta.EndsWith(".lfp"))
                        {
                            try
                            {
                                p1 = new Practica1(ruta);
                            }
                            catch
                            {

                            }
                        }
                        else {
                            Console.WriteLine(" archivo incorrecto");
                        }
                        break;
                    case "2":
                        if (p1 != null)
                        {
                            CrearHtml crear = new CrearHtml(p1.Return_array(),p1.Return_array_Tokens());
                            crear.crearAll();
                            //for (int i = 0; i < p1.Return_array().Count; i++)
                            //{
                            //    Errores error = (Errores)p1.Return_array()[i];
                            //    Console.WriteLine("Linea: " + error.Get_fila() + " Columna: " + error.Get_columna() + " Caracter: " + error.Get_caracter() + " Descripcion: " + error.Get_descripcion());
                            //}
                        }
                        else
                        {
                            Console.WriteLine("Primero cargue un archivo al programa");
                        }
                        break;
                    case "3":
                        System.Environment.Exit(-1);
                        break;
                    default:
                        Console.WriteLine("Opcion de manu no valida");
                        break;
                }
                Console.WriteLine("     Si deseas repetir el menu ingresa si");
            } while (Console.ReadLine() == "si");
            ///
        }
    }
}
