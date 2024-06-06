using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("███████╗███████╗██████╗ ██╗███████╗    ██╗██╗██╗    ██████╗ ██████╗  ██████╗ ██████╗ ██╗     ███████╗███╗   ███╗ █████╗     ██╗██╗");
        Console.WriteLine("██╔════╝██╔════╝██╔══██╗██║██╔════╝    ██║██║██║    ██╔══██╗██╔══██╗██╔═══██╗██╔══██╗██║     ██╔════╝████╗ ████║██╔══██╗    ██║██║");
        Console.WriteLine("███████╗█████╗  ██████╔╝██║█████╗      ██║██║██║    ██████╔╝██████╔╝██║   ██║██████╔╝██║     █████╗  ██╔████╔██║███████║    ██║██║");
        Console.WriteLine("╚════██║██╔══╝  ██╔══██╗██║██╔══╝      ██║██║██║    ██╔═══╝ ██╔══██╗██║   ██║██╔══██╗██║     ██╔══╝  ██║╚██╔╝██║██╔══██║    ██║██║");
        Console.WriteLine("███████║███████╗██║  ██║██║███████╗    ██║██║██║    ██║     ██║  ██║╚██████╔╝██████╔╝███████╗███████╗██║ ╚═╝ ██║██║  ██║    ██║██║");
        Console.WriteLine("╚══════╝╚══════╝╚═╝  ╚═╝╚═╝╚══════╝    ╚═╝╚═╝╚═╝    ╚═╝     ╚═╝  ╚═╝ ╚═════╝ ╚═════╝ ╚══════╝╚══════╝╚═╝     ╚═╝╚═╝  ╚═╝    ╚═╝╚═╝");
        Console.WriteLine();

        string elregex = @"^(NIT:[\w\d-]+)\s+(IP:\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}|DPI:\d{13})\s+(Tarjeta:\s?\d{16}|Hora:\d{2}:\d{2})\s+(Monto:[\$Q]\d+\.?\d*)$";

        //dejo mis dos casos de prueba solo es de cambiar el input2 por el input para probar el otro caso 
        string input = "NIT:1234567-8 IP:192.168.1.1 Tarjeta:1234567812345678 Monto:$100.00";
        string input2 = "NIT:719366-1 DPI:1307217010145 Hora:13:20 Monto:Q4500.00";


        if (Regex.IsMatch(input, elregex, RegexOptions.IgnoreCase))
        {
            Console.WriteLine("La cadena cumple con el formato requerido.");
        }
        else
        {
            Console.WriteLine("La cadena NO cumple con el formato requerido.");
        }
        Console.ReadKey();
    }
}

