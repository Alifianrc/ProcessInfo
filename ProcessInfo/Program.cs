using System;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            try
            {
                Console.Clear();

                // Get the process ID for the process you want to monitor
                int processId = Process.GetProcessesByName("Server")[0].Id;

                // Get the process object for the specified process ID
                Process process = Process.GetProcessById(processId);

                // Get the total CPU time for the process
                TimeSpan totalCpuTime = process.TotalProcessorTime;

                // Wait for a short period of time to calculate the CPU usage
                Thread.Sleep(500);

                // Get the CPU time for the process after the wait
                TimeSpan currentCpuTime = process.TotalProcessorTime;

                // Calculate the CPU usage as a percentage
                double cpuUsage = ((currentCpuTime - totalCpuTime).TotalMilliseconds / (double)(Environment.ProcessorCount * 500)) * 100;

                Console.WriteLine("Total Milisecond: {0}", (currentCpuTime - totalCpuTime).TotalMilliseconds);
                Console.WriteLine("Processor Count: {0}\n", Environment.ProcessorCount);

                // Display the CPU usage percentage
                Console.WriteLine("CPU Usage: {0}%", cpuUsage);

                // -----------------------------------------------------------------------------

                // Get the working set size for the process (in bytes)
                long workingSetSize = process.WorkingSet64;

                // Get the total physical memory installed on the system (in bytes)
                ulong totalMemory = 0;
                var memInfo = new System.IO.StreamReader("/proc/meminfo");
                var totalMemoryLine = memInfo.ReadLine();
                var totalMemoryStr = new string(totalMemoryLine.Where(char.IsDigit).ToArray());
                totalMemory = ulong.Parse(totalMemoryStr) * 1024;

                // Calculate the RAM usage as a percentage
                double ramUsage = ((double)workingSetSize / (double)totalMemory) * 100;

                // Display the RAM usage percentage
                Console.WriteLine("RAM Usage: {0}%", ramUsage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Thread.Sleep(500);
        }
    }
}