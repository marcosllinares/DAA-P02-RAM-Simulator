namespace DAA_RAM_simulator.src.Operators {
  public class Sub : IOperator {
    // Constructor de la clase Sub
    public Sub() {}
    // Ejecuta la operación de resta
    public void Solve(int[] registers, InputTape inputTape, OutputTape outputTape, ref int programCounter, int value) {
      registers[0] -= value;
    }
  }
}