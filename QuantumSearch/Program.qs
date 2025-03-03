namespace QuantumSearch {
    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Measurement;

    // Oracle: Marks the correct answer in the superposition
    operation Oracle(qubits: Qubit[]) : Unit is Adj {
        // Apply phase flip to the marked state
        Controlled Z(qubits[0..14], qubits[15]);
    }

    operation GroversAlgorithm() : Int {
        use qubits = Qubit[16];

        // Step 1: Put all qubits into superposition
        for q in qubits { H(q); }

        // Step 2: Apply Grover’s Search Algorithm
        let iterations = 30;  // Roughly sqrt(2^16) for optimal search
        for _ in 1..iterations {
            Oracle(qubits);  // Apply Oracle (marks the solution)
            
            // Apply Grover Diffusion Operator
            for q in qubits { H(q); X(q); }
            Controlled Z(qubits[0..14], qubits[15]); // Multi-qubit phase flip
            for q in qubits { X(q); H(q); }
        }

        // Step 3: Measure all qubits and store results in a mutable array
        mutable results = [];
        for q in qubits {
            set results += [M(q)];
        }

        let resultInt = ResultArrayAsInt(results);

        ResetAll(qubits);
        return resultInt;
    }

    // Function to Convert Measurement Results to Integer
    function ResultArrayAsInt(results: Result[]) : Int {
        mutable value = 0;
        for i in 0..Length(results)-1 {
            if results[i] == One {
                set value = value + (1 <<< i);
            }
        }
        return value;
    }
}
