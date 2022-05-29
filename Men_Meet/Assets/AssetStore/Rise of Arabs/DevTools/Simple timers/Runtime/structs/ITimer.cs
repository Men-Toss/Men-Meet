namespace RiseOfArabs.DevTools.SimpleTimers
{
    public interface ITimer
    {
        float CurrentTime { get; }
        bool IsStarted { get; }
        bool IsPaused { get; }

        void Stop();
        void Pause();
        void Resume();
    }
}