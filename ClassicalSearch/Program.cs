using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;
using QuantumSearch;

internal class Program
{
    private static void Main()
    {
        const int N = 1_000_000_000; // 1 billion records

        Console.WriteLine($"Generating {N:N0} random numbers for classical search...");
        var random = new Random();
        var data = Enumerable.Range(0, N).Select(_ => random.Next(N)).ToArray();

        var target = data[random.Next(N)]; // Pick a random number from the dataset
        Console.WriteLine($"Searching for: {target}");

        // ⏳ Time Classical Search
        var stopwatch = Stopwatch.StartNew();
        var index = Array.IndexOf(data, target); // Linear search
        stopwatch.Stop();
        var classicalTimeMs = stopwatch.ElapsedTicks / (Stopwatch.Frequency / 1_000.0);

        Console.WriteLine($"Classical search found index {index} in {classicalTimeMs:F3} ms.");

        // 🛠 Run Grover’s Algorithm (Simulated via DLL)
        Console.WriteLine("\nRunning Grover's Algorithm using Q#...");
        using (var simulator = new QuantumSimulator())
        {
            stopwatch.Restart();

            var groverResult = GroversAlgorithm.Run(simulator).Result;

            stopwatch.Stop();
            var quantumTimeMs = stopwatch.ElapsedTicks / (Stopwatch.Frequency / 1_000.0);

            Console.WriteLine($"Grover’s Algorithm found: {groverResult}");
            Console.WriteLine($"Quantum execution time: {quantumTimeMs:F3} ms.");

            // 📊 Print Comparison Table
            Console.WriteLine("\nComparison of Classical vs Quantum Search:");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("| Method                | Time Taken  | Complexity  |");
            Console.WriteLine("|-----------------------|------------|-------------|");
            Console.WriteLine($"| Classical Search      | {classicalTimeMs:F3} ms  | O(N)       |");
            Console.WriteLine($"| Grover’s Algorithm   | {quantumTimeMs:F3} ms  | O(√N)      |");
            Console.WriteLine("-------------------------------------------------");
        }
    }
}
