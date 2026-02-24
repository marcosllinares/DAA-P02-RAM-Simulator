/**
Universidad de La Laguna
Escuela Superior de Ingeniería y Tecnología
Grado en Ingeniería Informática
Asignatura: Diseño y Análisis de Algoritmos
Curso: 3º
Autores:
  - Marcos Llinares Montes. alu0100972443@ull.edu.es
  - Gerard Caramazza Vilá.  alu0101229775@ull.edu.es

Dependiendo de la versión de .NET Core, el comando 'dotnet run' puede no funcionar correctamente
si no se ejecuta con la misma versión que la especificada en DAA-RAM-simulator.csproj.
En ese caso cambiar la versión de .NET Core en DAA-RAM-simulator.csproj a: <TargetFramework>net9.0</TargetFramework>

Formato de Ejecución: dotnet run <archivo de programa> <archivo de entrada> <archivo de salida>.
  - Ejemplo:          dotnet run data/Ejemplos_RAM/test1.ram data/input.txt data/output.txt
*/
using DAA_RAM_simulator.src;

class Program {
  static void CheckParameters(string[] args) {
    if (args.Length == 0) {
      throw new ArgumentException("El programa simula la ejecución de una máquina RAM. Para más información use el parámetro '--help'.");
    } else if (args[0] == "--help") {
      throw new ArgumentException("Formato de Ejecución: dotnet run <archivo de programa> <archivo de entrada> <archivo de salida>.");
    } else if (args.Length != 3) {
      throw new ArgumentException("Número de parámetros incorrecto. Para más información use el parámetro '--help'.");
    }
  }

  // TODO: 
  // 4. Esta extensión de la máquina RAM implementada consiste en ampliar los registros R para
  //    que permitan almacenar vectores de tamaño dinámico.
  // 5. Comparar el número de ejecuciones para instancias de diferente tamaño 2 algoritmos de
  //    ordenación: BubbleSort y InsertionSort.
  //    Los resultados de esta comparación deben reflejarse en un informe de una página.

  // Genera un array de tamaño size con números aleatorios entre 0 y 100.
  static int[] GenerateRandomArray(int size) {
    Random random = new();
    int[] array = new int[size];
    for (int i = 0; i < size; i++) {
      array[i] = random.Next(0, 100);
    }
    return array;
  }

  // Imprime el array en la consola.
  static void PrintArray(int[] array) {
    for (int i = 0; i < array.Length; i++) {
      Console.Write(array[i] + " ");
    }
    Console.WriteLine();
  }

  // Guarda el array en un fichero.
  static void SaveArrayToFile(int[] array, string fileName) {
    File.WriteAllText(fileName, string.Join(" ", array));
  }

  static bool AskRegisterTypeIsVectorial() {
    Console.WriteLine("Registros:\n1) Vectores\n2) Enteros");
    string? answer = Console.ReadLine();
    return answer == "1";
  }

  static void Main(string[] args) {
    RAM? ram = null;
    bool vectorialRegisters = AskRegisterTypeIsVectorial();
    try {
      CheckParameters(args);
      string programFile = args[0];
      string inputFile = args[1];
      string outputFile = args[2];
      ram = new(programFile, inputFile, outputFile, vectorialRegisters);
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
