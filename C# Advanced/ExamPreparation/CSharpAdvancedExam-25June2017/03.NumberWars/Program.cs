using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NumberWars
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstAllCards = new Queue<string>(Console.ReadLine().Split());
            var secondAllCards = new Queue<string>(Console.ReadLine().Split());

            var turnsCount = 0;
            bool gameOver = false;
            while (turnsCount < 1_000_000 && firstAllCards.Count > 0 && secondAllCards.Count > 0 && !gameOver)
            {
                turnsCount++;
                var firstCard = firstAllCards.Dequeue();
                var secondCard = secondAllCards.Dequeue();
                if (GetNumber(firstCard) > GetNumber(secondCard))
                {
                    firstAllCards.Enqueue(firstCard);
                    firstAllCards.Enqueue(secondCard);
                }
                else if (GetNumber(secondCard) > GetNumber(firstCard))
                {
                    secondAllCards.Enqueue(secondCard);
                    secondAllCards.Enqueue(firstCard);
                }
                else
                {
                    var cardsInHand = new List<string> { firstCard, secondCard };
                    while (!gameOver)
                    {
                        if (firstAllCards.Count >= 3 && secondAllCards.Count >= 3)
                        {
                            int firstSum = 0;
                            int secondSum = 0;
                            for (int counter = 0; counter < 3; counter++)
                            {
                                var firstHandOfCards = firstAllCards.Dequeue();
                                var secondHandOfCards = secondAllCards.Dequeue();
                                firstSum += GetChar(firstHandOfCards);
                                secondSum += GetChar(secondHandOfCards);
                                cardsInHand.Add(firstHandOfCards);
                                cardsInHand.Add(secondHandOfCards);

                            }
                            if (firstSum > secondSum)
                            {
                                AddCardsToWinner(cardsInHand, firstAllCards);
                                break;
                            }
                            else if (secondSum > firstSum)
                            {
                                AddCardsToWinner(cardsInHand, secondAllCards);
                                break;
                            }
                        }
                        else
                        {
                            gameOver = true;
                        }
                    }
                }
            }

            var result = string.Empty;
            if (firstAllCards.Count == secondAllCards.Count)
            {
                result = "Draw";
            }
            else if (firstAllCards.Count > secondAllCards.Count)
            {
                result = "First player wins";
            }
            else if (secondAllCards.Count > firstAllCards.Count)
            {
                result = "Second player wins";
            }
            Console.WriteLine($"{result} after {turnsCount} turns");
        }

        private static void AddCardsToWinner(List<string> cardsInHand, Queue<string> firstAllCards)
        {
            foreach (var card in cardsInHand.OrderByDescending(c => GetNumber(c)).ThenByDescending(c => GetChar(c)))
            {
                firstAllCards.Enqueue(card);
            }
        }

        static int GetNumber(string card)
        {
           return int.Parse(card.Substring(0, card.Length - 1));
        }

        static int GetChar(string card)
        {
            return card[card.Length - 1];
        }
    }
}
