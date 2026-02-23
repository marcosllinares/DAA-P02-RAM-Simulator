namespace DAA_RAM_simulator.src.Operands {
  public class DirectValue : IOperand {
    private int value_;

    // Constructor de la clase DirectValue
    public DirectValue(string expression) {
      value_ = int.Parse(expression);
    }

    // Devuelve el valor del registro
    public int GetValue(int[] registers, Dictionary<string, int> tagMap) {
      return registers[value_];
    }
  }
}