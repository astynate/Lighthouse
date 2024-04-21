using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    /// <summary>
    ///  короче, тут будет логика, которая должна будет быть потом у телефона. Сначала мы слушаем что произошел ивент EndNightCall,
    /// а потом сами уже вызываем делаем свой ивент, что мы поговорили по телефону 
    /// </summary>
    public System.Action StartNewNight;
    void ProccessCall(Night lastNight){
    /// <summary>
    /// сам звонок и логика с ним. В параметрах передается ночь, а в ней есть история генераторов, которые мы чинили и тд. Можно интерактив придумать
    /// </summary>
    StartNewNight.Invoke();
    }







    public Text woorking;
    public Text notWorking;
    public Text CurrentNight;
    public Text Timer;
    private GeneratorHandler generatorHandler;
    private LogicController logicController;
    void Start()
    {
        logicController = GameObject.FindAnyObjectByType<LogicController>();
        logicController.EndNightCall += ProccessCall;
        generatorHandler = logicController.generatorHandler;
    }
    void Update()
    {
        woorking.text = generatorHandler.NowWorking.ToString();
        notWorking.text = generatorHandler.NowNotWorking.ToString();
        CurrentNight.text = logicController.CurrentNight.NightName;
        Timer.text = logicController.TimeLeft.ToString();
    }
}
