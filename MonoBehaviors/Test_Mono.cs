using System;
using System.Collections.Generic;
using System.Text;
using ModdingUtils.MonoBehaviours;

namespace Hicard.MonoBehaviors
{
    public class Test_Mono : MonoBehavior
    {
        private int stacks = 0;
        private int Maxstacks = 20;
        public float rampUp = 1f;
        private float timeSinceShot = 1f;
        private bool coroutineStarted;

    }
}
