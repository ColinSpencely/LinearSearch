using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            List<int> numbers = new List<int>();
            numbers = FillList(numbers, rand);
            Console.WriteLine("Number list: ");
            PrintPrettyList(numbers);

            bool check = false;
            int searchTerm = 0;

            while (!check)
            {
                Console.Write("\nEnter the integer to search for: ");
                check = int.TryParse(Console.ReadLine(), out searchTerm);
                if (!check)
                {
                    Console.WriteLine("That isn't a number, compadre!");
                }
            }

            int index = LinearSearch(numbers, searchTerm);
            if (index >= 0)
            {
                Console.WriteLine("Number found at index {0}.", index);
            }
            else
            {
                Console.WriteLine("Number not found.");
            }

        }

        static int LinearSearch(List<int> numbers, int term)
        {
            int index = -1;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i].Equals(term))
                {
                    return i;
                }
            }
            return index;
        }

        // Function fills list with random numbers.
        // Function takes a Random seed and a list of int as arguments.
        // Function returns unsorted list of ints to calling function.
        static List<int> FillList(List<int> nums, Random rand)
        {
            int randomInt = 0;
            int listSize = 0;
            bool check = false;

            while (!check)
            {
                Console.Write("How big is your list of numbers? ");
                check = int.TryParse(Console.ReadLine(), out listSize);
                if (!check)
                {
                    Console.WriteLine("That was not a number, compadre!");
                }
                if (check && listSize < 10)
                {
                    Console.WriteLine("List size must be greater than or equal to 10!");
                    check = false;
                }
            }

            while (nums.Count < listSize)
            {
                randomInt = rand.Next(1, listSize + 1);
                // If number is not already in list, add number.
                if (!nums.Contains(randomInt))
                    nums.Add(randomInt);
            }
            return nums;
        }

        // Function prints a list of ints with 10 ints per row.
        // Function takes a list of int as an argument.
        // Function returns void.
        static void PrintPrettyList(List<int> nums)
        {
            // Loop through each number in the list.
            for (int i = 0, j = 0; i < nums.Count; i++)
            {
                string numString = nums[i].ToString();
                numString = numString.PadLeft(5); // Adds 5 leading spaces to each number to even out the column width.

                j++; // Counts the number of ints in a single row.

                // Puts 10 numbers in a row.
                if (j < 10)
                {
                    Console.Write(numString + " ");
                }
                // At the end of a row, reset the counter.
                else
                {
                    j = 0;
                    Console.WriteLine(numString);
                }
            }
        }
    }
}

