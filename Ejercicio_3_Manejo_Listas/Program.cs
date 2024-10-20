using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionario
{
    internal class DiccionarioT
    {
        static void Main()
        {
            List<Tuple<string, string>> diccionario = CrearDiccionario();
            traducir(diccionario);
        }

        public static List<Tuple<string, string>> CrearDiccionario()
        {
            List<Tuple<string, string>> diccionario = new List<Tuple<string, string>>();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Introduzca la palabra {i + 1} en ingles: ");
                string palabra1 = Console.ReadLine();

                Console.WriteLine($"Introduzca la palabra {i + 1} en español: ");
                string palabra2 = Console.ReadLine();

                diccionario.Add(new Tuple<string, string>(palabra1, palabra2));
            }
            return diccionario;
        }

        public static void traducir(List<Tuple<string, string>> diccionario)
        {
            Console.WriteLine($"Introduzca la palabra a traducir: ");
            string palcomp = Console.ReadLine();
            bool encontrado = false;

            foreach (var duo in diccionario)
            {
                if (duo.Item1.Equals(palcomp, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"La traducción de la palabra {palcomp} es {duo.Item2}. ");
                    encontrado = true;
                    break;
                }
                else if (duo.Item2.Equals(palcomp, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"La traducción de la palabra {palcomp} es {duo.Item1}. ");
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine($"La palabra {palcomp} no se encuentra en el diccionario. ");
            }
        }


    }
}