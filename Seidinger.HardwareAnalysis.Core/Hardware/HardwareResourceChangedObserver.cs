using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seidinger.HardwareAnalysis.Core.Hardware
{
    public interface HardwareResourceChangedObserver
    {
        void HardwareInformationChanged();        
    }
}
