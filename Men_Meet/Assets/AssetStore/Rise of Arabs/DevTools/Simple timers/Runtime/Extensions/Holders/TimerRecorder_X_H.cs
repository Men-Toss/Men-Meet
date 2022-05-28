using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RiseOfArabs.DevTools.SimpleTimers.Extensions
{
    [AddComponentMenu(ATimer_H.TimersPath + nameof(TimerRecorder_X_H))]
    [RequireComponent(typeof(ATimer_H)), DisallowMultipleComponent]
    public class TimerRecorder_X_H : ATimer_X_H<ATimer_H>
    {
        #region Info
        /// <summary>The List that holds all records</summary>
        public List<TimeSegment_D> Records => recorder.records;

        /// <summary>Struct version of this extension</summary>
        [Tooltip("Struct version of this extension")]
        private TimerRecorder_X recorder;

        /// <summary>Runs whenever a saving has executed</summary>
        [Tooltip("Runs whenever a saving has executed")]
        public UnityEvent Recorded;
        #endregion

        #region Other
        protected override void Starting() => recorder.Starting();
        protected override void TypedUpdate() { }
        #endregion

        #region File
        /// <summary>Record timer's current time to the list</summary>
        [ContextMenu(nameof(Record))]
        public void Record()
        {
            recorder.Record(string.Empty, timer_H.Timer.CurrentTime);
            Recorded?.Invoke();
        }
        #endregion
    }
}