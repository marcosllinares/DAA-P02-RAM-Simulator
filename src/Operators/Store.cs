namespace DAA_RAM_simulator.src.Operators {
  public class Store : IOperator {
    // Constructor de la clase Store
    public Store() {}
    // Ejecuta la instrucción STORE
    public void Solve(int[] registers, InputTape inputTape, OutputTape outputTape, ref int programCounter, int value) {
      registers[value] = registers[0];
    }
  }
}