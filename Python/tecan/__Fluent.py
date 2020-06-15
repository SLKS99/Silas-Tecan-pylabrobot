"""
Wrapper for the SiLAFluentController.
"""

import logging
from enum import Enum
from sila2lib.framework import SiLAFramework_pb2 as silaFW_pb2
from sila2lib.sila_service_detection import SiLA2ServiceDetection
from .__SilaFluentController.SilaFluentController_client import SilaFluentControllerClient
from .__SilaFluentController.SilaFluentController.gRPC import SilaFluentController_pb2
from .__SilaFluentController.SilaFluentController.gRPC import SilaFluentController_pb2_grpc

logger = logging.getLogger(__name__)

class Fluent():
    """
    Python wrapper to remote Fluent.
    """
    __FORMAT = '%(asctime)-15s %(message)s'


    

    def __init__(self, server_ip : str, server_port : int):
        """Connects to a SilaFluentServer an creates a Fluent object able to controll an instance of FluentControl.
        :param server_ip: 
        :type server_ip: str
        :param server_port: 
        :type server_port: int
        """
        import sys

       # logging.root.addHandler(sys.stdout)
        logging.basicConfig(level=logging.INFO, format=Fluent.__FORMAT)
        self.__client = SilaFluentControllerClient(server_ip = server_ip, server_port = server_port)
        logger.info("successfully connected to the server")
 

    def add_labware(self, labware_name : str, labware_type : str, target_location : str, position = 0, rotation=0, has_lid=False, barcode=""):
        """adds labware to the worktable
        :param barcode: 
        :type barcode: str
        :param labware_name: 
        :type labware_name: str
        :param labware_type: 
        :type labware_type: str
        :param target_location: labware-name of the target
        :type target_location: str
        :param position: defaults to 0
        :type position: int, optional
        :param rotation: defaults to 0
        :type rotation: int, optional
        :param has_lid: defaults to False
        :type has_lid: bool, optional
        """
        parameters = SilaFluentController_pb2.AddLabware_Parameters(Barcode=silaFW_pb2.String(value=barcode),
                                                                    HasLid=silaFW_pb2.Boolean(value=has_lid),
                                                                    LabwareName=silaFW_pb2.String(value=labware_name),
                                                                    LabwareType=silaFW_pb2.String(value=labware_type),
                                                                    TargetLocation=silaFW_pb2.String(value=target_location),
                                                                    Position=silaFW_pb2.Integer(value=position),
                                                                    Rotation=silaFW_pb2.Integer(value=rotation))

        if self.__client.AddLabware(parameters) is None:
            logger.warning("Labware could not be added")
 
        else:
            logger.info("Labware added successfully")

        
      

    def remove_labware(self, labware_name : str):
        """removes labware from worktable
        :param labware_name: name of labware to remove
        :type labware_name: str
        """
        parameters = SilaFluentController_pb2.RemoveLabware_Parameters(LabwareName=silaFW_pb2.String(value=labware_name))

        if self.__client.RemoveLabware(parameters) is None:
            logger.warning("Labware could not be removed")
        else:
            logger.info("Labware removed successfully")

    def set_location(self, labware : str, rotation : int, target_location : str, target_site : int):
        """
        :param labware: name of the labware
        :type labware: str
        :param rotation: 
        :type rotation: int
        :param target_location: 
        :type target_location: str
        :param target_site: 
        :type target_site: int
        """
        parameters = SilaFluentController_pb2.SetLocation_Parameters(Labware=silaFW_pb2.String(value=labware),
                                                                     Rotation=silaFW_pb2.Integer(value=rotation),
                                                                     TargetLocation=silaFW_pb2.String(value=target_location),
                                                                     TargetSite=silaFW_pb2.Integer(value=target_site))
        if self.__client.SetLocation(parameters) is None:
            logger.warning("Location could not be set")
        else:
            logger.info("Location successfully set")

    def transfer_labware(self, labware_to_location : str, target_location : str, target_position=0, only_use_selected_site=True):
        """transfers labware on the worktable.
        :param labware_to_location: 
        :type labware_to_location: str
        :param target_location: 
        :type target_location: str
        :param target_position: defaults to 0
        :type target_position: int, optional
        :param only_use_selected_site: , defaults to True
        :type only_use_selected_site: bool, optional
        """
        
        parameters = SilaFluentController_pb2.TransferLabware_Parameters(LabwareToLocation=silaFW_pb2.String(value=labware_to_location),
                                                                         OnlyUseSelectedSite=silaFW_pb2.Boolean(value=only_use_selected_site),
                                                                         TargetLocation=silaFW_pb2.String(value=target_location),
                                                                         TargetPosition=silaFW_pb2.Integer(value=target_position))
        logger.info("transferring labware")
        self.__client.TransferLabware(parameters)
        logger.info("labware successfully transferred")

    def transfer_labware_back_to_base(self, labware_name : str):
        """transfers labware back to the spot where it was added to the worktable.
        :param labware_name: 
        :type labware_name: str
        """
        parameters = SilaFluentController_pb2.TransferLabwareBackToBase_Parameters(LabwareName=silaFW_pb2.String(value=labware_name))
        logger.info("transferring labware")
        self.__client.TransferLabwareBackToBase(parameters)
        logger.info("labware successfully transferred")

    def get_fingers(self, device_alias : str, gripper_fingers : str):
        """
        :param device_alias: 
        :type device_alias: str
        :param gripper_fingers: 
        :type gripper_fingers: str
        """
        parameters = SilaFluentController_pb2.GetFingers_Parameters(DeviceAlias=silaFW_pb2.String(value=device_alias),
                                                                    GripperFingers=silaFW_pb2.String(value=gripper_fingers))
        self.__client.GetFingers(parameters)

    def user_prompt(self, text : str):
        """
        :param text: 
        :type text: str
        """
        parameters = SilaFluentController_pb2.UserPrompt_Parameters(Text=silaFW_pb2.String(value=text))
        self.__client.UserPrompt(parameters)
        
    def get_tips(self, airgap_volume : int, airgap_speed : int , diti_type):
        """
        :param airgap_volume:
        :type airgap_volume: int
        :param airgap_speed: 
        :type airgap_speed: int
        :param diti_type: 
        :type diti_type: DiTi
        """
        parameters = SilaFluentController_pb2.GetTips_Parameters(AirgapVolume=silaFW_pb2.Integer(value=airgap_volume),
                                                                 AirgapSpeed=silaFW_pb2.Integer(value=airgap_speed),
                                                                 DiTiType=silaFW_pb2.String(value=diti_type.value))
        logger.info("executing...")
        self.__client.GetTips(parameters)
        logger.info("done")

    def aspirate(self, volume : int, labware: str, liquid_class : str , well_offset = 0):
        """
        :param volume: 
        :type volume: int
        :param labware: 
        :type labware: str
        :param liquid_class: 
        :type liquid_class: str
        :param well_offset: , defaults to 0
        :type well_offset: int, optional
        """
        parameters = SilaFluentController_pb2.Aspirate_Parameters(Volume=silaFW_pb2.Integer(value=volume),
                                                                  Labware=silaFW_pb2.String(value=labware),
                                                                  LiquidClass=silaFW_pb2.String(value=liquid_class),
                                                                  WellOffset=silaFW_pb2.Integer(value=well_offset))
        logger.info("aspirating...")                                                          
        self.__client.Aspirate(parameters)
        logger.info("finished aspirating")

    def dispense(self, volume : int, labware : str, liquid_class : str, well_offset=0):
        """
        :param volume: 
        :type volume: int
        :param labware: 
        :type labware: str
        :param liquid_class: 
        :type liquid_class: str
        :param well_offset: , defaults to 0
        :type well_offset: int, optional
        """
        parameters = SilaFluentController_pb2.Dispense_Parameters(Volume=silaFW_pb2.Integer(value=volume),
                                                                  Labware=silaFW_pb2.String(value=labware),
                                                                  LiquidClass=silaFW_pb2.String(value=liquid_class),
                                                                  WellOffset=silaFW_pb2.Integer(value=well_offset))
        logger.info("dispensing...")
        self.__client.Dispense(parameters)
        logger.info("finished dispensing")

    def drop_tips(self, labware : str):
        """
        :param labware: 
        :type labware: str
        """
        parameters = SilaFluentController_pb2.DropTips_Parameters(Labware=silaFW_pb2.String(value=labware))
        logger.info("dropping tips...")
        self.__client.DropTips(parameters)
        logger.info("dropped")

    def prepare_method(self, to_prepare : str):
        """Prepare a method so that you can run it later.
        :param to_prepare: 
        :type to_prepare: str
        """
        parameters = SilaFluentController_pb2.PrepareMethod_Parameters(ToPrepare=silaFW_pb2.String(value=to_prepare))
        logger.info("preparing method...")
        self.__client.PrepareMethod(parameters)
        """
        variables = self.get_variable_names()
        for name in variables:
            globals()[name] = VariableContainer(self.__client, name)
        """
        logger.info("method ready to run")


    def run_method(self):
        """Runs a method. you have to prepare it first by prepare_method().
        """
        self.__client.RunMethod()
        """
        variables = self.get_variable_names()
        for name in variables:
            globals()[name].__setattr__(name, self.get_variable_value(name))
        """
        logger.info("method running")

    def pause_run(self):
        """Pauses a method run.
        """
        self.__client.PauseRun()

    def resume_run(self):
        """Resumes a method run that was paused before.
        """
        self.__client.ResumeRun()
        logger.info("method paused")

    def stop_method(self):
        """Stops a method run. For a soft stop better use finish_execution().
        """
        self.__client.StopMethod()
        logger.info("method stopped") 

    def close_method(self):
        """closes a method.
        """
        self.__client.CloseMethod()
        logger.info("method closed")

    def set_variable_value(self, variable_name : str, value : str):
        """
        :param variable_name: 
        :type variable_name: str
        :param value: 
        :type value: str
        """
        parameters = SilaFluentController_pb2.SetVariableValue_Parameters(VariableName=silaFW_pb2.String(value=variable_name),
                                                                          Value=silaFW_pb2.String(value=value))
        if self.__client.SetVariableValue(parameters) is None:
            logger.warning("Value could not be set")
        else:
            logger.info("Value successfully set")

    def get_variable_names(self) -> list:
        """
        only works if you have a method prepared but not yet running
        :return: 
        :rtype: str
        """
        variables = []

        for variable in self.__client.GetVariableNames().ReturnValue:  # TODO find better solution to get list of strings
            variables.append(str(variable)[8:-2])

        return variables

    def get_variable_value(self, variable_name : str) -> str:
        """
        :param variable_name: 
        :type variable_name: str
        :return: 
        :rtype: str
        """
        parameters = SilaFluentController_pb2.GetVariableValue_Parameters(VariableName=silaFW_pb2.String(value=variable_name))
        return str(self.__client.GetVariableValue(parameters).ReturnValue)[8:-2]

    def get_all_runnable_methods(self):
        """returns a list of all methods that are executable from python. can only show methods, that are visible in touchtools.
        :return: 
        :rtype: list
        """
        methods = []

        for method in self.__client.GetAllRunnableMethods().ReturnValue:  # TODO find better solution to get list of strings
            methods.append(str(method)[8:-2])

        return methods

    def finish_execution(self):
        """Stops a method run softly. Best practice to end a method run containing an API-channel.
        """
        self.__client.FinishExecution()
        logger.info("successfully finished execution.")

    def start_fluent(self, username : str = None, password : str = None, simulation_mode = False):
        """Starts Fluent Controll or attaches to a running instance.
        :param username: Your Fluent USM username. When set, password has to be set as well., defaults to None
        :type username: str, optional
        :param password: Set only, when Username is set, defaults to None
        :type password: str, optional
        :param simulation_mode: Starts Fluent in simulation mode when set True, defaults to False
        :type simulation_mode: bool, optional
        :raises AttributeError: Raised if only one of username or password was set.
        """
        
        if username is None:
            if password is not None:
                raise AttributeError("username missing")
            logger.info("starting Fluent...")
            if simulation_mode:
                self.__client.StartFluentInSimulationMode()
            else:
                self.__client.StartFluentOrAttach()
            logger.info("started")
        elif password is None:
            raise AttributeError("password missing")
        else:
            parameters = SilaFluentController_pb2.StartFluentAndLogin_Parameters(Username = silaFW_pb2.String(value=username),
                                                                                 Password = silaFW_pb2.String(value=password))
            logger.info("starting Fluent...")
            self.__client.StartFluentAndLogin(parameters) 
            logger.info("started!")                                                                    

    def shutdown(self, timeout : int):
        """Shuts down a running FluentControl instance.
        
        :param timeout: [description]
        :type timeout: int
        """
        parameters = SilaFluentController_pb2.Shutdown_Parameters(Timeout = silaFW_pb2.Integer(value=timeout))
        self.__client.Shutdown(parameters)

    def discover(self):
        """Not implemented yet. Shall be able to find running servers in your network.
        """
        detector = SiLA2ServiceDetection()
        detector.registerService(service_name="PythonClient")

class VariableContainer():
    variables = {}

    def __init__(self, client, name : str):
        self.client = client
        self.name = name
        self.value = None

    def __getattr__(self, name):

        return self.value

    def __setattr__(self, name, value = None):
        if value is not None:
            parameters = SilaFluentController_pb2.SetVariableValue_Parameters(VariableName=silaFW_pb2.String(value=name),
                                                                          Value=silaFW_pb2.String(value=value))
            if self.client.SetVariableValue(parameters) is None:
                logger.info("fail")
        else:
            self.value = value
  
    def __dir__(self):
        return super().__dir__()

class DiTi(Enum):
    """
    Enum for DiTi types
    """
    FCA_200_UL_FILTERED_SBS = "TOOLTYPE:LiHa.TecanDiTi/TOOLNAME:FCA, 200ul Filtered SBS"
    FCA_5000_UL_FLIERED_SBS = "TOOLTYPE:LiHa.TecanDiTi/TOOLNAME:FCA, 5000ul Filtered SBS"
