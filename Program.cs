using System;
using System.Collections.Generic;
using System.Linq;

namespace _2019_Fall_Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            //1st question
            int target = 2;
            int[] nums = { 1, 3, 5, 6 };
            Console.WriteLine("Position to insert {0} is = {1}\n", target, SearchInsert(nums, target));

            //2nd question
            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };
            int[] intersect = Intersect(nums1, nums2);
            Console.WriteLine("Intersection of two arrays is:");
            DisplayArray(intersect);
            Console.WriteLine("\n");

            //3rd question
            int[] arr = { 5, 7, 3, 9, 4, 9, 8, 3, 1 };
            //int[] arr = { 9, 9, 8, 8 };
            Console.WriteLine("Largest integer occuring once = {0}\n", LargestUniqueNumber(arr));

            //4th question
            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "cba";
            Console.WriteLine("Time taken to type with one finger = {0}\n", CalculateTime(keyboard, word));
            //Input keyboard and string to traverse

            //5th question
            int[,] image = { { 1, 1, 0 }, { 1, 0, 1 }, { 0, 0, 0 } };
            //int[,] image = { { 1, 1, 0, 0 }, { 1, 0, 0, 1 }, { 0, 1, 1, 1 }, { 1, 0, 1, 0 } };
            int[,] newImage = FlipAndInvertImage(image);
            Console.WriteLine("The resulting flipped and inverted image is:\n");
            Display2DArray(newImage);
            Console.Write("\n");

            //6th question
            int[,] intervals = { { 0, 30 }, { 5, 10 }, { 15, 20 } };// Input array of start and end times
           // int[,] intervals = { { 7,10 }, { 2,4 } };
            int test = MinMeetingRooms(intervals);
            Console.WriteLine("Minimum meeting rooms needed = {0}\n", test);

            //7th question
            int[] arr1 = { -4, -1, 0, 3, 10 };
            int[] sortedSquares = SortedSquares(arr1);
            Console.WriteLine("Squares of the array in sorted order is:");
            DisplayArray(sortedSquares);
            Console.Write("\n");

            //8th question
            string s = "abca";
            Console.Write("\n");
            if (ValidPalindrome(s))
            {
                Console.WriteLine("The given string \"{0}\" can be made PALINDROME", s);
            }
            else
            {
                Console.WriteLine("The given string \"{0}\" CANNOT be made PALINDROME", s);
            }


        }
        public static void DisplayArray(int[] a)
        {
            //displayarray method will store all the value of the 'alpha' array created above in the variable r5.
            int i = 0;
            Console.Write("[");
            foreach (var commonsubarray in a)
            {
                Console.Write(a[i]);
                if (i < a.Length - 1)
                {
                    Console.Write(",");
                }
                i++;
            }
            Console.Write("]");
        }

        public static void Display2DArray(int[,] A)
        {
            for (int i = 0; i <= A.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= A.GetUpperBound(1); j++)
                {
                    Console.Write(A[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int i = 0;
                int j = nums.Length - 1;

                while (i <= j)         		//while loop to find index of target value
                {
                    int mid = (i + j) / 2;	// to find the mid value and compare target with mid inorder to find its position if present

                    if (target > nums[mid])
                    {
                        i = mid + 1;
                    }
                    else if (target < nums[mid])
                    {
                        j = mid - 1;
                    }
                    else
                    {
                        return mid;
                    }
                }

                return i;

            }
            catch
            {
                Console.WriteLine("Exception occured while computing SearchInsert()");
            }

            return 0;
        }
        public static int[] Intersect(int[] nums1,
                        int[] nums2)
        {

            try
            {


                int m = nums1.Length;
                int n = nums2.Length;



                // Now arr1[] is smaller 
                // Sort smaller array arr1[0..m-1] 
                Array.Sort(nums1);
                Array.Sort(nums2);

                int i = 0, j = 0;
                var numberseries = new List<int>();

                while (i < m && j < n)
                {

                    if (nums1[i] < nums2[j])
                        i++;
                    else if (nums2[j] < nums1[i])
                        j++;
                    else
                    {
                        /* Console.Write(nums2[j++] + " ");
                         i++;*/
                        numberseries.Add(nums2[j++]);
                        i++;
                    }
                }
                int[] wyj = new int[numberseries.Count];
                for (int z = 0; z < numberseries.Count; z++)
                {

                    wyj[z] = numberseries[z];

                }
                return wyj;
            }

            catch

            {

                Console.WriteLine("Exception occured while computing Intersect()");

            }

            return null;
        }

        public static int LargestUniqueNumber(int[] A)
        {
            try
            {
                Dictionary<int, bool> dictNumbers = new Dictionary<int, bool>(A.Length);
                for (int i = 0; i < A.Length; i++)
                {
                    try
                    {
                        dictNumbers.Add(A[i], true);
                    }
                    catch (ArgumentException)
                    {
                        dictNumbers[A[i]] = false;
                    }
                }
                int max = -1;
                foreach (var item in dictNumbers)
                {
                    if (item.Value != false && item.Key >= max)
                        max = item.Key;
                }
                return max;
            }

            catch

            {

                Console.WriteLine("Exception occured while computing LargestUniqueNumber()");

            }

            return 0;
        }

        public static int CalculateTime(string keyboard, string word)
        {
            try
            {
                if (keyboard != null && keyboard.Length != 26) //Constraint of keyboard length of 26 is checked
                {
                    Console.WriteLine("Please enter a valid keyboard string");
                }
                if (word != null && (word.Length < 1 || word.Length > 10000)) // Constraint of word length is checked
                {
                    Console.WriteLine("Please enter a vaild word");
                }

                Dictionary<char, int> dictKeyboard = new Dictionary<char, int>(26); // Dictionary is initialized as Key,Value
                for (int i = 0; i < keyboard.Length; i++)
                {
                    dictKeyboard.Add(keyboard[i], i);    // Input of keyboard is added to dictionary as Key
                }
                int position = 0, dist = 0; // Distant is the return variable with the distance covered by the single finger to type word
                for (int i = 0; i < word.Length; i++)
                {
                    if (dictKeyboard.ContainsKey(word[i]))
                    {
                        int keyValue = 0;
                        dictKeyboard.TryGetValue(word[i], out keyValue); // When the desired key is found the value is output to keyValue 
                        dist += (int)Math.Abs(keyValue - position); // Distance covered is added in iteration. The Absolute value is added to deal with negative number returns
                        position = keyValue;
                    }
                }

                return dist;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing CalculateTime()");
                return 0;
            }
        }

        public static int[,] FlipAndInvertImage(int[,] A)
        {
            int rows = A.GetUpperBound(0);
            int colums = A.GetUpperBound(1);
            if (A.Length < 1 || colums > 20)
            {
                Console.WriteLine("");
                return new int[rows, colums];
            }

            int[,] newImage = new int[rows + 1, colums + 1];

            for (int i = 0; i <= rows; i++)
            {
                for (int j = 0; j <= colums; j++)
                {
                    newImage[i, j] = A[i, colums - j];
                }
            }
            for (int i = 0; i <= rows; i++)
            {
                for (int j = 0; j <= colums; j++)
                {
                    if (newImage[i, j] == 1)
                        newImage[i, j] = 0;
                    else if (newImage[i, j] == 0)
                        newImage[i, j] = 1;
                    else
                    {
                        Console.WriteLine("0 <= A[i][j] <= 1");
                        return new int[rows, colums];
                    }
                }
            }

            return newImage;
        }

        public static int MinMeetingRooms(int[,] intervals)
        {
            try
            {
                List<int> lstStart = new List<int>(); //Initialize a list for meeting start time
                List<int> lstEnd = new List<int>(); // Initialize a list for meeting end time
                for (int i = 0; i < intervals.Length / 2; i++)
                {
                    lstStart.Add(intervals[i, 0]); // Add elemets to meeting start time list
                    lstEnd.Add(intervals[i, 1]); // Add elements to meeting end time list
                }

                lstStart = lstStart.OrderBy(item => item).ToList(); // Sort the meeting start time list
                lstEnd = lstEnd.OrderBy(item => item).ToList(); // Sort the meeting end time list

                SortedList<int, bool> meetingRoom = new SortedList<int, bool>();
                if (intervals.Length > 0) // If there is a meeting time add a meeting room by default first
                    meetingRoom.Add(1, false);

                int time = 0;
                while (true)
                {
                    if (lstEnd.Count == 0) // If there is no more endtimes left break
                        break;

                    if (lstEnd.Contains(time)) // If there is an endtime continue to execute
                    {
                        int count = lstEnd.Where(item => item == time).ToList().Count;
                        for (int i = 0; i < count; i++)
                        {
                            int index = meetingRoom.IndexOfValue(true);
                            meetingRoom[meetingRoom.Keys[index]] = false;
                            lstEnd.Remove(time);
                        }
                    }

                    if (lstStart.Contains(time)) // If there is an starttime continue to execute
                    {
                        int count = lstStart.Where(item => item == time).ToList().Count;
                        for (int i = 0; i < count; i++)
                        {
                            if (meetingRoom.ContainsValue(false)) // Evaluate if meetingroom has a value
                            {
                                int index = meetingRoom.IndexOfValue(false); // Assign a meeting room that is available
                                meetingRoom[meetingRoom.Keys[index]] = true;
                            }
                            else
                            {
                                meetingRoom.Add(meetingRoom.Count + 1, true); // If no meeting rooms are available increase the meeting room count
                            }
                        }
                    }
                    time++; // Increment the time
                }

                return meetingRoom.Count;
            }
            catch
            {
                Console.WriteLine("Exception occured while trying to execute MinMeetingRooms()");
                return 0;
            }
        }

        public static int[] SortedSquares(int[] A)
        {
            try
            {
                // Write your code here

                int n = A.Length;
                int j = 0;
                while (j < n && A[j] < 0)
                    j++;
                int i = j - 1;
                int[] ans = new int[n];

                int t = 0;

                while (i >= 0 && j < n)
                {
                    if (A[i] * A[i] < A[j] * A[j])
                    {
                        ans[t++] = A[i] * A[i];
                        i--;
                    }
                    else
                    {
                        ans[t++] = A[j] * A[j];
                        j++;
                    }
                }
                while (i >= 0)
                {
                    ans[t++] = A[i] * A[i];
                    i--;
                }
                while (j < n)
                {
                    ans[t++] = A[j] * A[j];
                    j++;
                }

                return ans;

            }
            catch
            {
                Console.WriteLine("Exception occured while computing SortedSquares()");
            }

            return new int[] { };
        }

        public static bool PalindromeCheck(string s)
        {
            int x = 0;
            int y = s.Length - 1;
            while (true)
            {
                if (x > y)
                {
                    return true;
                }
                char a = s[x];
                char b = s[y];
                if (char.ToLower(a) != char.ToLower(b))
                {
                    return false;
                }
                x++;
                y--;
            }
        }
        public static bool ValidPalindrome(string s)
        {
            try
            {
                int l = s.Length - 1;
                int len = 0;
                bool result = PalindromeCheck(s);
                if (result == true)
                {
                    return result;
                }
                else
                {
                    while (len <= l)
                    {
                        var x = s.Remove(len++, 1);
                        bool result2 = PalindromeCheck(x);
                        if (result2 == true)
                        {
                            return result2;
                        }
                    }
                }
                return false;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing ValidPalindrome()");
            }
            return false;
        }

    }
}
