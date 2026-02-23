using System.Text.RegularExpressions;

namespace DAA_RAM_simulator.src {
  public class RAM {
    private ALU alu_;
    private InputTape inputTape_;
    private OutputTape outputTape_;
    private int[] registers_;
    private List<Instruction> memoryProgram_;
    private Dictionary<string, int> tagMap_;

    // Constructor de la clase RAM
    public RAM(string programFile, string inputFile, string outputFile) {
      int[] array = new int[100];
      Array.Fill(array, int.MaxValue);
      registers_ = array;
      alu_ = new ALU();
      outputTape_ = new OutputTape(outputFile);
      inputTape_ = new InputTape(inputFile);
      memoryProgram_ = new List<Instruction>();
      tagMap_ = new Dictionary<string, int>();

      // Leer el programa y guardarlo en memoryProgram
      ParseProgram(programFile);
    }

    // Ejecutar el programa
    public void Run() {
      alu_.Execute(memoryProgram_, registers_, tagMap_, inputTape_, outputTape_);
    }

    // Parsear el programa y guardarlo en memoryProgram
    private void ParseProgram(string program) {
      int codeLine = 0;
      using (StreamReader reader = new StreamReader(program)) {
        string? line;
        string[] words;
        while ((line = reader.ReadLine()) != null) {
          line = line.ToUpper();
          // Separar la línea en palabras y los añade a un array
          words = Regex.Split(line.Trim(), @"\s+");
          // linea vacía o comentario
          if (words[0] == "" || words[0][0] == '#') {
            continue;
          }
          if (words[0][^1] == ':') { // Si el último caracter es ':'
            // Elimina ':'
            words[0] = words[0].Substring(0, words[0].Length - 1);
            // Añadir etiqueta
            tagMap_.Add(words[0], codeLine);
            // "lee:	read 1" -> [lee, read, 1] se elimina "lee" de este
            words = words.Skip(1).ToArray();
          }

          // Llamamos al constructor de Instruction
          try {
            // Si solo hay una palabra, se llama al constructor con un solo argumento correspondiente a lineas de instrucción "HALT"
            if (words.Length == 1) {
              memoryProgram_.Add(new Instruction(words[0]));
            }
            else {
              memoryProgram_.Add(new Instruction(words[0], words[1]));
            }
          }
          catch (Exception exception) {
            throw new Exception($"Error en tiempo de compilación durante el ParseProgram.\nError en la línea {codeLine + 1}: {exception.Message}");
          }
          codeLine++;
        }
      }
    } // El archivo se cierra automáticamente aquí, sin importar qué

    // Imprimir el mapa de etiquetas
    public void PrintTagMap() {
      foreach (var tag in tagMap_) {
        Console.WriteLine($"[{tag.Key}, {tag.Value}]");
      }
    }
    
    // Obtener la cinta de entrada
    public OutputTape GetOutputTape() {
      return outputTape_;
    }
  }
}