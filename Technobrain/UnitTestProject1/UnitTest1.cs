using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Validate_Only_One_CEO()
        {
            var sut = new Technobrain.Employee();
            var value = sut.validateOnlyOneCEO();
            Assert.AreEqual(1, value);
        }

        [TestMethod]
        public void No_Manager_That_Is_Not_An_Employee()
        {
            var sut = new Technobrain.Employee();
            string[] value = sut.noManagerThatIsNotAnEmployee();
            string[] managers = new string[2] { "employee2", "employee1"};
            CollectionAssert.AreEquivalent(managers, value);
        }

        [TestMethod]
        public void Salary_Budget_Of_Manager()
        {
            var sut = new Technobrain.Employee();
            Int32[] value = sut.salaryBudgetOfManagers();
            Int32[] salaryBudget = new int[] { 4000, 5800, 0 };
            CollectionAssert.AreEqual(salaryBudget, value);
        }

        [TestMethod]
        public void Validate_Salaries_Are_Valid_Integers()
        {
            var sut = new Technobrain.Employee();
            Int32[] value = sut.validateSalariesAreValidIntegers();
            CollectionAssert.AllItemsAreInstancesOfType(value, typeof(Int32));
        }

        [TestMethod]
        public void Validate_Employee_Reports_To_One_Manager()
        {
            var sut = new Technobrain.Employee();
            bool[] value = sut.validateEmployeeReportsToOneManager();
            bool[] expected = { true, true, true, true, true };
            CollectionAssert.AreEqual(expected, value);
        }

        [TestMethod]
        public void No_Circular_Reference()
        {
            var sut = new Technobrain.Employee();
            bool[] value = sut.noCircularReference();
            bool[] expected = { true, true, true, true, true };
            CollectionAssert.AreEqual(expected, value);
        }
    }
}
