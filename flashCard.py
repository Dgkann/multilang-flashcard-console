import json
import random
import os
from typing import List, Dict

class FlashcardDeck:
    def __init__(self):
        """
        Initializes a new FlashcardDeck instance.
        Loads existing cards from the 'cards.json' file if it exists.
        """
        self.cards: List[Dict[str, str]] = []  # A list to store flashcards as dictionaries.
        self.load_cards()  # Load flashcards from the file.

    def load_cards(self):
        """
        Loads flashcards from a JSON file ('cards.json').
        If the file doesn't exist, initializes an empty list.
        """
        if os.path.exists('cards.json'):  # Check if the file exists.
            with open('cards.json', 'r') as f:
                self.cards = json.load(f)  # Load the JSON data into the cards list.
        else:
            self.cards = []  # Initialize with an empty list if the file is missing.

    def save_cards(self):
        """
        Saves the current list of flashcards to the 'cards.json' file in JSON format.
        """
        with open('cards.json', 'w') as f:
            json.dump(self.cards, f, indent=2)  # Save cards with indentation for readability.

    def add_card(self, question: str, answer: str):
        """
        Adds a new flashcard with the specified question and answer to the deck.
        Updates the JSON file to include the new card.
        """
        if not question.strip() or not answer.strip():  # Missing Check: Prevent adding empty questions or answers
            print("\nQuestion and answer cannot be empty!")
            return
        self.cards.append({  # Add a new dictionary to the cards list.
            'question': question,
            'answer': answer
        })
        self.save_cards()  # Save changes to the file.

    def remove_card(self, index: int):
        """
        Removes a flashcard at the specified index from the deck.
        Updates the JSON file after removal.
        :param index: The 0-based index of the card to remove.
        """
        if 0 <= index < len(self.cards):  # Ensure the index is valid.
            self.cards.pop(index)  # Remove the card at the given index.
            self.save_cards()  # Save the updated cards list.
        else:  # Missing Check: Report invalid index status
            print("\nInvalid index! Please choose a valid card number.")

    def study(self):
        """
        Conducts a study session by displaying each flashcard's question and answer.
        Randomizes the order of cards and calculates the user's score based on their responses.
        """
        if not self.cards:  # Check if there are any cards to study.
            print("\nNo cards to study! Add some cards first.")
            return

        random.shuffle(self.cards)  # Randomize the order of flashcards.
        correct = 0  # Counter for correct answers.
        total = len(self.cards)  # Total number of flashcards.

        for i, card in enumerate(self.cards, 1):  # Loop through all flashcards.
            print(f"\nCard {i}/{total}")  # Display the current card number.
            print(f"\nQuestion: {card['question']}")  # Show the question.
            input("\nPress Enter to see the answer...")  # Wait for user input.
            print(f"Answer: {card['answer']}")  # Display the answer.
            
            while True:  # Loop until the user provides a valid response.
                response = input("\nDid you get it right? (y/n): ").lower()
                if response in ['y', 'n']:  # Validate input.
                    if response == 'y':  # If correct, increment the score.
                        correct += 1
                    break
                else:  # Missing Check: Add warning message in case of incorrect input
                    print("\nInvalid input! Please enter 'y' or 'n'.")

        score = (correct / total) * 100  # Calculate the score as a percentage.
        print(f"\nSession complete! Score: {correct}/{total} ({score:.1f}%)")  # Display the score.

def main():
    """
    Main function to run the Flashcard Study App.
    Provides a menu for users to add, study, list, and remove flashcards.
    """
    deck = FlashcardDeck()  # Create a new flashcard deck instance.
    
    while True:  # Infinite loop for the menu.
        print("\n=== Flashcard Study App ===")
        print("1. Add new card")
        print("2. Study cards")
        print("3. List all cards")
        print("4. Remove card")
        print("5. Exit")
        
        choice = input("\nEnter your choice (1-5): ")  # Get the user's menu choice.
        
        if choice == '1':  # Option to add a new card.
            question = input("\nEnter the question: ")
            answer = input("Enter the answer: ")
            deck.add_card(question, answer)  # Add the new card to the deck.
            print("Card added successfully!")
            
        elif choice == '2':  # Option to study cards.
            deck.study()
            
        elif choice == '3':  # Option to list all cards.
            if not deck.cards:  # Check if there are any cards to display.
                print("\nNo cards available.")
            else:
                print("\nAll Cards:")
                for i, card in enumerate(deck.cards, 1):  # Loop through all cards.
                    print(f"\n{i}. Question: {card['question']}")
                    print(f"   Answer: {card['answer']}")
                    
        elif choice == '4':  # Option to remove a card.
            if not deck.cards:  # Check if there are any cards to remove.
                print("\nNo cards to remove.")
            else:
                print("\nSelect card to remove:")
                for i, card in enumerate(deck.cards, 1):  # Display cards for selection.
                    print(f"{i}. {card['question']}")
                try:
                    idx = int(input("\nEnter card number: ")) - 1  # Get 1-based index from user.
                    deck.remove_card(idx)  # Remove the selected card.
                    print("Card removed successfully!")
                except ValueError:  # Handle invalid input.
                    print("\nInvalid input! Please enter a number.")
                except IndexError:  # Handle out-of-range index.
                    print("\nInvalid card number!")
                    
        elif choice == '5':  # Option to exit the program.
            print("\nThanks for studying! Goodbye!")
            break  # Exit the loop.
            
        else:  # Handle invalid menu options.
            print("\nInvalid choice! Please try again.")

if __name__ == "__main__":
    main()  # Run the main function.
