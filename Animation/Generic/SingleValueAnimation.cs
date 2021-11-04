using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSense.Animation.Generic
{
    public class SingleValueAnimation : IAnimator
    {
        private readonly int Value;

        private bool on = false;

        public SingleValueAnimation(int value)
        {
            this.Value = value;
        }

        public int[] NextFrame(int[] bottomLayer, int numberOfZones)
        {
            int value = on ? 0 : 100;
            on = !on;
            return Enumerable.Repeat(value, numberOfZones).ToArray();
        }
    }
}
