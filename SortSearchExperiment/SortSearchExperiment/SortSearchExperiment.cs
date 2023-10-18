/***************************************************************
* Name : Sort-Search Experiment
* Author: Jhon Paul Espiritu
* Created : 10/16/2023
* Course: CIS 152 - Data Structure
* Version: 1.0
* OS: Windows 10
* IDE: Visual Studio 22
* Copyright : This is my own original work 
* based onspecifications issued by our instructor
* Description : Model showcasing the uses of both search and sort algorithms in programming.
*            Input: None
*            Ouput: Sort-Search Output Test cases, as well as Word file documentation.
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or
* unmodified. I have not given other fellow student(s) access
* to my program.
***************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace SortSearchExperiment
{
    class Program
    {
        /**************************************************************
        * Class Variables
        ***************************************************************/

        const int LINEAR_SEARCH_ITEM = 73;
        const int BINARY_SEARCH_ITEM = 4096;
        const int BINARY_SEARCH_ITEM2 = 2;
        const int SORT_MIN = 0;
        const int SORT_MAX = 1001;
        const int SORT_SEARCH_VALUE = 882;

        /// <summary>
        /// Returns a formatted string of allotted time.
        /// </summary>
        /// <param name="watchToTest">Stopwatch to gain timespan from.</param>
        /// <returns>String format of Stopwatch time.</returns>
        static string TestTime(Stopwatch watchToTest)
        {

            // Format and display the TimeSpan value.
            string elapsedTime = watchToTest.Elapsed.TotalMilliseconds + " milliseconds";
            return elapsedTime;
        }

        /// <summary>
        /// A linear search goes through each item in an array to check if an object is equal to the object to find. O(N) complexity is at play.
        /// - When to use:
        /// For smaller data-sets (arrays) which don't require a large amount of searching to be done. 
        /// Unsorted data-sets, as linear search goes through each item to find data.
        /// - When not to use:
        /// On larger data-sets which require tons of searching to be done (O(N) worst-case scenario being at the end of the array).
        /// </summary>
        /// <param name="searchArray">Array to search through.</param>
        /// <param name="itemToFind">Item to find in the array.</param>
        /// <returns>Index of item in array.</returns>
        public static int LinearSearch(int[] searchArray, int itemToFind)
        {
            // Loops through each item in array to find desired item, indexing the amount.
            int index = 0;
            foreach (int item in searchArray)
            {
                if (item == itemToFind)
                {
                    return index;
                }
                index++;
            }

            // Returns negative if item is not found.
            return -1;
        }

        /// <summary>
        /// A binary search that recursively searches through an array to check if object is equal to object to find. O(log N) complexity.
        /// - When to use:
        /// For larger data-sets that require more items to be searched through, such as databases. 
        /// - When not to use: 
        /// On unsorted data-sets, as binary searches require them to be sorted in order to search correctly.
        /// </summary>
        /// <param name="searchArray">Array to search through.</param>
        /// <param name="lowValue">Lowest size index to search through.</param>
        /// <param name="highValue">Highest size index to search through.</param>
        /// <param name="itemToFind">Item to find in the array.</param>
        /// <returns>Index of item in array.</returns>
        public static int BinarySearch(int[] searchArray, int lowValue, int highValue, int itemToFind)
        {
            // Search assumes that array is already sorted.
            if (highValue >= lowValue)
            {
                // Formulas and index recursion found in
                // https://www.geeksforgeeks.org/binary-search/
                int indexMiddle = lowValue + (highValue - lowValue) / 2;

                // If item is the middle, return index.
                if (searchArray[indexMiddle] == itemToFind)
                {
                    return indexMiddle;
                }

                // If item is smaller than the middle index, search left of array.
                // Sets high value to middle index, minus one.
                if (searchArray[indexMiddle] > itemToFind)
                {
                    return BinarySearch(searchArray, lowValue, indexMiddle - 1, itemToFind);
                }
                // Else search right of array.
                // Sets low value to middle index, plus one.
                else
                {
                    return BinarySearch(searchArray, indexMiddle + 1, highValue, itemToFind);
                }
            }

            // Returns negative if item is not found.
            return -1;
        }

        /// <summary>
        /// Attention! Code modified but originally not mine. Citation: https://www.geeksforgeeks.org/bubble-sort/
        /// Summary in word document.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="n"></param>
        static void BubbleSort(int[] searchArray)
        {
            // Obtained code from:
            // https://www.geeksforgeeks.org/bubble-sort/#:~:text=of%20Bubble%20Sort-,static%20void%20bubbleSort(int%5B%5D%20arr%2C%20int%20n),%C2%A0%C2%A0%C2%A0%C2%A0%7D,-//%20Function%20to%20print

            int sizeToSort = searchArray.Length;

            // Temp value to store value of item in array.
            int temp1, temp2;
            // Indicates that a value was swapped: If not, stop the loop to optimize searching.
            bool swapped;

            // This loop iterates through each element of the array minus the last value.
            for (int i = 0; i < sizeToSort - 1; i++)
            {
                swapped = false;
                // Iterates through size minus the index amount of first loop.
                for (int j = 0; j < sizeToSort - i - 1; j++)
                {
                    // If value is greater than the next value, swap values.
                    if (searchArray[j] > searchArray[j + 1])
                    {
                        temp1 = searchArray[j];
                        temp2 = searchArray[j + 1];
                        searchArray[j] = temp2;
                        searchArray[j + 1] = temp1;
                        swapped = true;
                    }
                }

                // If no values were swapped, stop the loop.
                if (swapped == false)
                    break;
            }
        }

        /// <summary>
        /// Attention! Code modified but originally not mine. Citation: https://www.geeksforgeeks.org/selection-sort/
        /// </summary>
        /// <param name="arr"></param>
        static void SelectionSort(int[] searchArray)
        {
            // Obtained code from:
            // https://www.geeksforgeeks.org/selection-sort/#:~:text=%7B-,static%20void%20sort(int%20%5B%5Darr),%C2%A0%C2%A0%C2%A0%C2%A0%7D,-//%20Prints%20the%20array

            int sizeToSort = searchArray.Length;
            int temp;
            // Variable to record the minimum index in the array.
            int minIndex;

            // One by one move boundary of unsorted subarray
            for (int i = 0; i < sizeToSort - 1; i++)
            {
                // Find the smallest item in array
                minIndex = i;
                for (int j = i + 1; j < sizeToSort; j++)
                    if (searchArray[j] < searchArray[minIndex])
                        minIndex = j;

                // Swap with smallest item in array after finding it
                temp = searchArray[minIndex];
                searchArray[minIndex] = searchArray[i];
                searchArray[i] = temp;
            }
        }

        /// <summary>
        /// Attention! Code modified but originally not mine. Citation: https://www.geeksforgeeks.org/insertion-sort/#
        /// Edited slighty.
        /// Summary in word document.
        /// </summary>
        /// <param name="arr"></param>
        static void InsertionSort(int[] searchArray)
        {
            // Obtained code from:
            // https://www.geeksforgeeks.org/insertion-sort/#:~:text=using%20insertion%20sort-,void%20sort(int%5B%5D%20arr),%C2%A0%C2%A0%C2%A0%C2%A0%7D,-//%20A%20utility%20function

            int sizeToSort = searchArray.Length;

            // Variable to record current value in ongoing array.
            int key;
            // Variable to record previous index of array.
            int j;

            // Iterates through loop, starting at second value.
            for (int i = 1; i < sizeToSort; ++i)
            {
                key = searchArray[i];
                j = i - 1;

                // Until j iterates to the first value, and is greater than the current index value,
                // searches left until key value is found greater than searched value.
                while (j >= 0 && searchArray[j] > key)
                {
                    searchArray[j + 1] = searchArray[j];
                    j = j - 1;
                }
                searchArray[j + 1] = key;
            }
        }

        /// <summary>
        /// Retrieves the last hundred items in an array in a string, seperated by a comma.
        /// </summary>
        /// <param name="arr">Array to search in.</param>
        /// <returns>String returning last twenty items.</returns>
        static string LastHundredItems(int[] arr)
        {
            string returnString = "";
            for (int i = arr.Length - 100; i < arr.Length; i++) {
                if (i != arr.Length - 1)
                {
                    returnString += arr[i] + ", ";
                }
                else
                {
                    returnString += arr[i];
                }
            }

            return returnString;
        }

        static void Main(string[] args)
        {
            // Stopwatch to test time.
            Stopwatch stopWatch = new Stopwatch();
            Stopwatch linearySearchWatch = new Stopwatch();
            Stopwatch binarySearchWatch = new Stopwatch();
            Random rand = new Random();

            /* ----------------------------------------------
             * Linear Searching - https://www.geeksforgeeks.org/linear-search/#
             * ---------------------------------------------- */
            int[] arrayToSearch = new int[] { 52, 73, 84 };
            int result;

            // Part 1
            Console.WriteLine("--------Linear Search: -------- \n");
            Console.WriteLine("Desired Item: " + LINEAR_SEARCH_ITEM);
            result = LinearSearch(arrayToSearch, LINEAR_SEARCH_ITEM);
            if (result == -1)
            {
                Console.WriteLine("Item Was Not Found in Array.");
            }
            else
            {
                Console.WriteLine(LINEAR_SEARCH_ITEM + " was found at index " + result);
            }

            // Part 2
            arrayToSearch = new int[] { 52, 84 };
            int result2;
            result2 = LinearSearch(arrayToSearch, LINEAR_SEARCH_ITEM);
            Console.WriteLine();
            Console.WriteLine("New array was created.");
            if (result2 == -1)
            {
                Console.WriteLine("Item Was Not Found in Array.");
            }
            else
            {
                Console.WriteLine(LINEAR_SEARCH_ITEM + " was found at index " + result2);
            }

            /* ----------------------------------------------
             * Binary Searching - https://www.geeksforgeeks.org/binary-search/
             * ---------------------------------------------- */
            int[] bArrayToSearch = new int[] { 1, 2, 4, 8, 16, 32, 64, 128, 
                                               256, 512, 1024, 2048, 4096, 8192 };
            int bResult;

            // Part 1
            Console.WriteLine();
            Console.WriteLine("--------Binary Search: -------- \n");
            Console.WriteLine("Desired Item: " + BINARY_SEARCH_ITEM);
            bResult = BinarySearch(bArrayToSearch, 0, bArrayToSearch.Length, BINARY_SEARCH_ITEM);
            if (bResult == -1)
            {
                Console.WriteLine("Item Was Not Found in Array.");
            }
            else
            {
                Console.WriteLine(BINARY_SEARCH_ITEM + " was found at index " + bResult);
            }

            // Part 2
            bResult = BinarySearch(bArrayToSearch, 0, bArrayToSearch.Length, BINARY_SEARCH_ITEM2);
            Console.WriteLine();
            Console.WriteLine("Searching the other way.");
            if (bResult == -1)
            {
                Console.WriteLine("Item Was Not Found in Array.");
            }
            else
            {
                Console.WriteLine(BINARY_SEARCH_ITEM2 + " was found at index " + bResult);
            }

            /* ----------------------------------------------
             * Bubble Sort - https://www.geeksforgeeks.org/bubble-sort/
             * ---------------------------------------------- */
            Console.WriteLine("\n --------Bubble Sort: --------");

            int[] bubbleSortArray = new int[10000];
            for (int i = 0; i < bubbleSortArray.Length; i++)
            {
                bubbleSortArray[i] = rand.Next(SORT_MIN, SORT_MAX);
            }
            linearySearchWatch.Start();
            LinearSearch(bubbleSortArray, SORT_SEARCH_VALUE);
            linearySearchWatch.Stop();

            /*
            Console.WriteLine();
            Console.WriteLine("Last Hundred Items in Bubble Sort Array:");
            Console.WriteLine(LastHundredItems(bubbleSortArray));
            */

            stopWatch.Start();
            BubbleSort(bubbleSortArray);
            stopWatch.Stop();

            /*
            Console.WriteLine();
            Console.WriteLine("Last Hundred Items after Sorting:");
            Console.WriteLine(LastHundredItems(bubbleSortArray));
            */
            
            binarySearchWatch.Start();
            BinarySearch(bubbleSortArray, 0, bubbleSortArray.Length, SORT_SEARCH_VALUE);
            binarySearchWatch.Stop();

            Console.WriteLine();
            Console.WriteLine("Bubble Sort - Linear Search time: " + TestTime(linearySearchWatch));
            Console.WriteLine("Time it took to sort Bubble Sort of " + bubbleSortArray.Length + " items: " + TestTime(stopWatch));
            Console.WriteLine("Bubble Sort - Binary Search time: " + TestTime(binarySearchWatch));

            /* ----------------------------------------------
             * Selection Sort - https://www.geeksforgeeks.org/selection-sort/
             * ---------------------------------------------- */
            Console.WriteLine("\n --------Selection Sort: --------");
            int[] selectionSortArray = new int[10000];
            for (int i = 0; i < selectionSortArray.Length; i++)
            {
                selectionSortArray[i] = rand.Next(SORT_MIN, SORT_MAX);
            }
            linearySearchWatch.Restart();
            LinearSearch(selectionSortArray, SORT_SEARCH_VALUE);
            linearySearchWatch.Stop();

            /*
            Console.WriteLine();
            Console.WriteLine("Last Hundred Items in Selection Sort Array:");
            Console.WriteLine(LastHundredItems(selectionSortArray));
            */

            stopWatch.Restart();
            SelectionSort(selectionSortArray);
            stopWatch.Stop();

            /*
            Console.WriteLine();
            Console.WriteLine("Last Hundred Items after Sorting:");
            Console.WriteLine(LastHundredItems(selectionSortArray));
            */

            binarySearchWatch.Start();
            BinarySearch(selectionSortArray, 0, selectionSortArray.Length, SORT_SEARCH_VALUE);
            binarySearchWatch.Stop();

            Console.WriteLine();
            Console.WriteLine("Selection Sort - Linear Search time: " + TestTime(linearySearchWatch));
            Console.WriteLine("Time it took to sort Selection Sort of " + selectionSortArray.Length + " items: " + TestTime(stopWatch));
            Console.WriteLine("Selection Sort - Binary Search time: " + TestTime(binarySearchWatch));

            /* ----------------------------------------------
             * Insertion Sort - https://www.geeksforgeeks.org/insertion-sort/#
             * ---------------------------------------------- */
            Console.WriteLine("\n --------Insertion Sort: --------");
            int[] insertionSortArray = new int[10000];
            for (int i = 0; i < insertionSortArray.Length; i++)
            {
                insertionSortArray[i] = rand.Next(SORT_MIN, SORT_MAX);
            }
            linearySearchWatch.Restart();
            LinearSearch(insertionSortArray, SORT_SEARCH_VALUE);
            linearySearchWatch.Stop();

            /*
            Console.WriteLine();
            Console.WriteLine("Last Hundred Items in Insertion Sort Array:");
            Console.WriteLine(LastHundredItems(insertionSortArray));
            */

            stopWatch.Restart();
            InsertionSort(insertionSortArray);
            stopWatch.Stop();

            /*
            Console.WriteLine();
            Console.WriteLine("Last Hundred Items after Sorting:");
            Console.WriteLine(LastHundredItems(insertionSortArray));
            */

            binarySearchWatch.Start();
            BinarySearch(insertionSortArray, 0, insertionSortArray.Length, SORT_SEARCH_VALUE);
            binarySearchWatch.Stop();

            Console.WriteLine();
            Console.WriteLine("Insertion Sort - Linear Search time: " + TestTime(linearySearchWatch));
            Console.WriteLine("Time it took to sort Insertion Sort of " + insertionSortArray.Length + " items: " + TestTime(stopWatch));
            Console.WriteLine("Insertion Sort - Binary Search time: " + TestTime(binarySearchWatch));

            Console.ReadLine();
        }
    }
}
