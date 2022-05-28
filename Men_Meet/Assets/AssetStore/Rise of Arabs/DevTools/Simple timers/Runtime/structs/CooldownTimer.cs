using System;
using static UnityEngine.Mathf;

namespace RiseOfArabs.DevTools.SimpleTimers
{
    [Serializable]
    public struct CooldownTimer : ITimer
    {
        #region Info
        /// <summary>
        /// current time of the timer according to the value of the "inverted" bool
        /// </summary>
        public float CurrentTime
        {
            get
            {
                float _t = inverted ? cooldown - timer.CurrentTime : timer.CurrentTime;
                return Clamp(_t, 0, cooldown);
            }
        }

        /// <summary>
        /// current time of the timer as percent from 0 to 1 according to the value of the "inverted" bool
        /// </summary>
        public float CurrentTimePercentage
        {
            get
            {
                float _current = CurrentTime;
                if (cooldown == 0) return _current;
                return Clamp01(_current / cooldown);
            }
        }

        /// <summary>
        /// true if the timer has reached it's limit
        /// </summary>
        public bool IsReady => cooldown != 0 && timer.CurrentTime >= cooldown;

        /// <summary>
        /// true if the timer has already been started
        /// </summary>
        public bool IsStarted => timer.IsStarted;
        /// <summary>
        /// true if the timer is currently paused
        /// </summary>
        public bool IsPaused => timer.IsPaused;

        private InfiniteTimer timer;
        private float cooldown;
        /// <summary>
        /// edcides wheather the displaying of the time should be inverted or not
        /// </summary>
        public bool inverted;
        #endregion

        #region Start/Stop/Restert
        /// <summary>
        /// starts the timer, will not work if the timer has already started
        /// </summary>
        /// <param name="_cooldown">the time limit the timer can't pass</param>
        public void Start(float _cooldown)
        {
            if (!timer.IsStarted)
                Restart(_cooldown);
        }
        /// <summary>
        /// restarts the timer even if it's already running
        /// </summary>
        /// <param name="_cooldown">the time limit the timer can't pass</param>
        public void Restart(float _cooldown)
        {
            timer.Restart();
            cooldown = _cooldown;
        }
        /// <summary>
        /// stops the timer
        /// </summary>
        public void Stop()
        {
            timer.Stop();
            cooldown = 0;
        }
        #endregion

        #region Pause/Resume
        /// <summary>
        /// pauses the timer at the current time
        /// </summary>
        public void Pause() => timer.Pause();
        /// <summary>
        /// resumes the timer if it's paused
        /// </summary>
        public void Resume() => timer.Resume();
        #endregion
    }
}