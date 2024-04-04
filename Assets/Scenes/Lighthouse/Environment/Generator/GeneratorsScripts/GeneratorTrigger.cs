using System;
using UnityEngine;

public class GeneratorTrigger : MonoBehaviour
{
    public Canvas canvasE;
    private bool isWorked = true;
    private float workTime;
    private int start;

  
    // Start is called before the first frame update
    void Start()
    {
        System.Random random = new System.Random();
        workTime = random.Next(10, 30);
        start = Environment.TickCount;
    }

    // Update is called once per frame
    void Update()
    {
        int end = Environment.TickCount;
        if ((end - start) / 1000 > workTime)
        {
            //Debug.Log("Время вышло");
            isWorked = false;
        }

        if (canvasE.enabled == true && Input.GetKey(KeyCode.E))
        {
            canvasE.enabled = false;
        }
    }

    public void OnTriggerEnter(Collider other) => canvasE.enabled = true;

    public void OnTriggerExit(Collider other) => canvasE.enabled = false;
}
