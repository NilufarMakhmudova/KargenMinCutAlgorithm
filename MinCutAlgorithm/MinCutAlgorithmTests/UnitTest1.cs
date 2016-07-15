using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinCutAlgorithm;

namespace MinCutAlgorithmTests
{
    [TestClass]
    public class kargenMinCutTests
    {
        [TestMethod]
        public void testCase1Test()
        {
            int expected = 2;
            string expectedEndPoint1 = "1and7";
            string expectedEndPoint2 = "4and5";
            string filePath = @"C:\Users\Nilufar\Documents\GitHub\Stanford Algo\W3\testCase1.txt";
            AdjacencyList list = MinCutAlgorithm.FileReader.GetAdjacencyList(filePath);
            RandomContractionAlgorithm algo = new RandomContractionAlgorithm(list);
            list = algo.MinCuts();
            int actual = list.ListOfEdges.Count;
            string actualEndPoint1 = list.ListOfEdges[0].FirstEndpoint.Label + "and" + list.ListOfEdges[0].FirstEndpoint.Label;
            string actualEndPoint2 = list.ListOfEdges[1].FirstEndpoint.Label + "and" + list.ListOfEdges[0].FirstEndpoint.Label;

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedEndPoint1, actualEndPoint1);
            Assert.AreEqual(expectedEndPoint1, actualEndPoint2);
            Assert.AreEqual(expectedEndPoint2, actualEndPoint1);
            Assert.AreEqual(expectedEndPoint2, actualEndPoint2);
        }

        [TestMethod]
        public void testCase2Test()
        {
            int expected = 2;
            string expectedEndPoint1 = "1and7";
            string expectedEndPoint2 = "4and5";
            string filePath = @"C:\Users\Nilufar\Documents\GitHub\Stanford Algo\W3\testCase2.txt";
            AdjacencyList list = MinCutAlgorithm.FileReader.GetAdjacencyList(filePath);
            RandomContractionAlgorithm algo = new RandomContractionAlgorithm(list);
            list = algo.MinCuts();
            int actual = list.ListOfEdges.Count;
            string actualEndPoint1 = list.ListOfVertices[0].Label;
            string actualEndPoint2 = list.ListOfVertices[1].Label;

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedEndPoint1, actualEndPoint1);
            Assert.AreEqual(expectedEndPoint1, actualEndPoint2);
            Assert.AreEqual(expectedEndPoint2, actualEndPoint1);
            Assert.AreEqual(expectedEndPoint2, actualEndPoint2);
        }

        [TestMethod]
        public void testCase3Test()
        {
            int expected = 1;
            string expectedEndPoint1 = "4and5";
            string filePath = @"C:\Users\Nilufar\Documents\GitHub\Stanford Algo\W3\testCase3.txt";
            AdjacencyList list = MinCutAlgorithm.FileReader.GetAdjacencyList(filePath);
            RandomContractionAlgorithm algo = new RandomContractionAlgorithm(list);
            list = algo.MinCuts();
            int actual = list.ListOfEdges.Count;
            string actualEndPoint1 = list.ListOfVertices[0].Label;
           
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedEndPoint1, actualEndPoint1);
            }

        [TestMethod]
        public void testCase4Test()
        {
            int expected = 1;
            string expectedEndPoint1 = "4and5";
            string filePath = @"C:\Users\Nilufar\Documents\GitHub\Stanford Algo\W3\testCase4.txt";
            AdjacencyList list = MinCutAlgorithm.FileReader.GetAdjacencyList(filePath);
            RandomContractionAlgorithm algo = new RandomContractionAlgorithm(list);
            list = algo.MinCuts();
            int actual = list.ListOfEdges.Count;
            string actualEndPoint1 = list.ListOfVertices[0].Label;
            
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedEndPoint1, actualEndPoint1);
            }

        [TestMethod]
        public void testCase5Test()
        {
            int expected = 3;
            string filePath = @"C:\Users\Nilufar\Documents\GitHub\Stanford Algo\W3\testCase5.txt";
            AdjacencyList list = MinCutAlgorithm.FileReader.GetAdjacencyList(filePath);
            RandomContractionAlgorithm algo = new RandomContractionAlgorithm(list);
            list = algo.MinCuts();
            int actual = list.ListOfEdges.Count;
            
            Assert.AreEqual(expected, actual);
            }

        [TestMethod]
        public void testCase6Test()
        {
            int expected = 2;
            string filePath = @"C:\Users\Nilufar\Documents\GitHub\Stanford Algo\W3\testCase6.txt";
            AdjacencyList list = MinCutAlgorithm.FileReader.GetAdjacencyList(filePath);
            RandomContractionAlgorithm algo = new RandomContractionAlgorithm(list);
            list = algo.MinCuts();
            int actual = list.ListOfEdges.Count;
            
            Assert.AreEqual(expected, actual);
            }
    }
}
