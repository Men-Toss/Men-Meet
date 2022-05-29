using RiseOfArabs.DevTools.SimpleTimers.Extensions;
using UnityEngine;

namespace RiseOfArabs.DevTools.SimpleTimers
{
    public enum TimerPlaysOn { None, Awake, OnEnable, Start }
    [DisallowMultipleComponent]
    public abstract class ATimer_H : UpdatedClass
    {
        #region Info
        public const string TimersPath = "Rise of Arabs/DevTools/Simple timers/";

        [Header("Setup")]
        [Tooltip("The method the timer will start on")]
        public TimerPlaysOn playOn;
        [Tooltip("the time will be waited before starting the timer for the first time"), Min(0)]
        public float delay;

        /// <summary>
        /// The struct timer held by this timer holder 
        /// </summary>
        public abstract ITimer Timer { get; }
        public TimerEvents_1 currentTime;
        public TimerEvents_2 start_restart_stop;
        public TimerEvents_3 pause_resume;
        #endregion

        #region Main
        protected virtual void Awake()
        {
            Subscribe();
            CheckStartTimer(TimerPlaysOn.Awake);
        }
        protected virtual void OnEnable() => CheckStartTimer(TimerPlaysOn.OnEnable);
        protected virtual void Start() => CheckStartTimer(TimerPlaysOn.Start);
        protected override void TypedUpdate() => currentTime.CurrentTime?.Invoke(Timer.CurrentTime);
        #endregion

        #region Other
        protected virtual void CheckStartTimer(TimerPlaysOn _on)
        {
            if (playOn == _on)
                Invoke(nameof(StartTimer), delay);
        }

        public virtual void StartTimer() => start_restart_stop.Started?.Invoke();
        public virtual void RestartTimer() => start_restart_stop.Restarted?.Invoke();
        public virtual void StopTimer() => start_restart_stop.Stoped?.Invoke();
        public virtual void PauseTimer() => pause_resume.Paused?.Invoke();
        public virtual void ResumeTimer() => pause_resume.Resumed?.Invoke();
        #endregion
    }
}