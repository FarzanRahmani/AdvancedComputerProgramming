using Microsoft.VisualStudio.TestTools.UnitTesting;
using A3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3.Tests
{
    [TestClass()]
    public class BasicQuestionsTests
    {
        [TestMethod()]
        public void HumanTest()
        {
            Human h = new Human("Hooman", 21);
            Assert.AreEqual("Hooman", h.Name);

            h = new Human("Mozhgan", 18);
            Assert.AreEqual("Mozhgan", h.Name);
        }

        [TestMethod()]
        public void HumanAgeTest()
        {
            IHasAge h = new Human("Hooman", 21);
            Assert.AreEqual(21, h.GetAge());

            h = new Human("Mozhgan", 18);
            Assert.AreEqual(18, h.GetAge());
        }

        [TestMethod()]
        public void SwapIntTest()
        {
            int a = 1, b = 2;
            BasicQuestions.Swap(ref a, ref b);
            Assert.AreEqual(a, 2);
            Assert.AreEqual(b, 1);
        }

        [TestMethod()]
        public void SwapdoubleTest()
        {
            double a = 1, b = 2;
            BasicQuestions.Swap(ref a, ref b);
            Assert.AreEqual(a, 2);
            Assert.AreEqual(b, 1);
        }

        [TestMethod()]
        public void SwaplongTest()
        {
            long a = 1, b = 2;
            BasicQuestions.Swap(ref a, ref b);
            Assert.AreEqual(a, 2);
            Assert.AreEqual(b, 1);
        }

        [TestMethod()]
        public void OddSumTest()
        {
            int[] nums = new int[] { 1, 5, 4, 3, 12 };
            Assert.AreEqual(9, BasicQuestions.OddSum(nums));

            nums = new int[] { 1, 5, 4, 3, 12, 1 };
            Assert.AreEqual(10, BasicQuestions.OddSum(nums));
        }

        [TestMethod()]
        public void AssignPiTest()
        {
            double d; // chon initialize nakarde out
            // TODO-1: call BasicQuestions.AssignPi
            BasicQuestions.AssignPi(out d);

            // TODO-2: Uncomment assert below
            Assert.AreEqual(d, Math.PI);
        }

        [TestMethod()]
        public void SquareTest()
        {
            int d = 2; // chon initialize r ref
            // TODO-1: call BasicQuestions.Square
            BasicQuestions.Square(ref d);

            // TODO-2: Uncomment assert below
            Assert.AreEqual(d, 4);

            d = 5;
            // TODO-3: call BasicQuestions.Square
            BasicQuestions.Square(ref d);

            // TODO-4: Uncomment assert below
            Assert.AreEqual(d, 25);
        }

        [TestMethod()]
        public void AppendTest()
        {
            int [] nums = new int[]{2, 3, 5}; 
            // TODO-1: call BasicQuestions.Append
            BasicQuestions.Append(ref nums,7);

            // TODO-2: Uncomment assert below
            Assert.AreEqual(nums.Length, 4);
            Assert.AreEqual(nums[^1], 7);
            CollectionAssert.AreEqual(new int[]{2,3,5,7}, nums);
        }

        [TestMethod()]
        public void AbsArrayTest()
        {
            int [] nums = new int[]{-1, 1, 2, -3}; 
            // TODO-1: call BasicQuestions.AbsArray
            BasicQuestions.AbsArray(ref nums);

            // TODO-2: Uncomment assert below
            CollectionAssert.AreEqual(new int[]{1,1,2,3}, nums);
        }

        [TestMethod()]
        public void ArrayElementSwapTest()
        {
            int [] nums1 = new int[]{-1, 1, 2, -3}; object nums1_ref = nums1;
            int [] nums2 = new int[]{-2, 3, 4, -5}; object nums2_ref = nums2;

            // TODO-1: call BasicQuestions.ArrayElementSwap
            BasicQuestions.ArrayElementSwap(ref nums1,ref nums2);

            // TODO-2: Uncomment assert below
            Assert.AreEqual(nums1, nums1_ref);
            Assert.AreEqual(nums2, nums2_ref);
            CollectionAssert.AreEqual(new int[]{-1, 1, 2, -3}, nums2);
            CollectionAssert.AreEqual(new int[]{-2, 3, 4, -5}, nums1);
        }

        [TestMethod()]
        public void ArraySwapTest()
        {
            int [] nums1 = new int[]{-1, 1};
            int [] nums2 = new int[]{-2, 3, 4, -5};
            // TODO-1: call BasicQuestions.ArraySwap
            BasicQuestions.ArraySwap(ref nums1,ref nums2);

            // TODO-2: Uncomment assert below
            CollectionAssert.AreEqual(new int[]{-1, 1}, nums2);
            CollectionAssert.AreEqual(new int[]{-2, 3, 4, -5}, nums1);
        }        
    }
}
