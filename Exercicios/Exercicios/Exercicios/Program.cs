using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicios
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };

            Array num = VerificarArray(numeros);

            if (numeros.Length == num.Length)
                Console.WriteLine("O array contém somente números impares");
            else
                Console.WriteLine("O array não contém somente números impares");

            foreach (var item in num)
                Console.Write(item + ", ");

            Console.WriteLine();

            string[] arrayString = { "abracadabra", "allottee", "assessee" };

            foreach (var item in RemovePalavrasDuplicadas(arrayString))
                Console.Write(item + ", ");

            Console.ReadLine();
        }

        public static Array VerificarArray(int[] array)
        {
            var newArray =
                from num in array
                where (num % 2) != 0
                select num;

            return newArray.ToArray();
        }

        public static List<string> RemovePalavrasDuplicadas(string[] array)
        {
            var letrasDuplicadas = new List<char>();

            List<string> textos = new List<string>();

            foreach (var texto in array)
            {
                foreach (var element in texto.ToCharArray())
                    if (letrasDuplicadas.Count == 0 || letrasDuplicadas.Last() != element)
                        letrasDuplicadas.Add(element);

                string newString = new string(letrasDuplicadas.ToArray());
                textos.Add(newString);
                letrasDuplicadas.Clear();
            }

            return textos;
        }
    }
}
