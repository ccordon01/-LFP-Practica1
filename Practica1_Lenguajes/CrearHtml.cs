using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_Lenguajes
{
    internal class CrearHtml
    {
        private ArrayList arrayList1;
        private ArrayList arrayList2;
        Tokens lista = new Tokens();
        public CrearHtml(ArrayList arrayList1, ArrayList arrayList2)
        {
            this.arrayList1 = arrayList1;
            this.arrayList2 = arrayList2;
        }

        public void crearAll() {
            Console.WriteLine("Creando Archivos");
            string fileName1 = "Tokens.html";
            string path = "C:\\Reportes";
            System.IO.Directory.CreateDirectory(path);
            string pathStrings = System.IO.Path.Combine(path, fileName1);
            string fileName2 = "Erorres.html";
            string path1 = "C:\\Reportes";
            string pathStrings1 = System.IO.Path.Combine(path1, fileName2);
            if (!System.IO.File.Exists(pathStrings))
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(pathStrings))
                {
                    file.WriteLine("<html>");
                    file.WriteLine("<head>");
                    file.WriteLine("<title>Token</title>");
                    file.WriteLine("</head>");
                    file.WriteLine("<body>");
                    file.WriteLine("<h1>Lista Tokens</h1>");
                    file.WriteLine("<table border>");
                    file.WriteLine("<tr>");
                    file.WriteLine("<td>" + "#"+ "</td>");
                    file.WriteLine("<td>" + "Lexema" + "</td>");
                    file.WriteLine("<td>" + "Id Token" + "</td>");
                    file.WriteLine("<td>" + "Token" + "</td>");
                    file.WriteLine("</tr>");
                    for (int i = 0; i < arrayList2.Count; i++)
                    {
                        file.WriteLine("<tr>");
                        file.WriteLine("<td>"+i+"</td>");
                        for (int j = 0; j < 10; j++)
                        {
                            Tokens[,] aux_token = lista.Lista_Tokens();
                            if (arrayList2[i].ToString() == aux_token[j,0].get_lexema())
                            {   

                                file.WriteLine("<td>"+ arrayList2[i].ToString() + "</td>");
                                file.WriteLine("<td>" + aux_token[j, 0].get_id() + "</td>");
                                file.WriteLine("<td>" + aux_token[j, 0].get_token() + "</td>");
                            }
                        }
                        file.WriteLine("</tr>");
                    }
                    file.WriteLine("</table>");
                    file.WriteLine("</body>");
                    file.WriteLine("</html>");
                }
            }
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", fileName1);
            }

            if (!System.IO.File.Exists(pathStrings1))
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(pathStrings1))
                {
                    file.WriteLine("<html>");
                    file.WriteLine("<head>");
                    file.WriteLine("<title>Error</title>");
                    file.WriteLine("</head>");
                    file.WriteLine("<body>");
                    file.WriteLine("<h1>Lista Errores</h1>");
                    file.WriteLine("<table border>");
                    file.WriteLine("<tr>");
                    file.WriteLine("<td>" + "#" + "</td>");
                    file.WriteLine("<td>" + "Fila" + "</td>");
                    file.WriteLine("<td>" + "Columna" + "</td>");
                    file.WriteLine("<td>" + "Caracter" + "</td>");
                    file.WriteLine("<td>" + "Descripcion" + "</td>");
                    file.WriteLine("</tr>");
                    for (int i = 0; i < arrayList1.Count; i++)
                    {
                        file.WriteLine("<tr>");
                        file.WriteLine("<td>" + i + "</td>");
                            Errores error = (Errores)arrayList1[i];
                            file.WriteLine("<td>" + error.Get_fila() + "</td>");
                    file.WriteLine("<td>" + error.Get_columna() + "</td>");
                                file.WriteLine("<td>" + error.Get_caracter() + "</td>");
                    file.WriteLine("<td>" + error.Get_descripcion() + "</td>");
                    file.WriteLine("</tr>");
                    }
                    file.WriteLine("</table>");
                    file.WriteLine("</body>");
                    file.WriteLine("</html>");
                }
            }
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", fileName2);
            }
            Console.WriteLine("Creacion culminada");
        }
    }
}