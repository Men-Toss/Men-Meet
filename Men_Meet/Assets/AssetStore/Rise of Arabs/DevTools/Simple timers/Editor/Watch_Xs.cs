using System;

namespace RiseOfArabs.DevTools.SimpleTimers
{
    public static class Watch_Xs
    {
        public static void Compare(this Action _action1, Action _action2, int _times = 10000)
        {
            using (new Watch("Action_1"))
                for (int i = 0; i < _times; i++)
                    _action1.Invoke();

            using (new Watch("Action_2"))
                for (int i = 0; i < _times; i++)
                    _action2.Invoke();
        }
        public static void Compare<T>(this Func<T> _action1, Func<T> _action2, int _times = 10000)
        {
            using (new Watch("Action_1"))
                for (int i = 0; i < _times; i++)
                    _action1.Invoke();

            using (new Watch("Action_2"))
                for (int i = 0; i < _times; i++)
                    _action2.Invoke();
        }
    }
}