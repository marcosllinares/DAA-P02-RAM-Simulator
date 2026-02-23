namespace DAA_RAM_simulator.src.Operators {
  public class Write : IOperator {
    // Constructor de la clase Write
    public Write() {}
    // Escribe el valor en la cinta de salida
    public void Solve(int[] registers, InputTape inputTape, OutputTape outputTape, ref int programCounter, int value) {
      outputTape.Write(value);
    }
  }
}