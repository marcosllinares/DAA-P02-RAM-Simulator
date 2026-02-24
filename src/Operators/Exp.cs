namespace DAA_RAM_simulator.src.Operators {
  public class Exp : IOperator {
    // Constructor de la clase Exp
    public Exp() {}
    // Ejecuta la operación de exponenciación: R0 = R0^value
    public void Solve(int[] registers, InputTape inputTape, OutputTape outputTape, ref int programCounter, int value) {
      int baseValue = registers[0];
      int exponent = value;
      int result = 1;
      
      // Calculamos la potencia mediante multiplicaciones sucesivas
      for (int i = 0; i < exponent; i++) {
        result *= baseValue;
      }
      
      registers[0] = result;
    }
  }
}
