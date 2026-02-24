namespace DAA_RAM_simulator.src.Operands {
  public class DirectValueInt : IOperand {
    private int value_;

    public DirectValueInt(string expression) {
      value_ = int.Parse(expression);
    }

    public int GetValue(IRegister[] registers, RegisterInt accumulator, Dictionary<string, int> tagMap) {
      return (value_ == 0) ? accumulator.GetData() : registers[value_ - 1].GetData();
    }
  }
}