namespace Data
{
    using System;

    [DoNotObfuscate]
    public enum EmulatorState
    {
        Connected,
        Disconnected,
        Error_detected,
        Downloading_data,
        Sending_data,
        Realtime,
        Connecting
    }
}

