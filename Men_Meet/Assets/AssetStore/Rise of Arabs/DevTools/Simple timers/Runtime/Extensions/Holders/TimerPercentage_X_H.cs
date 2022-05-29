using UnityEngine;
using UnityEngine.Events;

namespace RiseOfArabs.DevTools.SimpleTimers.Extensions // Done
{
    [AddComponentMenu(ATimer_H.TimersPath + nameof(TimerPercentage_X_H))]
    [RequireComponent(typeof(CooldownTimer_H))]
    [DisallowMultipleComponent]
    public class TimerPercentage_X_H : ATimer_X_H<CooldownTimer_H>
    {
        #region Info
        /// <summary>Runs every frame and returns the percentage of the current time of the timer as 0-1</summary>
        [Tooltip("Runs every frame and returns the percentage of the current time of the timer as 0-1")]
        public UnityEvent<float> CurrentTimePercentage;
        
        /// <summary>Runs every frame and returns the percentage of the current time of the timer as 0-100</summary>
        [Tooltip("Runs every frame and returns the percentage of the current time of the timer as 0-100")]
        public UnityEvent<string> CurrentTime100Percentage;

        /// <summary>Runs every fram and returns the color that represents the timer percentage based on gradient colors</summary>
        [Tooltip("Runs every fram and returns the color that represents the timer percentage based on gradient colors")]
        public UnityEvent<Color> CurrentPercentageColor;
        /// <summary>The gradient color difference from 0 to 1 will be used in the event CurrentPercentageColor</summary>
        [Tooltip("The gradient color difference from 0 to 1 will be used in the event CurrentPercentageColor")]
        public Gradient gradient;
        #endregion

        #region Other
        protected override void TypedUpdate()
        {
            float _percentage = ((CooldownTimer)timer_H.Timer).CurrentTimePercentage;
            CurrentTimePercentage?.Invoke(_percentage);
            CurrentTime100Percentage?.Invoke(((int)(_percentage * 100)).ToString() + "%");
            CurrentPercentageColor?.Invoke(gradient.Evaluate(_percentage));
        }
        #endregion
    }
}