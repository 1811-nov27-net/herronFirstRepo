using System;
using System.Collections.Generic;
using System.Text;

namespace LINQAndTesting.Library
{
    /// <summery>
    /// a list with some extra helper methods
    /// </summery>
    /// <remarks>
    /// two stratigies:
    /// - inheritance (MyCollection IS a list)
    /// - composition (MyCollection HAS a list)
    /// 
    /// make class generic with angle brackets in definition
    ///   - defines type parameter in class. By convention,
    ///   - T if there is only one.
    /// </remarks>
    /// 

    // generic/type parameter constraints:
    //      you can require that it is derived from some type
    //          MyGenericCollection<T> where T : SomeType
    //      require it to be a struct
    //          MyGenericCollection<T> where T : struct
    //      require it to have a constructor
    //          MyGenericCollection<T> where T : new()

    public class MyGenericCollection<T> // where T : new()
    {
        protected List<T> _list = new List<T>();

        //public void AddDefaultValue()
        //{
        //    _list.Add(new T());
        //    // not allowed unless new() constraint used
        //}

        public void Add(T item)
        {
            _list.Add(item);
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }
        public void Sort()
        {
            _list.Sort();
        }
        public int Length => _list.Count;

        public T Get(int Index)
        {
            return _list[Index];
        }

    }
}
