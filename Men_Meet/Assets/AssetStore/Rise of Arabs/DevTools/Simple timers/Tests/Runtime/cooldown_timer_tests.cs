using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using static NUnit.Framework.Assert;

namespace RiseOfArabs.DevTools.SimpleTimers
{
    public static class cooldown_timer_tests
    {
        private static CooldownTimer timer = new CooldownTimer();

        [UnityTest] public static IEnumerator timer_current_time()
        {
            timer.Restart(2);
            timer.inverted = true;
            AreEqual(2, (int)timer.CurrentTime);
            timer.inverted = false;
            AreEqual(0, (int)timer.CurrentTime);
            yield return new WaitForSecondsRealtime(1);
            timer.inverted = true;
            AreEqual(0, (int)timer.CurrentTime);
            timer.inverted = false;
            AreEqual(1, (int)timer.CurrentTime);
        }

        [UnityTest] public static IEnumerator timer_is_ready()
        {
            timer.Restart(1);
            yield return new WaitForSecondsRealtime(.5f);
            AreEqual(false, timer.IsReady);
            yield return new WaitForSecondsRealtime(.5f);
            AreEqual(true, timer.IsReady);
        }

        [UnityTest] public static IEnumerator timer_percentage()
        {
            timer.Restart(.5f);
            yield return new WaitForSecondsRealtime(1);
            timer.inverted = false;
            AreEqual(1, timer.CurrentTimePercentage);
            timer.inverted = true;
            AreEqual(0, timer.CurrentTimePercentage);
        }
    }
}