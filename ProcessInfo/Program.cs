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

                // Get the amount of time that the process has been running
                TimeSpan runningTime = DateTime.Now - process.StartTime;

                // Get the number of CPU cores
                int cpuCount = Environment.ProcessorCount;

                // Calculate the CPU usage as a percentage
                double cpuUsage = (totalCpuTime.TotalMilliseconds / runningTime.TotalMilliseconds / cpuCount) * 100;

                Console.WriteLine("Total CPU Time : {0}", totalCpuTime);
                Console.WriteLine("Running Time : {0}", runningTime);
                Console.WriteLine("CPU Count : {0}\n", cpuCount);

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
            Thread.Sleep(1000);
        }
    }
}