using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;

namespace lab3._2_shopping_list
{
    class Program
    {
        static bool Redo(string userInput)
        {
            Console.WriteLine(userInput);
            char key = Console.ReadKey().KeyChar;

            while (key != 'y')
            {
                if (key == 'n')
                {
                    Console.WriteLine();
                    return false;
                }
                else
                {
                    Console.Write("\nThat is an invalid entry. Please enter y or n:");
                    key = Console.ReadKey().KeyChar;
                }
            }
            Console.WriteLine();
            return true;
        }
        static void Main(string[] args)
        {
            string contChoice ="y";

            ArrayList myShoppingList = new ArrayList();
            ArrayList myPrices = new ArrayList();

            Dictionary<string, decimal> items = new Dictionary<string, decimal>(); //create the dictionary of items/prices
            items["apple"] = 1.99m;
            items["pear"] = 2.20m;
            items["ham"] = 1.60m;
            items["orange"] = 1.55m;
            items["widget"] = 6.97m;
            items["pineapple"] = 3.09m;
            items["waffle"] = 2.69m;
            items["manure"] = 4.99m;

            Console.WriteLine("Welcome to Pelican Town Market!");
            Console.WriteLine();

            foreach(var item in items)  //display the available items to purchase
            {
                Console.WriteLine($"{item.Key}-----{item.Value}");
            }
            Console.WriteLine();
            do
            {
                Console.WriteLine("What would you like to purchase?");  //accept the item being purchased, format it to lower case
                string choice = Console.ReadLine();
                choice.ToLower();
                
                if (items.ContainsKey(choice))  //compare the choice the user made to the items available and add them to their own array
                {
                    Console.WriteLine($"You chose {choice} for {items[choice]}");
                    myShoppingList.Add(choice);
                    myPrices.Add(items[choice]);
                    Console.WriteLine("Would you like to add another item? (y/n)");
                    contChoice = Console.ReadLine();
                    contChoice.ToLower();

                    Console.Clear();

                    foreach (var item in items)  //display the available items to purchase
                    {
                        Console.WriteLine($"{item.Key}-----{item.Value}");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("incorrect data");
                }
            } while (contChoice != "n"  && contChoice != "no");

            decimal total = 0;

            for(int index=0; index<myShoppingList.Count; index++)
            {
                Console.WriteLine($"{myShoppingList[index]} ----- {myPrices[index]}");
                total += (decimal)myPrices[index];                
            }
            decimal average = total / myPrices.Count;

            Console.WriteLine();
            Console.WriteLine($"Your cart total is: {total:N2}");
            Console.WriteLine($"Your average price is: {average:N2}");        


        }

    }
}
