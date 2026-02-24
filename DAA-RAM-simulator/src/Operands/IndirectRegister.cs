namespace DAA_RAM_simulator.src.Operands {
  public class IndirectRegister : IOperand {
    private int value_;

    public IndirectRegister (string expression) {
      value_ = int.Parse(expression.Substring(1));
    }

    public int GetValue(IRegister[] registers, RegisterInt accumulator, Dictionary<string, int> tagMap) {
      return (value_ == 0) ? accumulator.GetData() : registers[value_ - 1].GetData();
    }
  }
}