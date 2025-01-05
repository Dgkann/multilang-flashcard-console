# Console-Based Flashcard Study Application

## Table of Contents

1. [Link](#link)  
2. [Description](#description)  
3. [Purpose](#purpose)  
4. [Features](#features)  
5. [Technologies Used](#technologies-used)  
    - [Python Version](#python-version)  
    - [C# Version](#c-version)  
    - [JavaScript Version](#javascript-version)  
6. [Installation & Setup](#installation--setup)  
    - [Prerequisites](#prerequisites)  
    - [Running Each Version](#running-each-version)  
7. [Project Structure](#project-structure)  
8. [Console Interface Examples](#console-interface-examples)  
    - [Main Menu](#main-menu)  
    - [Adding Flashcards](#adding-flashcards)  
    - [Study Mode](#study-mode)  
9. [Data Storage](#data-storage)  
10. [Core Functions](#core-functions)  
11. [Version Information](#version-information)  
12. [Team Members & Contact](#team-members--contact)

---

## Link
- GitHub Repository: [https://github.com/Dgkann/multilang-flashcard-console](https://github.com/Dgkann/multilang-flashcard-console)

---

## Description
The Console-Based Flashcard Study Application is implemented in three different programming languages (C#, Python, and JavaScript), each running as standalone console applications. This project provides a simple and effective way to study using flashcards through a text-based interface.

---

## Purpose
This project aims to help students and learners create and review flashcards using a simple console interface. Each implementation (C#, Python, JavaScript) demonstrates identical functionality while showcasing different programming approaches across languages.

---

## Features
- Create and remove flashcards with questions and answers.
- Study flashcards in randomized order with score tracking.
- View all flashcards in the deck.
- Persistent storage using JSON for saving and loading flashcards.
- Simple console-based interface with clear prompts.

---

## Technologies Used

### Python Version:
- Python 3.x
- JSON for data storage
- Built-in libraries for console interaction

### C# Version:
- .NET Core SDK
- Console Application
- File I/O for JSON-based data persistence

### JavaScript Version:
- Node.js
- `readline` module for console input
- JSON file handling

---

## Installation & Setup

### Prerequisites
1. Python 3.x (for the Python version)
2. .NET Core SDK (for the C# version)
3. Node.js (for the JavaScript version)

### Running Each Version

1. **Python Version**:
   ```bash
   cd python_version
   python flashcard_app.py
   ```

2. **C# Version**:
   ```bash
   cd csharp_version
   dotnet run
   ```

3. **JavaScript Version**:
   ```bash
   cd javascript_version
   node flashcard_app.js
   ```

---

## Project Structure
```
flashcard-study-app/
│
├── python_version/
│   ├── flashcard_app.py
│   └── cards.json
│
├── csharp_version/
│   ├── Program.cs
│   ├── FlashcardApp.csproj
│   └── cards.json
│
├── javascript_version/
│   ├── flashcard_app.js
│   └── cards.json
│
└── README.md
```

---

## Console Interface Examples

### Main Menu
```
=== Flashcard Study App ===
1. Add new card
2. Study cards
3. List all cards
4. Remove card
5. Exit
```

### Adding Flashcards
```
Enter the question: [Your question]
Enter the answer: [Your answer]
```

### Study Mode
```
Card 1/5
Question: [Question appears here]
Press Enter to see the answer...
Answer: [Answer appears here] 
Did you get it right? (y/n):
```

---

## Data Storage
Each implementation uses a simple JSON structure for storing flashcards:
```json
[
    {
        "question": "What is JSON?",
        "answer": "JavaScript Object Notation"
    }
]
```

---

## Core Functions

### 1. Card Operations
- `addCard(question, answer)` (Add a new flashcard)
- `removeCard(index)` (Remove a flashcard by index)

### 2. Study Features
- `study()` (Study cards in randomized order with score tracking)
- `loadCards()` (Load flashcards from JSON)
- `saveCards()` (Save flashcards to JSON)

---

## Version Information
- Current Version: 1.0.0
- Last Updated: 14.11.2024
- Status: In Development

---

## Team Members & Contact

### Python Version
- Developer: Mustafa Bozteke  
- Student ID: 210302348

### C# Version
- Developer: Doğukan Yurttürk  
- Student ID: 220302455

### JavaScript Version
- Developer: Omar Ben Sulaiman  
- Student ID: 230302506
