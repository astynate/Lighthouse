using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGenerator : BasicGenerator
{
    public override void HandleRepair()
    {
        if(this._isPlayerInside){
            IsWorking = true;
            InvokeRepair();
        }
    }
}
