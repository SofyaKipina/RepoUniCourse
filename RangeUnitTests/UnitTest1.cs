using System;
using RangeStruct;

namespace RangeStruct_UnitTests
{
    [TestFixture]
    public class RangeTests
    {

        [Test]
        public void ConstructorTest()
        {
            var range = new RangeStruct.Range(8, 19);

            Assert.That(range.LeftRange, Is.EqualTo(8));
            Assert.That(range.RightRange, Is.EqualTo(19));
        }

        [TestCase(15, 42, 27)]
        [TestCase(-9, -5, 4)]
        [TestCase(-15, 10, 25)]
        public void CountTest(int leftRange, int rightRange, int result)
        {
            var range = new RangeStruct.Range(leftRange, rightRange);
            Assert.That(range.Count, Is.EqualTo(result));
        }


        [TestCase(15, 42, 16, true)]
        [TestCase(-9, -5, -5, false)]
        [TestCase(-15, 10, -15, true)]
        public void IsContainsTest(int leftRange, int rightRange, int number, bool result)
        {
            var range = new RangeStruct.Range(leftRange, rightRange);
            Assert.That(range.IsContains(number), Is.EqualTo(result));
        }


        [TestCase(15, 42, "[15;42)")]
        [TestCase(-9, -5, "[-9;-5)")]
        [TestCase(-15, 10, "[-15;10)")]
        public void ToStringTest(int leftRange, int rightRange, string result)
        {
            var range = new RangeStruct.Range(leftRange, rightRange);
            Assert.That(range.ToString(), Is.EqualTo(result));
        }


        [TestCase(15, 42, -9, -5, false)]
        [TestCase(15, 42, 15, 42, true)]
        public void Equals_TwoRanges_ExpectedResult(int leftRange1, int rightRange1, int leftRange2, int rightRange2, bool result)
        {
            var range1 = new RangeStruct.Range(leftRange1, rightRange1);
            var range2 = new RangeStruct.Range(leftRange2, rightRange2);
            Assert.That(range1.Equals(range2), Is.EqualTo(result));
        }

        [Test]
        public void Equals_WrongArgument_ArgumentException()
        {
            var range = new RangeStruct.Range();
            var smth = new object();
            Assert.That(() => range.Equals(smth), Throws.ArgumentException);
        }

        [Test]
        public static void GetHashCodeTest()
        {
            var x = new RangeStruct.Range(15, 42);
            var y = new RangeStruct.Range(15, 42);
            var z = new RangeStruct.Range(-9, -5);
            Assert.That(x.Equals(y), Is.True);
            Assert.That(x.Equals(z), Is.False);
        }

        [TestCase(15, 42, 15, 42, 15, 42)]
        [TestCase(15, 42, -9, 16, 15, 16)]
        public void IntersectionTest(
            int leftRange1, int rightRange1,
            int leftRange2, int rightRange2,
            int newLeftRange, int newRightRange)
        {
            var range1 = new RangeStruct.Range(leftRange1, rightRange1);
            var range2 = new RangeStruct.Range(leftRange2, rightRange2);
            var result = new RangeStruct.Range(newLeftRange, newRightRange);
            Assert.That(range1 & range2, Is.EqualTo(result));
        }

        [TestCase(15, 42, -9, -5)]
        [TestCase(4, 5, 5, 9)]
        public void Intersection_ArgumentException(
            int leftRange1, int rightRange1,
            int leftRange2, int rightRange2)
        {
            var range1 = new RangeStruct.Range(leftRange1, rightRange1);
            var range2 = new RangeStruct.Range(leftRange2, rightRange2);
            Assert.That(() => range1 & range2, Throws.ArgumentException);
        }

        [TestCase(15, 42, 15, 42, 15, 42)]
        [TestCase(-9, 6, 4, 16, -9, 16)]
        public void LargestRangeTest(
            int leftRange1, int rightRange1,
            int leftRange2, int rightRange2,
            int newLeftRange, int newRightRange)
        {
            var range1 = new RangeStruct.Range(leftRange1, rightRange1);
            var range2 = new RangeStruct.Range(leftRange2, rightRange2);
            var result = new RangeStruct.Range(newLeftRange, newRightRange);
            Assert.That(range1 | range2, Is.EqualTo(result));
        }
    }
}