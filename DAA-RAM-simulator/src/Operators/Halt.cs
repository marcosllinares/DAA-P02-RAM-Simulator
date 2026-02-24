namespace DAA_RAM_simulator.src.Operators {
  public class Halt : IOperator {
    public Halt() {}
    public void Solve(IRegister[] registers, RegisterInt accumulator, InputTape inputTape, OutputTape outputTape, ref int programCounter, int value, bool vectorialRegisters) {
      // Halt
      outputTape.WriteToFile();
      Console.WriteLine("Terminó con éxito.");
      Environment.Exit(0);
    }
  }
}