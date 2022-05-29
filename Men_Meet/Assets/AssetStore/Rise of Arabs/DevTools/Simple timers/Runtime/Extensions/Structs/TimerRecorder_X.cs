using System;
using System.Collections.Generic;
using UnityEngine;

namespace RiseOfArabs.DevTools.SimpleTimers.Extensions
{
    [Serializable]
    public struct TimerRecorder_X : ITimer_X
    {
        #region Info
        /// <summary>The List that holds all records</summary>
        [Tooltip("The List that holds all saves")]
        public List<TimeSegment_D> records;
        #endregion

        #region Main
        /// <summary>MUST be called when timer starts or restarts</summary>
        [ContextMenu(nameof(Starting))]
        public void Starting() => records = new List<TimeSegment_D>();
        #endregion

        #region Other
        /// <summary>Saves timer's current time to the list</summary>
        /// <param name="_currentTime">Timer's current time, to be Recorded</param>
        [ContextMenu(nameof(Record))]
        public void Record(string _name, float _currentTime)
        {
            if (string.IsNullOrEmpty(_name))
                _name = "Record_" + records.Count;
            records.Add(new TimeSegment_D(_name, _currentTime));
        }
        #endregion
    }
    /// <summary>Types used to hold saves while printing it</summary>
    [Serializable] public struct Records_D
    {
        public TimeSegment_D[] records;
        public Records_D(TimeSegment_D[] _records) => records = _records;
    }

    [Serializable]
    public struct TimerRecorder_X<E> : ITimer_X
        where E : Enum, IComparable
    {
        #region Info
        /// <summary></summary>
        /// <param name="_e">Value of the enum used to organize savings</param>
        /// <returns>Recorded time at the specified value of the enum</returns>
        public float this[E _e] => saves[_e.ToString()];
        private readonly string[] names;

        /// <summary>The Dictionary that holds all saves</summary>
        [Tooltip("The List that holds all saves")]
        public Dictionary<string, float> saves;
        #endregion

        #region Main
        /// <summary>MUST be called at the beginning</summary>
        /// <param name="_e_T">The enum Type will be used to organize savings</param>
        public TimerRecorder_X(Type _e_T)
        {
            saves = new Dictionary<string, float>();
            names = Enum.GetNames(_e_T);
        }
        /// <summary>MUST be called when timer starts or restarts</summary>
        [ContextMenu(nameof(Starting))]
        public void Starting()
        {
            saves.Clear();
            foreach (var _name in names)
                saves.Add(_name, 0);
        }
        #endregion

        #region Other
        /// <summary>Saves timer's current time to the list</summary>
        /// <param name="_e">Saving again using the same value will not overwrite the old one</param>
        /// <param name="_currentTime">Timer's current time, to be Recorded</param>
        [ContextMenu(nameof(SaveTime))]
        public void SaveTime(E _e, float _currentTime)
        {
            var _length = names.Length;
            if (saves[names[_length - 1]] != 0) return;

            for (int i = 0; i < _length; i++)
            {
                if (saves[names[i]] != 0) continue;
                saves[names[i]] = _currentTime;
                if (names[i] == _e.ToString()) break;
            }
        }
        #endregion
    }
    /// <summary>Types used to hold saves while printing it</summary>
    [Serializable] public struct Records_D<E>
        where E : Enum, IComparable
    {
        public E type;
        public Dictionary<E, TimeSegment_D> records;
    }
}