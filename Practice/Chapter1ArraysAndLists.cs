using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public static class Chapter1ArraysAndLists
    {
        public static string OneEditAwayCheck(string input1, string input2)
        {
            if(input1 == null || input2 == null)
            {
                return null;
            }
            if(input1.Length == input2.Length)
            {
                // Possible replace 
                int replaceCount = 0;
                for(int i = 0; i < input1.Length; i++)
                {
                    if(input1[i] != input2[i])
                    {
                        replaceCount++;
                        if(replaceCount > 1)
                        {
                            return "Replace: Not One Edit";
                        }
                    }
                }
                if(replaceCount == 1)
                {
                    return "Replace: One Edit";
                }
                else
                {
                    return "Replace: Zero Edit";
                }
            }
            else if(input1.Length > input2.Length)
            {
                int input1Index = 0;
                int input2Index = 0;
                bool removeEnountered = false;
                while(input2Index < input2.Length)
                {
                    if(input2[input2Index] != input1[input1Index])
                    {
                        if(removeEnountered)
                        {
                             return "Remove: Not One Edit";
                        }
                        else
                        {
                            removeEnountered = true;
                        }
                    }
                    else
                    {
                        input2Index++;
                    }
                    input1Index++;
                }
                return "Remove: One Edit";
                // Possible remove
            }
            else
            {
                // Possible insert
                int input1Index = 0;
                int input2Index = 0;
                bool insertEncountered = false;
                while(input1Index < input1.Length)
                {
                     if(input2[input2Index] != input1[input1Index])
                     {
                         if (insertEncountered)
                         {
                             return "Insert: Not One Edit";
                         }
                         else
                         {
                             insertEncountered = true;
                         }
                     }
                     else
                     {
                         input1Index++;
                     }
                    input2Index++;
                }
                return "Insert: One Edit";
            }
        }
        public static string BaseTenToBase(int input, int baseNumber)
        {
            if (baseNumber < 2 || (baseNumber > 10 && baseNumber != 16))
            {
                return null;
            }
            StringBuilder sb = new StringBuilder();
            while(input > 0)
            {
                int remainder = input % baseNumber;
                string digit = DigitToStringInBase(remainder, baseNumber);
                if(digit == null)
                {
                    return null;
                }
                sb.Insert(0,digit);
                input = input / baseNumber;
            }
            return sb.ToString();
        }
        public static string DigitToStringInBase(int digit, int baseNumber)
        {
            if (baseNumber < 2 || (baseNumber > 10 && baseNumber != 16))
            {
                return null;
            }
            if (baseNumber != 16 || digit < 10)
            {
                return digit.ToString();
            }
            char baseChar = (char)('A' - 10);
            return ((char)(baseChar + digit)).ToString();
        }

        public static bool IsPermutationOfPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }
            var hashTable = new Dictionary<char, int>();
            foreach (char c in s)
            {
                char lowerC = char.ToLower(c);
                if (lowerC == ' ')
                {
                    continue;
                }
                if (hashTable.ContainsKey(lowerC))
                {
                    hashTable[lowerC]++;
                }
                else
                {
                    hashTable.Add(lowerC, 1);
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
