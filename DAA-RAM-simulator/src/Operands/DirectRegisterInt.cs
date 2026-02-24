namespace DAA_RAM_simulator.src.Operands {
  public class DirectRegisterInt : IOperand {
    private int value_;

    public DirectRegisterInt(string expression) {
      value_ = int.Parse(expression);
    }

    public int GetValue(IRegister[] registers, RegisterInt accumulator, Dictionary<string, int> tagMap) {
      return value_;
    }
  }
}