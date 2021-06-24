using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        private static Dictionary<int, string> guests = new Dictionary<int, string>();
        private static int min = 1000;
        private static int max = 9999;
        private static int raffleNumber;
        private static Random _rdm = new Random();

        //1. Method that takes string parameter to use instead of console writeline&readline
        private static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string response = Console.ReadLine();
            return response;
        }

        //3. Method that returns a random int btw min and max (calls line 16) 
        private static int GenerateRandomNumber(int min, int max)
        {
            int randomNumber = _rdm.Next(min, max); //.Next() is a method that is used to get random numbers 
            return randomNumber;
        }

        //5. Void method, loop to print name with their value (uses the guest dictionary line 12)
        private static void PrintGuestsName()
        {
            foreach (var guest in guests) //for each singular guest in the dictionary "guests"
                Console.WriteLine($"{guest.Value}: {guest.Key}"); //calling on the dictionary to print the guest with their name with their raffle number by using .Key and .Value
        }

        //4. Void method adding guest name and raffle num into dictionary
        private static void AddGuestsInRaffle(int raffleNumber, string guest)
        {
            guests.Add(raffleNumber, guest); //adding the rafflenumber(key) and the guest(value) to the guests dictionary by using .Add()
        }

        //6. Method that takes dictionary and returns random key as the winner
        private static int GetRaffleNumber(Dictionary<int, string> people)
        {
            var winningIndex = GenerateRandomNumber(0, people.Count - 1); //calls generate random num(). start the index at 0, people.count - 1 bc index counts 0,1,2,3.. and people are 1,2,3,4 (so minus one from people so it only goes to 3 so the index can call on it)
            return people.Keys.ToArray()[winningIndex]; //turned the rafflenumber(keys) into an array so that it can assign them an index and pick an index number to give the winner
        }

        //7. Void method to print winner and rafflenum, calls getRaffleMethod
        private static void PrintWinner()
        {
            int winnerNumber = GetRaffleNumber(guests); //picking the winning number from the guests dictionary using getrafflemnumber method
            string winnerName = guests[winnerNumber]; // picking the winner name from the guests dictionary by matching it to the winner number
            Console.WriteLine($"The Winner is: {winnerName} with the #{winnerNumber}!!!");
        }

        //2. Void method calling all the other methods except print guest name and print winner
        private static void GetUserInfo()
        {
            string otherGuest;
            do
            {
                string name;
                do
                {
                    name = GetUserInput("Please enter your name");
                } while (string.IsNullOrWhiteSpace(name)); //if they dont enter anything it will ask for their name again (instead of do you want to add another name)

                do
                {
                    raffleNumber = GenerateRandomNumber(min, max);
                }
                while (guests.ContainsKey(raffleNumber)); //checks if the guests dictionary contains the value of the raffle number

                AddGuestsInRaffle(raffleNumber, name);
                otherGuest = GetUserInput("Do you want to add another name?").ToLower();
            } while (otherGuest == "yes"); //as long as they keep saying yes the loop will run and assign raffle numbers to every name entered
        }



        static void Main(string[] args)
        {           
            Console.WriteLine("Welcome to the Party!!");
            GetUserInfo();
            MultiLineAnimation(); //calls on the animation below
            PrintGuestsName(); //this goes after the animation bc it wont show
            PrintWinner();
            Console.ReadLine(); //Keeps the console window open
        }

        
        static void MultiLineAnimation() // Credit: https://www.michalbialecki.com/2018/05/25/how-to-make-you-console-app-look-cool/
        {
            var counter = 0;
            for (int i = 0; i < 30; i++)
            {
                Console.Clear();

                switch (counter % 4)
                {
                    case 0:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    │││ \\   ║");
                            Console.WriteLine("         ║    │││  O  ║");
                            Console.WriteLine("         ║    OOO     ║");
                            break;
                        };
                    case 1:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                    case 2:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║   / │││    ║");
                            Console.WriteLine("         ║  O  │││    ║");
                            Console.WriteLine("         ║     OOO    ║");
                            break;
                        };
                    case 3:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                }

                counter++;
                Thread.Sleep(200);
            }
        }
    }
}
