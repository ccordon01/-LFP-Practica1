using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_Lenguajes
{
    class Practica1
    {
        static ArrayList arreglo_etiquetas = new ArrayList();
        static ArrayList arreglo_errores_ = new ArrayList();
        static ArrayList arreglo_tokens_ = new ArrayList();
        static ArrayList arreglo_errores_linea = new ArrayList();
        static ArrayList arreglo_errores_comando = new ArrayList();
        static ArrayList prueba, Cola;
        Tokens lista = new Tokens();
        static int[] F_Linea = new int[] { 5 };
        static int[,] Tabla_Linea = new int[,] { { -1, 1, -1, -1, 0, -1 }, { 1, -1, -1, 2, 1, -1 }, { 2, 3, -1, -1, 2, 2 }, { -1, -1, 4, -1, 3, -1 }, { 4, -1, -1, 5, 4, -1 }, { -1, -1, -1, -1, 5, -1 } };
        ///_automatas.Add(new Digito(F_Digito,Tabla_Digito));

        public Practica1(String ruta)
        {
            ///Comando
            int[] F_Comando = new int[] { 4 };
            int[,] Tabla_Comando = new int[,] { { -1, 1, -1, -1, 0, -1 }, { 2, -1, -1, 4, 2, -1 }, { 2, -1, -1, 4, 2, -1 }, { 3, -1, -1, 4, 3, -1 }, { -1, -1, -1, -1, 4, -1 } };
            AbstractAutomata automata1 = new Comando(F_Comando, Tabla_Comando);
            Lector arreglo = new Lector();
            int linea = 0;
            prueba = arreglo.Arreglo_de_archivo(ruta);
            AbstractAutomata automata2 = new Linea(F_Linea, Tabla_Linea);
            foreach (string sOutput in prueba)
            {
                ///Console.WriteLine(sOutput);
                linea++;
                bool valida1_linea = automata2.RecognizeToken(sOutput, linea, false);
                if (!valida1_linea)
                {
                    bool valida1 = automata1.RecognizeToken(sOutput, linea, true);
                    if (valida1)
                    {
                        ///Console.WriteLine("Cadena Valida");
                        ///Console.WriteLine("Comando encontrado: " + automata1.Retornar_Palabra_Concatenada() + " Tipo: "+ automata1.Retornar_Tipo_Etiqueta());
                        ArrayList aux = automata1.RetornarToken();
                        EtiquetasAdd(automata1.Retornar_Palabra_Concatenada(), automata1.Retornar_Tipo_Etiqueta(), linea);
                        aux.Add(automata1.Retornar_Palabra_Concatenada());
                        TokensAdd(aux);
                        //for (int i = 0; i < aux.Count; i++)
                        //{
                        //    for (int j = 0; j < 10; j++)
                        //    {
                        //        Tokens[,] aux_token = lista.Lista_Tokens();
                        //        if (aux[i].ToString() == aux_token[0, j].get_lexema())
                        //        {
                        //            arreglo_tokens_.Add(aux_token[0, j]);
                        //        }
                        //    }
                        //}
                        /*if (automata1.Retornar_Palabra_Concatenada().Equals("lfscript")) {
                            Console.WriteLine("Si");
                            ///break;
                        }*/
                    }
                    else
                    {
                        ///Console.WriteLine("Cadena Invalida");
                        //if (automata1.RetornarError() != null) {
                        //    arreglo_errores.Add(automata1.RetornarError());
                        //}
                        //Console.WriteLine("Comando " + arreglo_errores.Count);
                    }
                }
            }
            concatenar_array(automata1.RetornarError());
            arreglo_errores_comando = automata1.RetornarError();
            ///mostrararreglo();
            validador_comandos();
            Lets_do_this();
            ///Console.ReadLine();
        }

        private void TokensAdd(ArrayList aux)
        {
            //Console.WriteLine(aux.Count);
            for (int i = 0; i < aux.Count; i++)
            {
                  arreglo_tokens_.Add(aux[i]);
            }
        }

        private static void concatenar_array(ArrayList arrayList)
        {
            for (int i = 0; i < arrayList.Count; i++)
            {
                arreglo_errores_.Add(arrayList[i]);
            }
        }

        public void Lets_do_this()
        {
            if (Cola.Count != 0 && arreglo_errores_.Count == 0 && check_etiquetas())
            {
                for (int i = 0; i < Cola.Count; i++)
                {
                    Comandos_Cola cola_sub = (Comandos_Cola)Cola[i];
                    ///Console.WriteLine(cola_sub.Get_tipo());
                    switch (cola_sub.Get_tipo())
                    {
                        case "carpeta":
                            string folderName = cola_sub.Get_ruta();
                            string pathString = System.IO.Path.Combine(folderName, cola_sub.Get_nombre());
                            switch (cola_sub.Get_accion())
                            {
                                case "crear":
                                    System.IO.Directory.CreateDirectory(pathString);
                                    break;
                                case "eliminar":
                                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(pathString);
                                    // Delete this dir and all subdirs.
                                    try
                                    {
                                        di.Delete(true);
                                    }
                                    catch (System.IO.IOException e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    break;
                            }
                            break;
                        case "archivo":
                            string fileName = cola_sub.Get_nombre() + ".txt";
                            String path = cola_sub.Get_ruta();
                            string pathStrings = System.IO.Path.Combine(path, fileName);
                            switch (cola_sub.Get_accion())
                            {
                                case "crear":
                                    if (!System.IO.File.Exists(pathStrings))
                                    {
                                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(pathStrings))
                                        {
                                            file.WriteLine(cola_sub.Get_texto());
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("File \"{0}\" already exists.", fileName);
                                    }
                                    break;
                                case "modificar":
                                    if (System.IO.File.Exists(pathStrings))
                                    {
                                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(pathStrings))
                                        {
                                            file.WriteLine(cola_sub.Get_texto());
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("File \"{0}\" no exists.", fileName);
                                    }
                                    break;
                                case "eliminar":
                                    System.IO.FileInfo fi = new System.IO.FileInfo(pathStrings);
                                    // Delete this dir and all subdirs.
                                    try
                                    {
                                        fi.Delete();
                                    }
                                    catch (System.IO.IOException e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    break;
                            }

                            break;
                        case "especial":
                            DateTime localDate = DateTime.Now;
                            string fileName_e = cola_sub.Get_nombre() + ".txt";
                            String path_e = cola_sub.Get_ruta();
                            string pathStrings_e = System.IO.Path.Combine(path_e, fileName_e);
                            switch (cola_sub.Get_accion())
                            {
                                case "nuevo-nombre-shell":
                                    Console.Title = cola_sub.Get_nombre();
                                    break;
                                case "obtener-fecha":
                                    if (!System.IO.File.Exists(pathStrings_e))
                                    {
                                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(pathStrings_e))
                                        {
                                            file.WriteLine(localDate.Day + "/" + localDate.Month + "/" + localDate.Year);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("File \"{0}\" already exists.", fileName_e);
                                    }
                                    break;
                                case "obtener-hora":
                                    if (!System.IO.File.Exists(pathStrings_e))
                                    {
                                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(pathStrings_e))
                                        {
                                            file.WriteLine(localDate.Hour + ":" + localDate.Minute + ":" + localDate.Second);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("File \"{0}\" already exists.", fileName_e);
                                    }
                                    break;
                            }

                            break;
                    }
                }
                Console.WriteLine("Tarea completada exitosamente");
            }
            else
            {
                Console.WriteLine("Tarea no completada");
            }
        }

        private bool check_etiquetas()
        {
            int size_array = arreglo_etiquetas.Count;
            for (int i = 0; i < size_array; i++)
            {
                Validador_Etiquetas ve = (Validador_Etiquetas)arreglo_etiquetas[i];
                ///Console.WriteLine(ve.Get_Etiqueta_Entrada() + "!=" + ve.Get_Etiqueta_Salida());
                if (ve.Get_Etiqueta_Entrada() != ve.Get_Etiqueta_Salida()) {
                    return false;
                }
            }
            return true;
        }

        public ArrayList Return_array()
        {
            return arreglo_errores_;
        }

        public ArrayList Return_array_Tokens()
        {
            return arreglo_tokens_;
        }

        private void validador_comandos()
        {
            ///Linea

            Cola = new ArrayList();
            String tipo = "";
            String accion = "";
            String nombre = "";
            String texto = "";
            String ruta = "";
            if (arreglo_etiquetas.Count != 0)
            {
                int size_array = arreglo_etiquetas.Count;
                AbstractAutomata automata3 = new Linea(F_Linea, Tabla_Linea);
                for (int i = 1; i < size_array; i++)
                {
                    Validador_Etiquetas ve = (Validador_Etiquetas)arreglo_etiquetas[i];
                    for (int j = ve.Get_Linea_Entrada(); j < ve.Get_Linea_Salida(); j++)
                    {
                        bool valida1 = automata3.RecognizeToken(prueba[j].ToString(), j, true);
                        if (valida1)
                        {
                            ///Console.WriteLine("Cadena Valida");
                            //Console.WriteLine("Comando encontrado: " + automata3.Retornar_Palabra_Concatenada());
                            String value = automata3.Retornar_Palabra_Concatenada();
                            Char[] delimiter = { Convert.ToChar(34), '&' };
                            String[] substrings = value.Split(delimiter);
                            ArrayList array_sub1 = new ArrayList();
                            foreach (var substring in substrings)
                            {
                                if (substring != "")
                                {
                                    ///Console.WriteLine(substring);
                                    array_sub1.Add(substring);
                                }
                            }
                            //Console.WriteLine(array_sub1[0].ToString()+"=="+array_sub1[2].ToString());
                            if (array_sub1[0].ToString() == array_sub1[2].ToString())
                            {
                                switch (array_sub1[0].ToString())
                                {
                                    case "tipo":
                                        tipo = array_sub1[1].ToString();
                                        break;
                                    case "accion":
                                        accion = array_sub1[1].ToString();
                                        break;
                                    case "nombre":
                                        nombre = array_sub1[1].ToString();
                                        break;
                                    case "texto":
                                        texto = array_sub1[1].ToString();
                                        if (texto == null)
                                        {
                                            texto = "";
                                        }
                                        break;
                                    case "ruta":
                                        ruta = array_sub1[1].ToString();
                                        break;
                                }
                                ArrayList aux = automata3.RetornarToken();
                                aux.Add(automata3.Retornar_Palabra_Concatenada());
                                TokensAdd(aux);
                            }
                            else
                            {
                                Console.WriteLine("aalgo anda mal");
                            }

                        }
                        else
                        {
                            ///Console.WriteLine(automata3.Retornar_Palabra_Concatenada());
                            String value = automata3.Retornar_Palabra_Concatenada();
                            Char[] delimiter = { Convert.ToChar(34), '&' };
                            String[] substrings = value.Split(delimiter);
                            ArrayList array_sub1 = new ArrayList();
                            foreach (var substring in substrings)
                            {
                                if (substring != "")
                                {
                                    ///Console.WriteLine(substring);
                                    array_sub1.Add(substring);
                                }
                            }
                            try
                            {
                                ///Console.WriteLine(array_sub1.Count);
                                if (array_sub1.Count >= 1 && array_sub1.Count < 3)
                                {
                                    if (array_sub1[0].ToString() == "comando" || array_sub1[array_sub1.Count - 1].ToString() == "lfscript")
                                    {

                                    }
                                    else
                                    {
                                        //Console.WriteLine("Error");
                                        ArrayList e = new ArrayList();
                                        e.Add(new Errores("", "", array_sub1[array_sub1.Count - 1].ToString(), "Cadena no valida"));
                                        concatenar_array(e);
                                    }
                                }
                            }
                            catch {
                            }
                        }
                    }
                    Cola.Add(new Comandos_Cola(tipo, accion, nombre, texto, ruta));
                }
                concatenar_array(automata3.RetornarError());
                arreglo_errores_linea.Add(automata3.RetornarError());
            }
            else
            {
                Console.WriteLine("Arreglo vacio");
            }
        }

        private static void mostrararreglo()
        {
            if (arreglo_etiquetas.Count != 0)
            {


                int size_array = arreglo_etiquetas.Count;
                for (int i = 0; i < size_array; i++)
                {
                    Validador_Etiquetas ve = (Validador_Etiquetas)arreglo_etiquetas[i];
                    Console.WriteLine("Etiqueta Entrada: "+ve.Get_Etiqueta_Entrada()+" Linea Etiqueta Entrada: " + ve.Get_Linea_Entrada()+ " Etiqueta Salida: " + ve.Get_Etiqueta_Salida() + " Linea Etiqueta Salida: " + ve.Get_Linea_Salida());
                }
            }
            else
            {
                Console.WriteLine("Arreglo vacio");
            }
        }

        public static void EtiquetasAdd(string v1, int v2, int linea)
        {
            if (arreglo_etiquetas.Count != 0)
            {
                if (v2 == 1)
                {
                    arreglo_etiquetas.Add(new Validador_Etiquetas(v1, linea, null, 0));
                }
                else if (v2 == 0)
                {
                    int state = 0;
                    int size_array = arreglo_etiquetas.Count;
                    for (int i = 0; i < size_array; i++)
                    {
                        if (v2 == 0)
                        {
                            Validador_Etiquetas ve = (Validador_Etiquetas)arreglo_etiquetas[i];
                            if (ve.Get_Etiqueta_Entrada() == v1 && ve.Get_Etiqueta_Salida() == null)
                            {
                                ve.Set_Etiqueta_Salida(v1);
                                ve.Set_Linea_Salida(linea);
                                state = 1;
                                break;
                            }
                        }
                    }
                    if (state == 0) {
                        arreglo_etiquetas.Add(new Validador_Etiquetas(null, 0, v1, linea));
                    }
                }
            }
            else
            {
                if (v2 == 1)
                {
                    arreglo_etiquetas.Add(new Validador_Etiquetas(v1, linea, null, 0));
                }
                else if (v2 == 0)
                {
                    arreglo_etiquetas.Add(new Validador_Etiquetas(null, 0, v1, linea));
                }
            }
        }
    }
}
