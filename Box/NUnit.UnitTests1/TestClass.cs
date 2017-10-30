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
        Item itemClass;

        [SetUp]
        public void Setup()
        {
            testPackage = new Package();
            itemClass = new Item("testingItem", 1);
        }

        //This is a sample test for reference purposes
        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            Assert.Pass("Your first passing test");
        }

        //Tests to see if the get method in item.cs works correctly
        [Test]
        public void TestItemGet()
        {
            string name = itemClass.Name;

            StringAssert.AreEqualIgnoringCase(name, "testingItem");
        }

        //Tests to see if the set method in item.cs throws an exception when the name is empty
        [Test]
        public void TestItemException()
        {
            Assert.That(() => itemClass = new Item("", 1), Throws.Exception);
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

        //This method test to see wether the method AddItem from Package.cs throws an exception when the item name is null
        [Test]
        public void TestNullAddItem()
        {
            List<Item> packageList = new List<Item>(); //For holding items added by the subject method
            Assert.That(() => testPackage.AddItem(packageList, null, 1), Throws.Exception);
        }

        //This method test to see wether the method AddItem from Package.cs throws an exception when the item name is empty ""
        [Test]
        public void TestEmptyNameAddItem()
        {
            List<Item> packageList = new List<Item>(); //For holding items added by the subject method
            Assert.That(() => testPackage.AddItem(packageList, "", 1), Throws.Exception);
        }

        //this method tests packageRoom in Package.cs to see if it throws an exception when the room name is whitespace
        [Test]
        public void TestWhiteSpaceRoomName()
        {
            Assert.That(() => testPackage.Room = "", Throws.Exception);
        }

        //this method tests packageRoom in Package.cs to see if it throws an exception when the room name is null
        [Test]
        public void TestNullRoomName()
        {
            Assert.That(() => testPackage.Room = null, Throws.Exception);
        }

        //this method tests packageRoom in Package.cs to see if it throws an exception when the Package name is whitespace
        [Test]
        public void TestWhiteSpacePackageName()
        {
            Assert.That(() => testPackage.Name = "", Throws.Exception);
        }

        //this method tests packageRoom in Package.cs to see if it throws an exception when the room name is null
        [Test]
        public void TestNullPackageName()
        {
            Assert.That(() => testPackage.Name = null, Throws.Exception);
        }
    }
}
