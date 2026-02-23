namespace DAA_RAM_simulator.src.Operators {
  public class Jgtz : IOperator {
    // Constructor de la clase Jgtz
    public Jgtz() {}
    // Ejecuta la instrucción Jgtz
    public void Solve(int[] registers, InputTape inputTape, OutputTape outputTape, ref int programCounter, int value) {
      if (registers[0] > 0) {
        programCounter = value;
      }
    }
  }
}