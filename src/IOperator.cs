namespace DAA_RAM_simulator.src {
  public interface IOperator {
    // Metodo definido en la interfaz IOperator
    public void Solve(int[] registers, InputTape inputTape, OutputTape outputTape, ref int programCounter, int value);
  }
}