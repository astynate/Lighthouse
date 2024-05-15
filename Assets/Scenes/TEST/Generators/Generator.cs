using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yd.Generators{
public class Generator : MonoBehaviour
{

    public bool IsWorking = false;
    public float TimeItsBroke;
    public float MaxTimeBroken = 20;
    public event Action GGEvent;

    private bool isBroken= false;

    public void BreakGenerator(){
        IsWorking = false;
    }
    public void RepairGenerator(){
        IsWorking = true;
        isBroken = false;
    }
    void Update()
    {
        if(!IsWorking){
            if(isBroken){
                //if(Time.time - TimeItsBroke > MaxTimeBroken) GGEvent.Invoke();
            }
            else{
            TimeItsBroke = Time.time;
            isBroken = true;
            }
        }
        
    }
}
}
