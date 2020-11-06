using System;
using UnityEngine;

namespace UnityUtils.Saves
{
    public static class DateChecker
    {
        public static Action LoadOnNewDateCallback;
        public static Action LoadOnSameDateCallback;

        public static void CheckSaveDate(long fileTimeUtc, bool logDaysPassed = false) 
            => CheckSaveDate(DateTime.FromFileTimeUtc(fileTimeUtc), logDaysPassed);

        public static void CheckSaveDate(DateTime saveDate, bool logDaysPassed = false)
        {
            var now = DateTime.Now;

            bool daysPassed = (now - saveDate).Days >= 1;
            
            if(logDaysPassed) Debug.Log($"Days passed since save: {daysPassed}");

            if(daysPassed) LoadOnNewDateCallback?.Invoke();
            else LoadOnSameDateCallback?.Invoke();
        }
    }
}