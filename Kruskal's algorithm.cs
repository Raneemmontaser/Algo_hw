//C# implementation of Kruskal's algorithm:
using System;
using System.Collections.Generic;

class KruskalAlgorithm
{
    static void Main(string[] args)
    {
        Console.Write("Enter the number of vertices: ");
        int vertices = int.Parse(Console.ReadLine());

        Console.Write("Enter the number of edges: ");
        int edgeCount = int.Parse(Console.ReadLine());

        var edges = new List<(int, int, int)>();
        Console.WriteLine("Enter edges in the format: u v weight (0-indexed vertices)");
        for (int i = 0; i < edgeCount; i++)
        {
            string[] edgeInput = Console.ReadLine().Split();
            int u = int.Parse(edgeInput[0]);
            int v = int.Parse(edgeInput[1]);
            int weight = int.Parse(edgeInput[2]);

            
            if (u < 0 || v < 0 || u >= vertices || v >= vertices)
            {
                Console.WriteLine($"Error: Invalid edge ({u}, {v}). Vertex indices must be between 0 and {vertices - 1}.");
                i--; 
                continue;
            }

            edges.Add((u, v, weight));
        }

        Console.WriteLine("Edges in the Minimum Spanning Tree:");
        KruskalMST(edges, vertices);
    }

    static void KruskalMST(List<(int, int, int)> edges, int vertices)
    {
        
        edges.Sort((a, b) => a.Item3.CompareTo(b.Item3));

        
        int[] parent = new int[vertices];
        int[] rank = new int[vertices];
        for (int i = 0; i < vertices; i++)
        {
            parent[i] = i;
        }

        var mst = new List<(int, int, int)>();
        int mstWeight = 0;

        foreach (var (u, v, w) in edges)
        {
            if (Find(parent, u) != Find(parent, v))
            {
                mst.Add((u, v, w));
                mstWeight += w;
                Union(parent, rank, u, v);
            }
        }

        foreach (var (u, v, w) in mst)
        {
            Console.WriteLine($"Edge: {u} - {v}, Weight: {w}");
        }
        Console.WriteLine($"Total Weight of MST: {mstWeight}");
    }

    static int Find(int[] parent, int i)
    {
        if (parent[i] != i)
        {
            parent[i] = Find(parent, parent[i]); 
        }
        return parent[i];
    }

    static void Union(int[] parent, int[] rank, int x, int y)
    {
        int rootX = Find(parent, x);
        int rootY = Find(parent, y);

        if (rootX != rootY)
        {
            if (rank[rootX] < rank[rootY])
            {
                parent[rootX] = rootY;
            }
            else if (rank[rootX] > rank[rootY])
            {
                parent[rootY] = rootX;
            }
            else
            {
                parent[rootY] = rootX;
                rank[rootX]++;
            }
        }
    }
}



