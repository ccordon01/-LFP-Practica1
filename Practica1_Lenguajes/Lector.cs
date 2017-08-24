using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Practica1_Lenguajes
{
    class Lector
    {
        static void Main(string[] args)
        {
            /*StreamReader objReader = new StreamReader("c:\\Users\\Loscordonhdez\\Documents\\Visual Studio 2015\\Projects\\PruebaAutomata\\text.txt");
            string sLine = "";
            ArrayList arrText = new ArrayList();

            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    arrText.Add(sLine);
            }
            objReader.Close();

            foreach (string sOutput in arrText)
                Console.WriteLine(sOutput);
            Console.ReadLine();*/
        }

        public ArrayList Arreglo_de_archivo(String InputString)
        {
            StreamReader objReader = new StreamReader(InputString);
            string sLine = "";
            ArrayList arrText = new ArrayList();

            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                ///Console.WriteLine(Encoding.ASCII.GetBytes(sLine)[0]);
                if (sLine != null || sLine != Convert.ToChar(11).ToString())
                    arrText.Add(sLine);
                ///Console.WriteLine(sLine + " tamaño: " + sLine.Length);
            }
            objReader.Close();
            return arrText;
        }
    }
}
