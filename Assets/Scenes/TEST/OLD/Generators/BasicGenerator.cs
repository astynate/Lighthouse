using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yd.Generators{
public abstract class BasicGenerator : MonoBehaviour
{
    public bool IsActive = false;
    public bool IsWorking= false;
    public float LastBreakdownTime;



    public abstract void RepairGenerator();
    public void BreakGenerator(){
        if(IsActive && IsWorking) IsWorking = false;
    } 
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
}
