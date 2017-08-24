using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_Lenguajes
{
    class Validador_Etiquetas
    {
        String EtiquetaEntrada;
        int LineaEntrada;
        String EtiquetaSalida;
        int LineaSalida;

        public Validador_Etiquetas(String ee, int le, String es, int ls)
        {
            EtiquetaEntrada = ee;
            LineaEntrada = le;
            EtiquetaSalida = es;
            LineaSalida = ls;
        }

        public String Get_Etiqueta_Entrada()
        {
            return EtiquetaEntrada;
        }

        public void Set_Etiqueta_Entrada(String inputString)
        {
            EtiquetaEntrada = inputString;
        }

        public String Get_Etiqueta_Salida()
        {
            return EtiquetaSalida;
        }

        public void Set_Etiqueta_Salida(String inputString)
        {
            EtiquetaSalida = inputString;
        }

        public int Get_Linea_Entrada()
        {
            return LineaEntrada;
        }

        public void Set_Linea_Entrada(int inputInt)
        {
            LineaEntrada = inputInt;
        }

        public int Get_Linea_Salida()
        {
            return LineaSalida;
        }

        public void Set_Linea_Salida(int inputInt)
        {
            LineaSalida = inputInt;
        }
    }
}
