using System;
using UnityEngine;
using UnityEngine.Events;

namespace RiseOfArabs.DevTools.SimpleTimers.Extensions
{
    [Serializable]
    public class Wave
    {
        #region Info
        /// <summary>Returns true if wave has reached the max amount of times for repeating</summary>
        public bool MaxedOut => currentRepeat >= MaxRepeat;
        /// <summary>The time the next wave will hit at</summary>
        public float NextWave => waveTime * multiplier * (currentRepeat + 1);
        /// <summary>The time the preivous wave has hit at</summary>
        public float PreviousWave => waveTime * multiplier * (currentRepeat - 1);

        /// <summary>Time used to determine when waves should hit</summary>
        [Tooltip("Time used to determine when waves should hit")]
        [Min(1)] public float waveTime;

        /// <summary>The value will be used to calculate next wave</summary>
        [Tooltip("The value will be used to calculate next wave")]
        [Min(.01f)] public int multiplier;
        /// <summary>Maxmimum amount of times the wave should repeat</summary>
        public int MaxRepeat => maxRepeat > 0 ? maxRepeat : int.MaxValue;
        /// <summary>Maxmimum amount of times the wave should repeat</summary>
        [Tooltip("Maxmimum amount of times the wave should repeat")]
        [Min(0), SerializeField] private int maxRepeat;
        /// <summary>Number of times wave has been repeated</summary>
        public int CurrentRepeat => currentRepeat;
        /// <summary>Number of times wave has been repeated</summary>
        private int currentRepeat;

        /// <summary>Called whenever this wave hits a repeatetion</summary>
        [Tooltip("Called whenever this wave hits a repeatetion")]
        public UnityEvent<int> OnWaved;
        #endregion

        #region Main
        public Wave(float _waveTime, int _maxRepeat = 0, int _multiplier = 1)
        {
            waveTime = _waveTime;
            maxRepeat = _maxRepeat;
            multiplier = _multiplier;
            currentRepeat = 0;
            OnWaved = null;
        }
        #endregion

        #region Other
        /// <summary>Returns <see cref="currentRepeat"/> after increasing it by <see cref="multiplier"/></summary>
        public int Increase() => currentRepeat += multiplier;
        #endregion
    }
}