using UnityEditor;

namespace RiseOfArabs.DevTools.SimpleTimers.Extensions
{
    public abstract class ATimer_X_H<Timer_H_T> : UpdatedClass
        where Timer_H_T : ATimer_H
    {
        #region Info
        /// <summary>timer holder on this gameObject</summary>
        public Timer_H_T Timer_H => timer_H;
        /// <summary>timer holder on this gameObject</summary>
        protected Timer_H_T timer_H;
        #endregion

        #region Main
        /// <summary>Gets the component of the timer holder on this gameObject</summary>
        protected virtual void Awake() => timer_H = GetComponent<Timer_H_T>();
        /// <summary>Subscribes to timer starting events</summary>
        protected virtual void OnEnable()
        {
            timer_H.start_restart_stop.Started.AddListener(Starting);
            timer_H.start_restart_stop.Restarted.AddListener(Starting);
            if (timer_H is CooldownTimer_H) (timer_H as CooldownTimer_H).ready.Ready.AddListener(Ready);
        }
        /// <summary>Unsubscribes from timer starting events</summary>
        protected virtual void OnDisable()
        {
            timer_H.start_restart_stop.Started.RemoveListener(Starting);
            timer_H.start_restart_stop.Restarted.RemoveListener(Starting);
        }
        /// <summary>Unsubscribes from the update event</summary>
        protected virtual void OnDestroy() => Unsubscribe();
        /// <summary>Unsubscribes and subscribes to the currect update</summary>
        protected virtual void OnValidate()
        {
#if UNITY_EDITOR
            if ( !EditorApplication.isPlaying )
                return;
#endif
            Unsubscribe();
            Subscribe();
        }
        #endregion

        #region Other
        private void Ready()
        {
            (timer_H as CooldownTimer_H).ready.Ready.RemoveListener(Ready);
            Unsubscribe();
        }
        /// <summary>Called when timer holder starts or restarts the timer</summary>
        protected virtual void Starting() => Subscribe();
        #endregion
    }
}