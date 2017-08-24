using System;
using System.Collections;

namespace Practica1_Lenguajes
{
    abstract class AbstractAutomata
    {
        protected int _s;
        protected int[] _f;
        protected int[,] _stateTable;
        public AbstractAutomata(int[] F, int[,] stateTable)
        {
            _s = 0;
            _f = F;
            _stateTable = stateTable;
        }

        public abstract int GetState(int s, char c, int col);

        public abstract bool RecognizeToken(string inputString, int line, bool erroes);

        public abstract String Retornar_Palabra_Concatenada();

        public abstract ArrayList RetornarError();
        public abstract ArrayList RetornarToken();

        public abstract int Retornar_Tipo_Etiqueta();
        /// Algoritmo Base De un automata
        protected bool RecognizeBase(string inputString)
        {
            try
            {
                int n = 0;
                char c = inputString[n++];
                int aux_s = 0;
                while (n <= inputString.Length)
                {
                    _s = GetState(_s, c, n);
                    ///if (_s != -1 && n < inputString.Length)
                    if (n < inputString.Length)
                    {
                        if (_s == -1)
                        {
                            _s = aux_s;
                        }
                        c = inputString[n++];
                        aux_s = _s;
                    }
                    else
                    {
                        break;
                    }
                }
                for (int i = 0; i < _f.Length; i++)
                    if (_f[i] == _s)
                    {
                        _s = 0;
                        return true;
                    }
                _s = 0;
                return false;
            }
            catch
            {
                return false;
            }
        }

    }
}