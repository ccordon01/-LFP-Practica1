using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_Lenguajes
{
    class Comando : AbstractAutomata
    {
        String palabra_concatenada = "";
        int linea = 0;
        int columna = 0;
        bool Reconocedor_errores = true;
        bool Reconocedor_entrada_salida = true;
        Errores error;
        ArrayList arreglo_errores = new ArrayList();
        ArrayList arreglo_tokens = new ArrayList();
        public Comando(int[] F, int[,] stateTable) : base(F, stateTable)
        {
        }

        public override int GetState(int s, char c, int col)
        {
            columna = col;
            if (col == 1)
            {
                arreglo_tokens.Clear();
                palabra_concatenada = "";
                Reconocedor_entrada_salida = true;
                Reconocedor_errores = true;
                error = null;
            }
            int n = Encoding.ASCII.GetBytes(c.ToString())[0];
            //Console.WriteLine(n);
            if ((n >= 65 && n <= 90) || (n >= 97 && n <= 122))
            {
                //Console.WriteLine(_stateTable[s, 0]);
                Concatenar(c);
                //if (_stateTable[s, 0] == -1)
                //{
                //    Console.WriteLine("Error Linea: " + linea + " Columna: " + columna + " Caracter: " + c);
                //    error = new Errores(linea.ToString(), columna.ToString(), c.ToString(), "Desconocido");
                //}
                return _stateTable[s, 0];
            }
            else if (n == 60)
            {
                //Console.WriteLine(_stateTable[s, 1]);
                //if (_stateTable[s, 1] == -1)
                //{
                //    Console.WriteLine("1Error Linea: " + linea + " Columna: " + columna + " Caracter: " + c);
                //    error = new Errores(linea.ToString(), columna.ToString(), c.ToString(), "Desconocido");
                //}
                arreglo_tokens.Add(c.ToString());
                return _stateTable[s, 1];
            }
            else if (n == 47)
            {
                //Console.WriteLine(_stateTable[s, 2]);
                //if (_stateTable[s, 2] == -1)
                //{
                //    Console.WriteLine("1Error Linea: " + linea + " Columna: " + columna + " Caracter: " + c);
                //    error = new Errores(linea.ToString(), columna.ToString(), c.ToString(), "Desconocido");
                //}
                arreglo_tokens.Add(c.ToString());
                Reconocedor_entrada_salida = false;
                return _stateTable[s, 2];
            }
            else if (n == 62)
            {
                //Console.WriteLine(_stateTable[s, 3]);
                //if (_stateTable[s, 3] == -1)
                //{
                //    Console.WriteLine("1Error Linea: " + linea + " Columna: " + columna + " Caracter: " + c);
                //    error = new Errores(linea.ToString(), columna.ToString(), c.ToString(), "Desconocido");
                //}
                arreglo_tokens.Add(c.ToString());
                return _stateTable[s, 3];
            }
            else if (n == 32 || n == 9 || n == 11)
            {
                //Console.WriteLine(_stateTable[s, 4]);
                //if (_stateTable[s, 4] == -1)
                //{
                //    Console.WriteLine("1Error Linea: " + linea + " Columna: " + columna + " Caracter: " + c);
                //    error = new Errores(linea.ToString(), columna.ToString(), c.ToString(), "Desconocido");
                //}
                return _stateTable[s, 4];
            }
            else
            {
                //Console.WriteLine(-1);
                if (Reconocedor_errores)
                {
                    ///Console.WriteLine("Error1 Linea: " + linea + " Columna: " + columna + " Caracter: " + c);
                    error = new Errores(linea.ToString(), columna.ToString(), c.ToString(), "Desconocido");
                    arreglo_errores.Add(error);
                }
                columna = 0;
                return _stateTable[s, 5];
            }

        }

        public void Concatenar(char c)
        {
            palabra_concatenada += c.ToString();
        }

        public override String Retornar_Palabra_Concatenada()
        {
            String temporal = palabra_concatenada;
            ///palabra_concatenada = "";
            columna = 0;
            return temporal;
        }

        public override bool RecognizeToken(string inputString, int line, bool erroes)
        {
            Reconocedor_errores = erroes;
            linea = line;
            return RecognizeBase(inputString);
        }

        public override int Retornar_Tipo_Etiqueta()
        {
            bool aux_reconocedor = Reconocedor_entrada_salida;
            ///Reconocedor_entrada_salida = true;
            if (aux_reconocedor)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

        public override ArrayList RetornarError()
        {
            //Console.WriteLine(arreglo_errores.Count);
            return arreglo_errores;
        }

        public override ArrayList RetornarToken()
        {
            //Console.WriteLine(arreglo_errores.Count);
            return arreglo_tokens;
        }
        
    }
}
