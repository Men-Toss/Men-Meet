using System;
using UnityEngine.Events;

namespace RiseOfArabs.DevTools.SimpleTimers
{
    [Serializable]
    public struct TimerEvents_1
    {
        public UnityEvent<float> CurrentTime;
    }
    [Serializable]
    public struct TimerEvents_2
    {
        public UnityEvent Started, Restarted, Stoped;
    }
    [Serializable]
    public struct TimerEvents_3
    {
        public UnityEvent Paused, Resumed;
    }
    [Serializable]
    public struct TimerEvents_4
    {
        public UnityEvent Ready;
    }
}