using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yd.Logger{
public static class OnlyDebugLogger
{
    //если мешают сообщения - закоменти тела
    public static void Log(string message){
        Debug.Log("[YD]\t" + message);
    }
    public static void Log(string message, UnityEngine.Object obj){
        Debug.Log("[YD]\t" + message,obj);
    }

}
}
