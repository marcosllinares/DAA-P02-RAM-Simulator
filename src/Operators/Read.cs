namespace DAA_RAM_simulator.src.Operators {
  public class Read : IOperator {
    // Constructor de la clase Read
    public Read() {}
    // Ejecuta la instrucción Read
    public void Solve(int[] registers, InputTape inputTape, OutputTape outputTape, ref int programCounter, int value) {
      // Reads from inputTape and stores in register[value]
      registers[value] = inputTape.Read();
    }
  }
}