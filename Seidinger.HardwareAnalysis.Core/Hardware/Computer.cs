using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seidinger.HardwareAnalysis.Core.Hardware
{
    public class Computer
    {
        private IList<HardwareResource> Resources;
        public CPUInformation CpuInformation { get; private set; }
        public MemoryInformation MemoryInformation { get; private set; }
        public HardDriveInformation HardDriveInformation { get; private set; }
        public IList<HardwareResourceChangedObserver> HardwareResourceChangedObservers;

        public Computer()
        {
            this.HardwareResourceChangedObservers = new List<HardwareResourceChangedObserver>();
            this.Resources = new List<HardwareResource>();
            this.HardDriveInformation = new HardDriveInformation();
            this.CpuInformation = new CPUInformation();
            this.MemoryInformation = new MemoryInformation();
            this.Resources.Add(CpuInformation);
            this.Resources.Add(MemoryInformation);
            this.Resources.Add(HardDriveInformation);
        }

        public void UpdateHardwareInformation()
        {
            foreach (var hardwareResource in this.Resources)
            {
                hardwareResource.RetrieveHardwareInformation();
            }
            foreach (var observer in this.HardwareResourceChangedObservers)
            {
                observer.HardwareInformationChanged();
            }
        }

        public void AddHardwareResourceChangedObserver(HardwareResourceChangedObserver hardwareResourceChangedObserver)
        {
            this.HardwareResourceChangedObservers.Add(hardwareResourceChangedObserver);
        }
    }
}
