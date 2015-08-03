using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class ParallelismTests
    {
        [Test, Ignore]
        public void Using_Nothing()
        {
            Console.WriteLine("In Series...");
            var source = Enumerable.Range(1, 10);
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            source.ToList().ForEach(Calculate);
            stopWatch.Stop();
            Console.WriteLine("All tasks completed in {0} milliseconds", stopWatch.ElapsedMilliseconds);
        }

        [Test]
        public void Using_Task_Factory()
        {
            Console.WriteLine("Asynchronously with Tasks");
            var stopWatch = new Stopwatch();
            var source = Enumerable.Range(1, 10);

            stopWatch.Start();
            var tasks = source.Select(i => Task.Run(() => Calculate(i))).ToArray();
            Task.WaitAll(tasks);
            stopWatch.Stop();
            Console.WriteLine("All tasks completed in {0} milliseconds", stopWatch.ElapsedMilliseconds);
        }

        [Test]
        public void Using_tasks_with_a_result()
        {
            Console.WriteLine("Tasks with a result");
            var stopWatch = new Stopwatch();
            var source = Enumerable.Range(1, 10);
            var results = new List<string>();

            stopWatch.Start();
            var tasks = source.Select(i => Task.Run(() => results.Add(Calculate2(i)))).ToArray();

            Task.WaitAll(tasks);
            stopWatch.Stop();
            results.ForEach(Console.WriteLine);
            Console.WriteLine("All tasks completed in {0} milliseconds", stopWatch.ElapsedMilliseconds);

        }

        private static void Calculate(int i)
        {
            var rando = ((i % 4) + 1) * 500;

            Thread.Sleep(rando);
            Console.WriteLine("{0} waited {1} milliseconds to complete on thread '{2}'", 
                i, 
                rando, 
                Thread.CurrentThread.ManagedThreadId);
        }

        private static string Calculate2(int i)
        {
            var rando = ((i % 4) + 1) * 500;

            Thread.Sleep(rando);
            return String.Format("{0} waited {1} milliseconds to complete on thread '{2}'",
                i,
                rando,
                Thread.CurrentThread.ManagedThreadId);
        }
    }
}
