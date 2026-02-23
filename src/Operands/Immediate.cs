namespace DAA_RAM_simulator.src.Operands {
  public class Immediate : IOperand {
    private int value_;
    
    // Constructor de la clase Immediate
    public Immediate(string expression) {
      // Elimina el '=' y convierte el valor a entero
      value_ = int.Parse(expression.Substring(1));
    }

    // Devuelve el valor del operando, en este caso el valor literal
    public int GetValue(int[] registers, Dictionary<string, int> tagMap) {
      return value_;
    }
  }
}