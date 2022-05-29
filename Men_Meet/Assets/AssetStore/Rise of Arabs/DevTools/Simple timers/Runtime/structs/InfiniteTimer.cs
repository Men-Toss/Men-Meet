using System;
using static UnityEngine.Time;

namespace RiseOfArabs.DevTools.SimpleTimers
{
    [Serializable]
    public struct InfiniteTimer : ITimer
    {
        #region Info
        /// <summary>
        /// the current time of the timer
        /// </summary>
        public float CurrentTime
        {
            get
            {
                var _t = time;
                return !IsStarted ? 0 : IsPaused ? _t - StartTime - PauseDifference : _t - StartTime;
            }
        }

        /// <summary>
        /// true if the timer has already been started
        /// </summary>
        public bool IsStarted => StartTime != 0;
        /// <summary>
        /// true if the timer is currently paused
        /// </summary>
        public bool IsPaused => pauseTime != 0;
        private float PauseDifference => time - pauseTime;

        private float pauseTime;
        private float StartTime;
        #endregion

        #region Start/Stop/Restert
        /// <summary>
        /// starts the timer, will not work if the timer has already started
        /// </summary>
        public void Start()
        {
            if (!IsStarted)
                Restart();
        }
        /// <summary>
        /// restart the timer even if it's running
        /// </summary>
        public void Restart()
        {
            StartTime = time;
            pauseTime = 0;
        }
        /// <summary>
        /// stops the timer and goes back to zero
        /// </summary>
        public void Stop()
        {
            StartTime = 0;
            pauseTime = 0;
        }
        #endregion

        #region Pause/Resume
        /// <summary>
        /// pause the timer at the current time
        /// </summary>
        public void Pause()
        {
            var _t = time;
            if (!IsPaused)
                pauseTime = _t;
        }
        /// <summary>
        /// resumes the timer if it's paused
        /// </summary>
        public void Resume()
        {
            if (!IsPaused) return;

            StartTime += PauseDifference;
            pauseTime = 0;
        }
        #endregion
    }
}