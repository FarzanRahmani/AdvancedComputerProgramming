using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E1
{
    public class Matrix<_Type> :
        ICalculable<Matrix<_Type>>,
        IEquatable<Matrix<_Type>>
        where
            _Type : ICalculable<_Type>, IEquatable<_Type>
    {
        private static Random Rnd = new Random(0);
        private _Type[,] Data;

        public Matrix()
        {
        }

        public Matrix(_Type[,] data)
        {
            Data = data;
        }
        public Matrix(int row,int col)
        {
            Data = new _Type[row,col];
        }

        public void SetData(int row,int col,_Type t)
        {
            Data[row,col] = t;
        }

        public _Type GetData(int row,int col)
        {
            return Data[row,col];
        }

        public int RowCount { get => Data.GetLength(0); }
        public int ColumnCount { get => Data.GetLength(1); }

        public Matrix<_Type> PlusIdentity {
            get
                {
                Matrix<_Type> result = new Matrix<_Type>(this.RowCount,this.ColumnCount);
                for (int i = 0; i < this.RowCount; i++)
                {
                    for (int j = 0; j < this.ColumnCount; j++)
                    {
                        _Type type;
                        type = default(_Type);
                        type.LoadFromStr("1");
                        if (i == j)
                            result.SetData(i,j,type);
                        else
                            result.SetData(i,j,default(_Type) );
                    }
                }
                return result;
            }
        }

        public Matrix<_Type> NegIdentity {
        get
            {
                Matrix<_Type> result = new Matrix<_Type>(this.RowCount,this.ColumnCount);
                for (int i = 0; i < this.RowCount; i++)
                {
                    for (int j = 0; j < this.ColumnCount; j++)
                    {
                        _Type type;
                        type = default(_Type);
                        type.LoadFromStr("-1");
                        if (i == j)
                            result.SetData(i,j,type);
                        else
                            result.SetData(i,j,default(_Type) );
                    }
                }
                return result;
            }}

        public IEnumerable<System.Collections.ICollection> Rows { get
        {
            _Type[] r = new _Type[this.ColumnCount];
            for (int i = 0; i < Data.GetLength(0); i++)
            {
                for (int j = 0; j < Data.GetLength(1); j++)
                {
                    r[j] = this.GetData(i,j);
                }
                yield return r;
            }
        } }

        public IEnumerable<System.Collections.ICollection> Columns { get
        {
            _Type[] r = new _Type[this.RowCount];
            for (int i = 0; i < Data.GetLength(1); i++)
            {
                for (int j = 0; j < Data.GetLength(0); j++)
                {
                    r[j] = this.GetData(j,i);
                }
                yield return r;
            }
        } }
        public Matrix<_Type> AddWith(Matrix<_Type> other)
        {
            Matrix<_Type> result = new Matrix<_Type>(other.RowCount,other.ColumnCount);
            for (int i = 0; i < other.ColumnCount; i++)
            {
                for (int j = 0; j < other.RowCount; j++)
                {
                    result.SetData(i,j,this.GetData(i,j).AddWith(other.GetData(i,j)));
                }
            }
            return result;
        }

        public Matrix<_Type> Clone()
        {
            Matrix<_Type> result = new Matrix<_Type>(this.RowCount,this.ColumnCount);
            for (int i = 0; i < this.RowCount; i++)
            {
                for (int j = 0; j < this.ColumnCount; j++)
                {
                    result.SetData(i,j,GetData(i,j));
                }
            }
            return result;
        }

        public bool Equals(Matrix<_Type> other)
        {
            if (this.RowCount != other.RowCount || this.ColumnCount != other.ColumnCount)
                return false;
            for (int i = 0; i < this.RowCount; i++)
            {
                for (int j = 0; j < this.ColumnCount; j++)
                {
                    if (! this.GetData(i,j).Equals(other.GetData(i,j)))
                        return false;
                }
            }
            return true;
        }

        public void LoadFromStr(string str)
        {
            string[] r1 = str.Split("\n");
            string[] rAc = r1[0].Split(" ");
            // this = new Matrix<_Type>(int.Parse(rAc[0]),int.Parse(rAc[1]));
            this.Data = new _Type[int.Parse(rAc[0]),int.Parse(rAc[1])];
            for (int i = 0; i < this.RowCount; i++)
            {
                string[] r2 = r1[i+1].Split(" ");
                for (int j = 0; j < this.ColumnCount; j++)
                {
                    _Type type;
                    type = default(_Type);
                    type.LoadFromStr(r2[j]);
                    this.SetData(i,j,type);
                }
            }
        }

        public Matrix<_Type> MultiplyBy(Matrix<_Type> other)
        {
            Matrix<_Type> result = new Matrix<_Type>(this.RowCount,other.ColumnCount);
            for (int i = 0; i < result.RowCount; i++)
            {
                for (int j = 0; j < result.ColumnCount; j++)
                {
                    _Type sum = default(_Type);
                    for (int k = 0; k < this.ColumnCount; k++)
                    {
                        sum = sum.AddWith(this.GetData(i,k).MultiplyBy(other.GetData(k,j)));
                    }
                    result.SetData(i,j,sum);
                }
            }
            return result;
        }

        public Matrix<_Type> MultiplyBy_ParallelFor(Matrix<_Type> other)
        {
            Matrix<_Type> result = new Matrix<_Type>(this.RowCount,other.ColumnCount);
            Parallel.For(0,result.RowCount,(i,p) => {
                for (int j = 0; j < result.ColumnCount; j++)
                {
                    _Type sum = default(_Type);
                    for (int k = 0; k < this.ColumnCount; k++)
                    {
                        sum = sum.AddWith(this.GetData(i,k).MultiplyBy(other.GetData(k,j)));
                    }
                    result.SetData(i,j,sum);
                }
            });
            return result;
        }

        public void Reset()
        {
            for (int i = 0; i < this.RowCount; i++)
            {
                for (int j = 0; j < this.ColumnCount; j++)
                {
                    _Type type;
                    type = default(_Type);
                    type.LoadFromStr("0");
                    SetData(i,j,type);
                }
            }
        }

        public void RndSet()
        {
            for (int i = 0; i < this.RowCount; i++)
            {
                for (int j = 0; j < this.ColumnCount; j++)
                {
                    _Type type;
                    type = default(_Type);
                    type.LoadFromStr($"{Rnd.Next()}");
                    SetData(i,j,type);
                }
            }
        }

        public void Set(Matrix<_Type> o)
        {
            this.Data = new _Type[o.RowCount,o.ColumnCount];
            for (int i = 0; i < o.RowCount; i++)
            {
                for (int j = 0; j < o.ColumnCount; j++)
                {
                    this.SetData(i,j,o.GetData(i,j));
                }
            }
        }

        public static Matrix<_Type> LoadFromFile(string str)
        {
            StreamReader reader = new StreamReader(str);
            string result = reader.ReadToEnd();
            Matrix<_Type> resultM = new Matrix<_Type>();
            resultM.LoadFromStr(result);
            reader.Close();
            return resultM;
        }

        public void SaveToFile(string str)
        {
            StreamWriter writer = new StreamWriter(str);
            writer.Write(this.ToString());
            writer.Close();
        }

        public override string ToString()
        {
            string result = this.RowCount.ToString() + " " + this.ColumnCount.ToString() + "\n";
            for (int i = 0; i < this.RowCount; i++)
            {
                for (int j = 0; j < this.ColumnCount; j++)
                {
                    if (j == this.ColumnCount-1)
                        result += this.GetData(i,j).ToString();
                    else
                        result += this.GetData(i,j).ToString() + " ";
                }
                result += "\n";
            }
            return result;
        }

        public static IEnumerable<int[]> Split(int[] nums,int parts)
        {
            int MinPartSize = nums.Length / parts;
            int remainder = nums.Length % parts;
            int start = 0;
            int end = MinPartSize;

            for (int i = 0; i < remainder; i++) // ozv haye bozorgh tar
            {
                yield return nums[start..(end+1)]; // +1 remainder(bozrg tarast)
                start = end + 1;
                end = start + MinPartSize;
            }

            // end = start = MinPartSize;

            for (int i = remainder; i < parts && start < nums.Length; i++)
            {
                yield return nums[start..end];
                start = end;
                end = start + MinPartSize;
            }
        }
    }
}
