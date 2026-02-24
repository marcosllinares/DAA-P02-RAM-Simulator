using DAA_RAM_simulator.src.Operands;
using DAA_RAM_simulator.src.Operators;

namespace DAA_RAM_simulator.src {
  public class Instruction {
    private IOperand operand_;
    private IOperator operator_;
    // true si el operando directo devuelve el contenido del registro
    // false si el operando directo devuelve el indice del registro
    private bool registerValueAccessType;

    // Constructor de la clase Instruction
    public Instruction(string operator1, string operand = " ") {
      CheckValidInstruction(operator1, operand);
      registerValueAccessType = true; // Por defecto el operando directo devuelve el contenido del registro, cambia si es necesario
      operator_ = ConstructOperator(operator1);
      operand_ = ConstructOperand(operand);      
    }

    // Devuelve el operador correspondiente y asigna el booleano registerValueAccessType
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
        case "EXP":
          return new Exp();
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

    // Devuelve el operando correspondiente
    private IOperand ConstructOperand(string operand) {
      // Cambios según el tipo de operador
      if (operand == " ") {
        return new NullOperand(operand);
      } else if (operand[0] == '=') {
        return new Immediate(operand);
      } else  if (operand[0] == '*') {
        // Tenemos en cuenta que el operando puede devolver índice del registro o el valor del registro 
        // dependiendo del operador: (STORE o READ) VS el resto
        return registerValueAccessType ? new IndirectValue(operand) : new IndirectRegister(operand);
      } else if (int.TryParse(operand, out int auxiliar)) {
        return registerValueAccessType ? new DirectValue(operand) : new DirectRegister(operand);
      } else {
        return new TagOperand(operand);
      }
    }

    // Comprueba si la instrucción es válida
    private void CheckValidInstruction(string operator1, string operand) {
      int auxiliar;
      if ((operator1 != "HALT" && operand == " ")  ||
         (operator1 != "JUMP" && operator1 != "JZERO" && operator1 != "JGTZ" &&
          operand != " " && operand[0] != '=' && operand[0] != '*' && !int.TryParse(operand, out auxiliar)) ||
         ((operand[0] == '*' || int.TryParse(operand, out auxiliar)) &&
          (operator1 == "JUMP" || operator1 == "JZERO" || operator1 == "JGTZ" || operator1 == "HALT")) ||
         ((operand[0] == '=') && operator1 != "LOAD" && operator1 != "ADD" &&
           operator1 != "SUB" && operator1 != "MUL" && operator1 != "DIV" && operator1 != "EXP" && operator1 != "WRITE") ||
         ((operator1 == "READ" || operator1 == "WRITE") && (operand == "0"))) {
        throw new Exception($"El operador {operator1} no puede tener el operando {operand}.");
      }
    }

    // Devuelve el operador
    public IOperator GetOperator() {
      return operator_;
    }

    // Devuelve el operando
    public IOperand GetOperand() {
      return operand_;
    }

    // Devuelve el booleano registerValueAccessType 
    public bool GetRegisterValueAccessType() {
      return registerValueAccessType;
    }
  }
}