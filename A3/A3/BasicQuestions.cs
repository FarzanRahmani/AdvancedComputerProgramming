using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
	public class BasicQuestions
	{
		
		public static int OddSum(int[] nums)
		{
			int sum = 0;
			for (int i = 0; i < nums.Length; i++)
				if (nums[i] % 2 == 1)
					sum += nums[i];
			return sum;
		}

		public static void Swap<_T>(ref _T a,ref _T b)
		{
			_T tem= a;
			a = b;
			b = tem; 
		}
	
		public static void AssignPi(out double x)
		{
			x = Math.PI;
		}

		public static void Square(ref int y)
		{
			y = y*y;
		}

		public static void Append(ref int[] nums,int num)
		{
			int[] res = new int[nums.Length+1];
			int i;
			for (i = 0; i < nums.Length; i++)
			{
				res[i] = nums[i];
			}
			res[i] = num;
			nums = res;
		}

		public static void AbsArray(ref int[] nums)
		{
			for (int i = 0; i < nums.Length; i++)
				if (nums[i] < 0)
					nums[i] *= -1;
		}

		public static void ArrayElementSwap(ref int[] nums1,ref int[] nums2)
		{
			int tem;
			for (int i = 0; i < nums1.Length; i++)
			{
				tem = nums1[i];
				nums1[i] = nums2[i];
				nums2[i] = tem;
			}
		}

        public static void ArraySwap(ref int[] nums1, ref int[] nums2)
        {
			Swap(ref nums1,ref nums2);
    	}
	}
	public interface IHasAge
	{
		int GetAge();
	}

	public class Human :IHasAge  
	{
		private string name;
		private int age;

		public Human(string n, int a)
		{
			name = n ; age = a ;
		}
		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}

		public int GetAge()
		{
			return age;
		}
	}
}
