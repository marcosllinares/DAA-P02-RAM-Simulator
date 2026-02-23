namespace DAA_RAM_simulator.src.Operators {
  public class Load : IOperator {
    // Constructor de la clase Load
    public Load() {}
    // Ejecuta la instrucción Load
    public void Solve(int[] registers, InputTape inputTape, OutputTape outputTape, ref int programCounter, int value) {
      registers[0] = value;
    }
  }
}