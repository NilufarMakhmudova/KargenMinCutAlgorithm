using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCutAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            string Path = @"C:\Users\Nilufar\Documents\GitHub\Stanford Algo\W3\testCase1.txt";
            
            AdjacencyList readResult = FileReader.GetAdjacencyList(Path);
            RandomContractionAlgorithm algo = new RandomContractionAlgorithm(readResult);
            int minValue = 8000;

            for (int i = 1; i < 10000000; i++) {
                readResult = algo.MinCuts();
                int actual = readResult.ListOfEdges.FindAll(x => x.isDeleted == false).Count;
                if (actual < minValue) minValue = actual;
                //    Console.WriteLine(i + "th iteration");
                //    Console.WriteLine("Min value:" + minValue);
                //    Console.WriteLine("After iteration:" + actual);
                //    Console.WriteLine("/n");
            }
            //Console.ReadLine();
            //foreach (Vertex v in readResult.ListOfVertices)
            //{
            //    Console.WriteLine(v.Label);
            //}
            Console.WriteLine(minValue);
            Console.ReadLine();

        }
    }

    public class RandomContractionAlgorithm {

        public AdjacencyList adjacencyList;
        public RandomContractionAlgorithm(AdjacencyList list)
        {
            adjacencyList = list;
        }

        public AdjacencyList MinCuts() {
            
            while (adjacencyList.ListOfVertices
                .Where(x => x.isDeleted == false).ToList().Count > 2) {
                Random r = new Random();
                int allEdges = adjacencyList.ListOfEdges.Where(m => m.isDeleted == false).ToList().Count;
                int r_number = r.Next(1, allEdges);
                Edge randomEdge = adjacencyList.ListOfEdges.Where(m => m.isDeleted == false).ElementAt(r_number - 1);
                //merge to endpoints of edge into 1
                Vertex mergedVertex = randomEdge.FirstEndpoint;
                mergedVertex.Label += "mergedWith" + randomEdge.SecondEndPoint.Label;
                randomEdge.SecondEndPoint.isDeleted = true;
                randomEdge.isDeleted = true;                

                foreach (Edge e in randomEdge.SecondEndPoint.IncidentEdges.Where(x=>x.isDeleted==false))
                {
                    
                    if (e.FirstEndpoint == randomEdge.SecondEndPoint)
                    {
                        e.FirstEndpoint = mergedVertex;
                    }
                    else if (e.SecondEndPoint == randomEdge.SecondEndPoint)
                    {
                        e.SecondEndPoint = mergedVertex;
                    }
                    mergedVertex.IncidentEdges.Add(e);
                }

                randomEdge.SecondEndPoint = mergedVertex;
                //remove self loops

                foreach (Edge e in mergedVertex.IncidentEdges.Where(x => x.isDeleted == false))
                {
                    if (e.FirstEndpoint.Label == e.SecondEndPoint.Label)
                    {
                        e.isDeleted = true;
                     }
                }
                }
            //return cut represented by 2 final cuts
            
            return adjacencyList;
        }

    }

    public static class FileReader {
        public static AdjacencyList GetAdjacencyList(string path) {
            AdjacencyList result = new AdjacencyList();

            string[] fileLines = File.ReadAllLines(path);

            for  (int j=0; j<fileLines.Length; j++) {
                string[] lineNumbers = fileLines[j].Trim().Replace(" ", "\t").Split('\t');
                bool mainVertexAlreadyExists = result.ListOfVertices.Exists(x => x.Label == lineNumbers[0]);
                Vertex mainVertex = mainVertexAlreadyExists? result.ListOfVertices.Find(x => x.Label == lineNumbers[0]) : new Vertex() { Label = lineNumbers[0] };

                for (int i = 1; i < lineNumbers.Length; i++) {
                    bool vertexAlreadyCreated=false;
                    try
                    {
                        vertexAlreadyCreated = result.ListOfVertices.Exists(x => x.Label == lineNumbers[i]);                        
                    }
                    catch (NullReferenceException)
                    {
                        vertexAlreadyCreated = false;
                    }
                    Edge newEdge;
                    if (!vertexAlreadyCreated)
                    {
                        Vertex adjacentVertex = new Vertex() { Label = lineNumbers[i]};
                        newEdge = new Edge() { FirstEndpoint = mainVertex, SecondEndPoint = adjacentVertex };                        
                        adjacentVertex.IncidentEdges.Add(newEdge);
                        result.ListOfVertices.Add(adjacentVertex);
                        result.ListOfEdges.Add(newEdge);
                        mainVertex.IncidentEdges.Add(newEdge);

                    }
                    else {
                        Vertex existingVertex = result.ListOfVertices.Find(x => x.Label == lineNumbers[i]);
                        bool edgeAlreadyExists = result.ListOfEdges.Exists(c => (c.FirstEndpoint.Label == existingVertex.Label && c.SecondEndPoint.Label == mainVertex.Label) || (c.SecondEndPoint.Label == existingVertex.Label && c.FirstEndpoint.Label == mainVertex.Label));
                        if (!edgeAlreadyExists)
                        {
                            newEdge = new Edge() { FirstEndpoint = mainVertex, SecondEndPoint = existingVertex };
                            existingVertex.IncidentEdges.Add(newEdge);
                            mainVertex.IncidentEdges.Add(newEdge);
                            result.ListOfEdges.Add(newEdge);
                        }
                    }
                    }
                if (!mainVertexAlreadyExists)
                {
                    result.ListOfVertices.Add(mainVertex);
                }
            }

            return  result;
        }
    }
}
