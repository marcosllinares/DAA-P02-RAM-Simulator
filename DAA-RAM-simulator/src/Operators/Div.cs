namespace DAA_RAM_simulator.src.Operators {
  public class Div : IOperator {
    public Div() {}
    public void Solve(IRegister[] registers, RegisterInt accumulator, InputTape inputTape, OutputTape outputTape, ref int programCounter, int value, bool vectorialRegisters) {
      accumulator.SetData(accumulator.GetData() / value);
    }
  }
}