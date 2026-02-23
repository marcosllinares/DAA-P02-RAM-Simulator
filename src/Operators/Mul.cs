namespace DAA_RAM_simulator.src.Operators {
  public class Mul : IOperator {
    // Constructor de la clase Mul
    public Mul() {}
    // Ejecuta la operación de multiplicación
    public void Solve(int[] registers, InputTape inputTape, OutputTape outputTape, ref int programCounter, int value) {
      registers[0] *= value;
    }
  }
}