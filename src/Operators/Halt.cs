namespace DAA_RAM_simulator.src.Operators {
  public class Halt : IOperator {
    // Constructor de la clase Halt
    public Halt() {}
    // Ejecutar la instrucción HALT 
    public void Solve(int[] registers, InputTape inputTape, OutputTape outputTape, ref int programCounter, int value) {
      // Guardar la salida en outputTape
      outputTape.WriteToFile();
      Console.WriteLine("Terminó con éxito.");
      // Salir del programa
      Environment.Exit(0);
    }
  }
}