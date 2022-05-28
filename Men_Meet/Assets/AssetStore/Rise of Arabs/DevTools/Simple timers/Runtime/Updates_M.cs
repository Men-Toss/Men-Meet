using System;
using UnityEngine;
using static RiseOfArabs.DevTools.SimpleTimers.Update_Ts;

namespace RiseOfArabs.DevTools.SimpleTimers
{
    public enum Update_Ts { Fixed, Normal, Late }
    [AddComponentMenu(ATimer_H.TimersPath + nameof(Updates_M))]
    public class Updates_M : MonoBehaviour
    {
        #region Info
        public static event Action<Update_Ts> UpdatedTyped;
        public static event Action FixedUpdated, Updated, LateUpdated;
        #endregion

        #region Main
        private void FixedUpdate()
        {
            FixedUpdated?.Invoke();
            UpdatedTyped?.Invoke(Fixed);
        }
        private void Update()
        {
            Updated?.Invoke();
            UpdatedTyped?.Invoke(Normal);
        }
        private void LateUpdate()
        {
            LateUpdated?.Invoke();
            UpdatedTyped?.Invoke(Late);
        }
        #endregion
    }
}