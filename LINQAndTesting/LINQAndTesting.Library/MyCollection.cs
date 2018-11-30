using System;
using System.Collections.Generic;
using System.Linq;

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
    public class MyCollection : MyGenericCollection<String>
    {
        // "readonly" just means you can't reassign "_list" to a different object
        // but you can still modify the object.
        // private readonly List<String> _list = new List<string>(); no longer needed

        

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

        public double AverageLength()
        {
            return _list.Average(x => x.Length);
        }
        public IEnumerable<int> Lengths()
        {
            return _list.Select(x => x.Length);
        }
        public int NumberOfAs()
        {
            return _list.Count(x => x != null && x.Length > 0 && x[0] == 'a');

            // "lambda expressions" passed as parameters
        }

        private static bool ContainsAVowel(string s)
        {
            return s.Any(x => "AEIOUaeiou".Contains(x));
        }

        public int NumberWithVowels()
        {
            return _list.Count(ContainsAVowel);
        }

        // LINQ (and IEnumerable itself) uses "deferred execution"

        public string FirstAlphabetical()
        {
            var sorted = _list.OrderBy(x => x);
            // just sets stuff up; no actual sorting yet

            var first = sorted.First();
            // actually runs the sort
            return first;
        }
    }
}
