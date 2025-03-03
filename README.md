# QuantumDemo-Grover

## 🔍 Grover's Algorithm in C# and Q#

This project demonstrates **Grover's Algorithm**, a quantum search algorithm that can search an unsorted dataset significantly faster than classical methods. We compare classical search in C# against quantum search in Q#.

## 🚀 Project Overview

### Classical Search (C#)
- Uses `Array.IndexOf()` for a **linear search (O(N))**.
- Searches for a target number in a **1 billion** integer dataset.
- Measures and reports search time in milliseconds.

### Quantum Search (Q#)
- Implements **Grover's Algorithm (O(√N))**.
- Uses **superposition, phase flip, and interference** to amplify the correct result.
- Simulates quantum execution since real quantum hardware is not used.

## 📂 Project Structure
```
QuantumDemo-Grover/
│── ClassicalSearch/         # C# console app for classical search
│   ├── Program.cs           # Implements Array.IndexOf() search
│── QuantumSearch/           # Q# project for quantum search
│   ├── Grover.qs            # Implements Grover's Algorithm
│── README.md                # This documentation
│── QuantumDemo-Grover.sln   # Solution file
```

## ⚡ Running the Project
### 1️⃣ Prerequisites
- **.NET SDK** (latest version) - [Download Here](https://dotnet.microsoft.com/en-us/download)
- **Microsoft Quantum Development Kit (QDK)** - [Setup Guide](https://learn.microsoft.com/en-us/azure/quantum/install-overview-qdk)
- **Q# SDK & VS Code/Visual Studio** (for Q# development)

### 2️⃣ Clone the Repository
```sh
git clone https://github.com/tjgokken/QuantumDemo-Grover.git
cd QuantumDemo-Grover
```

### 3️⃣ Run Classical Search (C#)
```sh
dotnet run --project ClassicalSearch
```

### 4️⃣ Run Quantum Search (Q#)
```sh
dotnet run --project QuantumSearch
```

## 🏆 Results Comparison
| Method              | Time Complexity | Execution Time |
|---------------------|----------------|---------------|
| **Classical Search** | O(N)           | ~155ms        |
| **Grover’s Algorithm** | O(√N)         | ~48ms        |

*Note:* Since this is a **quantum simulation** running on classical hardware, real-world quantum execution would be **orders of magnitude faster** (nanoseconds).

## 💡 Understanding Grover's Algorithm
1. **Superposition** → Spread all qubits across possible states.
2. **Oracle** → Marks the correct answer with a phase flip.
3. **Diffusion** → Amplifies the correct answer probability.
4. **Measurement** → Extracts the most likely answer.

## 📖 Learn More
- **Grover’s Algorithm Explanation**: [Read the Full Article](https://tjgokken.com/series/quantum-computing)
- **Microsoft QDK Docs**: [Quantum Development Kit](https://learn.microsoft.com/en-us/azure/quantum)

## 📜 License
This project is licensed under the **MIT License**.

## 🤝 Contributing
Feel free to submit **pull requests** or report **issues**!

## 🔗 Connect
📧 **Contact**: [tjgokken.com](https://tjgokken.com)
