using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_Lenguajes
{
    class Errores
    {
        String fila;
        String columna;
        String caracter;
        String descripcion;
        public Errores(String fila_, String columna_, String caracter_, String descripcion_)
        {
            fila = fila_;
            columna = columna_;
            caracter = caracter_;
            descripcion = descripcion_;
        }

        public String Get_fila()
        {
            return fila;
        }

        public String Get_columna()
        {
            return columna;
        }

        public String Get_caracter()
        {
            return caracter;
        }

        public String Get_descripcion()
        {
            return descripcion;
        }
    }
}
