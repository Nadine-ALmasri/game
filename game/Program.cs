
using System;

namespace MathGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartSequence();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Program completed.");
            }
        }

        static void StartSequence()
        {
            Console.WriteLine("Enter a number greater than zero:");
            int size = Convert.ToInt32(Console.ReadLine());

            if (size <= 0)
                throw new Exception("Number should be greater than zero.");

            int[] numbers = new int[size];
            numbers = Populate(numbers);
            int sum = GetSum(numbers);
            int product = GetProduct(numbers, sum);
            decimal quotient = GetQuotient(product);

            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Product: {product}");
            Console.WriteLine($"Quotient: {quotient}");
        }

        static int[] Populate(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Please enter number {i + 1}/{numbers.Length}:");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }
            return numbers;
        }

        static int GetSum(int[] numbers)
        {
            int sum = 0;
            foreach (int num in numbers)
                sum += num;

            if (sum < 20)
                throw new Exception($"Value of {sum} is too low.");

            return sum;
        }

        static int GetProduct(int[] numbers, int sum)
        {
            Console.WriteLine("Please select a random number between 1 and the length of the array:");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;

            if (index < 0 || index >= numbers.Length)
                throw new IndexOutOfRangeException("Invalid index.");

            int product = sum * numbers[index];
            return product;
        }

        static decimal GetQuotient(int product)
        {
            Console.WriteLine($"Enter a number to divide the product ({product}):");
            decimal dividend = Convert.ToDecimal(Console.ReadLine());

            if (dividend == 0)
            {
                Console.WriteLine("Divide by zero error.");
                return 0;
            }

            decimal quotient = decimal.Divide(product, dividend);
            return quotient;
        }
    }
}