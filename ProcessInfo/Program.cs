﻿using System;
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

                // Display the CPU usage percentage
                Console.WriteLine("CPU Usage: {0}%", cpuUsage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Thread.Sleep(1000);
        }
    }
}