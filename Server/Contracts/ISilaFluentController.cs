using System;
using System.Collections.Generic;
using Tecan.Sila2;


namespace Contracts
{
    [SilaFeature]
    [SilaDescription("A service to send Commands to Fluent")]
    [SilaDisplayName("Fluent Service")]
    public interface ISilaFluentController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="barcode"></param>
        /// <param name="hasLid"></param>
        /// <param name="labwareName"></param>
        /// <param name="labwareType"></param>
        /// <param name="targetLocation"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        [SilaDescription("...")]
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void AddLabware(string barcode, bool hasLid, string labwareName, string labwareType, string targetLocation, int position, int rotation);

        [SilaDescription("Removes Labware from the worktable")]
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void RemoveLabware(string labwareName);

        [SilaDescription("...")]
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void SetLocation(string labware, int rotation, string targetLocation, int targetSite);

        [SilaDescription("...")]
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void Subroutine(string subroutineName);

        [SilaDescription("...")]
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void TransferLabware(string labwareToLocation, bool onlyUseSelectedSite, string targetLocation, int targetPosition);

        [SilaDescription("...")]
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void TransferLabwareBackToBase(string labwareName);

        [SilaDescription("...")]
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void GenericCommand(string content);

        [SilaDescription("...")]
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void GetFingers(string deviceAlias, string gripperFingers);

        [SilaDescription("...")]
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void DropFingers(string deviceAlias, string dockingStation);

        [SilaDescription("...")]
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void UserPrompt(string text);

        [SilaDescription("...")]
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void GetTips(int airgapVolume, int airgapSpeed, string diTiType); 

        [SilaDescription("...")]
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void Aspirate(int volume, string labware, string liquidClass, int wellOffset);

        [SilaDescription("...")]
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void Dispense(int volume, string labware, string liquidClass, int wellOffset);

        [SilaDescription("...")]
        [Throws(typeof(NoExecutionChannelException))]
        [Throws(typeof(RuntimeException))]
        void DropTips(string labware);

        [SilaDescription("Starts Fluent or connects to an instance already running")]
        void StartFluentOrAttach();

        [SilaDescription("Starts Fluent or connects to an instance already running")]
        void StartFluentAndLogin(string username, string password);

        [SilaDescription("Starts Fluent or connects to an instance already running")]
        void StartFluentInSimulationMode();

        [SilaDescription("...")]
        void PrepareMethod(string toPrepare);

        [SilaDescription("...")]
        void RunMethod();

        [SilaDescription("...")]
        void PauseRun();

        [SilaDescription("...")]
        void ResumeRun();

        [SilaDescription("...")]
        void StopMethod();

        [SilaDescription("...")]
        void FinishExecution();

        [SilaDescription("...")]
        void CloseMethod();

        [SilaDescription("...")]
        void SetVariableValue(string variableName, string value);

        [SilaDescription("...")]
        ICollection<string> GetVariableNames();

        [SilaDescription("...")]
        string GetVariableValue(string variableName);

        [SilaDescription("...")]
        ICollection<string> GetAllRunnableMethods();

        [SilaDescription("...")]
        void Shutdown(int timeout);
    }

    public class RuntimeException : Exception
    {
        public RuntimeException(string message) : base(message)
        {
        }
    }

    public class NoExecutionChannelException : Exception
    {
        public NoExecutionChannelException (string message) : base(message)
        {
        }
    }
}
