using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        titulo();
        Console.WriteLine();
        string[] ejemplos = {
            "DPI:1234567890123,TELEFONO:12345678, IMEI:123456789012345, CUENTAORIGEN:1234567,BANCOORIGEN:BancoJ,CUENTADESTINO:7654321, BANCO DESTINO:BancoW, MONTO:1400.00, MONEDA:GTQ ",
            "DPI:9876543210987,TELEFONO:87654321, IMEI:543216789012345, CUENTAORIGEN:2345678,BANCOORIGEN:BancU,CUENTADESTINO:8765432, BANCO DESTINO:BancP, MONTO:450.60, MONEDA:USD "
        };

        string pattern = @"^DPI:\d{13},TELEFONO:\d{8}, IMEI:\d{15}, CUENTAORIGEN:\d{7},BANCOORIGEN:[A-Za-z0-9 ]{4,7},CUENTADESTINO:\d{7}, BANCO DESTINO:[A-Za-z0-9 ]{4,7}, MONTO:\d+(\.\d{1,2})?, MONEDA:[A-Z]{3} $";

        foreach (var ejemplo in ejemplos)
        {
            if (Regex.IsMatch(ejemplo, pattern))
            {
                Console.WriteLine("Válido: " + ejemplo);
            }
            else
            {
                Console.WriteLine("Inválido: " + ejemplo);
            }
        }
        Console.ReadKey();
    }

    static void titulo()
    {
        Console.WriteLine("███████╗███████╗██████╗ ██╗███████╗    ██╗██╗██╗");
        Console.WriteLine("██╔════╝██╔════╝██╔══██╗██║██╔════╝    ██║██║██║");
        Console.WriteLine("███████╗█████╗  ██████╔╝██║█████╗      ██║██║██║");
        Console.WriteLine("╚════██║██╔══╝  ██╔══██╗██║██╔══╝      ██║██║██║");
        Console.WriteLine("███████║███████╗██║  ██║██║███████╗    ██║██║██║");
        Console.WriteLine("╚══════╝╚══════╝╚═╝  ╚═╝╚═╝╚══════╝    ╚═╝╚═╝╚═╝");
    }
}
