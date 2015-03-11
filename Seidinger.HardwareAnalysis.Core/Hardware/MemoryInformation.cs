using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Seidinger.HardwareAnalysis.Core.Hardware
{   
    public class MemoryInformation : HardwareResource
    {
        public int AvailableMemory { get; private set; }
        public void RetrieveHardwareInformation()
        {
            var performanceCounter = new PerformanceCounter("Memory", "Available MBytes", true);
            this.AvailableMemory = (int)performanceCounter.NextValue();
        }
    }
}
