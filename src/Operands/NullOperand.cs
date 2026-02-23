namespace DAA_RAM_simulator.src.Operands {
  public class NullOperand : IOperand {
    private string nullValue_;

    // Constructor de la clase NullOperand
    public NullOperand(string expression) {
      nullValue_ = expression;
    }

    // Método GetValue de la interfaz IOperand pero no es relevante
    public int GetValue(int[] registers, Dictionary<string, int> tagMap) {
      // Devuelve 0, pero no se usa
      return 0;
    }
  }
}