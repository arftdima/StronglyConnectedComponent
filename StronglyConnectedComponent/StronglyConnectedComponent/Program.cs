using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StronglyConnectedComponent
{
    public class Program
    {
        static List<int>[] g, gr; //G and GT
        static bool[] used;
        static List<int> order, companent;

        static void dfs1(int v)
        {
            used[v] = true;
            for (var i = 0; i < g[v].Count; ++i)
                if (!used[g[v][i]]) dfs1(g[v][i]);
            order.Add(v);
        }

        static void dfs2(int v)
        {
            used[v] = true;
            companent.Add(v);
            for (var i = 0; i < gr[v].Count; ++i)
                if (!used[gr[v][i]]) dfs2(gr[v][i]);
        }    
        

        static void Main(string[] args)
        {
            var N = 4;

            //init
            g = new List<int>[N]; 
            gr = new List<int>[N];
            for (var i = 0; i < g.Length; ++i)
            {
                g[i] = new List<int>();
                gr[i] = new List<int>();
            }           

            used = new bool[N];
            order = new List<int>();
            companent = new List<int>();
            

            //G
            g[0].Add(1);
            g[0].Add(3);
            g[1].Add(0);
            
            //GT
            gr[0].Add(1);
            gr[1].Add(0);
            gr[3].Add(0);

            //DFS_G
            for (var i = 0; i < N; ++i)
                if (!used[i])
                    dfs1(i);

            var counter = 0;

            //DFS_GT
            used = new bool[N];
            for(var i = 0;i < N; ++i)
            {
                int v = order[N - 1 - i];
                if(!used[v])
                {
                    dfs2(v);
                    companent.ForEach(x => Console.Write($"{x} "));
                    ++counter;
                    Console.WriteLine();
                    companent.Clear();
                }
            }
            Console.WriteLine($"counter := {counter}");
        }
    }
}
