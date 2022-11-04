namespace Data
{
    using System;

    [DoNotObfuscate]
    public enum DataloggingState
    {
        Connected,
        Link,
        Disconnected,
        Recording,
        PlayingF,
        PlayingR,
        Pause,
        Stop,
        Waiting,
        Timeout,
        Loading,
        Connecting
    }
}

