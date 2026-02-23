using System.Text.RegularExpressions;

namespace DAA_RAM_simulator.src {
  public class InputTape {
    private LinkedList<int> tape_;

    // Constructor de la clase InputTape. Lee el fichero y guarda los valores en una linked list 
    public InputTape(string inputFile) {
      tape_ = new LinkedList<int>();
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
    
    // Devuelve el primer elemento de la cinta de entrada y lo elimina, si no hay elementos lanza una excepción
    public int Read() {
      if (tape_.Count == 0) {
        throw new InvalidOperationException("No hay más elementos en la cinta de entrada.");
      }
      int written_element = tape_.First();
      tape_.RemoveFirst();
      return written_element;
    }

  }
}