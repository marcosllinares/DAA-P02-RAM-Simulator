namespace DAA_RAM_simulator.src.Operators {
  public class Jgtz : IOperator {
    public Jgtz() {}
    public void Solve(IRegister[] registers, RegisterInt accumulator, InputTape inputTape, OutputTape outputTape, ref int programCounter, int value, bool vectorialRegisters) {
      if (accumulator.GetData() > 0) {
        programCounter = value;
      }
    }
  }
}