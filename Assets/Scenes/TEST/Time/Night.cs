using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yd.Generators;
using Yd.Generators.Yd.Generators;
namespace Yd.Time
{
    public class Night
    {
        public Night(string nightName, int addedHeneratorsCount, float duration)
        {
            this.NightName = nightName;
            this.AddedHeneratorsCount = addedHeneratorsCount;
            this.Duration = duration;
        }
        public string NightName { get; private set; }
        public int AddedHeneratorsCount { get; private set; }
        public float Duration { get; private set; }
        public List<BasicGenerator> RepairedGenerators { get; set; }
    }
}

