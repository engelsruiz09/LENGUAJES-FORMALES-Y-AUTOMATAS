using System.ComponentModel.DataAnnotations;
using System.IO;
using EXPRESIONESREGULARES;
using System;
using System.Diagnostics;

bool continuar = true;

while (continuar)
{

    ImprimirTitulo();

    Console.WriteLine("Seleccione una opcion:\n1. Validar Placas\n2. Validar Fecha\n3. Validar SETS");

    var opcion = Console.ReadLine();

    
    try
    {
        string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        Process.Start("explorer.exe", downloadsPath);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Ocurrió un error al intentar abrir el directorio: " + ex.Message);
    }

    switch (opcion)
    {
        case "1":
            Console.WriteLine("Por favor, navegue a la carpeta que contiene el archivo con las placas, seleccione el archivo, arrastrelo y sueltelo aqui, o escriba la ruta completa del archivo y presione Enter:");
            var filePathPlacas = Console.ReadLine();

            if (File.Exists(filePathPlacas))
            {
                string[] placas = File.ReadAllLines(filePathPlacas);
                foreach (var placa in placas)
                {
                    bool esValida = expresiones.placa(placa);
                    Console.WriteLine($"{placa}: {(esValida ? "Valida" : "No valida")}");
                }
            }
            else
            {
                Console.WriteLine("El archivo de placas no existe. Por favor, verifica la ruta e intenta de nuevo.");
            }
            break;
        case "2":
            Console.WriteLine("Ingrese la fecha (AAAA/MM/DD HH:MM:SS):");
            var fecha = Console.ReadLine();
            Console.WriteLine($"Fecha {(expresiones.fechas(fecha) ? "Valida" : "Invalida")}");
            break;
        case "3":
            Console.WriteLine("Por favor, navegue a la carpeta que contiene el archivo con los SETS, seleccione el archivo, arrastrelo y sueltelo aqui, o escriba la ruta completa del archivo y presione Enter:");
            var filePathSets = Console.ReadLine();

            if (File.Exists(filePathSets))
            {
                int lineNumber = 1;
                foreach (var line in File.ReadLines(filePathSets))
                {
                    // Ahora llama a tu función set para cada línea, pasando la línea y el número de línea.
                    // Nota: set ahora no retorna un valor booleano que indique si todos los sets son válidos, sino que imprime el resultado por cada línea.
                    expresiones.set(line, lineNumber);
                    lineNumber++;
                }
            }
            else
            {
                Console.WriteLine("El archivo de SETS no existe. Por favor, verifica la ruta e intenta de nuevo.");
            }
            break;
        case "4":
            continuar = false;
            break;
        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
    Console.ReadKey();
    Console.Clear();
}


static void ImprimirTitulo()
{
    Console.WriteLine("  ______     _ ______ _____   _____ _____ _____ _____ ____    ___  ");
    Console.WriteLine(" |  ____|   | |  ____|  __ \\ / ____|_   _/ ____|_   _/ __ \\  |__ \\ ");
    Console.WriteLine(" | |__      | | |__  | |__) | |      | || |      | || |  | |    ) |");
    Console.WriteLine(" |  __| _   | |  __| |  _  /| |      | || |      | || |  | |   / / ");
    Console.WriteLine(" | |___| |__| | |____| | \\ \\| |____ _| || |____ _| || |__| |  / /_ ");
    Console.WriteLine(" |______\\____/|______|_|  \\_\\\\_____|_____\\_____|_____\\____/  |____|");
    Console.WriteLine();
}
