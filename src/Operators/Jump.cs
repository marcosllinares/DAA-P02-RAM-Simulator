namespace DAA_RAM_simulator.src.Operators {
  public class Jump : IOperator {
    // Constructor de la clase Jump
    public Jump() {}
    // Ejecutar la instrucción Jump
    // Jump a reference of programCounter to the address specified by the value
    public void Solve(int[] registers, InputTape inputTape, OutputTape outputTape, ref int programCounter, int value) {
      programCounter = value;
    }
  }
}