using System;
using System.Collections.Generic;

namespace LINQAndTesting.Library
{
    /// <summery>
    /// a list with some extra helper methods
    /// </summery>
    /// <remarks>
    /// two stratigies:
    /// - inheritance (MyCollection IS a list)
    /// - composition (MyCollection HAS a list)
    /// </remarks>
    /// 
    public class MyCollection
    {
        // "readonly" just means you can't reassign "_list" to a different object
        // but you can still modify the object.
        private readonly List<String> _list = new List<string>();

        public void Sort()
        {
            _list.Sort();
        }

        public void Add(string item)
        {
            _list.Add(item);
        }

        public int Length => _list.Count;

        public string Get(int Index)
        {
            return _list[Index];
        }

        public string Longest()
        {
            string retStr = null;
            if (_list.Count == 0)
                return retStr;
            retStr = "";
            foreach (string str in _list)
            {
                if (str != null && str.Length > retStr.Length)
                    retStr = str;
            }
            return retStr;
        }
    }
}
