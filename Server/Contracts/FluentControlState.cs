using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tecan.VisionX.Sila2
{
    /// <summary>
    /// Denotes the possible Fluent Control States
    /// </summary>
    public enum FluentControlState
    {
        /// <summary>
        /// waiting for elementary system components to be ready
        /// </summary>
        StartUpPhaseLoading,
        /// <summary>
        /// waiting for system to be ready for usage
        /// </summary>
        StartUpPhaseAdditionalLoadingAndUserLogIn,
        /// <summary>
        /// System is ready; user login ok but errors occured when modules are loaded.
        /// </summary>
        StartUpPhaseError,
        /// <summary>
        /// System is ready; all modules are loaded and user login ok
        /// </summary>
        StartUpPhaseSystemReady,
        /// <summary>
        /// Waiting for aborting of loading operations
        /// </summary>
        StartUpPhaseAborting,

        /// <summary>
        /// Generic shutdown state
        /// It contains the whole shutdown sequence
        /// </summary>
        ShutDownShuttingDown,

        /// <summary>
        /// Application is in edit mode
        /// <para>editing of labware, carriers, liquid classes, scripts, processes, 
        /// methods is possible</para>
        /// </summary>
        EditMode,

        /// <summary>
        /// Initilizing run mode; load/create method and do basic checks while entering Run Mode.<para />
        /// Access rights to the method including Approval check are checked.
        /// If recovery is available Recovery will be prepared. 
        /// If recovery data is available for any other method the user will be queried how to proceed:
        /// <list type="bullet">
        /// <item>Keep recovery data and run selected method without recovery support.</item>
        /// <item>Discard existing recovery data and run selected method with recovery support.</item>
        /// <item>Return to Edit Mode</item>
        /// </list>
        /// </summary>
        RunModePreRunChecks,

        /// <summary>
        /// Run mode is active; method was not started yet
        /// <para>settings for run can be modified </para>
        /// </summary>
        RunModePreparingRun,

        /// <summary>
        /// Preparing recovery dialog is open.
        /// </summary>
        RunModePreparingRecovery,

        /// <summary>
        /// The run mode is waiting for system to get ready to start the executing.
        /// Mainly instrument initialization
        /// </summary>
        RunModeWaitingForSystem,

        /// <summary>
        /// QueryVariablesAtStartup dialog is open.
        /// </summary>
        RunModeQueryVariables,

        /// <summary>
        /// Run mode is active; a method is running
        /// </summary>
        RunModeRunning,

        /// <summary>
        /// Run mode is active; a pause was requested
        /// </summary>
        RunModePauseRequested,

        /// <summary>
        /// Run mode is active; method is paused
        /// </summary>
        RunModePaused,

        /// <summary>
        /// Run mode is active; method is halted because of an error
        /// </summary>
        RunModeStopOnError,

        /// <summary>
        /// Run mode is active; Run is finished or aborted
        /// <para>User can look at run details, prepare new run, switch back to edit mode or configuration mode</para>
        /// </summary>
        RunModeRunFinished,


        /// <summary>
        /// Run mode is active; TouchTools displays the Disposable Tips Status screen
        /// </summary>
        RunModeResetTips,

        /// <summary>
        /// Run Mode is active; a run shall be resumed and the system is currently checking preconditions to continue 
        /// (e.g. initializing drivers if needed and Fluent ID resume check (rescanning tube runners) )
        /// </summary>
        RunModeResumeConditionCheck,

        /// <summary>
        /// Run Mode is active; system is preparing to start a run or recovery run.
        /// </summary>
        RunModeBeginRun,

        /// <summary>
        /// System is simulating already executed steps of a Journal in order to recover a Method. <para />
        /// This step will be followed by <see cref="RunModeResumeConditionCheck"/> before the real execution starts and the state will be changed to <see cref="RunModeRunning"/>.
        /// </summary>
        RunModeRecoveryRunning,

        /// <summary>
        /// Fallback state if no other State matches
        /// </summary>
        Unknown

    }
}
