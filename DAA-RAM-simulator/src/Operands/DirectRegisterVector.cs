namespace DAA_RAM_simulator.src.Operands {
  public class DirectRegisterVector : IOperand {
    private int value_;
    private int index_;

    public DirectRegisterVector(string expression) {
      int firstBracket = expression.IndexOf('[');
      int lastBracket = expression.IndexOf(']');
      if (firstBracket - 1 == 0) {
        value_ = expression[0] - '0';
      } else {
        value_ = int.Parse(expression.Substring(0, firstBracket - 1));
      }
      if (firstBracket + 1 == lastBracket - 1) {
        index_ = expression[firstBracket + 1] - '0';
      } else { 
        index_ = int.Parse(expression.Substring(firstBracket + 1, lastBracket - 1));
      }
    }

    public int GetValue(IRegister[] registers, RegisterInt accumulator, Dictionary<string, int> tagMap) {
      return value_ * 1000 + index_;
    }
  }
}