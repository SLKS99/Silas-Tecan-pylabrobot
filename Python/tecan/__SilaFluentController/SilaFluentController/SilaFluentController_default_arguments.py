# This file contains default values that are used for the implementations to supply them with 
#   working, albeit mostly useless arguments.
#   You can also use this file as an example to create your custom responses. Feel free to remove
#   Once you have replaced every occurrence of the defaults with more reasonable values.
#   Or you continue using this file, supplying good defaults..

# import the required packages
import sila2lib.framework.SiLAFramework_pb2 as silaFW_pb2
import sila2lib.framework.SiLABinaryTransfer_pb2 as silaBinary_pb2
from .gRPC import SilaFluentController_pb2 as pb2

# initialise the default dictionary so we can add keys. 
#   We need to do this separately/add keys separately, so we can access keys already defined e.g.
#   for the use in data type identifiers
default_dict = dict()


default_dict['AddLabware_Parameters'] = {
    'Barcode': silaFW_pb2.String(value='default string'),
    'HasLid': silaFW_pb2.Boolean(value=False),
    'LabwareName': silaFW_pb2.String(value='default string'),
    'LabwareType': silaFW_pb2.String(value='default string'),
    'TargetLocation': silaFW_pb2.String(value='default string'),
    'Position': silaFW_pb2.Integer(value=0),
    'Rotation': silaFW_pb2.Integer(value=0)
}

default_dict['AddLabware_Responses'] = {
    
}

default_dict['RemoveLabware_Parameters'] = {
    'LabwareName': silaFW_pb2.String(value='default string')
}

default_dict['RemoveLabware_Responses'] = {
    
}

default_dict['SetLocation_Parameters'] = {
    'Labware': silaFW_pb2.String(value='default string'),
    'Rotation': silaFW_pb2.Integer(value=0),
    'TargetLocation': silaFW_pb2.String(value='default string'),
    'TargetSite': silaFW_pb2.Integer(value=0)
}

default_dict['SetLocation_Responses'] = {
    
}

default_dict['Subroutine_Parameters'] = {
    'SubroutineName': silaFW_pb2.String(value='default string')
}

default_dict['Subroutine_Responses'] = {
    
}

default_dict['TransferLabware_Parameters'] = {
    'LabwareToLocation': silaFW_pb2.String(value='default string'),
    'OnlyUseSelectedSite': silaFW_pb2.Boolean(value=False),
    'TargetLocation': silaFW_pb2.String(value='default string'),
    'TargetPosition': silaFW_pb2.Integer(value=0)
}

default_dict['TransferLabware_Responses'] = {
    
}

default_dict['TransferLabwareBackToBase_Parameters'] = {
    'LabwareName': silaFW_pb2.String(value='default string')
}

default_dict['TransferLabwareBackToBase_Responses'] = {
    
}

default_dict['GenericCommand_Parameters'] = {
    'Content': silaFW_pb2.String(value='default string')
}

default_dict['GenericCommand_Responses'] = {
    
}

default_dict['GetFingers_Parameters'] = {
    'DeviceAlias': silaFW_pb2.String(value='default string'),
    'GripperFingers': silaFW_pb2.String(value='default string')
}

default_dict['GetFingers_Responses'] = {
    
}

default_dict['DropFingers_Parameters'] = {
    'DeviceAlias': silaFW_pb2.String(value='default string'),
    'DockingStation': silaFW_pb2.String(value='default string')
}

default_dict['DropFingers_Responses'] = {
    
}

default_dict['UserPrompt_Parameters'] = {
    'Text': silaFW_pb2.String(value='default string')
}

default_dict['UserPrompt_Responses'] = {
    
}

default_dict['GetTips_Parameters'] = {
    'AirgapVolume': silaFW_pb2.Integer(value=0),
    'AirgapSpeed': silaFW_pb2.Integer(value=0),
    'DiTiType': silaFW_pb2.String(value='default string')
}

default_dict['GetTips_Responses'] = {
    
}

default_dict['Aspirate_Parameters'] = {
    'Volume': silaFW_pb2.Integer(value=0),
    'Labware': silaFW_pb2.String(value='default string'),
    'LiquidClass': silaFW_pb2.String(value='default string'),
    'WellOffset': silaFW_pb2.Integer(value=0)
}

default_dict['Aspirate_Responses'] = {
    
}

default_dict['Dispense_Parameters'] = {
    'Volume': silaFW_pb2.Integer(value=0),
    'Labware': silaFW_pb2.String(value='default string'),
    'LiquidClass': silaFW_pb2.String(value='default string'),
    'WellOffset': silaFW_pb2.Integer(value=0)
}

default_dict['Dispense_Responses'] = {
    
}

default_dict['DropTips_Parameters'] = {
    'Labware': silaFW_pb2.String(value='default string')
}

default_dict['DropTips_Responses'] = {
    
}

default_dict['StartFluentOrAttach_Parameters'] = {
    
}

default_dict['StartFluentOrAttach_Responses'] = {
    
}

default_dict['StartFluentAndLogin_Parameters'] = {
    'Username': silaFW_pb2.String(value='default string'),
    'Password': silaFW_pb2.String(value='default string')
}

default_dict['StartFluentAndLogin_Responses'] = {
    
}

default_dict['StartFluentInSimulationMode_Parameters'] = {
    
}

default_dict['StartFluentInSimulationMode_Responses'] = {
    
}

default_dict['PrepareMethod_Parameters'] = {
    'ToPrepare': silaFW_pb2.String(value='default string')
}

default_dict['PrepareMethod_Responses'] = {
    
}

default_dict['RunMethod_Parameters'] = {
    
}

default_dict['RunMethod_Responses'] = {
    
}

default_dict['PauseRun_Parameters'] = {
    
}

default_dict['PauseRun_Responses'] = {
    
}

default_dict['ResumeRun_Parameters'] = {
    
}

default_dict['ResumeRun_Responses'] = {
    
}

default_dict['StopMethod_Parameters'] = {
    
}

default_dict['StopMethod_Responses'] = {
    
}

default_dict['FinishExecution_Parameters'] = {
    
}

default_dict['FinishExecution_Responses'] = {
    
}

default_dict['CloseMethod_Parameters'] = {
    
}

default_dict['CloseMethod_Responses'] = {
    
}

default_dict['SetVariableValue_Parameters'] = {
    'VariableName': silaFW_pb2.String(value='default string'),
    'Value': silaFW_pb2.String(value='default string')
}

default_dict['SetVariableValue_Responses'] = {
    
}

default_dict['GetVariableNames_Parameters'] = {
    
}

default_dict['GetVariableNames_Responses'] = {
    'ReturnValue': [silaFW_pb2.String(value='default string')]
}

default_dict['GetVariableValue_Parameters'] = {
    'VariableName': silaFW_pb2.String(value='default string')
}

default_dict['GetVariableValue_Responses'] = {
    'ReturnValue': silaFW_pb2.String(value='default string')
}

default_dict['GetAllRunnableMethods_Parameters'] = {
    
}

default_dict['GetAllRunnableMethods_Responses'] = {
    'ReturnValue': [silaFW_pb2.String(value='default string')]
}

default_dict['Shutdown_Parameters'] = {
    'Timeout': silaFW_pb2.Integer(value=0)
}

default_dict['Shutdown_Responses'] = {
    
}


