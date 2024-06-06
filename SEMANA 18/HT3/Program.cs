using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {

        while (true)
        {
            Console.WriteLine("Ingresa un número binario o escribe 'salir' para terminar:");
            string binaryNumber = Console.ReadLine();

            if (binaryNumber.ToLower() == "salir")
            {
                break;
            }

            // Expresión regular para verificar si el número binario es impar
            Regex regex = new Regex(".*1$");

            if (regex.IsMatch(binaryNumber))
            {
                Console.WriteLine("El número binario es impar.");
            }
            else
            {
                Console.WriteLine("El número binario es par.");
            }

            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
