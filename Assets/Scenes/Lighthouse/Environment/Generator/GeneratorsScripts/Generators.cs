using System;
using UnityEngine;

public class Generators : TriggerZone
{
    private bool isWorked = true;
    private float workTime;
    private int start;

    void Start()
    {
        System.Random random = new System.Random();
        workTime = random.Next(10, 30);
        start = Environment.TickCount;
    }

    void Update()
    {
        int end = Environment.TickCount;
        if ((end - start) / 1000 > workTime)
        {
            //Debug.Log("Время вышло");
            isWorked = false;
        }

        if (canvas.enabled == true && Input.GetKey(KeyCode.E))
        {
            canvas.enabled = false;
        }
    }
}
