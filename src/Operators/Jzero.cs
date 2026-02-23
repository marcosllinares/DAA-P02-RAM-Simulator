namespace DAA_RAM_simulator.src.Operators {
  public class Jzero : IOperator {
    // Constructor de la clase Jzero
    public Jzero() {}
    // Ejecuta la instrucción Jzero
    public void Solve(int[] registers, InputTape inputTape, OutputTape outputTape, ref int programCounter, int value) {
      if (registers[0] == 0) {
        programCounter = value;
      }
    }
  }
}