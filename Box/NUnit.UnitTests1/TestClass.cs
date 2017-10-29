using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqliteTutorial.Core.Models;

namespace NUnit.UnitTests1
{
    [TestFixture]
    public partial class AppTests
    {

        Package testPackage;

        [SetUp]
        public void Setup()
        {
            testPackage = new Package();

        }

        //This is a sample test for reference purposes
        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            Assert.Pass("Your first passing test");
        }

        //This method tests to see wether the method AddItem from Package.cs works correctly by comparing to a manually generated list
        [Test]
        public void TestAddItem()
        {
            List<Item> testList = new List<Item>(); //For holding manually generated items
            List<Item> packageList = new List<Item>(); //For holding items added by the subject method

            //adding items to testList
            testList.Add(new Item("Banana", 10));
            testList.Add(new Item("Apple", 5));
            testList.Add(new Item("Strawberry", 50));


            //adding items to packageList
            testPackage.AddItem(packageList, "Banana", 10);
            testPackage.AddItem(packageList, "Apple", 5);
            Assert.IsFalse(testList.Count() == packageList.Count()); //Quick test to see if the lists are unequal right now 3-2
            testPackage.AddItem(packageList, "Strawberry", 50);


            //asserting wether the two objects (Lists) are the same by checking that they both contain the same items /3 items each
            Assert.IsTrue(testList.Count() == packageList.Count());
            Assert.IsTrue(3 == packageList.Count());
        }

        //This method test to see wether the method AddItem from Package.cs allows an item with the name null (it shouldn't)
        [Test]
        public void TestNullAddItem()
        {
            List<Item> packageList = new List<Item>(); //For holding items added by the subject method
            testPackage.AddItem(packageList, null, 1);

            Assert.IsEmpty(packageList);
        }

        //This method test to see wether the method AddItem from Package.cs allows an item with an empty name (it shouldn't)
        [Test]
        public void TestEmptyNameAddItem()
        {
            List<Item> packageList = new List<Item>(); //For holding items added by the subject method
            testPackage.AddItem(packageList, "", 1);

            Assert.IsEmpty(packageList);
        }

        //This method test to see wether the method AddItem from Package.cs allows an item with an invalid name (numerical only, too few chars) (it shouldn't)
        [Test]
        public void TestNumericalNameAddItem()
        {
            List<Item> packageList = new List<Item>(); //For holding items added by the subject method
            testPackage.AddItem(packageList, "1", 1);

            Assert.IsEmpty(packageList);
        }

        //This method test to see wether the method AddItem from Package.cs allows an item with the amount 0 (it shouldn't)
        [Test]
        public void TestZeroCountAddItem()
        {
            List<Item> packageList = new List<Item>(); //For holding items added by the subject method
            testPackage.AddItem(packageList, "Bananas", 0);

            Assert.IsEmpty(packageList);
        }

        //This method test to see wether the method AddItem from Package.cs allows an item with the amount < 0 (it shouldn't)
        [Test]
        public void TestNegativeCountAddItem()
        {
            List<Item> packageList = new List<Item>(); //For holding items added by the subject method
            testPackage.AddItem(packageList, "Bananas", -1);

            Assert.IsEmpty(packageList);
        }

        //This method test to see wether the method AddItem from Package.cs allows an item with the name null, exception throw expected
        [Test]
        public void TestNullAddItemException()
        {
            List<Item> packageList = new List<Item>(); //For holding items added by the subject method
            TestDelegate addItem =  new TestDelegate(testPackage.AddItem(packageList, null, 1)); // *Up to here* Trying to get this line to work lel

            Assert.Throws(typeof(ArgumentException), addItem);
        }

        //Testing all viewmodels and models (Item.cs, package.cs),
    }
}