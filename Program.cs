﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Group8_Assignment2_CT_Spring2020
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Question 1");
            int[] l1 = new int[] { 5, 6, 6, 9, 9, 12 };
            int target = 9;
            int[] r = TargetRange(l1, target);
            for(int i = 0; i < r.Length; i++)
            {
                Console.Write(r[i]);
            }
            Console.WriteLine();
            // Write your code to print range r here
            Console.WriteLine("Question 2");
            string s = "University of South Florida";
            string rs = StringReverse(s);
            Console.WriteLine(rs);
            Console.WriteLine("Question 3");
            int[] l2 = new int[] { 4, 5, 6, 9 };
            int sum = MinimumSum(l2);
            Console.WriteLine(sum);*/

            Console.WriteLine("Question 4");
            string s2 = "eebhhh";
            string sortedString = FreqSort(s2);
            Console.WriteLine(sortedString);
            Console.WriteLine("Question 5-Part 1");
            int[] nums1 = { 2, 1, 1, 2 };
            int[] nums2 = { 1, 1, 1 };
            int[] intersect1 = Intersect1(nums1, nums2);
            Console.WriteLine("Part 1- Intersection of two arrays is: ");
            DisplayArray(intersect1);
            Console.WriteLine("\n");
            Console.WriteLine("Question 5-Part 2");
            int[] intersect2 = Intersect2(nums1, nums2);
            Console.WriteLine("Part 2- Intersection of two arrays is: ");
            DisplayArray(intersect2);
            Console.WriteLine("\n");
            Console.WriteLine("Question 6");
            char[] arr = new char[] { 'a', 'b', 'c', 'a', 'b', 'c' };
            int k = 3;
            Console.WriteLine(ContainsDuplicate(arr, k));
            /*Console.WriteLine("Question 7");
            int rodLength = 4;
            int priceProduct = GoldRod(rodLength);
            Console.WriteLine(priceProduct);
            Console.WriteLine("Question 8");
            string[] userDict = new string[] { "rocky", "usf", "hello", "apple" };
            string keyword = "hhllo";
        
            Console.WriteLine(DictSearch(userDict, keyword));
            Console.WriteLine("Question 8");
            SolvePuzzle();*/
        }
        public static void DisplayArray(int[] a)
        {
            foreach (int n in a)
            {
                Console.Write(n + " ");
            }
        }
        public static int[] TargetRange(int[] l1, int t)
        {
            int[] targetRange = new int[2];
            try
            {
                //Write your code here;
                int element = 0;
                for (int i = 0; i < l1.Length; i++)
                {
                    
                    if (t == l1[i])
                    {
                        targetRange[element] = i;
                        element += 1;
                    }
                }
                if (targetRange.Length == 0)
                {
                    targetRange = new int[] { -1, 1 };
                }
            }

            catch (Exception)
            {
                throw;
            }
            return targetRange;
        }
        public static string StringReverse(string s)
        {
            string reverse = "";
            try
            {
                //write your code here
                int spaces = 0;
                foreach(char i in s){
                    if(i == ' ')
                    {
                        spaces += 1;
                    }
                }
                string[] strArray = new string[] { };
                for (int i = s.Length - 1; i >= 0; i--)
                {
                    if(!s[i].Equals(" "))
                    {
                        reverse += s[i];
                    }
                    else
                    {
                        reverse += " ";
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return reverse;
        }
        public static int MinimumSum(int[] l2)
        {
            int sum = 0;
            try
            {
                //Write your code here;
                for(int i = 0; i < l2.Length - 1; i++)
                {
                    if(l2[i] == l2[i + 1])
                    {
                        l2[i + 1] = l2[i + 1] + 1;
                        sum += l2[i];
                    }
                    else
                    {
                        sum += l2[i];
                    }
                }
                sum += l2[l2.Length - 1];
            }
            catch (Exception)
            {
                throw;
            }
            return sum;
        }
        public static string FreqSort(string s2)
        {
            /* Logic: Created a dictionary to store the characters and their counts in the string, 
             sorted the dictionary and then stored the sorted keys from the dictionary depending 
             on their number of occurances in a new string.*/

            //String to store the output
            String freqSorted = "";
            try
            {
                //Write Your Code Here
                //Dictionary to store the string elements and their counts
                Dictionary<char, int> dictionary = new Dictionary<char, int>();
                foreach(char c in s2)
                {
                    if (dictionary.ContainsKey(c))
                    {
                        dictionary[c] += 1;
                    }
                    else
                    {
                        dictionary.Add(c, 1);
                    }
                }
                //Sorted the dictionary in descending order
                dictionary = dictionary.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                //Iterated over each key-value of the sorted list
                foreach(KeyValuePair<char, int> item in dictionary)
                {
                    //Iterated to ensure each key is stored multiple times as per their values
                    for(int i=0; i<item.Value; i++)
                    {
                        freqSorted += item.Key;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return freqSorted;
        }
        public static int[] Intersect1(int[] nums1, int[] nums2)
        {
            /*Logic: Used a while loop to iterate over each item of the two sorted arrays, store them in a string 
             if there is a value match, and increase their indices, else keep the larger array value fixed, and go
             to the next value of the array having a smaller value. */

            //Integer array to store the final return output
            int[] intersect = new int[] { };
            try
            {
                // Write your code here
                int len1 = nums1.Length;
                int len2 = nums2.Length;

                //A string variable to store the matching values
                string intersectedValues = "";

                //Sorted both the arrays
                Array.Sort(nums1);
                Array.Sort(nums2);

                //Variables used to iterate over the indices of the two sorted arrays
                int i = 0;
                int j = 0;

                //In case any of the arrays is null, returned an ampty integer array
                if(nums2 is null || nums2 is null)
                {
                    intersect = new int[] { };
                }

                else
                {
                    //While loop to iterate over the two sorted arrays
                    while (i < len1 && j < len2)
                    {
                        //If there is a value match, value stored in a string and both i, j are increased
                        if (nums1[i] == nums2[j])
                        {
                            intersectedValues += nums1[i];
                            i++;
                            j++;
                        }
                        //i/j are increased to compare next value of array with a smaller value
                        else if (nums1[i] < nums2[j])
                        {
                            i++;
                        }
                        else
                        {
                            j++;
                        }
                    }
                }
                //Length of the interger array is instantiated as the length of the string
                intersect = new int[intersectedValues.Length];

                //For loop to store the string values to the integer array
                for (int k = 0; k < intersectedValues.Length; k++)
                {
                    intersect[k] = int.Parse(intersectedValues[k].ToString());
                }
            }
            catch
            {
                throw;
            }
            return intersect;
        }
        public static int[] Intersect2(int[] nums1, int[] nums2)
        {
            /*Logic: Used a dictionary to store each nums1 element and their counts, then iterate over 
            each element of nums2 and if the element exists as a key in the dictionary, then add it in 
            a string and reduce the count of that key by 1, else remove that key from the dictionary */

            //Integer array to store the final return output
            int[] intersect = new int[] { };
            try
            {
                // Write your code here
                //Dictionary to store the nums1 elements and their counts
                Dictionary<int, int> dict = new Dictionary<int, int>();
                foreach(int i in nums1)
                {
                    if (dict.ContainsKey(i))
                    {
                        dict[i] += 1;
                    }
                    else
                    {
                        dict.Add(i, 1);
                    }
                }

                //String to store the intersecting elements
                string intersectedValues = "";

                //For loop to iterate over each element of nums2 to find an intersect
                foreach (int i in nums2)
                {
                    if (dict.ContainsKey(i))
                    {
                        intersectedValues += i;
                        if(dict[i] > 1)
                        {
                            dict[i]--;
                        }
                        else
                        {
                            dict.Remove(i);
                        }
                    }
                }
                // Length of the integer array is set as the length of the string
                intersect = new int[intersectedValues.Length];

                //For loop to store the string values to the integer array
                for(int i=0; i < intersectedValues.Length; i++)
                {
                    intersect[i] = int.Parse(intersectedValues[i].ToString());
                }
            }
            catch
            {
                throw;
            }
            return intersect;
        }

        public static bool ContainsDuplicate(char[] arr, int k)
        {
            /* Logic: A dictionary is used to store the char element by iterating over a for loop, 
             and in case it exists in the dictionary, its value is stored in a new variable index 
             and the difference between both the indices is checked against k */ 
            try
            {
                //Write your code here;
                //Dictionary to store a new char value
                Dictionary<char, int> dict = new Dictionary<char, int>();

                //For loop to iterate over each char element
                for(int i = 0; i < arr.Length; i++)
                {
                    //Variables to store the old index value and the difference
                    int index = 0;
                    int diff = 0;

                    //If the dictionary contains the char element, the difference between their index values is calculated
                    if (dict.ContainsKey(arr[i]))
                    {
                        index = dict[arr[i]];
                        diff = i - index;
                        dict.Remove(arr[i]);
                        dict.Add(arr[i], i);
                    }
                    else
                    {
                        dict.Add(arr[i], i);
                    }

                    //If the difference is > 0, but <= k, our condition is satisfied
                    if(diff > 0 && diff <= k)
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }
    }
}