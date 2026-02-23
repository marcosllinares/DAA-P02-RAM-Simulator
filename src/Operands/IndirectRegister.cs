namespace DAA_RAM_simulator.src.Operands {
  public class IndirectRegister : IOperand {
    private int value_;

    // Constructor de la clase IndirectRegister
    public IndirectRegister (string expression) {
      value_ = int.Parse(expression.Substring(1));
    }

    // Devuelve el valor del registro.
    // Caso especial de operaciones: STORE, READ
    public int GetValue(int[] registers, Dictionary<string, int> tagMap) {
      return registers[value_];
    }
  }
}