using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Write your code here
                if (nums == null || nums.Length == 0)
                {
                     // Return empty list if input is null or empty
                    return new List<int>(); 
                }

                // Get the maxi value in the input array for the range of numbers
                int maxNum = nums.Length;
                // Create a HashSet to store all unique numbers
                HashSet<int> numSet = new HashSet<int>(nums);

                List<int> missingNumbers = new List<int>();

                for (int i = 1; i <= maxNum; i++)
                {
                    // If the number is not in the HashSet, it is missing
                    if (!numSet.Contains(i))
                    {
                        missingNumbers.Add(i);
                    }
                }

                return missingNumbers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Write your code here
                if (nums == null)
                {
                    throw new ArgumentNullException(nameof(nums), "Input array cannot be null."); // Handle null array
                }

                // Two pointers to rearrange even and odd numbers
                int evenIndex = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    // If the number is even, swap
                    if (nums[i] % 2 == 0)
                    {
                        Swap(nums, i, evenIndex);
                        evenIndex++;  // Move the even index forward
                    }
                }

                return nums;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Write your code here
                if (nums == null)
                {
                    throw new ArgumentNullException(nameof(nums), "Input array cannot be null."); // Handle null array
                }

                if (nums.Length < 2)
                {
                    throw new ArgumentException("Input array must contain at least two numbers.", nameof(nums)); // Ensure sufficient elements
                }

                Dictionary<int, int> numDict = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    // Calculate the complement needed to reach the target
                    int complement = target - nums[i];
                    // Check if the complement exists in the dictionary
                    if (numDict.ContainsKey(complement))
                    {
                        return new int[] { numDict[complement], i };
                    }

                    // Add the current number and its index to the dictionary
                    if (!numDict.ContainsKey(nums[i])) // Only add if it doesn't already exist
                    {
                        numDict[nums[i]] = i;
                    }
                }
                throw new InvalidOperationException("No two sum solution exists for the provided input.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Write your code here
                if (nums == null)
                {
                    throw new ArgumentNullException(nameof(nums), "Input array cannot be null."); // Handle null array
                }

                if (nums.Length < 3)
                {
                    throw new ArgumentException("Input array must contain at least three numbers.", nameof(nums)); // Ensure enough elements
                }

                Array.Sort(nums);
                // The maximum product can be obtained by either:
                // The product of the three largest numbers or The product of the two smallest (possibly negative) numbers and the largest number
                int maxProduct = Math.Max(nums[nums.Length - 1] * nums[nums.Length - 2] * nums[nums.Length - 3], // Three largest
                                        nums[0] * nums[1] * nums[nums.Length - 1]); // Two smallest and largest

                return maxProduct;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Write your code here
                if (decimalNumber < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(decimalNumber), "Input cannot be a negative number."); // Handle negative input
                }

                if (decimalNumber == 0)
                {
                    return "0";
                }

                string binaryResult = string.Empty;

                while (decimalNumber > 0)
                {
                    // Prepend the remainder (0 or 1) to the binary result
                    binaryResult = (decimalNumber % 2) + binaryResult;
                    decimalNumber /= 2; 
                }

                return binaryResult;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                // Write your code here
                if (nums == null)
                {
                    throw new ArgumentNullException(nameof(nums), "Input array cannot be null."); 
                }

                if (nums.Length == 0)
                {
                    throw new ArgumentException("Input array cannot be empty.", nameof(nums));
                }

                int left = 0;
                int right = nums.Length - 1;

                // Binary search
                while (left < right)
                {
                    int mid = left + (right - left) / 2;
                    
                     // If mid element is greater than the rightmost element, the minimum is in the right half
                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1;
                    }
                    // Otherwise, the minimum is in the left half (including mid)
                    else
                    {
                        right = mid;
                    }
                }
                // Left will point to the minimum element, as position will be swap at the loop ends.
                return nums[left];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Write your code here
                if (x < 0)
                {
                    return false;
                }

                int original = x;
                int reversed = 0;

                while (x > 0)
                {
                    int lastDigit = x % 10;
                    // Prevent integer overflow for large numbers
                    if (reversed > (int.MaxValue - lastDigit) / 10)
                    {
                        throw new OverflowException("Integer overflow occurred while reversing the number.");
                    }
                    // A number is a palindrome if it equals its reverse
                    reversed = reversed * 10 + lastDigit;
                    x /= 10;
                }

                return original == reversed;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Write your code here
                if (n < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(n), "Input cannot be negative.");
                }

                if (n == 0) return 0;
                if (n == 1) return 1;

                int a = 0, b = 1;

                // Iteratively calculate Fibonacci values up to n - Tabular aproach
                for (int i = 2; i <= n; i++)
                {
                    int temp = a + b;
                    if (temp < 0)
                    {
                        throw new OverflowException("Integer overflow occurred while calculating Fibonacci.");
                    }
                    a = b;
                    b = temp;
                }

                return b;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
