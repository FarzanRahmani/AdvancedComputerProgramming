using System;
using System.Collections.Generic;

namespace C10
{
    public interface IMyComparer<_Type> // generic interface
    {
        bool Compare(_Type a, _Type b);

        // bool IsValid {get; set;}
    }

    class DoubleComparer: IMyComparer<double>
    {
        public bool Compare(double a, double b) => a<b;
    }
    class IntComparer: IMyComparer<int>
    {
        public bool Compare(int a, int b) => a<b;
        // {
        //     // if (a < b)
        //     //     return true;
        //     // else
        //     //     return false;
        //     return a<b;
        // }
    }

    public class Program
    {
        public static void Sort<_Type>(_Type[] nums, IMyComparer<_Type> comparer)
        {
            for(int i=0; i<nums.Length; i++)
                for (int j=i; j<nums.Length; j++)
                    if (comparer.Compare(nums[i], nums[j]))
                        Swap<_Type>(nums, i, j);
        }

        // public static void Sort<_Type>(_Type[] nums) where _Type: IMyComparer<_Type>
        // {
        //     for(int i=0; i<nums.Length; i++)
        //         for (int j=i; j<nums.Length; j++)
        //             if (nums[i].Compare(nums[i], nums[j]))
        //                 Swap<_Type>(nums, i, j);
        // }


        private static void Swap<_Type>(_Type[] nums, int i, int j)
        {
            _Type temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        #region Hide
        // private static void Swap(double[] nums, int i, int j)
        // {
        //     double temp = nums[i];
        //     nums[i] = nums[j];
        //     nums[j] = temp;
        // }        
        // public static void Sort(int[] nums, IntComparer comparer)
        // {
        //     for(int i=0; i<nums.Length; i++)
        //         for (int j=i; j<nums.Length; j++)
        //             if (comparer.Compare(nums[i], nums[j]))
        //                 Swap(nums, i, j);
        // }


        private static void Swap1(int[] nums, int i, int j)
        {
            // int temp = nums[i];
            // nums[i] = nums[j];
            // nums[j] = temp;

            int [] newNums = new int[nums.Length];
            for(int k=0; k<newNums.Length; k++)
                newNums[k] = nums[k];

            newNums[i] = nums[j];
            newNums[j] = nums[i];
            nums = newNums;
        }

        // void swap(vector<int> nums, int i, int j) class in C++ --> pass by value
        // {} C++

        // void swap(vector<int>& nums, int i, int j) & --> pass by reference
        // {}

        // void swap(int** pNums, int i, int j)
        // {

        //     pNums[i] = 10;
        //     *pNums = (int*) malloc(10);
        // }
        // int test[10];
        // swap(&test)
        #endregion

        static void Main(string[] args)
        {
            Student[] students = new Student[]{
                new Student("ali", 99521234, 18.2),
                new Student("zahra", 99521334, 19.2),
                new Student("mojdeh", 99521222, 17.2),
                new Student("kiarash", 99521432, 19.2),
                new Student("hasan", 99521112, 15.2),
                new Student("zhaleh", 99521193, 16.2),
                new Student("hossein", 99521154, 14.2),
            };

            Sort<Student>(students, StudentComparer.StudentGPAComparer);
            // StudentGPAComparer gpaComparer = new StudentGPAComparer();
            // Sort<Student>(students, gpaComparer);

            //StudentComparer sc = new StudentComparer();

            foreach(Student s in students)
                System.Console.WriteLine(s);
        }


        static void Main1(string[] args)
        {
            int[] nums = new int[]{5, 4, 2, 1, 10, 12, 2};
            IntComparer comparer = new IntComparer();
            Sort(nums, comparer);

            foreach(int num in nums)
                System.Console.WriteLine(num);
        }
    }
}
