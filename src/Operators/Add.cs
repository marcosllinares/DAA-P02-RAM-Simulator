namespace DAA_RAM_simulator.src.Operators {
  public class Add : IOperator {
    // Constructor de la clase Add
    public Add() { }
    // Suma el valor al registro 0
    public void Solve(int[] registers, InputTape inputTape, OutputTape outputTape, ref int programCounter, int value) {
      registers[0] += value;
    }
  }
}