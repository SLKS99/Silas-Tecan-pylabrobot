//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tecan.VisionX.Sila2
{
    using Tecan.Sila2;
    
    
    ///  <summary>
    /// Data transfer object for the request of the Start Simulation Mode command
    /// </summary>
    [ProtoBuf.ProtoContractAttribute()]
    public class StartSimulationModeRequestDto : Tecan.Sila2.ISilaTransferObject, Tecan.Sila2.ISilaRequestObject
    {
        
        ///  <summary>
        /// Create a new instance
        /// </summary>
        public StartSimulationModeRequestDto()
        {
        }
        
        ///  <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="store">An object to organize binaries.</param>
        public StartSimulationModeRequestDto(Tecan.Sila2.IBinaryStore store)
        {
        }
        
        ///  <summary>
        /// Gets the command identifier for this command
        /// </summary>
        /// <returns>The fully qualified command identifier</returns>
        public string CommandIdentifier
        {
            get
            {
                return "org.silastandard/core/SimulationController/v1/Command/StartSimulationMode";
            }
        }
        
        ///  <summary>
        /// Validates the contents of this transfer object
        /// </summary>
        /// <returns>A validation error or null, if no validation error occurred.</returns>
        public string GetValidationErrors()
        {
            return null;
        }
    }
    
    ///  <summary>
    /// Data transfer object for the request of the Start Real Mode command
    /// </summary>
    [ProtoBuf.ProtoContractAttribute()]
    public class StartRealModeRequestDto : Tecan.Sila2.ISilaTransferObject, Tecan.Sila2.ISilaRequestObject
    {
        
        ///  <summary>
        /// Create a new instance
        /// </summary>
        public StartRealModeRequestDto()
        {
        }
        
        ///  <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="store">An object to organize binaries.</param>
        public StartRealModeRequestDto(Tecan.Sila2.IBinaryStore store)
        {
        }
        
        ///  <summary>
        /// Gets the command identifier for this command
        /// </summary>
        /// <returns>The fully qualified command identifier</returns>
        public string CommandIdentifier
        {
            get
            {
                return "org.silastandard/core/SimulationController/v1/Command/StartRealMode";
            }
        }
        
        ///  <summary>
        /// Validates the contents of this transfer object
        /// </summary>
        /// <returns>A validation error or null, if no validation error occurred.</returns>
        public string GetValidationErrors()
        {
            return null;
        }
    }
}
