using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace A2
{
    public enum FutureHusbandType : int
    {
        None = 0b1,
        HasBigNose = 0b10,
        IsBald = 0b100,
        IsShort = 0b1000
    }

    public struct TypeOfSize5
    {
        char x;char y;char x1;char y1;char x2;
    }

    public struct TypeOfSize22
    {
        TypeOfSize5 x;TypeOfSize5 y;TypeOfSize5 z;TypeOfSize5 o;
        char a;char b;
    }

    public struct TypeOfSize125
    {
        TypeOfSize22 m11;TypeOfSize22 m12;TypeOfSize22 m13;TypeOfSize22 m14;TypeOfSize22 m15;
        TypeOfSize5 m2;TypeOfSize5 m3;TypeOfSize5 m41;
    }

    public struct TypeOfSize1024
    {
        TypeOfSize125 x1;
        TypeOfSize125 x2;
        TypeOfSize125 x3;
        TypeOfSize125 x4;
        TypeOfSize125 x5;
        TypeOfSize125 x6;
        TypeOfSize125 x7;
        TypeOfSize125 x8;
        TypeOfSize22 x9;
        char a;char b;
    }

    public struct TypeOfSize32768
    {
        TypeOfSize1024 x1 ;TypeOfSize1024 x11 ;TypeOfSize1024 x21 ;TypeOfSize1024 x31 ;
        TypeOfSize1024 x2 ;TypeOfSize1024 x12 ;TypeOfSize1024 x22 ;TypeOfSize1024 x32 ;
        TypeOfSize1024 x3 ;TypeOfSize1024 x13 ;TypeOfSize1024 x23 ;TypeOfSize1024 x33 ;
        TypeOfSize1024 x4 ;TypeOfSize1024 x14 ;TypeOfSize1024 x24 ;TypeOfSize1024 x34 ;
        TypeOfSize1024 x5 ;TypeOfSize1024 x15 ;TypeOfSize1024 x25 ;TypeOfSize1024 x35 ;
        TypeOfSize1024 x6 ;TypeOfSize1024 x16 ;TypeOfSize1024 x26 ;TypeOfSize1024 x36 ;
        TypeOfSize1024 x7 ;TypeOfSize1024 x17 ;TypeOfSize1024 x27 ;TypeOfSize1024 x37 ;
        TypeOfSize1024 x8 ;TypeOfSize1024 x18 ;TypeOfSize1024 x28 ;TypeOfSize1024 x38 ;
    }
    public struct TypeForMaxStackOfDepth10 
    {
        TypeOfSize32768 a;
        TypeOfSize1024 x1 ;TypeOfSize1024 x11 ;TypeOfSize1024 x21 ;TypeOfSize1024 x31 ;
        TypeOfSize1024 x2 ;TypeOfSize1024 x12 ;TypeOfSize1024 x22 ;TypeOfSize1024 x32 ;
        TypeOfSize1024 x3 ;TypeOfSize1024 x13 ;TypeOfSize1024 x23 ;TypeOfSize1024 x33 ;
        TypeOfSize1024 x4 ;TypeOfSize1024 x14 ;TypeOfSize1024 x24 ;TypeOfSize1024 x34 ;
        TypeOfSize1024 x5 ;TypeOfSize1024 x15 ;TypeOfSize1024 x25 ;TypeOfSize1024 x35 ;
        TypeOfSize1024 x6 ;TypeOfSize1024 x16 ;TypeOfSize1024 x26 ;TypeOfSize1024 x36 ;
        TypeOfSize1024 x7 ;TypeOfSize1024 x17 ;TypeOfSize1024 x27 ;TypeOfSize1024 x37 ;
    }

    public struct TypeForMaxStackOfDepth100
    {
        TypeOfSize1024 x1 ;TypeOfSize1024 x11 ;TypeOfSize1024 x21 ;TypeOfSize1024 x31 ;
        TypeOfSize1024 x2 ;TypeOfSize1024 x12 ;TypeOfSize1024 x22 ;
    }

    public struct TypeForMaxStackOfDepth1000
    {
        TypeOfSize125 x1;
        TypeOfSize125 x2;
        TypeOfSize125 x3;
        TypeOfSize125 x4;
        TypeOfSize125 x5;
    }

    public struct TypeForMaxStackOfDepth3000
    {
        TypeOfSize125 x1;
        TypeOfSize22 x2;
        TypeOfSize22 x3;
        TypeOfSize22 x4;
    }

    public struct StructOrClass1 // Value type -- pass by value
    {
        public int X;
    }

    public class StructOrClass2 // Reference type -- Reference by value
    {
        public int X;
    }

    public class StructOrClass3 // Reference type -- Reference by value
    {
        public StructOrClass2 X;
    }

    public class farzan 
    {
        TypeForMaxStackOfDepth10 x ;
        TypeForMaxStackOfDepth10 x1 ;
        TypeForMaxStackOfDepth10 x2 ;
        TypeForMaxStackOfDepth10 x3 ;
        TypeForMaxStackOfDepth10 x4 ;
        TypeForMaxStackOfDepth10 x5 ;
        TypeForMaxStackOfDepth10 x6 ;
        TypeForMaxStackOfDepth10 x7 ;
        TypeForMaxStackOfDepth100 x8;
    }

    public class TypeWithMemoryOnHeap
    {
        object a1;object a2;
        object a3;object a4;
        public void Allocate()
        {
            a1 = new farzan(); // int[] array = new int[1000000] 
            a2 = new farzan();
            a3 = new farzan();
            a4 = new farzan();
        }

        public void DeAllocate()
        {
            a1 = null;
            a2 = null;
            a3 = null;
            a4 = null;
        }
    }
}

