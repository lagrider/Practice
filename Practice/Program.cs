using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice
{
    internal class Program
    {
        private static void Main(string[] args)
        {
          Console.WriteLine(IsStringUnique("abca"));
        }

        private static bool IsStringUnique(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            var hashTable = new HashSet<char>();
            foreach (char c in input)
            {
                if (hashTable.Contains(c))
                {
                    return false;
                }
                else
                {
                    hashTable.Add(c);
                }
            }
            return true;
        }
        private static void BinarySearchTest()
        {
            var input = new[] {1, 2, 3, 4, 5, 6, 7, 9};
            var value = 7;
            Console.WriteLine(BinarySearch(input, value));
            Console.WriteLine(BinarySearchRecursive(input, value, 0, input.Length - 1));
        }

        private static bool BinarySearchRecursive(int[] input, int value, int minIndex, int maxIndex)
        {
            if (minIndex > maxIndex)
            {
                return false;
            }
            var midIndex = (minIndex + maxIndex)/2;
            var midValue = input[midIndex];
            if (value == midValue)
            {
                return true;
            }
            else if (value < midValue)
            {
                // Look left
                return BinarySearchRecursive(input, value, minIndex, midIndex - 1);
            }
            else
            {
                // Look Right
                return BinarySearchRecursive(input,value, midIndex+1, maxIndex);
            }   
        }
        private static bool BinarySearch(int[] input, int value)
        {
            var minIndex = 0;
            var maxIndex = input.Length - 1;
            while (minIndex <= maxIndex)
            {
                var midIndex = (minIndex + maxIndex)/2;
                var midValue = input[midIndex];
                if (value == midValue)
                {
                    return true;
                }
                if (value < midValue)
                {
                    maxIndex = midIndex - 1;
                }
                else
                {
                    minIndex = midIndex + 1;
                }
            }
            return false;
        }

        private static void ReverseArrayTest()
        {
            var input = new[] {1, 2, 3, 4};
            ReverseArray(input);
            foreach (var i in input)
            {
                Console.WriteLine(i);
            }
        }

        private static void ReverseArray<T>(T[] input)
        {
            for (var i = 0; i < input.Length/2; i++)
            {
                var tmp = input[i];
                input[i] = input[input.Length - 1 - i];
                input[input.Length - 1 - i] = tmp;
            }
        }

        private static void PermuteTest()
        {
            var input = "123";
            PermuteV1(input, "");

            var results = PermuteV2(input);
            Console.WriteLine();
            foreach (var result  in results)
            {
                Console.WriteLine(result);
            }
        }

        private static void PermuteV1(string rem, string prefix)
        {
            if (string.IsNullOrEmpty(rem))
            {
                Console.WriteLine(prefix);
                return;
            }
            var nextChar = rem[rem.Length - 1];
            rem = rem.Remove(rem.Length - 1);
            for (var i = 0; i <= prefix.Length; i++)
            {
                var newPrefix = prefix.Insert(i, nextChar.ToString());
                PermuteV1(rem, newPrefix);
            }
        }

        private static IEnumerable<string> PermuteV2(string input)
        {
            var result = new List<string>();
            if (!string.IsNullOrEmpty(input))
            {
                var firstChar = input[0].ToString();
                var subResults = PermuteV2(input.Remove(0, 1)).ToList();
                if (!subResults.Any())
                {
                    result.Add(firstChar);
                }
                else
                {
                    foreach (var subResult in subResults)
                    {
                        for (var i = 0; i <= subResult.Length; i++)
                        {
                            var subPermutation = subResult.Insert(i, firstChar);
                            result.Add(subPermutation);
                        }
                    }
                }
            }
            return result;
        }
    }
}