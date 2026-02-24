namespace DAA_RAM_simulator.src.Operands {
  public class TagOperand : IOperand {
    private string tag;

    public TagOperand(string expression) {
      if (string.IsNullOrWhiteSpace(expression)) {
        throw new ArgumentException("El tag no puede estar vacío o ser solo espacios en blanco.", nameof(expression));
      }
      tag = expression;
    }

    public int GetValue(IRegister[] registers, RegisterInt accumulator, Dictionary<string, int> tagMap) {
      if (tagMap == null) {
        throw new ArgumentNullException(nameof(tagMap), "El diccionario de etiquetas no puede ser nulo.");
      }
      if (!tagMap.ContainsKey(tag)) {
        throw new KeyNotFoundException($"El tag '{tag}' no fue encontrado en el mapa de etiquetas.");
      }
      return tagMap[tag];
    }
  }
}