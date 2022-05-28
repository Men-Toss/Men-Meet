using UnityEngine;
using static RiseOfArabs.DevTools.SimpleTimers.Update_Ts;
using static RiseOfArabs.DevTools.SimpleTimers.Updates_M;


namespace RiseOfArabs.DevTools.SimpleTimers.Extensions
{
    public abstract class UpdatedClass : MonoBehaviour
    {
        #region Info
        /// <summary>The update type this timer extension will run at</summary>
        public Update_Ts Type
        {
            get => type; set
            {
                Unsubscribe();
                Subscribe();
                type = value;
            }
        }
        /// <summary>The update type this timer extension will run at</summary>
        [Tooltip("The update type this timer extension will run at")]
        [SerializeField] private Update_Ts type = Normal;
        #endregion

        #region Main
        /// <summary>Runs every frame</summary>
        protected abstract void TypedUpdate();
        #endregion

        #region Subscription
        protected void Subscribe()
        {
            switch (type)
            {
                case Fixed: FixedUpdated += TypedUpdate; break;
                case Normal: Updated += TypedUpdate; break;
                case Late: LateUpdated += TypedUpdate; break;
            }
        }
        protected void Unsubscribe()
        {
            FixedUpdated -= TypedUpdate;
            Updated -= TypedUpdate;
            LateUpdated -= TypedUpdate;
        }
        #endregion
    }
}