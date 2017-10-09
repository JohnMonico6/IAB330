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
    public partial class Package
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

        //This method tests to see wether the method AddItem works correctly by comparing to a manually generated list
        [Test]
        public void TestAddItem()
        {
            List<Item> testList; //For holding manually generated items
            List<Item> packageList; //For holding items added by the subject method

            //adding items to testList
            testList.Add(new Item(Banana, 10));
            testList.Add(new Item(Apple, 5));
            testList.Add(new Item(Strawberry, 50));


            //adding items to packageList
            testPackage.AddItem(packageList, "Banana", 10);
            testPackage.AddItem(packageList, "Apple", 5);
            Assert.AreNotSame(testList, packageList); // quick test to see if lists are currently not the same
            testPackage.AddItem(packageList, "Strawberry", 50);

            //asserting wether the two objects (Lists) are the same
            Assert.AreSame(testList, packageList);
        }
    }
}