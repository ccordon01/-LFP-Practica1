using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_Lenguajes
{
    class Tokens
    {
        String lexema;
        int id;
        String token;
        Tokens[,] tokens;
        public Tokens() {

        }

        public Tokens(String lex, int i, String tok) {
            lexema = lex;
            id = i;
            token = tok;
        }

        public Tokens[,] Lista_Tokens() {
            tokens = new Tokens[,] { { new Tokens("<", 1, "simboloMenor")},{ new Tokens("/", 2, "simboloCierreEtiqueta") }, { new Tokens(">", 3, "simboloMayor") }, { new Tokens("lfscript", 4, "reservadaLfscript") }, { new Tokens("comando", 5, "reservadaComando") }, { new Tokens("tipo", 6, "reservadaTipo") }, { new Tokens("accion", 7, "reservadaAccion") }, { new Tokens("nombre", 8, "reservadaNombre") }, { new Tokens("texto", 9, "reservadaTexto") }, { new Tokens("ruta", 10, "reservadaRuta") } }; 
            return tokens;
        }

        public String get_lexema() {
            return lexema;
        }
        public int get_id()
        {
            return id;
        }
        public String get_token()
        {
            return token;
        }
    }
}
