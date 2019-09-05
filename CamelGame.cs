using System;
using System.Collections.Generic;
using System.Text;

namespace Camel_Game
{
    public class CamelGame
    {
        private int milesTraveled = 0;
        private int thirst = 0;
        private int camelTiredness = 0;
        private int nativeDistance = -20;
        private int drinksLeft = 3;
        private bool isDone = false;
        public CamelGame()
        {
            StartGame();
        }
        private void StartGame()
        {
            milesTraveled = 0;
            thirst = 0;
            camelTiredness = 0;
            nativeDistance = -20;
            drinksLeft = 3;
            Console.WriteLine("Welcome to Camel!");
            Console.WriteLine("You have stolen a camel to make your way across the great mobi desert.");
            Console.WriteLine("The natives want their camel back and are chasing you down!\nSurvive your desert trek and out run the natives");
            Console.WriteLine();
            ChooseNextOption();
        }
        private void ChooseNextOption()
        {
            string choice;
            CheckStatus();
            while (isDone == false)
            {
                choice = ShowMenu();
                switch (choice)
                {
                    case "A":
                        Drink();
                        break;
                    case "B":
                        Ahead("Moderate");
                        break;
                    case "C":
                        Ahead("Full");
                        break;
                    case "D":
                        Stop();
                        break;
                    case "E":
                        Status();
                        break;
                    case "Q":
                        Console.WriteLine("Goodbye");
                        isDone = true;
                        break;
                    default:
                        Console.WriteLine("Incorrect Option");
                        Console.WriteLine();
                        ChooseNextOption();
                        break;

                }
            }
        }
        private  void Status()
        {
            Console.WriteLine($"Miles Traveled: {milesTraveled}");
            Console.WriteLine($"Drinks Left in Canteen: {drinksLeft}");
            if (milesTraveled > 0)
            {
                Console.WriteLine($"The natives are {milesTraveled - nativeDistance} miles behind you");
            }
            else
            {
                Console.WriteLine($"The natives are {milesTraveled + Math.Abs(nativeDistance)} miles behind you");
            }
            Console.WriteLine();
            ChooseNextOption();
        }

        private void Stop()
        {
            camelTiredness = 0;
            Console.WriteLine("The camel is now happy");
            Random random = new Random();
            nativeDistance += random.Next(7, 14);
            Console.WriteLine();
            ChooseNextOption();
        }

        private void Ahead(string speed)
        {
            Random random = new Random();
            if (speed.Equals("Full"))
            {
                milesTraveled += random.Next(10, 20);
                Console.WriteLine($"You have now traveled {milesTraveled} miles.");
                thirst++;
                camelTiredness += random.Next(1, 4);
                nativeDistance += random.Next(7, 14);
            }
            else
            {
                milesTraveled = random.Next(5, 12);
                Console.WriteLine($"You have now traveled {milesTraveled} miles.");
                thirst++;
                camelTiredness++;
                nativeDistance += random.Next(7, 14);
            }
            int oasisChance = random.Next(0, 20);
            if (oasisChance == 20)
            {
                Console.WriteLine("You have found an oasis! Your supply's are refiled");
                drinksLeft = 3;
                thirst = 0;
                camelTiredness = 0;
            }
            Console.WriteLine();
            ChooseNextOption();
        }

        private  void Drink()
        {
            if (drinksLeft >= 1)
            {
                Console.WriteLine("Mmm... Refeshing!");
                thirst = 0;
                drinksLeft--;
            }
            else
            {
                Console.WriteLine("You are out of drinks!");
            }
            Console.WriteLine();
            ChooseNextOption();
        }
        private void CheckStatus()
        {
            if (thirst > 6)
            {
                Console.WriteLine("You have died of thirst.");
                isDone = true;
                return;
            }
            if (camelTiredness > 8)
            {
                Console.WriteLine("Your Camel has died.");
                isDone = true;
                return;
            }
            if (nativeDistance >= milesTraveled)
            {
                Console.WriteLine("The natives have caught up to you. You have died");
                isDone = true;
                return;
            }
            if (thirst >= 4)
            {
                Console.WriteLine("You are getting thirsty.");
                Console.WriteLine();
            }
            if (camelTiredness > 5)
            {
                Console.WriteLine("Your Camel is getting tired ");
                Console.WriteLine();
            }

            if (((milesTraveled - nativeDistance) < 15) && nativeDistance > 0)
            {
                Console.WriteLine("The Natives are getting closer!");
                Console.WriteLine();
            }
            if (milesTraveled >= 200)
            {
                Console.WriteLine("You made it!");
                isDone = true;
                return;
            }
        }
        private string ShowMenu()
        {
            string choice;
            Console.WriteLine("A. Drink from your canteen.");
            Console.WriteLine("B. Ahead moderate speed.");
            Console.WriteLine("C. Ahead full speed.");
            Console.WriteLine("D. Stop for the night.");
            Console.WriteLine("E. Status check.");
            Console.WriteLine("Q. Quit.");
            Console.WriteLine("What is your choice?");
            choice = Console.ReadLine();
            Console.WriteLine();
            return choice.ToUpper();
        }
    }
}
