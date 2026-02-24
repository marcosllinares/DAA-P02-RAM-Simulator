namespace DAA_RAM_simulator.src {
  public class ALU {
    int programCounter_;
    int complexityProgram_;

    public ALU() {
      programCounter_ = 0;
      complexityProgram_ = 0;
    }
    public void Execute(List<Instruction> memoryProgram, IRegister[] registers, RegisterInt accumulator, Dictionary<string, int> tagMap, InputTape inputTape, OutputTape outputTape, bool vectorialRegisters) {
      // Ejecutar el programa
      int value;
      int actualProgramCounter;
      while (programCounter_ < memoryProgram.Count) {
        value = memoryProgram[programCounter_].GetOperand().GetValue(registers, accumulator, tagMap);
        actualProgramCounter = programCounter_; 
        memoryProgram[programCounter_].GetOperator().Solve(registers, accumulator, inputTape, outputTape, ref programCounter_, value, vectorialRegisters);
        // Si programCounter_ cambio durante la ejecución de la instrucción significa un salto tuvo exito
        if (actualProgramCounter == programCounter_) {
          programCounter_++;
        }
        complexityProgram_++;
      }
      // Guardar la salida en outputTape
      outputTape.WriteToFile();
      Console.WriteLine("Terminó con éxito.");
    }

    // Devuelve el valor complejidad del programa
    public int GetComplexityProgram() {
      return complexityProgram_;
    }
  }
}