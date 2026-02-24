using DAA_RAM_simulator.src.Operands;
using DAA_RAM_simulator.src.Operators;


namespace DAA_RAM_simulator.src {
  public class Instruction {
    private IOperand operand_;
    private IOperator operator_;
    // true si el operando directo devuelve el contenido del registro
    // false si el operando directo devuelve el indice del registro
    private bool registerValueAccessType;
    public Instruction(string operator1, bool vectorialRegisters, string operand = " ") {
      CheckValidInstruction(operator1, operand);
      registerValueAccessType = true; // Por defecto el operando directo devuelve el contenido del registro, cambia si es necesario
      operator_ = ConstructOperator(operator1);
      operand_ = ConstructOperand(operand, vectorialRegisters);      
    }

    private void CheckValidInstruction(string operator1, string operand) {
      int auxiliar;
          // Comprueba que el operando vacío solo se usa con HALT
      if ((operator1 != "HALT" && operand == " ")  ||
          // Comprueba que una etiqueta solo se puede usar como operando en JUMP (o sus variantes)
         (operator1 != "JUMP" && operator1 != "JZERO" && operator1 != "JGTZ" &&
          operand != " " && operand[0] != '=' && operand[0] != '*' && !int.TryParse(operand, out auxiliar) && operand[^1] != ']') ||
          // Comprueba que el operando indirecto se usa con un operador adecuado
         ((operand[0] == '*' || int.TryParse(operand, out auxiliar)) &&
          (operator1 == "JUMP" || operator1 == "JZERO" || operator1 == "JGTZ" || operator1 == "HALT")) ||
          // Comprueba que el operando inmediato se usa con un operador adecuado
         ((operand[0] == '=') && operator1 != "LOAD" && operator1 != "ADD" &&
           operator1 != "SUB" && operator1 != "MUL" && operator1 != "DIV" && operator1 != "WRITE") ||
           // Casos específicos que no debe permitir nuestro programa
         ((operator1 == "READ" || operator1 == "WRITE") && (operand == "0"))) {
        throw new Exception($"El operador {operator1} no puede tener el operando {operand}.");
      }
    }

    private IOperator ConstructOperator(string operator1) {
      switch (operator1) {
        case "LOAD":
          return new Load();
        case "STORE":
          registerValueAccessType = false;
          return new Store();
        case "ADD":
          return new Add();
        case "SUB":
          return new Sub();
        case "MUL":
          return new Mul();
        case "DIV":
          return new Div();
        case "JUMP":
          return new Jump();
        case "JZERO":
          return new Jzero();
        case "JGTZ":
          return new Jgtz();
        case "READ":
          registerValueAccessType = false;
          return new Read();
        case "WRITE":
          return new Write();
        case "HALT":
          return new Halt();
        default:
          throw new Exception($"El operator {operator1} es ajeno a las instrucciones de la RAM.");
      }
    }

    private IOperand ConstructOperand(string operand, bool vectorialRegisters) {
      // Cambios según el tipo de operador
      bool a;
      if (operand == " ") {
        return new NullOperand(operand);
      } else if (operand[0] == '=') {
        return new Immediate(operand);
      } else  if (operand[0] == '*') {
        return registerValueAccessType ? new IndirectValue(operand) : new IndirectRegister(operand);
      } else if (int.TryParse(operand, out int auxiliar)) {
        return registerValueAccessType ? new DirectValueInt(operand) : new DirectRegisterInt(operand);
      } else if (a = operand.Contains('[')) {  
        return registerValueAccessType ? new DirectValueVector(operand) : new DirectRegisterVector(operand);
      } else {
        return new TagOperand(operand);
      }
    }

    public IOperator GetOperator() { return operator_; }
    public IOperand GetOperand() { return operand_; }
    public bool GetRegisterValueAccessType() { return registerValueAccessType; }
  }
}