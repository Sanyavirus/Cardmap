using System;

namespace SmartHouseTest.StateMachine
{
    public enum MachineStates
    {
        Initialize,
        Connected,
        Authorized,
        DeviceListRecieved    
    }
}