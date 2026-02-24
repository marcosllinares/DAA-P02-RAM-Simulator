namespace DAA_RAM_simulator.src {
  public class RegisterInt : IRegister {
    int data_;
    
    // Constructor por defecto
    public RegisterInt() {
      data_ = int.MaxValue;
    }
    
    // Constructor con parámetro entero
    public RegisterInt(int data) {
      data_ = data;
    }

    // Devuelve 1, no se utiliza
    public int GetSize() { return 1; }
    // Devuelve el valor de data
    public int GetData(int index = -1) { return data_; }
    // Establece el valor de data, index no se utiliza
    public void SetData(int newValue, int index = -1) { data_ = newValue; }
    // No se utiliza
    public void PushData(int element) {}
  }
}