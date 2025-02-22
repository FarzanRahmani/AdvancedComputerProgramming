using Microsoft.VisualStudio.TestTools.UnitTesting;
using E1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace E1.Tests
{
    [TestClass()]
    public class MatrixTests
    {
        [TestMethod()]
        public void Q3_1_ConstructorTest()
        {
            Matrix<DoubleWithOp> m1 = new Matrix<DoubleWithOp>(2, 3);
            m1.SetData(0, 0, new DoubleWithOp(1));
            m1.SetData(0, 1, new DoubleWithOp(2));
            m1.SetData(0, 2, new DoubleWithOp(1));
            m1.SetData(1, 0, new DoubleWithOp(0));
            m1.SetData(1, 1, new DoubleWithOp(1));
            m1.SetData(1, 2, new DoubleWithOp(1));

            Assert.AreEqual(m1.GetData(0, 0).Value, 1);
            Assert.AreEqual(m1.GetData(0, 1).Value, 2);
            Assert.AreEqual(m1.GetData(0, 2).Value, 1);
            Assert.AreEqual(m1.GetData(1, 0).Value, 0);
            Assert.AreEqual(m1.GetData(1, 1).Value, 1);
            Assert.AreEqual(m1.GetData(1, 2).Value, 1);

            Assert.AreEqual(m1.RowCount, 2);
            Assert.AreEqual(m1.ColumnCount, 3);

            Matrix<IntWithOp> m2 = new Matrix<IntWithOp>(2, 3);
            m2.SetData(0, 0, new IntWithOp(1));
            m2.SetData(0, 1, new IntWithOp(2));
            m2.SetData(0, 2, new IntWithOp(1));
            m2.SetData(1, 0, new IntWithOp(0));
            m2.SetData(1, 1, new IntWithOp(1));
            m2.SetData(1, 2, new IntWithOp(1));

            Assert.AreEqual(m1.GetData(0, 0).Value, 1);
            Assert.AreEqual(m1.GetData(0, 1).Value, 2);
            Assert.AreEqual(m1.GetData(0, 2).Value, 1);
            Assert.AreEqual(m1.GetData(1, 0).Value, 0);
            Assert.AreEqual(m1.GetData(1, 1).Value, 1);
            Assert.AreEqual(m1.GetData(1, 2).Value, 1);

            Assert.AreEqual(m2.RowCount, 2);
            Assert.AreEqual(m2.ColumnCount, 3);

        }

        [TestMethod()]
        public void Q3_2_AddWithTest()
        {
            Matrix<DoubleWithOp> m1 = new Matrix<DoubleWithOp>(2, 2);
            m1.SetData(0, 0, new DoubleWithOp(1));
            m1.SetData(0, 1, new DoubleWithOp(2));
            m1.SetData(1, 0, new DoubleWithOp(0));
            m1.SetData(1, 1, new DoubleWithOp(1));

            Matrix<DoubleWithOp> m2 = new Matrix<DoubleWithOp>(2, 2);
            m2.SetData(0, 0, new DoubleWithOp(2));
            m2.SetData(0, 1, new DoubleWithOp(1));
            m2.SetData(1, 0, new DoubleWithOp(1));
            m2.SetData(1, 1, new DoubleWithOp(2));

            var m3 = m1.AddWith(m2);
            Assert.AreEqual(3, m3.GetData(0, 0).Value);
            Assert.AreEqual(3, m3.GetData(0, 1).Value);
            Assert.AreEqual(1, m3.GetData(1, 0).Value);
            Assert.AreEqual(3, m3.GetData(1, 1).Value);
        }

        [TestMethod()]
        public void Q3_3_MultiplyByTest()
        {
            Matrix<DoubleWithOp> m1 = new Matrix<DoubleWithOp>(2, 3);
            m1.SetData(0, 0, new DoubleWithOp(1));
            m1.SetData(0, 1, new DoubleWithOp(2));
            m1.SetData(0, 2, new DoubleWithOp(1));
            m1.SetData(1, 0, new DoubleWithOp(0));
            m1.SetData(1, 1, new DoubleWithOp(1));
            m1.SetData(1, 2, new DoubleWithOp(1));

            Matrix<DoubleWithOp> m2 = new Matrix<DoubleWithOp>(3, 2);
            m2.SetData(0, 0, new DoubleWithOp(2));
            m2.SetData(0, 1, new DoubleWithOp(1));
            m2.SetData(1, 0, new DoubleWithOp(1));
            m2.SetData(1, 1, new DoubleWithOp(2));
            m2.SetData(2, 0, new DoubleWithOp(2));
            m2.SetData(2, 1, new DoubleWithOp(1));

            var m3 = m1.MultiplyBy(m2);
            Assert.AreEqual(6, m3.GetData(0, 0).Value);
            Assert.AreEqual(6, m3.GetData(0, 1).Value);
            Assert.AreEqual(3, m3.GetData(1, 0).Value);
            Assert.AreEqual(3, m3.GetData(1, 1).Value);
        }




        [TestMethod()]
        public void Q3_4_ToStringTest()
        {
            Matrix<DoubleWithOp> m1 = new Matrix<DoubleWithOp>(2, 2);
            m1.SetData(0, 0, new DoubleWithOp(1));
            m1.SetData(0, 1, new DoubleWithOp(2));
            m1.SetData(1, 0, new DoubleWithOp(0));
            m1.SetData(1, 1, new DoubleWithOp(1));
            string matrix_string = "2 2\n" + "1 2\n" + "0 1\n";
            Assert.AreEqual(m1.ToString(), matrix_string);

            Matrix<DoubleWithOp> m2 = new Matrix<DoubleWithOp>(2, 3);
            m2.SetData(0, 0, new DoubleWithOp(1));
            m2.SetData(0, 1, new DoubleWithOp(2));
            m2.SetData(0, 2, new DoubleWithOp(-1));
            m2.SetData(1, 0, new DoubleWithOp(0));
            m2.SetData(1, 1, new DoubleWithOp(1));
            m2.SetData(1, 2, new DoubleWithOp(2));
            matrix_string = "2 3\n" + "1 2 -1\n" + "0 1 2\n";
            Assert.AreEqual(m2.ToString(), matrix_string);
        }

        [TestMethod()]
        public void Q3_5_LoadFromStrTest()
        {
            string matrix_string = "2 2\n" + "1 2\n" + "0 1\n";
            Matrix<DoubleWithOp> m1 = new Matrix<DoubleWithOp>(2, 2);
            m1.LoadFromStr(matrix_string);
            Assert.AreEqual(m1.GetData(0, 0).Value,1);
            Assert.AreEqual(m1.GetData(0, 1).Value,2);
            Assert.AreEqual(m1.GetData(1, 0).Value,0);
            Assert.AreEqual(m1.GetData(1, 1).Value,1);

            Matrix<DoubleWithOp> m2 = new Matrix<DoubleWithOp>(2, 3);
            matrix_string = "2 3\n" + "1 2 -1\n" + "0 1 2\n";
            m2.LoadFromStr(matrix_string);
            Assert.AreEqual(m2.GetData(0, 0).Value,1);
            Assert.AreEqual(m2.GetData(0, 1).Value,2);
            Assert.AreEqual(m2.GetData(0, 2).Value,-1);
            Assert.AreEqual(m2.GetData(1, 0).Value,0);
            Assert.AreEqual(m2.GetData(1, 1).Value,1);
            Assert.AreEqual(m2.GetData(1, 2).Value,2);
        }

        [TestMethod()]
        public void Q3_6_ResetTest()
        {
            Matrix<DoubleWithOp> m1 = new Matrix<DoubleWithOp>(2, 3);
            m1.SetData(0, 0, new DoubleWithOp(1));
            m1.SetData(0, 1, new DoubleWithOp(2));
            m1.SetData(0, 2, new DoubleWithOp(1));
            m1.SetData(1, 0, new DoubleWithOp(0));
            m1.SetData(1, 1, new DoubleWithOp(1));
            m1.SetData(1, 2, new DoubleWithOp(1));
            m1.Reset();
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 3; j++)
                    Assert.AreEqual(m1.GetData(i, j).Value,0);

            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 3; j++)
                    while (m1.GetData(i, j).Value == 0)
                        m1.RndSet();                    
        }

        [TestMethod()]
        public void Q3_7_CloneTest()
        {
            Matrix<DoubleWithOp> m1 = new Matrix<DoubleWithOp>(2, 3);
            m1.SetData(0, 0, new DoubleWithOp(1));
            m1.SetData(0, 1, new DoubleWithOp(2));
            m1.SetData(0, 2, new DoubleWithOp(1));
            m1.SetData(1, 0, new DoubleWithOp(0));
            m1.SetData(1, 1, new DoubleWithOp(1));
            m1.SetData(1, 2, new DoubleWithOp(1));

            var m2 = m1.Clone();
            m1.SetData(0, 0, new DoubleWithOp(-1));
            m1.SetData(0, 1, new DoubleWithOp(-2));
            m1.SetData(0, 2, new DoubleWithOp(-3));
            m1.SetData(1, 0, new DoubleWithOp(-4));
            m1.SetData(1, 1, new DoubleWithOp(-5));
            m1.SetData(1, 2, new DoubleWithOp(-6));

            Assert.AreEqual(m2.GetData(0, 0).Value, 1);
            Assert.AreEqual(m2.GetData(0, 1).Value, 2);
            Assert.AreEqual(m2.GetData(0, 2).Value, 1);
            Assert.AreEqual(m2.GetData(1, 0).Value, 0);
            Assert.AreEqual(m2.GetData(1, 1).Value, 1);
            Assert.AreEqual(m2.GetData(1, 2).Value, 1);
            Assert.AreEqual(m2.RowCount, 2);
            Assert.AreEqual(m2.ColumnCount, 3);
        }

        [TestMethod()]
        public void Q3_8_EquatableTest()
        {
            Matrix<DoubleWithOp> m1 = new Matrix<DoubleWithOp>(2, 3);
            m1.SetData(0, 0, new DoubleWithOp(1));
            m1.SetData(0, 1, new DoubleWithOp(2));
            m1.SetData(0, 2, new DoubleWithOp(1));
            m1.SetData(1, 0, new DoubleWithOp(0));
            m1.SetData(1, 1, new DoubleWithOp(1));
            m1.SetData(1, 2, new DoubleWithOp(1));

            Matrix<DoubleWithOp> m2 = new Matrix<DoubleWithOp>(2, 3);
            m2.SetData(0, 0, new DoubleWithOp(1));
            m2.SetData(0, 1, new DoubleWithOp(2));
            m2.SetData(0, 2, new DoubleWithOp(1));
            m2.SetData(1, 0, new DoubleWithOp(0));
            m2.SetData(1, 1, new DoubleWithOp(1));
            m2.SetData(1, 2, new DoubleWithOp(1));

            var m3 = new Matrix<DoubleWithOp>(2, 3);
            m3.SetData(0, 0, new DoubleWithOp(-1));
            m3.SetData(0, 1, new DoubleWithOp(-2));
            m3.SetData(0, 2, new DoubleWithOp(-3));
            m3.SetData(1, 0, new DoubleWithOp(-4));
            m3.SetData(1, 1, new DoubleWithOp(-5));
            m3.SetData(1, 2, new DoubleWithOp(-6));

            Assert.IsTrue(m1.Equals(m2));
            Assert.IsFalse(m1.Equals(m3));
            Assert.IsFalse(m2.Equals(m3));
        }

        [TestMethod()]
        public void Q3_9_IdentityTest()
        {
            Matrix<IntWithOp> m = new Matrix<IntWithOp>(2,2);
            var im = m.PlusIdentity;
            for (int i = 0; i < im.RowCount; i++)
                Assert.AreEqual(im.GetData(i, i).Value, 1);

            for (int i = 0; i < im.RowCount; i++)
                for (int j=0; j < im.RowCount; j++)
                    if (i != j)
                        Assert.AreEqual(im.GetData(i, j).Value, 0);

            m = new Matrix<IntWithOp>(3, 3);
            im = m.NegIdentity;
            for (int i = 0; i < im.RowCount; i++)
                Assert.AreEqual(im.GetData(i, i).Value, -1);

            for (int i = 0; i < im.RowCount; i++)
                for (int j = 0; j < im.RowCount; j++)
                    if (i != j)
                        Assert.AreEqual(im.GetData(i, j).Value, 0);

            m = new Matrix<IntWithOp>(4, 4);
            im = m.NegIdentity;
            for (int i = 0; i < im.RowCount; i++)
                Assert.AreEqual(im.GetData(i, i).Value, -1);

            for (int i = 0; i < im.RowCount; i++)
                for (int j = 0; j < im.RowCount; j++)
                    if (i != j)
                        Assert.AreEqual(im.GetData(i, j).Value, 0);

        }

        [TestMethod()]
        public void Q3_10_RowsTest()
        {
            Matrix<DoubleWithOp> m1 = new Matrix<DoubleWithOp>(2, 3);
            m1.SetData(0, 0, new DoubleWithOp(1));
            m1.SetData(0, 1, new DoubleWithOp(2));
            m1.SetData(0, 2, new DoubleWithOp(1));
            m1.SetData(1, 0, new DoubleWithOp(0));
            m1.SetData(1, 1, new DoubleWithOp(1));
            m1.SetData(1, 2, new DoubleWithOp(1));
            DoubleWithOp[][] rows = new DoubleWithOp[][]
            {
                new DoubleWithOp[]{new DoubleWithOp(1), new DoubleWithOp(2), new DoubleWithOp(1)},
                new DoubleWithOp[]{new DoubleWithOp(0), new DoubleWithOp(1), new DoubleWithOp(1)}
            };
            int idx = 0;
            foreach(var row in m1.Rows)
            {
                CollectionAssert.AreEqual(row, rows[idx]);
                idx++;
            }

            Matrix<DoubleWithOp> m2 = new Matrix<DoubleWithOp>(3, 2);
            m2.SetData(0, 0, new DoubleWithOp(1));
            m2.SetData(0, 1, new DoubleWithOp(2));
            m2.SetData(1, 0, new DoubleWithOp(3));
            m2.SetData(1, 1, new DoubleWithOp(4));
            m2.SetData(2, 0, new DoubleWithOp(5));
            m2.SetData(2, 1, new DoubleWithOp(6));
            rows = new DoubleWithOp[][]
            {
                new DoubleWithOp[]{new DoubleWithOp(1), new DoubleWithOp(2)},
                new DoubleWithOp[]{new DoubleWithOp(3), new DoubleWithOp(4)},
                new DoubleWithOp[]{new DoubleWithOp(5), new DoubleWithOp(6)}
            };

            idx = 0;
            foreach (var row in m2.Rows)
            {
                CollectionAssert.AreEqual(row, rows[idx]);
                idx++;
            }
        }

        [TestMethod()]
        public void Q3_12_ColumnsTest()
        {
            Matrix<DoubleWithOp> m1 = new Matrix<DoubleWithOp>(2, 3);
            m1.SetData(0, 0, new DoubleWithOp(1));
            m1.SetData(0, 1, new DoubleWithOp(2));
            m1.SetData(0, 2, new DoubleWithOp(1));
            m1.SetData(1, 0, new DoubleWithOp(0));
            m1.SetData(1, 1, new DoubleWithOp(1));
            m1.SetData(1, 2, new DoubleWithOp(1));
            DoubleWithOp[][] columns = new DoubleWithOp[][]
            {
                new DoubleWithOp[]{new DoubleWithOp(1), new DoubleWithOp(0)},
                new DoubleWithOp[]{new DoubleWithOp(2), new DoubleWithOp(1)},
                new DoubleWithOp[]{new DoubleWithOp(1), new DoubleWithOp(1)}
            };
            int idx = 0;
            foreach (var column in m1.Columns)
            {
                CollectionAssert.AreEqual(column, columns[idx]);
                idx++;
            }

            Matrix<DoubleWithOp> m2 = new Matrix<DoubleWithOp>(3, 2);
            m2.SetData(0, 0, new DoubleWithOp(1));
            m2.SetData(0, 1, new DoubleWithOp(2));
            m2.SetData(1, 0, new DoubleWithOp(3));
            m2.SetData(1, 1, new DoubleWithOp(4));
            m2.SetData(2, 0, new DoubleWithOp(5));
            m2.SetData(2, 1, new DoubleWithOp(6));
            columns = new DoubleWithOp[][]
            {
                new DoubleWithOp[]{new DoubleWithOp(1), new DoubleWithOp(3), new DoubleWithOp(5)},
                new DoubleWithOp[]{new DoubleWithOp(2), new DoubleWithOp(4), new DoubleWithOp(6)}
            };

            idx = 0;
            foreach (var column in m2.Columns)
            {
                CollectionAssert.AreEqual(column, columns[idx]);
                idx++;
            }
        }

        [TestMethod()]
        public void Q3_13_LoadFromFileTest()
        {
            var m = Matrix<IntWithOp>.LoadFromFile("test_case1.txt");
            Assert.AreEqual(m.RowCount, 3);
            Assert.AreEqual(m.ColumnCount, 2);
            Assert.AreEqual(m.GetData(0, 0).Value, 6);
            Assert.AreEqual(m.GetData(0, 1).Value, 2);
            Assert.AreEqual(m.GetData(1, 0).Value, 6);
            Assert.AreEqual(m.GetData(1, 1).Value, -3);
            Assert.AreEqual(m.GetData(2, 0).Value, -6);
            Assert.AreEqual(m.GetData(2, 1).Value, -1);

            m = Matrix<IntWithOp>.LoadFromFile("test_case2.txt");
            Assert.AreEqual(m.RowCount, 3);
            Assert.AreEqual(m.ColumnCount, 2);
            Assert.AreEqual(m.GetData(0, 0).Value, -6);
            Assert.AreEqual(m.GetData(0, 1).Value, -2);
            Assert.AreEqual(m.GetData(1, 0).Value, -6);
            Assert.AreEqual(m.GetData(1, 1).Value, -3);
            Assert.AreEqual(m.GetData(2, 0).Value, -6);
            Assert.AreEqual(m.GetData(2, 1).Value, -1);
        }

        [TestMethod()]
        public void Q3_14_SaveToFileTest()
        {
            var m = new Matrix<IntWithOp>(3, 2);
            m.SetData(0, 0, new IntWithOp(6));
            m.SetData(0, 1, new IntWithOp(2));
            m.SetData(1, 0, new IntWithOp(6));
            m.SetData(1, 1, new IntWithOp(-3));
            m.SetData(2, 0, new IntWithOp(-6));
            m.SetData(2, 1, new IntWithOp(-1));
            var tmpFile = System.IO.Path.GetTempFileName();
            m.SaveToFile(tmpFile);
            var lines = System.IO.File.ReadAllLines(tmpFile);
            string[] expected_lines = new string[]
            {
                "3 2",
                "6 2",
                "6 -3",
                "-6 -1"
            };
            CollectionAssert.AreEqual(expected_lines, lines);

            m = new Matrix<IntWithOp>(3, 2);
            m.SetData(0, 0, new IntWithOp(-6));
            m.SetData(0, 1, new IntWithOp(-2));
            m.SetData(1, 0, new IntWithOp(-6));
            m.SetData(1, 1, new IntWithOp(-3));
            m.SetData(2, 0, new IntWithOp(-6));
            m.SetData(2, 1, new IntWithOp(-1));
            tmpFile = System.IO.Path.GetTempFileName();
            m.SaveToFile(tmpFile);
            lines = System.IO.File.ReadAllLines(tmpFile);
            expected_lines = new string[]
            {
                "3 2",
                "-6 -2",
                "-6 -3",
                "-6 -1"
            };
            CollectionAssert.AreEqual(expected_lines, lines);
        }

        [TestMethod()]
        public void Q3_15_MatrixMultiplyParallelTest()
        {
            var m1 = Matrix<IntWithOp>.LoadFromFile("m1.txt");
            var m2 = Matrix<IntWithOp>.LoadFromFile("m2.txt");
            var m3_expected = Matrix<IntWithOp>.LoadFromFile("m3.txt");

            Stopwatch sw = Stopwatch.StartNew();
            var m3 = m1.MultiplyBy(m2);
            var elapsed = sw.ElapsedMilliseconds;

            Assert.IsTrue(m3_expected.Equals(m3));

            sw.Restart();
            var m3_parallel = m1.MultiplyBy_ParallelFor(m2);
            var parallel_elapsed = sw.ElapsedMilliseconds;

            Assert.IsTrue(m3_expected.Equals(m3_parallel));

            Assert.IsTrue(elapsed > parallel_elapsed);
        }


        [TestMethod()]
        public void Q3_6_SplitTest()
        {
            var indecies = Enumerable.Range(0, 8).ToArray();
            var ranges = Matrix<DoubleWithOp>.Split(indecies, 4).ToArray();
            CollectionAssert.AreEqual(ranges[0], new int[] {0,1});
            CollectionAssert.AreEqual(ranges[1], new int[] {2,3});
            CollectionAssert.AreEqual(ranges[2], new int[] {4,5});
            CollectionAssert.AreEqual(ranges[3], new int[] {6,7 });

            indecies = Enumerable.Range(0, 10).ToArray();
            ranges = Matrix<DoubleWithOp>.Split(indecies, 4).ToArray();
            CollectionAssert.AreEqual(ranges[0], new int[] { 0, 1, 2 });
            CollectionAssert.AreEqual(ranges[1], new int[] { 3, 4, 5 });
            CollectionAssert.AreEqual(ranges[2], new int[] { 6, 7 });
            CollectionAssert.AreEqual(ranges[3], new int[] { 8, 9 });

            indecies = Enumerable.Range(0, 15).ToArray();
            ranges = Matrix<DoubleWithOp>.Split(indecies, 4).ToArray();
            CollectionAssert.AreEqual(ranges[0], new int[] { 0, 1, 2, 3 });
            CollectionAssert.AreEqual(ranges[1], new int[] { 4, 5, 6, 7 });
            CollectionAssert.AreEqual(ranges[2], new int[] { 8, 9, 10, 11});
            CollectionAssert.AreEqual(ranges[3], new int[] { 12, 13, 14 });

            indecies = Enumerable.Range(0, 14).ToArray();
            ranges = Matrix<DoubleWithOp>.Split(indecies, 4).ToArray();
            CollectionAssert.AreEqual(ranges[0], new int[] { 0, 1, 2, 3 });
            CollectionAssert.AreEqual(ranges[1], new int[] { 4, 5, 6, 7 });
            CollectionAssert.AreEqual(ranges[2], new int[] { 8, 9, 10 });
            CollectionAssert.AreEqual(ranges[3], new int[] { 11, 12, 13 });

        }
    }
}