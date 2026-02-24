# DAA-RAM-simulator

Universidad de La Laguna

Escuela Superior de Ingeniería y Tecnología

Grado en Ingeniería Informática

Asignatura: Diseño y Análisis de Algoritmos

Curso: 3º

Autores:
  - Marcos Llinares Montes. alu0100972443@ull.edu.es
  - Gerard Caramazza Vilá.  alu0101229775@ull.edu.es

##### Consideraciones generales

Dependiendo de la versión de .NET Core, el comando `dotnet run` puede no funcionar correctamente
si no se ejecuta con la misma versión que la especificada en `DAA-RAM-simulator.csproj`.

En ese caso cambiar la versión de .NET Core en `DAA-RAM-simulator.csproj` a: `<TargetFramework>net9.0</TargetFramework>`.

##### Ejecución normal del programa. Rama `version1`

- Formato de Ejecución: `dotnet run <archivo de programa> <archivo de entrada> <archivo de salida>`.
- Ejemplo:          `dotnet run data/Ejemplos_RAM/test1.ram data/input.txt data/output.txt`.

##### Ejecución del programa con ampliación. Rama `main`

- Formato de Ejecución: `dotnet run <archivo de programa> <archivo de entrada> <archivo de salida>`.

Además de lo anterior se pregunta por terminal al usuario que tipo de registro quiere utilizar:

- `¿Desea utilizar registros vectoriales (s/n)?`