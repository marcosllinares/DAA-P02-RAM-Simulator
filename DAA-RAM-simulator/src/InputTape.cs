using System.Text.RegularExpressions;

namespace DAA_RAM_simulator.src {
  public class InputTape {
    private LinkedList<int> tape_;

    public InputTape(string inputFile) {
      tape_ = new LinkedList<int>();
      // Leer el archivo y guardar los valores en un array
      // Abre el fichero en el directorio data/input.txt
      StreamReader reader = new (inputFile);
      string? line = reader.ReadLine();
      string[] numbersString = (line ?? "").Split(' ');
      foreach (string numberString in numbersString) {
        if (int.TryParse(numberString, out int number)) {
          tape_.AddLast(number);
        }
      }
    }
    
    public int Read() {
      // Devuelve el valor en la posición head_
      if (tape_.Count == 0) {
        throw new InvalidOperationException("No hay más elementos en la cinta de entrada.");
      }
      int written_element = tape_.First();
      tape_.RemoveFirst();
      return written_element;
    }
  }
}