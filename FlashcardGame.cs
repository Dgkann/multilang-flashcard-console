using System;                 // Provides fundamental types and base classes
using System.IO;             // Provides classes for reading and writing files
using System.Text.Json;      // Provides functionality for JSON serialization/deserialization

// Represents a single flashcard with a question and answer pair
public class Flashcard{

// Auto-implemented property for storing the flashcard question
    public string Question { 
        get; 
        set; 
    }
    // Auto-implemented property for storing the flashcard answer
    public string Answer { 
        get; 
        set; 
    }
}
// Manages a collection of flashcards with functionality for adding, removing, studying and persistence
public class FlashcardDeck{
    private Flashcard[] cards;             // Array to store flashcard objects
    private int count;                     // Tracks number of cards currently in deck
    private const string CARDS_FILE = "cards.json";  // File name for persistence
    private const int INITIAL_CAPACITY = 20;         // Initial size of cards array

    // Constructor initializes empty deck and loads any existing cards from file
    public FlashcardDeck(){
  
        cards = new Flashcard[INITIAL_CAPACITY];
        count = 0;
        LoadCards();
    }

    // Loads flashcards from JSON file if it exists
    private void LoadCards(){
        try{
            if (File.Exists(CARDS_FILE)){
                string jsonString = File.ReadAllText(CARDS_FILE);
                var loadedCards = JsonSerializer.Deserialize<Flashcard[]>(jsonString);

                // If cards were loaded successfully, copy them to our array
                if (loadedCards != null && loadedCards.Length > 0){
                    // Resize array if needed to fit loaded cards
                    if (loadedCards.Length > cards.Length){
                        cards = new Flashcard[loadedCards.Length * 2];
                    }
                    Array.Copy(loadedCards, cards, loadedCards.Length);
                    count = loadedCards.Length;
                }
            }
        }
        catch (Exception ex){
            // If loading fails, initialize empty deck
            Console.WriteLine($"Error loading cards: {ex.Message}");
            cards = new Flashcard[INITIAL_CAPACITY];
            count = 0;
        }
    }

    // Saves current flashcards to JSON file
    private void SaveCards(){
        try{
            // Create new array with exactly the number of cards we have
            Flashcard[] cardsToSave = new Flashcard[count];
            Array.Copy(cards, cardsToSave, count);
            string jsonString = JsonSerializer.Serialize(cardsToSave, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(CARDS_FILE, jsonString);
        }
        catch (Exception ex){
            Console.WriteLine($"Error saving cards: {ex.Message}");
        }
    }

    // Doubles the size of the cards array when it gets full
    private void ResizeArray(){
        int newSize = cards.Length * 2;
        Flashcard[] newCards = new Flashcard[newSize];
        Array.Copy(cards, newCards, cards.Length);
        cards = newCards;
    }

    // Adds a new flashcard to the deck
    public void AddCard(string question, string answer){
        // Validate input
        if (string.IsNullOrWhiteSpace(question) || string.IsNullOrWhiteSpace(answer))
        {
            Console.WriteLine("Question and answer cannot be empty!");
            return;
        }

        // Resize if needed
        if (count >= cards.Length){
            ResizeArray();
        }

        // Add new card and save
        cards[count] = new Flashcard { 
            Question = question.Trim(),
            Answer = answer.Trim()
        };
        count++;
        SaveCards();
        Console.WriteLine("Card added successfully!");
    }

    // Removes a flashcard at specified index
    public void RemoveCard(int index){
        if (index < 0 || index >= count){
            Console.WriteLine("Invalid card index!");
            return;
        }

        // Shift remaining cards left to fill the gap
        for (int i = index; i < count - 1; i++){
            cards[i] = cards[i + 1];
        }
        cards[count - 1] = null;
        count--;
        SaveCards();
    }

    // Implements study session with randomized cards and scoring
    public void Study(){
        if (count == 0){
            Console.WriteLine("\nNo cards to study! Add some cards first.");
            return;
        }

        // Create and shuffle copy of cards
        Random random = new Random();
        Flashcard[] shuffledCards = new Flashcard[count];
        Array.Copy(cards, shuffledCards, count);

        // Fisher-Yates shuffle algorithm
        for (int i = count - 1; i > 0; i--){
            int j = random.Next(i + 1);
            Flashcard temp = shuffledCards[i];
            shuffledCards[i] = shuffledCards[j];
            shuffledCards[j] = temp;
        }

        // Study session loop
        int correct = 0;
        int total = count;

        for (int i = 0; i < total; i++){
            Console.WriteLine($"\nCard {i + 1}/{total}");
            Console.WriteLine($"Question: {shuffledCards[i].Question}");
            Console.WriteLine("\nPress Enter to see the answer...");
            Console.ReadLine();
            Console.WriteLine($"Answer: {shuffledCards[i].Answer}");

            // Get user feedback on correctness
            while (true){
                Console.Write("\nDid you get it right? (y/n): ");
                string response = Console.ReadLine()?.ToLower() ?? "";
                if (response == "y" || response == "n")
                {
                    if (response == "y") correct++;
                    break;
                }
                Console.WriteLine("Please enter 'y' or 'n'");
            }
        }

        // Calculate and display final score
        double score = (correct / (double)total) * 100;
        Console.WriteLine($"\nSession complete! Score: {correct}/{total} ({score:F1}%)");
    }

    // Property to check if deck has any cards
    public bool HasCards => count > 0;

    // Returns copy of current cards array
    public Flashcard[] GetCards(){
        Flashcard[] result = new Flashcard[count];
        Array.Copy(cards, result, count);
        return result;
    }
}

// Main program class implementing the user interface
public class Program{
    public static void Main(){
        Console.WriteLine("Initializing Flashcard Study App...");
        FlashcardDeck deck = new FlashcardDeck();

        // Main program loop
        while (true){
            try{
                // Display menu options
                Console.WriteLine("\n=== Flashcard Study App ===");
                Console.WriteLine("1. Add new card");
                Console.WriteLine("2. Study cards");
                Console.WriteLine("3. List all cards");
                Console.WriteLine("4. Remove card");
                Console.WriteLine("5. Exit");

                Console.Write("\nEnter your choice (1-5): ");
                string choice = Console.ReadLine()?.Trim() ?? "";

                // Handle user choice
                switch (choice){
                    case "1":
                        Console.Write("\nEnter the question: ");
                        string question = Console.ReadLine();
                        Console.Write("Enter the answer: ");
                        string answer = Console.ReadLine();
                        deck.AddCard(question, answer);
                        break;
                    case "2":
                        deck.Study();
                        break;
                    case "3":
                        if (!deck.HasCards){
                            Console.WriteLine("\nNo cards available.");
                        }
                        else{
                            Console.WriteLine("\nAll Cards:");
                            Flashcard[] allCards = deck.GetCards();
                            for (int i = 0; i < allCards.Length; i++){
                                Console.WriteLine($"\n{i + 1}. Question: {allCards[i].Question}");
                                Console.WriteLine($"   Answer: {allCards[i].Answer}");
                            }
                        }
                        break;
                    case "4":
                         if (!deck.HasCards){
                            Console.WriteLine("\nNo cards to remove.");
                        }
                        else{
                            // Display cards and get user selection for removal
                            Console.WriteLine("\nSelect card to remove:");
                            Flashcard[] cards = deck.GetCards();
                            for (int i = 0; i < cards.Length; i++){
                                Console.WriteLine($"{i + 1}. {cards[i].Question}");
                            }
                            Console.Write("\nEnter card number: ");
                            if (int.TryParse(Console.ReadLine(), out int idx) && idx > 0 && idx <= cards.Length){
                                deck.RemoveCard(idx - 1);
                                Console.WriteLine("Card removed successfully!");
                            }
                            else{
                                Console.WriteLine("Invalid card number!");
                            }
                        }
                        break;
                    case "5":
                        Console.WriteLine("\nThanks for studying! Goodbye!");
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice! Please enter a number between 1 and 5.");
                        break;
                }
            }
            catch (Exception ex){
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}