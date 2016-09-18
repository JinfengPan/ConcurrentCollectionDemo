using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentDemo
{
    public class ParallelBenchmark
    {
        static void PopulateDictParallel(ConcurrentDictionary<int, int> dict, int dictSize)
        {
            Parallel.For(0, dictSize, (i) => dict.TryAdd(i, 0));

            Parallel.For(0, dictSize, (i) =>
            {
                bool done = dict.TryUpdate(i, 1, 0);
                if(!done)
                    throw new Exception("Error updating. Old value was " + dict[i]);
            });
        }

        static int GetTotalValueParallel(ConcurrentDictionary<int, int> dict)
        {
            int expectedTotal = dict.Count;

            int total = 0;
            Parallel.ForEach(dict, keyValPair =>
            {
                Interlocked.Add(ref total, keyValPair.Value);

            });

            return total;
        }
    }
}
