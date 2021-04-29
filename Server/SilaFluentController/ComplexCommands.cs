using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecan.VisionX.API.V2.Commands;

namespace Tecan.VisionX.Sila2
{
    public class GetTips : IGenericCommand
    {
        private int _airgapVolume;
        private int _airgapSpeed;
        private string _ditiType;

        public GetTips(int airgapVolume, int airgapSpeed, string diTiType)
        {
            _airgapVolume = airgapVolume;
            _airgapSpeed = airgapSpeed;
            _ditiType = diTiType;
        }

        public string Content { get; set; }


        public string ToXML()
        {
            return $@"<ScriptGroup>
                        <Objects>
                            <Object Type=""Tecan.Core.Instrument.Devices.LiHa.Scripting.LihaGetTipsScriptCommandDataV3"">
                                <LihaGetTipsScriptCommandDataV3>
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
                                                            <LabwareName></LabwareName>
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
                                                                            <LineNumber>1</LineNumber>
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
                                    <AirgapVolume>{_airgapVolume}</AirgapVolume>
                                    <AirgapSpeed>{_airgapSpeed}</AirgapSpeed>
                                    <DitiType>
                                        <AvailableID>{_ditiType}</AvailableID>
                                    </DitiType>
                                    <UseNextPosition>True</UseNextPosition>
                                </LihaGetTipsScriptCommandDataV3>
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

    public class Aspirate : IGenericCommand
    {
        private int _volume;
        private string _labware;
        private string _liquidClass;
        private int _wellOffset;

        public Aspirate(int volume, string labware, string liquidClass, int wellOffset)
        {
            _volume = volume;
            _labware = labware;
            _liquidClass = liquidClass;
            _wellOffset = wellOffset;
        }

        public string Content { get; set; }

        public string ToXML()
        {
            return $@"<ScriptGroup>
                        <Objects>
                            <Object Type=""Tecan.Core.Instrument.Devices.LiHa.Scripting.LihaAspirateScriptCommandDataV5"">
                                <LihaAspirateScriptCommandDataV5>
                                    <IsSwitchContainerSourceEnabled>False</IsSwitchContainerSourceEnabled>
                                    <OffsetX>0</OffsetX>
                                    <OffsetY>0</OffsetY>
                                    <Data Type=""Tecan.Core.Instrument.Devices.Scripting.Data.LihaPipettingWithVolumesScriptCommandDataV6"">
                                        <LihaPipettingWithVolumesScriptCommandDataV6>
                                            <Volumes>
                                                <Object Type=""System.String"">
                                                    <string>{_volume}</string>
                                                </Object>
                                                <Object Type=""System.String"">
                                                    <string>{_volume}</string>
                                                </Object>
                                                <Object Type=""System.String"">
                                                    <string>{_volume}</string>
                                                </Object>
                                                <Object Type=""System.String"">
                                                    <string>{_volume}</string>
                                                </Object>
                                                <Object Type=""System.String"">
                                                    <string>{_volume}</string>
                                                </Object>
                                                <Object Type=""System.String"">
                                                    <string>{_volume}</string>
                                                </Object>
                                                <Object Type=""System.String"">
                                                    <string>{_volume}</string>
                                                </Object>
                                                <Object Type=""System.String"">
                                                    <string>{_volume}</string>
                                                </Object>
                                            </Volumes>
                                            <IsLiquidClassNameByExpressionEnabled>False</IsLiquidClassNameByExpressionEnabled>
                                            <LiquidClassSelectionMode>
                                                <LiquidClassSelectionMode>SingleByName</LiquidClassSelectionMode>
                                            </LiquidClassSelectionMode>
                                            <LiquidClassNameBySelection>{_liquidClass}</LiquidClassNameBySelection>
                                            <LiquidClassNameByExpression></LiquidClassNameByExpression>
                                            <LiquidClassNames />
                                            <Compartment>1</Compartment>
                                            <Data Type=""Tecan.Core.Instrument.Devices.LiHa.Scripting.LihaScriptCommandUsingWellSelectionBaseDataV1"">
                                                <LihaScriptCommandUsingWellSelectionBaseDataV1>
                                                    <SerializedWellIndexes>0;0;0;0;0;0;0;0;</SerializedWellIndexes>
                                                    <SelectedWellsString>8 * A1</SelectedWellsString>
                                                    <WellOffset>{_wellOffset}</WellOffset>
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
                                                </LihaScriptCommandUsingWellSelectionBaseDataV1>
                                            </Data>
                                        </LihaPipettingWithVolumesScriptCommandDataV6>
                                    </Data>
                                </LihaAspirateScriptCommandDataV5>
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

    public class Dispense : IGenericCommand
    {
        private int _volume;
        private string _labware;
        private string _liquidClass;
        private int _wellOffset;


        public Dispense(int volume, string labware, string liquidClass, int wellOffset) 
        {
            _volume = volume;
            _labware = labware;
            _liquidClass = liquidClass;
            _wellOffset = wellOffset;
        }

        public string Content { get; set; }

        public string ToXML()
        {
            return $@"<ScriptGroup>
                        <Objects>
                            <Object Type=""Tecan.Core.Instrument.Devices.LiHa.Scripting.LihaDispenseScriptCommandDataV4"">
                                <LihaDispenseScriptCommandDataV4>
                                    <OffsetX>0</OffsetX>
                                    <OffsetY>0</OffsetY>
                                    <Data Type=""Tecan.Core.Instrument.Devices.Scripting.Data.LihaPipettingWithVolumesScriptCommandDataV6"">
                                        <LihaPipettingWithVolumesScriptCommandDataV6>
                                            <Volumes>
                                                <Object Type=""System.String"">
                                                    <string>{_volume}</string>
                                                </Object>
                                                <Object Type=""System.String"">
                                                    <string>{_volume}</string>
                                                </Object>
                                                <Object Type=""System.String"">
                                                    <string>{_volume}</string>
                                                </Object>
                                                <Object Type=""System.String"">
                                                    <string>{_volume}</string>
                                                </Object>
                                                <Object Type=""System.String"">
                                                    <string>{_volume}</string>
                                                </Object>
                                                <Object Type=""System.String"">
                                                    <string>{_volume}</string>
                                                </Object>
                                                <Object Type=""System.String"">
                                                    <string>{_volume}</string>
                                                </Object>
                                                <Object Type=""System.String"">
                                                    <string>{_volume}</string>
                                                </Object>
                                            </Volumes>
                                            <IsLiquidClassNameByExpressionEnabled>False</IsLiquidClassNameByExpressionEnabled>
                                            <LiquidClassSelectionMode>
                                                <LiquidClassSelectionMode>SingleByName</LiquidClassSelectionMode>
                                            </LiquidClassSelectionMode>
                                            <LiquidClassNameBySelection>{_liquidClass}</LiquidClassNameBySelection>
                                            <LiquidClassNameByExpression></LiquidClassNameByExpression>
                                            <LiquidClassNames />
                                            <Compartment>1</Compartment>
                                            <Data Type=""Tecan.Core.Instrument.Devices.LiHa.Scripting.LihaScriptCommandUsingWellSelectionBaseDataV1"">
                                                <LihaScriptCommandUsingWellSelectionBaseDataV1>
                                                    <SerializedWellIndexes>0&gt;1&gt;7;</SerializedWellIndexes>
                                                    <SelectedWellsString>A1 - H1</SelectedWellsString>
                                                    <WellOffset>{_wellOffset}</WellOffset>
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
                                                                                            <LineNumber>3</LineNumber>
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
                                                </LihaScriptCommandUsingWellSelectionBaseDataV1>
                                            </Data>
                                        </LihaPipettingWithVolumesScriptCommandDataV6>
                                    </Data>
                                </LihaDispenseScriptCommandDataV4>
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
