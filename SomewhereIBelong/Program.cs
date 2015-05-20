using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SomewhereIBelong
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphGenerator generator = new GraphGenerator();
            BoruvkaMST boruvka;
            KruskalMST kurskal;
            Stopwatch watch;
            double time;

            StreamWriter boruvkaOut = new StreamWriter("boruvka_out.txt");
            StreamWriter kurskalOut = new StreamWriter("kurskal_out.txt");

            for(int i = 1; i<Constants.weightMax; i+=Constants.weightStep)
            {
                var n =  Constants.vertexCount;
                Graph g = generator.generateWeightedGraph(n, n * (n - 1)/2, Constants.weightMin, i);
                watch = Stopwatch.StartNew();
                boruvka = new BoruvkaMST(g);
                watch.Stop();
                time = watch.ElapsedMilliseconds;
                Console.WriteLine("boruvka time with {0} max weight is {1} ", i, time);
                boruvkaOut.Write(time+"\t");

                watch = Stopwatch.StartNew();
                kurskal = new KruskalMST(g);
                watch.Stop();
                time = watch.ElapsedMilliseconds;
                Console.WriteLine("kurskal time with {0} max weight is {1}",i,time);
                kurskalOut.Write(time+"\t");
            }

            boruvkaOut.Close();
            kurskalOut.Close();
        }
    }
}
