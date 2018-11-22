using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMapHeightCalc()
        {
            TowerConfiguration towerConfig = new TowerConfiguration();
            towerConfig.random = new Random();

            List<int> results = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                results.Add( towerConfig.GetNextTowerHeight(16));
            }
            Assert.IsTrue(results.All(a => a > 4 && a < 9));
        }

        [TestMethod]
        public void TestDistanceToNextTower()
        {
            TowerConfiguration towerConfig = new TowerConfiguration();
            towerConfig.random  = new Random();

            List<int> results = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                results.Add(towerConfig.GetDistanceToNextTower());
            }
            Assert.IsTrue(results.All(a => a > 2 && a < 4));
        }
    }
}
