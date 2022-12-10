using System.Diagnostics;
using System.IO;
using Microsoft.VisualBasic.Devices;
using MugPlugin.Model;

namespace MugPlugin.StressTest
{
    /// <summary>
    /// Stress test class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main class method for running load testing.
        /// </summary>
        private static void Main()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var mugBuilder = new MugBuilder();
            var mugParameters = new MugParameters();
            var streamWriter = new StreamWriter($"StressTest.txt", true);
            var modelCounter = 0;
            var computerInfo = new ComputerInfo();
            ulong usedMemory = 0;
            while (usedMemory * 0.96 <= computerInfo.TotalPhysicalMemory)
            {
                mugBuilder.BuildMug(mugParameters);
                usedMemory = (computerInfo.TotalPhysicalMemory - computerInfo.AvailablePhysicalMemory);
                streamWriter.WriteLine(
                    $"{++modelCounter}\t{stopWatch.Elapsed:hh\\:mm\\:ss}\t{usedMemory}");
                streamWriter.Flush();
            }
            stopWatch.Stop();
            streamWriter.WriteLine("END");
            streamWriter.Close();
            streamWriter.Dispose();
        }
    }
}
