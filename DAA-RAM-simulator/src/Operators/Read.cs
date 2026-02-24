namespace DAA_RAM_simulator.src.Operators {
  public class Read : IOperator {
    public Read() {}
    // Solve en el operando READ utiliza una función biyectiva para codificar: f(n) = a * 1000 + b. La decodificación: a = n / 1000, b = n % 1000  
    public void Solve(IRegister[] registers, RegisterInt accumulator, InputTape inputTape, OutputTape outputTape, ref int programCounter, int value, bool vectorialRegisters) {
      if (vectorialRegisters) {
        if (registers[(value / 1000) - 1].GetSize() == (value % 1000)) {
          registers[(value / 1000) - 1].PushData(inputTape.Read());
        } else {
          registers[(value / 1000) - 1].SetData(inputTape.Read(), value % 1000);
        }
      } else {
        // Reads from inputTape and stores in register 0
        registers[value - 1].SetData(inputTape.Read());
      }
    }
  }
}