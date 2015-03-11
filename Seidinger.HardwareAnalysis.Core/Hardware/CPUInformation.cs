using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace Seidinger.HardwareAnalysis.Core.Hardware
{
    public class CPUInformation : HardwareResource
    {
        public ulong CpuUsage { get; private set; }
        private readonly string PROCESSOR_QUERY = "select * from Win32_PerfFormattedData_PerfOS_Processor";
        
        public void RetrieveHardwareInformation()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(PROCESSOR_QUERY);
            var cpuTimes = searcher.Get()
                .Cast<ManagementObject>()
                .Select(mo => new
                {
                    Name = mo["Name"],
                    Usage = mo["PercentProcessorTime"]
                }
                )
                .ToList();
            var query = cpuTimes.Where(x => x.Name.ToString() == "_Total").Select(x => x.Usage);
            var cpuUsage = query.SingleOrDefault();
            this.CpuUsage = (ulong)cpuUsage;
        }
    }
}
