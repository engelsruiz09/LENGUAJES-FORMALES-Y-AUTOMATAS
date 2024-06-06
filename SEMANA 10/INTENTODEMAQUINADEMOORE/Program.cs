using System;
//observaciones: segun mi tabla de estados tengo el estado 4 la transicion 5 en prefijo_octal y el correcto es en BIN y el 2,4 del estado 4 es 2,3 ahi un error en la escritura de las transiciones ya aca en el codigo las corregi    
public class EstadoMoore
{
    public int? SiguienteEstado { get; set; }
    public string Salida { get; set; }

    public EstadoMoore(int? siguienteEstado, string salida)
    {
        SiguienteEstado = siguienteEstado;
        Salida = salida;
    }

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


    private EstadoMoore Estado0(char letra)
    {
        int setPerteneciente = GetSet(letra);
        switch (setPerteneciente)
        {
            case PrefijoBinario:
                return new EstadoMoore(1, null);
            case PrefijoOctal:  
                return new EstadoMoore(2, null);
            case PrefijoHexadecimal:
                return new EstadoMoore(3, null);
            default:
                return new EstadoMoore(null, "RECHAZADO");
        }
    }

    private EstadoMoore Estado1(char letra)
    {
        int setPerteneciente = GetSet(letra);
        if (letra >= '0' && letra <= '1') return new EstadoMoore(4,null);
        switch (setPerteneciente)
        {
            case Binario:
                return new EstadoMoore(4, null);
            default:
                Console.WriteLine($"El caracter '{letra}' no tiene transicion en el estado 1.");
                return null;
        }
    }

    private EstadoMoore Estado2(char letra)
    {
        int setPerteneciente = GetSet(letra);
        if (letra >= '0' && letra <= '7') return new EstadoMoore(Octal, null);
        switch (setPerteneciente)
        {
            case Octal:
                return new EstadoMoore(5, null);

            default:
                Console.WriteLine($"El caracter '{letra}' no tiene transicion en el estado 2.");
                return null;
        }
    }

    private EstadoMoore Estado3(char letra)
    {
        int setPerteneciente = GetSet(letra);
        if ((letra >= '0' && letra <= '9') || (letra >= 'A' && letra <= 'F') || (letra >= 'a' && letra <= 'f')) return new EstadoMoore(6, null);
        switch (setPerteneciente)
        {
            case Hexadecimal:
                return new EstadoMoore(6, null);

            default:
                Console.WriteLine($"El caracter '{letra}' no tiene transicion en el estado 3.");
                return null;
        }
    }

    private EstadoMoore Estado4(char letra)
    {
        int setPerteneciente = GetSet(letra);
        if (letra >= '0' && letra <= '1') return new EstadoMoore(4,null);
        switch (setPerteneciente)
        {
            case Binario:
                return new EstadoMoore(4, null);
            case BIN:
                return new EstadoMoore(2, null);

            default:
                Console.WriteLine($"El caracter '{letra}' no tiene transicion en el estado 4.");
                return null;
        }
    }

    private EstadoMoore Estado5(char letra)
    {
        int setPerteneciente = GetSet(letra);
        if (letra >= '0' && letra <= '7') return new EstadoMoore(Octal, null);
        switch (setPerteneciente)
        {
            case Octal:
                return new EstadoMoore(5, null);
            case OCT:
                return new EstadoMoore(3, null);

            default:
                Console.WriteLine($"El caracter '{letra}' no tiene transicion en el estado 5.");
                return null;
        }
    }

    private EstadoMoore Estado6(char letra)
    {
        int setPerteneciente = GetSet(letra);
        if ((letra >= '0' && letra <= '9') || (letra >= 'A' && letra <= 'F') || (letra >= 'a' && letra <= 'f')) return new EstadoMoore(6, null);
        switch (setPerteneciente)
        {
            case Hexadecimal:
                return new EstadoMoore(6, null);
            case Hexa:
                return new EstadoMoore(7, null);

            default:
                Console.WriteLine($"El caracter '{letra}' no tiene transicion en el estado 6.");
                return null;
        }
    }



    public string AnalizarCadena(string input)
    {
        EstadoMoore estadoActual = new EstadoMoore(0, "INICIO");

        foreach (char letra in input)
        {
            switch (estadoActual.SiguienteEstado)
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

                default:
                    return estadoActual.Salida ?? "NO CUMPLE CON EL LENGUAJE";
            }
        }


        switch (estadoActual.SiguienteEstado)
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
        EstadoMoore mooreMachine = new EstadoMoore(null, null);
        Titulo();
        while (true)
        {

            Console.WriteLine("Ingrese la cadena a analizar (o 'salir' para terminar):");
            string input = Console.ReadLine();
            if (input.ToLower() == "salir") break;

            string resultado = mooreMachine.AnalizarCadena(input);
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
