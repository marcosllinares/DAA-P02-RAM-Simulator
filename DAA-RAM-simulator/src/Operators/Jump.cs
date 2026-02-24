namespace DAA_RAM_simulator.src.Operators {
  public class Jump : IOperator {
    public Jump() {}
    public void Solve(IRegister[] registers, RegisterInt accumulator, InputTape inputTape, OutputTape outputTape, ref int programCounter, int value, bool vectorialRegisters) {
      // Jump to the address specified by the value
      programCounter = value;
    }
  }
}