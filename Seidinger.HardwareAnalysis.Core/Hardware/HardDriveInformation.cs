using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Seidinger.HardwareAnalysis.Core.Hardware
{
    public class HardDriveInformation : HardwareResource
    {
        private readonly string MAIN_DRIVE_NAME = "C:\\";
        
        public int HardDriveUsage { get; private set; }
        
        public void RetrieveHardwareInformation()
        {
            DriveInfo mainDriveInfo = DriveInfo.GetDrives().Single(x => x.Name == MAIN_DRIVE_NAME);
            var percentageOfSpaceFree = ((decimal)mainDriveInfo.AvailableFreeSpace / mainDriveInfo.TotalSize) * 100;
            this.HardDriveUsage = 100 - (int)percentageOfSpaceFree;
        }
    }
}
