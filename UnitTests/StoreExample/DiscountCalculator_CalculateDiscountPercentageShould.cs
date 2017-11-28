﻿using System;
using System.Linq;
using Core.StoreExample;
using NUnit.Framework;

namespace UnitTests.StoreExample
{
    [TestFixture]
    public class DiscountCalculator_CalculateDiscountPercentageShould
    {
        private DiscountCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new DiscountCalculator();    
        }

        [Test]
        public void Return15PctForNewCustomer()
        {
            var customer = new Customer();

            decimal discount = _calculator.CalculateDiscountPercentage(customer);

            Assert.AreEqual(0.15m, discount);
        }

        [Test]
        public void Return10PctForVeteran()
        {
            var customer = new Customer() { IsVeteran = true, DateOfFirstPurchase = DateTime.Today.AddDays(-1) };

            decimal discount = _calculator.CalculateDiscountPercentage(customer);

            Assert.AreEqual(0.1m, discount);
        }

        [Test]
        public void Return5PctForSenior()
        {
            var customer = new Customer() { DateOfBirth = DateTime.Today.AddYears(-65).AddDays(-5), DateOfFirstPurchase = DateTime.Today.AddDays(-1) };

            decimal discount = _calculator.CalculateDiscountPercentage(customer);

            Assert.AreEqual(0.05m, discount);
        }

        [Test]
        public void Return10PctForBirthday()
        {
            var customer = new Customer() { DateOfBirth = DateTime.Today,
                                            DateOfFirstPurchase = DateTime.Today.AddDays(-1)
            };

            decimal discount = _calculator.CalculateDiscountPercentage(customer);

            Assert.AreEqual(0.10m, discount);
        }

        [Test]
        public void Return12PctFor5YearLoyalCustomer()
        {
            var customer = new Customer() { DateOfBirth = DateTime.Today.AddDays(-5), DateOfFirstPurchase = DateTime.Today.AddYears(-5) };

            decimal discount = _calculator.CalculateDiscountPercentage(customer);

            Assert.AreEqual(0.12m, discount);
        }

        [Test]
        public void Return22PctFor5YearLoyalCustomerOnBirthday()
        {
            var customer = new Customer() { DateOfBirth = DateTime.Today, DateOfFirstPurchase = DateTime.Today.AddYears(-5) };

            decimal discount = _calculator.CalculateDiscountPercentage(customer);

            Assert.AreEqual(0.22m, discount);
        }

    }
}
