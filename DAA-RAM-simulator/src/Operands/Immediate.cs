namespace DAA_RAM_simulator.src.Operands {
  public class Immediate : IOperand {
    private int value_;
    
    public Immediate(string expression) {
      value_ = int.Parse(expression.Substring(1));
    }

    public int GetValue(IRegister[] registers, RegisterInt accumulator, Dictionary<string, int> tagMap) {
      return value_;
    }
  }
}