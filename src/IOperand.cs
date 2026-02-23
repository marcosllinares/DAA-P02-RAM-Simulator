namespace DAA_RAM_simulator.src {
  public interface IOperand {
    // Metodo definido en la interfaz IOperand
    public int GetValue(int[] registers, Dictionary<string, int> tagMap);
  }
}