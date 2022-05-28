using System;
using UnityEngine;

namespace RiseOfArabs.DevTools.SimpleTimers
{
    [AddComponentMenu(TimersPath + nameof(CooldownTimer_H))]
    public class CooldownTimer_H : ATimer_H
    {
        #region Info
        private event Action CheckIsReady;

        [Header("Cooldown timer specials")]
        public TimerEvents_4 ready;
        public override ITimer Timer => timer;
        private CooldownTimer timer;

        [Tooltip("the time type of the 'time' float variable below")]
        [Header("Time"), SerializeField]
        internal Time_Ts currentType = Time_Ts.Seconds;
        [Tooltip("the cooldown of the timer, will be converted from 'Current Type' upove to seconds on awake"), Min(0), SerializeField]
        internal float time = 5;

        public bool Inverted
        {
            get => inverted; set
            {
                timer.inverted = value;
                inverted = value;
            }
        }
        [Tooltip("if true, the timer will show time inverted"), SerializeField]
        private bool inverted;

        public bool Loop
        {
            get => loop; set => loop = value;
        }
        [Tooltip("if true, the timer will keep restarting upon finishing"), SerializeField]
        private bool loop;
        #endregion

        #region Main
        protected override void Awake()
        {
            Apply();
            base.Awake();
        }
        protected override void Start()
        {
            Inverted = Inverted;
            base.Start();
        }
        protected override void TypedUpdate()
        {
            base.TypedUpdate();
            CheckIsReady?.Invoke();
        }
#if UNITY_EDITOR
        private void OnValidate() => timer.inverted = inverted;
#endif
        #endregion

        #region Start/Restart/Resume
        [ContextMenu(nameof(StartTimer))]
        public override void StartTimer()
        {
            CheckIsReady += IsReady;
            timer.Start(time);
            base.StartTimer();
        }
        [ContextMenu(nameof(RestartTimer))]
        public override void RestartTimer()
        {
            CheckIsReady += IsReady;
            timer.Restart(time);
            base.RestartTimer();
        }
        [ContextMenu(nameof(StopTimer))]
        public override void StopTimer()
        {
            CheckIsReady -= IsReady;
            timer.Stop();
            base.StopTimer();
        }
        #endregion

        #region Pause/Resume
        [ContextMenu(nameof(PauseTimer))]
        public override void PauseTimer()
        {
            CheckIsReady -= IsReady;
            timer.Pause();
            base.PauseTimer();
        }
        [ContextMenu(nameof(ResumeTimer))]
        public override void ResumeTimer()
        {
            CheckIsReady += IsReady;
            timer.Resume();
            base.ResumeTimer();
        }
        #endregion

        #region Other
        /// <summary>
        /// Invertes the "inverted" bool value
        /// </summary>
        [ContextMenu(nameof(ToggleInverted))]
        public void ToggleInverted() => timer.inverted = !timer.inverted;

        /// <summary>
        /// Converts the time to they type chosen
        /// </summary>
        [ContextMenu(nameof(Apply))]
        public void Apply() => time = time.ConvertTime(currentType);

        private void IsReady()
        {
            if (!timer.IsReady) return;

            CheckIsReady -= IsReady;
            ready.Ready?.Invoke();

            if (Loop) RestartTimer();
        }
        #endregion
    }
}