﻿using System;
using System.Collections.Generic;

namespace CSharp5
{
    class Program
    {
        class MyList<T>
        // class MyList<T> where T : new()
        // class MyList<T> where T : Monster
        // class MyList<T> where T : struct
        // class MyList<T> where T : class
        {
            T[] arr = new T[10];

            public T GetItem(int i)
            {
                return arr[i];
            }
        }

        class Monster
        {

        }

        static void Test<T>(T input)
        {

        }
            

        static void Main(string[] args)
        {
            MyList<int> myIntList = new MyList<int>();
            int item = myIntList.GetItem(0);
            MyList<short> myShortList = new MyList<short>();
            MyList<Monster> myMonsterList = new MyList<Monster>();

            Test<int>(3);
            // Test<float>(4.58);

        }
    }
}
