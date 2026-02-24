namespace DAA_RAM_simulator.src.Operands {
  public class IndirectValue : IOperand {
    private int value_;

    public IndirectValue (string expression) {
      value_ = int.Parse(expression.Substring(1));
    }

    public int GetValue(IRegister[] registers, RegisterInt accumulator, Dictionary<string, int> tagMap) {
      int newRegisterIndex = (value_ == 0) ? accumulator.GetData() : registers[value_ - 1].GetData();
      return (newRegisterIndex == 0) ? accumulator.GetData() : registers[newRegisterIndex - 1].GetData();
    }
  }
}