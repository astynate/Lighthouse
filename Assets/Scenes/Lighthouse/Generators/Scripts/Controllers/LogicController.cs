using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicController : MonoBehaviour
{

    public Night CurrentNight;
    public Time CurrentTime;
    public float TimeLeft;
    public Action<Night> EndNightCall;
    public GeneratorHandler generatorHandler{get; private set;} = new();
    private float TimeNightStarted;
    private Queue<Night> nights= new Queue<Night>();
    
    void Awake(){
        nights.Enqueue(new Night("First",1,180));
        nights.Enqueue(new Night("Second",2,180));
        nights.Enqueue(new Night("Third",3,180));
        nights.Enqueue(new Night("Fourth",3,180));
    }
    void Start()
    {
        GameObject.FindAnyObjectByType<UiController>().StartNewNight += ChangeNight;
        ChangeNight();
    }

    void Update()
    {
        TimeLeft = CurrentNight.Duration - (Time.time - TimeNightStarted);
        if(TimeLeft < 0){
            EndNightCall.Invoke(CurrentNight);
        }
    }
    void ChangeNight(){
        TimeNightStarted = Time.time;
        CurrentNight = nights.Dequeue();
    }
}
