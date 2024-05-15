using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Yd.TimeSystem{
public class Night
{
    public Night(string nightName, int maxBrokenGenerators, float duration){
        this.NightName = nightName;
        this.MaxBrokenGenerators = maxBrokenGenerators;
        this.Duration = duration;
    }
    public string NightName { get; private set; }
    public int MaxBrokenGenerators { get; private set; }
    public float Duration{ get; private set; }
    public List<BasicGenerator> RepairedGenerators{get;set;}
}
}
