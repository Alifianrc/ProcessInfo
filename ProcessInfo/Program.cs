using System;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Get a list of all running processes
        Process[] processes = Process.GetProcesses();

        // Iterate through each "dotnet run" process and display its name and CPU usage
        foreach (Process process in processes)
        {
            Console.WriteLine("{0} - CPU Usage: {1}%", process.ProcessName, process.TotalProcessorTime.Milliseconds);
        }
    }
}