namespace DAA_RAM_simulator.src.Operators {
  public class Load : IOperator {
    public Load() {}
    public void Solve(IRegister[] registers, RegisterInt accumulator, InputTape inputTape, OutputTape outputTape, ref int programCounter, int value, bool vectorialRegisters) {
      accumulator.SetData(value);
    }
  }
}