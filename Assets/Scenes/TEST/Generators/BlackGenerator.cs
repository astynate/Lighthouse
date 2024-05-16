using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yd.Generators.Yd.Generators;
namespace Yd.Generators{
public class BlackGenerator : BasicGenerator
{
        public override void RepairGenerator()
        {
            if(isPLayerInside){
                InvokeRepair();
            }
        }
}
}