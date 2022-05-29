using NUnit.Framework;
using static NUnit.Framework.Assert;
using static System.Enum;

namespace RiseOfArabs.DevTools.SimpleTimers
{
    public static class time_conversion
    {
        [Test] public static void all_conversions()
        {
            var _tests = new float[] { 1f, 60f, 3600f, 86400f };
            for (int i = 0; i < GetNames(typeof(Time_Ts)).Length; i++)
                AreEqual(_tests[i], 1f.ConvertTime((Time_Ts)i));
        }
    }
}