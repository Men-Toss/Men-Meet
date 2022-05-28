using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RiseOfArabs.DevTools.SimpleTimers.Extensions
{
    [AddComponentMenu(ATimer_H.TimersPath + nameof(TimerWaves_X_H))]
    [RequireComponent(typeof(ATimer_H))]
    [DisallowMultipleComponent]
    public partial class TimerWaves_X_H : ATimer_X_H<ATimer_H>
    {
        #region Info
        /// <summary>Is waves list empty</summary>
        public bool IsListNullOrEmpty => waves == null || waves.Count < 1;

        ///// <summary>Wavers to be used for waving</summary>
        //[Tooltip("Wavers to be used for waving")]
        public List<Wave> waves;
        #endregion

        #region Main
        protected override void TypedUpdate()
        {
            if (IsListNullOrEmpty) return;
            foreach (var _waver in waves)
                if (_waver.OnWaved != null && !_waver.MaxedOut && timer_H.Timer.CurrentTime > _waver.NextWave)
                    _waver.OnWaved.Invoke(_waver.Increase());
        }
        #endregion
    }
}