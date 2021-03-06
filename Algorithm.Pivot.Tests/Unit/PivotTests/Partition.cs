﻿namespace Algorithm.Pivot.Tests.Unit.PivotTests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class Partition
    {
        [Test]
        public void DoesNotPartitionArraysWithOneItem()
        {
            // Arrange
            var pivot = new Pivot(new[] { 0 });

            // Act
            var result = pivot.Partition(0, 0, 0);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void DoesNotPartitionArraysWithTwoItems()
        {
            // Arrange
            var pivot = new Pivot(new[] { 0, 0 });

            // Act
            var result = pivot.Partition(0, 0, 0);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void ThreeItemsArray()
        {
            // Arrange
            var array = new[] { 10, 5, 1 };
            var pivot = new Pivot(array);

            // Act
            var result = pivot.Partition(0, array.Length - 1, 5);

            // Assert
            Assert.AreEqual(1, result);
            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(5, array[1]);
            Assert.AreEqual(10, array[2]);
        }

        [Test]
        public void FourItemsArray()
        {
            // Arrange
            var array = new[] { 10, 5, 1, 8 };
            var pivot = new Pivot(array);

            // Act
            var result = pivot.Partition(0, array.Length - 1, 5);

            // Assert
            Assert.AreEqual(1, result);
            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(5, array[1]);
            Assert.IsTrue(array[2] > 5);
            Assert.IsTrue(array[3] > 5);
        }

        [Test]
        public void FiveItemsArray()
        {
            // Arrange
            var array = new[] { 10, 5, 1, 8, -63 };
            var pivot = new Pivot(array);

            // Act
            var result = pivot.Partition(0, array.Length - 1, 5);

            // Assert
            Assert.AreEqual(2, result);
            Assert.IsTrue(array[0] < 5);
            Assert.IsTrue(array[1] < 5);
            Assert.AreEqual(5, array[2]);
            Assert.IsTrue(array[3] > 5);
            Assert.IsTrue(array[4] > 5);
        }

        [Test]
        public void PivotDoesNotNeedToExistOnArrayForPartitionToWork()
        {
            // Arrange
            var array = new[] { 10, 5, 1, 8 };
            var pivot = new Pivot(array);

            // Act
            var result = pivot.Partition(0, array.Length - 1, 2);

            // Assert
            Assert.AreEqual(1, result);
            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(5, array[1]);
            Assert.IsTrue(array[2] > 5);
            Assert.IsTrue(array[3] > 5);
        }

        [Test]
        public void SucceedsOnRandomArray()
        {
            // Arrange
            var array = GetRandomArray();
            var pivot = new Pivot(array);

            // Act
            var result = pivot.Partition(0, array.Length - 1, 450);

            // Assert
            AssertItemsLeftOfPivotAreLessThanIt(array, result);
            AssertItemsRightOfPivotAreGreaterOrEqualOfIt(array, result);
        }

        private void AssertItemsLeftOfPivotAreLessThanIt(int[] array, int result)
        {
            var left = array.Take(result - 1).ToList();
            Assert.IsTrue(left.All(s => s <= 450));
        }

        private void AssertItemsRightOfPivotAreGreaterOrEqualOfIt(int[] array, int result)
        {
            var right = array.Skip(result).Take(array.Length).ToList();
            Assert.IsTrue(right.All(s => s >= 450));
        }

        private int[] GetRandomArray()
        {
            var generator = new Random();
            var array = new int[1000];
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = generator.Next(1000);
            }
            return array;
        }
    }
}