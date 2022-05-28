using static RiseOfArabs.DevTools.SimpleTimers.Time_Ts;

namespace RiseOfArabs.DevTools.SimpleTimers
{
    public enum Time_Ts
    {
        Seconds,
        Minutes,
        Hours,
        Days,
    }
    public static class TimeConversion_Xs
    {
        #region Constants
        /// <summary>
        /// the step between each time type
        /// </summary>
        public static int[] timeSteps =
        {
            60, // Seconds
            60, // Minutes
            24, // Hours
            7, // Days
        };
        #endregion

        #region Conversion
        /// <summary>
        /// converts the time from type to another
        /// </summary>
        /// <param name="_t">the time that will be converted</param>
        /// <param name="_from">the current type of the time</param>
        /// <param name="_to">the type to convert to</param>
        /// <returns></returns>
        public static float ConvertTime(this float _t, Time_Ts _from, Time_Ts _to = Seconds) =>
            _from > _to ? UpToDown(_t, _from, _to) : _from < _to ? DownToUp(_t, _from, _to) : _t;

        private static float UpToDown(float _time, Time_Ts _type, Time_Ts _returnType)
        {
            for (int i = (int)_returnType; i < (int)_type; i++) _time *= timeSteps[i];
            return _time;
        }
        private static float DownToUp(float _time, Time_Ts _type, Time_Ts _returnType)
        {
            for (int i = (int)_type; i < (int)_returnType; i++) _time /= timeSteps[i];
            return _time;
        }
        #endregion
    }
}