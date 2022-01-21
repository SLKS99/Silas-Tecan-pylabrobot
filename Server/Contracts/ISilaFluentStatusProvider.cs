using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecan.Sila2;

namespace Tecan.VisionX.Sila2
{
    /// <summary>
    /// Denotes a status provider for FluentControl
    /// </summary>
    [SilaFeature]
    [SilaDisplayName("FluentControl Status Provider")]
    public interface ISilaFluentStatusProvider
    {
        /// <summary>
        /// Gets the state of FluentControl
        /// </summary>
        [Observable]
        FluentControlState State { get; }

        /// <summary>
        /// Gets the value of the last progress update
        /// </summary>
        [Observable]
        int Progress { get; }

        /// <summary>
        /// Gets the last error message
        /// </summary>
        [Observable]
        string LastError { get; }
    }
}
