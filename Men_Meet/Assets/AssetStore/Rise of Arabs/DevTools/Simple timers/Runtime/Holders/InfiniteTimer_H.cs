using UnityEngine;

namespace RiseOfArabs.DevTools.SimpleTimers
{
    [AddComponentMenu(TimersPath + nameof(InfiniteTimer_H))]
    public class InfiniteTimer_H : ATimer_H
    {
        #region Info
        public override ITimer Timer => timer;
        private InfiniteTimer timer;
        #endregion

        #region Start/Restart/Resume
        [ContextMenu(nameof(StartTimer))]
        public override void StartTimer()
        {
            timer.Start();
            base.StartTimer();
        }
        [ContextMenu(nameof(RestartTimer))]
        public override void RestartTimer()
        {
            timer.Restart();
            base.RestartTimer();
        }
        [ContextMenu(nameof(StopTimer))]
        public override void StopTimer()
        {
            timer.Stop();
            base.StopTimer();
        }
        #endregion

        #region Pause/Resume
        [ContextMenu(nameof(PauseTimer))]
        public override void PauseTimer()
        {
            timer.Pause();
            base.PauseTimer();
        }
        [ContextMenu(nameof(ResumeTimer))]
        public override void ResumeTimer()
        {
            timer.Resume();
            base.ResumeTimer();
        }
        #endregion
    }
}