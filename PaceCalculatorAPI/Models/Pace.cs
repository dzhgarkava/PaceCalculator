using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaceCalculatorAPI.Models
{
    public class Pace
    {
        public Pace(int minutes, int seconds)
        {
            Minutes = minutes;
            Seconds = seconds;
        }

        private int Minutes { get; }
        private int Seconds { get; }

        public override string ToString()
        {
            var min = Minutes < 10 ? $"0{Minutes}" : $"{Minutes}";
            var sec = Seconds < 10 ? $"0{Seconds}" : $"{Seconds}";
            return $"{min}:{sec} min/km";
        }

        public string GetFinishTime(double distance)
        {
            var secPerKm = Minutes * 60 + Seconds;
            var totalSec = distance * secPerKm;

            var s = (int)totalSec;
            var finishHours = s / 3600;
            s = s % 3600;
            var finishMin = s / 60;
            s = s % 60;
            var finishSec = s;

            var hour = finishHours < 10 ? $"0{finishHours}" : $"{finishHours}";
            var min = finishMin < 10 ? $"0{finishMin}" : $"{finishMin}";
            var sec = finishSec < 10 ? $"0{finishSec}" : $"{finishSec}";
            return $"{hour}:{min}:{sec}";
        }
    }
}
