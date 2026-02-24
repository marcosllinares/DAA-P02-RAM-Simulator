namespace DAA_RAM_simulator.src {
  public interface IOperator {
    public void Solve(IRegister[] registers, RegisterInt accumulator, InputTape inputTape, OutputTape outputTape, ref int programCounter, int value, bool vectorialRegisters);
  }
}