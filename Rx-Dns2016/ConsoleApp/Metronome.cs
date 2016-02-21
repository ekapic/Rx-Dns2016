using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Metronome
    {
        public event TickHandler Tick;
        public delegate void TickHandler(Metronome m, TimeOfTick e);
        public void Start()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(3000);
                if (Tick != null)
                {
                    TimeOfTick TOT = new TimeOfTick();
                    TOT.Time = DateTime.Now;
                    Tick(this, TOT);
                }
            }
        }
    }
}
