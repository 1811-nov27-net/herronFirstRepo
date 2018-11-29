using LINQAndTesting.Library;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject1
{
    // typically one test class to test each real class
    public class MyCollectionsTest
    {
        // in XUnit, each unit test to test one thing should
        // be a method with the Fact attribute
        [Fact] // this kind of thing is called an "attribute" - 
               //   special kind of class that adds extra behavior to a thing 
        public void EmptyCollectionShouldHaveZeroLength()
        {
            // each test should test one thing
            // arrange (set it up)
            var sut = new MyCollection();
            // already empty

            // act (call method we are testing)
            var result = sut.Length;


            // assert (define correct result, check results)
            Assert.Equal(0, result);
            // Assert class has lots of static methods to check stuff

        }

        // fact is for tests that do not take parameters
        // theory is a paramaterized test

        [Theory]

        [InlineData(new string[] { "a", "ab" }, "ab")]
        [InlineData(new string[] { "a" }, "a")]
        [InlineData(new string[] { "ab", "a" }, "ab")]
        [InlineData(new string[] { "a2", "ab" }, "a2")]
        [InlineData(new string[] { }, null)]
        [InlineData(new string[] { "a", "ab", null }, "ab")]

        public void LongestShouldReturnLongest(string[] items, string expected)
        {
            // arrange
            var coll = new MyCollection();
            foreach (var item in items)
            {
                coll.Add(item);
            }

            // act
            string actual = coll.Longest();

            // assert
            Assert.Equal(expected, actual);

            // TDD
            // step 1: write test that fails
            // step 2: write the code to make test pass
        }
    }
}
