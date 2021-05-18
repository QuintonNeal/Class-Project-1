using System;
using System.Collections.Generic;
using static System.Console;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace Project01_QuintonNeal
{
    class Program
    {



        static void Main(string[] args)
        {
            //Save the costs of the different menu items, then save them into an array so they can be looped through when displayed in the menu
            const double fruitSaladCost = 9.95;
            const double pastaSaladCost = 12.00;
            const double smoothieCost = 4.95;
            const double fruitJuiceCost = 3.95;
            const double cupCakeCost = 3.00;
            const double shortCakeCost = 6.00;
            double[] itemCosts = {fruitSaladCost, pastaSaladCost, smoothieCost, fruitJuiceCost, cupCakeCost, shortCakeCost};

            //Save the names of menu items and put them into an array to loop through
            const string fruitSaladName = "Fruit Salad";
            const string pastaSaladName = "Pasta Salad";
            const string smoothieName = "Smoothie";
            const string fruitJuiceName = "Fruit Juice";
            const string cupCakeName = "Cup Cake";
            const string shortCakeName = "Short Cake";
            string[] names = {fruitSaladName, pastaSaladName, smoothieName, fruitJuiceName, cupCakeName, shortCakeName};

            //Displays the menu
            WriteLine("********************************* MENU *********************************");

            //Loop through the menu item names and their corresponding costs to display them to the screen
            for(int i = 0; i < names.Length; i++)
            {
                WriteLine("{0, 11} : {1}", names[i], itemCosts[i].ToString("C"));
            }

            WriteLine("************************************************************************");

            //Call the method to get user input, and save it to an array
            int[] itemsPurchased = new int[6];

            for (int i = 0; i < names.Length; i++)
            {
                itemsPurchased[i] = GetUserInput(names[i], itemCosts[i], i);
            }

            //Call the method to display the prices. Pass this method the array of how many items were purchased, as well as their costs
            DisplayPrices(itemsPurchased, itemCosts);

            ReadLine();
        }




        static int GetUserInput(string name, double cost, int i)
        {
            //Display the heading at the beginning
            if (i == 0)
            {
                WriteLine("**************************** ENTER YOUR ORDER **************************");
            }

            //Ask how many of each item the user wants
            WriteLine("How many {0}s --- {1} ?", name, cost.ToString("C"));
            string userInput = ReadLine();

            //Check to make sure the user input a number
            int num = -1;
            if (!Int32.TryParse(userInput, out num))
            {
                while (!Int32.TryParse(userInput, out num))
                {
                    WriteLine("Type and integer");
                    userInput = ReadLine();
                }
            }

            //Convert the user input into an int
            int numberOfItems = Convert.ToInt32(userInput);

            return numberOfItems;
        }




        static void DisplayPrices(int[] itemsPurchased, double[] itemCosts)
        {

            WriteLine("************************************************************************");

            //Calculate and display the subtotal cost
            double subtotal = 0;
            for (int i = 0; i < itemsPurchased.Length; i++)
            {
                subtotal = subtotal + (itemsPurchased[i] * itemCosts[i]);
            }
            WriteLine("Subtotal Costs {0}", subtotal.ToString("C"));

            //Calculate and display the amount of tax owed
            const double taxRate = 0.095;
            double taxOwed = subtotal * taxRate;
            WriteLine("Tax {0}", taxOwed.ToString("C"));

            //Calculate and display the total cost
            double totalCosts = subtotal + taxOwed;
            WriteLine("Total Costs {0}", totalCosts.ToString("C"));
        }

    }
}
