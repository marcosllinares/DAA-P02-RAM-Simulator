namespace DAA_RAM_simulator.src.Operands {
  public class NullOperand : IOperand {
    private string nullValue_;

    public NullOperand(string expression) {
      nullValue_ = expression;
    }

    public int GetValue(IRegister[] registers, RegisterInt accumulator, Dictionary<string, int> tagMap) {
      return 0;
    }
  }
}