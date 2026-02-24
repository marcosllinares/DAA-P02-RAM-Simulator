using System.Data;

namespace DAA_RAM_simulator.src {
  public class RegisterVector : IRegister {
    List<int> data_;
    
    // Constructor por defecto
    public RegisterVector() {
      data_ = new List<int>();
    }

    // Constructor con parámetros lista de enteros
    public RegisterVector(List<int> data) {
      data_ = data;
    }
    // Devuelve el tamaño de data
    public int GetSize() { return data_.Count; }
    // Devuelve el valor de data en la posición index en la lista de enteros
    public int GetData(int index) { return data_[index]; }
    // Establece el valor de data en la posición index en la lista de enteros
    public void SetData(int data, int index) { data_[index] = data; }
    // Añade un elemento a la lista de enteros mediante el método Add
    public void PushData(int element) { data_.Add(element); }
  }
}