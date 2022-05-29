using NUnit.Framework;
using static NUnit.Framework.Assert;
using static System.Enum;

namespace RiseOfArabs.DevTools.SimpleTimers
{
    public static class time_text
    {
        [Test] public static void all_identifier()
        {
            var _tests = new char[] { 's', 'm', 'h', 'd' };
            for (int i = 0; i < GetNames(typeof(Time_Ts)).Length; i++)
                AreEqual(_tests[i], TextTime_Xs.timeIdentifiers[i]);
        }

        [Test] public static void all_full_clock_timer()
        {
            var _clocks = new string[] { "01", "01:00", "01:00:00", "01:00:00:00" };
            for (int i = 0; i < GetNames(typeof(Time_Ts)).Length; i++)
            {
                var _type = (Time_Ts)i;
                var _time = 1f.ConvertTime(_type);
                AreEqual(_clocks[i], _time.ClockTimer(_type));
            }
        }

        [Test] public static void all_2_and_a_half_clock_timer()
        {
            var _clocks = new string[] { "02", "02:30", "02:30:00", "02:12:00:00" };
            for (int i = 0; i < GetNames(typeof(Time_Ts)).Length; i++)
            {
                var _type = (Time_Ts)i;
                var _time = 2.5f.ConvertTime(_type);
                AreEqual(_clocks[i], _time.ClockTimer(_type));
            }
        }
    }
}