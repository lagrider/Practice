using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public static class Chapter1ArraysAndLists
    {
        public static bool IsPermutationOfPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }
            var hashTable = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (c == ' ')
                {
                    continue;
                }
                if (hashTable.ContainsKey(c))
                {
                    hashTable[c]++;
                }
                else
                {
                    hashTable.Add(c, 1);
                }
            }
            bool oddValueFound = false;
            foreach (var value in hashTable.Values)
            {
                if (IsEven(value)) continue;
                if (oddValueFound)
                {
                    return false;
                }
                else
                {
                    oddValueFound = true;
                }
            }
            return true;
        }

        private static bool IsEven(int input)
        {
            return (input%2) == 0;
        }
        // ReSharper disable once InconsistentNaming
        public static void URLify()
        {
            char[] input = new char[17]
            {'M', 'r', ' ', 'J', 'o', 'h', 'n', ' ', 'S', 'm', 'i', 't', 'h', ' ', ' ', ' ', ' '};
            URLifyImpl(input, 13);
            Console.WriteLine(input);
        }
        // ReSharper disable once InconsistentNaming
        private static void URLifyImpl(char[] input, int strLen)
        {
            int destIndex = input.Length - 1;
            for (int sourceIndex = strLen - 1; sourceIndex >= 0; sourceIndex--)
            {
                if (input[sourceIndex] != ' ')
                {
                    input[destIndex--] = input[sourceIndex];
                }
                else
                {
                    input[destIndex--] = '0';
                    input[destIndex--] = '2';
                    input[destIndex--] = '%';
                }
            }
        }
        public static bool CheckPermutations(string s1, string s2)
        {
            if (s1 == null || s2 == null)
            {
                return false;
            }
            if (s1.Length != s2.Length)
            {
                return false;
            }
            var hashTable = new Dictionary<char, int>();
            foreach (char c in s1)
            {
                if (hashTable.ContainsKey(c))
                {
                    hashTable[c]++;
                }
                else
                {
                    hashTable.Add(c, 1);
                }
            }
            foreach (var c in s2)
            {
                if (!hashTable.ContainsKey(c))
                {
                    return false;
                }
                hashTable[c]--;
                if (hashTable[c] < 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
