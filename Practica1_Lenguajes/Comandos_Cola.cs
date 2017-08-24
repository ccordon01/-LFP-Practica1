using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_Lenguajes
{
    class Comandos_Cola
    {
        String tipo;
        String accion;
        String nombre;
        String texto;
        String ruta;

        public Comandos_Cola(String n1, String n2, String n3, String n4, String n5)
        {
            tipo = n1;
            accion = n2;
            nombre = n3;
            texto = n4;
            ruta = n5;
        }

        public String Get_tipo()
        {
            return tipo;
        }

        public String Get_accion()
        {
            return accion;
        }

        public String Get_nombre()
        {
            return nombre;
        }

        public String Get_texto()
        {
            return texto;
        }

        public String Get_ruta()
        {
            return ruta;
        }
    }
}
