using System;
using System.Collections.Generic;
using Tecan.Sila2;


namespace Tecan.VisionX.Sila2
{
    /// <summary>
    /// Denotes a service to remote-control FluentControl
    /// </summary>
    [SilaFeature]
    [SilaDisplayName("Fluent Service")]
    public interface ISilaFluentController
    {
        /// <summary>
        /// Adds new labware to the worktable
        /// </summary>
        /// <param name="barcode">the barcode of the labware</param>
        /// <param name="hasLid">True, if the labware has a lid</param>
        /// <param name="labwareName">the name of the labware</param>
        /// <param name="labwareType">the type of the labware</param>
        /// <param name="targetLocation">the location where the labware should be spawned</param>
        /// <param name="position">the position in the target location group</param>
        /// <param name="rotation">the rotation of the labware</param>
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void AddLabware(string barcode, bool hasLid, string labwareName, string labwareType, string targetLocation, int position, int rotation);

        /// <summary>
        /// Removes the labware with the given name
        /// </summary>
        /// <param name="labwareName">the name of the labware</param>
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void RemoveLabware(string labwareName);

        /// <summary>
        /// Sets the location of the given labware
        /// </summary>
        /// <param name="labware">the name of the labware</param>
        /// <param name="rotation">the new rotation of the labware</param>
        /// <param name="targetLocation">the target location group name</param>
        /// <param name="targetSite">the target site</param>
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void SetLocation(string labware, int rotation, string targetLocation, int targetSite);

        /// <summary>
        /// Starts a subroutine with the given name
        /// </summary>
        /// <param name="subroutineName">the name of the subroutine</param>
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void Subroutine(string subroutineName);

        /// <summary>
        /// Transfers labware on the worktable with the RGA
        /// </summary>
        /// <param name="labwareToLocation">the labware that should be moved</param>
        /// <param name="onlyUseSelectedSite">True, if the instrument should only use the exact target position, otherwise False</param>
        /// <param name="targetLocation">the target location group</param>
        /// <param name="targetPosition">the target position</param>
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void TransferLabware(string labwareToLocation, bool onlyUseSelectedSite, string targetLocation, int targetPosition);

        /// <summary>
        /// Transfers the given labware back to its base
        /// </summary>
        /// <param name="labwareName">the name of the labware</param>
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void TransferLabwareBackToBase(string labwareName);

        /// <summary>
        /// Executes a generic command
        /// </summary>
        /// <param name="content">the XML representation of the command</param>
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void GenericCommand(string content);

        /// <summary>
        /// Gets the fingers of the gripper
        /// </summary>
        /// <param name="deviceAlias">the alias of the RGA</param>
        /// <param name="gripperFingers">the gripper fingers</param>
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void GetFingers(string deviceAlias, string gripperFingers);

        /// <summary>
        /// Drops the fingers to the provided docking station
        /// </summary>
        /// <param name="deviceAlias">the alias of the RGA</param>
        /// <param name="dockingStation">the docking station</param>
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void DropFingers(string deviceAlias, string dockingStation);

        /// <summary>
        /// Shows a user prompt on TouchTools
        /// </summary>
        /// <param name="text">the text to display to the user</param>
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void UserPrompt(string text);

        /// <summary>
        /// Gets tips
        /// </summary>
        /// <param name="airgapVolume">the airgap volume</param>
        /// <param name="airgapSpeed">the airgap speed</param>
        /// <param name="diTiType">the type of disposable tips</param>
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void GetTips(int airgapVolume, int airgapSpeed, string diTiType); 

        /// <summary>
        /// Aspirates liquid
        /// </summary>
        /// <param name="volume">the volume that should be aspirated</param>
        /// <param name="labware">the labware from which should be aspirated</param>
        /// <param name="liquidClass">the name of the liquid class used for aspiration</param>
        /// <param name="wellOffset">the well offset</param>
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void Aspirate(int volume, string labware, string liquidClass, int wellOffset);

        /// <summary>
        /// Dispenses liquid
        /// </summary>
        /// <param name="volume">the volume that should be dispensed</param>
        /// <param name="labware">the labware that should be dispensed into</param>
        /// <param name="liquidClass">the name of the liquid class used for dispensing</param>
        /// <param name="wellOffset">the well offset</param>
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void Dispense(int volume, string labware, string liquidClass, int wellOffset);

        /// <summary>
        /// Drops the currently mounted disposable tips to the provided labware
        /// </summary>
        /// <param name="labware">the labware</param>
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void DropTips(string labware);

        /// <summary>
        /// Starts FluentControl or connect to an instance already running
        /// </summary>
        void StartFluentOrAttach();

        /// <summary>
        /// Starts FluentControl and log in or connect to an instance already running
        /// </summary>
        void StartFluentAndLogin(string username, string password);

        /// <summary>
        /// Starts FluentControl in simulation mode
        /// </summary>
        void StartFluentInSimulationMode();

        /// <summary>
        /// Prepares the method for execution
        /// </summary>
        /// <param name="toPrepare">the name of the method to prepare</param>
        void PrepareMethod(string toPrepare);

        /// <summary>
        /// Runs the currently prepared method
        /// </summary>
        void RunMethod();

        /// <summary>
        /// Pauses the currently run method
        /// </summary>
        void PauseRun();

        /// <summary>
        /// Resumes method execution
        /// </summary>
        void ResumeRun();

        /// <summary>
        /// Stops the method
        /// </summary>
        void StopMethod();

        /// <summary>
        /// Finishes the execution of the current method
        /// </summary>
        void FinishExecution();

        /// <summary>
        /// Closes the current method
        /// </summary>
        void CloseMethod();

        /// <summary>
        /// Sets the value of the given variable
        /// </summary>
        /// <param name="variableName">the name of the variable</param>
        /// <param name="value">the new value of the variable</param>
        void SetVariableValue(string variableName, string value);

        /// <summary>
        /// Gets a collection of variable names for the current method
        /// </summary>
        /// <returns>A collection of variable names</returns>
        ICollection<string> GetVariableNames();

        /// <summary>
        /// Gets the value of the provided variable
        /// </summary>
        /// <param name="variableName">the name of the variable</param>
        /// <returns>the current value of this variable</returns>
        string GetVariableValue(string variableName);

        /// <summary>
        /// Gets a collection of runnable methods
        /// </summary>
        /// <returns>a collection of runnable methods</returns>
        ICollection<string> GetAllRunnableMethods();

        /// <summary>
        /// Shuts down FluentControl
        /// </summary>
        /// <param name="timeout">a timeout in seconds</param>
        void Shutdown(int timeout);
    }

    /// <summary>
    /// Denotes that an error occurred while executing a script
    /// </summary>
    public class RuntimeException : Exception
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="message">The error message</param>
        public RuntimeException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// Denotes the error that no execution channel has been opened
    /// </summary>
    public class NoExecutionChannelException : Exception
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="message">the error message</param>
        public NoExecutionChannelException (string message) : base(message)
        {
        }
    }
}
