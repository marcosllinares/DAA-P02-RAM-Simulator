/**
Universidad de La Laguna
Escuela Superior de Ingeniería y Tecnología
Grado en Ingeniería Informática
Asignatura: Diseño y Análisis de Algoritmos
Curso: 3º
Autores:
  - Marcos Llinares Montes. alu0100972443@ull.edu.es
  - Diego Antonio Pi Artiaga. alu0101493084@ull.edu.es

Dependiendo de la versión de .NET Core, el comando 'dotnet run' puede no funcionar correctamente
si no se ejecuta con la misma versión que la especificada en DAA-RAM-simulator.csproj.
En ese caso cambiar la versión de .NET Core en DAA-RAM-simulator.csproj a: <TargetFramework>net9.0</TargetFramework>

Formato de Ejecución: dotnet run <archivo de programa> <archivo de entrada> <archivo de salida>.
  - Ejemplo:          dotnet run data/Ejemplos_RAM/test1.ram data/input.txt data/output.txt
*/

using System;
using DAA_RAM_simulator.src;

class Program {
  // Valida los parámetros de entrada.
  static void CheckParameters(string[] args) {
    if (args.Length == 0) {
      throw new ArgumentException("El programa simula la ejecución de una máquina RAM. Para más información use el parámetro '--help'.");
    } else if (args[0] == "--help") {
      throw new ArgumentException("Formato de Ejecución: dotnet run <archivo de programa> <archivo de entrada> <archivo de salida>.");
    } else if (args.Length != 3) {
      throw new ArgumentException("Número de parámetros incorrecto. Para más información use el parámetro '--help'.");
    }
  }

  // Guarda el array en un fichero.
  static void SaveArrayToFile(int[] array, string fileName) {
    System.IO.File.WriteAllText(fileName, string.Join(" ", array));
  }

  // Método principal.
  static void Main(string[] args) {
    RAM? ram = null;
    // Manejo de errores
    try {
      CheckParameters(args);
      string programFile = args[0];
      string inputFile = args[1];
      string outputFile = args[2];
      ram = new(programFile, inputFile, outputFile);
      ram.Run();
    }
    catch (Exception exception) {
      if (ram != null) {
        ram.GetOutputTape().WriteToFile();
      }
      Console.WriteLine(exception.Message);
    }
  }
}
