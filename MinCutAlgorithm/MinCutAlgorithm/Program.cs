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
            string Path = @"C:\Users\Nilufar\Documents\GitHub\Stanford Algo\W3\kargerMinCut.txt";

            AdjacencyList readResult = FileReader.GetAdjacencyList(Path);

            //Console.ReadLine();
            //foreach (Vertex v in readResult.ListOfVertices)
            //{
            //    Console.WriteLine(v.Label);
            //}
            Console.WriteLine(readResult.ListOfVertices.Count);
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
            
            while (adjacencyList.ListOfVertices.Count > 2) {
                Random r = new Random();
                int r_number = r.Next(adjacencyList.ListOfEdges.Count - 1);
                Edge randomEdge = adjacencyList.ListOfEdges.ElementAt(r_number);
                //merge to endpoints of edge into 1
                Vertex mergedVertex = new Vertex { Label = randomEdge.FirstEndpoint.Label + "and" + randomEdge.SecondEndPoint.Label };

                foreach (Edge e in randomEdge.FirstEndpoint.IncidentEdges) {
                    if (e.FirstEndpoint == randomEdge.FirstEndpoint) {
                        e.FirstEndpoint = mergedVertex;                        
                    }
                    else if ( e.SecondEndPoint == randomEdge.FirstEndpoint){
                        e.SecondEndPoint = mergedVertex;                       
                    }
                    mergedVertex.IncidentEdges.Add(e);
                }
                foreach (Edge e in randomEdge.SecondEndPoint.IncidentEdges)
                {
                    if (e.FirstEndpoint == randomEdge.SecondEndPoint) 
                    {
                        e.FirstEndpoint = mergedVertex;
                       }
                        else if (e.SecondEndPoint == randomEdge.SecondEndPoint) {
                            e.SecondEndPoint = mergedVertex;
                        }
                    mergedVertex.IncidentEdges.Add(e);
                }
                //remove self loops

                foreach (Edge e in mergedVertex.IncidentEdges) {
                    if (e.FirstEndpoint.Label == e.SecondEndPoint.Label) {
                        mergedVertex.IncidentEdges.Remove(e);
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
                Vertex mainVertex = new Vertex() { Label = lineNumbers[0] };
                bool mainVertexAlreadyExists = result.ListOfVertices.Exists(x => x.Label == mainVertex.Label); 
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
                        if (!mainVertexAlreadyExists)
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
