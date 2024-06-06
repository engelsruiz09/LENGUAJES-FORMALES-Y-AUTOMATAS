using System;
//observaciones: segun mi tabla de estados tengo el estado 4 la transicion 5 en prefijo_octal y el correcto es en BIN y el 2,4 del estado 4 es 2,3 ahi un error en la escritura de las transiciones ya aca en el codigo las corregi    
public class ScannerAFD
{
    public const int PrefijoBinario = 1;
    public const int Binario = 2;
    public const int BIN = 3;
    public const int PrefijoOctal = 4;
    public const int Octal = 5;
    public const int OCT = 6;
    public const int PrefijoHexadecimal = 7;
    public const int Hexadecimal = 8;
    public const int Hexa = 9;

    public static int GetSet(char letra)
    {
        if (letra == 'b') return PrefijoBinario;
        else if (letra == 'o') return PrefijoOctal;
        else if (letra == 'x') return PrefijoHexadecimal;
        //else if (letra >= '0' && letra <= '1') return Binario;
        //else if (letra >= '0' && letra <= '7') return Octal;
        //else if ((letra >= '0' && letra <= '9') || (letra >= 'A' && letra <= 'F') || (letra >= 'a' && letra <= 'f')) return Hexadecimal;
        else return -1; // No reconocido
    }

   
    private int? Estado0(char letra)
    {
        int setPerteneciente = GetSet(letra);
        switch (setPerteneciente)
        {
            case PrefijoBinario:
                return 1;
            case PrefijoOctal:
                return 2;
            case PrefijoHexadecimal:
                return 3;
            default:
                Console.WriteLine($"El caracter '{letra}' no tiene transicion en el estado 0.");
                return null;
        }
    }

    private int? Estado1(char letra)
    {
        int setPerteneciente = GetSet(letra);
        if (letra >= '0' && letra <= '1') return 4;
        switch (setPerteneciente)
        {
            case Binario:
                return 4;
            default:
                Console.WriteLine($"El caracter '{letra}' no tiene transicion en el estado 1.");
                return null;
        }
    }

    private int? Estado2(char letra)
    {
        int setPerteneciente = GetSet(letra);
        if (letra >= '0' && letra <= '7') return Octal;
        switch (setPerteneciente)
        {
            case Octal:
                return 5;

            default:
                Console.WriteLine($"El caracter '{letra}' no tiene transicion en el estado 2.");
                return null;
        }
    }

    private int? Estado3(char letra)
    {
        int setPerteneciente = GetSet(letra);
        if ((letra >= '0' && letra <= '9') || (letra >= 'A' && letra <= 'F') || (letra >= 'a' && letra <= 'f')) return 6;
        switch (setPerteneciente)
        {
            case Hexadecimal:
                return 6;

            default:
                Console.WriteLine($"El caracter '{letra}' no tiene transicion en el estado 3.");
                return null;
        }
    }

    private int? Estado4(char letra)
    {
        int setPerteneciente = GetSet(letra);
        if (letra >= '0' && letra <= '1') return 4;
        switch (setPerteneciente)
        {
            case Binario:
                return 4;
            case BIN:
                return 2;

            default:
                Console.WriteLine($"El caracter '{letra}' no tiene transicion en el estado 4.");
                return null;
        }
    }

    private int? Estado5(char letra)
    {
        int setPerteneciente = GetSet(letra);
        if (letra >= '0' && letra <= '7') return Octal;
        switch (setPerteneciente)
        {
            case Octal:
                return 5;
            case OCT:
                return 3;

            default:
                Console.WriteLine($"El caracter '{letra}' no tiene transicion en el estado 5.");
                return null;
        }
    }

    private int? Estado6(char letra)
    {
        int setPerteneciente = GetSet(letra);
        if ((letra >= '0' && letra <= '9') || (letra >= 'A' && letra <= 'F') || (letra >= 'a' && letra <= 'f')) return 6;
        switch (setPerteneciente)
        {
            case Hexadecimal:
                return 6;
            case Hexa:
                return 7;

            default:
                Console.WriteLine($"El caracter '{letra}' no tiene transicion en el estado 6.");
                return null;
        }
    }

    private int Estado7(char letra)
    {
        int setPerteneciente = GetSet(letra);return 7;
    }

    public string AnalizarCadena(string input)
    {
        int? estadoActual = 0; // Estado inicial.

        foreach (char letra in input)
        {
            switch (estadoActual)
            {
                case 0:
                    estadoActual = Estado0(letra);
                    break;
                case 1:
                    estadoActual = Estado1(letra);
                    break;
                case 2:
                    estadoActual = Estado2(letra);
                    break;
                case 3:
                    estadoActual = Estado3(letra);
                    break;
                case 4:
                    estadoActual = Estado4(letra);
                    break;
                case 5:
                    estadoActual = Estado5(letra);
                    break;
                case 6:
                    estadoActual = Estado6(letra);
                    break;
                case 7:
                    estadoActual = Estado7(letra);
                    break;

                default:
                    Console.WriteLine("Estado no reconocido");
                    return null;
            }
        }


        switch (estadoActual)
        {
            case 4:
                return "NUMERO BINARIO";

            case 5:
                return "NUMERO OCTAL";

            case 6:
                return "NOMBRE HEXADECIMAL";
            default:
                return "NO CUMPLE CON EL LENGUAJE";
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        ScannerAFD scanner = new ScannerAFD();
        Titulo();
        while (true)
        {
           
            Console.WriteLine("Ingrese la cadena a analizar (o 'salir' para terminar):");
            string input = Console.ReadLine();
            if (input.ToLower() == "salir") break;

            string resultado = scanner.AnalizarCadena(input);
            Console.WriteLine($"Resultado: {resultado}");
        }

    }
    public static void Titulo()
    {
        Console.WriteLine(" █████╗ ███████╗██████╗                    ██╗██╗   ██╗██╗     ██╗ ██████╗ ");
        Console.WriteLine("██╔══██╗██╔════╝██╔══██╗                   ██║██║   ██║██║     ██║██╔═══██╗");
        Console.WriteLine("███████║█████╗  ██║  ██║    █████╗         ██║██║   ██║██║     ██║██║   ██║");
        Console.WriteLine("██╔══██║██╔══╝  ██║  ██║    ╚════╝    ██   ██║██║   ██║██║     ██║██║   ██║");
        Console.WriteLine("██║  ██║██║     ██████╔╝              ╚█████╔╝╚██████╔╝███████╗██║╚██████╔╝");
        Console.WriteLine("╚═╝  ╚═╝╚═╝     ╚═════╝                ╚════╝  ╚═════╝ ╚══════╝╚═╝ ╚═════╝ ");
        Console.WriteLine("");
    }

}
