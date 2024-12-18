# DNA Sequence Alignment using Dynamic Programming

This project implements DNA sequence alignment using Dynamic Programming (DP), specifically focusing on the Needleman-Wunsch algorithm for global alignment. The application allows users to input two DNA sequences, align them, and visualize the alignment along with the similarity score, non-similarity score, and gap penalties.

## Features

- Implements the Needleman-Wunsch algorithm.
- Supports affine gap penalties for biologically meaningful alignments.
- Efficiently aligns DNA sequences using dynamic programming.
- Includes an intuitive user interface for input and visualization of results.

## Getting Started

## Technologies Used

C#: The application is developed using C# programming language.
Windows Forms: Provides the GUI for the application.
Dynamic Programming: Used to calculate the optimal alignment of two DNA sequences.

### Installation

1. Clone this repository:
   ```bash
   git clone https://github.com/hekurani/Biological_Sequence_Alignment_Using_Dynamic_Programming_Grupi26.git
2. Open the project in Visual Studio.
3. Build and run the project.

### Usage

1. Launch the application.
2. Input two DNA sequences to align.
3. Adjust scoring parameters (match, mismatch, gap opening, and gap extension penalties) as needed.
4. Run the alignment to view the results.

### Algorithm Used

This project implements the Needleman-Wunsch algorithm, which is a dynamic programming approach to sequence alignment. The algorithm computes the optimal alignment of two sequences by constructing a matrix and filling it with alignment scores based on similarity, non-similarity, and gap penalties.

Needleman-Wunsch Algorithm

Initialize the scoring matrix.
Fill the matrix using the similarity and gap penalties.
Traceback to find the optimal alignment by backtracking through the matrix.
Display the alignment and calculate scores (similarity, non-similarity, and gap penalties).

### Contributors

* Anila Luta
* Albiona Mustafa
* Dion Gashi
* Hekuran Kokolli
