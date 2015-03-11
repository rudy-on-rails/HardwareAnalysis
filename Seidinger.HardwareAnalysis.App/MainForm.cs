using Seidinger.HardwareAnalysis.Core.Hardware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seidinger.HardwareAnalysis.App
{
    public partial class MainForm : Form, HardwareResourceChangedObserver
    {
        private Computer computer;
        public MainForm()
        {
            InitializeComponent();
            this.computer = new Computer();
            this.computer.AddHardwareResourceChangedObserver(this);
            UpdateHardwareInformationTimer.Start();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UpdateHardwareInformationTimer_Tick(object sender, EventArgs e)
        {
            this.computer.UpdateHardwareInformation();
        }

        public void HardwareInformationChanged()
        {
            UpdateHardwareDisplayInformation();
        }

        private void UpdateHardwareDisplayInformation()
        {
            var cpuUsage = this.computer.CpuInformation.CpuUsage;
            var availableMemory = this.computer.MemoryInformation.AvailableMemory;
            var hardDiskUsage = this.computer.HardDriveInformation.HardDriveUsage;
            this.CpuUsageLabel.Text = String.Format("{0} %", cpuUsage);
            this.AvailableMemoryLabel.Text = String.Format("{0} MB", availableMemory);
            this.HardDrivePercentageUsedLabel.Text = String.Format("{0} %", hardDiskUsage);
        }
    }
}
