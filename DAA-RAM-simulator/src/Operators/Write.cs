namespace DAA_RAM_simulator.src.Operators {
  public class Write : IOperator {
    public Write() {}
    public void Solve(IRegister[] registers, RegisterInt accumulator, InputTape inputTape, OutputTape outputTape, ref int programCounter, int value, bool vectorialRegisters) {
      outputTape.Write(value);
    }
  }
}