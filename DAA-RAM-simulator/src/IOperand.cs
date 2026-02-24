namespace DAA_RAM_simulator.src {
  public interface IOperand {
    public int GetValue(IRegister[] registers, RegisterInt accumulator, Dictionary<string, int> tagMap);
  }
}