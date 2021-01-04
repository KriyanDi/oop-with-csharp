using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    //#1
    public class AlarmEventArgs : EventArgs
    {
        private readonly int nrigns = 0;
        private readonly bool snoozedPressed = false;

        public string AlarmText { get; set; }
        public int NumRings { get; set; }
        public bool SnoozedPressed { get; set; }
    }

    //#2
    public delegate void AlarmEventHandler(object s, AlarmEventArgs e);

    //#3
    class AlarmClock
    {
        public event AlarmEventHandler Alarm;

        protected virtual void OnAlarm(AlarmEventArgs e)
        {
            Alarm?.Invoke(this, e);
        }

        //#4
        public void AlarmRang(object s, AlarmEventArgs e)
        {
            this.Alarm += this.AlarmRang;
        }
    }

    
}
