using UnityEngine;
using UnityEngine.Events;

namespace RiseOfArabs.DevTools.SimpleTimers.Extensions // Done
{
    [AddComponentMenu(ATimer_H.TimersPath + nameof(TimerText_X_H))]
    [RequireComponent(typeof(ATimer_H))]
    [DisallowMultipleComponent]
    public class TimerText_X_H : ATimer_X_H<ATimer_H>
    {
        #region Info
        /// <summary>Declares how many digits clock timer format should hold</summary>
        [Tooltip("Declares how many digits clock timer format should hold")]
        public Time_Ts clockMaxType;

        /// <summary>Digits wanted in the current time text displayed by the event CurrentTime</summary>
        [Tooltip("Digits wanted in the current time text displayed by the event CurrentTime")]
        public string textFormat;
        /// <summary>Runs every frame, displays the timer current time as textFormat format</summary>
        [Tooltip("Runs every frame, displays the timer current time as textFormat format")]
        public UnityEvent<string> CurrentTime;
        /// <summary>Runs every frame, displays the timer current time as clock timer format</summary>
        [Tooltip("Runs every frame, displays the timer current time as clock timer format")]
        public UnityEvent<string> ClockCurrentTime;

        private float Time => timer_H.Timer.CurrentTime;
        #endregion

        #region Main
        protected override void TypedUpdate()
        {
            CurrentTime?.Invoke(Time.ToString(textFormat));
            ClockCurrentTime?.Invoke(Time.ClockTimer(clockMaxType));
        }
        #endregion
    }
}