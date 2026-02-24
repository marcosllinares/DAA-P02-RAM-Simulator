namespace DAA_RAM_simulator.src {
  public class OutputTape {
    private LinkedList<int> tape_;
    string outputFile_;

    // Constructor de la clase OutputTape
    public OutputTape(string outputFile) {
      outputFile_ = outputFile;
      tape_ = new LinkedList<int>();
    }

    // Write the value in the tape_
    public void Write(int value) {
      tape_.AddLast(value);
    }

    // Write the tape_ to the output file
    public void WriteToFile() {
      using StreamWriter streamWriter = new (outputFile_); 
      foreach (int value in tape_) {
        streamWriter.Write(value + " ");
      }
    }
  }
}