using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicGenerator : MonoBehaviour
{
    public float TimeBeforeEnd = 30;
    public bool IsWorking = true;
    public ParticleSystem Particles;
    // public UnityEngine.Canvas WorkingMessage;
    // public UnityEngine.Canvas NotWorkingMessage;
    public event Action EndGame;
    public event Action<BasicGenerator> RepairGenerator;
    protected bool _isPlayerInside = false;
    private System.Random random= new System.Random();
    private bool _breakdownEventGoing = false;
    private float _breakdownTime = 0 ;
    private float _breakdownTimeStart;
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player") | _isPlayerInside) return;
        _isPlayerInside = true;
        Debug.Log("Игрок вошел");
    }
    private void OnTriggerExit(Collider other)
    {
        if(!other.CompareTag("Player")) return;
        _isPlayerInside = false;
        Debug.Log("Игрок вышел");
    }
    // private void HandleStateMessage(){
    //     if(IsWorking && !WorkingMessage.gameObject.activeSelf ){
    //         NotWorkingMessage.gameObject.SetActive(false);
    //         Particles.gameObject.SetActive(false);
    //         WorkingMessage.gameObject.SetActive(true);
    //     }
    //     else if(!IsWorking && !NotWorkingMessage.gameObject.activeSelf ){
    //         WorkingMessage.gameObject.SetActive(false);
    //         NotWorkingMessage.gameObject.SetActive(true);
    //         Particles.gameObject.SetActive(true);
    //     }
    //     if(WorkingMessage.gameObject.activeSelf){
    //         WorkingMessage.transform.LookAt(transform.position + WorkingMessage.worldCamera.transform.rotation * Vector3.forward, WorkingMessage.worldCamera.transform.rotation * Vector3.up);
    //     }
    //     else if(NotWorkingMessage.gameObject.activeSelf){
    //         NotWorkingMessage.transform.LookAt(transform.position + WorkingMessage.worldCamera.transform.rotation * Vector3.forward, WorkingMessage.worldCamera.transform.rotation * Vector3.up);
    //     }
    // }
    public void BreakGenerator() =>IsWorking = false;
    private void HandleBreakdownEvent(){
        if(!IsWorking){

            if(_breakdownEventGoing){
                if(_breakdownTime > TimeBeforeEnd ){
                    Debug.Log("Конец");
                    EndGame.Invoke();
                }
            }
            else{
                _breakdownEventGoing = true;
                _breakdownTimeStart = Time.time;
            }
            _breakdownTime = Time.time-_breakdownTimeStart;
            //ebug.Log(_breakdownTime);
        }
        else{_breakdownEventGoing = false;}
    }
    protected void InvokeRepair()=>this.RepairGenerator.Invoke(this);
    public abstract void HandleRepair();
    void Update()
    {
        //HandleStateMessage();
        HandleBreakdownEvent();
        HandleRepair();
        if(IsWorking){
            Particles.gameObject.SetActive(false);
        }
        else{
            Particles.gameObject.SetActive(true);
        }

    }
}
