namespace DAA_RAM_simulator.src {
  public interface IRegister {
    public int GetData(int index = -1);
    public void SetData(int value, int index = -1);
    public void PushData(int value);
    public int GetSize();
  }
}