using System;
using System.Collections.Generic;
using System.Linq;

public class StructParser
{
    private void S0(Stack<string> stack)
    {
        stack.Push("#");
        stack.Push("S");
    }

    private int S1(string[] tokens, int index, Stack<string> stack)
    {
        while (index < tokens.Length)
        {
            string token = tokens[index];

            switch (token)
            {
                case "struct":
                    {
                        if (stack.Peek() == "S")
                        {
                            if (index + 1 < tokens.Length && IsIdentifier(tokens[index + 1]))
                            {
                                stack.Pop();
                                stack.Push("fin_struct");
                                index += 2; // Avanza al contenido del struct
                                continue;
                            }
                        }
                        throw new Exception("Se esperaba un identificador después de 'struct'");
                    }

                case "int":
                    {
                        if (index + 2 < tokens.Length && IsIdentifier(tokens[index + 1]) && IsNumeric(tokens[index + 2]))
                        {
                            if (stack.Peek() == "fin_struct")
                            {
                                index += 3; // Avanza al siguiente token después del valor numérico
                                continue;
                            }
                        }
                        throw new Exception("Se esperaban un identificador y un valor numérico después de 'int'");
                    }

                case "string":
                    {
                        if (index + 2 < tokens.Length && IsIdentifier(tokens[index + 1]) && !IsNumeric(tokens[index + 2]))
                        {
                            if (stack.Peek() == "fin_struct")
                            {
                                index += 3; // Avanza al siguiente token después del valor de cadena
                                continue;
                            }
                        }
                        throw new Exception("Se esperaban un identificador y una cadena después de 'string'");
                    }

                default:
                    throw new Exception($"El símbolo: {token} no pertenece al alfabeto o es inesperado en este contexto");
            }
        }

        return index;
    }

    private void S2(string[] tokens , int index, Stack<string> stack)
    {
        if (index != tokens.Length)
        {
            throw new Exception("Símbolos pendientes de consumir, cadena no aceptada");
        }

        if (stack.Peek() == "fin_struct")
        {
            stack.Pop();
        }

        if (stack.Peek() == "#")
        {
            stack.Pop();
        }

        if (stack.Count != 0)
        {
            throw new Exception("Símbolos pendientes de procesar, cadena no aceptada");
        }
    }

    public bool Parse(string input)
    {
        bool cadenaAceptada = false;
        int index = 0;
        Stack<string> stack = new Stack<string>();
        string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        try
        {
            S0(stack);
            index = S1(tokens, index, stack);
            S2(tokens, index, stack);
            cadenaAceptada = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return cadenaAceptada;
    }

    private bool IsIdentifier(string token)
    {
        return char.IsLetter(token[0]) && token.All(char.IsLetterOrDigit);
    }

    private bool IsNumeric(string token)
    {
        return int.TryParse(token, out _);
    }

    public static void Main()
    {
        StructParser parser = new StructParser();
        string input = "struct Persona int edad 30 string nombre Juan int edad 30 ";
        //
        bool result = parser.Parse(input);
        Console.WriteLine($"La cadena '{input}' es {(result ? "aceptada" : "no aceptada")} por el autómata.");
        Console.ReadKey();
    }
}
