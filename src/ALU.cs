namespace DAA_RAM_simulator.src {
  public class ALU {
    int programCounter_;
    int complexityProgram_;

    // Constructor de la clase ALU
    public ALU() {
      programCounter_ = 0;
      complexityProgram_ = 0;
    }
    
    // Ejecutar el programa
    public void Execute(List<Instruction> memoryProgram, int[] registers, Dictionary<string, int> tagMap, InputTape inputTape, OutputTape outputTape) {
      int value;
      int actualProgramCounter;
      while (programCounter_ < memoryProgram.Count) {
        // GetValue() obtiene el valor literal ya transformado según el tipo de operando
        value = memoryProgram[programCounter_].GetOperand().GetValue(registers, tagMap);
        actualProgramCounter = programCounter_; 
        // Solve() ejecuta la instrucción según el operador y el value literal obtenido
        memoryProgram[programCounter_].GetOperator().Solve(registers, inputTape, outputTape, ref programCounter_, value);
        // Si programCounter_ cambio durante la ejecución de la instrucción significa que un salto tuvo exito
        if (actualProgramCounter == programCounter_) {
          programCounter_++;
        }
        complexityProgram_++;
      }
      // Guardar la salida en outputTape
      outputTape.WriteToFile();
      Console.WriteLine("Terminó con éxito.");
    }

    // Devuelve la complejidad del programa
    public int GetComplexityProgram() {
      return complexityProgram_;
    }
  }
}