using System;
using UnityEngine;

namespace UnityUtils.Saves
{
    public static class DateChecker
    {
        public static Action LoadOnNewDateCallback;
        
        public static void CheckSaveDate(DateTime saveDate, bool logDaysPassed = false)
        {
            var now = DateTime.Now;
            
            var daysPassed = 
                (now.DayOfYear > saveDate.DayOfYear || now.Year > saveDate.Year);
            
            if(logDaysPassed) Debug.Log($"Days passed since save: {daysPassed}");

            if(daysPassed) LoadOnNewDateCallback?.Invoke();
        }
    }
}