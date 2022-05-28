using RiseOfArabs.DevTools.SimpleTimers.Extensions;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RiseOfArabs.DevTools.SimpleTimers
{
    [AddComponentMenu(ATimer_H.TimersPath + nameof(TimeSegmentsController)), DisallowMultipleComponent]
    public class TimeSegmentsController : UpdatedClass
    {
        #region Info
        /// <summary><see cref="TimerRecorder_X_H"/> used to get records data from</summary>
        [Tooltip("TimerRecorder_X_H used to get records data from")]
        [SerializeField] private TimerRecorder_X_H recorder;

        /// <summary>List of all <see cref="TimeSegment"/>s being controlled by this <see cref="TimeSegmentsController"/></summary>
        [Tooltip("List of all segments being controlled by this TimeSegmentsController")]
        [HideInInspector] public List<TimeSegment> segments;
        /// <summary><see cref="TextMeshProUGUI"/> that current time will be printed on</summary>
        [Tooltip("TextMeshProUGUI that current time will be printed on")]
        [SerializeField] private TextMeshProUGUI currentTimeText;
        /// <summary>Prefab used for instantiation</summary>
        [Tooltip("Prefab used for instantiation")]
        [SerializeField] private TimeSegment segmentPrefab;
        /// <summary>The <see cref="Transform"/> that holds <see cref="TimeSegment"/>s as childs</summary>
        [Tooltip("The transform that holds segments as childs")]
        [SerializeField] private Transform segmentsHolder;
        #endregion

        #region Main
        private void Awake() => Subscribe();
        private void Start()
        {
            segments = new List<TimeSegment>(GetComponentsInChildren<TimeSegment>());
            recorder.Recorded.AddListener(UpdateUI);
        }
        protected override void TypedUpdate() => currentTimeText.text = recorder.Timer_H.Timer.CurrentTime.ToString("00.00");

        private void OnDestroy() => recorder.Recorded.RemoveListener(UpdateUI);
        #endregion

        #region Other
        /// <summary>Updates all segments data and UI to match the <see cref="recorder"/>'s records</summary>
        [ContextMenu(nameof(UpdateUI))]
        public void UpdateUI()
        {
            int _count = recorder.Records.Count;
            for (int _i = 0; _i < _count; _i++)
                if (segments.Count >= _count)
                {
                    if (segments[_i] == null)
                        segments[_i] = GetNewSegment(_i);
                    else
                        SetupSegment(segments[_i], _i);
                }
                else
                    segments.Add(GetNewSegment(_i));
        }

        private TimeSegment GetNewSegment(int _index)
        {
            TimeSegment _newSegment = Instantiate(segmentPrefab, segmentsHolder);
            SetupSegment(_newSegment, _index);
            return _newSegment;
        }
        private void SetupSegment(TimeSegment _segment, int _index) => _segment.Data = recorder.Records[_index];
        #endregion
    }
}