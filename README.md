# Console-Based Flashcard Study Application

## Link
- GitHub Repository: https://github.com/Dgkann/multilang-flashcard-console

## Description
The Console-Based Flashcard Study Application is implemented in three different programming languages (C#, Python, and JavaScript), each running as standalone console applications. This project demonstrates the same functionality across different languages while providing a simple yet effective way to study using flashcards through a text-based interface.

## Purpose
This project aims to help students and learners create and review flashcards through a simple console interface. Each implementation (C#, Python, JavaScript) provides identical functionality while showcasing different programming approaches across languages.

## Features
- **Create Flashcards**: Create new flashcards with terms and definitions
- **Manage Decks**: Create and organize multiple flashcard decks
- **Study Mode**: Review flashcards with immediate feedback
- **Progress Tracking**: Basic statistics for study sessions
- **Save/Load**: Store and retrieve flashcard decks
- **Simple Navigation**: Easy-to-use menu system

## Technologies Used

### Python Version:
- Python 3.x
- JSON for data storage
- Built-in libraries for console interaction

### C# Version:
- .NET Core SDK
- Console Application
- File I/O for data persistence

### JavaScript Version:
- Node.js
- readline module for console input
- JSON file handling

## Installation & Setup

### Prerequisites
- Python 3.x
- .NET Core SDK
- Node.js

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

## Console Interface Examples

### Main Menu
```
=== Flashcard Study Application ===
1. Create New Deck
2. Study Existing Deck
3. View Statistics
4. Exit
Choose an option (1-4):
```

### Creating Flashcards
```
Creating new flashcard:
Enter term: [User inputs term]
Enter definition: [User inputs definition]
Add another card? (y/n):
```

### Study Mode
```
Studying: [Deck Name]
Card 1/10
Term: [Front of card]
Press Enter to see definition...
Definition: [Back of card]
Did you know this? (y/n):
```

## Data Storage
The application uses a simple JSON structure for storing flashcards:
```json
{
    "decks": [
        {
            "name": "Example Deck",
            "cards": [
                {
                    "term": "What is JSON?",
                    "definition": "JavaScript Object Notation",
                    "reviewCount": 0,
                    "lastReviewed": null
                }
            ]
        }
    ]
}
```

## Core Functions

### 1. Deck Management
- CreateDeck()
- LoadDeck()
- SaveDeck()

### 2. Card Operations
- AddCard()
- EditCard()
- DeleteCard()

### 3. Study Features
- StartStudySession()
- ShowCard()
- TrackProgress()

## Future Enhancements

### Basic Enhancements
- Multiple choice quiz mode
- Basic search functionality
- Import/Export capabilities

### Advanced Features
- Simple spaced repetition
- Basic statistics tracking
- Card categories/tags

## Version Information
- Current Version: 1.0.0
- Last Updated: 14.11.2024
- Status: In Development

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
