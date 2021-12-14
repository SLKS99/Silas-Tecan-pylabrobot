using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecan.VisionX.API.V2.Commands;

namespace Tecan.VisionX.Sila2
{
    public class DropTips : IGenericCommand
    {
        private string _labware;

        public DropTips(string labware)
        {
            _labware = labware;
        }

        public string Content { get; set; }

        public string ToXML()
        {
            return $@"<ScriptGroup>
                        <Objects>
                            <Object Type=""Tecan.Core.Instrument.Devices.LiHa.Scripting.LihaDropTipsScriptCommandDataV1"">
                                <LihaDropTipsScriptCommandDataV1>
                                    <Data Type=""Tecan.Core.Instrument.Devices.LiHa.Scripting.LiHaScriptCommandUsingTipSelectionBaseDataV1"">
                                        <LiHaScriptCommandUsingTipSelectionBaseDataV1>
                                            <SerializedTipsIndexes></SerializedTipsIndexes>
                                            <SelectedTipsIndexes>
                                                <Object Type=""System.Int32"">
                                                    <int>0</int>
                                                </Object>
                                                <Object Type=""System.Int32"">
                                                    <int>1</int>
                                                </Object>
                                                <Object Type=""System.Int32"">
                                                    <int>2</int>
                                                </Object>
                                                <Object Type=""System.Int32"">
                                                    <int>3</int>
                                                </Object>
                                                <Object Type=""System.Int32"">
                                                    <int>4</int>
                                                </Object>
                                                <Object Type=""System.Int32"">
                                                    <int>5</int>
                                                </Object>
                                                <Object Type=""System.Int32"">
                                                    <int>6</int>
                                                </Object>
                                                <Object Type=""System.Int32"">
                                                    <int>7</int>
                                                </Object>
                                            </SelectedTipsIndexes>
                                            <TipMask></TipMask>
                                            <TipOffset>0</TipOffset>
                                            <TipSpacing>9</TipSpacing>
                                            <Data Type=""Tecan.Core.Instrument.Devices.LiHa.Scripting.LihaScriptCommandDataV1"">
                                                <LihaScriptCommandDataV1>
                                                    <Data Type=""Tecan.Core.Instrument.Helpers.Scripting.ScriptCommandCommonDataV1"">
                                                        <ScriptCommandCommonDataV1>
                                                            <LabwareName>{_labware}</LabwareName>
                                                            <Data Type=""Tecan.Core.Instrument.Helpers.Scripting.DeviceAliasStatementBaseDataV1"">
                                                                <DeviceAliasStatementBaseDataV1>
                                                                    <Alias Type=""Tecan.Core.Instrument.DeviceAlias.DeviceAlias"">
                                                                        <DeviceAlias>Instrument=1/Device=LIHA:1</DeviceAlias>
                                                                    </Alias>
                                                                    <ID>
                                                                        <AvailableID>USB:TECAN,MYRIUS,1310005667/LIHA:1</AvailableID>
                                                                    </ID>
                                                                    <Data Type=""Tecan.Core.Scripting.Helpers.ScriptStatementBaseDataV1"">
                                                                        <ScriptStatementBaseDataV1>
                                                                            <IsBreakpoint>False</IsBreakpoint>
                                                                            <IsDisabledForExecution>False</IsDisabledForExecution>
                                                                            <GroupLineNumber>0</GroupLineNumber>
                                                                            <LineNumber>2</LineNumber>
                                                                        </ScriptStatementBaseDataV1>
                                                                    </Data>
                                                                </DeviceAliasStatementBaseDataV1>
                                                            </Data>
                                                        </ScriptCommandCommonDataV1>
                                                    </Data>
                                                </LihaScriptCommandDataV1>
                                            </Data>
                                        </LiHaScriptCommandUsingTipSelectionBaseDataV1>
                                    </Data>
                                </LihaDropTipsScriptCommandDataV1>
                            </Object>
                        </Objects>
                        <Name></Name>
                        <IsBreakpoint>False</IsBreakpoint>
                        <IsDisabledForExecution>False</IsDisabledForExecution>
                        <LineNumber>0</LineNumber>
                    </ScriptGroup>";
        }

        public void Validate()
        {
            
        }
    }
}
