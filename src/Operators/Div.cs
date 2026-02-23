namespace DAA_RAM_simulator.src.Operators {
  public class Div : IOperator {
    // Constructor de la clase Div
    public Div() {}
    // Ejecuta la operación de división
    public void Solve(int[] registers, InputTape inputTape, OutputTape outputTape, ref int programCounter, int value) {
      registers[0] /= value;
    }
  }
}