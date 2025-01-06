import json
import random

class FlashcardApp:
    def __init__(self):
        self.flashcards = []
        self.load_flashcards()

    def load_flashcards(self):
        try:
            with open('flashcards.json', 'r') as f:
                self.flashcards = json.load(f)
        except (FileNotFoundError, json.JSONDecodeError):
            self.flashcards = []

    def save_flashcards(self):
        with open('flashcards.json', 'w') as f:
            json.dump(self.flashcards, f)

    def add_flashcard(self):
        question = input("Enter the question: ")
        answer = input("Enter the answer: ")
        self.flashcards.append({"question": question, "answer": answer})
        self.save_flashcards()
        print("Flashcard added!")

    def review_flashcards(self):
        if not self.flashcards:
            print("No flashcards available. Please add some first.")
            return
        for card in self.flashcards:
            print(f"Question: {card['question']}")
            input("Press Enter to see the answer...")
            print(f"Answer: {card['answer']}\n")

    def quiz(self):
        if not self.flashcards:
            print("No flashcards available. Please add some first.")
            return
        random.shuffle(self.flashcards)
        score = 0
        for card in self.flashcards:
            print(f"Question: {card['question']}")
            answer = input("Your answer: ")
            if answer.lower() == card['answer'].lower():
                print("Correct!\n")
                score += 1
            else:
                print(f"Wrong! The correct answer is : {card['answer']}\n")
        print(f"Your score : {score}/{len(self.flashcards)}")

    def run(self):
        while True:
            print("1. Add Flashcard")
            print("2. Review Flashcards")
            print("3. Quiz")
            print("4. Exit")
            choice = input("Choose an option : ")
            if choice == '1':
                self.add_flashcard()
            elif choice == '2':
                self.review_flashcards()
            elif choice == '3':
                self.quiz()
            elif choice == '4':
                print("Goodbye!")
                break
            else:
                print("Invalid choice. Please try again.")

if __name__ == "__main__":
    print("\n\t\tWELCOME TO FLASHCARD APP\n")
    app = FlashcardApp()
    app.run()

