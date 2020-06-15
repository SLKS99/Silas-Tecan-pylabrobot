using Contracts;
using ComplexCommands;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading;
using Tecan.VisionX.API.V2;
using Tecan.VisionX.API.V2.Commands;
using Tecan.VisionX.API.V2.Implementation.Commands;
using System.Linq;
using System.Diagnostics;


namespace Implementation
{
    [Export(typeof(ISilaFluentController))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class SilaFluentController : ISilaFluentController
    {
        private readonly ManualResetEventSlim _waitForRuntimeIsReady = new ManualResetEventSlim(false);
        private readonly ManualResetEventSlim _waitForEditMode = new ManualResetEventSlim(false);
        private RuntimeController runtime;
        private readonly FluentControl _process = new FluentControl();
        private IExecutionChannel _currentExecutionChannel;
        private readonly List<IExecutionChannel> _openExecutionChannels = new List<IExecutionChannel>();

        #region Commands
        public void DropFingers(string deviceAlias, string dockingStation)
        {
            ICommand dropFingers = new DropFingers(dockingStation, deviceAlias);
            TriggerCommand(dropFingers);
        }

        public void GenericCommand(string content)
        {
            ICommand genericCommand = new GenericCommand(content);
            TriggerCommand(genericCommand);
        }

        public void GetFingers(string deviceAlias, string gripperFingers)
        {
            ICommand getFingers = new GetFingers(gripperFingers, deviceAlias);
            TriggerCommand(getFingers);
        }

        public void RemoveLabware(string labwareName)
        {
            IRemoveLabware removeLabware = new RemoveLabware(labwareName);
            TriggerCommand(removeLabware);
        }

        public void SetLocation(string labware, int rotation, string targetLocation, int targetSite)
        {
            ICommand setLocation = new SetLocation(labware, targetLocation, rotation, targetSite);
            TriggerCommand(setLocation);
        }

        public void Subroutine(string subroutineName)
        {
            ICommand subroutine = new Subroutine(subroutineName);
            TriggerCommand(subroutine);
        }

        public void TransferLabware(string labwareToLocation, bool onlyUseSelectedSite, string targetLocation, int targetPosition)
        {
            ICommand transferLabware = new TransferLabware(labwareToLocation, targetLocation, targetPosition, onlyUseSelectedSite);
            TriggerCommand(transferLabware);
        }

        public void TransferLabwareBackToBase(string labwareName)
        {
            ICommand command = new TransferLabware(labwareName);
            TriggerCommand(command);
        }


        public void UserPrompt(string text)
        {
            ICommand userPrompt = new UserPrompt(text);

            TriggerCommand(userPrompt);
         

        }

        public void AddLabware(string barcode, bool hasLid, string labwareName, string labwareType, string targetLocation, int position, int rotation)
        {
            ICommand addLabware = new AddLabware(labwareName, labwareType, targetLocation, rotation, position, barcode, hasLid);
            TriggerCommand(addLabware);
        }

        public void GetTips(int airgapVolume, int airgapSpeed, string diTiType)
        {
            ICommand getTips = new GetTips(airgapVolume, airgapSpeed, diTiType);
            TriggerCommand(getTips);
        }

        public void Aspirate(int volume, string labware, string liquidClass, int wellOffset)
        {
            ICommand aspirate = new Aspirate(volume, labware, liquidClass, wellOffset);
            TriggerCommand(aspirate);
        }

        public void Dispense(int volume, string labware, string liquidClass, int wellOffset)
        {
            ICommand dispense = new Dispense(volume, labware, liquidClass, wellOffset);
            TriggerCommand(dispense);
        }

        public void DropTips(string labware)
        {
            IGenericCommand dropTips = new DropTips(labware);
            TriggerCommand(dropTips);
        }

        public void PrepareMethod(string toPrepare)
        {
            Process.Start("cmd.exe", "/c rd \"C:/ProgramData/Tecan/VisionX/Journaling/000/\" /q /s");
            Process.Start("cmd.exe", "/c rd \"C:/ProgramData/Tecan/VisionX/Journaling/ToDelete/\" /q /s");
            runtime.PrepareMethod(toPrepare);
        }

        public void RunMethod()
        { 
            runtime.RunMethod();
        }

        public void PauseRun()
        {
            runtime.PauseRun();
        }

        public void ResumeRun()
        {
            runtime.ResumeRun();
        }

        public void StopMethod()
        {
            runtime.StopMethod();
        }

        public void CloseMethod()
        {
            runtime.CloseMethod();
        }

        public void SetVariableValue(string variableName, string value)
        {
            runtime.SetVariableValue(variableName, value);
        }

        public ICollection<string> GetVariableNames()
        {
            
            var variables = runtime.GetVariableNames();
            if (variables != null)
            {
               return variables.ToList();
            }

            return null;
        }

        public string GetVariableValue(string variableName)
        {
            return runtime.GetVariableValue(variableName);
        }

        public ICollection<string> GetAllRunnableMethods()
        {
            var methods = runtime.GetAllRunnableMethods();
            if (methods != null)
            {
                return methods.ToList();
            }
            return null;
        }

        public void StartFluentInSimulationMode()
        {
            bool alreadyStarted = _process.IsRunning();
            _process.RuntimeIsAvailable += _process_RuntimeIsAvailable;
            _process.StartInSimulationMode();
            _process.StartOrAttach();


            if (!alreadyStarted)
            {
                _waitForRuntimeIsReady.Wait();
            }

            runtime = (RuntimeController)_process.GetRuntime();
            runtime.ChannelOpens += Runtime_ChannelOpens;
            PrepareMethodRun();
        }

        public void StartFluentAndLogin(string username, string password) {

            bool alreadyStarted = _process.IsRunning();
            _process.RuntimeIsAvailable += _process_RuntimeIsAvailable;
            _process.StartAndLogin(username, password);
            _process.StartOrAttach();

            if (!alreadyStarted)
            {
                _waitForRuntimeIsReady.Wait();
            }

            runtime = (RuntimeController)_process.GetRuntime();
            runtime.ChannelOpens += Runtime_ChannelOpens;
            PrepareMethodRun();

        }

        public void StartFluentOrAttach()
        {

            bool alreadyStarted = _process.IsRunning();
            _process.RuntimeIsAvailable += _process_RuntimeIsAvailable;
            _process.StartOrAttach();

            
            if (!alreadyStarted)
            {
                _waitForRuntimeIsReady.Wait();
            }
            
            runtime = (RuntimeController)_process.GetRuntime();
            runtime.ChannelOpens += Runtime_ChannelOpens;
            PrepareMethodRun();
            
        }

        public void Shutdown(int timeout)
        {
            _process.Shutdown(timeout);
        }

        public void FinishExecution()
        {
            _currentExecutionChannel.FinishExecution();
        }
        #endregion
        #region private_methods
        private void _process_RuntimeIsAvailable()
        {
            _waitForRuntimeIsReady.Set();
        }

        private void Runtime_ChannelOpens(IExecutionChannel openedChannel)
        {
            _currentExecutionChannel = openedChannel;
            _openExecutionChannels.Add(openedChannel);
        }

        private void TriggerCommand(ICommand command)
        {
            if(_currentExecutionChannel != null && _currentExecutionChannel.IsAlive)
            {
                try
                {
                    _currentExecutionChannel.ExecuteCommand(command);
                }
                catch (FluentRuntimeException e)
                {
                    throw new RuntimeException(e.Message);
                }
                 
            }
            else
            {
                throw new NoExecutionChannelException("There is no execution channel available");
            }
        }

        private void CloseRuntimeChannel() 
        {
            _openExecutionChannels.Remove(_currentExecutionChannel);
            _currentExecutionChannel.FinishExecution();
            _currentExecutionChannel = _openExecutionChannels[0];
        }

        private void PrepareMethodRun() 
        {
            runtime = (RuntimeController)_process.GetRuntime();
            runtime.ModeChanged += Runtime_ModeChanged;
            if (runtime.GetFluentStatus() != StateMachineStates.EditMode)
            {
                _waitForEditMode.Wait();
            }
            runtime.PrepareMethod("Method to prepare");
        }

        private void Runtime_ModeChanged(StateMachineStates old, StateMachineStates current)
        {
            if (current == StateMachineStates.EditMode)
            {
                _waitForEditMode.Set();
            }
        }
        #endregion
    }
}
