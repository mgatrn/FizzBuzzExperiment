using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace FizzBuzzTests
{
    [TestClass]
    public class FizzBuzzUnitTests
    {
        [TestMethod]
        public void StaticFizzBuzz_NoError()
        {
            // no errors should be thrown
            FizzBuzzApplication.FizzBuzz.StaticFizzBuzz();
        }

        [TestMethod]
        public void CustomFizzBuzz_NoError()
        {
            Dictionary<int, string> _testDict = new Dictionary<int, string>()
            {
                { 2, "Even" }
            };
            int[] _testRange = Enumerable.Range(1, 20).ToArray();

            // no errors should be thrown
            FizzBuzzApplication.FizzBuzz.CustomFizzBuzz(_testDict, _testRange);
        }

        [TestMethod]
        public void CustomFizzBuzz_BadDict()
        {
            Dictionary<int, string> _testDict = new Dictionary<int, string>();
            int[] _testRange = Enumerable.Range(1, 20).ToArray();

            CollectionAssert.AreEqual(_testDict, new Dictionary<int, string>());

            try
            {
                FizzBuzzApplication.FizzBuzz.CustomFizzBuzz(_testDict, _testRange);
            } catch (ArgumentException e)
            {
                Trace.Write(e.Message);
                StringAssert.Contains(e.Message, "Please include a valid dictionary");
            }
            
        }

        [TestMethod]
        public void CustomFizzBuzz_BadRange()
        {

            Dictionary<int, string> _testDict = new Dictionary<int, string>()
            {
                { 2, "Even" }
            };
            int[] _testRange = new int[0];

            CollectionAssert.AreEqual(_testRange, new int[0]);

            try
            {
                FizzBuzzApplication.FizzBuzz.CustomFizzBuzz(_testDict, _testRange);
            }
            catch (ArgumentException e)
            {
                Trace.Write(e.Message);
                StringAssert.Contains(e.Message, "No valid range");
            }

        }

        [TestMethod]
        public void PrintNumberToConsole_NoError()
        {
            // no error should be thrown
            int _testNumber = 20;
            FizzBuzzApplication.FizzBuzz.PrintNumberToConsole(_testNumber);            
        }

        [TestMethod]
        public void PrintKeyIfDivisible_NoError()
        {
            // no error should be thrown
            KeyValuePair<int, string> _testKV = new KeyValuePair<int, string>(3, "Key");
            FizzBuzzApplication.FizzBuzz.PrintKeyIfDivisible(10, _testKV);

        }

        [TestMethod]
        public void PrintKeyIfDivisible_invalidNumber()
        {
            KeyValuePair<int, string> _testKV = new KeyValuePair<int, string>(3, "Key");
            try
            {
                FizzBuzzApplication.FizzBuzz.PrintKeyIfDivisible(-8, _testKV);
            } catch(ArgumentException e)
            {
                Trace.Write(e.Message);
                StringAssert.Contains(e.Message, "The range operand is less than zero!");
            }
        }

        [TestMethod]
        public void PrintKeyIfDivisible_invalidKey()
        {
            KeyValuePair<int, string> _testKV = new KeyValuePair<int, string>(-8, "Key");
            try
            {
                FizzBuzzApplication.FizzBuzz.PrintKeyIfDivisible(9, _testKV);
            }
            catch (ArgumentException e)
            {
                Trace.Write(e.Message);
                StringAssert.Contains(e.Message, "The key operand is less than zero!");
            }
        }

        [TestMethod]
        public void PrintKeyIfDivisible_invalidValue()
        {
            KeyValuePair<int, string> _testKV = new KeyValuePair<int, string>(3, null);
            try
            {
                FizzBuzzApplication.FizzBuzz.PrintKeyIfDivisible(9, _testKV);
            }
            catch (ArgumentException e)
            {
                Trace.Write(e.Message);
                StringAssert.Contains(e.Message, "The printable value is null!");
            }
        }

    }
}
