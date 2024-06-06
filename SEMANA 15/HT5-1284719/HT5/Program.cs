using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        AutomataPila automata = new AutomataPila();

        string input = "C,C++ Java y UML/6071512123*Desarrolo Humano/6071509335#Avengers/2012?http:/www.url.edu.gt";
        bool resultado = automata.EsAceptada(input);
        Console.WriteLine($"La cadena '{input}' es {(resultado ? "aceptada" : "no aceptada")} por el autómata.");
    }
}

public class AutomataPila
{
    private void S0(Stack<string> stack)
    {
        stack.Push("#");
        stack.Push("S");
    }

    private int S1(string input, int index, Stack<string> stack)
    {
        while (index < input.Length)
        {
            if (input[index] == '*' || input[index] == '#' || input[index] == '?' || input[index] == '$')
            {
                char delimiter = input[index];
                index++; // Skip the delimiter
                int nextIndex = FindNextIndex(input, index);
                string content = input.Substring(index, nextIndex - index);
                index = nextIndex;

                if (delimiter == '?' && (content.StartsWith("http://") || content.StartsWith("https://")))
                {
                    // Process URL after '?'
                    if (stack.Peek() == "URL")
                    {
                        stack.Pop(); // URL is correctly placed and processed
                    }
                }

                switch (delimiter)
                {
                    case '*':
                        if (stack.Peek() == "libro") stack.Pop();
                        break;
                    case '#':
                        if (stack.Peek() == "pelicula") stack.Pop();
                        break;
                    case '$':
                        if (stack.Peek() == "tesis") stack.Pop();
                        break;
                }
            }
            else
            {
                index++;
            }
        }
        return index;
    }

    private int FindNextIndex(string input, int startIndex)
    {
        for (int i = startIndex; i < input.Length; i++)
        {
            if (input[i] == '*' || input[i] == '#' || input[i] == '?' || input[i] == '$')
                return i;
        }
        return input.Length; // Return end of string if no delimiter found
    }

    private void S2(string input, int index, Stack<string> stack)
    {
        if (index != input.Length)
        {
            throw new Exception("Símbolos pendientes de consumir cadena no aceptada");
        }

        if (stack.Peek() == "S" && stack.Count == 2) // Check for initial 'S' and '#'
        {
            stack.Pop(); // Pop 'S'
        }

        if (stack.Count != 1 || stack.Peek() != "#") // Expect only '#' at the end
        {
            throw new Exception("Símbolos pendientes de procesar cadena no aceptada");
        }
    }

    public bool EsAceptada(string input)
    {
        bool cadenaAceptada = false;
        int index = 0;
        Stack<string> stack = new Stack<string>();

        try
        {
            S0(stack);
            index = S1(input, index, stack);
            S2(input, index, stack);
            cadenaAceptada = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return cadenaAceptada;
    }
}
