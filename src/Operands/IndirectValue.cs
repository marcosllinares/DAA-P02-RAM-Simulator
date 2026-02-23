namespace DAA_RAM_simulator.src.Operands {
  public class IndirectValue : IOperand {
    private int value_;

    // Constructor de la clase IndirectValue
    public IndirectValue (string expression) {
      value_ = int.Parse(expression.Substring(1));
    }

    // Devuelve el valor del registro apuntado por el valor del registro newRegisterIndex
    public int GetValue(int[] registers, Dictionary<string, int> tagMap) {
      int newRegisterIndex = registers[value_];
      return registers[newRegisterIndex];
    }
  }
}