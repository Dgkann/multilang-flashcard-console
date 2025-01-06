const fs = require('fs');
const path = require('path');

class FlashcardDeck {
  constructor() {
    this.cards = [];
    this.loadCards();
  }

  loadCards() {
    const filePath = path.resolve('cards.json');
    if (fs.existsSync(filePath)) {
      const data = fs.readFileSync(filePath, 'utf-8');
      this.cards = JSON.parse(data);
    } else {
      this.cards = [];
    }
  }

  saveCards() {
    const filePath = path.resolve('cards.json');
    fs.writeFileSync(filePath, JSON.stringify(this.cards, null, 2));
  }

  addCard(question, answer) {
    this.cards.push({ question, answer });
    this.saveCards();
  }

  removeCard(index) {
    if (index >= 0 && index < this.cards.length) {
      this.cards.splice(index, 1);
      this.saveCards();
    }
  }

  async study() {
    if (this.cards.length === 0) {
      console.log("\nNo cards to study! Add some cards first.");
      return;
    }

    this.shuffleCards();
    let correct = 0;
    const total = this.cards.length;

    for (let i = 0; i < total; i++) {
      const card = this.cards[i];
      console.log(`\nCard ${i + 1}/${total}`);
      console.log(`\nQuestion: ${card.question}`);
      await this.waitForInput("\nPress Enter to see the answer...");
      console.log(`Answer: ${card.answer}`);

      while (true) {
        const response = await this.waitForInput("\nDid you get it right? (y/n): ");
        if (['y', 'n'].includes(response.toLowerCase())) {
          if (response.toLowerCase() === 'y') {
            correct++;
          }
          break;
        }
      }
    }

    const score = (correct / total) * 100;
    console.log(`\nSession complete! Score: ${correct}/${total} (${score.toFixed(1)}%)`);
  }

  shuffleCards() {
    for (let i = this.cards.length - 1; i > 0; i--) {
      const j = Math.floor(Math.random() * (i + 1));
      [this.cards[i], this.cards[j]] = [this.cards[j], this.cards[i]];
    }
  }

  waitForInput(prompt) {
    const readline = require('readline');
    const rl = readline.createInterface({
      input: process.stdin,
      output: process.stdout
    });

    return new Promise((resolve) => rl.question(prompt, (input) => {
      rl.close();
      resolve(input);
    }));
  }
}

async function main() {
  const deck = new FlashcardDeck();

  while (true) {
    console.log("\n=== Flashcard Study App ===");
    console.log("1. Add new card");
    console.log("2. Study cards");
    console.log("3. List all cards");
    console.log("4. Remove card");
    console.log("5. Exit");

    const choice = await deck.waitForInput("\nEnter your choice (1-5): ");

    if (choice === '1') {
      const question = await deck.waitForInput("\nEnter the question: ");
      const answer = await deck.waitForInput("Enter the answer: ");
      deck.addCard(question, answer);
      console.log("Card added successfully!");
    } else if (choice === '2') {
      await deck.study();
    } else if (choice === '3') {
      if (deck.cards.length === 0) {
        console.log("\nNo cards available.");
      } else {
        console.log("\nAll Cards:");
        deck.cards.forEach((card, i) => {
          console.log(`\n${i + 1}. Question: ${card.question}`);
          console.log(`   Answer: ${card.answer}`);
        });
      }
    } else if (choice === '4') {
      if (deck.cards.length === 0) {
        console.log("\nNo cards to remove.");
      } else {
        console.log("\nSelect card to remove:");
        deck.cards.forEach((card, i) => {
          console.log(`${i + 1}. ${card.question}`);
        });
        const index = parseInt(await deck.waitForInput("\nEnter card number: "), 10) - 1;
        if (!isNaN(index) && index >= 0 && index < deck.cards.length) {
          deck.removeCard(index);
          console.log("Card removed successfully!");
        } else {
          console.log("Invalid card number!");
        }
      }
    } else if (choice === '5') {
      console.log("\nThanks for studying! Goodbye!");
      break;
    } else {
      console.log("\nInvalid choice! Please try again.");
    }
  }
}

main();
