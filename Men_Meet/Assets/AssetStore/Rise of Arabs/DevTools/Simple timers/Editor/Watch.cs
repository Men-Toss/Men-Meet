// Inspired from Tarodev : https://youtu.be/FObIXskxLWk

using System;
using System.Diagnostics;
using static System.Diagnostics.Stopwatch;
using static UnityEngine.Debug;

namespace RiseOfArabs.DevTools.SimpleTimers
{
    public class Watch : IDisposable
    {
        #region Info
        private readonly string text;
        private readonly Stopwatch watch;
        #endregion

        #region Main
        public Watch(string _text)
        {
            text = _text;
            watch = StartNew();
        }
        #endregion

        #region Other
        public void Dispose()
        {
            watch.Stop();
            Log(text + ": " + watch.ElapsedMilliseconds);
        }
        #endregion
    }
}