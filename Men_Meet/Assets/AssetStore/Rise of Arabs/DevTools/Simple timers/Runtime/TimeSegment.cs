using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Runtime.Serialization;

namespace RiseOfArabs.DevTools.SimpleTimers
{
    [AddComponentMenu(ATimer_H.TimersPath + nameof(TimeSegment)), DisallowMultipleComponent]
    public class TimeSegment : MonoBehaviour
    {
        #region Info
        /// <summary>Data this segment holds</summary>
        public TimeSegment_D Data { get => data;
            set
            {
                data = value;

                if (nameText != null) nameText.text = data.name;
                if (timeText != null) timeText.text = data.time.ToString(format);
                if (iconImage != null && data.icon != null) iconImage.sprite = data.icon;
            }
        }
        /// <summary>Data this segment holds</summary>
        [Tooltip("Data this segment holds")]
        private TimeSegment_D data;

        [SerializeField] private Image iconImage;
        [SerializeField] private TextMeshProUGUI nameText, timeText;

        /// <summary>Time format will be used to print time in <see cref="timeText"/></summary>
        [Tooltip("Time format will be used to print time in timeText")]
        [SerializeField] private string format = "00.00";
        #endregion
    }

    [Serializable]
    public struct TimeSegment_D : ISerializable
    {
        #region Info
        public Sprite icon;
        public string name;
        public float time;
        #endregion

        #region Main
        public TimeSegment_D(string _name, float _time, Sprite _icon = null)
        {
            name = _name;
            time = _time;
            icon = _icon;
        }
        #endregion

        #region Serialization
        public TimeSegment_D(SerializationInfo _info, StreamingContext _context)
        {
            name = _info.GetString(NAME);
            time = _info.GetSingle(TIME);
            icon = (Sprite)_info.GetValue(ICON, ICON_TYPE);
        }
        public void GetObjectData(SerializationInfo _info, StreamingContext _context)
        {
            _info.AddValue(NAME, name);
            _info.AddValue(TIME, time);
            _info.AddValue(ICON, icon);
        }
        private const string NAME = nameof(name), TIME = nameof(time), ICON = nameof(icon);
        private static readonly Type ICON_TYPE = typeof(Sprite);
        #endregion
    }
}