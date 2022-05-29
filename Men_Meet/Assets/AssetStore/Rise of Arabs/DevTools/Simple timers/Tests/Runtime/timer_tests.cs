using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using static NUnit.Framework.Assert;

namespace RiseOfArabs.DevTools.SimpleTimers
{
    public static class timer_tests
    {
        private static InfiniteTimer timer = new InfiniteTimer();
        private static int Current => (int)timer.CurrentTime;

        #region Timer main properities
        [UnityTest]
        public static IEnumerator timer_current_time()
        {
            timer.Restart();
            for (int i = 1; i <= 3; i++)
            {
                yield return new WaitForSecondsRealtime(1);
                AreEqual(i, Current);
            }
        }
        [UnityTest]
        public static IEnumerator timer_is_started_and_is_paused()
        {
            timer.Stop();
            AreEqual(false, timer.IsStarted);
            AreEqual(false, timer.IsPaused);
            timer.Start();
            yield return new WaitForSecondsRealtime(.1f);
            AreEqual(true, timer.IsStarted);
            timer.Pause();
            AreEqual(true, timer.IsPaused);
        }
        #endregion

        #region Timer main methods
        [UnityTest]
        public static IEnumerator timer_start()
        {
            timer.Stop();
            timer.Start();
            yield return new WaitForSecondsRealtime(1);
            AreEqual(1, Current);
            timer.Start();
            AreEqual(1, Current);
        }

        [UnityTest]
        public static IEnumerator timer_restart()
        {
            timer.Restart();
            yield return new WaitForSecondsRealtime(1);
            AreEqual(1, Current);
            timer.Restart();
            AreEqual(0, Current);
            yield return new WaitForSecondsRealtime(1);
            AreEqual(1, Current);
        }

        [UnityTest]
        public static IEnumerator timer_stop()
        {
            timer.Restart();
            yield return new WaitForSecondsRealtime(1);
            AreEqual(1, Current);
            timer.Stop();
            AreEqual(0, Current);
            yield return new WaitForSecondsRealtime(1);
            AreEqual(0, Current);
        }

        [UnityTest]
        public static IEnumerator timer_pause_and_resume()
        {
            timer.Restart();
            yield return new WaitForSecondsRealtime(1);
            AreEqual(1, Current);
            timer.Pause();
            yield return new WaitForSecondsRealtime(1);
            AreEqual(1, Current);
            timer.Resume();
            yield return new WaitForSecondsRealtime(1);
            AreEqual(2, Current);
        }
        #endregion
    }
}