using System.Text;
using static RiseOfArabs.DevTools.SimpleTimers.TimeConversion_Xs;
using static RiseOfArabs.DevTools.SimpleTimers.Time_Ts;
using static UnityEngine.Mathf;
using static RiseOfArabs.DevTools.SimpleTimers.Clock_Ts;

namespace RiseOfArabs.DevTools.SimpleTimers
{
    public enum Clock_Ts { Normal, Names }
    public static class TextTime_Xs
    {
        #region Info
        /// <summary>
        /// the letters that represent each time type
        /// </summary>
        public static char[] timeIdentifiers =
        {
            's', // seconds
            'm', // minutes
            'h', // hours
            'd', // days
        };
        #endregion

        #region text conversion
        /// <summary>
        /// returns the time as clock time with the style of choice
        /// </summary>
        /// <param name="_t">the time</param>
        /// <param name="_as">the maximum time type</param>
        /// <param name="_inverted">if true, inverts the order of the time types</param>
        /// <param name="_type">type of the style of the clock time</param>
        /// <param name="_format">the format for amount of digits for each time type</param>
        /// <returns></returns>
        public static string ClockTimer(this float _t, Time_Ts _as, Clock_Ts _type = Normal, string _format = "00")
        {
            var _builder = new StringBuilder();
            for (int i = (int)_as; i > -1; i--)
            {
                _builder.Append(Round(_t.GetCorrectStyle(i)).ToString(_format));
                _type.AppendIdentifier(_builder, i);
            }
            return _builder.ToString();
        }

        private static float GetCorrectStyle(this float _t, int _as) => _t / 1f.ConvertTime((Time_Ts)_as, Seconds) % timeSteps[_as];
        private static void AppendIdentifier(this Clock_Ts _type, StringBuilder _builder, int _index)
        {
            switch (_type)
            {
                case Normal:
                    if (_index > 0) _builder.Append(':');
                    break;
                case Names:
                    _builder.Append(timeIdentifiers[_index] + ' ');
                    break;
            }
        }
        #endregion
    }
}