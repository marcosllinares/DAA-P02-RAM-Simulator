namespace DAA_RAM_simulator.src.Operands {
  public class DirectRegister : IOperand {
    private int value_;

    // Constructor de la clase DirectRegister
    public DirectRegister(string expression) {
      value_ = int.Parse(expression);
    }

    // Devuelve el indice del registro, no el contenido.
    // Caso especial de operaciones: STORE, READ
    public int GetValue(int[] registers, Dictionary<string, int> tagMap) {
      return value_;
    }
  }
}