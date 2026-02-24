namespace DAA_RAM_simulator.src.Operators {
  public class Store : IOperator {
    public Store() {}
    public void Solve(IRegister[] registers, RegisterInt accumulator, InputTape inputTape, OutputTape outputTape, ref int programCounter, int value, bool vectorialRegisters) {
      if (vectorialRegisters) {
        if (registers[(value / 1000) - 1].GetSize() == (value % 1000)) {
          registers[(value / 1000) - 1].PushData(accumulator.GetData());
        } else {
          registers[(value / 1000) - 1].SetData(accumulator.GetData(), value % 1000);
        }
      } else {
        registers[value - 1].SetData(accumulator.GetData());
      }
    }
  }
}