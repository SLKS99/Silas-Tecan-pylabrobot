using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tecan.VisionX.Sila2
{
    [Export(typeof(ISimulationController))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class SimulationController : ISimulationController
    {
        public bool SimulationMode => false;

        public void StartRealMode()
        {
        }

        public void StartSimulationMode()
        {
            throw new StartSimulationModeFailedException("You are not supposed to use this");
        }
    }
}
